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

namespace SampleBrowser
{
    public class ZoomingandPanning : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "Height vs Weight";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis primaryAxis = new NumericalAxis();
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Minimum = 100;
            primaryAxis.Maximum = 220;
            primaryAxis.Interval = 20;
            primaryAxis.Title.Text = "Height in Inches";
            primaryAxis.ShowTrackballInfo = true;
            primaryAxis.TrackballLabelStyle.LabelFormat = "##.##";
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.ShowMajorGridLines = false;
            secondaryAxis.Minimum = 50;
            secondaryAxis.Maximum = 80;
            secondaryAxis.Interval = 5;
            secondaryAxis.Title.Text = "Weight in Pounds";
            secondaryAxis.ShowTrackballInfo = true;
            secondaryAxis.TrackballLabelStyle.LabelFormat = "##.##";
            chart.SecondaryAxis = secondaryAxis;

            ScatterSeries scatter = new ScatterSeries();
            scatter.Alpha = 0.7f;
            scatter.ScatterWidth = 12;
            scatter.ScatterHeight = 12;
            scatter.ItemsSource = MainPage.GetScatterMaleData();
            scatter.XBindingPath = "XValue";
            scatter.YBindingPath = "YValue";
            scatter.Label = "Male";
            scatter.LegendIcon = ChartLegendIcon.SeriesType;
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

            chart.Series.Add(scatter);
            chart.Series.Add(scatter1);

            chart.Behaviors.Add(new ChartZoomPanBehavior { SelectionZoomingEnabled = true, SelectionRectStrokeWidth = 1 });

            var label = new TextView(context);
            label.SetPadding(5, 5, 5, 5);
            label.Text = "Pinch to zoom or double tap and drag to select a region to zoom in.";

            var layout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };

            var layoutLabel = new LinearLayout(context)
            {
                Orientation = Android.Widget.Orientation.Horizontal,
                LayoutParameters =
                    new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            layoutLabel.SetHorizontalGravity(GravityFlags.CenterHorizontal);
            layoutLabel.AddView(label);

            layout.AddView(layoutLabel);
            layout.AddView(chart);

            return layout;
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }
    }
}