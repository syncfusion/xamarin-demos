#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private Color backgroundColor;

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set 
            {
                backgroundColor = value;
                NotifyPropertyChanged();
            }

        }

        private Color focusedColor;

        public Color FocusedColor
        {
            get { return focusedColor; }
            set
            {
                focusedColor = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Color> colors;

        public ObservableCollection<Color> Colors
        {
            get { return colors; }
            set { colors = value; }
        }


        private bool enableHintAlwaysFloated;

        public bool EnableHintAlwaysFloated
        {
            get { return enableHintAlwaysFloated; }
            set
            {
                enableHintAlwaysFloated = value;
                NotifyPropertyChanged();
            }
        }

        private double cornerRadius = 4;

        public double CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = Math.Round(value);
                NotifyPropertyChanged();
            }
        }

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

        private double amount;

        public double Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                NotifyPropertyChanged();
            }
        }


        private string expiredMonth;

        public string ExpiredMonth
        {
            get { return expiredMonth; }
            set
            {
                expiredMonth = value;
                IsMonthEmpty = false;
                NotifyPropertyChanged();
            }
        }

        private string expiredYear;

        public string ExpiredYear
        {
            get { return expiredYear; }
            set
            {
                expiredYear = value;
                IsYearEmpty = false;
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

        private List<string> month;

        public List<string> Month
        {
            get { return month; }
            set
            {
                month = value;
                NotifyPropertyChanged();
            }
        }

        private List<string> year;

        public List<string> Year
        {
            get { return year; }
            set
            {
                year = value;
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

        private bool isMonthEmpty;

        public bool IsMonthEmpty
        {
            get { return isMonthEmpty; }
            set
            {
                isMonthEmpty = value;
                NotifyPropertyChanged();
            }
        }

        private bool isYearEmpty;

        public bool IsYearEmpty
        {
            get { return isYearEmpty; }
            set
            {
                isYearEmpty = value;
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

        public ICommand PaymentCommand { get; private set; }

        public PaymentViewModel()
        {
            PaymentCommand = new Command<string>(PaymentButtonClicked);

            colors = new ObservableCollection<Color>
            {
                Color.FromUint(0x0A000000),
                Color.FromHex("#b5cdf4"),
                Color.FromHex("#fcc7ee")
            };

            Month = new List<string>();

            for(int i = 1; i<=12; i++)
            {
                if(i <= 9)
                {
                    Month.Add("0" + i);
                }
                else
                {
                    Month.Add(i.ToString());
                }
            }

            Year = new List<string>();

            for(int i=19; i<=40; i++)
            {
                Year.Add(i.ToString());
            }

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

            if(string.IsNullOrEmpty(ExpiredMonth))
            {
                IsMonthEmpty = true;
            }

            if(string.IsNullOrEmpty(ExpiredYear))
            {
                IsYearEmpty = true;
            }

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(card) || string.IsNullOrEmpty(CVVNumber) || string.IsNullOrEmpty(ExpiredMonth) || string.IsNullOrEmpty(ExpiredYear))
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
