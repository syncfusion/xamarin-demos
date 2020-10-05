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


namespace SampleBrowser
{
    public class ErrorBar : SamplePage
    {
        SfChart chart;
        ErrorBarSeries errorBar;
        TextView type;
        List<string> types;
        TextView mode;
        List<string> modes;
        TextView horizontalDirection;
        List<string> horizonatalDirections;
        TextView verticalDirection;
        List<string> verticalDirections;
        TextView horizontalValue;
        TextView verticalValue;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Sales Distribution of Car by Region";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            CategoryAxis primaryaxis = new CategoryAxis();
            primaryaxis.ShowMajorGridLines = false;
            primaryaxis.AxisLineOffset = 10;
            primaryaxis.PlotOffset = 10;
            primaryaxis.MajorTickStyle.TickSize = 10;
            primaryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = primaryaxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Minimum = 15;
            secondaryAxis.Maximum = 45;
            secondaryAxis.Interval = 5;
            secondaryAxis.LabelStyle.LabelFormat = "#'%'";
            secondaryAxis.LineStyle.StrokeWidth = 0;
            secondaryAxis.MajorTickStyle.TickSize = 0;
            chart.SecondaryAxis = secondaryAxis;

            ScatterSeries scatterSeries = new ScatterSeries();
            scatterSeries.ItemsSource = MainPage.GetErrorBarData();
            scatterSeries.XBindingPath = "XValue";
            scatterSeries.YBindingPath = "YValue";
            scatterSeries.ScatterHeight = 20;
            scatterSeries.ScatterWidth = 20;
            scatterSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
            scatterSeries.ShapeType = ChartScatterShapeType.Ellipse;
            chart.Series.Add(scatterSeries);

            errorBar = new ErrorBarSeries();
            errorBar.ItemsSource = MainPage.GetErrorBarData();
            errorBar.XBindingPath = "XVAlue";
            errorBar.YBindingPath = "YValue";
            errorBar.HorizontalErrorPath = "High";
            errorBar.VerticalErrorPath = "Low";
            errorBar.HorizontalErrorValue = 3;
            errorBar.VerticalErrorValue = 3;
            errorBar.Type = ErrorBarType.Fixed;
            errorBar.Mode = ErrorBarMode.Vertical;
            chart.Series.Add(errorBar);
            return chart;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;
            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 5);
            layoutParams1.SetMargins(0, 20, 0, 0);
            type = new TextView(context);
            type.Text = "Error Bar Type";
            type.SetPadding(5, 20, 0, 20);
            mode = new TextView(context);
            mode.Text = "Drawing Mode";
            mode.SetPadding(5, 30, 0, 20);
            horizontalDirection = new TextView(context);
            horizontalDirection.Text = "Horizontal Direction";
            horizontalDirection.SetPadding(5, 30, 0, 20);
            verticalDirection = new TextView(context);
            verticalDirection.Text = "Vertical Direction";
            verticalDirection.SetPadding(5, 30, 0, 20);
            horizontalValue = new TextView(context);
            horizontalValue.Text = "Horizontal Error : 3.0";
            horizontalValue.SetPadding(5, 30, 0, 20);
            verticalValue = new TextView(context);
            verticalValue.Text = "Vertical Error : 3.0";
            verticalValue.SetPadding(5, 20, 0, 20);

            Spinner errorBarType = new Spinner(context, SpinnerMode.Dialog);
            Spinner errorBarDrawingMode = new Spinner(context, SpinnerMode.Dialog);
            errorBarDrawingMode.SetSelection(2);
            SeekBar errorBarHorizontalError = new SeekBar(context);
            errorBarHorizontalError.Max = 3;
            errorBarHorizontalError.Progress = 3;

            SeekBar errorBarVerticalError = new SeekBar(context);
            errorBarVerticalError.Max = 3;
            errorBarVerticalError.Progress = 3;
            Spinner errorBarHorizontalDirection = new Spinner(context, SpinnerMode.Dialog);
            Spinner errorBarVerticalDirection = new Spinner(context, SpinnerMode.Dialog);

