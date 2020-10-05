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

namespace SampleBrowser.SfNavigationDrawer
{
    public partial class NavigationDrawer_Main : SampleView
    {
        public NavigationDrawer_Main()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Phone)
            {
                NavigationDrawer_Default navigationdrawer = new NavigationDrawer_Default();
                this.Content = navigationdrawer.getContent();
                this.PropertyView = navigationdrawer.getPropertyView();
                if (Device.RuntimePlatform != Device.iOS)
                    this.Padding = new Thickness(2, 0, 2, 0);
            }
            else if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                NavigationDrawer_Tablet autocompleteTab = new NavigationDrawer_Tablet();
                this.Content = autocompleteTab.getContent();
                this.PropertyView = autocompleteTab.getPropertyView();
                if (Device.RuntimePlatform == Device.iOS)
                    this.Padding = new Thickness(-15, -20, -10, 0);
            }
        }
    }
}

