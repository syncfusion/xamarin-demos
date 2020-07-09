#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfListView.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using SampleBrowser.Core;

[assembly: ExportRenderer(typeof(SampleBrowser.SfListView.IncomingCustomContentView), typeof(IncomingCustomContentViewRenderer))]
namespace SampleBrowser.SfListView.UWP
{
    #region IncomingCustomContentViewRenderer 

    public class IncomingCustomContentViewRenderer : VisualElementRenderer<IncomingCustomContentView, Border>
    {
        Border border;
        protected override void OnElementChanged(ElementChangedEventArgs<IncomingCustomContentView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                border = new Border();
                border.BorderThickness = new Windows.UI.Xaml.Thickness(2);
                border.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(255, 192, 238, 252));
                border.CornerRadius = new Windows.UI.Xaml.CornerRadius(8);
                border.Margin = new Windows.UI.Xaml.Thickness(-2);
                this.SetNativeControl(border);
                Canvas.SetZIndex(border, -1);
            }
        }
    }
    #endregion
}
