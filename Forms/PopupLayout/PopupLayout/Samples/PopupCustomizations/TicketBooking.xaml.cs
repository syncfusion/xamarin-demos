#region Copyright Syncfusion Inc. 2001-2022.
// ------------------------------------------------------------------------------------
// <copyright file = "TicketBooking.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// A ContentPage that contains the TicketBooking sample.
    /// </summary>
    public partial class TicketBooking : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the TicketBooking class.
        /// </summary>
        public TicketBooking()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// You can override this method while View was disappear from window
        /// </summary>
        protected override void OnDisappearing()
        {          
            base.OnDisappearing();

            if (this.termsAndConditionPopup != null)
            {
                this.termsAndConditionPopup.Dispose();
                this.termsAndConditionPopup = null;
            }

            if (this.informationDialog != null)
            {
                this.informationDialog.Dispose();
                this.informationDialog = null;
            }

            if (this.ticketBookingPopup != null)
            {
                this.ticketBookingPopup.Dispose();
                this.ticketBookingPopup = null;
            }

            if (this.confirmationDialog != null)
            {
                this.confirmationDialog.Dispose();
                this.confirmationDialog = null;
            }

            if (this.seconddataGrid != null)
            {
                this.seconddataGrid.Dispose();
                this.seconddataGrid = null;
            }
        }
    }
}