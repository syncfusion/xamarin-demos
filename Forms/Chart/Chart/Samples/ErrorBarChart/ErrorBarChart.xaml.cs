#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfChart
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ErrorBarChart : SampleView
	{
		public ErrorBarChart ()
		{
			InitializeComponent ();

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                secondaryAxisLabelStyle.LabelFormat = "0'%'";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "#'%'";
            }

            HorizontalErrorValue.ValueChanged += Horizontal_ValueChanged;
            VerticalErrorValue.ValueChanged += Vertical_ValueChanged;
            HorizontalErrorValue.MaximumTrackColor = Color.LightBlue;
            HorizontalErrorValue.MinimumTrackColor = Color.Blue;
            VerticalErrorValue.MaximumTrackColor = Color.LightBlue;
            VerticalErrorValue.MinimumTrackColor = Color.Blue;
            ErrorBarTypeValue.SelectedIndex = 0;
            ErrorBarTypeValue.SelectedIndexChanged += ErrorBarType_SelectedIndexChanged;
            ErrorBarDrawingModeValue.SelectedIndex = 2;
            ErrorBarDrawingModeValue.SelectedIndexChanged += ErrorBarModeValue_SelectedIndexChanged;
            HorizontalDirectionValue.SelectedIndex = 0;
            HorizontalDirectionValue.SelectedIndexChanged += HorizontalDirectionValue_SelectedIndexChanged;
            VerticalDirectionValue.SelectedIndex = 0;
            VerticalDirectionValue.SelectedIndexChanged += VerticalDirectionValue_SelectedIndexChanged;
		}

        private void Vertical_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Series.VerticalErrorValue = e.NewValue;
            VerticalError.Text = "Vertical Error : " + e.NewValue.ToString();
        }

        private void Horizontal_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Series.HorizontalErrorValue = e.NewValue;
            HorizontalError.Text = "Horizontal Error : " + e.NewValue.ToString();
        }

        private void VerticalDirectionValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (VerticalDirectionValue.SelectedIndex)
            {
                case 0:
                    Series.VerticalDirection = ErrorBarDirection.Both;
                    break;
                case 1:
                    Series.VerticalDirection = ErrorBarDirection.Minus;
                    break;
                case 2:
                    Series.VerticalDirection = ErrorBarDirection.Plus;
                    break;
            }
        }

        private void HorizontalDirectionValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(HorizontalDirectionValue.SelectedIndex)
            {
                case 0:
                    Series.HorizontalDirection = ErrorBarDirection.Both;
                    break;
                case 1:
                    Series.HorizontalDirection = ErrorBarDirection.Minus;
                    break;
                case 2:
                    Series.HorizontalDirection = ErrorBarDirection.Plus;
                    break;
            }
        }

        private void ErrorBarModeValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(ErrorBarDrawingModeValue.SelectedIndex)
            {
                case 0:
                    Series.Mode = ErrorBarMode.Both;
                    break;
                case 1:
                    Series.Mode = ErrorBarMode.Horizontal;
                    break;
                case 2:
                    Series.Mode = ErrorBarMode.Vertical;
                    break;
            }
        }

        private void ErrorBarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(ErrorBarTypeValue.SelectedIndex)
            {
                case 0:
                    Series.Type = ErrorBarType.Fixed;
                    break;
                case 1:
                    Series.Type = ErrorBarType.Percentage;
                    break;
                case 2:
                    Series.Type = ErrorBarType.StandardDeviation;
                    break;
                case 3:
                    Series.Type = ErrorBarType.StandardErrors;
                    break;
                case 4:
                    Series.Type = ErrorBarType.Custom;
                    break;
            }
        }
    }
}