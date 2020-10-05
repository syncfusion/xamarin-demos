#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class LiveUpdate : SampleView
	{
		LiveUpdateViewModel viewModel;
		public LiveUpdate()
		{
			InitializeComponent();
			viewModel = Chart.BindingContext as LiveUpdateViewModel;
			viewModel.UpdateLiveData();
			(Chart.SecondaryAxis as NumericalAxis).Maximum = 1.5;
			(Chart.SecondaryAxis as NumericalAxis).Minimum = -1.5;
            viewModel.StartTimer();
        }

        public override void OnAppearing()
        {
            if (viewModel != null)
                viewModel.StartTimer();
            base.OnAppearing();
        }

        public override void OnDisappearing()
        {
            if (viewModel != null)
                viewModel.StopTimer();
        }
    }
}