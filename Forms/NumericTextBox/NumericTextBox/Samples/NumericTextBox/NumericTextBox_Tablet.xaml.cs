#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;

using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.XForms.Editors;
using Xamarin.Forms;

namespace SampleBrowser.SfNumericTextBox
{
    public partial class NumericTextBox_Tablet : SampleView
    {
        StackLayout view;
        Button closeButton;
        Switch allowNullToggle;
        Picker localePicker;
        int precision = 0;
        bool tooltip = true;
        Label allowNullLabel;
        double width;

        public NumericTextBox_Tablet()
        {
            InitializeComponent();
            width = Core.SampleBrowser.ScreenWidth;
            clearButtonPicker.SelectedIndex = precision;
            getPropertiesWindow();
            DevicesChanges();
        }


        public void getPropertiesWindow()
        {
            view = new StackLayout();

            view.HeightRequest = Property_Windows.HeightRequest;
            view.BackgroundColor = Color.FromRgb(250, 250, 250);
            if (Device.RuntimePlatform == Device.iOS)
            {
                Property_Windows.HeightRequest = 250;
            }

            StackLayout propertyLayout = new StackLayout();
            propertyLayout.Orientation = StackOrientation.Horizontal;
            propertyLayout.BackgroundColor = Color.FromRgb(230, 230, 230);
            propertyLayout.Padding = new Thickness(10, 0, 0, 0);

            TapGestureRecognizer tab = new TapGestureRecognizer();
            tab.Tapped += tab_Tapped;
            propertyLayout.GestureRecognizers.Add(tab);
            Label propertyLabel = new Label();
            propertyLabel.Text = "OPTIONS";
            propertyLabel.WidthRequest = 150;
            propertyLabel.VerticalOptions = LayoutOptions.Center;
            propertyLabel.HorizontalOptions = LayoutOptions.Start;
            propertyLabel.FontFamily = "Helvetica";
            propertyLabel.FontSize = 20;
            closeButton = new Button();
            if (Device.RuntimePlatform == Device.iOS)
            {
                closeButton.Text = "X";
                closeButton.TextColor = Color.FromRgb(51, 153, 255);
            }
			else if (Device.RuntimePlatform == Device.Android)
            {
                closeButton.Image = "cancelsearch.png";
            }else{
				closeButton.Image = "sfclosebutton.png";
			}
            closeButton.Clicked += Close_Button;

            closeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
            propertyLayout.Children.Add(propertyLabel);
            propertyLayout.Children.Add(closeButton);

            temp.BackgroundColor = Color.FromRgb(230, 230, 230);
            closeButton.BackgroundColor = Color.FromRgb(230, 230, 230);
            Property_Button.BackgroundColor = Color.FromRgb(230, 230, 230);

            StackLayout emptyLayout = new StackLayout();
            emptyLayout.Orientation = StackOrientation.Vertical;
            emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
            if (Device.RuntimePlatform == Device.iOS)
            {
                emptyLayout.Padding = new Thickness(60, 20, 40, 40);
            }
            else
            {
                emptyLayout.Padding = new Thickness(30, 20, 40, 40);
            }

            StackLayout cultureLayout = new StackLayout();
            cultureLayout.Orientation = StackOrientation.Horizontal;
            cultureLayout.Padding = new Thickness(100, 20, 0, 20);

            Label cultureLabel = new Label();
            cultureLabel.Text = "Culture";
            cultureLabel.WidthRequest = 150;
            cultureLabel.VerticalOptions = LayoutOptions.Center;
            cultureLabel.HorizontalOptions = LayoutOptions.End;
            cultureLabel.FontFamily = "Helvetica";
            cultureLabel.FontSize = 16;

            localePicker = new Picker();
            localePicker.VerticalOptions = LayoutOptions.Center;
            localePicker.HorizontalOptions = LayoutOptions.Start;
            localePicker.Items.Add("United States");
            localePicker.Items.Add("United Kingdom");
            localePicker.Items.Add("Japan");
            localePicker.Items.Add("France");
            localePicker.Items.Add("Italy");
            localePicker.SelectedIndex = precision;

            localePicker.SelectedIndexChanged += localePicker_Changed;
            cultureLayout.Children.Add(cultureLabel);
            cultureLayout.Children.Add(localePicker);

            StackLayout allowNullLayout = new StackLayout();
            allowNullLayout.Orientation = StackOrientation.Horizontal;
            allowNullLayout.Padding = new Thickness(100, 20, 0, 20);

            allowNullLabel = new Label();
            allowNullLabel.Text = "Allow Null";
            allowNullLabel.WidthRequest = 150;
            allowNullLabel.VerticalOptions = LayoutOptions.Center;
            allowNullLabel.HorizontalOptions = LayoutOptions.End;
            allowNullLabel.FontFamily = "Helvetica";
            allowNullLabel.FontSize = 16;

            allowNullToggle = new Switch();
            allowNullToggle.Toggled += toggleStateChanged;
            allowNullToggle.IsToggled = tooltip;
            allowNullToggle.HorizontalOptions = LayoutOptions.Start;
            allowNullToggle.VerticalOptions = LayoutOptions.Center;
            allowNullLayout.Children.Add(allowNullLabel);
            allowNullLayout.Children.Add(allowNullToggle);

            emptyLayout.Children.Add(cultureLayout);
            emptyLayout.Children.Add(allowNullLayout);

            view.Children.Add(propertyLayout);
            view.Children.Add(emptyLayout);

            Property_Windows.Children.Remove(temp);
            //Property_Windows.Children.Insert(0, view);



        }
        void tab_Tapped(object sender, EventArgs e)
        {
            closeAction();

        }
        void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
        {
            getPropertiesWindow();
        }

