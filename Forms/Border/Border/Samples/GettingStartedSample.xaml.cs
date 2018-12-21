#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Buttons;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser.SfBorder
{
    #region Getting Started Sample Class

    public partial class GettingStartedSample : SampleView
    {
        #region Constructor

        ViewModel viewModel;
        public GettingStartedSample()
        {
            InitializeComponent();
            viewModel = new ViewModel();
           this.BorderColorSegment.ItemsSource = viewModel.PrimaryColors;
            this.BindingContext = viewModel;
        }

        void Handle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                viewModel.BorderColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
                this.BorderColorSegment.SelectionTextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
        }
        #endregion
    }
    #endregion
}