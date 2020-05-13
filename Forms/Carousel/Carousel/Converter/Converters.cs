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
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfCarousel
{
    #region converter
  
    /// <summary>
    /// Text to proper conveter.
    /// </summary>
    public class TextToProperConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Replace("-WF", "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Font icon converter.
    /// </summary>
    public class FontIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = parameter.ToString();
            if (Device.RuntimePlatform == "Android")
            {
                return path;
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                string fontname = path.Substring(path.IndexOf('#') + 1, path.Length - 1 - path.IndexOf('#'));
                return fontname;
            }
            else
            {
#if COMMONSB
                return "/Assets/Fonts/" + path;
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return "/Assets/Fonts/"+path;
                }
                else
                {
                    return $"ms-appx:///SampleBrowser.SfCarousel.UWP/Assets/Fonts/"+path;
                }
#endif
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class UnWantedTextRemove : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value.ToString();

            if(text.Contains("-"))
            {
                string temp = text.Substring(0, text.IndexOf('-'));
                return temp;
            }
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

#endregion
}
