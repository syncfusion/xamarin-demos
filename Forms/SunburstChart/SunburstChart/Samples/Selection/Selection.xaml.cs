#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Syncfusion.SfSunburstChart.XForms;

namespace SampleBrowser.SfSunburstChart
{
    [Preserve(AllMembers = true)]
    public partial class Selection : SampleView
    {
        public Selection()
        {
            InitializeComponent();
            
            selectionMode.SelectedIndex = 0;
            selectionType.SelectedIndex = 0;
            sunburstChart.SelectionChanged += SunburstChart_SelectionChanged;
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                if (Device.RuntimePlatform != Device.UWP)
                {
                    if (legend.LabelStyle == null)
                        legend.LabelStyle = new SunburstLegendLabelStyle();
                    legend.LabelStyle.FontSize = 16;
                }
                title.FontSize = 20;
            }
            else
            {
                if (Device.RuntimePlatform != Device.UWP)
                {
                    if (legend.LabelStyle == null)
                        legend.LabelStyle = new SunburstLegendLabelStyle();
                    legend.LabelStyle.FontSize = 14;
                }
                dataLabel.FontSize = 10;
            }
            
        }

        private void SunburstChart_SelectionChanged(object sender, Syncfusion.SfSunburstChart.XForms.SelectionChangedEventArgs e)
        {
            if (e.SelectedSegment != null)
            {
                stackLayout.IsVisible = true;

                if(!e.IsSelected)
                {
                    stackLayout.IsVisible = false;
                }

                if (e.SelectedSegment.CurrentLevel == 0)
                {
                    countryLabel.Text = "Continent: " + e.SelectedSegment.Category;
                    populationLabel.Text = "Population: " + e.SelectedSegment.Value;
                }
                else if (e.SelectedSegment.CurrentLevel == 1)
                {
                    countryLabel.Text = "Country: " + e.SelectedSegment.Category;
                    populationLabel.Text = "Population: " + e.SelectedSegment.Value;
                }
                else
                {
                    countryLabel.Text = "State: " + e.SelectedSegment.Category;
                    populationLabel.Text = "Population: " + e.SelectedSegment.Value;
                }    
            }
        }

        private void selectionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker.SelectedIndex == 0)
                sunburstChart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByOpacity;
            else if (picker.SelectedIndex == 1)
                sunburstChart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByColor;
            else if (picker.SelectedIndex == 2)
                sunburstChart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByStrokeColor;
        }

        private void selectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker.SelectedIndex == 0)
                sunburstChart.SelectionSettings.SelectionType = SelectionType.Child;
            else if (picker.SelectedIndex == 1)
                sunburstChart.SelectionSettings.SelectionType = SelectionType.Group;
            else if (picker.SelectedIndex == 2)
                sunburstChart.SelectionSettings.SelectionType = SelectionType.Parent;
            else if (picker.SelectedIndex == 3)
                sunburstChart.SelectionSettings.SelectionType = SelectionType.Single;
        }
    }
}