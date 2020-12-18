#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.TreeView;
using Syncfusion.TreeView.Engine;

namespace SampleBrowser
{
    public class TemplateAdapter : TreeViewAdapter
    {
        public TemplateAdapter()
        {
        }

        protected override View CreateContentView(TreeViewItemInfoBase itemInfo)
        {
            var gridView = new TemplateView(TreeView.Context, itemInfo);
            return gridView;
        }

        protected override void UpdateContentView(View view, TreeViewItemInfoBase itemInfo)
        {
            var grid = view as TemplateView;
            var treeViewNode = itemInfo.Node;
            if (grid != null)
            {
                var label = grid.GetChildAt(0) as ContentLabel;
                if (label != null)
                {
                    label.Text = (treeViewNode.Content as MailFolder).FolderName;
                    if ((treeViewNode.Content as MailFolder).MailsCount > 0)
                        label.SetTypeface(Android.Graphics.Typeface.Default, Android.Graphics.TypefaceStyle.Bold);
                }

                var label1 = grid.GetChildAt(1) as ContentLabel;
                if (label1 != null)
                {
                    if ((treeViewNode.Content as MailFolder).MailsCount > 0)
                    {
                        label1.Text = (treeViewNode.Content as MailFolder).MailsCount.ToString();
                        label1.SetTextColor(Android.Graphics.Color.White);
                        label1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF6377EB"));
                    }
                }
            }
        }
    }
}