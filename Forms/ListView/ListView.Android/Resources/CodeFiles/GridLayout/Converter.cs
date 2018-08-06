#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewBoolToSelectionImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Assembly assembly = typeof(GridLayout).GetTypeInfo().Assembly;
#if COMMONSB
            if ((bool)value)
                return ImageSource.FromResource("SampleBrowser.Icons.Selected1.png", assembly);
            else
                return ImageSource.FromResource("SampleBrowser.Icons.NotSelected1.png", assembly);
#else
            if ((bool)value)
                return ImageSource.FromResource("SampleBrowser.SfListView.Icons.Selected1.png", assembly);
            else
                return ImageSource.FromResource("SampleBrowser.SfListView.Icons.NotSelected1.png", assembly);
#endif
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
