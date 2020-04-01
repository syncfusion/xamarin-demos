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
	public partial class VerticalChart : SampleView
	{
		public VerticalChart()
		{
			InitializeComponent();
			VerticalChartViewModel viewModel = chart.BindingContext as VerticalChartViewModel;
			viewModel.LoadVerticalData();
            viewModel.StartTimer();
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
                        fastlineseries.StrokeWidth = 2;
                        chart.Legend.DockPosition = LegendPlacement.Bottom;
                    }
                    else
                    {
                        fastlineseries.StrokeWidth = 1;
                        chart.Legend.DockPosition = LegendPlacement.Right;
                    }
                }
            }
        }
    }
}