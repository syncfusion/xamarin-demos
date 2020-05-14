#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
	public class DataPointSelection : SampleView
	{
		SFChart chart;
		ChartViewModel dataModel;
        UIPickerView selectionPicker;
        UIButton doneButton;
        UIButton selectionTypeTextButton;

        public DataPointSelection()
		{
            selectionPicker = new UIPickerView();
            doneButton = new UIButton();
            selectionTypeTextButton = new UIButton();

            chart = new SFChart();
            chart.Title.Text = new NSString("Product Sale 2016");
			SFCategoryAxis primary = new SFCategoryAxis();
			primary.LabelPlacement = SFChartLabelPlacement.BetweenTicks;
			primary.Title.Text = new NSString("Month");
			chart.PrimaryAxis = primary;
			chart.SecondaryAxis = new SFNumericalAxis() { ShowMajorGridLines = false };
			chart.SecondaryAxis.Title.Text = new NSString("Sales");

			dataModel = new ChartViewModel();

			SFColumnSeries series = new SFColumnSeries();
			series.ItemsSource = dataModel.SelectionData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableDataPointSelection = true;
			series.EnableAnimation = true;
            series.Color = UIColor.FromRGBA(0, 189f / 255f, 174f / 255f, 1f);
            series.SelectedDataPointColor = UIColor.FromRGBA(0, 113f / 255f, 104f / 255f, 1f);
            chart.Series.Add(series);

            SFColumnSeries series1 = new SFColumnSeries();
            series1.ItemsSource = dataModel.SelectionData1;
            series1.XBindingPath = "XValue";
            series1.YBindingPath = "YValue";
            series1.EnableDataPointSelection = true;
            series1.EnableAnimation = true;
            series1.Color = UIColor.FromRGBA(0, 132f / 255f, 232f / 255f, 1f);
            series1.SelectedDataPointColor = UIColor.FromRGBA(0, 79f / 255f, 178f / 255f, 1f);
            chart.Series.Add(series1);

			chart.AddChartBehavior(new SFChartSelectionBehavior());
			
			this.AddSubview(chart);

            selectionTypeTextButton.SetTitle(" Data Point Selection", UIControlState.Normal);
            selectionTypeTextButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            selectionTypeTextButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            selectionTypeTextButton.TouchUpInside += delegate
            {

                selectionPicker.Hidden = false;
                doneButton.Hidden = false;
                this.BecomeFirstResponder();

            };
            selectionTypeTextButton.BackgroundColor = UIColor.Clear;
            selectionTypeTextButton.Layer.BorderWidth = 2.0f;
            selectionTypeTextButton.Layer.BorderColor = UIColor.FromRGB(240.0f / 255.0f, 240.0f / 255.0f, 240.0f / 255.0f).CGColor;
            selectionTypeTextButton.Layer.CornerRadius = 8.0f;
            this.AddSubview(selectionTypeTextButton);

            selectionPicker.ShowSelectionIndicator = true;
            selectionPicker.Hidden = true;

            selectionPicker.Model = new PickerViewModel(chart, selectionTypeTextButton);

            selectionPicker.BackgroundColor = UIColor.FromRGB(240f / 255.0f, 240f / 255.0f, 240f / 255.0f);
            selectionPicker.SelectedRowInComponent(0);
            this.AddSubview(selectionPicker);

            doneButton.SetTitle("Done" + "\t", UIControlState.Normal);
            doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            doneButton.TouchUpInside += delegate
            {

                selectionPicker.Hidden = true;
                doneButton.Hidden = true;
                this.BecomeFirstResponder();

            };

            doneButton.BackgroundColor = UIColor.FromRGB(240f / 255.0f, 240f / 255.0f, 240f / 255.0f);
            doneButton.Hidden = true;
            this.AddSubview(doneButton);
        }

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
                if (view == chart)
                {
                    chart.Frame = new CGRect(this.Bounds.X, this.Bounds.Y + 40,
                   this.Bounds.Width, this.Bounds.Height - 40);
                }
                else if (view == selectionTypeTextButton)
                {
                    selectionTypeTextButton.Frame = new CGRect(10, Bounds.Y, Frame.Size.Width - 20, 32);
                }
                else if (view == doneButton)
                {
                    if (Utility.IsIPad)
                    {
                        doneButton.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 253, Frame.Size.Width, 35);
                    }
                    else
                    {
                        doneButton.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 143, Frame.Size.Width, 35);
                    }
                }
                else if (view == selectionPicker)
                {
                    if (Utility.IsIPad)
                    {
                        selectionPicker.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 260, Frame.Size.Width, 260);
                    }
                    else
                    {
                        selectionPicker.Frame = new CGRect(0, Bounds.Y + Frame.Size.Height - 150, Frame.Size.Width, 150);
                    }
                }
                else
                    view.Frame = Frame;
            }
            base.LayoutSubviews();
		}
	}

    public class PickerViewModel : UIPickerViewModel
    {
        UIButton selectionTypeTextButton;
        SFChart chart1;


        public PickerViewModel(SFChart chart, UIButton selectionButton)
        {
            selectionTypeTextButton = selectionButton;
            chart1 = chart;

        }

        private readonly IList<string> selectionModes = new List<string>
        {
        "Data Point Selection",
        "Series Selection",
        };


        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return (nint)selectionModes.Count;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return selectionModes[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {

            selectionTypeTextButton.SetTitle(selectionModes[(int)row], UIControlState.Normal);

            if (row == 0)
            {
                chart1.EnableSeriesSelection = false;
            }
            else if (row == 1)
            {
                chart1.EnableSeriesSelection = true;
            }
        }
    }
}