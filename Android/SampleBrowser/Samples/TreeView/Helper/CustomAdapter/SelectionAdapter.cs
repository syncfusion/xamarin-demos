#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Views;
using Android.Widget;
using Syncfusion.Android.TreeView;

namespace SampleBrowser
{
    public class SelectionAdapter : TreeViewAdapter
    {
        public SelectionAdapter()
        {
        }

        protected override void UpdateContentView(View view, TreeViewItemInfoBase itemInfo)
        {
            var textView = view as TextView;
            if (textView != null)
            {
                textView.Text = (itemInfo.Node.Content as Countries).Name;
            }
        }
    }
}