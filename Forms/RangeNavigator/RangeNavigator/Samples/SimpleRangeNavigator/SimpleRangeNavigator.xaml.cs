#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Syncfusion.RangeNavigator.XForms;
using SampleBrowser.Core;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfRangeNavigator
{
   [Preserve(AllMembers = true)]
	public partial class SimpleRangeNavigator : SampleView
	{
		public SimpleRangeNavigator()
		{
			InitializeComponent();

			((Syncfusion.SfChart.XForms.SfChart)RangeNavigator.Content).Series.Clear();
			((Syncfusion.SfChart.XForms.SfChart)RangeNavigator.Content).Series.Add(new SplineAreaSeries() { ItemsSource = series.ItemsSource, XBindingPath = "XValue", YBindingPath = "YValue" });

			if (Device.RuntimePlatform == Device.Android)
            {
                RangeNavigator.HeightRequest = 150;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                RangeNavigator.HeightRequest = 100;
            }
            else if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                chart.Margin = new Thickness(5);
                RangeNavigator.Margin = new Thickness(5);
                RangeNavigator.Intervals = Syncfusion.RangeNavigator.XForms.DateTimeIntervalType.Quarter |
                                           Syncfusion.RangeNavigator.XForms.DateTimeIntervalType.Month;
                RangeNavigator.TooltipFormat = "dd/MM/yy";
                RangeNavigator.LeftTooltipStyle = new TooltipStyle()
                {
                    FontSize = 10
                };
                RangeNavigator.RightTooltipStyle = new TooltipStyle()
                {
                    FontSize = 10
                };
            }
        }

		void nac_RangeChanged(object sender, Syncfusion.RangeNavigator.XForms.RangeChangedEventArgs e)
		{
            dateTimeAxis.Minimum = e.ViewRangeStartDate;
            dateTimeAxis.Maximum = e.ViewRangeEndDate;
        }
	}
}