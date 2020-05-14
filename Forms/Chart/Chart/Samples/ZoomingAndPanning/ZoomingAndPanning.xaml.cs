#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace SampleBrowser.SfChart
{
    public partial class ZoomingAndPanning : SampleView
    {
        public ZoomingAndPanning()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }

            if (Device.RuntimePlatform != Device.macOS)
            {
                zoomPan.EnableDirectionalZooming = true;
                PropertyView = Resources["stackLayout"] as View;
            }

            ////transparentView.Focused += TransparentView_Focused;
            //var touchGesture = new TapGestureRecognizer();
            //touchGesture.Tapped += (sender, e) =>
            // {
            //     transparentView.IsEnabled = false;
            //     transparentView.IsVisible = false;
            //     grid.Children.Remove(transparentView);
            //     transparentView.Opacity = 0;
            // };
            //transparentView.GestureRecognizers.Add(touchGesture);
        }

        private void EnableDirectionalZooming_Toggled(object sender, ToggledEventArgs e)
        {
            zoomPan.EnableDirectionalZooming = enableDirectionalZooming.IsToggled;
        }

        private void EnableSelectionZooming_Toggled(object sender, ToggledEventArgs e)
        {
            zoomPan.EnableSelectionZooming = enableSelectionZooming.IsToggled;
        }

        //void TransparentView_Focused(object sender, FocusEventArgs e)
        //{
        //    transparentView.IsEnabled = false;
        //    transparentView.IsVisible = false;
        //    grid.Children.Remove(transparentView);
        //    transparentView.Opacity = 0;
        //}
    }
}