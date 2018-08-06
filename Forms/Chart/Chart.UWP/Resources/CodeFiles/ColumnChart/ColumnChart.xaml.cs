#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
	public partial class ColumnChart : SampleView
	{
		public ColumnChart()
		{
			InitializeComponent();
			Spacing.ValueChanged += Spacing_ValueChanged;
			ColumnWidth.ValueChanged += ColumnWidth_ValueChanged;

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }
        }

        private void ColumnWidth_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			columnSeries1.Width = e.NewValue;
			columnSeries2.Width = e.NewValue;
			columnSeries3.Width = e.NewValue;
			ColumnWidthValue.Text = "Width : " + e.NewValue.ToString();
		}

		private void Spacing_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			columnSeries1.Spacing = e.NewValue;
			columnSeries2.Spacing = e.NewValue;
			columnSeries3.Spacing = e.NewValue;
			SpacingValue.Text = "Spacing : " + e.NewValue.ToString();
		}

        private void cornerRadius_ValueChanged(object sender, ValueChangedEventArgs e)
        {
           
            columnSeries1.CornerRadius = new ChartCornerRadius(e.NewValue, e.NewValue, 0, 0);
            columnSeries2.CornerRadius = new ChartCornerRadius(e.NewValue, e.NewValue, 0, 0);
            columnSeries3.CornerRadius = new ChartCornerRadius(e.NewValue, e.NewValue, 0, 0);

            cornerRadiusValue.Text = "CornerRadius : " + e.NewValue.ToString();
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
                        Chart.Legend.DockPosition = LegendPlacement.Bottom;
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