#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using SampleBrowser.SfPdfViewer;
using SampleBrowser.SfPdfViewer.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SampleBrowser.SfPdfViewer.iOS
{
    public class CustomEntryRenderer : EntryRenderer
    {
        Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewerControl;
        UIAlertView alertView;
        IUIAlertViewDelegate alertViewDelegate;
        UITextField textField;
        bool isInitialized = false;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ((sender as CustomEntry) != null)
            {
                if (e.PropertyName == "IsFocused")
                {
                    if ((sender as CustomEntry) != null && (sender as CustomEntry).IsFocused)
                        Control.PerformSelector(new ObjCRuntime.Selector("selectAll"), null, 0.0f);
                }

                if (!isInitialized && (sender as CustomEntry).IsPageNumberEntry)
                {
                    textField = new UITextField();
                    SetNativeControl(textField);
                    pdfViewerControl = (sender as CustomEntry).PdfViewer;
                    textField.TextAlignment = UITextAlignment.Center;
                    textField.TextColor = new UIColor(0f, 0.46f, 1f, 1f);
                    textField.Layer.BorderColor = new CoreGraphics.CGColor(0, 0, 0, 0.4f);
                    textField.Layer.BorderWidth = 1;
                    textField.Layer.CornerRadius = 2;
                    textField.TintColor = new UIColor(255f, 255f, 255f, 0);
                    textField.EditingDidBegin += TextField_EditingDidBegin;
                    isInitialized = true;
                }
            }

        }

        void TextField_EditingDidBegin(object sender, EventArgs e)
        {
            (sender as UITextField).ResignFirstResponder();
            alertViewDelegate = new AlertViewDelegate(pdfViewerControl);
            alertView = new UIAlertView("Go To Page", "Enter Page Number (1 - " + pdfViewerControl.PageCount.ToString() + ")", alertViewDelegate, "Cancel", "Okay");
            alertView.BackgroundColor = UIColor.White;
            alertView.Layer.BorderWidth = 1;
            alertView.Layer.BorderColor = new CoreGraphics.CGColor(0.2f, 0.2f);
            alertView.Layer.CornerRadius = 10;
            alertView.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
            (alertView.GetTextField(0) as UITextField).KeyboardType = UIKeyboardType.NumberPad;
            (alertView.GetTextField(0) as UITextField).BecomeFirstResponder();
            (alertView.GetTextField(0) as UITextField).ShouldReturn += (textField) => {
                int pageNum = 0;
                if (int.TryParse(alertView.GetTextField(0).Text, out pageNum) && pageNum > 0 && pageNum <= pdfViewerControl.PageCount)
                {
                    pdfViewerControl.PageNumber = pageNum;
                    return true;
                }
                else if (alertView.GetTextField(0).Text != "")
                    return true;
                else
                    return false;
            };
            alertView.Show();
        }
    }
}
