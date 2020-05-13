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

[assembly: ExportRenderer(typeof(SampleBrowser.SfListView.OutgoingCustomContentView), typeof(OutgoingCustomContentViewRenderer))]
namespace SampleBrowser.SfListView.UWP
{
    #region OutgoingCustomContentViewRenderer 
    public class OutgoingCustomContentViewRenderer : VisualElementRenderer<OutgoingCustomContentView, Border>
    {
        Border border;
        protected override void OnElementChanged(ElementChangedEventArgs<OutgoingCustomContentView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                border = new Border();
                border.BorderThickness = new Windows.UI.Xaml.Thickness(2);
                border.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(255, 229, 245, 251));
                border.CornerRadius = new Windows.UI.Xaml.CornerRadius(8);
                border.Margin = new Windows.UI.Xaml.Thickness(-2);
                this.SetNativeControl(border);
                Canvas.SetZIndex(border, -1);
            }
        }
    }

    #endregion
}
