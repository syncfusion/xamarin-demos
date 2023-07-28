#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfStepProgressBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Themes : SampleView
    {
        ShipmentViewModel ShipmentViewModel = new ShipmentViewModel();

        public Themes()
        {
            InitializeComponent();
            stepProgress.StatusChanged += Step_StatusChanged;
            ShipmentViewModel.PopulateShipmentDetails();
            BindableLayout.SetItemsSource(stepProgress, ShipmentViewModel.ShipmentInfoCollection);
            this.PropertyChanged += Themes_PropertyChanged;
        }

        private void Themes_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BackgroundColor" && stepProgress != null && stepProgress.Children.Count > 0)
            {
                for (int i = 0; i < stepProgress.Children.Count; i++)
                {
                    SetStepViewPrimaryTextColor(stepProgress.Children[i] as StepView);
                }
            }
        }

        void SetStepViewPrimaryTextColor(StepView view)
        {
            if (view.Status == StepStatus.Completed)
            {
                view.PrimaryFormattedText.Spans[0].TextColor = stepProgress.CompletedStepStyle.FontColor;
                view.PrimaryFormattedText.Spans[3].TextColor = stepProgress.CompletedStepStyle.FontColor;
                view.PrimaryFormattedText.Spans[5].TextColor = stepProgress.CompletedStepStyle.FontColor;
            }

            if (view.Status == StepStatus.NotStarted)
            {
                view.PrimaryFormattedText.Spans[0].TextColor = Color.FromHex("#6E6E6E");
                view.PrimaryFormattedText.Spans[3].TextColor = Color.Transparent;
                view.PrimaryFormattedText.Spans[5].TextColor = Color.Transparent;
            }
        }

        void Step_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            int index = stepProgress.Children.IndexOf(e.Item);
            SetStepViewPrimaryTextColor(e.Item);
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
}