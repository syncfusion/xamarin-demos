#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfPdfViewer.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly:ResolutionGroupName("SampleBrowser.SfPdfViewer")]
[assembly:ExportEffect(typeof(CustomStampEffect), nameof(CustomStampEffect))]
namespace SampleBrowser.SfPdfViewer.UWP
{
    public class CustomStampEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.PointerEntered += Control_PointerEntered;
            Control.PointerExited += Control_PointerExited;
        }

        private void Control_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            (Control as Border).Background = new SolidColorBrush(Windows.UI.Color.FromArgb(0, 0, 0, 0));
        }

        private void Control_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            (Control as Border).Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 233, 233, 233));
        }

        protected override void OnDetached()
        {
            
        }
    }
}
