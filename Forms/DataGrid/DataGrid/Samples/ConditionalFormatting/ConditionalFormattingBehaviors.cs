#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ConditionalFormattingBehaviors.cs" company="Syncfusion.com">
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.Data.Extensions;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the ConditionalFormatting samples
    /// </summary>
    public class ConditionalFormattingBehaviors : Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="dataGrid">DataGrid type parameter as dataGrid</param>
        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid)
        {
            dataGrid.QueryCellStyle += this.DataGrid_QueryCellStyle;
            base.OnAttachedTo(dataGrid);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="dataGrid">DataGrid type parameter as dataGrid</param>
        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid)
        {
            dataGrid.QueryCellStyle -= this.DataGrid_QueryCellStyle;
            base.OnDetachingFrom(dataGrid);
        }

        /// <summary>
        /// Fired when a cell comes to the View 
        /// </summary>
        /// <param name="sender">DataGrid_QueryCellStyle event sender</param>
        /// <param name="e">DataGrid_QueryCellStyle event args</param>
        private void DataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            if (e.Column.MappingName == "Name")
            {
                e.Style.FontAttribute = FontAttributes.Bold;
                e.Handled = true;
            }
        }
    }
}
