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
            SFChart chart = new SFChart();
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            primaryAxis.AxisLineOffset = 2;
            primaryAxis.PlotOffset = 5;
            primaryAxis.ShowMajorGridLines = false;
            chart.PrimaryAxis = primaryAxis;

            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.MajorTickStyle.LineSize = 0;
            secondaryAxis.AxisLineStyle.LineWidth = 0;
            secondaryAxis.Minimum = new NSNumber(25);
            secondaryAxis.Maximum = new NSNumber(50);
            chart.SecondaryAxis = secondaryAxis;
            ChartViewModel dataModel = new ChartViewModel();

            SFLineSeries series1 = new SFLineSeries();
            series1.ItemsSource = dataModel.LineSeries1;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
            series1.Label = "Germany";
            series1.LineWidth = 3;
            chart.Series.Add(series1);

            SFLineSeries series2 = new SFLineSeries();
            series2.ItemsSource = dataModel.LineSeries2;
            series2.XBindingPath = "XValue";
            series2.YBindingPath = "YValue";
            series2.Label = "England";
            series2.LineWidth = 3;
            chart.Series.Add(series2);

            SFLineSeries series3 = new SFLineSeries();
            series3.ItemsSource = dataModel.LineSeries3;
            series3.XBindingPath = "XValue";
            series3.YBindingPath = "YValue";
            series3.Label = "France";
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




