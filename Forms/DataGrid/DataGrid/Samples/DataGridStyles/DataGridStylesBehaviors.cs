#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DataGridStylesBehaviors.cs" company="Syncfusion.com">
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
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the DataGridStyles samples
    /// </summary>
    public class DataGridStylesBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private StylesViewModel viewModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt stylePicker;

        /// <summary>
        /// Used to change a GridStyle based on selected Index
        /// </summary>
        /// <param name="sender">OnStyleChanged event sender</param>
        /// <param name="e">EventArgs e</param>
        public void OnStyleChanged(object sender, EventArgs e)
        {
            if (this.stylePicker.SelectedIndex == 0)
            {
                this.dataGrid.GridStyle = new Dark();
            }
            else if (this.stylePicker.SelectedIndex == 1)
            {
                this.dataGrid.GridStyle = new Blue();
            }
            else if (this.stylePicker.SelectedIndex == 2)
            {
                this.dataGrid.GridStyle = new Red();
            }
            else if (this.stylePicker.SelectedIndex == 3)
            {
                this.dataGrid.GridStyle = new Green();
            }
            else if (this.stylePicker.SelectedIndex == 4)
            {
                this.dataGrid.GridStyle = new Purple();
            }
        }

        /// <summary>
        /// Fired when DataGrid View is created
        /// </summary>
        /// <param name="sender">GridViewCreated event sender</param>
        /// <param name="e">GridViewCreatedEventArgs e</param>
        public void GridViewCreated(object sender, GridViewCreatedEventArgs e)
        {
            this.dataGrid.SelectedItem = this.viewModel.OrdersInfo[3];
        }

        /// <summary>
        /// You can override this method to subscribe to Associated Object events and initialize properties.
        /// </summary>
        /// <param name="bindAble">A sample View type of parameter bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.viewModel = new StylesViewModel();
            bindAble.BindingContext = this.viewModel;
            this.dataGrid.ItemsSource = this.viewModel.OrdersInfo;
            this.dataGrid.GridViewCreated += this.GridViewCreated;
            this.stylePicker = bindAble.FindByName<PickerExt>("StylePicker");
            this.stylePicker.Items.Add("Dark");
            this.stylePicker.Items.Add("Blue");
            this.stylePicker.Items.Add("Red");
            this.stylePicker.Items.Add("Green");
            this.stylePicker.Items.Add("Purple");
            this.stylePicker.SelectedIndex = 1;
            this.stylePicker.SelectedIndexChanged += this.OnStyleChanged;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of parameter bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.dataGrid.GridViewCreated -= this.GridViewCreated;
            this.stylePicker.SelectedIndexChanged -= this.OnStyleChanged;
            this.dataGrid = null;
            this.stylePicker = null;
            base.OnDetachingFrom(bindAble);
        }
    }
}
