using System;
using Syncfusion.iOS.TreeView;
using Syncfusion.TreeView.Engine;
using CoreGraphics;
namespace SampleBrowser
{
    public class TreeTemplate : SampleView
    {
        SfTreeView treeView;
        MailFolderViewModel viewModel;
        public TreeTemplate()
        {
            treeView = new SfTreeView();
            viewModel = new MailFolderViewModel();
            treeView.FullRowSelect = true;
            treeView.Indentation = 20;
            treeView.ExpanderWidth = 0;
            treeView.ItemHeight = 40;
            treeView.AutoExpandMode = AutoExpandMode.AllNodesExpanded;
            treeView.ChildPropertyName = "SubFolder";
            treeView.ItemsSource = viewModel.Folders;
            treeView.Adapter = new TemplateAdapter();
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
