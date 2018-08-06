#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
    public class Radar : SamplePage
    {
        SfChart chart;
        List<String> polarAngleMode;
        NumericalAxis secondaryAxis;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);

            chart.Title.Text = "Average Sales Comparison";
            chart.Title.TextSize = 15;
            chart.Legend.Visibility = Visibility.Visible;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
			chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            chart.PrimaryAxis = new CategoryAxis();
            secondaryAxis = new NumericalAxis();
            secondaryAxis.LabelStyle.LabelFormat = "#'M'";
            chart.SecondaryAxis = secondaryAxis;

            RadarSeries radarSeries1 = new RadarSeries();
            radarSeries1.TooltipEnabled = true;
            radarSeries1.EnableAnimation = true;
            radarSeries1.Label = "Product A";
            radarSeries1.Closed = true;
            radarSeries1.DrawType = PolarChartDrawType.Area;
            radarSeries1.Alpha = 0.5f;
            radarSeries1.ItemsSource = MainPage.GetPolarData1();
			radarSeries1.XBindingPath = "XValue";
			radarSeries1.YBindingPath = "YValue";
            chart.Series.Add(radarSeries1);

            RadarSeries radarSeries2 = new RadarSeries();
            radarSeries2.TooltipEnabled = true;
            radarSeries2.EnableAnimation = true;
            radarSeries2.Label = "Product B";
            radarSeries2.Closed = true;
            radarSeries2.DrawType = PolarChartDrawType.Area;
            radarSeries2.Alpha = 0.5f;
			radarSeries2.ItemsSource = MainPage.GetPolarData2();
			radarSeries2.XBindingPath = "XValue";
			radarSeries2.YBindingPath = "YValue";
            chart.Series.Add(radarSeries2);

            RadarSeries radarSeries3 = new RadarSeries();
            radarSeries3.TooltipEnabled = true;
            radarSeries3.EnableAnimation = true;            
            radarSeries3.Label = "Product C";
            radarSeries3.Closed = true;
            radarSeries3.DrawType = PolarChartDrawType.Area;
            radarSeries3.Alpha = 0.5f;
			radarSeries3.ItemsSource = MainPage.GetPolarData3();
			radarSeries3.XBindingPath = "XValue";
			radarSeries3.YBindingPath = "YValue";
            chart.Series.Add(radarSeries3);

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            polarAngleMode = new List<String>() { "Rotate 0", "Rotate 90", "Rotate 180", "Rotate 270" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
               (context, Android.Resource.Layout.SimpleSpinnerItem, polarAngleMode);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;

            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.SetPadding(20, 0, 20, 30);
            linearLayout.SetBackgroundColor(Color.Rgb(236, 235, 242));
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.SetBackgroundColor(Color.White);
            linearLayout.AddView(selectLabelMode);
            linearLayout.AddView(chart);

            return linearLayout;
        }
        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = polarAngleMode[e.Position];
            if (selectedItem.Equals("Rotate 0"))
            {
                secondaryAxis.PolarAngle = ChartPolarAngle.Rotate0;
            }
            else if (selectedItem.Equals("Rotate 90"))
            {
                secondaryAxis.PolarAngle = ChartPolarAngle.Rotate90;
            }
            else if (selectedItem.Equals("Rotate 180"))
            {
                secondaryAxis.PolarAngle = ChartPolarAngle.Rotate180;
            }
            else if (selectedItem.Equals("Rotate 270"))
            {
                secondaryAxis.PolarAngle = ChartPolarAngle.Rotate270;
            }
        }
    }
}