#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.DocIORenderer;
using Syncfusion.OfficeChart;
using Syncfusion.Drawing;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using Syncfusion.iOS.Buttons;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
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
    public partial class TrackChanges : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton imageType;
        UIButton generateButton;
        UIButton viewButton;
        //RadioButton
        SfRadioGroup radioGroup = new SfRadioGroup();
        SfRadioButton acceptAll = new SfRadioButton();
        SfRadioButton rejectAll = new SfRadioButton();
        public TrackChanges()
        {
            label = new UILabel();
            imageType = new UIButton();
            viewButton = new UIButton(UIButtonType.System);
            viewButton.TouchUpInside += OnConvertClicked1;
            generateButton = new UIButton(UIButtonType.System);
            generateButton.TouchUpInside += OnConvertClicked2;
        }

        void LoadAllowedTextsLabel()
        {
            #region Description Label
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to accept or reject the tracked changes in the Word document using Essential DocIO.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 35);
            }
            else
            {
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 70);
            }
            this.AddSubview(label);
            #endregion
            #region ImageFormat Label
            imageType.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            #endregion
            #region Radio Buttons for track changes
            radioGroup.Axis = UILayoutConstraintAxis.Horizontal;
            acceptAll.SetTitle("Accepts all", UIControlState.Normal);
            radioGroup.AddArrangedSubview(acceptAll);
            rejectAll.SetTitle("Rejects all", UIControlState.Normal);            
            radioGroup.AddArrangedSubview(rejectAll);
            acceptAll.IsChecked = true;
            radioGroup.Distribution = UIStackViewDistribution.FillProportionally;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                radioGroup.Frame = new CGRect(5, 60, frameRect.Width, 40);
            }
            else
            {
                radioGroup.Frame = new CGRect(5, 80, frameRect.Width, 40);
            }
            this.AddSubview(radioGroup);
            #endregion

            #region Convert Button
            viewButton.SetTitle("View Template", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                viewButton.Frame = new CGRect(0, 115, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                viewButton.Frame = new CGRect(0, 135, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            this.AddSubview(viewButton);
            generateButton.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                generateButton.Frame = new CGRect(0, 145, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                generateButton.Frame = new CGRect(0, 165, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            this.AddSubview(generateButton);
            #endregion
        }
        void OnConvertClicked1(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.TrackChangesTemplate.docx");
            MemoryStream stream = new MemoryStream();
            inputStream.CopyTo(stream);
            inputStream.Dispose();
            string fileName = null;
            string ContentType = null;
            fileName = "TrackChangesTemplate.docx";
            ContentType = "application/msword";
            //Reset the stream position
            stream.Position = 0;
            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save(fileName, ContentType, stream as MemoryStream);
            }
        }
            void OnConvertClicked2(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            WordDocument document = new WordDocument();
            // Open an existing template document.
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.TrackChangesTemplate.docx");
            document.Open(inputStream, FormatType.Docx);
            inputStream.Dispose();
            if (rejectAll != null && (bool)rejectAll.IsChecked)
                document.Revisions.RejectAll();
            else
                document.Revisions.AcceptAll();
            string fileName = null;
            string ContentType = null;
            MemoryStream ms = new MemoryStream();
            fileName = "Track Changes.docx";
            ContentType = "application/msword";
            document.Save(ms, FormatType.Docx);
            //Reset the stream position
            ms.Position = 0;
            //Close the document instance.
            document.Close();
            if (ms != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save(fileName, ContentType, ms as MemoryStream);
            }
        }
        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Bounds;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));
            LoadAllowedTextsLabel();
            base.LayoutSubviews();
        }
    }
}