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
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfTextInputLayout
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string notes;

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                NotifyPropertyChanged();
            }
        }

        private string dateOfBirth;

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                NotifyPropertyChanged();
            }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                HasError = false;
                NotifyPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                IsEnabled = password.Length >= 5;
                IsPasswordEmpty = false;
                NotifyPropertyChanged();
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                IsMobileNumberEmpty = false;
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
                IsNameEmpty = false;
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
                    DateOfBirth = dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year;
                    NotifyPropertyChanged();
                }
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

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                IsConfirmPasswordEmpty = false;
                NotifyPropertyChanged();
            }
        }

        private bool isNameEmpty;

        public bool IsNameEmpty
        {
            get { return isNameEmpty; }
            set
            {
                isNameEmpty = value;
                NotifyPropertyChanged();
            }
        }

        private bool isMobileNumberEmpty;

        public bool IsMobileNumberEmpty
        {
            get { return isMobileNumberEmpty; }
            set
            {
                isMobileNumberEmpty = value;
                NotifyPropertyChanged();
            }
        }

        private bool isPasswordEmpty;

        public bool IsPasswordEmpty
        {
            get { return isPasswordEmpty; }
            set
            {
                isPasswordEmpty = value;
                NotifyPropertyChanged();
            }
        }

        private bool isConfirmPasswordEmpty;

        public bool IsConfirmPasswordEmpty
        {
            get { return isConfirmPasswordEmpty; }
            set
            {
                isConfirmPasswordEmpty = value;
                NotifyPropertyChanged();
            }
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                NotifyPropertyChanged(nameof(IsEnabled));
            }
        }

        public ICommand ResetCommand { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        public SignUpViewModel()
        {
            SubmitCommand = new Command(SubmitButtonClicked);
            ResetCommand = new Command(ResetButtonClicked);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This method will be called whenever reset button is clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void ResetButtonClicked(object obj)
        {
            Notes = string.Empty;
            Mail = string.Empty;
            DateOfBirth = string.Empty;
            Name = string.Empty;
            PhoneNumber = string.Empty;
            ConfirmPassword = string.Empty;
            Password = string.Empty;
        }

        /// <summary>
        /// This method will be called whenever submit button is clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void SubmitButtonClicked(object obj)
        {
            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsMobileNumberEmpty = string.IsNullOrEmpty(PhoneNumber);
            IsPasswordEmpty = string.IsNullOrEmpty(Password);
            if (!string.IsNullOrEmpty(Password))
            {
                IsPasswordEmpty = Password.Length < 5;
                IsConfirmPasswordEmpty =  !Password.Equals(ConfirmPassword);
            }
            if (string.IsNullOrEmpty(Mail) || !mail.Contains("@") || !mail.Contains("."))
            {
                HasError = true;
            }
            else if (!IsNameEmpty && !IsMobileNumberEmpty && !isPasswordEmpty && !IsConfirmPasswordEmpty)
            {
                Application.Current.MainPage.DisplayAlert("Success", "Your account has been created successfully", "Ok");
            }
        }
    }
}