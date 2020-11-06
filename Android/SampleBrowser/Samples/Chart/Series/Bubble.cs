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


namespace SampleBrowser
{

    internal class Bubble : SamplePage
    {
        BubbleTooltipBehavior tooltipBehavior;
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "World Countries Details";
            chart.Title.TextSize = 15;

            NumericalAxis primaryAxis = new NumericalAxis();
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.Minimum = 60;
            primaryAxis.Maximum = 100;
            primaryAxis.Interval = 5;
            primaryAxis.Title.Text = "Literacy Rate";
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.ShowMinorGridLines = false;
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Minimum = 0;
            secondaryAxis.Maximum = 10;
            secondaryAxis.Interval = 2.5;
            secondaryAxis.Title.Text = "GDP Growth Rate";
            secondaryAxis.ShowMajorGridLines = false;
            secondaryAxis.ShowMinorGridLines = false;
            chart.SecondaryAxis = secondaryAxis;

            var bubble = new BubbleSeries();           
            bubble.MinimumRadius = 5;
            bubble.MaximumRadius = 40;
            bubble.Alpha = 0.7f;
            bubble.ColorModel.ColorPalette = ChartColorPalette.Natural;
			bubble.ItemsSource = MainPage.GetBubbleData();
			bubble.XBindingPath = "XValue";
			bubble.YBindingPath = "YValue";
            bubble.Size = "Size";
            bubble.EnableAnimation = true;
            chart.Series.Add(bubble);

            bubble.TooltipEnabled = true;

            tooltipBehavior = new BubbleTooltipBehavior(context);
            chart.Behaviors.Add(tooltipBehavior);

            chart.TooltipCreated += Chart_TooltipCreated;
            return chart;
        }

        private void Chart_TooltipCreated(object sender, SfChart.TooltipCreatedEventArgs e)
        {
            tooltipBehavior.MarginLeft = 80;
            tooltipBehavior.MarginTop = 30;
            tooltipBehavior.MarginRight = 50;
            tooltipBehavior.MarginBottom = 30;
            tooltipBehavior.BackgroundColor = Color.ParseColor("#404041");
            tooltipBehavior.TextColor = Color.Transparent;
            tooltipBehavior.StrokeWidth = 1f;
        }
    }

    class BubbleTooltipBehavior : ChartTooltipBehavior
    {
        Context context;

        public BubbleTooltipBehavior(Context con)
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
            label.Text = (p0.ChartDataPoint as DataPoint).Label.ToString();
            label.TextSize = 12;
            label.TextAlignment = Android.Views.TextAlignment.Center;
            label.SetPadding(150, 0, 0, 0);
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
            xLabel.Text = "Literacy Rate : ";
            xLabel.TextSize = 12;
            xLabel.SetTextColor(Color.ParseColor("#CCCCCC"));

            TextView xValue = new TextView(context);
            xValue.Text = (p0.ChartDataPoint as DataPoint).XValue + "%";
            xValue.TextSize = 12;
            xValue.SetTextColor(Color.White);

            xLayout.AddView(xLabel);
            xLayout.AddView(xValue);

            LinearLayout yLayout = new LinearLayout(context);
            yLayout.Orientation = Orientation.Horizontal;
            yLayout.SetPadding(0, 5, 0, 0);

            TextView yLabel = new TextView(context);
            yLabel.Text = "GDP Growth Rate : ";
            yLabel.TextSize = 12;
            yLabel.SetTextColor(Color.ParseColor("#CCCCCC"));

            TextView yValue = new TextView(context);
            yValue.Text = (p0.ChartDataPoint as DataPoint).YValue.ToString();
            yValue.TextSize = 12;
            yValue.SetTextColor(Color.White);

            yLayout.AddView(yLabel);
            yLayout.AddView(yValue);

            LinearLayout sizeLayout = new LinearLayout(context);
            sizeLayout.Orientation = Orientation.Horizontal;
            sizeLayout.SetPadding(0, 5, 0, 0);

            TextView sizeLabel = new TextView(context);
            sizeLabel.Text = "Population : ";
            sizeLabel.TextSize = 12;
            sizeLabel.SetTextColor(Color.ParseColor("#CCCCCC"));

            TextView sizeValue = new TextView(context);
            sizeValue.Text = (p0.ChartDataPoint as DataPoint).Size + " Billion";
            sizeValue.TextSize = 12;
            sizeValue.SetTextColor(Color.White);

            sizeLayout.AddView(sizeLabel);
            sizeLayout.AddView(sizeValue);

            rootLayout.AddView(label);
            rootLayout.AddView(line);
            rootLayout.AddView(xLayout);
            rootLayout.AddView(yLayout);
            rootLayout.AddView(sizeLayout);
            p0.AddView(rootLayout);

            return p0;
        }

    }
}