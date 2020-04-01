#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Xamarin.Forms;
using Syncfusion.XForms.ProgressBar;
using System.Globalization;
using System.Diagnostics;
using Syncfusion.XForms.ComboBox;

namespace SampleBrowser.SfStepProgressBar
{
    public partial class UserRegistration : SampleView
    {
        public List<string> QuestionOne = new List<string>();
        public List<string> QuestionTwo = new List<string>();
        bool isStatuUpdate = false;
        string[] profilePage = new string[] { "User.png", "User.png", "UserSelection.png", };
        string[] accountSetUpPage = new string[] { "AccountSelection.png", "AccountWhite.png", "AccountWhite.png" };
        string[] personalPage = new string[] { "Personal.png", "PersonalSelection.png", "PersonalWhite.png" };
        int index = 0;
        public UserRegistration()
        {
            InitializeComponent();
            QuestionOne.Add("What was the name of your first pet ?");
            QuestionOne.Add("What was the first thing you learned to cook ?");
            QuestionTwo.Add("What was the first film saw in the theater ?");
            QuestionTwo.Add("What was the last name of the favorite teacher ?");
            comboBox1.ComboBoxSource = QuestionOne;
            comboBox2.ComboBoxSource = QuestionTwo;
            SetButtonStyles();
            AssignStepperIndicatorProperties();
            (stepProgressBar.Children[0] as StepView).Status = StepStatus.InProgress;
            datePicker.DateSelected += DatePicker_DateSelected;
            datePicker.Unfocused += DatePicker_Unfocused;
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DOBEntryField.Text = e.NewDate.Date.ToString("dd/MM/yyyy");
        }

        private void DatePicker_Unfocused(object sender, FocusEventArgs e)
        {
            DOBEntryField.Text = (e.VisualElement as DatePicker).Date.ToString("dd/MM/yyyy");
        }

        private void SetButtonStyles()
        {
            ProfilePageNextButton.BackgroundColor = Color.FromHex("#FF007AFF");
            AccountsPageNextButton.BackgroundColor = Color.FromHex("#FF007AFF");
            AccountsPagePreviousButton.BackgroundColor = Color.FromHex("#FFFFFFFF");
            AccountsPagePreviousButton.TextColor = Color.FromHex("#434343");
            AccountsPagePreviousButton.BorderColor = Color.FromHex("EAEAEA");
            PersonalPageNextButton.BackgroundColor = Color.FromHex("#FF007AFF");
            PersonalPagePreviousButton.BackgroundColor = Color.FromHex("#FFFFFFFF");
            PersonalPagePreviousButton.TextColor = Color.FromHex("#434343");
            PersonalPagePreviousButton.BorderColor = Color.FromHex("EAEAEA");
            NameEntryField.PlaceholderColor = Color.FromHex("#FF949494");
            EmailEntryField.PlaceholderColor = Color.FromHex("#FF949494");
            PasswordEntryField.PlaceholderColor = Color.FromHex("#FF949494");
            ConfirmPasswordField.PlaceholderColor = Color.FromHex("#FF949494");
            PhoneNumberEntryField.PlaceholderColor = Color.FromHex("#FF949494");
            NameEntryField.FontSize = 14;
            EmailEntryField.FontSize = 14;
            PasswordEntryField.FontSize = 14;
            ConfirmPasswordField.FontSize = 14;
            PhoneNumberEntryField.FontSize = 14;
            DOBEntryField.FontSize = 14;
        }

        void NextButton_Clicked(object sender, System.EventArgs e)
        {
            if (index < 2)
            {
                index++;
            }
            SetVisibility();
            if (isStatuUpdate)
            {
                (stepProgressBar.Children[index] as StepView).Status = StepStatus.InProgress;
                this.UpdateImage(index);
                isStatuUpdate = false;
            }
        }

        void PreviousButton_Clicked(object sender, System.EventArgs e)
        {
            if (index > 0)
            {
                index--;
            }
            SetVisibility();
            if (isStatuUpdate)
            {
                (stepProgressBar.Children[index] as StepView).Status = StepStatus.InProgress;
                this.UpdateImage(index);
                isStatuUpdate = false;
            }
        }

        private void SetVisibility()
        {
            if (index == 0)
            {
                AccountSetupPage.IsVisible = true;
                SecurityQuestionPage.IsVisible = false;
                ProfilePage.IsVisible = false;
                isStatuUpdate = true;
            }
            else if (index == 1 && ProfilePageNextButton.IsEnabled)
            {
                AccountSetupPage.IsVisible = false;
                ProfilePage.IsVisible = false;
                SecurityQuestionPage.IsVisible = true;
                isStatuUpdate = true;
            }
            else if (index == 2 && AccountsPageNextButton.IsEnabled)
            {
                AccountSetupPage.IsVisible = false;
                SecurityQuestionPage.IsVisible = false;
                ProfilePage.IsVisible = true;
                isStatuUpdate = true;
            }
        }

