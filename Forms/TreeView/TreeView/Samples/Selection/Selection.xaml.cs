#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.TreeView.Engine;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace SampleBrowser.SfTreeView
{
    public partial class Selection : SampleView
	{
		public Selection ()
		{
			InitializeComponent ();
		}
    }
    public class TreeViewSelectionBehavior : Behavior<SampleView>
    {
        #region Fields

        private Syncfusion.XForms.TreeView.SfTreeView TreeView;
        private Picker modePicker;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(SampleView bindable)
        {
            TreeView = bindable.FindByName<Syncfusion.XForms.TreeView.SfTreeView>("treeView");

            modePicker = bindable.FindByName<Picker>("selectionModePicker");
            modePicker.Items.Add("Single");
            modePicker.Items.Add("SingleDeselect");
            modePicker.Items.Add("Multiple");
            modePicker.Items.Add("Extended");
            modePicker.Items.Add("None");
            modePicker.SelectedIndex = 2;
            modePicker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            base.OnAttachedTo(bindable);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modePicker.SelectedIndex == 0)
                TreeView.SelectionMode = Syncfusion.XForms.TreeView.SelectionMode.Single;
            else if (modePicker.SelectedIndex == 1)
                TreeView.SelectionMode = Syncfusion.XForms.TreeView.SelectionMode.SingleDeselect;
            else if (modePicker.SelectedIndex == 2)
                TreeView.SelectionMode = Syncfusion.XForms.TreeView.SelectionMode.Multiple;
            else if (modePicker.SelectedIndex == 3)
                TreeView.SelectionMode = Syncfusion.XForms.TreeView.SelectionMode.Extended;
            else if (modePicker.SelectedIndex == 4)
                TreeView.SelectionMode = Syncfusion.XForms.TreeView.SelectionMode.None;
        }
      
        #endregion
    } 
}