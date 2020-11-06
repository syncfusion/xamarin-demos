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
	public partial class RadarChart : SampleView
	{
		public RadarChart()
		{
			InitializeComponent();

            angle.SelectedIndex = 3;
            angle.SelectedIndexChanged += polarStartAngle_Changed;

            radarDrawType.SelectedIndex = 1;
            radarDrawType.SelectedIndexChanged += radarDrawType_Changed;

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                secondaryAxisLabelSyle.LabelFormat = "0'M'";
            }
            else
            {
                secondaryAxisLabelSyle.LabelFormat = "#'M'";
            }

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }
        }

        void polarStartAngle_Changed(object sender, EventArgs e)
        {
            switch (angle.SelectedIndex)
            {
                case 0:
                    secondary.PolarAngle = ChartPolarAngle.Rotate0;
                    break;
                case 1:
                    secondary.PolarAngle = ChartPolarAngle.Rotate90;
                    break;
                case 2:
                    secondary.PolarAngle = ChartPolarAngle.Rotate180;
                    break;
                case 3:
                    secondary.PolarAngle = ChartPolarAngle.Rotate270;
                    break;
            }
        }

        void radarDrawType_Changed(object sender, EventArgs e)
        {
            switch (radarDrawType.SelectedIndex)
            {
                case 0:
                    series1.DrawType = PolarRadarSeriesDrawType.Line;
                    series2.DrawType = PolarRadarSeriesDrawType.Line;
                    series3.DrawType = PolarRadarSeriesDrawType.Line;
                    break;
                case 1:
                    series1.DrawType = PolarRadarSeriesDrawType.Area;
                    series2.DrawType = PolarRadarSeriesDrawType.Area;
                    series3.DrawType = PolarRadarSeriesDrawType.Area;
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
                        Chart.Legend.DockPosition = LegendPlacement.Top;
                    }
                    else
                    {
                        Chart.Legend.DockPosition = LegendPlacement.Right;
                    }
                }
            }
        }
    }
}
