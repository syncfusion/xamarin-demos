#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfCheckBox
{
    public partial class CheckBox : SampleView
    {
        private bool skip = false;

        public object NonCheckBox { get; private set; }

        public CheckBox()
        {
            InitializeComponent();
            selectAll.StateChanged += SelectAll1_StateChanged;
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                movieImage.HeightRequest = 270;
                frame.Margin = new Thickness(25, 25, 25, 0);
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    selectAll.FontSize = grilledChicken.FontSize = chickenTikka.FontSize = 20;
                    chickenSausage.FontSize = beef.FontSize = 20;
                }
                title.FontSize = 22;
                title.Margin = new Thickness(0, 20, 0, 10);
                selectAll.Margin = new Thickness(0, 20, 0, 0);
                grilledChicken.Margin = new Thickness(0, 30, 0, 0);
                chickenTikka.Margin = new Thickness(0, 30, 0, 0);
                chickenSausage.Margin = new Thickness(0, 30, 0, 0);
                beef.Margin = new Thickness(0, 30, 0, 30);
            }
            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                frame.BackgroundColor = Color.White;
                frame.HasShadow = true;
#pragma warning disable 618
                frame.OutlineColor = Color.FromHex("29000000");
#pragma warning restore 618
            }
            if (Device.RuntimePlatform == Device.WPF || Device.RuntimePlatform == Device.UWP)
            {
                if(Device.RuntimePlatform == Device.UWP)
                    frame.HeightRequest = 680;
                else
                    frame.HeightRequest = 600;

                frame.WidthRequest = 380;
                frame.HorizontalOptions = LayoutOptions.Center;
                frame.VerticalOptions = LayoutOptions.Center;
                button.HeightRequest = 50;
                button.WidthRequest = 410;
                button.HorizontalOptions = LayoutOptions.Center;
                button.VerticalOptions = LayoutOptions.Center;
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            bool? temp = ValidateNonVegToopings();
            if (!temp.HasValue || (temp.HasValue && temp.Value))
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Your order has been placed successfully !", "Ok");
                selectAll.IsChecked = false;
            }
            if (Device.RuntimePlatform == Device.WPF)
            {
                button.TextColor = Color.Black;
            }
        }

        private void NonvegToppingsChanged(object sender, Syncfusion.XForms.Buttons.StateChangedEventArgs eventArgs)
        {
            if (!skip)
            {
                skip = true;
                selectAll.IsChecked = ValidateNonVegToopings();
                if (!selectAll.IsChecked.HasValue || (selectAll.IsChecked.HasValue && selectAll.IsChecked.Value))
                {
                    button.IsEnabled = true;
                    if (Device.RuntimePlatform == Device.WPF)
                    {
                        button.TextColor = Color.White;
                    }
                }
                else
                {
                    button.IsEnabled = false;
                }
                skip = false;
            }
        }

        private void SelectAll1_StateChanged(object sender, Syncfusion.XForms.Buttons.StateChangedEventArgs eventArgs)
        {
            if (!skip)
            {
                skip = true;
                    grilledChicken.IsChecked = chickenTikka.IsChecked = chickenSausage.IsChecked = beef.IsChecked = eventArgs.IsChecked.Value;
                button.IsEnabled = eventArgs.IsChecked.Value;

                skip = false;
                if (Device.RuntimePlatform == Device.WPF)
                    button.TextColor = Color.Black;
            }
        }

        private void NonCheckBox_StateChanged(object sender, Syncfusion.XForms.Buttons.StateChangedEventArgs eventArgs)
        {
            grilledChicken.IsVisible = chickenTikka.IsVisible = chickenSausage.IsVisible = beef.IsVisible = eventArgs.IsChecked.Value;
            if (!eventArgs.IsChecked.Value)
            {
                selectAll.IsChecked = false;
                grilledChicken.IsChecked = chickenTikka.IsChecked = chickenSausage.IsChecked = beef.IsChecked = false;
            }
        }

        private bool? ValidateNonVegToopings()
        {
            if (grilledChicken.IsChecked.Value && chickenTikka.IsChecked.Value && chickenSausage.IsChecked.Value && beef.IsChecked.Value)
                return true;
            else if (!grilledChicken.IsChecked.Value && !chickenTikka.IsChecked.Value && !chickenSausage.IsChecked.Value && !beef.IsChecked.Value)
                return false;
            else
                return null;
        }
    }
}