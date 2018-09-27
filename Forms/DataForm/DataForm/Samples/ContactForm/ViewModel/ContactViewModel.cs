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
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using SampleBrowser.Core;

namespace SampleBrowser.SfDataForm
{
    [Preserve(AllMembers = true)]
    public class ListViewGroupingViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ContactInfo> contactsInfo;
        private ContactInfo selectedItem;
        private bool refreshLayout = false;
        private bool isVisible;
        private bool isNewContact;

        #endregion

        #region Constructor

        public ListViewGroupingViewModel()
        {
            GenerateSource(100);
            this.isVisible = true;
            this.RefreshCommand = new Command<object>(this.OnRefreshLayout);
            this.AddCommand = new Command<object>(this.OnAdd);
            this.BackCommand = new Command<object>(this.OnBack);
            this.EditAndDoneCommand = new Command<object>(this.OnEditAndDone);
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public ObservableCollection<ContactInfo> ContactsInfo
        {
            get { return contactsInfo; }
            set { this.contactsInfo = value; }
        }

        public ContactInfo SelectedItem
        {
            get { return this.selectedItem; }
            set
            {
                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
            }         
        }

        public Command<object> RefreshCommand { get; set; }
        public Command<object> AddCommand { get; set; }
        public Command<object> BackCommand { get; set; }
        public Command<object> EditAndDoneCommand { get; set; }
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                this.OnPropertyChanged("IsVisible");
            }
        }

        internal bool IsNewContact
        {
            get { return this.isNewContact; }
            set
            {
                this.isNewContact = value;
                this.OnPropertyChanged("IsNewContact");
            }
        }

        internal bool RefreshLayout
        {
            get { return this.refreshLayout; }
            set { this.refreshLayout = value; }           
        }

        #endregion

        #region ItemSource

        public void GenerateSource(int count)
        {
            ContactsInfoRepository contactRepository = new ContactsInfoRepository();
            contactsInfo = contactRepository.GetContactDetails(count);
        }

        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnRefreshLayout(object dataForm) 
        {
            refreshLayout = true;
            this.IsVisible = false;
            var sfDataForm = dataForm as Syncfusion.XForms.DataForm.SfDataForm;
            sfDataForm.RefreshLayout();
            var grid = sfDataForm.Parent as Grid;   
            grid.RowDefinitions[2].Height = 0;
        }
        
        private void OnAdd(object listView)
        {
			var sflistView = listView as Syncfusion.ListView.XForms.SfListView;
            var contactInfo = new ContactInfo() { ContactImage = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.LabelContactName.png") };
            var viewModel = sflistView.BindingContext as ListViewGroupingViewModel;
            viewModel.SelectedItem = contactInfo as ContactInfo;
            this.refreshLayout = true;                        
            this.IsNewContact = true;
            sflistView.Navigation.PushAsync(new DataFormPage() { BindingContext = sflistView.BindingContext, Title = "Contact Form" });
        }

        private void OnBack(object grid)
        {
            var dataFormGrid = grid as Grid;
            var dataForm = dataFormGrid.FindByName<Syncfusion.XForms.DataForm.SfDataForm>("dataForm");
            var navigation = dataForm.Navigation;
            dataForm = null;
            navigation.PopAsync();
        }

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
                    var viewModel = dataForm.BindingContext as ListViewGroupingViewModel;
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