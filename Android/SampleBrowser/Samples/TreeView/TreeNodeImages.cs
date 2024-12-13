using Syncfusion.Android.TreeView;
using Syncfusion.TreeView.Engine;
using System;

namespace SampleBrowser
{
    public class TreeNodeImages : SamplePage, IDisposable
    {
        private SfTreeView treeView;
        private FileManagerViewModel viewModel;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            treeView = new SfTreeView(context, null);
            viewModel = new FileManagerViewModel();
            treeView.Indentation = 20;
            treeView.ExpanderWidth = 40;
            treeView.ItemHeight = 45;
            treeView.AutoExpandMode = AutoExpandMode.AllNodesExpanded;
            treeView.ChildPropertyName = "SubFolder";
            treeView.ItemsSource = viewModel.Folders;
            treeView.Adapter = new NodeImageAdapter();
            return treeView;
        }

        public void Dispose()
        {
            if (treeView != null)
            {
                treeView.Dispose();
                treeView = null;
            }
        }
    }
}