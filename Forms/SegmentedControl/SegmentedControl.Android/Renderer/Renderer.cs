#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Views;
using SampleBrowser.SegmentedControl;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomListView))]
namespace SampleBrowser.SegmentedControl
{
    public class CustomListView : ViewCellRenderer
    {
        protected override View GetCellCore(Cell segmentitem, View segmentConverterView, ViewGroup parent, Context context)
        {
            var listviewCell = base.GetCellCore(segmentitem, segmentConverterView, parent, context);
            var SegmentlistView = parent as Android.Widget.ListView;

            if (SegmentlistView != null)
            {
                SegmentlistView.SetSelector(Android.Resource.Color.Transparent);
                SegmentlistView.CacheColorHint = Android.Graphics.Color.Transparent;
            }

            return listviewCell;
        }
    }
}