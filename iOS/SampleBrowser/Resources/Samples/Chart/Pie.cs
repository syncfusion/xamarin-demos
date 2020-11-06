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
	public class Pie : SampleView
	{
		public Pie ()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text 				= new NSString ("Mobile Browser Statistics");
			chart.Legend.Visible 			= true;
			ChartViewModel dataModel		= new ChartViewModel ();

			SFPieSeries series = new SFPieSeries();
            series.StrokeColor = UIColor.White;
			series.ItemsSource = dataModel.PieSeriesData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.StartAngle = 50;
			series.EndAngle = 410;
			series.CircularCoefficient = 0.65f;
			series.EnableSmartLabels = true;
			series.DataMarkerPosition = SFChartCircularSeriesLabelPosition.OutsideExtended;
			series.ConnectorLineType = SFChartConnectorLineType.Bezier;
			series.DataMarker.ShowLabel = true;
			series.DataMarker.LabelContent = SFChartLabelContent.Percentage;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            chart.Legend.ToggleSeriesVisibility = true;
			series.EnableAnimation = true;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.Series.Add(series);

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