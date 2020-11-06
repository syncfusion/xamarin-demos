#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class AutoScrolling : SampleView
	{
		AutoScrollingViewModel viewModel;
        public AutoScrolling()
		{
			InitializeComponent();

			viewModel = Chart.BindingContext as AutoScrollingViewModel;
			viewModel.LoadData();

			if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                duplicateAxis.IsVisible = true;

                if (Device.RuntimePlatform == Device.WPF)
                {
                    label.FontSize = 15;
                }
            }
        }

        public override void OnAppearing()
        {
            viewModel.IsDisappear = false;

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), viewModel.UpdateData);

            base.OnAppearing();
        }

		public override void OnDisappearing()
		{
			viewModel.IsDisappear = true;
			base.OnDisappearing();
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS))
            {
                if (height > 0 && width > 0)
                {
                    if (height > width)
                    {
                        layout.Padding = new Thickness(10);
                        stack.Padding = new Thickness(5);
                        duplicateAxis.IsVisible = false;
                    }
                    else
                    {
                        stack.Padding = new Thickness(5);
                        layout.Padding = new Thickness(10);
                        duplicateAxis.IsVisible = true;
                    }
                }
            }
        }
    }
}
