#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class PyramidChart : SampleView
	{
		public PyramidChart()
		{
			InitializeComponent();

            overflowMode.SelectedIndex = 0;
            overflowMode.SelectedIndexChanged += OverflowMode_SelectedIndexChanged;

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                    chart.Margin = new Thickness(0, 0, 0, 10);
                else
                    chart.Margin = new Thickness(100, 0, 100, 0);
            }

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }
        }

        private void OverflowMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (overflowMode.SelectedIndex)
            {
                case 0:
                    chart.Legend.OverflowMode = Syncfusion.SfChart.XForms.ChartLegendOverflowMode.Wrap;
                    break;
                case 1:
                    chart.Legend.OverflowMode = Syncfusion.SfChart.XForms.ChartLegendOverflowMode.Scroll;
                    break;
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
                        chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
                        chart.Legend.DockPosition = LegendPlacement.Bottom;
                    }
                    else
                    {
                        chart.Legend.DockPosition = LegendPlacement.Right;
                        chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
                    }
                }
            }
        }
    }
}