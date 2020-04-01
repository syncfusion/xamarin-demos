#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedViewModel.cs" company="Syncfusion.com">
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
    using System.ComponentModel;
    using System.Reflection;
    using SampleBrowser.Core;
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms;

    /// <summary>
    /// A ViewModel for GettingStarted sample.
    /// </summary>
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Backing filed for SmallFontSwitch property.
        /// </summary>
        private bool smallFontSwitch;

        /// <summary>
        /// Backing filed for NormalFontSwitch property.
        /// </summary>
        private bool normalFontSwitch;

        /// <summary>
        /// Backing filed for LargeFontSwitch property.
        /// </summary>
        private bool largeFontSwitch;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel" /> class.
        /// </summary>
        public GettingStartedViewModel()
        {
            this.OpenAlertDialog = new Command<SfPopupLayout>(this.DisplayAlert);
            this.OpenAlertWithTitleDialog = new Command<SfPopupLayout>(this.DisplayAlertWithTitle);
            this.OpenSimpleDialog = new Command<SfPopupLayout>(this.DisplaySimpleDialog);
            this.OpenConfirmationDialog = new Command<SfPopupLayout>(this.DisplayConfirmationDialog);
            this.OpenModalDialog = new Command<SfPopupLayout>(this.DisplayModalDialog);
            this.OpenRelativeDialog = new Command<SfPopupLayout>(this.DisplayDialogRelativeToView);
            this.OpenFullScreenDialog = new Command<SfPopupLayout>(this.DisplayFullScreenDialog);
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
        /// Gets or sets the command for opening the AlertDialog popup.
        /// </summary>
        public Command<SfPopupLayout> OpenAlertDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the AlertDialog popup with title. 
        /// </summary>
        public Command<SfPopupLayout> OpenAlertWithTitleDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the simple dialog. 
        /// </summary>
        public Command<SfPopupLayout> OpenSimpleDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the confirmation dialog.
        /// </summary>
        public Command<SfPopupLayout> OpenConfirmationDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the Modal window popup.
        /// </summary>
        public Command<SfPopupLayout> OpenModalDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the popup relative to a view.
        /// </summary>
        public Command<SfPopupLayout> OpenRelativeDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the full screen popup.
        /// </summary>
        public Command<SfPopupLayout> OpenFullScreenDialog { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the SmallFont is enabled.
        /// </summary>
        public bool SmallFontSwitch
        {
            get
            {
                return this.smallFontSwitch;
            }

            set
            {
                this.smallFontSwitch = value;
                if (value)
                {
                    this.SelectSmallFontSize();
                }

                this.RaisePropertyChanged("SmallFontSwitch");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the NormalFont is enabled.
        /// </summary>
        public bool NormalFontSwitch
        {
            get
            {
                return this.normalFontSwitch;
            }

            set
            {
                this.normalFontSwitch = value;
                if (value)
                {
                    this.SelectNormaFontSize();
                }

                this.RaisePropertyChanged("NormalFontSwitch");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the LargeFont is enabled.
        /// </summary>
        public bool LargeFontSwitch
        {
            get
            {
                return this.largeFontSwitch;
            }

            set
            {
                this.largeFontSwitch = value;
                if (value)
                {
                    this.SelectLargeFontSize();
                }

                this.RaisePropertyChanged("LargeFontSwitch");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Displays the popup as the alert.
        /// </summary>
        /// <param name="popupLayout">Popup to be displayed.</param>
        private void DisplayAlert(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }

        /// <summary>
        /// Displays the popup as the dialog with title.
        /// </summary>
        /// <param name="popupLayout">Popup to be displayed.</param>
        private void DisplayAlertWithTitle(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }

        /// <summary>
        /// Displays the popup as the simple dialog.
        /// </summary>
        /// <param name="popupLayout">Popup to be displayed.</param>
        private void DisplaySimpleDialog(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }

        /// <summary>
        /// Displays the popup as the confirmation dialog.
        /// </summary>
        /// <param name="popupLayout">Popup to be displayed.</param>
        private void DisplayConfirmationDialog(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }

        /// <summary>
        /// Displays the popup as the modal window.
        /// </summary>
        /// <param name="popupLayout">Popup to be displayed.</param>
        private void DisplayModalDialog(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }

        /// <summary>
        /// Displays the dialog relative to the view.
        /// </summary>
        /// <param name="popupLayout">Popup to be displayed.</param>
        private void DisplayDialogRelativeToView(SfPopupLayout popupLayout)
        {
            popupLayout.Show();
        }

        /// <summary>
        /// Displays the full screen popup.
        /// </summary>
        /// <param name="popupLayout">Popup to be displayed.</param>
        private void DisplayFullScreenDialog(SfPopupLayout popupLayout)
        {
            popupLayout.PopupView.IsFullScreen = true;
            popupLayout.Show(true);
        }

        /// <summary>
        /// Sets the ImageSource for the Images.
        /// </summary>
        private void SetBindingImageSource()
        {
        }

        /// <summary>
        /// Selects the small font size.
        /// </summary>
        private void SelectSmallFontSize()
        {
            this.NormalFontSwitch = false;
            this.LargeFontSwitch = false;
        }

        /// <summary>
        /// Selects the normal font size.
        /// </summary>
        private void SelectNormaFontSize()
        {
            this.LargeFontSwitch = false;
            this.SmallFontSwitch = false;
        }

        /// <summary>
        /// Selects the large font size.
        /// </summary>
        private void SelectLargeFontSize()
        {
            this.SmallFontSwitch = false;
            this.NormalFontSwitch = false;
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