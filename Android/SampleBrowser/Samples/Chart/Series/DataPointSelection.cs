#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    public class DataPointSelection : SamplePage
    {
        private TextView label;
        private TextView productLabel1;
        private TextView productLabel2;

        double sumOfTotalSeries1 = 0;
        double sumOfTotalSeries2 = 0;
        IList<DataPoint> datapoint;
        IList<DataPoint> datapoint1;
        List<String> selectionMode;

        ColumnSeries columnSeries;
        ColumnSeries columnSeries1;
        SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Product Sale 2016";
            chart.SetBackgroundColor(Color.White);

            var primaryAxis = new CategoryAxis { LabelPlacement = LabelPlacement.BetweenTicks };

            primaryAxis.Title.Text = "Month";
            chart.PrimaryAxis = primaryAxis;

            var secondaryAxis = new NumericalAxis();
            primaryAxis.ShowMajorGridLines = false;
            secondaryAxis.Title.Text = "Sales";
            secondaryAxis.LabelStyle.LabelFormat = "$##.##";
            chart.SecondaryAxis = secondaryAxis;

            columnSeries = new ColumnSeries
            {
				ItemsSource = MainPage.GetSelectionData(),
				XBindingPath = "XValue",
				YBindingPath = "YValue",
				Color = Color.ParseColor("#00BDAE"),
				SelectedDataPointColor = Color.ParseColor("#007168"),
                DataPointSelectionEnabled = true,
                EnableAnimation = true,
                Label = "Product A"
            };

            chart.Series.Add(columnSeries);

            columnSeries1 = new ColumnSeries
            {
                ItemsSource = MainPage.GetSelectionData1(),
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                Color = Color.ParseColor("#7F84E8"),
                SelectedDataPointColor = Color.ParseColor("#4A4FB2"),
                DataPointSelectionEnabled = true,
                EnableAnimation = true,
                Label = "Product B"
            };

            chart.Series.Add(columnSeries1);

            datapoint = columnSeries.ItemsSource as IList<DataPoint>;
            datapoint1 = columnSeries1.ItemsSource as IList<DataPoint>;

            foreach (var data in datapoint)
            {
                sumOfTotalSeries1 += data.YValue;
            }

            foreach (var data in datapoint1)
            {
                sumOfTotalSeries2 += data.YValue;
            }

            chart.Behaviors.Add(new ChartSelectionBehavior());
            chart.SelectionChanged += chart_SelectionChanged;

            label = new TextView(context){ TextSize = 15 };
            label.Text = "Tap on a bar segment to select a data point.";
            label.SetPadding(5, 5, 5, 5);

            productLabel1 = new TextView(context) { TextSize = 15, Visibility = ViewStates.Gone, };
            productLabel1.SetTextColor(Color.ParseColor("#007168"));
            productLabel1.SetPadding(5, 5, 5, 5);

            productLabel2 = new TextView(context) { TextSize = 15, Visibility = ViewStates.Gone, };
            productLabel2.SetTextColor(Color.ParseColor("#4A4FB2"));
            productLabel2.SetPadding(5, 5, 5, 5);

            var layout = new LinearLayout(context){ Orientation = Android.Widget.Orientation.Vertical };

            var layoutLabel = new LinearLayout(context)
            {
                Orientation = Android.Widget.Orientation.Horizontal,
                LayoutParameters =
                    new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            layoutLabel.SetHorizontalGravity(GravityFlags.CenterHorizontal);
            layoutLabel.AddView(label);
            layoutLabel.AddView(productLabel1);
            layoutLabel.AddView(productLabel2);
            layout.AddView(layoutLabel);
            layout.AddView(chart);
                       
            return layout;
        }

        private void chart_SelectionChanged(object sender, SfChart.SelectionChangedEventArgs e)
        {
            var chart = sender as SfChart;

            var series = e.P1.SelectedSeries;
            if (series == null) return;

            if (chart.EnableSeriesSelection)
            {

                productLabel1.Visibility = ViewStates.Gone;
                productLabel2.Visibility = ViewStates.Gone;
                label.Visibility = ViewStates.Visible;

                if (columnSeries.IsSelected)
                {
                    label.Text = series.Label + " | Total Sales : $" + sumOfTotalSeries1;
                    return;
                }
                else if (columnSeries1.IsSelected)
                {
                    label.Text = series.Label + " | Total Sales : $" + sumOfTotalSeries2;
                    return;
                }

                label.Text = "Tap on a bar segment to select a series";
            }
            else
            {

                productLabel1.Visibility = ViewStates.Visible;
                productLabel2.Visibility = ViewStates.Visible;
                label.Visibility = ViewStates.Gone;

                var selectedindex = e.P1.SelectedDataPointIndex;
                var seriesIndex = chart.Series.IndexOf(e.P1.SelectedSeries);

                if (selectedindex < 0)
                {
                    if (seriesIndex == 0)
                        productLabel1.Text = "Tap on a bar segment";
                    else
                        productLabel2.Text = "Tap on a bar segment";

                    return;
                }
                else
                {
                    if (seriesIndex == 0)
                    {
                        var x = datapoint[selectedindex].XValue;
                        var y = datapoint[selectedindex].YValue;
                        productLabel1.Text = "Month : " + x + ",  Sales : $" + y;
                    }
                    else if (seriesIndex == 1)
                    {
                        var x = datapoint1[selectedindex].XValue;
                        var y = datapoint1[selectedindex].YValue;
                        productLabel2.Text = "Month : " + x + ",  Sales : $" + y;
                    }
                }
            }
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context); 
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 5);

            layoutParams1.SetMargins(0, 20, 0, 0);

            TextView selection = new TextView(context);
            selection.TextSize = 20;
            selection.Text = "Selection";
            selection.SetPadding(5, 20, 0, 20);

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            selectionMode = new List<String>() { "Data Point Selection", "Series Selection" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
               (context, Android.Resource.Layout.SimpleSpinnerItem, selectionMode);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;

            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);

            propertylayout.AddView(selection);
            propertylayout.AddView(selectLabelMode);
            propertylayout.AddView(separate, layoutParams1);

            return propertylayout;
        }

        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = selectionMode[e.Position];
            if (selectedItem.Equals("Data Point Selection"))
            {
                chart.EnableSeriesSelection = false;
            }
            else if (selectedItem.Equals("Series Selection"))
            {
                chart.EnableSeriesSelection = true;
            }
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }
    }
}