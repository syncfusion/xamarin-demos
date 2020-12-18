#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using SampleBrowser.SfTabView;
using SampleBrowser.SfTabView.iOS;

[assembly: ExportRenderer(typeof(CustomizedEntry), typeof(CustomEntryRenderer))]
namespace SampleBrowser.SfTabView.iOS
{
	public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
            }
        }
    }
}
