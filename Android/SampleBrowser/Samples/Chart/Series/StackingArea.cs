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
using Android.Graphics;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Views;

namespace SampleBrowser
{
   public class StackingArea : SamplePage
    {
        private SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Trend in Sales of Ethical Produce";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Interval = 2;
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.ShowMajorGridLines = false;
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 7;
            numericalAxis.Interval = 1;
            numericalAxis.Title.Text = "Spends";
            numericalAxis.LineStyle.StrokeWidth = 0;
            numericalAxis.MajorTickStyle.TickSize = 0;
            numericalAxis.LabelStyle.LabelFormat = "##.##B ";
            chart.SecondaryAxis = numericalAxis;

            StackingAreaSeries stackingAreaSeries = new StackingAreaSeries();
            stackingAreaSeries.EnableAnimation = true;
            stackingAreaSeries.ItemsSource = MainPage.GetStackedAreaData1();
            stackingAreaSeries.XBindingPath = "XValue";
            stackingAreaSeries.YBindingPath = "YValue";
            stackingAreaSeries.Label = "Organic";
            stackingAreaSeries.LegendIcon = ChartLegendIcon.SeriesType;
            chart.Series.Add(stackingAreaSeries);

            StackingAreaSeries stackingAreaSeries1 = new StackingAreaSeries();
            stackingAreaSeries1.EnableAnimation = true;
            stackingAreaSeries1.ItemsSource = MainPage.GetStackedAreaData2();
            stackingAreaSeries1.XBindingPath = "XValue";
            stackingAreaSeries1.YBindingPath = "YValue";
            stackingAreaSeries1.Label = "Fair-trade";
            stackingAreaSeries1.LegendIcon = ChartLegendIcon.SeriesType;
            chart.Series.Add(stackingAreaSeries1);

            StackingAreaSeries stackingAreaSeries2 = new StackingAreaSeries();
            stackingAreaSeries2.EnableAnimation = true;
            stackingAreaSeries2.ItemsSource = MainPage.GetStackedAreaData3();
            stackingAreaSeries2.XBindingPath = "XValue";
            stackingAreaSeries2.YBindingPath = "YValue";
            stackingAreaSeries2.Label = "Veg Alternatives";
            stackingAreaSeries2.LegendIcon = ChartLegendIcon.SeriesType;
            chart.Series.Add(stackingAreaSeries2);

            StackingAreaSeries stackingAreaSeries3 = new StackingAreaSeries();
            stackingAreaSeries3.EnableAnimation = true;
            stackingAreaSeries3.ItemsSource = MainPage.GetStackedAreaData4();
            stackingAreaSeries3.XBindingPath = "XValue";
            stackingAreaSeries3.YBindingPath = "YValue";
            stackingAreaSeries3.Label = "Others";
            stackingAreaSeries3.LegendIcon = ChartLegendIcon.SeriesType;
            chart.Series.Add(stackingAreaSeries3);

            stackingAreaSeries.TooltipEnabled = true;
            stackingAreaSeries1.TooltipEnabled = true;
            stackingAreaSeries2.TooltipEnabled = true;
            stackingAreaSeries3.TooltipEnabled = true;

            stackingAreaSeries.EnableAnimation = true;
            stackingAreaSeries1.EnableAnimation = true;
            stackingAreaSeries2.EnableAnimation = true;
            stackingAreaSeries3.EnableAnimation = true;

            return chart;
        }
    }
}