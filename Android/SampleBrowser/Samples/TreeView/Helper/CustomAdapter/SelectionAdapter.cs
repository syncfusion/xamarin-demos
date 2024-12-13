using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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