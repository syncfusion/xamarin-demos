#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Syncfusion.SfSparkline.iOS;
using UIKit;
using Foundation;

namespace SampleBrowser
{
	public class Sparkline : SampleView
	{
		SfAreaSparkline area;
		SfLineSparkline line;
		SfColumnSparkline column;
		SfWinLossSparkline winLoss;

		UILabel areaLabel;
		UILabel lineLabel;
		UILabel columnLabel;
		UILabel winLossLabel;

		public Sparkline()
		{
			var AreaData = new List<SparklineModel>
			{
				new SparklineModel {Value = 0.8},
				new SparklineModel {Value = 1.8},
				new SparklineModel {Value = 1.3},
				new SparklineModel {Value = 1.1},
				new SparklineModel {Value = 1.6},
				new SparklineModel {Value = 2.0},
				new SparklineModel {Value = 1.7},
				new SparklineModel {Value = 2.3},
				new SparklineModel {Value = 2.7},
				new SparklineModel {Value = 2.3},
				new SparklineModel {Value = 1.9},
				new SparklineModel {Value = 1.4},
				new SparklineModel {Value = 1.2},
				new SparklineModel {Value = 0.8},
			};

			var LineData = new List<SparklineModel>
			{
				new SparklineModel {Value = 1.1},
				new SparklineModel {Value = 0.9},
				new SparklineModel {Value = 1.1},
				new SparklineModel {Value = 1.3},
				new SparklineModel {Value = 1.1},
				new SparklineModel {Value = 1.8},
				new SparklineModel {Value = 2.1},
				new SparklineModel {Value = 2.3},
				new SparklineModel {Value = 1.7},
				new SparklineModel {Value = 1.5},
				new SparklineModel {Value = 2.5},
				new SparklineModel {Value = 1.9},
				new SparklineModel {Value = 1.3},
				new SparklineModel {Value = 0.9},
			};

			var ColumnData = new List<SparklineModel>
			{
				new SparklineModel {Value = 34},
				new SparklineModel {Value = 23},
				new SparklineModel {Value = -31},
				new SparklineModel {Value = 66},
				new SparklineModel {Value = 26},
				new SparklineModel {Value = 44}
			};

			var WinLossData = new List<SparklineModel>
			{
				new SparklineModel {Value = 24},
				new SparklineModel {Value = 32},
				new SparklineModel {Value = 14},
				new SparklineModel {Value = -29},
				new SparklineModel {Value = 33},
				new SparklineModel {Value = 44}
			};

			areaLabel = new UILabel();
			areaLabel.Text = "Area";
			areaLabel.Font = UIFont.FromName("HelveticaNeue-Bold", 13f);
			areaLabel.TextAlignment = UITextAlignment.Center;

			lineLabel = new UILabel();
			lineLabel.Text = "Line";
			lineLabel.Font = UIFont.FromName("HelveticaNeue-Bold", 13f);
			lineLabel.TextAlignment = UITextAlignment.Center;

			columnLabel = new UILabel();
			columnLabel.Text = "Column";
			columnLabel.Font = UIFont.FromName("HelveticaNeue-Bold", 13f);
			columnLabel.TextAlignment = UITextAlignment.Center;

			winLossLabel = new UILabel();
			winLossLabel.Text = "WinLoss";
			winLossLabel.Font = UIFont.FromName("HelveticaNeue-Bold", 13f);
			winLossLabel.TextAlignment = UITextAlignment.Center;

			area = new SfAreaSparkline();
			//area.Marker = new SparklineMarker() { IsVisible = true, Color= UIColor.Clear };
			area.ItemsSource = AreaData;
			area.YBindingPath = "Value";
			area.StrokeColor = UIColor.FromRGB(166.0f / 255.0f, 173.0f / 255.0f, 134.0f / 255.0f);
			//area.HighPointColor = UIColor.Green;
			//area.LowPointColor = UIColor.Red;
			area.Color = UIColor.FromRGBA(166.0f/255.0f, 173.0f/255.0f, 134.0f/255.0f,0.5f);

			line = new SfLineSparkline();
			//line.Marker = new SparklineMarker() { IsVisible = true, Color = UIColor.Clear };
			line.ItemsSource = LineData;
			line.StrokeColor = UIColor.FromRGB(166.0f / 255.0f, 173.0f / 255.0f, 134.0f / 255.0f);
			//line.HighPointColor = UIColor.Green;
			//line.LowPointColor = UIColor.Red;
			line.YBindingPath = "Value";

			column = new SfColumnSparkline();
			column.ItemsSource = ColumnData;
			column.YBindingPath = "Value";
			column.Color = UIColor.FromRGB(86.0f / 255.0f, 140.0f / 255.0f, 233.0f / 255.0f);
			column.FirstPointColor = UIColor.FromRGB(86.0f / 255.0f, 140.0f / 255.0f, 233.0f / 255.0f);
			column.LastPointColor = UIColor.FromRGB(86.0f / 255.0f, 140.0f / 255.0f, 233.0f / 255.0f);
			column.HighPointColor = UIColor.FromRGBA(166.0f / 255.0f, 173.0f / 255.0f, 134.0f / 255.0f, 0.9f);
			column.LowPointColor = UIColor.FromRGB(252.0f / 255.0f, 98.0f / 255.0f, 93.0f / 255.0f);

			winLoss = new SfWinLossSparkline();
			winLoss.ItemsSource = WinLossData;
			winLoss.YBindingPath = "Value";
			winLoss.Color = UIColor.FromRGB(86.0f / 255.0f, 140.0f / 255.0f, 233.0f / 255.0f);
			winLoss.FirstPointColor = UIColor.FromRGB(86.0f / 255.0f, 140.0f / 255.0f, 233.0f / 255.0f);
			winLoss.LastPointColor = UIColor.FromRGB(86.0f / 255.0f, 140.0f / 255.0f, 233.0f / 255.0f);
			winLoss.HighPointColor = UIColor.FromRGBA(166.0f / 255.0f, 173.0f / 255.0f, 134.0f / 255.0f, 0.9f);
			winLoss.LowPointColor = UIColor.FromRGB(252.0f / 255.0f, 98.0f / 255.0f, 93.0f / 255.0f); ;
			winLoss.NeutralPointsColor = UIColor.FromRGB(86.0f / 255.0f, 140.0f / 255.0f, 233.0f / 255.0f);

			this.AddSubview(areaLabel);
			this.AddSubview(lineLabel);
			this.AddSubview(columnLabel);
			this.AddSubview(winLossLabel);

			this.AddSubview(area);
			this.AddSubview(line);
			this.AddSubview(column);
			this.AddSubview(winLoss);
		}

		public override void LayoutSubviews()
		{
			nfloat X = 40;
			nfloat Y = 0;
			nfloat height = (this.Frame.Size.Height - 120) / 4;
			nfloat width = this.Frame.Size.Width - 80;

			area.Frame = new CGRect(X, Y, width, height); 
			areaLabel.Frame = new CGRect(X, Y+ area.Frame.Size.Height, width, 15);
			Y = Y + area.Frame.Size.Height + 20;
			line.Frame = new CGRect(X,Y, width, height);

			lineLabel.Frame = new CGRect(X, Y+line.Frame.Size.Height, width, 15);
			Y = Y + line.Frame.Size.Height + 25;
			column.Frame = new CGRect(X, Y, width, height);

			columnLabel.Frame = new CGRect(X, Y+column.Frame.Size.Height+5, width, 15);
			Y = Y + column.Frame.Size.Height + 35;
			winLoss.Frame = new CGRect(X, Y, width, height);
			winLossLabel.Frame = new CGRect(X, Y + column.Frame.Size.Height, width, 15);
			base.LayoutSubviews();
		}
	}

    [Preserve(AllMembers = true)]
    public class SparklineModel
	{
		public double Value { get; set; }
	}
}

