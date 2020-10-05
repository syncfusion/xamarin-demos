#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Drawing;

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
	public class Column : SampleView
	{
		SFChart chart;
		public Column()
		{
			chart = new SFChart();
			chart.Title.Text = new NSString("Olympic Medal Counts - RIO");
			chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFCategoryAxis primary = new SFCategoryAxis();
			primary.LabelPlacement = SFChartLabelPlacement.BetweenTicks;
			primary.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			primary.ShowMajorGridLines = false;
			chart.PrimaryAxis = primary;
			chart.SecondaryAxis = new SFNumericalAxis();
			chart.SecondaryAxis.ShowMajorGridLines = false;
			chart.SecondaryAxis.Visible = false;
			ChartViewModel dataModel = new ChartViewModel();

			SFColumnSeries series1 = new SFColumnSeries();
			series1.ItemsSource = dataModel.ColumnData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "Gold";
			series1.EnableAnimation = true;
			series1.LegendIcon = SFChartLegendIcon.SeriesType;
			series1.DataMarker.ShowLabel = true;
			series1.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
			chart.Series.Add(series1);

			SFColumnSeries series2 = new SFColumnSeries();
			series2.ItemsSource = dataModel.ColumnData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "Silver";
			series2.EnableAnimation = true;
			series2.LegendIcon = SFChartLegendIcon.SeriesType;
			series2.DataMarker.ShowLabel = true;
            series2.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
			chart.Series.Add(series2);

			SFColumnSeries series3 = new SFColumnSeries();
            series3.ItemsSource = dataModel.ColumnData3;
            series3.XBindingPath = "XValue";
            series3.YBindingPath = "YValue";
            series3.EnableTooltip = true;
            series3.Label = "Silver";
            series3.EnableAnimation = true;
            series3.LegendIcon = SFChartLegendIcon.SeriesType;
            series3.DataMarker.ShowLabel = true;
            series3.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
			chart.Series.Add(series3);

			chart.Legend.Visible = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			chart.Legend.ToggleSeriesVisibility = true;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;

			this.AddSubview(chart);
           
			this.OptionView = new UIView();

		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = Bounds;
			}
			this.CreateOptionView();
			base.LayoutSubviews();
		}

		private void CreateOptionView()
		{
			UILabel spacingLbl = new UILabel();
			spacingLbl.Text = "Spacing:";
			spacingLbl.TextAlignment = UITextAlignment.Left;
			spacingLbl.Font = UIFont.FromName("Helvetica", 14f);

			UILabel widthLbl = new UILabel();
			widthLbl.Text = "SegmentWidth:";
			widthLbl.TextAlignment = UITextAlignment.Left;
			widthLbl.Font = UIFont.FromName("Helvetica", 14f);

			UILabel spacing = new UILabel();
			spacing.Text = "0.0";
			spacing.Font = UIFont.FromName("Helvetica", 14f);

			UILabel width = new UILabel();
			width.Text = "0.8";
			width.Font = UIFont.FromName("Helvetica", 14f);

			UISlider spacingSlider = new UISlider();
			spacingSlider.MinValue = 0.0f;
			spacingSlider.MaxValue = 1.0f;
			spacingSlider.Value = 0.0f;
			spacingSlider.ValueChanged += (object sender, EventArgs e) =>
			{

				(chart.SeriesAtIndex(0) as SFColumnSeries).Spacing = (float)spacingSlider.Value;
				(chart.SeriesAtIndex(1) as SFColumnSeries).Spacing = (float)spacingSlider.Value;
				decimal value = decimal.Parse(spacingSlider.Value.ToString());
				spacing.Text = value.ToString("0.00");
			};

			UISlider widthSlider = new UISlider();
			widthSlider.MinValue = 0.0f;
			widthSlider.MaxValue = 1.0f;
			widthSlider.Value = 0.8f;
			widthSlider.ValueChanged += (object sender, EventArgs e) =>
			 {
				 (chart.SeriesAtIndex(0) as SFColumnSeries).Width = (float)widthSlider.Value;
				 (chart.SeriesAtIndex(1) as SFColumnSeries).Width = (float)widthSlider.Value;
				 decimal value = decimal.Parse(widthSlider.Value.ToString());
				 width.Text = value.ToString("0.00");
			 };

			if (Utility.IsIPad)
			{
				spacingLbl.Frame = new CGRect(10, 25, 80, 40);
				spacing.Frame = new CGRect(spacingLbl.Frame.Size.Width, 25, 50, 40);
				widthLbl.Frame = new CGRect(10, 130, 120, 40);
				width.Frame = new CGRect(widthLbl.Frame.Size.Width, 130, 50, 40);
				spacingSlider.Frame = new RectangleF(10, 50, (float)PopoverSize.Width - 20, 60);
				widthSlider.Frame = new RectangleF(10, 155, (float)PopoverSize.Width - 20, 60);
			}
			else
			{
				spacingLbl.Frame = new CGRect(10, 25, 80, 40);
				spacing.Frame = new CGRect(spacingLbl.Frame.Size.Width, 25, 50, 40);
				widthLbl.Frame = new CGRect(10, 130, 120, 40);
				width.Frame = new CGRect(widthLbl.Frame.Size.Width, 130, 50, 40);
				spacingSlider.Frame = new RectangleF(10, 50, (float)this.Frame.Width - 20, 60);
				widthSlider.Frame = new RectangleF(10, 155, (float)this.Frame.Width - 20, 60);
			}

			this.OptionView.AddSubview(spacingLbl);
			this.OptionView.AddSubview(widthLbl);
			this.OptionView.AddSubview(spacing);
			this.OptionView.AddSubview(width);
			this.OptionView.AddSubview(spacingSlider);
			this.OptionView.AddSubview(widthSlider);

		}
	}
}