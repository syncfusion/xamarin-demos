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
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class Bubble : SampleView
	{
		public Bubble ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text					= new NSString ("World Countries Details");
			SFNumericalAxis primaryAxis			= new SFNumericalAxis ();
			chart.PrimaryAxis 					= primaryAxis;
			primaryAxis.Minimum 				= new NSNumber (60);
			primaryAxis.Maximum					= new NSNumber (100);
			primaryAxis.Interval 				= new NSNumber (5);
            primaryAxis.ShowMinorGridLines      = false;
            primaryAxis.ShowMajorGridLines      = false;
			chart.PrimaryAxis.Title.Text		= new NSString ("Literacy Rate");

			chart.SecondaryAxis 				= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text 		= new NSString ("GDP Growth Rate");
			chart.SecondaryAxis.Minimum 		= new NSNumber (0);
			chart.SecondaryAxis.Maximum 		= new NSNumber (10);
			chart.SecondaryAxis.Interval        = new NSNumber(2.5);
            chart.SecondaryAxis.ShowMinorGridLines = false;
            chart.SecondaryAxis.ShowMajorGridLines = false;
			chart.Delegate                      = new TooltipFormatter();
			ChartViewModel dataModel			= new ChartViewModel ();

			SFBubbleSeries series	= new SFBubbleSeries();
			series.EnableTooltip	= true;
			series.Alpha			= 0.6f;
			series.ItemsSource		= dataModel.BubbleData;
			series.XBindingPath		= "XValue";
			series.YBindingPath		= "YValue";
			series.Size				= "Size";
			series.MaximumRadius	= 40;
			series.MinimumRadius 	= 5;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			series.EnableAnimation	= true;
			chart.Series.Add(series);

			var tooltip = new SFChartTooltipBehavior();
			tooltip.BackgroundColor = UIColor.FromRGBA(64.0f / 255.0f, 64.0f / 255.0f, 65.0f / 255.0f, 1.0f);
			chart.AddChartBehavior(tooltip);

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

	class TooltipFormatter : SFChartDelegate
    {
        public override void WillShowTooltip(SFChart chart, SFChartTooltip tooltipView)
        {
            UIView customView = new UIView();
            customView.Frame = new CGRect(0, 0, 140, 70);

			UILabel label = new UILabel();
			label.Frame = new CGRect(45, 0, 180, 18);
			label.TextColor = UIColor.White;
            label.Font = UIFont.FromName("Helvetica", 12f);
			label.Text = (tooltipView.DataPoint as ChartDataModel).Label;

			UILabel box = new UILabel();
            box.Frame = new CGRect(customView.Frame.X, label.Frame.Height, customView.Frame.Width, 1);
            box.BackgroundColor = UIColor.White;
            
            UILabel xLabel = new UILabel();
            xLabel.Frame = new CGRect(5, 20, 80, 18);
			xLabel.TextColor = UIColor.LightGray;
            xLabel.Font = UIFont.FromName("Helvetica", 12f);
			xLabel.Text = "Literacy Rate : ";

			UILabel xValue = new UILabel();
            xValue.Frame = new CGRect(87, 20, 35, 18);
			xValue.TextColor = UIColor.White;
            xValue.Font = UIFont.FromName("Helvetica", 12f);
			xValue.Text = (tooltipView.DataPoint as ChartDataModel).XValue + "%";
                        
            UILabel yLabel = new UILabel();
            yLabel.Frame = new CGRect(5, 35, 180, 18);
			yLabel.TextColor = UIColor.LightGray;
            yLabel.Font = UIFont.FromName("Helvetica", 12f);
			yLabel.Text = "GDP Growth Rate : ";
            
			UILabel yValue = new UILabel();
            yValue.Frame = new CGRect(112, 35, 35, 18);
            yValue.TextColor = UIColor.White;
            yValue.Font = UIFont.FromName("Helvetica", 12f);
            yValue.Text = tooltipView.Text;

			UILabel sizeLabel = new UILabel();
            sizeLabel.Frame = new CGRect(5, 50, 65, 18);
			sizeLabel.TextColor = UIColor.LightGray;
            sizeLabel.Font = UIFont.FromName("Helvetica", 12f);
			sizeLabel.Text = "Population : ";

            UILabel sizeValue = new UILabel();
            sizeValue.Frame = new CGRect(73, 50, 90, 18);
            sizeValue.TextColor = UIColor.White;
            sizeValue.Font = UIFont.FromName("Helvetica", 12f);
			sizeValue.Text = (tooltipView.DataPoint as ChartDataModel).Size + " Billion";

			customView.AddSubview(label);
			customView.AddSubview(box);
			customView.AddSubview(xLabel);
			customView.AddSubview(xValue);
            customView.AddSubview(yLabel);
			customView.AddSubview(yValue);
			customView.AddSubview(sizeLabel);
			customView.AddSubview(sizeValue);
            tooltipView.CustomView = customView;
        }
    }
}