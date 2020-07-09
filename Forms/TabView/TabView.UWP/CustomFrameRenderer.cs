#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfTabView;
using SampleBrowser.SfTabView.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace SampleBrowser.SfTabView.UWP
{

    public class CustomFrameRenderer : FrameRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                (this.Control as Border).Background = FormColorToNativeColor((e.NewElement as CustomFrame).BackgroundColor);

                if ((e.NewElement as CustomFrame).CornerRadius != -1)
                    (this.Control as Border).CornerRadius = new Windows.UI.Xaml.CornerRadius((e.NewElement as CustomFrame).CornerRadius);
            }
        }

        internal SolidColorBrush FormColorToNativeColor(Color color)
        {
            return new SolidColorBrush(Windows.UI.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255)));
        }
    }

}
