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
            chart.Title.Text = new NSString("World Countries Details");
			SFNumericalAxis primary = new SFNumericalAxis();
			primary.ShowMajorGridLines = false;
			chart.PrimaryAxis = primary;
            chart.PrimaryAxis.Title.Text = new NSString("Literacy Rate");
			SFNumericalAxis secondary = new SFNumericalAxis();
			secondary.ShowMajorGridLines = false;
			secondary.Minimum = new NSNumber(-500);
			secondary.Maximum = new NSNumber(700);
			chart.SecondaryAxis = secondary;
            chart.SecondaryAxis.Title.Text = new NSString("GDP Growth Rate");

			ChartViewModel dataModel = new ChartViewModel();

			SFScatterSeries series = new SFScatterSeries();
			series.ItemsSource = dataModel.ScatterDataZoomPan;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
            
			chart.Series.Add(series);

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

	}
}