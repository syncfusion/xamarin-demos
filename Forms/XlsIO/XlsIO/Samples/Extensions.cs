#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using System.Xml.Linq;
using System.Linq;
using Syncfusion.XlsIO;

namespace SampleBrowser.XlsIO
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

        public static PropertyInfo GetProperty(this Type type, string name)
        {
            IEnumerator<PropertyInfo> propertyEnum = type.GetTypeInfo().DeclaredProperties.GetEnumerator();
            while (propertyEnum.MoveNext())
            {
                if (propertyEnum.Current.Name == name)
                {
                    return propertyEnum.Current;
                }
            }

            return null;
        }
    }

    public class XlsIOExtensions
    {       
        /// <summary>
        /// Import XML file into Excel file.
        /// </summary>
        /// <param name="fileStream">XML file stream</param>
        /// <param name="sheet">Worksheet to import</param>
        /// <param name="row">Row to which import begin</param>
        /// <param name="col">Column to which import begin</param>
        /// <param name="header">Imports header if true</param>
        public void ImportXML(Stream fileStream, IWorksheet sheet, int row, int col, bool header)
        {
            StreamReader reader = new StreamReader(fileStream);
            IEnumerable<Customers> customers = GetData<Customers>(reader.ReadToEnd());
            PropertyInfo[] propertyInfo = null;
            bool headerXML = true;
            int newCol = col;
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

        internal static IEnumerable<T> GetData<T>(string xml)
        where T : Customers, new()
        {
            return XElement.Parse(xml)
               .Elements("Customers")
               .Select(c => new T
               {
                   CustomerID = (string)c.Element("CustomerID"),
                   CompanyName = (string)c.Element("CompanyName"),
                   ContactName = (string)c.Element("ContactName"),
                   ContactTitle = (string)c.Element("ContactTitle"),
                   Address = (string)c.Element("Address"),
                   City = (string)c.Element("City"),
                   PostalCode = (string)c.Element("PostalCode"),
                   Country = (string)c.Element("Country"),
                   Phone = (string)c.Element("Phone"),
                   Fax = (string)c.Element("Fax")
               });
        }
    }

    public class Customers
    {
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

    public class BusinessObject
    {
        public string SalesPerson { get; set; }

        public int SalesJanJune { get; set; }

        public int SalesJulyDec { get; set; }

        public int Change { get; set; }
    }
}