#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
            this.OpenAlertDialog = new Command<ScrollView>(this.DisplayAlert);
            this.OpenAlertWithTitleDialog = new Command<ScrollView>(this.DisplayAlertWithTitle);
            this.OpenSimpleDialog = new Command<ScrollView>(this.DisplaySimpleDialog);
            this.OpenConfirmationDialog = new Command<ScrollView>(this.DisplayConfirmationDialog);
            this.OpenModalDialog = new Command<ScrollView>(this.DisplayModalDialog);
            this.OpenRelativeDialog = new Command<ScrollView>(this.DisplayDialogRelativeToView);
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
        public Command<ScrollView> OpenAlertDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the AlertDialog popup with title. 
        /// </summary>
        public Command<ScrollView> OpenAlertWithTitleDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the simple dialog. 
        /// </summary>
        public Command<ScrollView> OpenSimpleDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the confirmation dialog.
        /// </summary>
        public Command<ScrollView> OpenConfirmationDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the Modal window popup.
        /// </summary>
        public Command<ScrollView> OpenModalDialog { get; set; }

        /// <summary>
        /// Gets or sets the command for opening the popup relative to a view.
        /// </summary>
        public Command<ScrollView> OpenRelativeDialog { get; set; }

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

        /// <summary>
        /// Gets or sets the source for the AddAccount Image.
        /// </summary>
        public ImageSource AddAccountImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the UserAccount Image.
        /// </summary>
        public ImageSource UserAccountImage { get; set; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Displays the popup as the alert.
        /// </summary>
        /// <param name="parentLayout">The parent layout in the view.</param>
        private void DisplayAlert(ScrollView parentLayout)
        {
            ((parentLayout.Parent as SampleView).Resources["AlertDialog"] as SfPopupLayout).Show();
        }

        /// <summary>
        /// Displays the popup as the dialog with title.
        /// </summary>
        /// <param name="parentLayout">The parent layout in the view.</param>
        private void DisplayAlertWithTitle(ScrollView parentLayout)
        {
            ((parentLayout.Parent as SampleView).Resources["AlertWithTitleDialog"] as SfPopupLayout).Show();
        }

        /// <summary>
        /// Displays the popup as the simple dialog.
        /// </summary>
        /// <param name="parentLayout">The parent layout in the view.</param>
        private void DisplaySimpleDialog(ScrollView parentLayout)
        {
            ((parentLayout.Parent as SampleView).Resources["SimpleDialog"] as SfPopupLayout).Show();
        }

        /// <summary>
        /// Displays the popup as the confirmation dialog.
        /// </summary>
        /// <param name="parentLayout">The parent layout in the view.</param>
        private void DisplayConfirmationDialog(ScrollView parentLayout)
        {
            ((parentLayout.Parent as SampleView).Resources["ConfirmationDialog"] as SfPopupLayout).Show();
        }

        /// <summary>
        /// Displays the popup as the modal window.
        /// </summary>
        /// <param name="parentLayout">The parent layout in the view.</param>
        private void DisplayModalDialog(ScrollView parentLayout)
        {
            ((parentLayout.Parent as SampleView).Resources["ModalWindow"] as SfPopupLayout).Show();
        }

        /// <summary>
        /// Displays the dialog relative to the view.
        /// </summary>
        /// <param name="parentLayout">The parent layout in the view.</param>
        private void DisplayDialogRelativeToView(ScrollView parentLayout)
        {
            ((parentLayout.Parent as SampleView).Resources["RelativeDialog"] as SfPopupLayout).Show();
        }

        /// <summary>
        /// Sets the ImageSource for the Images.
        /// </summary>
        private void SetBindingImageSource()
        {
#if COMMONSB
                this.AddAccountImage = ImageSource.FromResource(
                "SampleBrowser.Images.AddAccountImage.png",
                typeof(DialogViewModel).GetTypeInfo().Assembly);
#else
            this.AddAccountImage = ImageSource.FromResource(
            "SampleBrowser.SfPopupLayout.Images.AddAccountImage.png",
            typeof(GettingStartedViewModel).GetTypeInfo().Assembly);
#endif
#if COMMONSB
                this.UserAccountImage = ImageSource.FromResource(
                "SampleBrowser.Images.UserAccountImage.png",
                typeof(DialogViewModel).GetTypeInfo().Assembly);
#else
            this.UserAccountImage = ImageSource.FromResource(
            "SampleBrowser.SfPopupLayout.Images.UserAccountImage.png",
            typeof(GettingStartedViewModel).GetTypeInfo().Assembly);
#endif
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
