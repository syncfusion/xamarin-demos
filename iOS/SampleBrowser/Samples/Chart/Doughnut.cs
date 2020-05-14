#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Collections.ObjectModel;

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
	public class Doughnut : SampleView
	{
		public Doughnut ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 					= new NSString ("Project Cost Breakdown");
			chart.Legend.Visible 				= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition           = SFChartLegendPosition.Bottom;
            chart.Legend.OverflowMode           = ChartLegendOverflowMode.Wrap;
            chart.Legend.IconWidth              = 14;
            chart.Legend.IconHeight             = 14;
			chart.Delegate                      = new CenterViewUpdater();
			chart.AddChartBehavior(new SFChartSelectionBehavior());
			ChartViewModel dataModel			= new ChartViewModel ();

			SFDoughnutSeries series = new SFDoughnutSeries();
            series.StrokeColor = UIColor.White;
			series.ItemsSource = dataModel.DoughnutSeriesData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.DataMarker.ShowLabel = true;
			series.ExplodeOnTouch = true;
			series.DataMarker.LabelContent = SFChartLabelContent.Percentage;
			series.EnableAnimation = true;
            series.ColorModel.Palette = SFChartColorPalette.Natural;

			var centerView= new UIView();
			centerView.Frame = new CGRect(chart.Frame.X / 2, chart.Frame.Y / 2, 100, 40);   
			UILabel xLabel = new UILabel();
			xLabel.Text = "Tap on slice";            
            xLabel.Font = UIFont.FromName("Helvetica", 12f);
			xLabel.TextAlignment = UITextAlignment.Center;
			xLabel.Frame = new CGRect(5, centerView.Frame.Y, centerView.Frame.Width, centerView.Frame.Height);

			UILabel yLabel = new UILabel();
			yLabel.TextAlignment = UITextAlignment.Center;
            
			centerView.AddSubview(xLabel);
			centerView.AddSubview(yLabel);
			series.CenterView = centerView;

			series.EnableDataPointSelection = true;
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

	class CenterViewUpdater : SFChartDelegate
    {
		public override void WillDataPointSelect(SFChart chart, SFChartSelectionChangingInfo info)
		{
			var doughnutSeries = info.SelectedSeries as SFDoughnutSeries;
			var xlabel = doughnutSeries.CenterView.Subviews[0] as UILabel;
			var ylabel = doughnutSeries.CenterView.Subviews[1] as UILabel;

			if (doughnutSeries.ExplodeIndex >= 0)
            {
				var datapoints = doughnutSeries.ItemsSource as ObservableCollection<ChartDataModel>;
				xlabel.Text = datapoints[doughnutSeries.ExplodeIndex].XValue.ToString();
				ylabel.Text = datapoints[doughnutSeries.ExplodeIndex].YValue + "M";
                
				var segments = doughnutSeries.Segments;
				xlabel.TextColor = segments[doughnutSeries.ExplodeIndex].Color;
				xlabel.Font = UIFont.FromName("Helvetica", 12f); 
				xlabel.Frame = new CGRect(0, 0, doughnutSeries.CenterView.Frame.Width, doughnutSeries.CenterView.Frame.Height / 2);
				xlabel.TextAlignment = UITextAlignment.Center;
                
				ylabel.Font = UIFont.FromName("Helvetica", 10f);
				ylabel.Frame = new CGRect(0, doughnutSeries.CenterView.Frame.Height / 2, doughnutSeries.CenterView.Frame.Width, doughnutSeries.CenterView.Frame.Height / 2);
				ylabel.TextAlignment = UITextAlignment.Center;
				doughnutSeries.SelectedDataPointColor = segments[doughnutSeries.ExplodeIndex].Color;
            }
            else
            {                
				xlabel.Text = "Tap on slice";
				xlabel.Font = UIFont.FromName("Helvetica", 12f);
				xlabel.TextColor = UIColor.Black;
				xlabel.Frame = new CGRect(0, 0, doughnutSeries.CenterView.Frame.Width, doughnutSeries.CenterView.Frame.Height);

				ylabel.Text = string.Empty;
            }
		}
    }

}