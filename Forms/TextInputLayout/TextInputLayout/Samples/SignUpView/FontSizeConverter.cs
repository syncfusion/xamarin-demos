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
    /// Converter to convert the font size by decreasing the actual size to 75 percentage. 
    /// </summary>
    public class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double fontSize = 0f;

            if (value == null)
                return null;

            if (double.TryParse(value.ToString(), out fontSize))
            {
                fontSize = fontSize * 0.75;
            }
            return fontSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
