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