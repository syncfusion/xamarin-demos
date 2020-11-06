#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleBrowser.SfTabView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Themes : SampleView
    {
        public Themes()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == "iOS")
            {
                furnitureLabel.FontFamily = clothingLabel.FontFamily = shoesLabel.FontFamily  = fruitsLabel.FontFamily  = toysLabel.FontFamily  = "TabIcons";

            }
            else if (Device.RuntimePlatform == "Android")
            {
                furnitureLabel.FontFamily = clothingLabel.FontFamily = shoesLabel.FontFamily = fruitsLabel.FontFamily = toysLabel.FontFamily  = "TabIcons.ttf#TabIcons";
            }
            else if (Device.RuntimePlatform == "UWP")
            {
                furnitureLabel.FontFamily = clothingLabel.FontFamily = shoesLabel.FontFamily = fruitsLabel.FontFamily = toysLabel.FontFamily  = "/Assets/Fonts/TabIcons.ttf#TabIcons";
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    furnitureLabel.FontFamily = clothingLabel.FontFamily = shoesLabel.FontFamily = fruitsLabel.FontFamily = toysLabel.FontFamily  = "/Assets/Fonts/TabIcons.ttf#TabIcons";
                }
                else
                {
                    furnitureLabel.FontFamily = clothingLabel.FontFamily = shoesLabel.FontFamily = fruitsLabel.FontFamily = toysLabel.FontFamily  = $"ms-appx:///SampleBrowser.SfTabView.UWP/Assets/Fonts/TabIcons.ttf#TabIcons";    //@"SampleBrowser.SfTabView.UWP\Assets\Fonts\TabIcons.ttf#TabIcons";
                }
            }

        }

    }
}