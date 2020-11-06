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

[assembly: ExportRenderer(typeof(SfFontButton), typeof(SfFontButtonRenderer))]
namespace SampleBrowser.SfPdfViewer.iOS
{
	public class SfFontButtonRenderer : ButtonRenderer
	{


		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			double? fontSize = e.NewElement?.FontSize;
            if(fontSize==null || e.NewElement.FontFamily==null)
            {
                return;
            }
			UIFont font = UIFont.FromName(e.NewElement.FontFamily, (int)fontSize);
			Control.Font = font;
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName.Equals("Text"))
			{
				Label label = sender as Label;
				UIFont font = UIFont.FromName("Final_PDFViewer_IOS_FontUpdate", 50);
                if ((Element as SfFontButton).ButtonName == "viewModeButton")
                    Control.Font = UIFont.FromName(Element.FontFamily, Control.Font.PointSize);
                else
				    Control.Font = font;
				Control.Font.WithSize(35);

			}
		}
	}
}