#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using View=UIKit.UIView;
using UIKit;
using Syncfusion.iOS.TreeView;

namespace SampleBrowser
{
    public class TemplateAdapter : TreeViewAdapter
    {
        public TemplateAdapter()
        {
        }
        protected override View CreateContentView(TreeViewItemInfoBase itemInfo)
        {
            var gridView = new TemplateSelectorView();
            return gridView;
        }
        protected override void UpdateContentView(View view, TreeViewItemInfoBase itemInfo)
        {
            var grid = view as TemplateSelectorView;
            var treeViewNode = itemInfo.Node;
            if (grid != null)
            {
                var label = grid.Subviews[0] as UILabel;
                if (label != null)
                {
                    label.Text = (treeViewNode.Content as MailFolder).FolderName;
                    if ((treeViewNode.Content as MailFolder).MailsCount > 0)                  
                        label.Font = UIFont.BoldSystemFontOfSize(16);
                }
                var label1 = grid.Subviews[1] as UILabel;
                if (label1 != null)
                {
                    if ((treeViewNode.Content as MailFolder).MailsCount > 0)
                    {
                        label1.Text = (treeViewNode.Content as MailFolder).MailsCount.ToString();
                        label1.BackgroundColor = UIColor.Blue;
                        label1.TextColor = UIColor.White;
                        label1.TextAlignment = UITextAlignment.Center;
                        label1.AdjustsFontSizeToFitWidth = true;
                    }
                }
            }
        }
    }
}