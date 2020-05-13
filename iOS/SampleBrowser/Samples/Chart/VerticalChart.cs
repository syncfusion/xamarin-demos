#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 


#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Threading.Tasks;

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
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class VerticalChart : SampleView
	{
		SFChart chart ;
		ChartVerticalDataModel dataModel;

		public VerticalChart ()
		{
			chart = new SFChart ();

			SFDateTimeAxis xAxis 			= new SFDateTimeAxis ();
			NSDateFormatter formatter 		= new NSDateFormatter ();
			formatter.DateFormat 			= new NSString ("mm:ss");
			xAxis.LabelStyle.LabelFormatter = formatter;
			xAxis.Title.Text 				= new NSString ("Time(sec)");
			xAxis.ShowMajorGridLines		= false;
			chart.PrimaryAxis 				= xAxis;

			SFNumericalAxis yAxis 			= new SFNumericalAxis ();
			yAxis.Minimum 					= new NSNumber(-10);
			yAxis.Maximum 					= new NSNumber (10);
			yAxis.Interval 					= new NSNumber (10);
			yAxis.Title.Text 				= new NSString ("Velocity(m/s)");
			yAxis.ShowMajorGridLines 		= false;
			chart.SecondaryAxis				= yAxis;

			chart.Title.Text       = new NSString ("Seismograph of Japan Earthquake 2011");
			chart.Title.Font       = UIFont.FromName ("Helvetica neue",15);

			dataModel = new ChartVerticalDataModel();
			chart.DataSource = dataModel as ChartVerticalDataModel;

			this.AddSubview(chart);
			UpdateData ();
		}

		async void UpdateData()
		{
			await Task.Delay(50);
			var datapoint = dataModel.dataPointWithTimeInterval (0.13);
			dataModel.DataPoints.Add (datapoint);
			chart.InsertDataPointAtIndex ((int)dataModel.DataPoints.Count - 1, 0);

			if(dataModel.DataPoints.Count < 340)
				UpdateData ();
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}
	}

	public class ChartVerticalDataModel : SFChartDataSource
	{
		public NSMutableArray DataPoints;
		public NSDate date;
		Random random;

		public ChartVerticalDataModel ()
		{
			DataPoints 					= new NSMutableArray ();
			random 				        = new Random ();
			NSCalendar calendar 		= new NSCalendar (NSCalendarType.Gregorian);
			NSDateComponents components = new NSDateComponents ();
			date 						= new NSDate ();

			components.Year 	= 2011;
			components.Month	= 3;
			components.Day 		= 11;
			components.Hour 	= 14;
			components.Minute 	= 46;
			components.Second 	= 0;

			date = calendar.DateFromComponents(components);

			for (int i = 0; i <30; i++) 
			{
				DataPoints.Add (dataPointWithTimeInterval(0.15));
			}
		}

		public SFChartDataPoint dataPointWithTimeInterval(double time)
		{
			int count = (int)DataPoints.Count;
			NSNumber value;

			if(count>320)
			{
				value = random.Next (0, 0);
			}
			else if(count>280)
			{
				value = random.Next (-2, 2);
			}
			else if(count>240)
			{
				value = random.Next (-3, 3);
			}
			else if(count>200)
			{
				value = random.Next (-5, 5);
			}
			else if(count>180)
			{
				value = random.Next (-6, 6);
			}
			else if(count>120)
			{
				value = random.Next (-7, 7);
			}
			else if (count > 30)
			{
				value = random.Next (-9, 9);
			}
			else
			{
				value = random.Next (-3, 3);
			}

			date = date.AddSeconds (time);

			SFChartDataPoint datapoint = new SFChartDataPoint();
			datapoint.XValue = NSObject.FromObject (date);
			datapoint.YValue = value;
			return datapoint;
		}

		public override nint NumberOfSeriesInChart (SFChart chart)
		{
			return 1; 
		}

		public override SFSeries GetSeries (SFChart chart, nint index)
		{
			SFFastLineSeries series = new SFFastLineSeries ();
			series.IsTransposed 	= true;
			series.EnableAnimation  = true;
			return series;
		}

		public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
		{
			return DataPoints.GetItem<SFChartDataPoint> ((nuint)index);
		}

		public override nint GetNumberOfDataPoints (SFChart chart, nint index)
		{
			return (int)DataPoints.Count;
		}
	}
}

