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
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
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
    public partial class WordToHTML : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        bool isGenerateButtonClicked = false;
        UILabel label;
        UIButton button;

        public WordToHTML()
        {
            label = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to convert a Word document into HTML file.";
            label.Font = UIFont.SystemFontOfSize(15);
            label.Lines = 0;
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 40);
            }
            else
            {
                label.Frame = new CGRect(frameRect.Location.X, 5, frameRect.Size.Width, 40);
            }
            this.AddSubview(label);

            button.SetTitle("Generate", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(5, 60, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 60, frameRect.Size.Width, 10);
            }
            this.AddSubview(button);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Creating a new document.
            WordDocument document = new WordDocument();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.WordtoHTML.doc");
            //Open the Word document to convert
            document.Open(inputStream, FormatType.Doc);
            //Export the Word document to HTML file
            MemoryStream stream = new MemoryStream();
            HTMLExport htmlExport = new HTMLExport();
            htmlExport.SaveAsXhtml(document, stream);
            document.Close();
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string htmlString = reader.ReadToEnd();
            isGenerateButtonClicked = true;
            UIWebView webView = new UIWebView(this.Bounds);
            webView.Frame = new CGRect(0, 0, this.Bounds.Width, this.Bounds.Height);
            this.AddSubview(webView);
            webView.LoadHtmlString(htmlString, NSBundle.MainBundle.BundleUrl);
            webView.ScalesPageToFit = false;
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
            if (!isGenerateButtonClicked)
                LoadAllowedTextsLabel();
            base.LayoutSubviews();
        }
    }
    class WebViewController : UIViewController
    {
        UIWebView webView;
        private string m_htmlString = string.Empty;
        public WebViewController(string htmlString)
        {
            m_htmlString = htmlString;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.View.BackgroundColor = UIColor.White;
            webView = new UIWebView(this.View.Bounds);
            webView.Frame = new CGRect(0, 0, this.View.Bounds.Width, this.View.Bounds.Height);
            this.View.AddSubview(webView);
            webView.LoadHtmlString(m_htmlString, NSBundle.MainBundle.BundleUrl);
            webView.ScalesPageToFit = false;
        }
        public override void ViewDidDisappear(bool animated)
        {
            if (webView != null)
            {
                webView.RemoveFromSuperview();
                webView.Dispose();
                webView = null;
            }
            base.ViewWillDisappear(animated);
        }
    }
}