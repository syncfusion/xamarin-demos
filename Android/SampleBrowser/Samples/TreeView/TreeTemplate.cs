using Syncfusion.Android.TreeView;
using Syncfusion.TreeView.Engine;
using System;

namespace SampleBrowser
{
    public class TreeTemplate : SamplePage, IDisposable
    {
        private SfTreeView treeView;
        private MailFolderViewModel viewModel;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            treeView = new SfTreeView(context, null);
            viewModel = new MailFolderViewModel();
            treeView.FullRowSelect = true;
            treeView.Indentation = 20;
            treeView.ExpanderWidth = 40;
            treeView.ItemHeight = 40;
            treeView.AutoExpandMode = AutoExpandMode.AllNodesExpanded;
            treeView.ChildPropertyName = "SubFolder";
            treeView.ItemsSource = viewModel.Folders;
            treeView.Adapter = new TemplateAdapter();
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