            types = new List<string>() { "Fixed", "Custom", "percentage", "StandardDeviation", "StandardErrors" };
            modes = new List<string>() { "Both", "Horizontal", "Vertical" };
            horizonatalDirections = new List<string> { "Both", "Minus", "Plus" };
            verticalDirections = new List<string> { "Both", "Minus", "Plus" };

            ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>
                 (context, Android.Resource.Layout.SimpleSpinnerItem, types);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            errorBarType.Adapter = dataAdapter;

            ArrayAdapter<string> dataAdapter1 = new ArrayAdapter<string>
                 (context, Android.Resource.Layout.SimpleSpinnerItem, modes);
            dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            errorBarDrawingMode.Adapter = dataAdapter1;

            ArrayAdapter<string> dataAdapter2 = new ArrayAdapter<string>
                 (context, Android.Resource.Layout.SimpleSpinnerItem, horizonatalDirections);
            dataAdapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            errorBarHorizontalDirection.Adapter = dataAdapter2;

            ArrayAdapter<string> dataAdapter3 = new ArrayAdapter<string>
                 (context, Android.Resource.Layout.SimpleSpinnerItem, verticalDirections);
            dataAdapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            errorBarVerticalDirection.Adapter = dataAdapter3;

            errorBarType.ItemSelected += Type_ItemSelected;
            errorBarDrawingMode.ItemSelected += Mode_ItemSelected;
            errorBarHorizontalError.ProgressChanged += HorizontalError_ProgressChanged;
            errorBarVerticalError.ProgressChanged += VerticalError_ProgressChanged;
            errorBarHorizontalDirection.ItemSelected += HorizontalDirection_ItemSelected;
            errorBarVerticalDirection.ItemSelected += VerticalDirection_ItemSelected;

            propertylayout.AddView(type);
            propertylayout.AddView(errorBarType);
            propertylayout.AddView(mode);
            propertylayout.AddView(errorBarDrawingMode);
            propertylayout.AddView(horizontalValue);
            propertylayout.AddView(errorBarHorizontalError);
            propertylayout.AddView(verticalValue);
            propertylayout.AddView(errorBarVerticalError);
            propertylayout.AddView(horizontalDirection);
            propertylayout.AddView(errorBarHorizontalDirection);
            propertylayout.AddView(verticalDirection);
            propertylayout.AddView(errorBarVerticalDirection);

            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);

            return propertylayout;

        }

        private void VerticalError_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            double verticalError = 0.0;
            verticalError = (int)e.Progress;
            errorBar.VerticalErrorValue = verticalError;
            verticalValue.Text = "Vertical Error : " + verticalError;
        }

        private void HorizontalError_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            double horizontalError = 0.0;
            horizontalError = (int)e.Progress;
            errorBar.HorizontalErrorValue = horizontalError;
            horizontalValue.Text = "Horizontal Error : " + horizontalError;
        }

        private void VerticalDirection_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    errorBar.VerticalDirection = ErrorBarDirection.Both;
                    break;
                case 1:
                    errorBar.VerticalDirection = ErrorBarDirection.Minus;
                    break;
                case 2:
                    errorBar.VerticalDirection = ErrorBarDirection.Plus;
                    break;
            }
        }

        private void HorizontalDirection_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    errorBar.HorizontalDirection = ErrorBarDirection.Both;
                    break;
                case 1:
                    errorBar.HorizontalDirection = ErrorBarDirection.Minus;
                    break;
                case 2:
                    errorBar.HorizontalDirection = ErrorBarDirection.Plus;
                    break;
            }
        }

        private void Mode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    errorBar.Mode = ErrorBarMode.Both;
                    break;
                case 1:
                    errorBar.Mode = ErrorBarMode.Horizontal;
                    break;
                case 2:
                    errorBar.Mode = ErrorBarMode.Vertical;
                    break;
            }
        }

        private void Type_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    errorBar.Type = ErrorBarType.Fixed;
                    break;
                case 1:
                    errorBar.Type = ErrorBarType.Custom;
                    break;
                case 2:
                    errorBar.Type = ErrorBarType.Percentage;
                    break;
                case 3:
                    errorBar.Type = ErrorBarType.StandardDeviation;
                    break;
                case 4:
                    errorBar.Type = ErrorBarType.StandardErrors;
                    break;
            }
        }
    }
}

