#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
    public class ListViewBoolToSortImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Assembly assembly = typeof(SortingFiltering).GetTypeInfo().Assembly;
            var sortOptions = (ListViewSortOptions)value;
#if COMMONSB
            if(sortOptions == ListViewSortOptions.Ascending)
                return ImageSource.FromResource("SampleBrowser.Icons.Sort_Ascending.png", assembly);
            else if(sortOptions == ListViewSortOptions.Descending)
                return ImageSource.FromResource("SampleBrowser.Icons.Sort_Decending.png", assembly);
            else
                return ImageSource.FromResource("SampleBrowser.Icons.SortIcon.png", assembly);
#else
            if (sortOptions == ListViewSortOptions.Ascending)
                return ImageSource.FromResource("SampleBrowser.SfListView.Icons.Sort_Ascending.png", assembly);
            else if (sortOptions == ListViewSortOptions.Descending)
                return ImageSource.FromResource("SampleBrowser.SfListView.Icons.Sort_Decending.png", assembly);
            else
                return ImageSource.FromResource("SampleBrowser.SfListView.Icons.SortIcon.png", assembly);
#endif
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
