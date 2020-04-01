#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.MaskedEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.Editors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfMaskedEdit
{
    public partial class MaskedEdit_Default : SampleView
    {
        public MaskedEdit_Default()
        {
            InitializeComponent();
            buttonaStack.Padding = new Thickness(0, 20, 0, 0);
            OptionView();

        }

        public void OptionView()
        {
            double height = Bounds.Height;
            lblToAccountError.IsVisible = false;
            ErrorToAccount.IsVisible = false;
            lblAmountError.IsVisible = false;
            ErrorAmount.IsVisible = false;
            lblEmailError.IsVisible = false;
            ErrorEmail.IsVisible = false;
            lblPhoneError.IsVisible = false;
            ErrorPhone.IsVisible = false;

            sfToAccount.MaskInputRejected += SfToAccount_MaskInputRejected;
            sfToAccount.ValueChanged += SfToAccount_ValueChanged;

            sfAmount.MaskInputRejected += SfAmount_MaskInputRejected;
            sfAmount.ValueChanged += SfAmount_ValueChanged;

            sfEmail.MaskInputRejected += SfEmail_MaskInputRejected;
            sfEmail.ValueChanged += SfEmail_ValueChanged;

            sfPhone.MaskInputRejected += SfPhone_MaskInputRejected;
            sfPhone.ValueChanged += SfPhone_ValueChanged;
            //Toggle button
            hidePromptToggle.Toggled += ToggleChanged;

            localePicker.Items.Add("United States");
            localePicker.Items.Add("United Kingdom");
            localePicker.Items.Add("Japan");
            localePicker.Items.Add("France");
            localePicker.Items.Add("Italy");
            localePicker.SelectedIndexChanged += localePicker_Changed;
            localePicker.SelectedIndex = 0;

            validationPicker.Items.Add("Lost Focus");
            validationPicker.Items.Add("Key Press");
            validationPicker.SelectedIndexChanged += ValidationPicker_SelectedIndexChanged;
            validationPicker.SelectedIndex = 1;

            if (Device.RuntimePlatform == Device.UWP)
            {
                visibilityStack.HeightRequest = 0;
                visibilityStack.IsVisible = false;
             }
           else
            {
                visibilityPicker.Items.Add("Never");
                visibilityPicker.Items.Add("While Editing");
                visibilityPicker.SelectedIndexChanged += VisibilityPicker_SelectedIndexChanged;
                visibilityPicker.SelectedIndex = 1;
           }

            promptPicker.Items.Add("_");
            promptPicker.Items.Add("*");
            promptPicker.Items.Add("~");
            promptPicker.SelectedIndexChanged += PromptPicker_SelectedIndexChanged;
            promptPicker.SelectedIndex = 0;


            //Device Settings
            if (Device.RuntimePlatform == Device.iOS)
            {
                sfToAccount.HeightRequest = 30;
                sfDesc.HeightRequest = 30;
                sfAmount.HeightRequest = 30;
                sfPhone.HeightRequest = 30;
                sfEmail.HeightRequest = 30;

                lblHidePromt.VerticalOptions = LayoutOptions.End;
                lblPrompt.VerticalOptions = LayoutOptions.End;
                column1.Width = new GridLength(200, GridUnitType.Absolute);

                lblToAccount.TextColor = Color.FromHex("#535359");
                lblDesc.TextColor = Color.FromHex("#535359");
                lblAmount.TextColor = Color.FromHex("#535359");
                lblEmail.TextColor = Color.FromHex("#535359");
                lblPhone.TextColor = Color.FromHex("#535359");

                submitButton.BackgroundColor = Color.FromHex("#2196f3");
                submitButton.TextColor = Color.White;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                submitButton.BackgroundColor = Color.FromHex("#2196f3");
                submitButton.CornerRadius = 1;
                submitButton.BorderWidth = 0;
                submitButton.TextColor = Color.White;
                submitButton.FontFamily = "Roboto";
                pickerLayout1.Padding = new Thickness(-2, 0, 0, 0);
                pickerLayout2.Padding = new Thickness(-2, 0, 0, 0);
                lblAmount.HeightRequest = 25;
                lblToAccount.HeightRequest = 25;
                lblDesc.HeightRequest = 25;
                lblEmail.HeightRequest = 25;
                lblPhone.HeightRequest = 25;
                sfToAccount.HeightRequest = 45;

                maskEdit1.Padding = new Thickness(-3, -10, 0, 0);
                maskEdit2.Padding = new Thickness(-3, -10, 0, 0);
                maskEdit3.Padding = new Thickness(-3, -10, 0, 0);
                maskEdit4.Padding = new Thickness(-3, -10, 0, 0);
                maskEdit5.Padding = new Thickness(-3, -10, 0, 0);

                sfToAccount.Margin = new Thickness(0, 0, 0, 0);
                sfDesc.Margin = new Thickness(0, 0, 0, 0);
                sfAmount.Margin = new Thickness(0, 0, 0, 0);
                sfPhone.Margin = new Thickness(0, 0, 0, 0);
                sfEmail.Margin = new Thickness(0, 0, 0, 0);

            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                submitButton.FontSize = 16;
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    sfToAccount.HeightRequest = 40;
                    sfDesc.HeightRequest = 40;
                    sfAmount.HeightRequest = 40;
                    sfPhone.HeightRequest = 40;
                    sfEmail.HeightRequest = 40;

                    sfToAccount.FontSize = 23;
                    sfDesc.FontSize = 23;
                    sfAmount.FontSize = 23;
                    sfPhone.FontSize = 23;
                    sfEmail.FontSize = 23;
                    
                    submitButton.HeightRequest = 35;

                    sfToAccount.WidthRequest = 300;
                    sfDesc.WidthRequest = 300;
                    sfAmount.WidthRequest = 300;
                    sfPhone.WidthRequest = 300;
                    sfEmail.WidthRequest = 300;


                    sfToAccount.WatermarkFontSize = 20;
                    sfDesc.WatermarkFontSize = 20;
                    sfAmount.WatermarkFontSize = 20;
                    sfPhone.WatermarkFontSize = 20;
                    sfEmail.WatermarkFontSize = 20;

                    sampleLayout.HorizontalOptions = LayoutOptions.Start;
                    hidePromptToggle.HorizontalOptions = LayoutOptions.End;
                    localePicker.HorizontalOptions = LayoutOptions.Start;
                    localePicker.WidthRequest = 320.0;
                    validationPicker.HorizontalOptions = LayoutOptions.Start;
                    validationPicker.WidthRequest = 320.0;
                    promptPicker.WidthRequest = 65.0;
                }
                else
                {
                    sfToAccount.HeightRequest = 35;
                    sfDesc.HeightRequest = 35;
                    sfAmount.HeightRequest = 35;
                    sfPhone.HeightRequest = 35;
                    sfEmail.HeightRequest = 35;

                    sfToAccount.FontSize = 18;
                    sfDesc.FontSize = 18;
                    sfAmount.FontSize = 18;
                    sfPhone.FontSize = 18;
                    sfEmail.FontSize = 18;

                    sfToAccount.WatermarkFontSize = 18;
                    sfDesc.WatermarkFontSize = 18;
                    sfAmount.WatermarkFontSize = 18;
                    sfPhone.WatermarkFontSize = 18;
                    sfEmail.WatermarkFontSize = 18;

                    hidePromptToggle.HorizontalOptions = LayoutOptions.End;
                    column2.Width = new GridLength(1, GridUnitType.Star);
                    promptPicker.WidthRequest = 65.0;
                    optionLayout.Padding = new Thickness(10, 0, 0, 0);
                }
            }
        }

        private void VisibilityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string visibility = (sender as Picker).SelectedItem.ToString();
            if (visibility == "Never")
            {
                sfToAccount.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                sfDesc.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                sfAmount.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                sfEmail.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                sfPhone.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
            }
            else
            {
                sfToAccount.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                sfDesc.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                sfAmount.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                sfEmail.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                sfPhone.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
            }
        }

        private void SfPhone_ValueChanged(object sender, Syncfusion.XForms.MaskedEdit.ValueChangedEventArgs e)
        {
            HideError(lblPhoneError, ErrorPhone, row9);
        }

        private void SfPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ShowError(lblPhoneError, ErrorPhone, row9, e.RejectionHint);
        }

        private void SfEmail_ValueChanged(object sender, Syncfusion.XForms.MaskedEdit.ValueChangedEventArgs e)
        {
            HideError(lblEmailError, ErrorEmail, row7);
        }

        private void SfEmail_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ShowError(lblEmailError, ErrorEmail, row7, e.RejectionHint);
        }

        private void SfAmount_ValueChanged(object sender, Syncfusion.XForms.MaskedEdit.ValueChangedEventArgs e)
        {
            HideError(lblAmountError, ErrorAmount, row5);
        }

        private void SfAmount_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ShowError(lblAmountError, ErrorAmount, row5, e.RejectionHint);
        }

        private void SfToAccount_ValueChanged(object sender, Syncfusion.XForms.MaskedEdit.ValueChangedEventArgs e)
        {
            HideError(lblToAccountError, ErrorToAccount, row2);
        }
        private void SfToAccount_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ShowError(lblToAccountError, ErrorToAccount, row2, e.RejectionHint);
        }
        private void HideError(Label label, StackLayout stacklayout, RowDefinition row)
        {
                stacklayout.IsVisible = false;
                label.IsVisible = false;
                label.Text = "";
                row.Height = new GridLength(0, GridUnitType.Absolute);
        }
        private void ShowError(Label label, StackLayout stacklayout, RowDefinition row, MaskedTextResultHint hint)
        {
                string hintText = GetRejectionHintText(hint);
                if (!string.IsNullOrEmpty(hintText))
                {
                    stacklayout.IsVisible = true;
                    label.IsVisible = true;
                    label.Text = hintText;
                    row.Height = new GridLength(1, GridUnitType.Auto);
                }
        }
        private string GetRejectionHintText(MaskedTextResultHint hint)
        {
            string hintText = string.Empty;
            switch(hint)
            {
                case MaskedTextResultHint.AlphanumericCharacterExpected:
                    hintText = "Invalid character!";
                    break;
                case MaskedTextResultHint.DigitExpected:
                    hintText = "Invalid character!";
                    break;
                case MaskedTextResultHint.LetterExpected:
                    hintText = "Invalid character!";
                    break;
                case MaskedTextResultHint.SignedDigitExpected:
                    hintText = "Invalid character!";
                    break;
                //case MaskedTextResultHint.UnavailableEditPosition:
                //    hintText = "Invalid typed character!";
                //    break;
            }
            return hintText;
        }
        private void PromptPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (promptPicker.SelectedIndex)
            {
                case 1:
                    {
                        sfToAccount.PromptChar = '*';
                        sfDesc.PromptChar = '*';
                        sfAmount.PromptChar = '*';
                        sfPhone.PromptChar = '*';
                        sfEmail.PromptChar = '*';
                    }
                    break;
                case 0:
                    {
                        sfToAccount.PromptChar = '_';
                        sfDesc.PromptChar = '_';
                        sfAmount.PromptChar = '_';
                        sfPhone.PromptChar = '_';
                        sfEmail.PromptChar = '_';
                    }
                    break;
                case 2:
                    {
                        sfToAccount.PromptChar = '~';
                        sfDesc.PromptChar = '~';
                        sfAmount.PromptChar = '~';
                        sfPhone.PromptChar = '~';
                        sfEmail.PromptChar = '~';
                    }
                    break;
            }
        }

        private void ValidationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            sfToAccount.ValidationMode = (InputValidationMode)validationPicker.SelectedIndex;
            sfDesc.ValidationMode = (InputValidationMode)validationPicker.SelectedIndex;
            sfAmount.ValidationMode = (InputValidationMode)validationPicker.SelectedIndex;
            sfEmail.ValidationMode = (InputValidationMode)validationPicker.SelectedIndex;
            sfPhone.ValidationMode = (InputValidationMode)validationPicker.SelectedIndex;
        }

        void ToggleChanged(object sender, ToggledEventArgs e)
        {
            sfToAccount.HidePromptOnLeave = e.Value;
            sfDesc.HidePromptOnLeave = e.Value;
            sfAmount.HidePromptOnLeave = e.Value;
            sfPhone.HidePromptOnLeave = e.Value;
            sfEmail.HidePromptOnLeave = e.Value;
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
                if ((sfToAccount.Value == null || sfToAccount.Value.ToString() == string.Empty)
                    || (sfDesc.Value == null || sfDesc.Value.ToString() == string.Empty)
                    || (sfAmount.Value == null || sfAmount.Value.ToString() == string.Empty)
                    || (sfEmail.Value == null || sfEmail.Value.ToString() == string.Empty)
                    || (sfPhone.Value == null || sfPhone.Value.ToString() == string.Empty))
                {
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Status", "Please fill all the required data!", "Ok");
                }
                else if((sfToAccount.HasError || sfDesc.HasError || sfAmount.HasError || sfEmail.HasError || sfPhone.HasError))
                {
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Status", "Please enter valid details", "Ok");
                }
                else 
                {
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Status", string.Format("Amount of {0} has been transferred successfully!", sfAmount.Value), "Ok");
                    string mask1 = sfToAccount.Mask;
                    sfToAccount.Mask = string.Empty;
                    sfToAccount.Mask = mask1;

                    mask1 = sfDesc.Mask;
                    sfDesc.Mask = "0";
                    sfDesc.Mask = mask1;

                    mask1 = sfAmount.Mask;
                    sfAmount.Mask = string.Empty;
                    sfAmount.Mask = mask1;

                    mask1 = sfEmail.Mask;
                    sfEmail.Mask = string.Empty;
                    sfEmail.Mask = mask1;

                    mask1 = sfPhone.Mask;
                    sfPhone.Mask = string.Empty;
                    sfPhone.Mask = mask1;
                }
        }
        public void localePicker_Changed(object c, EventArgs e)
        {
            switch (localePicker.SelectedIndex)
            {
                case 0:
                    {
                        sfToAccount.Culture = new System.Globalization.CultureInfo("en-US");
                        sfDesc.Culture = new System.Globalization.CultureInfo("en-US");
                        sfAmount.Culture = new System.Globalization.CultureInfo("en-US");
                        sfPhone.Culture = new System.Globalization.CultureInfo("en-US");
                        sfEmail.Culture = new System.Globalization.CultureInfo("en-US");
                    }
                    break;
                case 1:
                    {
                        sfToAccount.Culture = new System.Globalization.CultureInfo("en-GB");
                        sfDesc.Culture = new System.Globalization.CultureInfo("en-GB");
                        sfAmount.Culture = new System.Globalization.CultureInfo("en-GB");
                        sfPhone.Culture = new System.Globalization.CultureInfo("en-GB");
                        sfEmail.Culture = new System.Globalization.CultureInfo("en-GB");
                    }
                    break;
                case 2:
                    {

                        sfToAccount.Culture = new System.Globalization.CultureInfo("ja-JP");
                        sfDesc.Culture = new System.Globalization.CultureInfo("ja-JP");
                        sfAmount.Culture = new System.Globalization.CultureInfo("ja-JP");
                        sfPhone.Culture = new System.Globalization.CultureInfo("ja-JP");
                        sfEmail.Culture = new System.Globalization.CultureInfo("ja-JP");
                    }
                    break;
                case 3:
                    {
                        sfToAccount.Culture = new System.Globalization.CultureInfo("fr-FR");
                        sfDesc.Culture = new System.Globalization.CultureInfo("fr-FR");
                        sfAmount.Culture = new System.Globalization.CultureInfo("fr-FR");
                        sfPhone.Culture = new System.Globalization.CultureInfo("fr-FR");
                        sfEmail.Culture = new System.Globalization.CultureInfo("fr-FR");
                    }
                    break;
                case 4:
                    {
                        sfToAccount.Culture = new System.Globalization.CultureInfo("it-IT");
                        sfDesc.Culture = new System.Globalization.CultureInfo("it-IT");
                        sfAmount.Culture = new System.Globalization.CultureInfo("it-IT");
                        sfPhone.Culture = new System.Globalization.CultureInfo("it-IT");
                        sfEmail.Culture = new System.Globalization.CultureInfo("it-IT");
                    }
                    break;
            }

        }

        public View getContent()
        {
            return this.Content;
        }

        public View getPropertyView()
        {
            return this.PropertyView;
        }
    }
}