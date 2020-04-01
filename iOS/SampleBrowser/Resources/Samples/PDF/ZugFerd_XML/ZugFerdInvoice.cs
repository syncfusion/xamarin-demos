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

        string rsm = "urn:ferd:CrossIndustryDocument:invoice:1p0";
        string xsi = "http://www.w3.org/2001/XMLSchema-instance";
        string udt = "urn:un:unece:uncefact:data:standard:UnqualifiedDataType:15";
        string ram = "urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:12";

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void AddProduct(string productID, string productName, float price, float quantity, float totalPrice)
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
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            Currency = currency;
        }

        public Stream Save(Stream stream)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement CrossIndustryDocument = doc.CreateElement("rsm", "CrossIndustryDocument", rsm);

            CrossIndustryDocument.SetAttribute("xmlns:xsi", xsi);
            CrossIndustryDocument.SetAttribute("xmlns:rsm", rsm);
            CrossIndustryDocument.SetAttribute("xmlns:udt", udt);
            CrossIndustryDocument.SetAttribute("xmlns:ram", ram);


            XmlElement specifiedExchangedDocument = doc.CreateElement("rsm", "SpecifiedExchangedDocumentContext", rsm);


            XmlElement TestIndicator = doc.CreateElement("ram", "TestIndicator", ram);
            XmlElement Indicator = doc.CreateElement("udt", "Indicator", udt);
            Indicator.InnerText = "true";
            TestIndicator.AppendChild(Indicator);
            specifiedExchangedDocument.AppendChild(TestIndicator);

            XmlElement guidelineSpecifiedDocument = doc.CreateElement("ram", "GuidelineSpecifiedDocumentContextParameter", ram);
            XmlElement id = doc.CreateElement("ram", "ID", ram);
            id.InnerText = "urn:ferd:CrossIndustryDocument:invoice:1p0:" + Profile.ToString();
            guidelineSpecifiedDocument.AppendChild(id);
            specifiedExchangedDocument.AppendChild(guidelineSpecifiedDocument);

            CrossIndustryDocument.AppendChild(specifiedExchangedDocument);

            XmlElement headerExchangeDocument = WriteHeaderExchangeDocument(doc);


            XmlElement SpecifiedSupplyChainTradeTransaction = doc.CreateElement("rsm", "SpecifiedSupplyChainTradeTransaction", rsm);


            XmlElement ApplicableSupplyChainTradeAgreement = doc.CreateElement("ram", "ApplicableSupplyChainTradeAgreement", ram);

            XmlElement SellerTradeParty = WriteUserDetails(doc, "SellerTradeParty", Seller);

            XmlElement BuyerTradeParty = WriteUserDetails(doc, "BuyerTradeParty", Buyer);

            ApplicableSupplyChainTradeAgreement.AppendChild(SellerTradeParty);
            ApplicableSupplyChainTradeAgreement.AppendChild(BuyerTradeParty);
            SpecifiedSupplyChainTradeTransaction.AppendChild(ApplicableSupplyChainTradeAgreement);
            

            XmlElement ApplicableSupplyChainTradeSettlement = doc.CreateElement("ram", "ApplicableSupplyChainTradeSettlement", ram);
            XmlElement InvoiceCurrencyCode = doc.CreateElement("ram", "InvoiceCurrencyCode", ram);
            InvoiceCurrencyCode.InnerText = Currency.ToString("g");
            ApplicableSupplyChainTradeSettlement.AppendChild(InvoiceCurrencyCode);
            XmlElement SpecifiedTradeSettlementMonetarySummation = doc.CreateElement("ram", "SpecifiedTradeSettlementMonetarySummation", ram);
            XmlElement GrandTotalAmount = doc.CreateElement("ram", "GrandTotalAmount", ram);
            GrandTotalAmount.InnerText = TotalAmount.ToString();
            SpecifiedTradeSettlementMonetarySummation.AppendChild(GrandTotalAmount);
            ApplicableSupplyChainTradeSettlement.AppendChild(SpecifiedTradeSettlementMonetarySummation);

            SpecifiedSupplyChainTradeTransaction.AppendChild(ApplicableSupplyChainTradeSettlement);
            XmlElement LineItem = AddTradeLineItems(doc);
        
            SpecifiedSupplyChainTradeTransaction.AppendChild(LineItem);

            CrossIndustryDocument.AppendChild(headerExchangeDocument);

            CrossIndustryDocument.AppendChild(SpecifiedSupplyChainTradeTransaction);          

            doc.AppendChild(CrossIndustryDocument);

            doc.Save(stream);
            stream.Position = 0;      
           
            return stream;
        }    

        private XmlElement AddTradeLineItems(XmlDocument doc)
        {
            XmlElement IncludedSupplyChainTradeLineItem = null;
            foreach (Product product in this.products)
            {

                IncludedSupplyChainTradeLineItem = doc.CreateElement("ram", "IncludedSupplyChainTradeLineItem", ram);


                if (Profile != ZugFerdProfile.Basic)
                {
                    XmlElement SpecifiedSupplyChainTradeAgreement = doc.CreateElement("ram", "SpecifiedSupplyChainTradeAgreement", ram);
                    XmlElement GrossPriceProductTradePrice = doc.CreateElement("ram", "GrossPriceProductTradePrice", ram);
                    XmlElement BasisQuantity = doc.CreateElement("ram", "BasisQuantity", ram);
                    BasisQuantity.InnerText = product.Quantity.ToString();
                    BasisQuantity.SetAttribute("unitCode", "KGM");
                    GrossPriceProductTradePrice.AppendChild(BasisQuantity);
                    SpecifiedSupplyChainTradeAgreement.AppendChild(GrossPriceProductTradePrice);

                    IncludedSupplyChainTradeLineItem.AppendChild(SpecifiedSupplyChainTradeAgreement);

                }

                XmlElement SpecifiedSupplyChainTradeDelivery = doc.CreateElement("ram", "SpecifiedSupplyChainTradeDelivery", ram);
                XmlElement BilledQuantity = doc.CreateElement("ram", "BilledQuantity", ram);
                BilledQuantity.InnerText = product.Quantity.ToString();
                BilledQuantity.SetAttribute("unitCode", "KGM");

                SpecifiedSupplyChainTradeDelivery.AppendChild(BilledQuantity);
                IncludedSupplyChainTradeLineItem.AppendChild(SpecifiedSupplyChainTradeDelivery);

                XmlElement SpecifiedSupplyChainTradeSettlement = doc.CreateElement("ram", "SpecifiedSupplyChainTradeSettlement", ram);
                XmlElement SpecifiedTradeSettlementMonetarySummation = doc.CreateElement("ram", "SpecifiedTradeSettlementMonetarySummation", ram);

                XmlElement LineTotalAmount = doc.CreateElement("ram", "LineTotalAmount", ram);

                LineTotalAmount.InnerText = FormatValue(TotalAmount);
                LineTotalAmount.SetAttribute("currencyID", this.Currency.ToString("g"));

                SpecifiedTradeSettlementMonetarySummation.AppendChild(LineTotalAmount);
                SpecifiedSupplyChainTradeSettlement.AppendChild(SpecifiedTradeSettlementMonetarySummation);

                IncludedSupplyChainTradeLineItem.AppendChild(SpecifiedSupplyChainTradeSettlement);

                XmlElement SpecifiedTradeProduct = doc.CreateElement("ram", "SpecifiedTradeProduct", ram);

                XmlElement productElement = WriteOptionalElement(doc, "Name", product.productName);

                SpecifiedTradeProduct.AppendChild(productElement);

                IncludedSupplyChainTradeLineItem.AppendChild(SpecifiedTradeProduct);


            }
            return IncludedSupplyChainTradeLineItem;
        }
      


        private XmlElement WriteOptionalElement(XmlDocument doc, string tagName, string value)
        {
            XmlElement element = null;
            if (!String.IsNullOrEmpty(value))
            {
                element = doc.CreateElement("ram", tagName, ram);

                element.InnerText = value;
            }
            return element;
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

 
        private XmlElement WriteUserDetails(XmlDocument doc, string customerTag, UserDetails user)
        {
            XmlElement customerTagElement = null;
            if (user != null)
            {
                customerTagElement = doc.CreateElement("ram", customerTag, ram);
                if (!String.IsNullOrEmpty(user.ID))
                {
                    XmlElement ID = doc.CreateElement("ram", "ID", ram);

                    ID.InnerText = user.ID;
                    customerTagElement.AppendChild(ID);
                }

                if (!String.IsNullOrEmpty(user.Name))
                {
                    XmlElement Name = doc.CreateElement("ram", "Name", ram);
                    Name.InnerText = user.Name;
                     customerTagElement.AppendChild(Name);
                }

                XmlElement PostalTradeAddress = doc.CreateElement("ram", "PostalTradeAddress", ram);
                XmlElement PostcodeCode = doc.CreateElement("ram", "PostcodeCode", ram);
                PostcodeCode.InnerText = user.Postcode;
                PostalTradeAddress.AppendChild(PostcodeCode);

                XmlElement LineOne = doc.CreateElement("ram", "LineOne", ram);
                LineOne.InnerText = string.IsNullOrEmpty(user.ContactName) ? user.Street : user.ContactName;
                PostalTradeAddress.AppendChild(LineOne);

                if (!string.IsNullOrEmpty(user.ContactName))
                {
                    XmlElement LineTwo = doc.CreateElement("ram", "LineTwo", ram);
                    LineTwo.InnerText = user.Street;
                    PostalTradeAddress.AppendChild(LineTwo);

                }
                XmlElement CityName = doc.CreateElement("ram", "CityName", ram);
                CityName.InnerText = user.City;
                PostalTradeAddress.AppendChild(CityName);

                XmlElement CountryID = doc.CreateElement("ram", "CountryID", ram);
                CountryID.InnerText = user.Country.ToString("g");
                PostalTradeAddress.AppendChild(CountryID);

                customerTagElement.AppendChild(PostalTradeAddress);
            }
            return customerTagElement;
        }


      
        private XmlElement WriteHeaderExchangeDocument(XmlDocument doc)
        {
            #region HeaderExchangedDocument

           XmlElement headerExchangedDocument= doc.CreateElement("rsm", "HeaderExchangedDocument", rsm);
            XmlElement ID = doc.CreateElement("ram", "ID", ram);
            ID.InnerText = InvoiceNumber;
            headerExchangedDocument.AppendChild(ID);
            XmlElement Name = doc.CreateElement("ram", "Name", ram);
            Name.InnerText = GetInvoiceTypeName(Type);
            headerExchangedDocument.AppendChild(Name);
            XmlElement TypeCode = doc.CreateElement("ram", "TypeCode", ram);
            TypeCode.InnerText = GetInvoiceTypeCode(Type).ToString();
            headerExchangedDocument.AppendChild(TypeCode);


            XmlElement issueDateTime = doc.CreateElement("ram", "IssueDateTime", ram);

            XmlElement dateTimeString = doc.CreateElement("udt", "DateTimeString", udt);

            dateTimeString.SetAttribute("format", "102");

            dateTimeString.InnerText = ConvertDateFormat(InvoiceDate, "102");

            issueDateTime.AppendChild(dateTimeString);

            headerExchangedDocument.AppendChild(issueDateTime);

            #endregion
            return headerExchangedDocument;
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