#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
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


        //void TransparentView_Focused(object sender, FocusEventArgs e)
        //{
        //    transparentView.IsEnabled = false;
        //    transparentView.IsVisible = false;
        //    grid.Children.Remove(transparentView);
        //    transparentView.Opacity = 0;
        //}
    }
}