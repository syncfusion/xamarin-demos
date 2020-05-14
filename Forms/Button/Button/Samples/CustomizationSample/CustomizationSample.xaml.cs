#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Buttons;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser.SfButton
{
    #region Customization Sample Class
    public partial class CustomizationSample : SampleView
    {
        #region Constructor

        ViewModel viewModel;
        public CustomizationSample()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            this.TextColorSegment.ItemsSource = viewModel.PrimaryColors;
            this.BackgroundColorSegment.ItemsSource = viewModel.PrimaryColors;
            this.BorderColorSegment.ItemsSource = viewModel.PrimaryColors;
            this.BindingContext = viewModel;

            if(Device.RuntimePlatform == Device.UWP)
            {
                shadow.IsVisible = false;
            }

        }

        void Handle_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            if ((sender as Syncfusion.XForms.Buttons.SfSegmentedControl) == TextColorSegment)
            {
                viewModel.TextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
                this.TextColorSegment.SelectionTextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
            }
            else if ((sender as Syncfusion.XForms.Buttons.SfSegmentedControl) == BackgroundColorSegment)
            {
                viewModel.BackgroundColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
                this.BackgroundColorSegment.SelectionTextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
            }
            else if ((sender as Syncfusion.XForms.Buttons.SfSegmentedControl) == BorderColorSegment)
            {
                viewModel.BorderColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
                this.BorderColorSegment.SelectionTextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
            }
        }
        #endregion
    }
    #endregion
}