#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Syncfusion.SfSparkline.Android;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class SparkLine : SamplePage
	{
		SfAreaSparkline areaSparLine;
		SfLineSparkline lineSparkLine;
		SfColumnSparkline columnSparkLine;
		SfWinLossSparkline winLossSparkLine;

		public override View GetSampleContent(Context context)
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
				new SparklineModel {Value = -12},
				new SparklineModel {Value = 43},
				new SparklineModel {Value = 66},
				new SparklineModel {Value = 26},
				new SparklineModel {Value = 10}
			};

			var WinLossData = new List<SparklineModel>
			{
				new SparklineModel {Value = 34},
				new SparklineModel {Value = 23},
				new SparklineModel {Value = -31},
				new SparklineModel {Value = 0},
				new SparklineModel {Value = 26},
				new SparklineModel {Value = 44}
			};

			float width = context.Resources.DisplayMetrics.WidthPixels;
			float height = context.Resources.DisplayMetrics.HeightPixels;

            LayoutInflater layoutInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View view = layoutInflater.Inflate(Resource.Layout.SfSparkline, null);

            lineSparkLine = new SfLineSparkline(context);
            columnSparkLine = new SfColumnSparkline(context);
            areaSparLine = new SfAreaSparkline(context);
            winLossSparkLine = new SfWinLossSparkline(context);

            int layoutPadding = 30;
            int topPadding = 80;

            TextView lineSparkLineLabel = new TextView(context);
            lineSparkLineLabel.Text = "Line";
            lineSparkLineLabel.SetPadding(0, topPadding, 0, 0);
            lineSparkLineLabel.Typeface = Typeface.Create((Typeface)null, TypefaceStyle.Bold);
            lineSparkLineLabel.Gravity = GravityFlags.Center;

            TextView columnSparkLineLabel = new TextView(context);
            columnSparkLineLabel.Text = "Column";
            columnSparkLineLabel.SetPadding(0, topPadding, 0, 0);
            columnSparkLineLabel.Typeface = Typeface.Create((Typeface)null, TypefaceStyle.Bold);
            columnSparkLineLabel.Gravity = GravityFlags.Center;

            TextView areaSparLineLabel = new TextView(context);
            areaSparLineLabel.Text = "Area";
            areaSparLineLabel.SetPadding(0, topPadding, 0, 0);
            areaSparLineLabel.Typeface = Typeface.Create((Typeface)null, TypefaceStyle.Bold);
            areaSparLineLabel.Gravity = GravityFlags.Center;

            TextView winLossSparkLineLabel = new TextView(context);
            winLossSparkLineLabel.Text = "WinLoss";
            winLossSparkLineLabel.SetPadding(0, topPadding, 0, 0);
            winLossSparkLineLabel.Typeface = Typeface.Create((Typeface)null, TypefaceStyle.Bold);
            winLossSparkLineLabel.Gravity = GravityFlags.Center;

            RelativeLayout lineSparkLineLayout = view.FindViewById<RelativeLayout>(Resource.Id.lineSparkLineLayout);
            lineSparkLineLayout.SetPadding(0, layoutPadding, 0, 0);
            lineSparkLineLayout.SetGravity(GravityFlags.Center);

            var lineParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height / 10);
            lineParams.AddRule(LayoutRules.AlignParentTop);
            lineSparkLine.LayoutParameters = lineParams;

            var lineLabelParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height);
            lineLabelParams.AddRule(LayoutRules.AlignBaseline, lineSparkLine.Id);
            lineSparkLineLabel.LayoutParameters = lineLabelParams;

            lineSparkLineLayout.AddView(lineSparkLine, lineParams);
            lineSparkLineLayout.AddView(lineSparkLineLabel, lineLabelParams);

            RelativeLayout columnSparkLineLayout = view.FindViewById<RelativeLayout>(Resource.Id.columnSparkLineLayout);
            columnSparkLineLayout.SetPadding(0, layoutPadding, 0, 0);
            columnSparkLineLayout.SetGravity(GravityFlags.Center);

            var columnParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height / 10);
            columnParams.AddRule(LayoutRules.AlignParentTop);
            columnSparkLine.LayoutParameters = columnParams;

            var columnLabelParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height);
            columnLabelParams.AddRule(LayoutRules.Below, columnSparkLine.Id);
            columnSparkLineLabel.LayoutParameters = columnLabelParams;

            columnSparkLineLayout.AddView(columnSparkLine, columnParams);
            columnSparkLineLayout.AddView(columnSparkLineLabel, columnLabelParams);

            RelativeLayout areaSparLineLayout = view.FindViewById<RelativeLayout>(Resource.Id.areaSparLineLayout);
            areaSparLineLayout.SetPadding(0, layoutPadding, 0, 0);
            areaSparLineLayout.SetGravity(GravityFlags.Center);

            var areaParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height / 10);
            areaParams.AddRule(LayoutRules.AlignParentTop);
            areaSparLine.LayoutParameters = areaParams;

            var areaLabelParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height);
            areaLabelParams.AddRule(LayoutRules.Below, areaSparLine.Id);
            areaSparLineLabel.LayoutParameters = areaLabelParams;

            areaSparLineLayout.AddView(areaSparLine, areaParams);
            areaSparLineLayout.AddView(areaSparLineLabel, areaLabelParams);

            RelativeLayout winLossSparkLineLayout = view.FindViewById<RelativeLayout>(Resource.Id.winLossSparkLineLayout);
            winLossSparkLineLayout.SetPadding(0, layoutPadding, 0, 0);
            winLossSparkLineLayout.SetGravity(GravityFlags.Center);

            var winLossParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height / 10);
            winLossParams.AddRule(LayoutRules.AlignParentTop);
            winLossSparkLine.LayoutParameters = winLossParams;

            var winLossLabelParams = new RelativeLayout.LayoutParams((int)width / 2, (int)height);
            winLossLabelParams.AddRule(LayoutRules.Below, winLossSparkLine.Id);
            winLossSparkLineLabel.LayoutParameters = winLossLabelParams;

            winLossSparkLineLayout.AddView(winLossSparkLine, winLossParams);
            winLossSparkLineLayout.AddView(winLossSparkLineLabel, winLossLabelParams);

            lineSparkLine.ItemsSource = LineData;
            lineSparkLine.YBindingPath = "Value";
            lineSparkLine.Marker.Visibility = ViewStates.Visible;

            columnSparkLine.ItemsSource = ColumnData;
            columnSparkLine.YBindingPath = "Value";

            areaSparLine.ItemsSource = AreaData;
            areaSparLine.YBindingPath = "Value";
            areaSparLine.Marker.Visibility = ViewStates.Visible;

            winLossSparkLine.ItemsSource = WinLossData;
            winLossSparkLine.YBindingPath = "Value";

            return view;
        }
	}

    public class SparklineModel
    {
        public double Value { get; set; }
    }
}