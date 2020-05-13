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
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class MultipleAxes : SampleView
	{
		public MultipleAxes ()
		{
			SFChart chart 				= new SFChart ();
			SFCategoryAxis primaryAxis 	= new SFCategoryAxis ();
			primaryAxis.LabelPlacement	= SFChartLabelPlacement.BetweenTicks;
			primaryAxis.Title.Text 		= new NSString("Years");
			chart.PrimaryAxis 			= primaryAxis;
			chart.SecondaryAxis 		= new SFNumericalAxis (){
				ShowMajorGridLines 		= false
			};
			chart.SecondaryAxis.Title.Text = new NSString ("Revenue (in millions)");
			NSNumberFormatter formatter	= new NSNumberFormatter ();
			formatter.PositiveFormat	= "$";
			chart.SecondaryAxis.LabelStyle.LabelFormatter = formatter;
			chart.Legend.Visible 			= true;
			chart.Legend.ToggleSeriesVisibility = true;
			chart.Legend.ItemMargin = new UIEdgeInsets (0, 0, 50, 20);
			MultipleAxisDataSource dataModel 	= new MultipleAxisDataSource ();
			chart.DataSource 					= dataModel as SFChartDataSource;
			this.AddSubview(chart);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}
	}
}

public class MultipleAxisDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;
	NSMutableArray DataPoints1;

	public MultipleAxisDataSource ()
	{
		DataPoints 	= new NSMutableArray ();
		DataPoints1 = new NSMutableArray ();
		AddDataPointsForChart("2010", 20,6);
		AddDataPointsForChart("2011", 21,15);
		AddDataPointsForChart("2012", 22.5,35);
		AddDataPointsForChart("2013", 26,65);
		AddDataPointsForChart("2014", 27,75);
	}

	void AddDataPointsForChart (String XValue, Double YValue, Double YValue1)
	{
		DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (XValue), NSObject.FromObject(YValue)));
		DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (XValue), NSObject.FromObject(YValue1)));
	}
		
	public override nint NumberOfSeriesInChart (SFChart chart)
	{
		return 2; 
	}

	public override SFSeries GetSeries (SFChart chart, nint index)
	{
		if (index == 0) 
		{
			SFColumnSeries series 	= new SFColumnSeries ();
			series.EnableTooltip 	= true;
			series.Label 			= new NSString("Revenue");
			series.EnableAnimation = true;
			return series;
		} 
		else 
		{
			SFLineSeries series = new SFLineSeries ();
			series.EnableTooltip = true;
			series.LineWidth	= 5;
			series.Label 		= new NSString("Customers");
			series.YAxis		= new SFNumericalAxis (){
				OpposedPosition = true,
				Minimum = NSObject.FromObject(0),
				Maximum = NSObject.FromObject(80),
				Interval = NSObject.FromObject(5),
				ShowMajorGridLines = false
			};
			series.DataMarker.ShowLabel = true;
			series.YAxis.Title.Text 	= new NSString ("Number of Customers");
			series.EnableAnimation      = true;
			return series;
		}
	}

	public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
	{
		if (seriesIndex == 0)
			return DataPoints.GetItem<SFChartDataPoint> ((nuint)index);
		else
			return DataPoints1.GetItem<SFChartDataPoint> ((nuint)index);
	}

	public override nint GetNumberOfDataPoints (SFChart chart, nint index)
	{
		if(index == 0)
			return (int)DataPoints.Count;
		else 
			return (int)DataPoints1.Count;
	}
}



