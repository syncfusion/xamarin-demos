#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Syncfusion.ZugFerd
{
    /// <summary>
    /// zugFerd Invoice
    /// </summary>
    public class ZugFerdInvoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public CurrencyCodes Currency { get; set; }
        public InvoiceType Type { get; set; }

        public UserDetails Buyer { get; set; }
        public UserDetails Seller { get; set; }

        public ZugFerdProfile Profile { get; set; }
       
        public float TotalAmount { get; set; }

        List<Product> products = new List<Product>();

        XNamespace rsm = "urn:ferd:CrossIndustryDocument:invoice:1p0";
        XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        XNamespace udt = "urn:un:unece:uncefact:data:standard:UnqualifiedDataType:15";
        XNamespace ram = "urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:12";

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void AddProduct(string productID, string productName,float price, float quantity, float totalPrice)
        {
            Product product = new Product()
            {
                ProductID = productID,
                productName = productName,
                Price = price,
                Quantity = quantity,
                Total = totalPrice
            };

            products.Add(product);
        }

        public ZugFerdInvoice(string invoiceNumber, DateTime invoiceDate, CurrencyCodes currency)
        {            
            InvoiceNumber= invoiceNumber;
            InvoiceDate = invoiceDate;            
            Currency = currency;
                  
        }
        public Stream Save(Stream stream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;


            XDocument doc = new XDocument();
            XElement root = new XElement(rsm + "CrossIndustryDocument", new XAttribute(XNamespace.Xmlns + "xsi", xsi));          
            root.SetAttributeValue(XNamespace.Xmlns + "rsm", rsm);         
            root.SetAttributeValue(XNamespace.Xmlns + "ram", ram);
            root.SetAttributeValue(XNamespace.Xmlns + "udt", udt);

            #region SpecifiedExchangedDocumentContext
            XElement SpecifiedExchangedDocumentContext = new XElement(rsm + "SpecifiedExchangedDocumentContext");
            XElement testIndicator = new XElement(ram + "TestIndicator");
            XElement udtIndicator = new XElement(udt + "Indicator");
            udtIndicator.Value = "true";
            testIndicator.Add(udtIndicator);
            SpecifiedExchangedDocumentContext.Add(testIndicator);

            XElement guidelineSpecifiedDocumentContextParameter = new XElement(ram + "GuidelineSpecifiedDocumentContextParameter");
            XElement id = new XElement(ram + "ID");
            id.Value = "urn:ferd:CrossIndustryDocument:invoice:1p0:" + Profile.ToString();
            guidelineSpecifiedDocumentContextParameter.Add(id);
            SpecifiedExchangedDocumentContext.Add(guidelineSpecifiedDocumentContextParameter);
            root.Add(SpecifiedExchangedDocumentContext);
            #endregion

            #region HeaderExchangedDocument
            XElement headerExchangedDocument = new XElement(rsm + "HeaderExchangedDocument");
            id = new XElement(ram + "ID");
            id.Value = InvoiceNumber;
            headerExchangedDocument.Add(id);
            XElement name = new XElement(ram + "Name");
            name.Value = GetInvoiceTypeName(Type);
            headerExchangedDocument.Add(name);
            XElement typeCode = new XElement(ram + "TypeCode");
            typeCode.Value = GetInvoiceTypeCode(Type).ToString();
            headerExchangedDocument.Add(typeCode);
            XElement issueDateTime = new XElement(ram + "IssueDateTime");
            XElement dateTimeString = new XElement(udt + "DateTimeString", new XAttribute("format", "102"));
            dateTimeString.Value = ConvertDateFormat(InvoiceDate, "102");
            issueDateTime.Add(dateTimeString);
            headerExchangedDocument.Add(issueDateTime);
            root.Add(headerExchangedDocument);
            #endregion

            #region SpecifiedSupplyChainTradeTransaction
            XElement specifiedSupplyChainTradeTransaction = new XElement(rsm + "SpecifiedSupplyChainTradeTransaction");
            XElement applicableSupplyChainTradeAgreement = new XElement(ram + "ApplicableSupplyChainTradeAgreement");

            XElement sellerParty = WriteUserDetails("SellerTradeParty", Seller);
            applicableSupplyChainTradeAgreement.Add(sellerParty);

            XElement buyerParty =WriteUserDetails("BuyerTradeParty", Buyer);
            applicableSupplyChainTradeAgreement.Add(buyerParty);

            specifiedSupplyChainTradeTransaction.Add(applicableSupplyChainTradeAgreement);



            XElement ApplicableSupplyChainTradeSettlement = new XElement(ram+"ApplicableSupplyChainTradeSettlement");
            XElement InvoiceCurrencyCode = new XElement(ram+ "InvoiceCurrencyCode");
            InvoiceCurrencyCode.Value = Currency.ToString("g");
            ApplicableSupplyChainTradeSettlement.Add(InvoiceCurrencyCode);
            XElement SpecifiedTradeSettlementMonetarySummation = new XElement(ram+"SpecifiedTradeSettlementMonetarySummation");
            XElement GrandTotalAmount = new XElement(ram+"GrandTotalAmount");
            GrandTotalAmount.Value = TotalAmount.ToString();
            GrandTotalAmount.SetAttributeValue("currencyID",Currency.ToString("g"));
            SpecifiedTradeSettlementMonetarySummation.Add(GrandTotalAmount);
            ApplicableSupplyChainTradeSettlement.Add(SpecifiedTradeSettlementMonetarySummation);

            specifiedSupplyChainTradeTransaction.Add(ApplicableSupplyChainTradeSettlement);

              foreach (Product product in this.products)
            {
                XElement LineItem = AddTradeLineItems(product);

                specifiedSupplyChainTradeTransaction.Add(LineItem);
            }     
            root.Add(specifiedSupplyChainTradeTransaction);
            #endregion

            doc.Add(root);
            XmlWriter writer = XmlWriter.Create(stream, settings);
            doc.WriteTo(writer);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

      private XElement AddTradeLineItems(Product product)
        {
            XElement tradeLineItem = null;
            if (products.Count == 0)
                throw new Exception("prodcut empty");

            tradeLineItem = new XElement(ram + "IncludedSupplyChainTradeLineItem");

            if (Profile != ZugFerdProfile.Basic)
            {
                XElement tradeAgreement = new XElement(ram + "SpecifiedSupplyChainTradeAgreement");
                XElement tradePrice = new XElement(ram + "GrossPriceProductTradePrice");
                XElement basisQuantity = new XElement(ram + "BasisQuantity");
                basisQuantity.Value = product.Quantity.ToString();

                tradePrice.Add(basisQuantity);
                tradeAgreement.Add(tradePrice);
                tradeLineItem.Add(tradeAgreement);
            }


            XElement SpecifiedSupplyChainTradeDelivery = new XElement(ram + "SpecifiedSupplyChainTradeDelivery");

            XElement BilledQuantity = new XElement(ram + "BilledQuantity");
            BilledQuantity.Value = product.Quantity.ToString();
            BilledQuantity.SetAttributeValue("unitCode", "KGM");
            SpecifiedSupplyChainTradeDelivery.Add(BilledQuantity);
            tradeLineItem.Add(SpecifiedSupplyChainTradeDelivery);


            XElement tradSettlement = new XElement(ram + "SpecifiedSupplyChainTradeSettlement");

            XElement monetarySummation = new XElement(ram + "SpecifiedTradeSettlementMonetarySummation");


            XElement LineTotalAmount = new XElement(ram + "LineTotalAmount");

            LineTotalAmount.Value = FormatValue(TotalAmount);
            LineTotalAmount.SetAttributeValue("currencyID", this.Currency.ToString("g"));
            monetarySummation.Add(LineTotalAmount);
            tradSettlement.Add(monetarySummation);

            tradeLineItem.Add(tradSettlement);

            XElement SpecifiedTradeProduct = new XElement(ram + "SpecifiedTradeProduct");


            XElement productName = new XElement(ram + "Name");
            productName.Value = product.productName;

            SpecifiedTradeProduct.Add(productName);

            tradeLineItem.Add(SpecifiedTradeProduct);

            return tradeLineItem;

        }
 
        private void WriteAttribute(XmlWriter writer, string tagName, string attributeName, string attributeValue, string nodeValue)
        {
            writer.WriteStartElement(tagName);
            writer.WriteAttributeString(attributeName, attributeValue);
            writer.WriteValue(nodeValue);
            writer.WriteEndElement(); 
        }

      

        private void WriteOptionalElement(XmlWriter writer, string tagName, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                writer.WriteElementString(tagName, value);
            }
        }
        private void WriteOptionalAmount(XmlWriter writer, string tagName, float value, int numDecimals = 2)
        {
            if (value !=float.MinValue)
            {
                writer.WriteStartElement(tagName);
                writer.WriteAttributeString("currencyID", Currency.ToString("g"));
                writer.WriteValue(FormatValue(value, numDecimals));
                writer.WriteEndElement();
            }
        }

 
        private XElement WriteUserDetails( string customerTag, UserDetails user)
        {
            XElement sellerTradeParty = null;
            if (user != null)
            {
                sellerTradeParty = new XElement(ram + customerTag);
                XElement id = new XElement(ram + "ID");
                sellerTradeParty.Add(id);
                id.Value = user.ID;
                XElement name = new XElement(ram + "Name");
                name.Value = user.Name;
                sellerTradeParty.Add(name);
                XElement postalTradeAddress = new XElement(ram + "PostalTradeAddress");
                XElement postcodeCode = new XElement(ram + "PostcodeCode");
                postcodeCode.Value = user.Postcode;
                postalTradeAddress.Add(postcodeCode);
                XElement lineOne = new XElement(ram + "LineOne");
                lineOne.Value = string.IsNullOrEmpty(user.ContactName) ? user.Street : user.ContactName;
                postalTradeAddress.Add(lineOne);

                XElement lineTwo = new XElement(ram + "LineTwo");
                lineTwo.Value = user.Street;
                postalTradeAddress.Add(lineTwo);


                XElement cityName = new XElement(ram + "CityName");
                cityName.Value = user.City;
                postalTradeAddress.Add(cityName);

                XElement countryID = new XElement(ram + "CountryID");
                countryID.Value = user.Country.ToString("g"); 
                postalTradeAddress.Add(countryID);

                sellerTradeParty.Add(postalTradeAddress);

            }
            return sellerTradeParty;
        }


        private string ConvertDateFormat(DateTime date, String format = "102")
        {
            if (format.Equals("102"))
            {
                return date.ToString("yyyymmdd");
            }
            else
            {
                return date.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        private string GetInvoiceTypeName(InvoiceType type)
        {
            switch (type)
            {
                case InvoiceType.Invoice: return "RECHNUNG";
                case InvoiceType.Correction: return "KORREKTURRECHNUNG";
                case InvoiceType.CreditNote: return "GUTSCHRIFT";
                case InvoiceType.DebitNote: return "";
                case InvoiceType.SelfBilledInvoice: return "";
                default: return "";
            }
        }
        private int GetInvoiceTypeCode(InvoiceType type)
        {
            if ((int)type > 1000)
            {
                type -= 1000;
            }

            return (int)type;
        }

        private string FormatValue(float value, int numDecimals = 2)
        {
            string formatString = "0.";
            for (int i = 0; i < numDecimals; i++)
            {
                formatString += "0";
            }
            return value.ToString(formatString).Replace(",", ".");
        }
      
    }
}