#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfTabView
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductView : ViewCell
    {
        public ProductView()
        {
            InitializeComponent();
        }
    }

    public class CustomFrame: Frame
    {

    }

    public class ProductViewFontConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == "Android")
            {
                    return "Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
            }
            else if (Device.RuntimePlatform == "iOS")
            {

                return "Segoe MDL2 Assets";

            }
            else
            {
#if COMMONSB
                return "/Assets/Fonts/Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return "/Assets/Fonts/Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
                }
                else
                {
                    return $"ms-appx:///SampleBrowser.SfTabView.UWP/Assets/Fonts/Segoe MDL2 Assets.ttf#Segoe MDL2 Assets"; // "SampleBrowser.SfTabView.UWP\\Assets/Fonts/NestedTab.ttf#NestedTab";
                }
#endif
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}