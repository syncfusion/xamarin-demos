#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using AutoComplete = Syncfusion.SfAutoComplete.XForms.SfAutoComplete;
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

		private string gender;

		public string Gender
		{
			get { return gender; }
			set
			{
				gender = value;
				IsGenderEmpty = false;
				NotifyPropertyChanged();
			}
		}

		private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                IsAddressEmpty = false;
                NotifyPropertyChanged();
            }
        }

        private List<string> state;

        public List<string> State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged();
            }
        }

        private string selectedState;
        public string SelectedState
        {
            get { return selectedState; }
            set
            {
                selectedState = value;
                IsStateEmpty = false;
                NotifyPropertyChanged();
            }
        }

		private DateTime dateTime = new DateTime(1990, 01, 01);

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

		private bool isGenderEmpty;

		public bool IsGenderEmpty
		{
			get { return isGenderEmpty; }
			set
			{
				isGenderEmpty = value;
				NotifyPropertyChanged();
			}
		}

		private bool isAddressEmpty;

        public bool IsAddressEmpty
        {
            get { return isAddressEmpty; }
            set
            {
                isAddressEmpty = value;
                NotifyPropertyChanged();
            }
        }

        private bool isStateEmpty;

        public bool IsStateEmpty
        {
            get { return isStateEmpty; }
            set
            {
                isStateEmpty = value;
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

        private List<int> fontSizeCollection = new List<int>
        {
            12,
            14,
            16
        };


        public List<int> FontSizeCollection => fontSizeCollection;

        private int containerLabelFontSize = 16;

        public int ContainerLabelFontSize
        {
            get
            {
                return containerLabelFontSize;
            }
            set
            {
                containerLabelFontSize = value;
                NotifyPropertyChanged();
            }
        }
 
        private int selectedFontSize = 2;
        public int SelectedFontSize
        {
            get
            {
                return selectedFontSize;
            }
            set
            {
                selectedFontSize = value;
                NotifyPropertyChanged();
                ContainerLabelFontSize = FontSizeCollection[selectedFontSize];
            }
        }

        List<FontAttributes> fontAttributeCollection = new List<FontAttributes>
        {
            FontAttributes.None,
            FontAttributes.Bold,
            FontAttributes.Italic
        };
        public List<FontAttributes> FontAttributeCollection => fontAttributeCollection;

        private FontAttributes containerLabelFontAttribute;
        public FontAttributes ContainerLabelFontAttribute
        {
            get
            {
                return containerLabelFontAttribute;
            }
            set
            {
                containerLabelFontAttribute = value;
                NotifyPropertyChanged();
            }
        }

        private int selectedFontAttribute;
        public int SelectedFontAttribute
        {
            get
            {
                return selectedFontAttribute;
            }
            set
            {
                selectedFontAttribute = value;
                NotifyPropertyChanged();
                ContainerLabelFontAttribute = FontAttributeCollection[selectedFontAttribute];
            }
        }
        List<string> fontFamilyCollection = new List<string>
        {
            "Default",
            "Lobster-Regular"
        };
        public List<string> FontFamilyCollection => fontFamilyCollection;
        
        private string containerLabelFontFamily;
        public string ContainerLabelFontFamily
        {
            get
            {
                return containerLabelFontFamily;
            }
            set
            {
                containerLabelFontFamily = value;
                NotifyPropertyChanged();
            }
        }
        private int selectedFontFamily;

        public int SelectedFontFamily
        {
            get
            {
                return selectedFontFamily;
            }
            set
            {
                selectedFontFamily = value;
                NotifyPropertyChanged();
                ContainerLabelFontFamily = FontFamilyCollection[selectedFontFamily];
            }
        }

        public ICommand ResetCommand { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        public SignUpViewModel()
        {
            SubmitCommand = new Command<string>(SubmitButtonClicked);
            ResetCommand = new Command<AutoComplete>(ResetButtonClicked);

            State = new List<string>();
            State.Add("Alabama");
            State.Add("Alaska");
            State.Add("Arizona");
            State.Add("California");
            State.Add("Colorado");
            State.Add("Delaware");
            State.Add("Florida");
            State.Add("Georgia");
            State.Add("Hawaii");
            State.Add("Lowa");
            State.Add("Maine");
            State.Add("MaryLand");
            State.Add("Montana");
            State.Add("Nevada");
            State.Add("New Jersey");
            State.Add("New Mexico");
            State.Add("New York");
            State.Add("Washington");

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
			Gender = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            ConfirmPassword = string.Empty;
            Password = string.Empty;
            SelectedState = string.Empty;
        }

        /// <summary>
        /// This method will be called whenever submit button is clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void SubmitButtonClicked(object obj)
        {
            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsGenderEmpty = string.IsNullOrEmpty(Gender);
			IsMobileNumberEmpty = string.IsNullOrEmpty(PhoneNumber);
            IsAddressEmpty = string.IsNullOrEmpty(Address);
            IsPasswordEmpty = string.IsNullOrEmpty(Password);
            IsStateEmpty = string.IsNullOrEmpty(SelectedState);
         
            if (!string.IsNullOrEmpty(Password))
            {
                IsPasswordEmpty = Password.Length < 5;
                IsConfirmPasswordEmpty =  !Password.Equals(ConfirmPassword);
            }
            if (string.IsNullOrEmpty(Mail) || !mail.Contains("@") || !mail.Contains("."))
            {
                HasError = true;
            }
            else if (!IsNameEmpty && !IsMobileNumberEmpty && !IsAddressEmpty && !IsStateEmpty && !isPasswordEmpty && !IsConfirmPasswordEmpty && !IsGenderEmpty)
            {
                Application.Current.MainPage.DisplayAlert("Success", "Your account has been created successfully", "Ok");
            }
        }
    }
}