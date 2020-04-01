#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    public class Column : SamplePage
    {
        SfChart chart;
        ColumnSeries columnSeries1;
        ColumnSeries columnSeries2;
        ColumnSeries columnSeries3;
        TextView spacingValue;
        TextView columnWidthValue;
        TextView cornerRadiusValue;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Olympic Medal Counts - RIO";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.Title.Text = "Countries";
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.ShowMajorGridLines = false;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Title.Text = "Medals";
            numericalaxis.Visibility = Visibility.Gone;
            numericalaxis.ShowMajorGridLines = false;
            chart.SecondaryAxis = numericalaxis;

            columnSeries1 = new ColumnSeries();
            columnSeries1.Label = "Gold";
			columnSeries1.ItemsSource = MainPage.GetColumnData1();
			columnSeries1.XBindingPath = "XValue";
			columnSeries1.YBindingPath = "YValue";
            columnSeries1.TooltipEnabled = true;
            columnSeries1.EnableAnimation = true;
            columnSeries1.LegendIcon = ChartLegendIcon.SeriesType;
            columnSeries1.DataMarker.ShowLabel = true;
            columnSeries1.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Inner;

			columnSeries2 = new ColumnSeries();
            columnSeries2.Label = "Silver";
			columnSeries2.ItemsSource = MainPage.GetColumnData2();
			columnSeries2.XBindingPath = "XValue";
			columnSeries2.YBindingPath = "YValue";
            columnSeries2.TooltipEnabled = true;
            columnSeries2.EnableAnimation = true;
            columnSeries2.LegendIcon = ChartLegendIcon.SeriesType;
            columnSeries2.DataMarker.ShowLabel = true;
            columnSeries2.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Inner;

            columnSeries3 = new ColumnSeries();
            columnSeries3.Label = "Bronze";
			columnSeries3.ItemsSource = MainPage.GetColumnData3();
			columnSeries3.XBindingPath = "XValue";
			columnSeries3.YBindingPath = "YValue";
            columnSeries3.TooltipEnabled = true;
            columnSeries3.EnableAnimation = true;
            columnSeries3.LegendIcon = ChartLegendIcon.SeriesType;
            columnSeries3.DataMarker.ShowLabel = true;
            columnSeries3.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Inner;

            chart.Series.Add(columnSeries1);
            chart.Series.Add(columnSeries2);
            chart.Series.Add(columnSeries3);

            return chart;
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

            spacingValue = new TextView(context);
            spacingValue.Text = "Spacing : 0.0";
            spacingValue.SetPadding(5, 20, 0, 20);

            columnWidthValue = new TextView(context);
            columnWidthValue.Text = "Width : 0.8";
            columnWidthValue.SetPadding(5, 20, 0, 20);

            cornerRadiusValue = new TextView(context);
            cornerRadiusValue.Text = "Corner Radious : 0";
            cornerRadiusValue.SetPadding(5, 20, 0, 20);

            SeekBar spacing = new SeekBar(context);
            spacing.Max = 10;

            SeekBar columnWidth = new SeekBar(context);
            columnWidth.Max = 10;
            columnWidth.Progress = 8;

            SeekBar cornerRadius = new SeekBar(context);
            cornerRadius.Max = 15;
            cornerRadius.Progress = 0;

            spacing.ProgressChanged += Spacing_ProgressChanged;

            columnWidth.ProgressChanged += ColumnWidth_ProgressChanged;

            cornerRadius.ProgressChanged += CornerRadius_ProgressChanged;

            propertylayout.AddView(columnWidthValue);
            propertylayout.AddView(columnWidth);
            propertylayout.AddView(spacingValue);
            propertylayout.AddView(spacing);
            propertylayout.AddView(cornerRadiusValue);
            propertylayout.AddView(cornerRadius);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);

            return propertylayout;
        }

        private void CornerRadius_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            double cornerRadious = 0;
            cornerRadious = (int)e.Progress;
            columnSeries1.CornerRadius = new ChartCornerRadius(cornerRadious, cornerRadious, 0, 0);
            columnSeries2.CornerRadius = new ChartCornerRadius(cornerRadious, cornerRadious, 0, 0);
            columnSeries3.CornerRadius = new ChartCornerRadius(cornerRadious, cornerRadious, 0, 0);
            cornerRadiusValue.Text = "Corner Radious : " + cornerRadious;

        }

        private void Spacing_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            float spacing = 0;
            spacing = (int)e.Progress;
            columnSeries1.Spacing = spacing / 10;
            columnSeries2.Spacing = spacing / 10;
            columnSeries3.Spacing = spacing / 10;
            spacingValue.Text = "Spacing : " + spacing / 10;
        }

        private void ColumnWidth_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            float columnWidth = 0;
            columnWidth = (int)e.Progress;
            columnSeries1.Width = columnWidth / 10;
            columnSeries2.Width = columnWidth / 10;
            columnSeries3.Width = columnWidth / 10;
            columnWidthValue.Text = "Width : " + columnWidth / 10;
        }
    }
}