        void AssignStepperIndicatorProperties()
        {
            stepProgressBar.ProgressAnimationDuration = 0;
            stepProgressBar.NotStartedStepStyle.MarkerSize = 29;
            stepProgressBar.InProgressStepStyle.MarkerSize = 29;
            stepProgressBar.CompletedStepStyle.MarkerSize = 29;
            stepProgressBar.NotStartedStepStyle.MarkerContentSize = 15;
            stepProgressBar.InProgressStepStyle.MarkerContentSize = 15;
            stepProgressBar.CompletedStepStyle.MarkerContentSize = 15;
            stepProgressBar.NotStartedStepStyle.MarkerFillColor = Color.FromHex("#DADADA");
            stepProgressBar.NotStartedStepStyle.MarkerStrokeColor = Color.FromHex("#DADADA");
            stepProgressBar.InProgressStepStyle.MarkerFillColor = Color.FromHex("#FFFFFF");
            stepProgressBar.CompletedStepStyle.MarkerFillColor = Color.FromHex("#007AFF");
            stepProgressBar.InProgressStepStyle.FontColor = Color.FromHex("#007AFF");
            stepProgressBar.CompletedStepStyle.FontColor = Color.FromHex("#007AFF");
            stepProgressBar.StepTapped += Stepprogressbar_StepTapped;
        }

        void Stepprogressbar_StepTapped(object sender, StepTappedEventArgs e)
        {
            if (e.Index == 1 && !ProfilePageNextButton.IsEnabled)
            {
                return;
            }
            else if (e.Index == 2 && !AccountsPageNextButton.IsEnabled)
            {
                return;
            }

            index = e.Index;
            SetVisibility();
            if (isStatuUpdate)
            {
                e.Item.Status = StepStatus.InProgress;
                this.UpdateImage(index);
                isStatuUpdate = false;
            }
        }

        private void DOBEntryField_Focused(object sender, FocusEventArgs e)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                datePicker.IsVisible = true;
                datePicker.Focus();
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                datePicker.Unfocus();
                datePicker.Focus();
            });

            DOBEntryField.Unfocus();
        }

        private void Done(object sender, EventArgs e)
        {
            index = 0;
            (stepProgressBar.Children[index] as StepView).Status = StepStatus.InProgress;
            this.UpdateImage(index);
            SetVisibility();
            isStatuUpdate = false;
            male.IsChecked = false;
            female.IsChecked = false;
            NameEntryField.Text = null;
            EmailEntryField.Text = null;
            PasswordEntryField.Text = null;
            ConfirmPasswordField.Text = null;
            question1.Text = null;
            question2.Text = null;
            PhoneNumberEntryField.Text = null;
            DOBEntryField.Text = null;
            ProfilePageNextButton.IsEnabled = AccountSetupGridValidation();
            AccountsPageNextButton.IsEnabled = SecurityQuestionGridValidation();
            PersonalPageNextButton.IsEnabled = ProfilePageValidation();
        }
        void UpdateImage(int index)
        {
            if (index == 0)
            {
                AccountIcon.Color = Color.FromHex("#007aff");
                SecurityIcon.Color = Color.FromHex("868686");
                PersonalIcon.Color = Color.FromHex("868686");
            }
            else if (index == 1)
            {
                AccountIcon.Color = Color.FromHex("#ffffff");
                SecurityIcon.Color = Color.FromHex("#007aff");
                PersonalIcon.Color = Color.FromHex("868686");
            }
            else if (index == 2)
            {
                AccountIcon.Color = Color.FromHex("#ffffff");
                SecurityIcon.Color = Color.FromHex("#ffffff");
                PersonalIcon.Color = Color.FromHex("007aff");
            }
        }

        private void EntryField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AccountSetupPage.IsVisible)
            {
                ProfilePageNextButton.IsEnabled = AccountSetupGridValidation();
            }
            else if (SecurityQuestionPage.IsVisible)
            {
                AccountsPageNextButton.IsEnabled = SecurityQuestionGridValidation();
            }
            else if(ProfilePage.IsVisible)
            {
                PersonalPageNextButton.IsEnabled = ProfilePageValidation();
            }
        }

        private bool AccountSetupGridValidation()
        {
            bool isEnable = false;
            if (EmailEntryField.Text != null && PasswordEntryField.Text != null && ConfirmPasswordField.Text != null && PasswordEntryField.Text == ConfirmPasswordField.Text)
            {
                isEnable = true;
            }
            else
            {
                isEnable = false;
            }

            return isEnable;
        }

        private bool SecurityQuestionGridValidation()
        {
            bool isEnable = false;
            if (question1.Text != null && question2.Text != null)
            {
                isEnable = true;
            }
            else
            {
                isEnable = false;
            }
            return isEnable;
        }

        private bool ProfilePageValidation()
        {
            bool isEnable = false;
            if (NameEntryField.Text != null && PhoneNumberEntryField.Text != null && DOBEntryField.Text != null)
            {
                isEnable = true;
            }
            else
            {
                isEnable = false;
            }
            return isEnable;
        }

        private void ComboBox1_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            Syncfusion.XForms.ComboBox.SfComboBox comboBox = sender as Syncfusion.XForms.ComboBox.SfComboBox;
            if (comboBox.SelectedIndex >= 0)
            {
                question1.IsEnabled = true;
            }
            else
            {
                question1.IsEnabled = false;
            }
        }
        private void ComboBox2_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            Syncfusion.XForms.ComboBox.SfComboBox comboBox = sender as Syncfusion.XForms.ComboBox.SfComboBox;
            if (comboBox.SelectedIndex >= 0)
            {
                question2.IsEnabled = true;
            }
            else
            {
                question2.IsEnabled = false;
            }
        }
    }  
}