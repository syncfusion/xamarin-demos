#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.SfNumericTextBox;
using SampleBrowser.SfNumericTextBox.iOS;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(NumericTextBoxRenderer2), typeof(CustomNumericTextBoxRenderer2))]
namespace SampleBrowser.SfNumericTextBox.iOS
{
	public class CustomNumericTextBoxRenderer2 : SfNumericTextBoxRenderer
	{
		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.Layer.CornerRadius = 5;
				Control.Layer.BorderWidth = 1;
				Control.ClipsToBounds = true;
			}
		}
	}
}
