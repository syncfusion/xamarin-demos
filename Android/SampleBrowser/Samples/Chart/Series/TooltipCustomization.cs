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
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;

namespace SampleBrowser
{
    public class TooltipCustomization : SamplePage
    {
        CustomTooltipBehavior tooltipBehavior;

        public override View GetSampleContent(Context con)
        {

            SfChart sfChart = new SfChart(con);
            sfChart.Title.Text = "Wheat Production in Tons";
            sfChart.Title.TextSize = 15;
            sfChart.PrimaryAxis = new CategoryAxis()
            {
                PlotOffset = 10,
                MajorGridLineStyle = { StrokeWidth = 0.5f },
                Interval = 2,
                ShowMajorGridLines = false,
            };

            sfChart.SecondaryAxis = new NumericalAxis()
            {
                Maximum = 2.7f,
                Minimum = 1.5,
                Interval = 0.2,
                EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift,                    
                LineStyle =  { StrokeWidth = 0 },         
                MajorGridLineStyle = { StrokeWidth = 0.5f },
            };
			sfChart.SecondaryAxis.LabelStyle.LabelFormat = "##.##M";

            SplineSeries splineSeries = new SplineSeries()
            {
                Color = Color.Argb(255, 255, 150, 00),
                DataMarker =
                    {
                        ShowMarker = true,
                        ShowLabel = false,
                        MarkerColor = Color.Rgb(250, 0, 0)
                    },
                TooltipEnabled = true,
            };
            splineSeries.EnableAnimation = true;
            splineSeries.ItemsSource = MainPage.GetTooltipData();
            splineSeries.XBindingPath = "XValue";
            splineSeries.YBindingPath = "YValue";
            sfChart.Series.Add(splineSeries);

            tooltipBehavior = new CustomTooltipBehavior(con);
            tooltipBehavior.BackgroundColor = Color.Argb(255, 193, 39, 45);
            sfChart.Behaviors.Add(tooltipBehavior);

            sfChart.TooltipCreated += sfChart_TooltipCreated;

            return sfChart;
        }

        void sfChart_TooltipCreated(object sender, SfChart.TooltipCreatedEventArgs e)
        {
            tooltipBehavior.MarginLeft = 5;
            tooltipBehavior.MarginTop = 25;
            tooltipBehavior.MarginRight = 75;
            tooltipBehavior.MarginBottom = 20;
            tooltipBehavior.BackgroundColor = Color.Argb(255, 193, 39, 45);
            tooltipBehavior.TextColor = Color.Transparent;
            tooltipBehavior.StrokeWidth = 1f;
        }
    }
}
