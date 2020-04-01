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
    public class NodeImageAdapter : TreeViewAdapter
    {
        public NodeImageAdapter()
        {
        }
        protected override View CreateContentView(TreeViewItemInfoBase itemInfo)
        {
            var gridView = new NodeImageView();
            return gridView;
        }
        protected override void UpdateContentView(View view, TreeViewItemInfoBase itemInfo)
        {
            var grid = view as NodeImageView;
            var treeViewNode = itemInfo.Node;
            if (grid != null)
            {
                var imageView = grid.Subviews[0] as UIImageView;
                if (imageView != null)
                    imageView.Image = (treeViewNode.Content as FileManager).ImageIcon;
                var label1 = grid.Subviews[1] as UILabel;
                if (label1 != null)
                    label1.Text = (treeViewNode.Content as FileManager).FileName;
            }
        }
    }
}