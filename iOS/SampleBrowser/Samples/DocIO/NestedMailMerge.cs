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
using System.Data;
using System.Collections;
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
    public partial class NestedMailMerge : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton button;

        public NestedMailMerge()
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
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Template_Letter.doc");
            //Open Template document
            document.Open(inputStream, FormatType.Word2013);
            inputStream.Dispose();
            inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Employees.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(inputStream);
            ArrayList commands = new ArrayList();

            //DictionaryEntry contain "Source table" (KEY) and "Command" (VALUE)
            DictionaryEntry entry = new DictionaryEntry("Employees", string.Empty);
            commands.Add(entry);

            // To retrive customer details
            System.Data.DataTable table = ds.Tables["Customers"];
            string relation = table.ParentRelations[0].ChildColumns[0].ColumnName + " = %Employees." + table.ParentRelations[0].ParentColumns[0].ColumnName + "%";
            entry = new DictionaryEntry("Customers", relation);
            commands.Add(entry);

            // To retrieve order details
            table = ds.Tables["Orders"];
            relation = table.ParentRelations[0].ChildColumns[0].ColumnName + " = %Customers." + table.ParentRelations[0].ParentColumns[0].ColumnName + "%";
            entry = new DictionaryEntry("Orders", relation);
            commands.Add(entry);

            //Executes nested Mail merge using explicit relational data.
            document.MailMerge.ExecuteNestedGroup(ds, commands);

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
}