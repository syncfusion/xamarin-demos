#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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