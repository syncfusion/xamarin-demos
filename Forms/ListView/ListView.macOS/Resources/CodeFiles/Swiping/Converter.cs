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
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class SwipingBoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Assembly assembly = typeof(Swiping).GetTypeInfo().Assembly;
#if COMMONSB
            if ((bool)value)
                return ImageSource.FromResource("SampleBrowser.Icons.Favorites1.png", assembly);
            else
                return ImageSource.FromResource("SampleBrowser.Icons.InboxIcon.png", assembly);
#else
            if ((bool)value)
                return ImageSource.FromResource("SampleBrowser.SfListView.Icons.Favorites1.png", assembly);
            else
                return ImageSource.FromResource("SampleBrowser.SfListView.Icons.InboxIcon.png", assembly);
#endif
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
