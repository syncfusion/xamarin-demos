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
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class Polar : SamplePage
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

            PolarSeries polarSeries1 = new PolarSeries();
            polarSeries1.TooltipEnabled = true;
            polarSeries1.EnableAnimation = true;
            polarSeries1.Label = "Product A";
            polarSeries1.Closed = true;
            polarSeries1.DrawType = PolarChartDrawType.Area;
            polarSeries1.Alpha = 0.5f;
            polarSeries1.ItemsSource = MainPage.GetPolarData1();
			polarSeries1.XBindingPath = "XValue";
			polarSeries1.YBindingPath = "YValue";
            chart.Series.Add(polarSeries1);

            PolarSeries polarSeries2 = new PolarSeries();
            polarSeries2.TooltipEnabled = true;
            polarSeries2.EnableAnimation = true;
            polarSeries2.Label = "Product B";
            polarSeries2.Closed = true;
            polarSeries2.DrawType = PolarChartDrawType.Area;
            polarSeries2.Alpha = 0.5f;
			polarSeries2.ItemsSource = MainPage.GetPolarData2();
			polarSeries2.XBindingPath = "XValue";
			polarSeries2.YBindingPath = "YValue";
            chart.Series.Add(polarSeries2);

            PolarSeries polarSeries3 = new PolarSeries();
			polarSeries3.XBindingPath = "XValue";
			polarSeries3.YBindingPath = "YValue";
            polarSeries3.EnableAnimation = true;
            polarSeries3.TooltipEnabled = true;
            polarSeries3.Label = "Product C";
            polarSeries3.Closed = true;
            polarSeries3.DrawType = PolarChartDrawType.Area;
            polarSeries3.Alpha = 0.5f;
			polarSeries3.ItemsSource = MainPage.GetPolarData3();
            chart.Series.Add(polarSeries3);

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
            linearLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
                LinearLayout.LayoutParams.WrapContent);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.SetBackgroundColor(Android.Graphics.Color.White);

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