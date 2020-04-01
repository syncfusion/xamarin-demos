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
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    internal class Scatter : SamplePage
    {
        List<string> scatterSeriesType;
        ScatterSeries scatter;
        ScatterTooltipBehavior tooltipBehavior;

        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "Height vs Weight";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis primariyAxis = new NumericalAxis();
            primariyAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primariyAxis.ShowMajorGridLines = false;
            primariyAxis.Minimum = 100;
            primariyAxis.Maximum = 220;
            primariyAxis.Interval = 20;
            primariyAxis.Title.Text = "Height in Inches";
            chart.PrimaryAxis = primariyAxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.ShowMajorGridLines = false;
            secondaryAxis.Minimum = 50;
            secondaryAxis.Maximum = 80;
            secondaryAxis.Interval = 5;
            secondaryAxis.Title.Text = "Weight in Pounds";
            chart.SecondaryAxis = secondaryAxis;

            scatter = new ScatterSeries();           
            scatter.Alpha = 0.7f;
            scatter.ScatterWidth = 12;
            scatter.ScatterHeight = 12;
			scatter.ItemsSource = MainPage.GetScatterMaleData();
			scatter.XBindingPath = "XValue";
			scatter.YBindingPath = "YValue";
            scatter.Label = "Male";
            scatter.LegendIcon = ChartLegendIcon.SeriesType;
            scatter.TooltipEnabled = true;
            scatter.EnableAnimation = true;

            ScatterSeries scatter1 = new ScatterSeries();
            scatter1.Alpha = 0.7f;
            scatter1.ScatterWidth = 12;
            scatter1.ScatterHeight = 12;
			scatter1.ShapeType = ChartScatterShapeType.Diamond;
            scatter1.ItemsSource = MainPage.GetScatterFemaleData();
            scatter1.XBindingPath = "XValue";
            scatter1.YBindingPath = "YValue";
            scatter1.Label = "Female";
            scatter1.LegendIcon = ChartLegendIcon.SeriesType;
            scatter1.EnableAnimation = true;
            scatter1.TooltipEnabled = true;

            chart.Series.Add(scatter);
            chart.Series.Add(scatter1);

            tooltipBehavior = new ScatterTooltipBehavior(context);
            chart.Behaviors.Add(tooltipBehavior);

            chart.TooltipCreated += Chart_TooltipCreated;
            return chart;
        }

        private void Chart_TooltipCreated(object sender, SfChart.TooltipCreatedEventArgs e)
        {
            tooltipBehavior.MarginLeft = 30;
            tooltipBehavior.MarginTop = 20;
            tooltipBehavior.MarginRight = 50;
            tooltipBehavior.MarginBottom = 20;
            tooltipBehavior.BackgroundColor = Color.ParseColor("#404041");
            tooltipBehavior.TextColor = Color.Transparent;
            tooltipBehavior.StrokeWidth = 1f;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context);

            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 05);
            layoutParams1.SetMargins(0, 20, 0, 0);

            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            scatterSeriesType = new List<String>() { "Ellipse", "Cross", "Diamond", "Hexagon", "Triangle", "InvertedTriangle", "Plus", "Pentagon", "Rectangle" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, scatterSeriesType);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;

            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            propertylayout.AddView(selectLabelMode);
            return propertylayout;
        }

        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
					scatter.ShapeType = ChartScatterShapeType.Ellipse;
                    break;
                case 1:
					scatter.ShapeType = ChartScatterShapeType.Cross;
                    break;
                case 2:
					scatter.ShapeType = ChartScatterShapeType.Diamond;
                    break;
                case 3:
					scatter.ShapeType = ChartScatterShapeType.Hexagon;
                    break;
                case 4:
					scatter.ShapeType = ChartScatterShapeType.Triangle;
                    break;
                case 5:
					scatter.ShapeType = ChartScatterShapeType.InvertedTriangle;
                    break;
                case 6:
					scatter.ShapeType = ChartScatterShapeType.Plus;
                    break;
                case 7:
					scatter.ShapeType = ChartScatterShapeType.Pentagon;
                    break;
                case 8:
					scatter.ShapeType = ChartScatterShapeType.Rectangle;
                    break;
            }
        }
    }

    class ScatterTooltipBehavior : ChartTooltipBehavior
    {
        Context context;

        public ScatterTooltipBehavior(Context con)
        {
            context = con;
        }

        protected override View GetView(TooltipView p0)
        {
            LinearLayout rootLayout = new LinearLayout(context);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                    LinearLayout.LayoutParams.MatchParent);
            rootLayout.Orientation = Orientation.Vertical;
            rootLayout.LayoutParameters = layoutParams;
            rootLayout.SetPadding(10, 5, 5, 5);
            rootLayout.SetBackgroundColor(Color.ParseColor("#404041"));

            TextView label = new TextView(context);
            label.Text = p0.Series.Label;
            label.TextSize = 12;
            label.TextAlignment = Android.Views.TextAlignment.Center;
            label.SetPadding(80, 0, 0, 0);
            label.SetTextColor(Color.White);

            LinearLayout line = new LinearLayout(context);
            LinearLayout.LayoutParams linelayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                    4);
            line.LayoutParameters = linelayoutParams;
            line.SetBackgroundColor(Color.White);

            LinearLayout xLayout = new LinearLayout(context);
            xLayout.Orientation = Orientation.Horizontal;
            xLayout.SetPadding(0, 5, 0, 0);

            TextView xLabel = new TextView(context);
            xLabel.Text = "Height : ";
            xLabel.TextSize = 12;
            xLabel.SetTextColor(Color.ParseColor("#CCCCCC"));

            TextView xValue = new TextView(context);
			xValue.Text = (p0.ChartDataPoint as DataPoint).XValue.ToString();
            xValue.TextSize = 12;
            xValue.SetTextColor(Color.White);

            xLayout.AddView(xLabel);
            xLayout.AddView(xValue);

            LinearLayout yLayout = new LinearLayout(context);
            yLayout.Orientation = Orientation.Horizontal;
            yLayout.SetPadding(0, 5, 0, 0);

            TextView yLabel = new TextView(context);
			yLabel.Text = "Weight : ";
            yLabel.TextSize = 12;
            yLabel.SetTextColor(Color.ParseColor("#CCCCCC"));

            TextView yValue = new TextView(context);
			yValue.Text = (p0.ChartDataPoint as DataPoint).YValue + " lbs";
            yValue.TextSize = 12;
            yValue.SetTextColor(Color.White);

            yLayout.AddView(yLabel);
            yLayout.AddView(yValue);

            rootLayout.AddView(label);
            rootLayout.AddView(line);
			rootLayout.AddView(yLayout);
            rootLayout.AddView(xLayout);            
            p0.AddView(rootLayout);

            return p0;
        }

    }
}