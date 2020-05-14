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
using CoreGraphics;
using Foundation;
using UIKit;

#else
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

using System.Threading.Tasks;

namespace SampleBrowser
{
	public class AutoScrolling : SampleView
	{
		SFChart chart;
		UILabel label;
		NSNumber value;
		Random random;
		bool isDispose = false;

		ChartViewModel dataModel;
		public AutoScrolling ()
		{

			chart 							= new SFChart ();
			SFNumericalAxis primaryAxis 	= new SFNumericalAxis ();
			primaryAxis.AutoScrollingDelta 	= 10;
			chart.PrimaryAxis				= primaryAxis;
			SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			secondaryAxis.Minimum 			= NSObject.FromObject(0);
			secondaryAxis.Maximum 			= NSObject.FromObject(9);
			chart.SecondaryAxis				= secondaryAxis;
			dataModel 						= new ChartViewModel();

			SFColumnSeries series = new SFColumnSeries();
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			series.ItemsSource = dataModel.data;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			chart.Series.Add(series);
			label 							= new UILabel ();
			label.Text 						= "In this demo, a data point is being added for every 500 milliseconds. The Chart is then automatically scrolled to display the fixed range of data points at the end. You can also pan to view previous data points. In this sample the delta value is 10";
			label.Font						= UIFont.FromName("Helvetica", 12f);
			label.TextAlignment 			= UITextAlignment.Center;
			label.LineBreakMode 			= UILineBreakMode.WordWrap;
			label.Lines 					= 6; 
			label.BackgroundColor		    = UIColor.FromRGB (249, 249, 249);
			label.TextColor 			   	= UIColor.FromRGB (79, 86, 91);

			chart.AddChartBehavior (new SFChartZoomPanBehavior());

			this.AddSubview (chart);

			CALayer topLine					= new CALayer ();
			topLine.Frame			    	= new CGRect (0, 0, UIScreen.MainScreen.ApplicationFrame.Width , 0.5);
			topLine.BackgroundColor			= UIColor.FromRGB (178, 178, 178).CGColor;
			label.Layer.AddSublayer (topLine);

			this.AddSubview (label);
			random = new Random ();
			UpdateData ();
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view == chart)
					chart.Frame = new CGRect (0, 0, Frame.Width, Frame.Height - 72);
				else if (view == label)
					label.Frame = new CGRect (0, Frame.Height-74, Frame.Width, 80);

			}
			base.LayoutSubviews ();
		}

		async void UpdateData()
		{
			await Task.Delay(500);

			if (!isDispose) 
			{
				AddDataPoint ();
				UpdateData ();
			}
		}

		private void AddDataPoint()
		{
			if (chart != null) {
				value = new NSNumber(random.Next(0,9)) ;
				dataModel.data.Add (new ChartDataModel(dataModel.wave1, (double)value));
				chart.InsertDataPointAtIndex ((int)dataModel.data.Count - 1, 0);
				dataModel.wave1++;
			}
		}

		protected override void Dispose (bool disposing)
		{
			isDispose = true;
			base.Dispose (disposing);
		}

	}
}

