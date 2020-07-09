#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedBehavior.cs" company="Syncfusion.com">
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
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.SfDataGrid.XForms.DataPager;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Paging samples
    /// </summary>
    public class GettingStartedBehavior : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.datagrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.datagrid.QueryRowHeight += this.Datagrid_QueryRowHeight;
            this.datagrid.PropertyChanged += this.Datagrid_PropertyChanged;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.datagrid = null;
            this.datagrid.QueryRowHeight -= this.Datagrid_QueryRowHeight;
            this.datagrid.PropertyChanged -= this.Datagrid_PropertyChanged;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when a row comes in to View 
        /// </summary>
        /// <param name="sender">DataGrid_QueryRowHeight sender</param>
        /// <param name="e">QueryRowHeightEventArgs parameter e</param>
        private void Datagrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if (SfDataGridHelpers.IsCaptionSummaryRow(this.datagrid, e.RowIndex))
            {
                e.Height = 40;
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    e.Height = 50;
                }

                e.Handled = true;
            }
        }

        /// <summary>
        /// Fired when a grid property is changed.
        /// </summary>
        /// <param name="sender">DataGrid_PropertyChanged sender</param>
        /// <param name="e">PropertyChangedEventArgs parameter e</param>
        private void Datagrid_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width")
            {
                this.datagrid.Columns[0].Width = this.datagrid.Width / 2;
            }
        }
    }
}
