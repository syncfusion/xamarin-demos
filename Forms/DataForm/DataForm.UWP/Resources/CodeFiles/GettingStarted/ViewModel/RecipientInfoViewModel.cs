#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataForm
{
    [Preserve(AllMembers=true)]
    public class RecipientInfoViewModel : INotifyPropertyChanged
    {
        private RecipientInfo recipientInfo;
        private bool isVisible;       

        public RecipientInfoViewModel()
        {
            this.recipientInfo = new RecipientInfo();
            isVisible = true;
            this.CommitCommand = new Command<object>(OnCommit);           
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public RecipientInfo RecipientInfo
        {
            get { return this.recipientInfo; }
            set { this.recipientInfo = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                this.OnPropertyChanged("IsVisible");
            }
        }
        public Command<object> CommitCommand { get; set; }      

        private void OnCommit(object dataForm)
        {
            var sfDataForm = dataForm as Syncfusion.XForms.DataForm.SfDataForm;
            var isValid = sfDataForm.Validate();            
            sfDataForm.Commit();
            if (!isValid)
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter valid details", "Ok");
                return;
            }

            App.Current.MainPage.DisplayAlert("Alert", "Money Transferred", "Ok");
            sfDataForm.IsReadOnly = true;
            IsVisible = false;
        }     

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
