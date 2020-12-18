#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.SfChart.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class GettingStartedRangeNavigator : SampleView
	{
		SFChart chart;
		SFDateTimeRangeNavigator rangeNavigator;
		SFDateTimeAxis primaryAxis;
		SFNumericalAxis secondaryAxis;
        ChartViewModel dataModel = new ChartViewModel();

		public GettingStartedRangeNavigator ()
		{
			chart 							= new SFChart ();
			primaryAxis 					= new SFDateTimeAxis ();
			primaryAxis.Minimum				= DateTimeToNSDate( new DateTime (2015, 5, 15, 0, 0, 0));
			primaryAxis.Maximum				= DateTimeToNSDate( new DateTime (2015, 8, 15, 0, 0, 0));
			chart.PrimaryAxis 				= primaryAxis;
			secondaryAxis 					= new SFNumericalAxis ();
			chart.SecondaryAxis 			= secondaryAxis;

			SFSplineAreaSeries series = new SFSplineAreaSeries();
			series.Alpha = 0.6f;
			series.BorderColor = UIColor.FromRGBA(255.0f / 255.0f, 191.0f / 255.0f, 0.0f / 255.0f, 1.0f);
            series.ItemsSource = dataModel.DateTimeRangeData;
            series.XBindingPath = "XValue";
            series.YBindingPath = "YValue";
            chart.Series.Add(series);
			this.AddSubview (chart);

			rangeNavigator					= new SFDateTimeRangeNavigator ();
			rangeNavigator.Delegate			= new RangeNavigatorDelegate(primaryAxis);

			SFSplineAreaSeries series1 = new SFSplineAreaSeries();
			series1.Alpha = 0.6f;
			series1.BorderColor = UIColor.FromRGBA(255.0f / 255.0f, 191.0f / 255.0f, 0.0f / 255.0f, 1.0f);
			series1.ItemsSource = dataModel.DateTimeRangeData;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			chart.Series.Add(series1);
            ((SFChart)rangeNavigator.Content).Series.Add(series1);

			DateTime minDate			    = new DateTime (2015, 1, 1, 0, 0, 0);
			DateTime maxDate 				= new DateTime (2015, 12, 1, 0, 0, 0);
			DateTime startDate			    = new DateTime (2015, 5, 15, 0, 0, 0);
			DateTime endDate 				= new DateTime (2015, 8, 15, 0, 0, 0);
			rangeNavigator.Minimum 			= DateTimeToNSDate (minDate);
			rangeNavigator.Maximum		    = DateTimeToNSDate (maxDate);
			rangeNavigator.ViewRangeStart	= DateTimeToNSDate (startDate);
			rangeNavigator.ViewRangeEnd		= DateTimeToNSDate (endDate);

			this.AddSubview (rangeNavigator);

			//this.control				    = this;
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view == rangeNavigator)
					view.Frame = new CGRect (0, Frame.Size.Height - 100, Frame.Width, 100);
				else if (view == chart)
					view.Frame = new CGRect (0, 0, Frame.Size.Width, Frame.Size.Height - 100);
				else
					view.Frame = Frame;
			}
			base.LayoutSubviews ();
		}

		public void UpdateChart(NSDate startDate, NSDate endDate)
		{
			primaryAxis.Minimum	= startDate;
			primaryAxis.Maximum = endDate;
		}

		public NSDate DateTimeToNSDate(DateTime date)
		{
			DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
				new DateTime(2001, 1, 1, 0, 0, 0) );
			return NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
		}

	}
}

public class RangeNavigatorDelegate: SFRangeNavigatorDelegate
{
	SFDateTimeAxis primaryAxis;

	public RangeNavigatorDelegate(SFDateTimeAxis _primaryAxis)
	{
		primaryAxis 	= _primaryAxis;
	}

	public override void RangeChanged (SFDateTimeRangeNavigator rangeNavigator, NSDate startDate, NSDate endDate)
	{
		primaryAxis.Minimum		= startDate;
		primaryAxis.Maximum		= endDate;
	}
}