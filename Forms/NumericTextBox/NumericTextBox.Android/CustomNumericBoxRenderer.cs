#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.SfNumericTextBox;
using SampleBrowser.SfNumericTextBox.Droid;
using Syncfusion.SfNumericTextBox.XForms.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(NumericTextBoxRenderer), typeof(CustomNumericBoxRenderer))]
namespace SampleBrowser.SfNumericTextBox.Droid
{
    public class CustomNumericBoxRenderer : SfNumericTextBoxRenderer
    {
        public CustomNumericBoxRenderer()
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Control.SetBackgroundResource(0);
            }
        }
    }
}

