#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Com.Syncfusion.Navigationdrawer;
using System;
using System.Collections.Generic;


namespace SampleBrowser
{
    [Activity(Label = "Trackball")]
    public class Trackball : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Average sales for person";

            chart.Legend.Visibility = Visibility.Visible;
			chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;

            DateTimeAxis primaryAxis = new DateTimeAxis();
            primaryAxis.PlotOffset = 5;
            primaryAxis.AxisLineOffset = 5;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Interval = 1;
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.EdgeLabelsVisibilityMode = EdgeLabelsVisibilityMode.Visible;
            primaryAxis.LabelStyle.LabelFormat = "yyyy";
			chart.PrimaryAxis = primaryAxis;
            chart.PrimaryAxis.ShowMajorGridLines = false;
            chart.SecondaryAxis = new NumericalAxis { };

            chart.SecondaryAxis.MajorTickStyle.TickSize = 0;
            chart.SecondaryAxis.LineStyle.StrokeWidth = 0;
            (chart.SecondaryAxis as NumericalAxis).Maximum = 80;
            (chart.SecondaryAxis as NumericalAxis).Minimum = 10;
            (chart.SecondaryAxis as NumericalAxis).Interval = 10;
            chart.SecondaryAxis.Title.Text = "Revenue";
            chart.SecondaryAxis.LabelStyle.LabelFormat = "#'M '";

            var series = new LineSeries
            {
				ItemsSource = MainPage.GetSeriesData1(),
				XBindingPath = "Date",
				YBindingPath = "YValue",
                Label = "John",
				Color = Color.ParseColor("#00BDAE"),
				StrokeWidth= 3
            };
            series.DataMarker.MarkerStrokeColor = Color.ParseColor("#00BDAE");
            series.DataMarker.ShowMarker = true;
            series.DataMarker.MarkerColor = Color.White;
            series.DataMarker.MarkerStrokeWidth = 2;
            series.DataMarker.MarkerWidth = 6;
            series.DataMarker.MarkerHeight = 6;
            chart.Series.Add(series);

            series = new LineSeries
            {
				ItemsSource = MainPage.GetSeriesData2(),
				XBindingPath = "Date",
				YBindingPath = "YValue",
				Color = Color.ParseColor("#404041"),
				Label = "Andrew",
				StrokeWidth = 3
            };
            series.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            series.DataMarker.ShowMarker = true;
            series.DataMarker.MarkerColor = Color.White;
            series.DataMarker.MarkerStrokeWidth = 2;
            series.DataMarker.MarkerWidth = 6;
            series.DataMarker.MarkerHeight = 6;
            chart.Series.Add(series);

            series = new LineSeries
            {
				ItemsSource = MainPage.GetSeriesData3(),
				XBindingPath = "Date",
				YBindingPath = "YValue",
				Color = Color.ParseColor("#357CD2"),
                Label = "Thomas",
				StrokeWidth = 3
            };
            series.DataMarker.MarkerStrokeColor = Color.ParseColor("#357CD2");
            series.DataMarker.ShowMarker = true;
            series.DataMarker.MarkerColor = Color.White;
            series.DataMarker.MarkerStrokeWidth = 2;
            series.DataMarker.MarkerWidth = 6;
            series.DataMarker.MarkerHeight = 6;
            chart.Series.Add(series);

            chart.Behaviors.Add(new ChartTrackballBehavior());

            var label = new TextView(context);
            label.SetPadding(5, 5, 5, 5);
            label.Text = "Press and hold to enable trackball.";

            var layout = new LinearLayout(context){ Orientation = Android.Widget.Orientation.Vertical };

            var layoutLabel = new LinearLayout(context)
            {
                Orientation = Android.Widget.Orientation.Horizontal,
                LayoutParameters =
                    new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            layoutLabel.SetHorizontalGravity(GravityFlags.CenterHorizontal);
            layoutLabel.AddView(label);
            
            layout.AddView(layoutLabel);
            layout.AddView(chart);

            return layout;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            /**
     * Property Window
     * */
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context); //= new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 5);

            layoutParams1.SetMargins(0, 20, 0, 0);

            TextView labelDisplayMode = new TextView(context);
            labelDisplayMode.TextSize = 20;
            labelDisplayMode.Text = "LabelDisplay Mode";

            Spinner selectLabelMode = new Spinner(context,SpinnerMode.Dialog);
            
            List<String> adapter = new List<String>() { "FloatAllPoints", "NearestPoint", "GroupAllPoints" };
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;

            selectLabelMode.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                ChartTrackballBehavior trackballBehavior = (chart.Behaviors[0] as ChartTrackballBehavior);
                if (selectedItem.Equals("NearestPoint"))
                {
                    trackballBehavior.LabelDisplayMode = TrackballLabelDisplayMode.NearestPoint;
                }
                else if (selectedItem.Equals("FloatAllPoints"))
                {
                    trackballBehavior.LabelDisplayMode = TrackballLabelDisplayMode.FloatAllPoints;
                }
                else if (selectedItem.Equals("GroupAllPoints"))
                {
                    trackballBehavior.LabelDisplayMode = TrackballLabelDisplayMode.GroupAllPoints;
                }
            };

            propertylayout.AddView(labelDisplayMode);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);
            propertylayout.AddView(selectLabelMode);

           

            return propertylayout;
        }
    }
}