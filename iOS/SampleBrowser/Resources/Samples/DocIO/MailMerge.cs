#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using System.Collections.Generic;


#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
    public partial class MailMerge : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton button;

        public MailMerge()
        {
            label = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to create a letter format document by filling the data using Mail merge functionality of DocIO.";
            label.Lines = 0;
            label.Font = UIFont.SystemFontOfSize(15);
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 70);
            }
            else
            {
                label.Frame = new CGRect(frameRect.Location.X, 5, frameRect.Size.Width, 70);
            }
            this.AddSubview(label);

            button.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(5, 90, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 90, frameRect.Size.Width, 10);
            }
            button.TouchUpInside += OnButtonClicked;
            this.AddSubview(button);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Creating a new document.
            WordDocument document = new WordDocument();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Letter Formatting.docx");
            //Open Template document
            document.Open(inputStream, FormatType.Word2013);
            inputStream.Dispose();
            List<Customer> source = new List<Customer>();
            source.Add(new Customer("ALFKI", "Alfreds Futterkiste", "Maria Anders", "Sales Representative", "Obere Str. 57", "Berlin", "12209", "Germany", "030-0074321", "030-0076545"));
            //source.Add(new Customer("ANATR", "Ana Trujillo Emparedados y helados", "Ana Trujillo", "Owner", "Avda. de la Constitución 2222", "México D.F.", "05021", "Mexico", "(5) 555-4729", "(5) 555-3745"));
            document.MailMerge.Execute(source);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("MailMerge.docx", "application/msword", stream);
            }
        }
        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Frame;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));
            LoadAllowedTextsLabel();
            base.LayoutSubviews();
        }
    }

    public class Customer
    {
        #region fields
        string m_customerID;
        string m_companyName;
        string m_contactName;
        string m_contactTitle;
        string m_address;
        string m_city;
        string m_postalCode;
        string m_country;
        string m_phone;
        string m_fax;
        #endregion

        #region properties
        public string CustomerID
        {
            get
            {
                return m_customerID;
            }
            set
            {
                m_customerID = value;
            }
        }
        public string CompanyName
        {
            get
            {
                return m_companyName;
            }
            set
            {
                m_companyName = value;
            }
        }
        public string ContactName
        {
            get
            {
                return m_contactName;
            }
            set
            {
                m_contactName = value;
            }
        }
        public string ContactTitle
        {
            get
            {
                return m_contactTitle;
            }
            set
            {
                m_contactTitle = value;
            }
        }
        public string Address
        {
            get
            {
                return m_address;
            }
            set
            {
                m_address = value;
            }
        }
        public string City
        {
            get
            {
                return m_city;
            }
            set
            {
                m_city = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return m_postalCode;
            }
            set
            {
                m_postalCode = value;
            }
        }
        public string Country
        {
            get
            {
                return m_country;
            }
            set
            {
                m_country = value;
            }
        }
        public string Phone
        {
            get
            {
                return m_phone;
            }
            set
            {
                m_phone = value;
            }
        }
        public string Fax
        {
            get
            {
                return m_fax;
            }
            set
            {
                m_fax = value;
            }
        }
        #endregion

        #region constructor
        public Customer()
        { }

        public Customer(string customerID, string companyName, string contactName, string contactTitle, string address, string city, string postalCode, string country, string phone, string fax)
        {
            m_customerID = customerID;
            m_companyName = companyName;
            m_contactName = contactName;
            m_contactTitle = contactTitle;
            m_address = address;
            m_city = city;
            m_postalCode = postalCode;
            m_country = country;
            m_phone = phone;
            m_fax = fax;
        }
        #endregion
    }
}