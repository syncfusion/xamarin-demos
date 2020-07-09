#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.TreeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public partial class GettingStarted : SampleView
    {
        public GettingStarted()
        {
            InitializeComponent();
        }
    }

    public class TreeViewGettingStartedBehavior : Behavior<SampleView>
    {
        #region Fields

        private Syncfusion.XForms.TreeView.SfTreeView TreeView;
        private Picker animationPicker;
        private Picker expanderPositionPicker;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(SampleView bindable)
        {
            TreeView = bindable.FindByName<Syncfusion.XForms.TreeView.SfTreeView>("treeView");

            animationPicker = bindable.FindByName<Picker>("enableAnimation");
            animationPicker.Items.Add("False");
            animationPicker.Items.Add("True");
            animationPicker.SelectedIndex = 1;
            animationPicker.SelectedIndexChanged += EnableAnimation_SelectedIndexChanged;

            expanderPositionPicker = bindable.FindByName<Picker>("expanderPosition");
            expanderPositionPicker.Items.Add("Start");
            expanderPositionPicker.Items.Add("End");
            expanderPositionPicker.SelectedIndex = 0;
            expanderPositionPicker.SelectedIndexChanged += ExpanderPosition_SelectedIndexChanged;

            base.OnAttachedTo(bindable);
        }

        private void EnableAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animationPicker.SelectedIndex == 0)
                TreeView.IsAnimationEnabled = false;
            else if (animationPicker.SelectedIndex == 1)
                TreeView.IsAnimationEnabled = true;
        }

        private void ExpanderPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expanderPositionPicker.SelectedIndex == 0)
                TreeView.ExpanderPosition = ExpanderPosition.Start;
            else if (expanderPositionPicker.SelectedIndex == 1)
                TreeView.ExpanderPosition = ExpanderPosition.End;
        }

        #endregion
    }

}
