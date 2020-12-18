#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using Syncfusion.SfChart.XForms;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class ScatterChart : SampleView
	{
		public ScatterChart()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS))
            {
                if (height > 0 && width > 0)
                {
                    if (height > width)
                    {
                        if (Device.RuntimePlatform == Device.Android)
                        {
                            Chart.PrimaryAxis.Title.Margin = new Thickness(0,10,0,0);
                        }
                    }
                    else
                    {
                        if (Device.RuntimePlatform == Device.Android)
                        {
                            Chart.PrimaryAxis.Title.Margin = new Thickness(0);
                        }
                    }
                }
            }
        }
    }
}
