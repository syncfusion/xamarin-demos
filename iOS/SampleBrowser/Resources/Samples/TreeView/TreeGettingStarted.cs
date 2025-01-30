using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using CoreGraphics;
using UIKit;
using Syncfusion.iOS.TreeView;
using Syncfusion.TreeView.Engine;
namespace SampleBrowser
{
    public class TreeGettingStarted : SampleView
    {
        SfTreeView treeView;
        FoodSpeciesViewModel viewModel;
        public TreeGettingStarted()
        {
            treeView = new SfTreeView();
            viewModel = new FoodSpeciesViewModel();
			treeView.FullRowSelect = true;
            treeView.AutoExpandMode = AutoExpandMode.AllNodesExpanded;
            treeView.ExpandActionTarget = ExpandActionTarget.Node;
            treeView.ChildPropertyName = "Species";
            treeView.ItemsSource = viewModel.SpeciesType;
            treeView.Adapter = new GettingStartedAdapter();
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