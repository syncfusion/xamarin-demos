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

    public class Area : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Average Sales Comparison";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.Visibility = Visibility.Visible;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis categoryaxis = new NumericalAxis();
            categoryaxis.Minimum = 2000;
            categoryaxis.Maximum = 2005;
            categoryaxis.Interval = 1;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.Title.Text = "Year";
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 2;
            numericalaxis.Maximum = 5;
            numericalaxis.Interval = 1;
            numericalaxis.Title.Text = "Revenue in Millions";
            numericalaxis.LabelStyle.LabelFormat = "#'M '";
            chart.SecondaryAxis = numericalaxis;

            var areaSeries1 = new AreaSeries
            {
                Label = "Product A",
                Alpha = 0.5f,
				EnableAnimation= true,
				ItemsSource = MainPage.GetAreaData1(),
				XBindingPath = "XValue",
				YBindingPath = "YValue",
                LegendIcon = ChartLegendIcon.SeriesType
            };
            var areaSeries2 = new AreaSeries
            {
                Label = "Product B",
                Alpha = 0.5f,
				EnableAnimation = true,
				ItemsSource = MainPage.GetAreaData2(),
				XBindingPath = "XValue",
				YBindingPath = "YValue",
                LegendIcon = ChartLegendIcon.SeriesType
            };

            chart.Series.Add(areaSeries1);
            chart.Series.Add(areaSeries2);

            areaSeries1.TooltipEnabled = true;
            areaSeries2.TooltipEnabled = true;
            areaSeries1.EnableAnimation = true;
            areaSeries2.EnableAnimation = true;

            return chart;
        }
    }
}
