#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using SelectionChangedEventArgs = Syncfusion.XForms.Buttons.SelectionChangedEventArgs;
using Syncfusion.XForms.Buttons;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser.SfBorder
{
    #region Getting Started Sample Class

    public partial class GettingStartedSample : SampleView
    {
        #region Constructor

        GettingStartedSampleViewModel viewModel;
        public GettingStartedSample()
        {
            InitializeComponent();
            viewModel = new GettingStartedSampleViewModel();
            this.BorderColorSegment.ItemsSource = viewModel.PrimaryColors;
            this.BindingContext = viewModel;
			
			if(Device.RuntimePlatform == Device.UWP)
			{
				shadow.IsVisible = false;
			}
        }

        void Handle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                viewModel.BorderColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
                this.BorderColorSegment.SelectionTextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
        }

        void BorderTypeToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            border.DashArray = dottedArraySwitch.IsToggled ? new double[] { 10, 5 } : new double[] { 0, 0 };
        }

        #endregion
    }
    #endregion
}