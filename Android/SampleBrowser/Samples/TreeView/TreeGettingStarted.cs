#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Android.TreeView;
using Syncfusion.TreeView.Engine;

namespace SampleBrowser
{
    public class TreeGettingStarted : SamplePage
    {
        SfTreeView treeView;
        FoodSpeciesViewModel viewModel;
    
        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            treeView = new SfTreeView(context,null);
            viewModel = new FoodSpeciesViewModel();
            treeView.Indentation = 20;
            treeView.ExpanderWidth = 40;
            treeView.ItemHeight = 40;
            treeView.AutoExpandMode = AutoExpandMode.AllNodesExpanded;
            treeView.ExpandActionTarget = ExpandActionTarget.Node;
            treeView.ChildPropertyName = "Species";
            treeView.ItemsSource = viewModel.SpeciesType;
            treeView.Adapter = new GettingStartedAdapter();
            return treeView;
        }
    }
}

