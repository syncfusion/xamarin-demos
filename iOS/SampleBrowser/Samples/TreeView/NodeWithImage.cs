#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.TreeView.Engine;
using Syncfusion.iOS.TreeView;
using CoreGraphics;
namespace SampleBrowser
{
    public class NodeWithImage : SampleView
    {
        SfTreeView treeView;
        FileManagerViewModel viewModel;
        public NodeWithImage()
        {
            treeView = new SfTreeView();
            viewModel = new FileManagerViewModel();
            treeView.Indentation = 20;
            treeView.ExpanderWidth = 40;
            treeView.ItemHeight = 40;
            treeView.AutoExpandMode = AutoExpandMode.AllNodesExpanded;
            treeView.ChildPropertyName = "SubFolder";
            treeView.ItemsSource = viewModel.Folders;
            treeView.Adapter = new NodeImageAdapter();
            this.AddSubview(treeView);
        }
        public override void LayoutSubviews()
        {
            this.treeView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);

            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}