#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using CoreAnimation;


#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using CoreGraphics;
using Syncfusion.SfChart.iOS;
using UIKit;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
    public class Trendlines : SampleView
    {
        private SFSplineSeries splineSeries2;
        private SFSplineSeries splineSeries1;
        private SFChartTrendline powerTrendline;
        private SFChartTrendline linearTrendline;
        private readonly List<string> Types = new List<string> { "Linear", "Exponential", "Logarithmic", "Power", "Polynomial" };
        UIPickerView picker;

        private SFChart chart;
        private SFChart chart1;
        private UIButton typeTextButton;
        private UIButton doneButton;

        public Trendlines()
        {
            chart = GetCurrencyDevationChart();
            chart1 = GetMeterDevationChart();
            chart.Hidden = false;

            chart1.Hidden = true;
            picker = new UIPickerView();
            var pickerModel = new TypePickerViewmodel(Types);
            picker.Model = pickerModel;
            picker.Hidden = true;
            pickerModel.ValueChanged += PickerModel_ValueChanged;

            doneButton = new UIButton();
            typeTextButton = new UIButton();
            doneButton.SetTitle("Done" + "\t", UIControlState.Normal);
            doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            doneButton.TouchUpInside += delegate
            {
                picker.Hidden = true;
                doneButton.Hidden = true;
                this.BecomeFirstResponder();
            };

            typeTextButton.SetTitle("Linear", UIControlState.Normal);
            typeTextButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            typeTextButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            typeTextButton.TouchUpInside += delegate
            {
                picker.Hidden = false;
                doneButton.Hidden = false;
                this.BecomeFirstResponder();
            };

            typeTextButton.BackgroundColor = UIColor.Clear;
            typeTextButton.Layer.BorderWidth = 2.0f;
            typeTextButton.Layer.BorderColor = UIColor.FromRGB(240.0f / 255.0f, 240.0f / 255.0f, 240.0f / 255.0f).CGColor;
            typeTextButton.Layer.CornerRadius = 8.0f;

            picker.BackgroundColor = UIColor.FromRGB(240f / 255.0f, 240f / 255.0f, 240f / 255.0f);

            doneButton.BackgroundColor = UIColor.FromRGB(240f / 255.0f, 240f / 255.0f, 240f / 255.0f);
            doneButton.Hidden = true;

            chart1.Legend.Visible = true;

            AddSubview(chart);
            AddSubview(chart1);
            AddSubview(picker);
            AddSubview(typeTextButton);
            AddSubview(doneButton);
        }

        void PickerModel_ValueChanged(object sender, EventArgs e)
        {
            var selectedValue = ((TypePickerViewmodel)sender).SelectedValue;
            if (selectedValue == "Power")
            {
                typeTextButton.SetTitle("Power", UIControlState.Normal);
                chart1.Hidden = false;
                chart.Hidden = true;
            }
            else
            {
                if (selectedValue == "Linear")
                {
                    typeTextButton.SetTitle("Linear", UIControlState.Normal);
                    linearTrendline.Type = SFTrendlineType.Linear;
                    linearTrendline.Label = "Linear";
                }
                else if (selectedValue == "Exponential")
                {
                    typeTextButton.SetTitle("Exponential", UIControlState.Normal);
                    linearTrendline.Label = "Exponential";
                    linearTrendline.Type = SFTrendlineType.Exponential;
                }
                else if (selectedValue == "Logarithmic")
                {
                    typeTextButton.SetTitle("Logarithmic", UIControlState.Normal);
                    linearTrendline.Label = "Logarithmic";
                    linearTrendline.Type = SFTrendlineType.Logarithmic;
                }
                else if (selectedValue == "Polynomial")
                {
                    typeTextButton.SetTitle("Polynomial", UIControlState.Normal);
                    linearTrendline.Label = "Polynomial";
                    linearTrendline.Type = SFTrendlineType.Polynomial;
                }

                if (chart.Hidden)
                {
                    chart.Hidden = false;
                    chart1.Hidden = true;
                }
            }
        }

        private SFChart GetMeterDevationChart()
        {
            var sfchart = new SFChart();
            sfchart.Title.Text = "Distance Measurement";

            sfchart.Legend.Visible = true;
            sfchart.Legend.DockPosition = SFChartLegendPosition.Top;
            sfchart.Legend.IconHeight = 14;
            sfchart.Legend.IconWidth = 14;
            sfchart.ColorModel.Palette = SFChartColorPalette.Natural;

            SFNumericalAxis numericalaxis = new SFNumericalAxis();
            numericalaxis.AxisLineStyle.LineWidth = 0;
            numericalaxis.MajorTickStyle.LineWidth = 0;
            numericalaxis.Title.Text = new Foundation.NSString("Meters");
            sfchart.SecondaryAxis = numericalaxis;

            SFNumericalAxis primaryAxis = new SFNumericalAxis();
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.Title.Text = new Foundation.NSString("Seconds");
            primaryAxis.ShowMinorGridLines = false;
            sfchart.PrimaryAxis = primaryAxis;

            splineSeries2 = new SFSplineSeries();
            splineSeries2.ItemsSource = ChartViewModel.GetTrendlineDataSource2();
            splineSeries2.XBindingPath = "XValue";
            splineSeries2.YBindingPath = "YValue";
            splineSeries2.Label = "Rupees";
            splineSeries2.LegendIcon = SFChartLegendIcon.SeriesType;

            splineSeries2.DataMarker.ShowMarker = true;
            splineSeries2.DataMarker.ShowLabel = false;
            splineSeries2.DataMarker.MarkerHeight = 5;
            splineSeries2.DataMarker.MarkerWidth = 5;
            splineSeries2.DataMarker.MarkerBorderWidth = 2;
            splineSeries2.DataMarker.MarkerBorderColor = UIColor.FromName("#00bdae");

            splineSeries2.Trendlines = new ChartTrendlineCollection();
            powerTrendline = new SFChartTrendline()
            {
                Type = SFTrendlineType.Power,
                LineColor = UIColor.FromRGB(201, 23, 97),
                LegendIcon = SFChartLegendIcon.SeriesType,
                Label = "Power"
            };

            splineSeries2.Trendlines.Add(powerTrendline);
            sfchart.Series.Add(splineSeries2);
            return sfchart;
        }



        private SFChart GetCurrencyDevationChart()
        {
            var sfchart = new SFChart();
            sfchart.Title.Text = "1 USD to INR from 1977 to 2019";

            sfchart.Legend.Visible = true;
            sfchart.Legend.DockPosition = SFChartLegendPosition.Top;
            sfchart.Legend.IconHeight = 14;
            sfchart.Legend.IconWidth = 14;
            sfchart.ColorModel.Palette = SFChartColorPalette.Natural;
            sfchart.Delegate = new AxisLabelFormatter();
            SFNumericalAxis numericalaxis = new SFNumericalAxis();
            numericalaxis.AxisLineStyle.LineWidth = 0;
            numericalaxis.MajorTickStyle.LineWidth = 0;
            numericalaxis.Title.Text = new Foundation.NSString("Rupees against Dollars");
            sfchart.SecondaryAxis = numericalaxis;

            SFDateTimeAxis primaryAxis = new SFDateTimeAxis();
            primaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.IntervalType = SFChartDateTimeIntervalType.Years;
            primaryAxis.Interval = new NSNumber(8);
            primaryAxis.Title.Text = new Foundation.NSString("Years");
            primaryAxis.ShowMinorGridLines = false;
            sfchart.PrimaryAxis = primaryAxis;

            splineSeries1 = new SFSplineSeries();
            splineSeries1.XBindingPath = "XValue";
            splineSeries1.YBindingPath = "YValue";
            splineSeries1.ItemsSource = ChartViewModel.GetTrendlineDataSource1();
            splineSeries1.Label = "Rupees";
            splineSeries1.LegendIcon = SFChartLegendIcon.SeriesType;

            splineSeries1.DataMarker.ShowMarker = true;
            splineSeries1.DataMarker.ShowLabel = false;
            splineSeries1.DataMarker.MarkerHeight = 5;
            splineSeries1.DataMarker.MarkerWidth = 5;
            splineSeries1.DataMarker.MarkerWidth = 2;
            splineSeries1.DataMarker.MarkerBorderColor = UIColor.FromName("#00bdae");
            splineSeries1.Trendlines = new ChartTrendlineCollection();
            linearTrendline = new SFChartTrendline()
            {
                Type = SFTrendlineType.Linear,
                LineColor = UIColor.FromRGB(201, 23, 97),
                LegendIcon = SFChartLegendIcon.SeriesType,
                Label = "Linear",
                PolynomialOrder = 3,
            };

            splineSeries1.Trendlines.Add(linearTrendline);
            sfchart.Series.Add(splineSeries1);

            return sfchart;
        }

        public override void LayoutSubviews()
        {

            base.LayoutSubviews();
            chart.Frame = new CGRect(this.Bounds.X, this.Bounds.Y + 40, this.Bounds.Width, this.Bounds.Height - 40);
            chart1.Frame = new CGRect(this.Bounds.X, this.Bounds.Y + 40, this.Bounds.Width, this.Bounds.Height - 40);
            typeTextButton.Frame = new CGRect(10, Bounds.Y, Frame.Size.Width - 20, 40);

            if (Utility.IsIPad)
            {
                doneButton.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 253, Frame.Size.Width, 35);
                picker.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 260, Frame.Size.Width, 260);
            }
            else
            {
                doneButton.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 143, Frame.Size.Width, 35);
                picker.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 150, Frame.Size.Width, 150);
            }

        }

        public class TypePickerViewmodel : UIPickerViewModel
        {
            public List<string> Types;
            public EventHandler ValueChanged;
            public string SelectedValue;
            public TypePickerViewmodel(List<string> types)
            {
                this.Types = types;
            }
            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return Types.Count;
            }
            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 1;
            }
            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                return Types[(int)row];
            }
            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                var type = Types[(int)row];
                SelectedValue = type;
                ValueChanged?.Invoke(this, null);
            }
        }

        class AxisLabelFormatter : SFChartDelegate
        {
            public override NSString GetFormattedAxisLabel(SFChart chart, NSString label, NSObject value, SFAxis axis)
            {
                if (axis == chart.SecondaryAxis)
                {
                    String formattedLabel = "₹" + label;
                    label = new NSString(formattedLabel);
                    return label;
                }

                return label;
            }
        }
    }
}