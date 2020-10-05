#region Copyright
// <copyright file="RecipientInfoViewModel.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
    /// Represents the view model of data form getting started sample.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RecipientInfoViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the recipient information.
        /// </summary>
        private RecipientInfo recipientInfo;

        /// <summary>
        /// Represents a value indicating whether visible or not.
        /// </summary>
        private bool isVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipientInfoViewModel"/> class.
        /// </summary>
        public RecipientInfoViewModel()
        {
            this.recipientInfo = new RecipientInfo();
            this.isVisible = true;
            this.CommitCommand = new Command<object>(this.OnCommit);
        }

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the recipient information.
        /// </summary>
        public RecipientInfo RecipientInfo
        {
            get { return this.recipientInfo; }
            set { this.recipientInfo = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether visible or not.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }

            set
            {
                this.isVisible = value;
                this.OnPropertyChanged("IsVisible");
            }
        }

        /// <summary>
        /// Gets or sets an ICommand implementation wrapping a commit action.
        /// </summary>
        public Command<object> CommitCommand { get; set; }

        /// <summary>        
        /// Commits the value of the specific editor to corresponding property in the business object.
        /// </summary>
        /// <param name="dataForm">The corresponding DataForm.</param>
        private void OnCommit(object dataForm)
        {
            var dataFormLayout = dataForm as Syncfusion.XForms.DataForm.SfDataForm;
            var isValid = dataFormLayout.Validate();
            dataFormLayout.Commit();
            if (!isValid)
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter valid details", "Ok");
                return;
            }

            App.Current.MainPage.DisplayAlert("Alert", "Money Transferred", "Ok");
            dataFormLayout.IsReadOnly = true;
            this.IsVisible = false;
        }

        /// <summary>
        /// Occurs when property value changes.
        /// </summary>
        /// <param name="propertyName">The corresponding name of the property.</param>
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
