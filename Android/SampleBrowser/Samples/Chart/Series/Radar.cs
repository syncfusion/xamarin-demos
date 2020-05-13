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
using Com.Syncfusion.Navigationdrawer;

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
        RadarSeries radarSeries1;
        RadarSeries radarSeries2;
        RadarSeries radarSeries3;
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

            radarSeries1 = new RadarSeries();
            radarSeries1.TooltipEnabled = true;
            radarSeries1.EnableAnimation = true;
            radarSeries1.StrokeWidth = 3;
            radarSeries1.PathEffect = new DashPathEffect(new float[] { 4, 6 }, 0);
            radarSeries1.Label = "Product A";
            radarSeries1.Closed = true;
            radarSeries1.DrawType = PolarChartDrawType.Area;
            radarSeries1.Alpha = 0.5f;
            radarSeries1.ItemsSource = MainPage.GetPolarData1();
			radarSeries1.XBindingPath = "XValue";
			radarSeries1.YBindingPath = "YValue";
            chart.Series.Add(radarSeries1);

            radarSeries2 = new RadarSeries();
            radarSeries2.TooltipEnabled = true;
            radarSeries2.EnableAnimation = true;
            radarSeries2.StrokeWidth = 3;
            radarSeries2.PathEffect = new DashPathEffect(new float[] { 4, 6 }, 0);
            radarSeries2.Label = "Product B";
            radarSeries2.Closed = true;
            radarSeries2.DrawType = PolarChartDrawType.Area;
            radarSeries2.Alpha = 0.5f;
			radarSeries2.ItemsSource = MainPage.GetPolarData2();
			radarSeries2.XBindingPath = "XValue";
			radarSeries2.YBindingPath = "YValue";
            chart.Series.Add(radarSeries2);

            radarSeries3 = new RadarSeries();
            radarSeries3.TooltipEnabled = true;
            radarSeries3.EnableAnimation = true;
            radarSeries3.StrokeWidth = 3;
            radarSeries3.PathEffect = new DashPathEffect(new float[] { 4, 6 }, 0);
            radarSeries3.Label = "Product C";
            radarSeries3.Closed = true;
            radarSeries3.DrawType = PolarChartDrawType.Area;
            radarSeries3.Alpha = 0.5f;
			radarSeries3.ItemsSource = MainPage.GetPolarData3();
			radarSeries3.XBindingPath = "XValue";
			radarSeries3.YBindingPath = "YValue";
            chart.Series.Add(radarSeries3);

            return chart;
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

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            /**
            * Property Window
            * */
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context); //= new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 5);

            layoutParams1.SetMargins(0, 20, 0, 0);

            TextView drawType = new TextView(context);
            drawType.TextSize = 20;
            drawType.Text = "Draw Type";
            drawType.SetPadding(5, 20, 0, 20);

            TextView polarAngle = new TextView(context);
            polarAngle.TextSize = 20;
            polarAngle.Text = "Angle";
            polarAngle.SetPadding(5, 20, 0, 20);

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            polarAngleMode = new List<String>() { "Rotate 0", "Rotate 90", "Rotate 180", "Rotate 270" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
               (context, Android.Resource.Layout.SimpleSpinnerItem, polarAngleMode);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;

            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            Spinner selectDrawType = new Spinner(context, SpinnerMode.Dialog);

            List<String> adapter = new List<String>() { "Area", "Line" };
            ArrayAdapter<String> dataAdapter1 = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectDrawType.Adapter = dataAdapter1;

            selectDrawType.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter1.GetItem(e.Position);

                if (selectedItem.Equals("Area"))
                {
                    radarSeries1.DrawType = PolarChartDrawType.Area;
                    radarSeries2.DrawType = PolarChartDrawType.Area;
                    radarSeries3.DrawType = PolarChartDrawType.Area;
                }
                else if (selectedItem.Equals("Line"))
                {
                    radarSeries1.DrawType = PolarChartDrawType.Line;
                    radarSeries2.DrawType = PolarChartDrawType.Line;
                    radarSeries3.DrawType = PolarChartDrawType.Line;
                }
            };

            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);

            propertylayout.AddView(drawType);
            propertylayout.AddView(selectDrawType);
            propertylayout.AddView(polarAngle);
            propertylayout.AddView(selectLabelMode);
            propertylayout.AddView(separate, layoutParams1);
          

            return propertylayout;
        }
    }
}