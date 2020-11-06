#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfSegmentedControl;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomListView))]
namespace SampleBrowser.SfSegmentedControl
{
    public class CustomListView : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell segmentitem, UITableViewCell reusableCell, UITableView segment)
        {
            var listviewCell = base.GetCell(segmentitem, reusableCell, segment);
            if (listviewCell != null)
            {
                listviewCell.SelectionStyle = UITableViewCellSelectionStyle.None;
            }
            return listviewCell;
        }
    }
}