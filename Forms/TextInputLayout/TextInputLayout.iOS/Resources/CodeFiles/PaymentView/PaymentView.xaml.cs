#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using Syncfusion.XForms.MaskedEdit;

namespace SampleBrowser.SfTextInputLayout
{
    /// <summary>
    /// Payment view.
    /// </summary>
    public partial class PaymentView : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfTextInputLayout.PaymentView"/> class.
        /// </summary>
        public PaymentView()
        {
            InitializeComponent();
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
            if (Device.RuntimePlatform != Device.UWP)
            {
                date_Picker.Focus();
            }                
        }
    }
}