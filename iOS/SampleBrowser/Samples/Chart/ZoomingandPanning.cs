#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using CoreAnimation;


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
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class ZoomingandPanning : SampleView
	{
		SFChart chart;
		UILabel label;
		public ZoomingandPanning()
		{
			chart = new SFChart();
            chart.ColorModel.Palette = SFChartColorPalette.Natural;
            chart.Title.Text = new NSString("Height vs Weight");
			chart.Delegate = new TooltipGenerator();

            SFNumericalAxis primary = new SFNumericalAxis();
            primary.ShowMajorGridLines = false;
            primary.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            primary.Minimum = new NSNumber(100);
            primary.Maximum = new NSNumber(220);
            primary.Interval = new NSNumber(20);
            primary.Title.Text = new NSString("Height in Inches");
            primary.TrackballLabelStyle.Visible = true;
            chart.PrimaryAxis = primary;

            SFNumericalAxis secondary = new SFNumericalAxis();
            secondary.Title.Text = new NSString("Weight in Pounds");
            secondary.ShowMajorGridLines = false;
            secondary.Minimum = new NSNumber(50);
            secondary.Maximum = new NSNumber(80);
            secondary.Interval = new NSNumber(5);
            secondary.TrackballLabelStyle.Visible = true;
            chart.SecondaryAxis = secondary;
            ChartViewModel dataModel = new ChartViewModel();

            SFScatterSeries series = new SFScatterSeries();
            series.ItemsSource = dataModel.ScatterMaleData;
            series.XBindingPath = "XValue";
            series.YBindingPath = "YValue";
            series.EnableTooltip = true;
            series.ScatterHeight = 10;
            series.ScatterWidth = 10;
            series.Alpha = 0.7f;
            series.EnableAnimation = true;
            series.Label = "Male";
            series.LegendIcon = SFChartLegendIcon.SeriesType;
            chart.Series.Add(series);

            SFScatterSeries series1 = new SFScatterSeries();
            series1.ItemsSource = dataModel.ScatterFemaleData;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
            series1.EnableTooltip = true;
            series1.ScatterHeight = 10;
            series1.ScatterWidth = 10;
			series1.ShapeType = ChartScatterShapeType.Diamond;
            series1.Alpha = 0.7f;
            series1.EnableAnimation = true;
            series1.Label = "Female";
            series1.LegendIcon = SFChartLegendIcon.SeriesType;
            chart.Series.Add(series1);

            chart.Legend.Visible = true;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            chart.Legend.DockPosition = SFChartLegendPosition.Bottom;

            var tooltip = new SFChartTooltipBehavior();
            tooltip.BackgroundColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
            chart.AddChartBehavior(tooltip);

			label = new UILabel();
			label.Text = "Pinch to zoom or double tap and drag to select a region to zoom in";
			label.Font = UIFont.FromName("Helvetica", 12f);
			label.TextAlignment = UITextAlignment.Center;
			label.LineBreakMode = UILineBreakMode.WordWrap;
			label.Lines = 2;
			label.BackgroundColor = UIColor.FromRGB(249, 249, 249);
			label.TextColor = UIColor.FromRGB(79, 86, 91);
			chart.AddChartBehavior(new SFChartZoomPanBehavior() { EnableSelectionZooming = true });
			this.AddSubview(chart);

			CALayer topLine = new CALayer();
			topLine.Frame = new CGRect(0, 0, UIScreen.MainScreen.ApplicationFrame.Width, 0.5);
			topLine.BackgroundColor = UIColor.FromRGB(178, 178, 178).CGColor;
			label.Layer.AddSublayer(topLine);

			this.AddSubview(label);
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				if (view == chart)
					chart.Frame = new CGRect(0, 0, Frame.Width, Frame.Height - 48);
				else if (view == label)
					label.Frame = new CGRect(0, Frame.Height - 32, Frame.Width, 40);
				else
					view.Frame = Frame;

			}
			base.LayoutSubviews();
		}

		class TooltipGenerator : SFChartDelegate
        {
            public override void WillShowTooltip(SFChart chart, SFChartTooltip tooltipView)
            {
                UIView customView = new UIView();
                customView.Frame = new CGRect(0, 0, 95, 55);
                var height = customView.Frame.Height / 3;

                UILabel label = new UILabel();
                label.Frame = new CGRect(0, 0, customView.Frame.Width, height);
                label.TextColor = UIColor.White;
                label.Font = UIFont.FromName("Helvetica", 12f);
                label.TextAlignment = UITextAlignment.Center;
                label.Text = tooltipView.Series.Label;

                UILabel box = new UILabel();
                box.Frame = new CGRect(customView.Frame.X, label.Frame.Height, customView.Frame.Width, 1);
                box.BackgroundColor = UIColor.White;

                UILabel xLabel = new UILabel();
                xLabel.Frame = new CGRect(5, 35, 60, height);
                xLabel.TextColor = UIColor.LightGray;
                xLabel.Font = UIFont.FromName("Helvetica", 12f);
                xLabel.Text = "Height : ";

                UILabel xValue = new UILabel();
                xValue.Frame = new CGRect(53, 35, 40, height);
                xValue.TextColor = UIColor.White;
                xValue.Font = UIFont.FromName("Helvetica", 12f);
                xValue.Text = (tooltipView.DataPoint as ChartDataModel).XValue.ToString();

                UILabel yLabel = new UILabel();
                yLabel.Frame = new CGRect(5, 20, 60, height);
                yLabel.TextColor = UIColor.LightGray;
                yLabel.Font = UIFont.FromName("Helvetica", 12f);
                yLabel.Text = "Weight : ";

                UILabel yValue = new UILabel();
                yValue.Frame = new CGRect(54, 20, 55, height);
                yValue.TextColor = UIColor.White;
                yValue.Font = UIFont.FromName("Helvetica", 12f);
                yValue.Text = (tooltipView.DataPoint as ChartDataModel).YValue + " lbs";

                customView.AddSubview(label);
                customView.AddSubview(box);
                customView.AddSubview(xLabel);
                customView.AddSubview(xValue);
                customView.AddSubview(yLabel);
                customView.AddSubview(yValue);
                tooltipView.CustomView = customView;
            }
        }
	}
}