#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace SampleBrowser
{
	public class StackedDoughnut : SampleView
	{
		void Chart_LegendItemCreated(object sender, ChartLegendItemCreatedEventArgs e)
		{
			ChartDataModel dataModel = e.LegendItem.DataPoint as ChartDataModel;
			float heightAndWidth = Utility.IsIPad ? 80 : 60;

			UIView legendView = new UIView();
			legendView.Frame = new CGRect(0, 0, 130, heightAndWidth - 10);

			SFChart legendChart = new SFChart();
			legendChart.Frame = new CGRect(0, 0, heightAndWidth, heightAndWidth);

			UIImageView imageView = new UIImageView();
			imageView.Image = UIImage.FromBundle(dataModel.Image);
			imageView.Frame = new CGRect(legendChart.Frame.X / 2, legendChart.Frame.Y / 2, Utility.IsIPad ? 30 : 20, Utility.IsIPad ? 30 : 20);

			SFDoughnutSeries series = new SFDoughnutSeries();
			series.IsStackedDoughnut = true;
			series.Color = e.LegendItem.IconColor;
			series.ItemsSource = new List<ChartDataModel>() { dataModel };
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.StartAngle = -90;
			series.EndAngle = 270;
			series.MaximumValue = 100;
			series.Spacing = 0.2;
			series.DoughnutCoefficient = 0.8;
			series.CircularCoefficient = 1.0;
			series.CapStyle = DoughnutCapStyle.BothCurve;
			series.CenterView = imageView;
			legendChart.Series.Add(series);
			legendView.AddSubview(legendChart);

			UILabel yLabel = new UILabel();
			yLabel.Frame = new CGRect(Utility.IsIPad ? 77 : 57, Utility.IsIPad ? 20 : 10, 80, 18);
			yLabel.TextColor = e.LegendItem.IconColor;
			yLabel.Font = UIFont.FromName("Helvetica", 14f);
			yLabel.Text = dataModel.YValue.ToString() + "%";

			UILabel xLabel = new UILabel();
			xLabel.Frame = new CGRect(Utility.IsIPad ? 77 : 57, Utility.IsIPad ? 40 : 30, 80, 18);
			xLabel.TextColor = UIColor.Black;
			xLabel.Font = UIFont.FromName("Helvetica", 12f);
			xLabel.Text = dataModel.XValue.ToString();

			legendView.AddSubview(yLabel);
			legendView.AddSubview(xLabel);

			e.LegendItem.View = legendView;
		}

		public StackedDoughnut()
		{
			ChartViewModel viewModel = new ChartViewModel();

			SFChart chart = new SFChart();
			chart.Title.Text = new NSString("Percentage of Loan Closure");
			chart.Title.Font = UIFont.SystemFontOfSize(15);
			chart.Legend.Visible = true;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
			chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
			chart.LegendItemCreated += Chart_LegendItemCreated; ;

			UIImageView imageView = new UIImageView();
			imageView.Image = UIImage.FromBundle("Images/Person.png");
			float heightAndWidth = Utility.IsIPad ? 250 : 80;
			imageView.Frame = new CGRect(chart.Frame.X / 2, chart.Frame.Y / 2, heightAndWidth, heightAndWidth);   

			SFDoughnutSeries doughnutSeries = new SFDoughnutSeries();
			doughnutSeries.IsStackedDoughnut = true;
			doughnutSeries.ColorModel.Palette = SFChartColorPalette.Custom;
			doughnutSeries.ColorModel.CustomColors = NSArray.FromObjects(UIColor.FromRGBA(0.28f, 0.73f, 0.62f, 1.0f), 
			                                                             UIColor.FromRGBA(0.90f, 0.53f, 0.44f, 1.0f), 
			                                                             UIColor.FromRGBA(0.59f, 0.53f, 0.79f, 1.0f),
			                                                             UIColor.FromRGBA(0.90f, 0.40f, 0.56f, 1.0f));
			doughnutSeries.ItemsSource = viewModel.StackedDoughnutData;
			doughnutSeries.XBindingPath = "XValue";
			doughnutSeries.YBindingPath = "YValue";
			doughnutSeries.StartAngle = -90;
			doughnutSeries.EndAngle = 270;
			doughnutSeries.MaximumValue = 100;
			doughnutSeries.Spacing = 0.2;
			doughnutSeries.DoughnutCoefficient = 0.6;
			doughnutSeries.CircularCoefficient = 1;
			doughnutSeries.CapStyle = DoughnutCapStyle.BothCurve;
			doughnutSeries.CenterView = imageView;
			chart.Series.Add(doughnutSeries);

			this.AddSubview(chart);
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = Bounds;
			}
			base.LayoutSubviews();
		}
	}
}
