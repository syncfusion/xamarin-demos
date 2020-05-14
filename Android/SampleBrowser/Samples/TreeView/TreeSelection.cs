#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Widget;
using Syncfusion.Android.TreeView;
using Syncfusion.TreeView.Engine;

namespace SampleBrowser
{
    public class TreeSelection : SamplePage, IDisposable
    {
        private SfTreeView treeView;
        private CountriesViewModel viewModel;
      
        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            treeView = new SfTreeView(context, null);
            viewModel = new CountriesViewModel();
            treeView.Indentation = 20;
            treeView.ExpanderWidth = 40;
            treeView.ItemHeight = 40;
            treeView.SelectionMode = SelectionMode.Multiple;
            treeView.AutoExpandMode = AutoExpandMode.RootNodesExpanded;
            treeView.ChildPropertyName = "States";
            treeView.ItemsSource = viewModel.CountriesInfo;
            treeView.Adapter = new SelectionAdapter();
            treeView.SelectedItems = viewModel.SelectedCountries;
            return treeView;
        }

        public override Android.Views.View GetPropertyWindowLayout(Android.Content.Context context)
        {
            Spinner spin = new Spinner(context, SpinnerMode.Dialog);
            List<String> adapter = new List<String>() { "Single", "Single/Deselect", "Multiple", "None" };
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerDropDownItem, adapter);
            spin.Adapter = dataAdapter;
            TextView txt = new TextView(context);
            txt.Text = "Choose Selection Mode";
            txt.TextSize = 16f;
            txt.SetPadding(10, 10, 10, 10);
            spin.SetPadding(10, 10, 10, 10);
            spin.SetSelection(2);
            spin.ItemSelected += Spin_ItemSelected;

            LinearLayout prop = new LinearLayout(context);
            prop.Orientation = Orientation.Horizontal;
            prop.AddView(txt);
            prop.AddView(spin);

            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Orientation.Vertical;
            linear.AddView(prop);

            return linear;
        }

        private void Spin_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position == 0)
            {
                treeView.SelectionMode = SelectionMode.Single;
            }

            if (e.Position == 1)
            {
                treeView.SelectionMode = SelectionMode.SingleDeselect;
            }

            if (e.Position == 2)
            {
                treeView.SelectionMode = SelectionMode.Multiple;
            }

            if (e.Position == 3)
            {
                treeView.SelectionMode = SelectionMode.None;
            }
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