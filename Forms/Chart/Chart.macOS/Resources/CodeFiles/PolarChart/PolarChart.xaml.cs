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
	public partial class PolarChart : SampleView
	{
		public PolarChart()
		{
			InitializeComponent();
            polarStartAngle.SelectedIndex = 3;
            polarStartAngle.SelectedIndexChanged += polarStartAngle_Changed;

            if (Device.RuntimePlatform == Device.UWP)
            {
                secondaryAxisLabelSyle.LabelFormat = "0'M'";
            }
            else
            {
                secondaryAxisLabelSyle.LabelFormat = "#'M'";
            }

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }
        }

        void polarStartAngle_Changed(object sender ,EventArgs e)
        {
            switch (polarStartAngle.SelectedIndex)
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

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS))
            {
                if (height > 0 && width > 0)
                {
                    if (height > width)
                    {
                        layout.Padding = new Thickness(0);
                        Chart.Legend.DockPosition = LegendPlacement.Top;
                    }
                    else
                    {
                        double padding = (layout.Width - layout.Height) / 2;
                        layout.Padding = new Thickness(padding / 2, 0, padding / 2, 0);
                        Chart.Legend.DockPosition = LegendPlacement.Right;
                    }
                }
            }
        }
    }
}
