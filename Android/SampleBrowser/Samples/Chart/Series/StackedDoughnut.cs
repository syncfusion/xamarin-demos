#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Java.Lang;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class StackedDoughnut : SamplePage
    {
        void Chart_LegendItemCreated(object sender, ChartLegendItemCreatedEventArgs e)
        {
			MultipleCircleModel datamodel = e.LegendItem.DataPoint as MultipleCircleModel;

            LinearLayout outerLayout = new LinearLayout(chart.Context);
            outerLayout.Orientation = Orientation.Horizontal;
            outerLayout.SetBackgroundColor(Color.Transparent);

            LinearLayout innerLayout = new LinearLayout(chart.Context);
            innerLayout.Orientation = Orientation.Vertical;
            innerLayout.SetPadding(3, 30, 3, 0);
            innerLayout.SetBackgroundColor(Color.Transparent);

            TextView loanName = new TextView(chart.Context);
            TextView loanPercent = new TextView(chart.Context);

            ImageView centerView = new ImageView(chart.Context);
            centerView.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams((int)(40 * density), (int)(40 * density)));
			centerView.SetImageResource(datamodel.ImageResId);

            loanPercent.Text = (e.LegendItem.DataPoint as MultipleCircleModel).YValue + "%";
            loanPercent.TextAlignment = Android.Views.TextAlignment.Center;
            loanPercent.Gravity = GravityFlags.Center;
            loanPercent.SetTextColor(e.LegendItem.IconColor);
            loanPercent.TextSize = 15;

            loanName.Text = (e.LegendItem.DataPoint as MultipleCircleModel).XValue;
            loanName.TextAlignment = Android.Views.TextAlignment.Center;
            loanName.Gravity = GravityFlags.Center;
            loanName.SetTextColor(Color.Black);
            innerLayout.AddView(loanPercent);
            innerLayout.AddView(loanName);

            SfChart sfChart = new SfChart(chart.Context);
            sfChart.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams((int)(65 * density), (int)(65 * density)));
            sfChart.SetBackgroundColor(Color.White);

            DoughnutSeries series = new DoughnutSeries();
            series.Color = e.LegendItem.IconColor;
			series.ItemsSource = new ObservableCollection<MultipleCircleModel>() { datamodel };
            series.XBindingPath = "XValue";
            series.YBindingPath = "YValue";
            series.StartAngle = -90;
            series.EndAngle = 270;
            series.MaximumValue = 100;
            series.Spacing = 0.4;
            series.DoughnutCoefficient = 0.6;
            series.CircularCoefficient = 0.9;
            series.CapStyle = DoughnutCapStyle.BothCurve;
            series.IsStackedDoughnut = true;
            series.CenterView = centerView;
            sfChart.Series.Add(series);

            outerLayout.AddView(sfChart);
            outerLayout.AddView(innerLayout);
            e.LegendItem.View = outerLayout;
        }

        List<Color> colors;
        SfChart chart;
        float density;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Percentage of Loan Closure";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
            chart.LegendItemCreated += Chart_LegendItemCreated;
            density = context.Resources.DisplayMetrics.Density;

            colors = new List<Color>();
            colors.Add(Color.ParseColor("#47ba9f"));
            colors.Add(Color.ParseColor("#e58870"));
            colors.Add(Color.ParseColor("#9686c9"));
            colors.Add(Color.ParseColor("#e56590"));

            ImageView image = new ImageView(chart.Context);
            image.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams((int)(100 * density), (int)(100 * density)));
            image.SetImageResource(Resource.Drawable.Person);

            DoughnutSeries doughnutSeries = new DoughnutSeries();
            doughnutSeries.ColorModel.ColorPalette = ChartColorPalette.Custom;
            doughnutSeries.ColorModel.CustomColors = colors;
            doughnutSeries.ItemsSource = MainPage.GetStackedDoughnutData();
            doughnutSeries.XBindingPath = "XValue";
            doughnutSeries.YBindingPath = "YValue";
            doughnutSeries.StartAngle = -90;
            doughnutSeries.EndAngle = 270;
            doughnutSeries.MaximumValue = 100;
            doughnutSeries.Spacing = 0.4;
            doughnutSeries.DoughnutCoefficient = 0.6;
            doughnutSeries.CircularCoefficient = 0.9;
            doughnutSeries.IsStackedDoughnut = true;
            doughnutSeries.CapStyle = DoughnutCapStyle.BothCurve;
            doughnutSeries.CenterView = image;
            chart.Series.Add(doughnutSeries);

            return chart;
        }
    }

    public class MultipleCircleModel
    {
        public string XValue
        {
            get;
            set;
        }

        public double YValue
        {
            get;
            set;
        }

		public int ImageResId
        {
            get;
            set;
        }

        public MultipleCircleModel(string xValue, double yValue, int image)
        {
            XValue = xValue;
            YValue = yValue;
			ImageResId = image;
        }
    }
}
