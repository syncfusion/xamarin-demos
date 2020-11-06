#region Copyright
// <copyright file="ContactListViewModel.cs" company="Syncfusion"> 
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
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using SampleBrowser.Core;
    using Syncfusion.ListView.XForms;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
    /// Represents the view model of the list view in the contact forms.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactListViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Represents a dynamic data collection of the contact information.
        /// </summary>
        private ObservableCollection<ContactInfo> contactsInfo;

        /// <summary>
        /// Represents the selected item of the contact information.
        /// </summary>
        private ContactInfo selectedItem;

        /// <summary>
        /// Represents a value indicating whether to refresh the layout. 
        /// </summary>
        private bool refreshLayout = false;

        /// <summary>
        /// Represents a value indicating whether visible or not. 
        /// </summary>
        private bool isVisible;

        /// <summary>
        /// Represents a value indicating whether the contact is new. 
        /// </summary>
        private bool isNewContact;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactListViewModel"/> class.
        /// </summary>
        public ContactListViewModel()
        {
            this.GenerateSource(100);
            this.isVisible = true;
            this.RefreshCommand = new Command<object>(this.OnRefreshLayout);
            this.AddCommand = new Command<object>(this.OnAdd);
            this.BackCommand = new Command<object>(this.OnBack);
            this.EditAndDoneCommand = new Command<object>(this.OnEditAndDone);
        }

        #endregion

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        /// <summary>
        /// Gets or sets the contact information of the customer.
        /// </summary>
        public ObservableCollection<ContactInfo> ContactsInfo
        {
            get { return this.contactsInfo; }
            set { this.contactsInfo = value; }
        }

        /// <summary>
        /// Gets or sets the selected item in the contacts view.
        /// </summary>
        public ContactInfo SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets or sets an ICommand implementation wrapping a refresh action.
        /// </summary>
        public Command<object> RefreshCommand { get; set; }

        /// <summary>
        /// Gets or sets an ICommand implementation wrapping a add action.
        /// </summary>
        public Command<object> AddCommand { get; set; }

        /// <summary>
        /// Gets or sets an ICommand implementation wrapping a edit and done action.
        /// </summary>
        public Command<object> BackCommand { get; set; }

        /// <summary>
        /// Gets or sets an ICommand implementation wrapping a edit and done action.
        /// </summary>
        public Command<object> EditAndDoneCommand { get; set; }

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
        /// Gets or sets a value indicating whether the contact is new.
        /// </summary>
        internal bool IsNewContact
        {
            get
            {
                return this.isNewContact;
            }

            set
            {
                this.isNewContact = value;
                this.OnPropertyChanged("IsNewContact");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to refresh the layout.
        /// </summary>
        internal bool RefreshLayout
        {
            get { return this.refreshLayout; }
            set { this.refreshLayout = value; }
        }

        #endregion

        #region ItemSource

        /// <summary>
        /// Generates the source of the contact information repository.
        /// </summary>
        /// <param name="count">Represents the number of elements.</param>
        public void GenerateSource(int count)
        {
            ContactsInfoRepository contactRepository = new ContactsInfoRepository();
            this.contactsInfo = contactRepository.GetContactDetails(count);
        }

        #endregion

        /// <summary>
        /// Occurs when property value is changed.
        /// </summary>
        /// <param name="propertyName">Represents the proeprty name.</param>
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Occurs when layout is refreshed.
        /// </summary>
        /// <param name="dataForm">DataForm object.</param>
        private void OnRefreshLayout(object dataForm)
        {
            this.refreshLayout = true;
            this.IsVisible = false;
            var dataFormLayout = dataForm as Syncfusion.XForms.DataForm.SfDataForm;
            dataFormLayout.RefreshLayout();
            var grid = dataFormLayout.Parent as Grid;
            grid.RowDefinitions[2].Height = 0;
        }

        /// <summary>
        /// Occurs when new item is added in list view.
        /// </summary>
        /// <param name="listView">List view object.</param>
        private void OnAdd(object listView)
        {
            var sflistView = listView as Syncfusion.ListView.XForms.SfListView;
            var contactInfo = new ContactInfo()
            {
                ContactImage = new FontImageSource()
                {
                    Glyph = "\ue72a",
                    FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                    Color = Color.Black,
                }
            };
            var viewModel = sflistView.BindingContext as ContactListViewModel;
            viewModel.SelectedItem = contactInfo as ContactInfo;
            this.refreshLayout = true;
            this.IsNewContact = true;
            sflistView.Navigation.PushAsync(new DataFormPage() { BindingContext = sflistView.BindingContext, Title = "Contact Form" });
        }

        /// <summary>
        /// Occurs when back is pressed.
        /// </summary>
        /// <param name="grid">The corresponding layout object.</param>
        private void OnBack(object grid)
        {
            var dataFormGrid = grid as Grid;
            var dataForm = dataFormGrid.FindByName<Syncfusion.XForms.DataForm.SfDataForm>("dataForm");
            var navigation = dataForm.Navigation;
            dataForm = null;
            navigation.PopAsync();
        }

        /// <summary>
        /// Occurs after editing is done.
        /// </summary>
        /// <param name="grid">The corresponding layout object.</param>
        private void OnEditAndDone(object grid)
        {
            var dataFormGrid = grid as Grid;
            var dataForm = dataFormGrid.FindByName<Syncfusion.XForms.DataForm.SfDataForm>("dataForm");
            var editButton = dataFormGrid.FindByName<Button>("editButton");
            var contactLabel = dataFormGrid.FindByName<Button>("contactLabel");
            if (dataForm.IsReadOnly)
            {
                dataForm.IsReadOnly = false;
                editButton.Text = "Done";
            }
            else
            {
                var isValid = dataForm.Validate();
                if (!isValid)
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Please enter valid details", "Ok");
                    return;
                }

                if (contactLabel.Text == "Add Contact")
                {
                    var viewModel = dataForm.BindingContext as ContactListViewModel;
                    viewModel.ContactsInfo.Add(viewModel.SelectedItem);
                }

                editButton.Text = "Edit";
                dataForm.Commit();
                dataForm.IsReadOnly = true;
                var navigation = dataForm.Navigation;
                dataForm = null;
                navigation.PopAsync();
            }
        }
    }
}