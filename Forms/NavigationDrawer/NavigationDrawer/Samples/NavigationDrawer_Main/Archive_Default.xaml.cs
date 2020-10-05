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
using SampleBrowser.Core;
using Syncfusion.SfNavigationDrawer.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfNavigationDrawer
{
    public partial class Archive_Default : ContentView
    {
        public Archive_Default(ObservableCollection<Message> items, string title)
        {
            InitializeComponent();
            headerGradiant.WidthRequest = Core.SampleBrowser.ScreenWidth;
            headerLabel.Text = title;
            listView.ItemsSource = items;
            btn.BackgroundColor = Color.FromHex("#00a0e1");

            btn.HeightRequest = 40;
            btn.WidthRequest = 40;
            btn.Text = "H";
            btn.FontSize = 16;

            if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Tablet)
            {
                headingGrid.Padding = new Thickness(10, 10, 0, 10);
            }
            if (Device.RuntimePlatform == Device.Android)
            {
                if(Device.Idiom == TargetIdiom.Tablet)
                btn.WidthRequest = 60;
                btn.FontFamily = "navigation.ttf#navigation";
                recentButton.Text = "\uE823";
                headerLabel.WidthRequest = ((Core.SampleBrowser.ScreenWidth * Core.SampleBrowser.Density) - (Core.SampleBrowser.Density * btn.WidthRequest));
                recentButton.WidthRequest = 60;
                recentButton.FontFamily = "segoe-mdl2-assets.ttf#segoe-mdl2-assets";
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                btn.FontSize = 21;
                btn.Text = "\xE700";
                btn.FontFamily = "Segoe MDL2 Assets";
                btn.HeightRequest = 50;
                btn.WidthRequest = 50;
                recentButton.FontFamily = "SB Icons.ttf#SB Icons";
                recentButton.Text = "\uE726";
                recentButton.WidthRequest = 50;
                recentButton.HeightRequest = 50;
            }
            else
            {
                btn.FontFamily = "SB Icons";
                btn.Text = "\uE731";
                btn.WidthRequest = 50;
                btn.HeightRequest = 50;
                recentButton.FontFamily = "SB Icons";
                recentButton.Text = "\uE726";
                recentButton.WidthRequest = 50;
                recentButton.HeightRequest = 50;
            }
            btn.TextColor = Color.White;

        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        void Btn_Clicked(object sender, EventArgs e)
        {
            if((sender as Button) == btn)
                DependencyService.Get<IToggleDrawer>().ToggleDrawer();
            else if((sender as Button) == recentButton)
                DependencyService.Get<IToggleSecondaryDrawer>().ToggleSecondaryDrawer();

		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.RuntimePlatform == Device.iOS)
            {
                recentButton.HeightRequest = 48;
                recentButton.WidthRequest = 48;
            }
        }
    }
}
