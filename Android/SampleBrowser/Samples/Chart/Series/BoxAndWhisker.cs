#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
using Android.Graphics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;


namespace SampleBrowser
{
    public class BoxAndWhisker : SamplePage
    {
        SfChart chart;
        BoxAndWhiskerSeries boxPlotSeries;
        TextView boxPlotMode;
        TextView showMedian;
        TextView symbol;
        List<string> boxPlotModeType;
        List<string> symbolType;
        Switch medianSwitch;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Employee Age Group in Various Department";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            CategoryAxis categoryAxis = new CategoryAxis();
            categoryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryAxis.ShowMajorGridLines = false;
            categoryAxis.Title.Text = "Department";
            chart.PrimaryAxis = categoryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Age";
            numericalAxis.Maximum = 60;
            numericalAxis.Minimum = 20;
            numericalAxis.Interval = 5;
            numericalAxis.ShowMinorGridLines = false;
            numericalAxis.LineStyle.StrokeWidth = 0;
            numericalAxis.MajorTickStyle.TickSize = 0;
            chart.SecondaryAxis = numericalAxis;

            boxPlotSeries = new BoxAndWhiskerSeries();
            boxPlotSeries.ItemsSource = MainPage.BoxAndWhiskerData();
            boxPlotSeries.XBindingPath = "Department";
            boxPlotSeries.YBindingPath = "EmployeeAges";
            boxPlotSeries.Width = 0.5;
            boxPlotSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
            boxPlotSeries.TooltipEnabled = true;
            boxPlotSeries.EnableAnimation = true;
            boxPlotSeries.ShowMedian = true;
        

            chart.Series.Add(boxPlotSeries);
            return chart;
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
               width * 2, 5);

            layoutParams1.SetMargins(0, 20, 0, 0);

            boxPlotMode = new TextView(context);
            boxPlotMode.Text = "Box Plot Mode";
            boxPlotMode.SetPadding(5, 20, 0, 20);

            showMedian = new TextView(context);
            showMedian.Text = "Show Median";
            showMedian.SetPadding(5, 20, 0, 20);

            symbol = new TextView(context);
            symbol.Text = "Symbol Type";
            symbol.SetPadding(5, 20, 0, 20);

            Spinner selectBoxPlotModeType = new Spinner(context, SpinnerMode.Dialog);
            boxPlotModeType = new List<string>() { "Exclusive", "Inclusive", "Normal" };

            Spinner selectSymbolType = new Spinner(context, SpinnerMode.Dialog);
            symbolType = new List<string>() { "Ellipse", "Diamond", "Cross", "Hexagon", "InvertedTriangle", "Pentagon", "Plus", "Rectangle", "Triangle" };

            ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>
                (context, Android.Resource.Layout.SimpleSpinnerItem, boxPlotModeType);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectBoxPlotModeType.Adapter = dataAdapter;

            selectBoxPlotModeType.ItemSelected += SelectBoxPlotModeType_ItemSelected;

            ArrayAdapter<string> dataAdapter1 = new ArrayAdapter<string>
               (context, Android.Resource.Layout.SimpleSpinnerItem, symbolType);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectSymbolType.Adapter = dataAdapter1;

            selectSymbolType.ItemSelected += SelectSymbolType_ItemSelected;

            medianSwitch = new Switch(context);
            medianSwitch.Checked = true;
            medianSwitch.CheckedChange += MedianSwitch_CheckedChange;

            propertylayout.AddView(boxPlotMode);
            propertylayout.AddView(selectBoxPlotModeType);
            propertylayout.AddView(symbol);
            propertylayout.AddView(selectSymbolType);
            propertylayout.AddView(showMedian);
            propertylayout.AddView(medianSwitch);

            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);

            return propertylayout;
        }

        private void MedianSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            boxPlotSeries.ShowMedian = e.IsChecked;
        }

        private void SelectSymbolType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    boxPlotSeries.SymbolType = ChartSymbolType.Ellipse;
                    break;
                case 1:
                    boxPlotSeries.SymbolType = ChartSymbolType.Diamond;
                    break;
                case 2:
                    boxPlotSeries.SymbolType = ChartSymbolType.Cross;
                    break;
                case 3:
                    boxPlotSeries.SymbolType = ChartSymbolType.Hexagon;
                    break;
                case 4:
                    boxPlotSeries.SymbolType = ChartSymbolType.InvertedTriangle;
                    break;
                case 5:
                    boxPlotSeries.SymbolType = ChartSymbolType.Pentagon;
                    break;
                case 6:
                    boxPlotSeries.SymbolType = ChartSymbolType.Plus;
                    break;
                case 7:
                    boxPlotSeries.SymbolType = ChartSymbolType.Rectangle;
                    break;
                case 8:
                    boxPlotSeries.SymbolType = ChartSymbolType.Triangle;
                    break;
            }
        }

        private void SelectBoxPlotModeType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    boxPlotSeries.BoxPlotMode = BoxPlotMode.Exclusive;
                    break;
                case 1:
                    boxPlotSeries.BoxPlotMode = BoxPlotMode.Inclusive;
                    break;
                case 2:
                    boxPlotSeries.BoxPlotMode = BoxPlotMode.Normal;
                    break;
            }
        }
    }
}