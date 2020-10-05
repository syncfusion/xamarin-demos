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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;

namespace SampleBrowser.SfRadioButton
{
    public partial class RadioButton : SampleView
    {
        public RadioButton()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
                frame.BackgroundColor = Color.Transparent;
            if (Device.RuntimePlatform == Device.WPF || Device.RuntimePlatform == Device.UWP)
            {
                buttn.HeightRequest = 50;
                buttn.WidthRequest = 300;
                buttn.HorizontalOptions = LayoutOptions.Center;
                buttn.VerticalOptions = LayoutOptions.Center;
            }
            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                frame.BackgroundColor = Color.White;
                lineFrame.BackgroundColor = Color.White;
                frame.HasShadow = true;
                lineFrame.HasShadow = false;
#pragma warning disable 618
                frame.OutlineColor = Color.FromHex("29000000");
                lineFrame.OutlineColor = Color.FromHex("29000000");
#pragma warning restore 618

            }
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                frame.Margin = new Thickness(45, 89, 45, 0);
                headerText.Margin = new Thickness(0, 50, 0, 0);
                headerText.FontSize = 30;
                amountlabl.FontSize = 22;
                amt.FontSize = 22;
                paymentmodelbl.FontSize = 22;
                debit.FontSize = 20;
                credit.FontSize = 20;
                netbanking.FontSize = 20;
                buttn.FontSize = 25;
                lineFrame.HeightRequest = 2;
                lineFrame.Margin = new Thickness(25, 25, 25, 0);
                amtStack.Margin = new Thickness(25, 25, 25, 0);
                amountlabl.Margin = new Thickness(0, 20 , 0, 0);
                amt.Margin = new Thickness(0, 20, 0, 0);
                radioGroup.Margin = new Thickness(0, 35, 0, 0);
                paymentmodelbl.Margin = new Thickness(25, 0, 0, 0);
                debit.Margin = new Thickness(25, 30, 0, 0);
                credit.Margin = new Thickness(25, 30, 0, 45);
                netbanking.Margin = new Thickness(25, 30, 0, 0);
            }
        }
        private void Buttn_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Payment Successfull !", "Ok");
            debit.IsChecked = false;
            credit.IsChecked = false;
            netbanking.IsChecked = false;
            buttn.IsEnabled = false;
            if (Device.RuntimePlatform == Device.WPF)
            {
                buttn.TextColor = Color.Black;
            }
        }

        private void paymentMode_StateChanged(object sender, Syncfusion.XForms.Buttons.StateChangedEventArgs eventArgs)
        {
            buttn.IsEnabled = true;
            if (Device.RuntimePlatform == Device.WPF)
            {
                buttn.TextColor = Color.White;
            }
        }
    }
}