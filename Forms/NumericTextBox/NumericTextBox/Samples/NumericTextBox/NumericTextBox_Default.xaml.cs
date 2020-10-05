#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.XForms.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser.SfNumericTextBox
{
    public partial class NumericTextBox_Default : SampleView
    {
        int precision = 0;

        public NumericTextBox_Default()
        {
            InitializeComponent();
            OptionView();
            clearButtonPicker.SelectedIndex = precision;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            interestLayout.IsVisible = true;
        }

        Double rate = 0;
        Double princ = 0;
        Double term = 0;
        public void trimValue()
        {
            if (principalNumericTextBox.Value != null)
            {
                if (principalNumericTextBox.Value == null || interestRateNumericTextBox.Value == null || termNumericTextBox.Value == null)
                {
                    interestNumericTextBox.Value = 0;
                    if (interestRateNumericTextBox.Value == null)
                        rate = 0;
                    if (principalNumericTextBox.Value == null)
                        princ = 0;
                    if (termNumericTextBox.Value == null)
                        term = 0;
                }
                else
                {
                    if (principalNumericTextBox.Value.ToString().Length < 8)
                    {
                        princ = Convert.ToDouble(principalNumericTextBox.Value.ToString());
                    }
                    if (interestRateNumericTextBox.Value.ToString().Length < 8)
                    {
                        rate = Convert.ToDouble(interestRateNumericTextBox.Value.ToString());
                    }
                    if (termNumericTextBox.Value.ToString().Length < 8)
                    {
                        term = Convert.ToDouble(termNumericTextBox.Value.ToString());
                    }
                    else
                    {
                        if (interestRateNumericTextBox.Value.ToString().Length > 7)
                            rate = Convert.ToDouble(interestRateNumericTextBox.Value.ToString().Remove(7));
                        if (principalNumericTextBox.Value.ToString().Length > 7)
                            princ = Convert.ToDouble(principalNumericTextBox.Value.ToString().Remove(7));
                        if (termNumericTextBox.Value.ToString().Length > 7)
                            term = Convert.ToDouble(termNumericTextBox.Value.ToString().Remove(7));
                    }
                }
            }
            else
            {
                rate = princ = term = 0.0;
            }
        }


        public void OptionView()
        {
            double height = Bounds.Height;
            double width = Core.SampleBrowser.ScreenWidth;
            if (Device.Idiom == TargetIdiom.Tablet)
                width /= 2;

            //Toggle button
            allowNullToggle.Toggled += ToggleChanged;

            //Localization
            termNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            principalNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            interestNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");

            localePicker.Items.Add("United States");
            localePicker.Items.Add("United Kingdom");
            localePicker.Items.Add("Japan");
            localePicker.Items.Add("France");
            localePicker.Items.Add("Italy");
            localePicker.SelectedIndex = precision;
            localePicker.SelectedIndexChanged += localePicker_Changed;


            //Value Changed
            principalNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
            {
                interestLayout.IsVisible = false;
                trimValue();
                interestNumericTextBox.Value = rate * princ * term;
            };

            interestRateNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
            {
                interestLayout.IsVisible = false;
                trimValue();
                interestNumericTextBox.Value =
                princ * term * rate;
            };

            termNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
            {
                interestLayout.IsVisible = false;
                trimValue();
                interestNumericTextBox.Value =
               princ * term * rate;
            };

            //Device Settings
            if (Device.RuntimePlatform == Device.iOS)
            {
                principalNumericTextBox.WidthRequest = width / 2;
                interestRateNumericTextBox.WidthRequest = width / 2;
                termNumericTextBox.WidthRequest = width / 2;
                interestNumericTextBox.WidthRequest = width / 2;
                allowNullLabel.WidthRequest = width / 2;
                allowNullLabel.VerticalOptions = LayoutOptions.End;
                allowNullToggle.VerticalOptions = LayoutOptions.Start;
                optionLayout.Padding = new Thickness(0, 0, 10, 0);
                interestNumericTextBox.BorderColor = Color.Transparent;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                calculateButton.BackgroundColor = Color.FromHex("#2196f3");
                calculateButton.CornerRadius = 1;
                calculateButton.BorderWidth = 0;
                calculateButton.TextColor = Color.White;
                calculateButton.FontFamily = "Roboto";
                principalNumericTextBox.Margin = new Thickness(0, 0, 0, 0);
                interestNumericTextBox.Margin = new Thickness(0, 0, 0, 0);
                interestRateNumericTextBox.Margin = new Thickness(0, 0, 0, 0);
                termNumericTextBox.Margin = new Thickness(0, 0, 0, 0);

                numericTextBox1.Padding = new Thickness(-3, -15, 0, 0);
                numericTextBox2.Padding = new Thickness(-3, -15, 0, 0);
                numericTextBox3.Padding = new Thickness(-3, -15, 0, 0);
                numericTextBox4.Padding = new Thickness(-3, -15, 0, 0);


                principalLabel.HeightRequest = 25;
                interestRateLabel.HeightRequest = 25;
                termLabel.HeightRequest = 25;

                
                pickerLayout3.Padding = new Thickness(-2, 0, 0, 0);
            }
            else if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                principalNumericTextBox.WidthRequest = width / 2;
                interestRateNumericTextBox.WidthRequest = width / 2;
                termNumericTextBox.WidthRequest = width / 2;
                interestNumericTextBox.WidthRequest = width / 2;
                principalNumericTextBox.HeightRequest = 75;
                interestRateNumericTextBox.HeightRequest = 75;
                termNumericTextBox.HeightRequest = 75;
                interestNumericTextBox.HeightRequest = 75;
                localePicker.HeightRequest = 90;
                allowNullToggle.WidthRequest = width / 2;
                allowNullToggle.HorizontalOptions = LayoutOptions.End;
                //interestRateNumericTextBox.FormatString = "0 %";
                termNumericTextBox.FormatString = "0 years";
                interestNumericTextBox.BorderColor = Color.Transparent;

            }
            else
            {
                principalNumericTextBox.WidthRequest = width / 3;
                interestRateNumericTextBox.WidthRequest = width / 3;
                termNumericTextBox.WidthRequest = width / 3;
                interestNumericTextBox.WidthRequest = width / 3;
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                simpleInterestCalculatorLabel.TextColor = Color.Gray;
                findingSimpleInterestLabel.TextColor = Color.Gray;
                formulaLabel.TextColor = Color.Gray;
                principalLabel.TextColor = Color.Gray;
                interestRateLabel.TextColor = Color.Gray;
                termLabel.TextColor = Color.Gray;
                interestLabel.TextColor = Color.Gray;
                //interestRateNumericTextBox.FormatString = "0 %";
                termNumericTextBox.FormatString = "0 years";
                interestNumericTextBox.IsEnabled = true;
                interestNumericTextBox.HeightRequest = 40;
                interestLabel.HeightRequest = 40;
                calculateButton.FontSize = 12;
                interestNumericTextBox.BorderColor = Color.Transparent;
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    interestRateLabel.WidthRequest = 150.0;
                    termLabel.WidthRequest = 150.0;
                    principalLabel.WidthRequest = 150.0;
                    interestLabel.WidthRequest = 150.0;
                    column1.Width = new GridLength(1, GridUnitType.Star);
                }
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    sampleLayout.HorizontalOptions = LayoutOptions.Start;
                    column1.Width = new GridLength(200.0, GridUnitType.Absolute);
                    allowNullToggle.HorizontalOptions = LayoutOptions.Start;
                    localePicker.HorizontalOptions = LayoutOptions.Start;
                    localePicker.WidthRequest = 300.0;
                }
            }

        }

        void ToggleChanged(object sender, ToggledEventArgs e)
        {
            principalNumericTextBox.AllowNull = e.Value;
            interestRateNumericTextBox.AllowNull = e.Value;
            termNumericTextBox.AllowNull = e.Value;
            interestNumericTextBox.AllowNull = e.Value;
        }

        public void localePicker_Changed(object c, EventArgs e)
        {
            switch (localePicker.SelectedIndex)
            {
                case 0:
                    {
                        principalNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
                        interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
                        interestNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
                        termNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
                        precision = 0;
                    }
                    break;
                case 1:
                    {
                        principalNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
                        interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
                        termNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
                        interestNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
                        precision = 1;
                    }
                    break;
                case 2:
                    {
                        principalNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
                        interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
                        termNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
                        interestNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
                        precision = 2;
                    }
                    break;
                case 3:
                    {
                        principalNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
                        interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
                        termNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
                        interestNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
                        precision = 3;
                    }
                    break;
                case 4:
                    {
                        principalNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
                        interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
                        termNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
                        interestNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
                        precision = 4;
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

        private void OnClearButtonPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (clearButtonPicker.SelectedIndex)
            {
                case 0:
                    {
                        principalNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                        interestRateNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                        termNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                        interestNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.WhileEditing;
                    }
                    break;
                case 1:
                    {
                        principalNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                        interestRateNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                        termNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                        interestNumericTextBox.ClearButtonVisibility = ClearButtonVisibilityMode.Never;
                    }
                    break;
            }
        }
    }

    public class NumericTextBoxRenderer : Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox
    {
        public NumericTextBoxRenderer()
        {

        }
    }
    public class NumericTextBoxRenderer2 : Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox
    {
        public NumericTextBoxRenderer2()
        {

        }
    }
}

