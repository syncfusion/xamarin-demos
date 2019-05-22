#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfTextInputLayout
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        private string cVVNumber;

        public string CVVNumber
        {
            get { return cVVNumber; }
            set
            {
                var maxCharLength = 3;
                if (value.Length > maxCharLength)
                {
                    cVVNumber = value.Substring(0, maxCharLength);
                }
                else
                {
                    cVVNumber = value;
                }
                HasError = false;
                NotifyPropertyChanged();
            }
        }

        private string validityDate;

        public string ValidityDate
        {
            get { return validityDate; }
            set
            {
                validityDate = value;
                NotifyPropertyChanged();
            }
        }

        private bool hasError;

        public bool HasError
        {
            get { return hasError; }
            set
            {
                hasError = value;
                NotifyPropertyChanged();
            }
        }

        private object cardNumber;

        public object CardNumber
        {
            get { return cardNumber; }
            set
            {
                cardNumber = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime dateTime = DateTime.Now.Date;

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    ValidityDate = dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand PaymentCommand { get; private set; }

        public PaymentViewModel()
        {
            PaymentCommand = new Command(PaymentButtonClicked);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This method will be called whenever payment button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void PaymentButtonClicked(object obj)
        {
            var card = CardNumber as string; 

            if (string.IsNullOrEmpty(CVVNumber) || CVVNumber.Length != 3)
            {
                HasError = true;
            }
            else if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(card) || string.IsNullOrEmpty(CVVNumber) || string.IsNullOrEmpty(ValidityDate))
            {
                Application.Current.MainPage.DisplayAlert("Alert", "Please fill all the fields", "Ok");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Success", "Payment done successfully", "Ok");
            }
        }
    }
}
