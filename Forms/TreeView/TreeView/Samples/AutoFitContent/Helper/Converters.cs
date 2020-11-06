#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.TreeView.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Just now";

            TimeSpan timeSpan = DateTime.Now.Subtract((DateTime)value);
            if (timeSpan.Days == 0)
            {
                if (timeSpan.Hours == 0)
                {
                    if (timeSpan.Minutes < 5)
                        return "Just now";
                    else
                        return timeSpan.Minutes + " mins before";
                }
                else
                    return timeSpan.Hours + " hour" + ((timeSpan.Hours == 1) ? "" : "s") + " ago";
            }
            else
                return timeSpan.Days + " day" + ((timeSpan.Days == 1) ? "" : "s") + " ago";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [Preserve(AllMembers = true)]
    public class RepliesTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isExpand= (bool)value;
            return (isExpand ? "Hide " : "View ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [Preserve(AllMembers = true)]
    public class RepliesCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var replies = (ObservableCollection<Reply>)value;
            return " " + (replies.Count > 0 ? replies.Count : 0) + " replies";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
