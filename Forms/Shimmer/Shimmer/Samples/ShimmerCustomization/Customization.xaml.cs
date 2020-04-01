#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Border;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfShimmer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customization : SampleView
    {
        public Customization()
        {
            InitializeComponent();
            picker.SelectedIndex = 4;
            waveDirectionPicker.SelectedIndex = 0;

            var colors = new List<Color>
            {
                Color.FromHex("#EBEBEB"),
                Color.FromHex("#E7E7F9"),
                Color.FromHex("#E1EFFF"),
                Color.FromHex("#F4E2EE"),
                Color.FromHex("#F6F6DB"),
            };
            var viewCollection = new ObservableCollection<View>();

            foreach (var color in colors)
            {
                var grid = new Grid();
                var border = new Syncfusion.XForms.Border.SfBorder
                {
                    Margin = new Thickness(3),
                    HorizontalOptions = LayoutOptions.Center,
                    CornerRadius = 22,
                    BorderWidth = 0,
                    Content = new BoxView { Color = color }
                };
                grid.Children.Add(border);
                viewCollection.Add(grid);
            }

            shimmerColorSegmentedControl.ItemsSource = viewCollection;
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            shimmer.Type = (Syncfusion.XForms.Shimmer.ShimmerTypes)(sender as Picker).SelectedIndex;
        }

        private void OnShimmerColorSelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            viewModel.ShimmerColor = viewModel.ShimmerColors[e.Index];
            shimmerColorSegmentedControl.SelectionTextColor = viewModel.ShimmerColors[e.Index];
            viewModel.WaveColor = viewModel.WaveColors[e.Index];
        }

        private void OnWaveDirectionPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            shimmer.WaveDirection = (Syncfusion.XForms.Shimmer.WaveDirection)(sender as Picker).SelectedIndex;
        }
    }
}