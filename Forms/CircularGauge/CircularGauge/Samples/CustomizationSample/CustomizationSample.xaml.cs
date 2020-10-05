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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfCircularGauge
{
	[Preserve(AllMembers = true)]
    public partial class CustomizationSample : SampleView
    {
        public CustomizationSample()
        {
            InitializeComponent();

            header1.Text = Math.Round(viewModel.PointerValue, 2) + " GB";
            header2.Text = Math.Round(viewModel.PointerValue, 2) + " GB";

            pointer_slider.BindingContext = viewModel;
            pointer_slider.ValueChanged += Pointer_slider_ValueChanged;

            rangePointerColorPicker.SelectedIndex = 0;
            rangePointerColorPicker.SelectedIndexChanged += RangePointerColorPicker_SelectedIndexChanged;

            needlePointerColorPicker.SelectedIndex = 0;
            needlePointerColorPicker.SelectedIndexChanged += NeedlePointerColorPicker_SelectedIndexChanged;

            rangeColorPicker.SelectedIndex = 0;
            rangeColorPicker.SelectedIndexChanged += RangeColorPicker_SelectedIndexChanged;
        
        }

        private void Pointer_slider_ValueChanged(object sender, EventArgs e)
        {
            header1.Text = Math.Round(viewModel.PointerValue, 2) + " GB";
            header2.Text = Math.Round(viewModel.PointerValue, 2) + " GB";
        }

        private void RangePointerColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rangePointerColorPicker.SelectedIndex)
            {
                case 0:
                    viewModel.RangePointerColor = Color.FromHex("#FFDD00");
                    break;

                case 1:
                    viewModel.RangePointerColor = Color.FromHex("#00bdae");
                    break;

                case 2:
                    viewModel.RangePointerColor = Color.FromHex("#FF2680");
                    break;
            }
        }
        private void NeedlePointerColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (needlePointerColorPicker.SelectedIndex)
            {
                case 0:
                    viewModel.NeedlePointerColor = Color.FromHex("#424242");
                    break;

                case 1:
                    viewModel.NeedlePointerColor = Color.FromHex("#6f6fe2");
                    break;

                case 2:
                    viewModel.NeedlePointerColor = Color.FromHex("#9e480e");
                    break;
            }
        }
        private void RangeColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rangeColorPicker.SelectedIndex)
            {
                case 0:
                    viewModel.RangeColor = Color.FromHex("#E0E0E0");
                    break;

                case 1:
                    viewModel.RangeColor = Color.FromHex("#7bb4eb");
                    break;

                case 2:
                    viewModel.RangeColor = Color.FromHex("#ea7e57");
                    break;
            }
        }
    }
}
