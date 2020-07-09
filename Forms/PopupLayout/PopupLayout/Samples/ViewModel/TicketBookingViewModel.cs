#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "TicketBookingViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Reflection;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms;

    /// <summary>
    /// A ViewModel for TicketBooking sample.
    /// </summary>
    public class TicketBookingViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// backing field for TimingCommand.
        /// </summary>
        private Command<SfPopupLayout> timingCommand;        

        /// <summary>
        /// backing field for BookingCommand.
        /// </summary>
        private Command<SfDataGrid> bookingCommand;        

        /// <summary>
        /// backing field for ProceedCommand.
        /// </summary>
        private Command<SfPopupLayout> proceedCommand;

        /// <summary>
        /// backing field for AcceptCommand.
        /// </summary>
        private Command<SfPopupLayout> acceptCommand;
        
        /// <summary>
        /// backing field for DeclineCommand.
        /// </summary>
        private Command declineCommand;    

        /// <summary>
        /// backing field for DeclineCommand.
        /// </summary>
        private Command<Label> seatSelectionCommand;        

        /// <summary>
        /// backing field for OpenInfoCommand.
        /// </summary>
        private Command<InfoPopupParameters> openInfoCommand;

        /// <summary>
        /// Current Terms and Conditions Popup in view.
        /// </summary>
        private SfPopupLayout currentTermsAndConditionsPopup;

        /// <summary>
        /// Current TicketBooking popup.
        /// </summary>
        private SfPopupLayout currentTicketBookingPopup;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the TicketBookingViewModel class.
        /// </summary>
        public TicketBookingViewModel()
        {
            var details = new TicketInfoRepository();
            this.TheaterInformation = details.GetDetails();
            this.timingCommand = new Command<SfPopupLayout>(this.OnTimingButtonClicked);
            this.bookingCommand = new Command<SfDataGrid>(this.OnBookingButtonClicked);
            this.proceedCommand = new Command<SfPopupLayout>(this.OnProceedButtonClicked);
            this.acceptCommand = new Command<SfPopupLayout>(this.OnAcceptButtonClicked);
            this.declineCommand = new Command(this.OnDeclineButtonClicked);
            this.seatSelectionCommand = new Command<Label>(this.SelectSeat);
            this.openInfoCommand = new Command<InfoPopupParameters>(this.OpenInfoPopup);
            this.SetBindingImageSource();
        }

        #endregion

        #region Events

        /// <summary>
        /// Event that triggers when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Command that is called when the timing button is called.
        /// </summary>
        public Command<SfPopupLayout> TimingCommand
        {
            get
            {
                return this.timingCommand;
            }

            set
            {
                this.timingCommand = value;
                this.RaisePropertyChanged("TimingCommand");
            }
        }

        /// <summary>
        /// Gets or sets the Command that will is called when the book button is clicked.
        /// </summary>
        public Command<SfDataGrid> BookingCommand
        {
            get
            {
                return this.bookingCommand;
            }

            set
            {
                this.bookingCommand = value;
                this.RaisePropertyChanged("BookingCommand");
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the Proceed button is clicked.
        /// </summary>
        public Command<SfPopupLayout> ProceedCommand
        {
            get
            {
                return this.proceedCommand;
            }

            set
            {
                this.proceedCommand = value;
                this.RaisePropertyChanged("ProceedCommand");
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the Accept button is clicked.
        /// </summary>
        public Command<SfPopupLayout> AcceptCommand
        {
            get
            {
                return this.acceptCommand;
            }

            set
            {
                this.acceptCommand = value;
                this.RaisePropertyChanged("AcceptCommand");
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the Decline button is clicked.
        /// </summary>
        public Command DeclineCommand
        {
            get
            {
                return this.declineCommand;
            }

            set
            {
                this.declineCommand = value;
                this.RaisePropertyChanged("DeclineCommand");
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the seat is selected.
        /// </summary>
        public Command<Label> SeatSelectionCommand
        {
            get
            {
                return this.seatSelectionCommand;
            }

            set
            {
                this.seatSelectionCommand = value;
                this.RaisePropertyChanged("SeatSelectionCommand");
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the information image is clicked.
        /// </summary>
        public Command<InfoPopupParameters> OpenInfoCommand
        {
            get
            {
                return this.openInfoCommand;
            }

            set
            {
                this.openInfoCommand = value;
                this.RaisePropertyChanged("OpenInfoCommand");
            }
        }

        #region ItemsSource

        /// <summary>
        /// Gets or sets the TheaterInformation which is ObservableCollection of TicketBookingInfo type.
        /// </summary>
        public ObservableCollection<TicketBookingInfo> TheaterInformation { get; set; }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Action to be performed when timing button is clicked.
        /// </summary>
        /// <param name="termsAndConditionsPopup">Popup to be displayed.</param>
        private void OnTimingButtonClicked(SfPopupLayout termsAndConditionsPopup)
        {
            this.currentTermsAndConditionsPopup = termsAndConditionsPopup;
            this.currentTermsAndConditionsPopup.Show();
        }

        /// <summary>
        /// Action to be performed when book button is clicked.
        /// </summary>
        /// <param name="dataGridObject">DataGrid's object in view</param>
        private void OnBookingButtonClicked(SfDataGrid dataGridObject)
        {
            if (dataGridObject != null)
            {
                (dataGridObject.Parent as SampleView).Navigation.PushAsync(new TicketBooking());
            }
        }

        /// <summary>
        /// Action to be performed when proceed button is clicked.
        /// </summary>
        /// <param name="confirmationPopup">Confirmation popup to be displayed.</param>
        private async void OnProceedButtonClicked(SfPopupLayout confirmationPopup)
        {
            if (this.currentTicketBookingPopup != null)
            {
                this.currentTicketBookingPopup.Dismiss();
            }

            await Task.Delay(200);
            confirmationPopup.Show();
        }

        /// <summary>
        /// Action to be performed when accept button is clicked.
        /// </summary>
        /// <param name="ticketBookingPopup">Popup to be displayed.</param>
        private async void OnAcceptButtonClicked(SfPopupLayout ticketBookingPopup)
        {
            this.CloseCurrentTermsAndConditionsPopup();
            await Task.Delay(200);
            this.currentTicketBookingPopup = ticketBookingPopup;
            this.currentTicketBookingPopup.Show();
        }

        /// <summary>
        /// Action to be performed when decline button is clicked.
        /// </summary>
        private void OnDeclineButtonClicked()
        {
            this.CloseCurrentTermsAndConditionsPopup();
        }

        /// <summary>
        /// Closes the current TermsAndConditionsPopup.
        /// </summary>
        private void CloseCurrentTermsAndConditionsPopup()
        {
            if (this.currentTermsAndConditionsPopup != null)
            {
                this.currentTermsAndConditionsPopup.Dismiss();
            }
        }

        /// <summary>
        /// Action to be performed when seats is selected.
        /// </summary>
        /// <param name="label">The view that is clicked</param>
        private void SelectSeat(Label label)
        {
            foreach (var children in (label.Parent as StackLayout).Children)
            {
                children.BackgroundColor = Color.White;
                (children as Label).TextColor = Color.Black;
            }

            label.BackgroundColor = Color.FromHex("#007CEE");
            label.TextColor = Color.White;
        }

        /// <summary>
        /// Action to be performed when Info image is clicked.
        /// </summary>
        /// <param name="infoPopupParameters">InfoPopupParameters needed for displaying InfoPopup</param>
        private void OpenInfoPopup(InfoPopupParameters infoPopupParameters)
        {
            infoPopupParameters.InfoPopup.PopupView.HeaderTitle = infoPopupParameters.TheatreLabel.Text;
            infoPopupParameters.InfoPopup.Show();
        }

        /// <summary>
        /// Sets the ImageSource for the Images.
        /// </summary>
        private void SetBindingImageSource()
        {
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter named as name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
