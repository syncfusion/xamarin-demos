#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// A sampleView that contains the flight booking sample.
    /// </summary>
    public partial class FlightBooking : SampleView
    {
        /// <summary>
        /// Initializes a new instance of <see cref="FlightBooking"/>.
        /// </summary>
        public FlightBooking()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises when <see cref="FlightBooking"/> page disappears.
        /// </summary>
        public override void OnDisappearing()
        {
            base.OnDisappearing();
            this.viewModel.Bot = null;
            if (this.sfChat != null)
            {
                this.sfChat.Dispose();
                this.sfChat = null;
            }

            if(this.busyindicator != null)
            {
                this.busyindicator = null;
            }
        }
    }
}