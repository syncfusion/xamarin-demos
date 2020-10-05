#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;

namespace SampleBrowser.Chips
{
	#region Converter

    /// <summary>
    /// String to color converter.
    /// </summary>
	public class StringToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch(value.ToString())
            {
                case "Blue":
                    return Color.Blue;
                case "Black":
                    return Color.Black;
                case "Red":
                    return Color.Red;
                case "Pink":
                    return Color.Pink;
                case "Purple":
                    return Color.Purple;
                case "Green":
                    return Color.Green;
                case "White":
                    return Color.White;
                case "Orange":
                    return Color.Orange;
            }

            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}

