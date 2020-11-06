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
    public class Trackball : SampleView
    {
        UILabel label;
        SFChart chart;
        public Trackball()
        {
            chart = new SFChart();
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

			SFDateTimeAxis primaryAxis = new SFDateTimeAxis();
            primaryAxis.AxisLineOffset = 7;
            primaryAxis.PlotOffset = 7;
            primaryAxis.ShowMajorGridLines = false;
			primaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			primaryAxis.Interval = new NSNumber(1);
			primaryAxis.IntervalType = SFChartDateTimeIntervalType.Years;
			NSCalendar calendar = new NSCalendar(NSCalendarType.Gregorian);           
			primaryAxis.Minimum = calendar.DateFromComponents(new NSDateComponents() {Year = 1999, Month = 12, Day = 31 });
            chart.PrimaryAxis = primaryAxis;

            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.MajorTickStyle.LineSize = 0;
            secondaryAxis.AxisLineStyle.LineWidth = 0;
            secondaryAxis.Minimum = new NSNumber(10);
            secondaryAxis.Maximum = new NSNumber(80);
			secondaryAxis.Interval = new NSNumber(10);
			secondaryAxis.Title.Text = new NSString("Revenue");
			secondaryAxis.AxisLineStyle.LineWidth = 0;
            secondaryAxis.MajorTickStyle.LineWidth = 0;
			NSNumberFormatter formatter = new NSNumberFormatter();
            formatter.PositiveSuffix = "M";
            secondaryAxis.LabelStyle.LabelFormatter = formatter;
            chart.SecondaryAxis = secondaryAxis;
            ChartViewModel dataModel = new ChartViewModel();

            SFLineSeries series1 = new SFLineSeries();
            series1.ItemsSource = dataModel.LineSeries1;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
			series1.Label = "John";
			series1.DataMarker.ShowMarker = true;
            series1.DataMarker.MarkerColor = UIColor.White;
            series1.DataMarker.MarkerBorderColor = UIColor.FromRGBA(0.0f / 255.0f, 189.0f / 255.0f, 174.0f / 255.0f, 1.0f);
            series1.DataMarker.MarkerBorderWidth = 2;
            series1.DataMarker.MarkerWidth = 5f;
            series1.DataMarker.MarkerHeight = 5f;
            series1.LineWidth = 3;
            chart.Series.Add(series1);

            SFLineSeries series2 = new SFLineSeries();
            series2.ItemsSource = dataModel.LineSeries2;
            series2.XBindingPath = "XValue";
            series2.YBindingPath = "YValue";
			series2.Label = "Andrew";
			series2.DataMarker.ShowMarker = true;
            series2.DataMarker.MarkerColor = UIColor.White;
            series2.DataMarker.MarkerBorderColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
            series2.DataMarker.MarkerBorderWidth = 2;
            series2.DataMarker.MarkerWidth = 5f;
            series2.DataMarker.MarkerHeight = 5f;
            series2.LineWidth = 3;
            chart.Series.Add(series2);

            SFLineSeries series3 = new SFLineSeries();
            series3.ItemsSource = dataModel.LineSeries3;
            series3.XBindingPath = "XValue";
            series3.YBindingPath = "YValue";
			series3.Label = "Thomas";
			series3.EnableTooltip = true;
			series3.DataMarker.ShowMarker = true;
            series3.DataMarker.MarkerHeight = 5f;
            series3.DataMarker.MarkerWidth = 5f;            
            series3.DataMarker.MarkerBorderColor = UIColor.FromRGBA(53.0f / 255.0f, 124.0f / 255.0f, 210.0f / 255.0f, 1.0f);
            series3.DataMarker.MarkerBorderWidth = 2;
            series3.DataMarker.MarkerColor = UIColor.White;
            series3.LineWidth = 3;
            chart.Series.Add(series3);

            label = new UILabel();
            label.Text = "Press and hold to enable trackball";
            label.Font = UIFont.FromName("Helvetica", 12f);
            label.TextAlignment = UITextAlignment.Center;
            label.LineBreakMode = UILineBreakMode.WordWrap;
            label.Lines = 2;

            label.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            label.TextColor = UIColor.FromRGB(79, 86, 91);

            CALayer topLine = new CALayer();
            topLine.Frame = new CGRect(0, 0, UIScreen.MainScreen.ApplicationFrame.Width, 0.5);
            topLine.BackgroundColor = UIColor.FromRGB(178, 178, 178).CGColor;
            label.Layer.AddSublayer(topLine);

            chart.Legend.Visible = true;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = SFChartLegendPosition.Bottom;

            chart.AddChartBehavior(new SFChartTrackballBehavior());

            this.AddSubview(chart);
            this.AddSubview(label);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                if (view == chart)
                    chart.Frame = new CGRect(0, 0, Frame.Width, Frame.Height - 48);
                else if (view == label)
                    label.Frame = new CGRect(0, Frame.Height - 10, Frame.Width, 20);
                else
                    view.Frame = Bounds;
            }
            base.LayoutSubviews();
        }
    }

    public class CustomTrackballBehavior : SFChartTrackballBehavior
    {
        public override UIView ViewForTrackballLabel(SFChartPointInfo pointInfo)
        {
            pointInfo.MarkerStyle.BorderColor = pointInfo.Series.Color;

            UIView customView = new UIView();
            customView.Frame = new CGRect(0, 0, 48, 30);

            UILabel xLabel = new UILabel();
            xLabel.Frame = new CGRect(7, 0, 50, 15);
            xLabel.TextColor = UIColor.White;
            xLabel.Font = UIFont.FromName("HelveticaNeue-BoldItalic", 13f);
            xLabel.Text = (pointInfo.Data as ChartDataModel).YValue.ToString() + "%";

            UILabel yLabel = new UILabel();
            yLabel.Frame = new CGRect(7, 15, 50, 15);
            yLabel.TextColor = UIColor.White;
            yLabel.Font = UIFont.FromName("Helvetica", 8f);
            yLabel.Text = "Efficiency";

            customView.AddSubview(xLabel);
            customView.AddSubview(yLabel);

            return customView;
        }
    }
}




