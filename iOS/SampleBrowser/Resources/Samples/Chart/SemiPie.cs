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
	public class SemiPie : SampleView
	{
		public SemiPie ()
		{
			SFChart chart 						= new SFChart ();
			chart.Legend.Visible 				= true;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFPieSeries series = new SFPieSeries();
            series.StrokeColor = UIColor.White;
			series.ItemsSource = dataModel.SemiCircularData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.StartAngle = 180;
			series.EndAngle = 360;
			series.DataMarker.ShowLabel = true;
			series.DataMarker.LabelContent = SFChartLabelContent.Percentage;
			series.DataMarkerPosition = SFChartCircularSeriesLabelPosition.Outside;
			series.EnableAnimation = true;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.Series.Add(series);

			chart.Legend.DockPosition 			= SFChartLegendPosition.Bottom;
			chart.Legend.ToggleSeriesVisibility = true;
			chart.Title.Text 					= new NSString ("Products Growth - 2015");
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