#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SelectionBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
 
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Selection samples
    /// </summary>
    public class SelectionBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt selectionPicker;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SelectionViewModel viewModel;

        /// <summary>
        /// Triggers while selected Index was changed, used to set a SelectionMode
        /// </summary>
        /// <param name="sender">OnSelectionChanged event sender</param>
        /// <param name="e">EventArgs e</param>
        public void OnSelectionChanged(object sender, EventArgs e)
        {
            (this.dataGrid.SelectionController as SelectionController).CanApplyMultipleSelectionColor = false;
            if (this.selectionPicker.SelectedIndex == 0)
            {
                this.dataGrid.SelectionMode = Syncfusion.SfDataGrid.XForms.SelectionMode.None;
            }
            else if (this.selectionPicker.SelectedIndex == 1)
            {
                this.dataGrid.SelectionMode = Syncfusion.SfDataGrid.XForms.SelectionMode.Single;
            }
            else if (this.selectionPicker.SelectedIndex == 2)
            {
                this.dataGrid.SelectionMode = Syncfusion.SfDataGrid.XForms.SelectionMode.SingleDeselect;
            }
            else if (this.selectionPicker.SelectedIndex == 3)
            {
                this.dataGrid.SelectionMode = Syncfusion.SfDataGrid.XForms.SelectionMode.Multiple;           
            }
        }

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new SelectionViewModel();
            bindAble.BindingContext = this.viewModel;
            this.selectionPicker = bindAble.FindByName<PickerExt>("SelectionPicker");
            this.selectionPicker.Items.Add("None");
            this.selectionPicker.Items.Add("Single");
            this.selectionPicker.Items.Add("Single Deselect");
            this.selectionPicker.Items.Add("Multiple");
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.dataGrid.ItemsSource = this.viewModel.OrdersInfo;
            this.dataGrid.AllowKeyboardNavigation = true;
            this.dataGrid.SelectionController = new SelectionController(this.dataGrid);
            this.selectionPicker.SelectedIndexChanged += this.OnSelectionChanged;
            this.dataGrid.SelectedItems.Add(this.viewModel.OrdersInfo[1]);
            this.dataGrid.SelectedItems.Add(this.viewModel.OrdersInfo[3]);
            this.dataGrid.SelectedItems.Add(this.viewModel.OrdersInfo[7]);
            base.OnAttachedTo(bindAble);
        }
     
        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.selectionPicker.SelectedIndexChanged -= this.OnSelectionChanged;
            this.dataGrid = null;
            this.selectionPicker = null;
            base.OnDetachingFrom(bindAble);
        }
    }
}
