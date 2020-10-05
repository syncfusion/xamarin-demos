#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class DataMarkerCustomization : SamplePage
    {
        SfChart chart;
        LineSeries lineSeries1, lineSeries2;
        float density;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Population of India (2013 - 2016)";
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            density = context.Resources.DisplayMetrics.Density;
            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.ShowMajorGridLines = false;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.PlotOffset = 30;
            categoryaxis.AxisLineOffset = 30;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 900;
            numericalaxis.Maximum = 1300;
            numericalaxis.Interval = 80;
            numericalaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            numericalaxis.Title.Text = "Population";
            chart.SecondaryAxis = numericalaxis;

            lineSeries1 = new LineSeries();
            lineSeries1.ItemsSource = MainPage.GetDataMarkerData1();
            lineSeries1.XBindingPath = "XValue";
            lineSeries1.YBindingPath = "YValue";
            lineSeries1.EnableAnimation = true;
            lineSeries1.Label = "Male";
            lineSeries1.DataMarker.ShowLabel = true;
            lineSeries1.DataMarkerLabelCreated += LineSeries1_DataMarkerLabelCreated;
            lineSeries1.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Center;
            lineSeries1.DataMarker.LabelStyle.OffsetY = -18;
            lineSeries1.DataMarker.ShowMarker = true;
            lineSeries1.DataMarker.MarkerColor = Color.White;
            lineSeries1.DataMarker.MarkerHeight = 6;
            lineSeries1.DataMarker.MarkerWidth = 6;
            lineSeries1.DataMarker.MarkerStrokeWidth = 2;
            lineSeries1.DataMarker.MarkerStrokeColor = Color.ParseColor("#00BDAE");
			chart.Series.Add(lineSeries1);

            lineSeries2 = new LineSeries();
            lineSeries2.ItemsSource = MainPage.GetDataMarkerData2();
            lineSeries2.XBindingPath = "XValue";
            lineSeries2.YBindingPath = "YValue";
            lineSeries2.EnableAnimation = true;
            lineSeries2.Label = "Female";
            lineSeries2.DataMarker.ShowLabel = true;
            lineSeries2.DataMarkerLabelCreated += LineSeries2_DataMarkerLabelCreated;
            lineSeries2.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Center;
            lineSeries2.DataMarker.LabelStyle.OffsetY = 18;
            lineSeries2.DataMarker.ShowMarker = true;
            lineSeries2.DataMarker.MarkerColor = Color.White;
            lineSeries2.DataMarker.MarkerHeight = 6;
            lineSeries2.DataMarker.MarkerWidth = 6;
            lineSeries2.DataMarker.MarkerStrokeWidth = 2;
            lineSeries2.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            chart.Series.Add(lineSeries2);

            return chart;
        }

        private void LineSeries1_DataMarkerLabelCreated(object sender, ChartSeries.DataMarkerLabelCreatedEventArgs e)
        {
            LinearLayout layout = new LinearLayout(chart.Context);
            layout.SetBackgroundColor(Color.ParseColor("#00BDAE"));
            layout.SetPadding(3, 3, 3, 3);

            TextView text = new TextView(chart.Context);
            ImageView image = new ImageView(chart.Context);
            image.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams((int)(20 * density), (int)(20 * density)));
            image.SetImageResource(Resource.Drawable.Male);
            text.Text = e.DataMarkerLabel.Label + "M";
            text.SetTextColor(Color.White);

            layout.AddView(image);
            layout.AddView(text);
            e.DataMarkerLabel.View = layout;
        }
        private void LineSeries2_DataMarkerLabelCreated(object sender, ChartSeries.DataMarkerLabelCreatedEventArgs e)
        {
            LinearLayout layout = new LinearLayout(chart.Context);
            layout.SetBackgroundColor(Color.ParseColor("#404041"));
            layout.SetPadding(3, 3, 3, 3);

            TextView text = new TextView(chart.Context);
            ImageView image = new ImageView(chart.Context);
            image.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams((int)(20 * density), (int)(20 * density)));
            image.SetImageResource(Resource.Drawable.Female);
            text.Text = e.DataMarkerLabel.Label + "M";
            text.SetTextColor(Color.White);

            layout.AddView(image);
            layout.AddView(text);
            e.DataMarkerLabel.View = layout;
        }
    }
}