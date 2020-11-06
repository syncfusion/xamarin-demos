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
	public partial class CategoryAxis : SampleView
	{
		public CategoryAxis()
		{
            InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                axisLabelStyle.FontSize = 14;
            }
		}

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                primary.ArrangeByIndex = true;
                Chart.SideBySideSeriesPlacement = true;
                axisLabelStyle.MaxWidth = double.NaN;
            }
            else
            {
                primary.ArrangeByIndex = false;
                Chart.SideBySideSeriesPlacement = false;
                axisLabelStyle.WrappedLabelAlignment = ChartAxisLabelAlignment.Center;

                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    axisLabelStyle.MaxWidth = 40;
                }
                else if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
                {
                    axisLabelStyle.MaxWidth = 80;
                }
            }
        }
    }
}