        public void closeAction()
        {
            view.BackgroundColor = Color.White;
            Property_Windows.Children.Add(temp);
            Property_Windows.Children.Remove(view);
        }
        public void Property_Button_Clicked(object c, EventArgs e)
        {
            getPropertiesWindow();
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
        public void toggleStateChanged(object c, ToggledEventArgs e)

        {
            if (e.Value)
            {
                principalNumericTextBox.AllowNull = e.Value;
                interestRateNumericTextBox.AllowNull = e.Value;
                termNumericTextBox.AllowNull = e.Value;
                interestNumericTextBox.AllowNull = e.Value;
                tooltip = e.Value;

            }
            else
            {
                principalNumericTextBox.AllowNull = e.Value;
                interestRateNumericTextBox.AllowNull = e.Value;
                termNumericTextBox.AllowNull = e.Value;
                interestNumericTextBox.AllowNull = e.Value;
                tooltip = e.Value;

            }

        }

        void DevicesChanges()
        {
            TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
            tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
            temp.GestureRecognizers.Add(tap_Gestue_Prob);

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                width /= 2;
            }
            Property_Button.Clicked += Property_Button_Clicked;

            principalNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
            {
                if (e.Value == null)
                    interestNumericTextBox.Value = 0.0;
                else
                    interestNumericTextBox.Value = Convert.ToDouble(interestRateNumericTextBox.Value.ToString()) * Convert.ToDouble(e.Value.ToString()) * Convert.ToDouble(termNumericTextBox.Value.ToString());
            };
            principalNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            interestRateNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
            {
                if (e.Value == null)
                    interestNumericTextBox.Value = 0.0;
                else
                    interestNumericTextBox.Value = Convert.ToDouble(principalNumericTextBox.Value.ToString()) * Convert.ToDouble(e.Value.ToString()) * Convert.ToDouble(termNumericTextBox.Value.ToString());
            };
            interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            termNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
            {
                if (e.Value == null)
                    interestNumericTextBox.Value = 0.0;
                else
                    interestNumericTextBox.Value = Convert.ToDouble(principalNumericTextBox.Value.ToString()) * Convert.ToDouble(interestRateNumericTextBox.Value.ToString()) * Convert.ToDouble(e.Value.ToString());
            };
            termNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            interestNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");

			if (Device.RuntimePlatform == Device.iOS)
            {
                principalNumericTextBox.WidthRequest = width / 2;
                interestRateNumericTextBox.WidthRequest = width / 2;
                termNumericTextBox.WidthRequest = width / 2;
                interestNumericTextBox.WidthRequest = width / 2;

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

                interestRateNumericTextBox.FormatString = "0 %";
                termNumericTextBox.FormatString = "0 years";
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
                principalLabel.TextColor = Color.Gray;
                interestRateLabel.TextColor = Color.Gray;
                termLabel.TextColor = Color.Gray;
                interestLabel.TextColor = Color.Gray;

                interestRateNumericTextBox.FormatString = "0 %";
                termNumericTextBox.FormatString = "0 years";
                if (Device.Idiom != TargetIdiom.Tablet)
                {
                    interestNumericTextBox.IsEnabled = true;
                }
            }
        }
        public void Close_Button(object c, EventArgs e)
        {
            closeAction();

        }
        public View getContent()
        {
            return this.Content;
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
}



