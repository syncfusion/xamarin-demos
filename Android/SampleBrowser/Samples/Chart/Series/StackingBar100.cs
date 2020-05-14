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
    [Activity(Label = "100% Stacked Bars")]
    public class StackingBar100 : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Sales Comparison";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis categoryAxis = new CategoryAxis();
            categoryAxis.ShowMajorGridLines = false;
            categoryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = categoryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 20;
            numericalAxis.LineStyle.StrokeWidth = 0;
            numericalAxis.MajorTickStyle.TickSize = 0;
            numericalAxis.LabelStyle.LabelFormat = "#'%'";
            chart.SecondaryAxis = numericalAxis;

            StackingBar100Series stackingBar100Series = new StackingBar100Series();
            stackingBar100Series.EnableAnimation = true;
            stackingBar100Series.Label = "Apple";
            stackingBar100Series.ItemsSource = MainPage.GetStackedBar100Data1();
            stackingBar100Series.XBindingPath = "XValue";
            stackingBar100Series.YBindingPath = "YValue";

            StackingBar100Series stackingBar100Series1 = new StackingBar100Series();
            stackingBar100Series1.EnableAnimation = true;
            stackingBar100Series1.Label = "Orange";
            stackingBar100Series1.ItemsSource = MainPage.GetStackedBar100Data2();
            stackingBar100Series1.XBindingPath = "XValue";
            stackingBar100Series1.YBindingPath = "YValue";

            StackingBar100Series stackingBar100Series2 = new StackingBar100Series();
            stackingBar100Series2.EnableAnimation = true;
            stackingBar100Series2.Label = "Wastage";
            stackingBar100Series2.ItemsSource = MainPage.GetStackedBar100Data3();
            stackingBar100Series2.XBindingPath = "XValue";
            stackingBar100Series2.YBindingPath = "YValue";

            chart.Series.Add(stackingBar100Series);
            chart.Series.Add(stackingBar100Series1);
            chart.Series.Add(stackingBar100Series2);

            stackingBar100Series.TooltipEnabled = true;
            stackingBar100Series1.TooltipEnabled = true;
            stackingBar100Series2.TooltipEnabled = true;

            stackingBar100Series.EnableAnimation = true;
            stackingBar100Series1.EnableAnimation = true;
            stackingBar100Series2.EnableAnimation = true;
            return chart;
        }
    }
}