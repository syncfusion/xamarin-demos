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
using Com.Syncfusion.Navigationdrawer;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class Pie : SamplePage
    {
        PieSeries pieSeries;
        TextView groupToValue;
        TextView groupMode;
        List<string> groupModeType;

        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "Sales by Sales Person";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Android.Graphics.Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
			chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;

            pieSeries = new PieSeries();
            pieSeries.TooltipEnabled = true;
			pieSeries.GroupTo = 25;
            pieSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
			pieSeries.ItemsSource = MainPage.GetPieData();
			pieSeries.XBindingPath = "XValue";
			pieSeries.YBindingPath = "YValue";
            pieSeries.DataMarker.ShowLabel = true;
			pieSeries.DataMarker.LabelStyle.LabelFormat = "#.#'%'";
            pieSeries.EnableAnimation = true;
            pieSeries.CircularCoefficient = 0.7;
            pieSeries.StrokeWidth = 1;
            pieSeries.StrokeColor = Android.Graphics.Color.White;
            chart.Series.Add(pieSeries);
            return chart;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 2);

            groupToValue = new TextView(context);
            groupToValue.Text = "GroupTo Value is 25";
            groupToValue.SetPadding(5, 20, 0, 20);

            SeekBar groupTo = new SeekBar(context);
            groupTo.Progress = 25;
            groupTo.Max = 40;
            groupTo.ProgressChanged += GroupTo_ProgressChanged;
            groupMode = new TextView(context);
            groupMode.Text = "GroupMode";

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            groupModeType = new List<string>() { "Value", "Percentage", "Angle" };

            ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>
                (context, Android.Resource.Layout.SimpleSpinnerItem, groupModeType);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;

            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            propertylayout.AddView(groupToValue);
            propertylayout.AddView(groupTo);
            propertylayout.AddView(groupMode);
            propertylayout.AddView(selectLabelMode);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);

            return propertylayout;
        }

        void GroupTo_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            groupToValue.Text = "groupToValue is " + ((int)e.Progress).ToString();
            pieSeries.GroupTo = (int)e.Progress;
        }

        void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    pieSeries.GroupMode = PieGroupMode.Value;
                    break;
                case 1:
                    pieSeries.GroupMode = PieGroupMode.Percentage;
                    break;
                case 2:
                    pieSeries.GroupMode = PieGroupMode.Angle;
                    break;
            }
        }
    }
}