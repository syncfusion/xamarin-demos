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
	public class Funnel : SampleView
	{
		public Funnel ()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text 				= new NSString ("Website Visitors");
			chart.Legend.Visible 			= true;
			ChartViewModel dataModel		= new ChartViewModel ();

			SFFunnelSeries series = new SFFunnelSeries();
			series.ItemsSource = dataModel.FunnelData;
            series.DataMarker.LabelStyle.BackgroundColor = UIColor.Clear;
            series.DataMarker.LabelStyle.Color = UIColor.White;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.DataMarker.ShowLabel = true;
			series.LegendIcon =   SFChartLegendIcon.Circle;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			series.DataMarker.ShowLabel = true;
			series.DataMarker.LabelStyle.Color = UIColor.White;
			series.DataMarker.LabelStyle.BackgroundColor = UIColor.Clear;
			chart.Series.Add(series);
			chart.Delegate = new DataMarkerFormatter();
			chart.Legend.ToggleSeriesVisibility = true;

			this.AddSubview(chart);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

		class DataMarkerFormatter : SFChartDelegate
        {
            public override NSString GetFormattedDataMarkerLabel(SFChart chart, NSString label, nint index)
            {
                String formattedLabel = label + "%";
                label = new NSString(formattedLabel);
                return label;
            }
        }
	}
}