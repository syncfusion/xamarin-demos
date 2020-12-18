#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Syncfusion.XlsIO;
using System.Xml;
using Foundation;

namespace SampleBrowser

{
    public static class TypeExtension
    {
        public static PropertyInfo[] GetProperties(this Type type)
        {
            IEnumerator<PropertyInfo> propertyEnum = type.GetTypeInfo().DeclaredProperties.GetEnumerator();
            IList<PropertyInfo> listProperties = new List<PropertyInfo>();
            while (propertyEnum.MoveNext())
            {
                listProperties.Add(propertyEnum.Current);
            }
            return listProperties.ToArray<PropertyInfo>();
        }
        public static PropertyInfo GetProperty(this Type type,string name)
        {
            IEnumerator<PropertyInfo> propertyEnum = type.GetTypeInfo().DeclaredProperties.GetEnumerator();
            while (propertyEnum.MoveNext())
            {
                if (propertyEnum.Current.Name == name)
                    return propertyEnum.Current;
            }
            return null;
        }
    }
    public class XlsIOExtensions
    {
        
        /// <summary>
        /// Import XML file into XlsIO
        /// </summary>
        /// <param name="fileStream">XML file stream</param>
        /// <param name="sheet">Worksheet to import</param>
        /// <param name="row">Row to which import begin</param>
        /// <param name="col">Column to which import begin</param>
        /// <param name="header">Imports header if true</param>
        public void ImportXML(Stream fileStream, IWorksheet sheet, int row, int col, bool header)
        {
			XmlReader reader = XmlReader.Create(fileStream);
            IEnumerable<Customers> customers = GetData(reader);
            PropertyInfo[] propertyInfo = null;
            bool headerXML = true; int newCol = col;
            foreach (object obj in customers)
            {
                if (obj != null)
                {
                    propertyInfo = obj.GetType().GetProperties();
                    if (header && headerXML)
                    {
                        foreach (var cell in propertyInfo)
                        {
                            sheet[row, newCol].Text = cell.Name;
                            newCol++;
                        }
                        row++;
                        headerXML = false;
                    }
                    newCol = col;
                    foreach (var cell in propertyInfo)
                    {
                        Type currentRecordType = obj.GetType();
                        PropertyInfo property = currentRecordType.GetProperty(cell.Name);

                        sheet[row, newCol].Value2 = property.GetValue(obj, null);

                        newCol++;
                    }
                    headerXML = false;
                    row++;
                }
            }
        }

		private IEnumerable<Customers> GetData(XmlReader reader )
		{

			List<Customers> collection = new List<Customers>();

			string customers = "";
			string companyName = "";
			string contactName = "";
			string contactTitle = "";
			string address = "";
			string city = "";
			string postalCode = "";
			string country = "";
			string phone = "";
			string fax = "";

			while (reader.Read ()) 
			{
				if (reader.IsStartElement ()) 
				{
					switch (reader.Name) 
					{
					case "Customers":
						while (reader.Read ()) {
							if (reader.IsStartElement ()) {
								switch (reader.Name) {

								case "CustomerID":
									reader.Read ();
									customers = reader.Value;
									break;
								case "CompanyName":
									reader.Read ();
									companyName = reader.Value;
									break;
								case "ContactName":
									reader.Read ();
									contactName = reader.Value;
									break;
								case "ContactTitle":
									reader.Read ();
									contactTitle = reader.Value;
									break;
								case "Address":
									reader.Read ();
									address = reader.Value;
									break;
								case "City":
									reader.Read ();
									city = reader.Value;
									break;
								case "PostalCode":
									reader.Read ();
									postalCode = reader.Value;
									break;
								case "Country":
									reader.Read ();
									country = reader.Value;
									break;
								case "Phone":
									reader.Read ();
									phone = reader.Value;
									break;
								case "Fax":
									reader.Read ();
									fax = reader.Value;
									Customers temp = new Customers (customers, companyName, contactName, contactTitle, address, city, postalCode, country, phone, fax); 
									collection.Add (temp);
									break;

								}
							} else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Customers")
								break;
						}
						break;

					}
				}
			}

			return collection.AsEnumerable();

		}

    }

    [Preserve(AllMembers = true)]
    public class Customers
    {
		public Customers(string id, string company,string name, string title,string address,string city,string code,string country,string phone,string fax)
		{
			CustomerID = id;
			CompanyName = company;
			ContactName = name;
			ContactTitle = title;
			Address = address;
			City = city;
			PostalCode = code;
			Country = country;
			Phone = phone;
			Fax = fax;
		}
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }


    [Preserve(AllMembers = true)]
    public class CLRObject
    {
        public string SalesPerson { get; set; }
        public int SalesJanJune { get; set; }
        public int SalesJulyDec { get; set; }
        public int Change { get; set; }
    }


}