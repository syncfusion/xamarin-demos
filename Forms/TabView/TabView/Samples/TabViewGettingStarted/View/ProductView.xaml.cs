#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
                    return string.Empty;
            }
            else if (Device.RuntimePlatform == "iOS")
            {

                return string.Empty;

            }
            else
            {
#if COMMONSB
                return string.Empty;
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return string.Empty;
                }
                else
                {
                    return string.Empty;
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