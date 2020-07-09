#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.iOS.TreeView;
using Syncfusion.TreeView.Engine;
using CoreGraphics;
using System.Collections.Generic;
using UIKit;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class TreeSelection : SampleView
    {
        SfTreeView treeView;
        CountriesViewModel viewModel;
        UIView option = new UIView();
        UIPickerView selectionPicker = new UIPickerView();

        public TreeSelection()
        {
            treeView = new SfTreeView();
            viewModel = new CountriesViewModel();
            treeView.Indentation = 20;
            treeView.ExpanderWidth = 40;
            treeView.ItemHeight = 40;
            treeView.SelectionMode = SelectionMode.Multiple;
            treeView.AutoExpandMode = AutoExpandMode.AllNodesExpanded;
            treeView.ChildPropertyName = "States";
            treeView.ItemsSource = viewModel.CountriesInfo;
            treeView.Adapter = new SelectionAdapter();
            treeView.SelectedItems = viewModel.SelectedCountries;
            this.AddSubview(treeView);
            this.OptionView = option;
        }
        public override void LayoutSubviews()
        {
            this.treeView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
            this.CreateOptionView();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void CreateOptionView()
        {
            List<string> index = new List<string> { "Multiple", "SingleDeselect", "Single", "None" };
            var picker = new TreeViewPickerModel(index);

            selectionPicker.Model = picker;
            selectionPicker.SelectedRowInComponent(0);
            selectionPicker.ShowSelectionIndicator = true;
            selectionPicker.Frame = new CGRect(0, 100, this.Frame.Width, this.Frame.Height / 3);
            picker.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue == "Single")
                    treeView.SelectionMode = SelectionMode.Single;
                else if (e.SelectedValue == "SingleDeselect")
                    treeView.SelectionMode = SelectionMode.SingleDeselect;
                else if (e.SelectedValue == "Multiple")
                    treeView.SelectionMode = SelectionMode.Multiple;
                else if (e.SelectedValue == "None")
                    treeView.SelectionMode = SelectionMode.None;
            };
            this.OptionView.AddSubview(selectionPicker);
        }
    }
}
