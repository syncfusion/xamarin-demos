#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfCheckBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Themes : SampleView
    {
        public Themes()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                title.FontSize = 22;
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    grilledChicken.FontSize = chickenTikka.FontSize = 20;
                    chickenSausage.FontSize = beef.FontSize = 20;
                }
                title.Margin = new Thickness(0, 20, 0, 10);
                grilledChicken.Margin = new Thickness(0, 30, 0, 0);
                chickenTikka.Margin = new Thickness(0, 30, 0, 0);
                chickenSausage.Margin = new Thickness(0, 30, 0, 0);
                beef.Margin = new Thickness(0, 30, 0, 30);
            }
            if (Device.RuntimePlatform == Device.WPF || Device.RuntimePlatform == Device.UWP)
            {
                MainStack1.HorizontalOptions = LayoutOptions.Center;
                MainStack1.VerticalOptions = LayoutOptions.Start;
            }
        }
    }
}