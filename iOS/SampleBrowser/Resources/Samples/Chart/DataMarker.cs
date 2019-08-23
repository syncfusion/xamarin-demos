#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace SampleBrowser
{
	public class DataMarker : SampleView
	{
		SFChart chart;
		public DataMarker()
		{
			chart 									= new SFChart();
            chart.Title.Text = new NSString("Unemployment Rate");
			SFCategoryAxis primary 					= new SFCategoryAxis();
			primary.ShowMajorGridLines 				= false;
			chart.PrimaryAxis 						= primary;
			chart.SecondaryAxis 				 	= new SFNumericalAxis();
			chart.SecondaryAxis.ShowMajorGridLines 	= false;
			chart.SecondaryAxis.Maximum 			= new NSNumber(100);
			ChartViewModel dataModel 				= new ChartViewModel();

			SFBarSeries series = new SFBarSeries();
			series.ItemsSource = dataModel.DataMarkerData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Outer;
			//series.Color = UIColor.FromRGB(233.0f / 255.0f, 88.0f / 255.0f, 83.0f / 255.0f);
			series.DataMarker.ShowLabel = true;
			chart.Series.Add(series);
			chart.Delegate 							= new ChartDataMarkerDelegate();
            chart.ColorModel.Palette = SFChartColorPalette.Natural;
			this.AddSubview(chart);

		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = Bounds;
			}
			base.LayoutSubviews();
		}

	}

	public class ChartDataMarkerDelegate : SFChartDelegate
	{
		public override UIView ViewForDataMarkerLabel(SFChart chart, NSString label, nint index, SFSeries series)
		{
			var dataPoint = (series.ItemsSource as IList<ChartDataModel>);

			UIView customView = new UIView();
			customView.Frame = new CGRect(0, 0, 60, 20);

			UIImageView imageView = new UIImageView();
			imageView.Frame = new CGRect(35, 0, 20, 20);

			UILabel average = new UILabel();
			average.Frame = new CGRect(3, 0, 40, 20);
			average.Font = UIFont.FromName("Helvetica", 15f);
			average.Text = label.ToString()+"%";

			if ((dataPoint[(int)index].YValue) > 50) 
			{
				imageView.Image = UIImage.FromBundle("Images/Up.png");
				average.TextColor = UIColor.Green;
			}
			else
			{
				imageView.Image = UIImage.FromBundle("Images/Down.png");
				average.TextColor = UIColor.Red;
			}

			customView.AddSubview(imageView);
			customView.AddSubview(average);
			return customView;
		}
	}
}

