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
using nfloat = System.Single;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class StripLines : SampleView
	{
		public StripLines ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 			        = new NSString ("Weather Report");

			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.LabelPlacement			= SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis 					= primaryAxis;

			chart.PrimaryAxis.Title.Text        = new NSString ("Months");
			SFNumericalAxis numeric				= new SFNumericalAxis ();
			numeric.Minimum 					= NSObject.FromObject(10);
			numeric.Maximum 					= NSObject.FromObject(40);
			numeric.Title.Text  				= new NSString ("Temperature in Celsius");

			SFChartNumericalStripLine strip1 	= new SFChartNumericalStripLine ();
			strip1.Start                        = 10;
			strip1.Width                        = 10;
			strip1.Text                         = new NSString("Low Temperature");
			strip1.BackgroundColor              = UIColor.FromRGBA((nfloat)249/255,(nfloat)212/255,(nfloat)35/255,(nfloat)1.0);

			numeric.AddStripLine (strip1);

			SFChartNumericalStripLine strip2 	= new SFChartNumericalStripLine ();
			strip2.Start                        = 20;
			strip2.Width                        = 10;
			strip2.Text                         = new NSString("Average Temperature");
			strip2.BackgroundColor              = UIColor.FromRGBA((nfloat)252/255,(nfloat)144/255,(nfloat)42/255,(nfloat)1.0);

			numeric.AddStripLine (strip2);

			SFChartNumericalStripLine strip3 	= new SFChartNumericalStripLine ();
			strip3.Start                        = 30;
			strip3.Width                        = 10;
			strip3.Text                         = new NSString("High Temperature");
			strip3.BackgroundColor              = UIColor.FromRGBA((nfloat)254/255,(nfloat)81/255,(nfloat)47/255,(nfloat)1.0);

			numeric.AddStripLine (strip3);

			chart.SecondaryAxis 		        = numeric;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFLineSeries series = new SFLineSeries();
			series.LineWidth = 2;
			series.Color = UIColor.White;
			series.ItemsSource = dataModel.StripLineData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;

			series.DataMarker.ShowLabel = false;
			series.DataMarker.ShowMarker = true;
			series.DataMarker.MarkerWidth = 10;
			series.DataMarker.MarkerHeight = 10;
			series.DataMarker.MarkerColor = UIColor.FromRGBA((nfloat)102/255, (nfloat)102/255, (nfloat)102/255, (nfloat)1.0);
			series.DataMarker.MarkerBorderColor = UIColor.FromRGBA((nfloat)255, (nfloat)255, (nfloat)255, (nfloat)1.0); ;
			series.DataMarker.MarkerBorderWidth = 4;

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