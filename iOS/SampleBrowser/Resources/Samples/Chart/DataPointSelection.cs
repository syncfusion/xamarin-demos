#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
	public class DataPointSelection : SampleView
	{
		SFChart chart;
		UILabel label;
		ChartViewModel dataModel;
		public DataPointSelection()
		{
			chart = new SFChart();
            chart.Title.Text = new NSString("Product Sale 2016");
			SFCategoryAxis primary = new SFCategoryAxis();
			primary.LabelPlacement = SFChartLabelPlacement.BetweenTicks;
			primary.Title.Text = new NSString("Month");
			chart.PrimaryAxis = primary;
			chart.SecondaryAxis = new SFNumericalAxis() { ShowMajorGridLines = false };
			chart.SecondaryAxis.Title.Text = new NSString("Sales");

			dataModel = new ChartViewModel();

			SFColumnSeries series = new SFColumnSeries();
			series.ItemsSource = dataModel.SelectionData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableDataPointSelection = true;
			series.EnableAnimation = true;
			series.Color = UIColor.FromRGBA(0, 189f / 255f, 174f / 255f, 0.5f);
            series.SelectedDataPointColor = UIColor.FromRGBA(0, 189f / 255f, 174f / 255f, 1f);
			chart.Series.Add(series);

			chart.Delegate = new ChartSelectionDelegate();
			chart.AddChartBehavior(new SFChartSelectionBehavior());
			label = new UILabel();
			label.Text = "Month :  Mar, Sales : $ 53";
			label.Font = UIFont.FromName("Helvetica", 13f);
			label.TextAlignment = UITextAlignment.Center;
			this.AddSubview(chart);
			this.AddSubview(label);
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				if (view == chart)
					chart.Frame = new CGRect(0, 0, Frame.Width, Frame.Height - 28);
				else if (view == label)
					label.Frame = new CGRect(0, Frame.Height - 20, Frame.Width, 20);
				else
					view.Frame = Frame;

			}
			base.LayoutSubviews();
		}

		public void SetLabelContent(string xValue, string yValue)
		{
			if (xValue != null && yValue != null)
			{
				label.Text = "Month : " + xValue + ", Sales : $" + yValue;
			}
			else {
				label.Text = "Tap a bar segment to select a data point";
			}

		}

	}

	public class ChartSelectionDelegate : SFChartDelegate
	{
		public override void DidDataPointSelect(SFChart chart, SFChartSelectionInfo info)
		{
			int selectedindex = info.SelectedDataPointIndex;
			if (selectedindex >= 0)
			{
				SFSeries series = info.SelectedSeries;
				if (series != null)
				{
					var dataPoint = (series.ItemsSource as IList<ChartDataModel>);

					if (dataPoint == null)
						(chart.Superview as DataPointSelection).SetLabelContent(null, null);
					else {
						String x = dataPoint[selectedindex].XValue.ToString();
						String y = dataPoint[selectedindex].YValue.ToString();
						(chart.Superview as DataPointSelection).SetLabelContent(x, y);
					}
				}
			}
			else
			{
				(chart.Superview as DataPointSelection).SetLabelContent(null, null);
			}
		}
	}
}