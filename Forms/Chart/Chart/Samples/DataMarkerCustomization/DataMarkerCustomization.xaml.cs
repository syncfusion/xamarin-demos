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
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class DataMarkerCustomization : SampleView
	{
		public DataMarkerCustomization()
		{
			InitializeComponent();

            if(Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                secondaryAxisLabelStyle.LabelFormat = "0'M'";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "#'M'";
            }

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
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
                        chart.Legend.DockPosition = LegendPlacement.Bottom;
                    }
                    else
                    {
                        chart.Legend.DockPosition = LegendPlacement.Right;
                    }
                }
            }
        }
    }
}