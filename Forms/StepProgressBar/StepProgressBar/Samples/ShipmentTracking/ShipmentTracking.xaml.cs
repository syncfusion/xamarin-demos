#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;

namespace SampleBrowser.SfStepProgressBar
{
    public partial class ShipmentTracking : SampleView
    {
        public ShipmentTracking()
        {
            InitializeComponent();
            stepProgress.StatusChanged += Step_StatusChanged;
        }

        void Step_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            int index = stepProgress.Children.IndexOf(e.Item);
            if (index == 1)
            {
                if (e.Item.Status == StepStatus.InProgress)
                {
                    span2.TextColor = Color.Black;
                    span3.TextColor = Color.FromHex("#6E6E6E");
                }
                else if (e.Item.Status == StepStatus.NotStarted)
                {
                    span2.TextColor = Color.Transparent;
                    span3.TextColor = Color.Transparent;
                }
            }

            if (index == 2)
            {
                if (e.Item.Status == StepStatus.InProgress)
                {
                    span22.TextColor = Color.Black;
                    span23.TextColor = Color.FromHex("#6E6E6E");
                }
                else if (e.Item.Status == StepStatus.NotStarted)
                {
                    span22.TextColor = Color.Transparent;
                    span23.TextColor = Color.Transparent;
                }
            }

            if (e.Item == stepProgress.Children[stepProgress.Children.Count - 1] && e.Item.Status == StepStatus.Completed)
            {
                TrackButton.IsEnabled = true;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            StepView stepView;
            switch (TrackButton.Text)
            {
                case "Track Status":
                    stepProgress.ProgressAnimationDuration = 1000;
                    stepView = stepProgress.Children[3] as StepView;
                    stepView.Status = StepStatus.Completed;
                    TrackButton.Text = "Reset";
                    TrackButton.IsEnabled = false;
                    break;
                default:
                    TrackButton.Text = "Track Status";
                    stepProgress.ProgressAnimationDuration = 1;
                    stepView = stepProgress.Children[0] as StepView;
                    stepView.Status = StepStatus.NotStarted;
                    break;
            }
        }
    }
     
    public class SwitchToColorConverter : IValueConverter
    {
        string checkString = string.Empty;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Span span = parameter as Span;
            Color color = Color.FromHex("#6E6E6E");
            if ((StepStatus)value == StepStatus.Completed)
            {
                if (checkString == string.Empty && span.Text != string.Empty)
                {
                    checkString = span.Text;
                    return color;
                }
                switch (span.ClassId)
                {
                    case "1":
                        color = Color.Black;
                        break;
                }
            }
            else if ((StepStatus)value == StepStatus.NotStarted)
            {
                checkString = string.Empty;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Color)value == Color.Black;
        }
    }
}