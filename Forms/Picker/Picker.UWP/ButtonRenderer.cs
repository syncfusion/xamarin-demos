#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(SampleBrowser.SfPicker.CustomButton), typeof(SampleBrowser.UWP.CustomButtonRenderer))]
namespace SampleBrowser.UWP
{

    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;
            Control.Padding = new Windows.UI.Xaml.Thickness(2, 2, 2, 2);
        }
    }
}
