#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Core.XForms;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.XForms.TextInputLayout;

namespace SampleBrowser.SfTextInputLayout
{
    /// <summary>
    /// Sign up view.
    /// </summary>
    public partial class SignUpView : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfTextInputLayout.SignUpView"/> class.
        /// </summary>
        public SignUpView()
        {
            InitializeComponent();
            picker.SelectedIndex = 0;
            picker2.SelectedIndexChanged += (sender, e) =>
              {
                  picker3.IsVisible = (picker2.SelectedIndex == 0);
                  fontAttributeLabel.IsVisible = (picker2.SelectedIndex == 0);
              };

            if (Device.RuntimePlatform == Device.WPF)
            {
                stateLayout.IsVisible = false;
				birthdayLayoutGrid.IsVisible = false;

                submitButton.HeightRequest = 35;
                resetButton.HeightRequest = 35;
            }
        }

        public override void OnDisappearing()
        {
            labelGesture.Tapped -= GestureRecognizer_Tapped;
        }
        
        /// <summary>
        /// Raised when the Label is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The eventArgs</param>
        private void GestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if(Device.RuntimePlatform != Device.UWP)
                date_Picker.Focus();
        }

		/// <summary>
		/// Paised when the picker selected item changed.
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The eventArgs</param>
		private void GenderPicker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Picker pickerInstance = sender as Picker;
			signUpViewModel.Gender = (string)pickerInstance.ItemsSource[pickerInstance.SelectedIndex];
		}
	}
}