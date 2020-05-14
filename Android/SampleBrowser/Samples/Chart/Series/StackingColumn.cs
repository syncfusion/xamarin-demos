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
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;


namespace SampleBrowser
{
     [Activity(Label = "Stacked Columns")]
    public class StackingColumn : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "Mobile Game Market by Country";
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis PrimaryAxis = new CategoryAxis();
            PrimaryAxis.ShowMajorGridLines = false;
            PrimaryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = PrimaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Sales";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 500;
            numericalAxis.Interval = 100;
            numericalAxis.LineStyle.StrokeWidth = 0;
            numericalAxis.MajorTickStyle.TickSize = 0;
            numericalAxis.LabelStyle.LabelFormat = "#'B'";
            chart.SecondaryAxis = numericalAxis;

            StackingColumnSeries stackingColumnSeries = new StackingColumnSeries();
            stackingColumnSeries.EnableAnimation = true;
            stackingColumnSeries.Label = "UK";
            stackingColumnSeries.ItemsSource = MainPage.GetStackedColumnData1();
            stackingColumnSeries.XBindingPath = "XValue";
            stackingColumnSeries.YBindingPath = "YValue";
            stackingColumnSeries.LegendIcon = ChartLegendIcon.SeriesType;

            StackingColumnSeries stackingColumnSeries1 = new StackingColumnSeries();
            stackingColumnSeries1.EnableAnimation = true;
            stackingColumnSeries1.Label = "Germany";
            stackingColumnSeries1.ItemsSource = MainPage.GetStackedColumnData2();
            stackingColumnSeries1.XBindingPath = "XValue";
            stackingColumnSeries1.YBindingPath = "YValue";
            stackingColumnSeries1.LegendIcon = ChartLegendIcon.SeriesType;

            StackingColumnSeries stackingColumnSeries2 = new StackingColumnSeries();
            stackingColumnSeries2.EnableAnimation = true;
            stackingColumnSeries2.Label = "France";
            stackingColumnSeries2.ItemsSource = MainPage.GetStackedColumnData3();
            stackingColumnSeries2.XBindingPath = "XValue";
            stackingColumnSeries2.YBindingPath = "YValue";
            stackingColumnSeries2.LegendIcon = ChartLegendIcon.SeriesType;

            StackingColumnSeries stackingColumnSeries3 = new StackingColumnSeries();
            stackingColumnSeries3.EnableAnimation = true;
            stackingColumnSeries3.Label = "Italy";
            stackingColumnSeries3.ItemsSource = MainPage.GetStackedColumnData4();
            stackingColumnSeries3.XBindingPath = "XValue";
            stackingColumnSeries3.YBindingPath = "YValue";
            stackingColumnSeries3.LegendIcon = ChartLegendIcon.SeriesType;

            chart.Series.Add(stackingColumnSeries);
            chart.Series.Add(stackingColumnSeries1);
            chart.Series.Add(stackingColumnSeries2);
            chart.Series.Add(stackingColumnSeries3);

            stackingColumnSeries.TooltipEnabled = true;
            stackingColumnSeries1.TooltipEnabled = true;
            stackingColumnSeries2.TooltipEnabled = true;
            stackingColumnSeries3.TooltipEnabled = true;
			
            stackingColumnSeries.EnableAnimation = true;
            stackingColumnSeries1.EnableAnimation = true;
            stackingColumnSeries2.EnableAnimation = true;
            stackingColumnSeries3.EnableAnimation = true;

            return chart;
        }
    }
}