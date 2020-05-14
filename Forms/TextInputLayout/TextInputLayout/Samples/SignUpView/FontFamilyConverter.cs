#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XForms.TextInputLayout;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfTextInputLayout
{
    /// <summary>
    /// To get the Font family for the Hint/Helper/Error/Counter label.
    /// </summary>
    public class FontFamilyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            if (value == null)
                return null;
            if (value.ToString() == "Default")
            {
                return value;
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                return "Lobster-Regular.ttf#Lobster-Regular";
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                return "Lobster-Regular";
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                return "Assets/Fonts/Lobster-Regular.ttf#Lobster";
            }
            else if (Device.RuntimePlatform == Device.WPF)
            {
                return "Assets/Fonts/Lobster-Regular.ttf#Lobster";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
