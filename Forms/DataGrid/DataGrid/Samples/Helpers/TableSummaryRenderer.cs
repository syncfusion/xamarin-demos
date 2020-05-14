#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "TableSummaryRenderer.cs" company="Syncfusion.com">
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
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    /// <summary>
    ///  Creates TableSummary cells with desired properties
    /// </summary>
    public class TableSummaryRenderer : GridTableSummaryCellRenderer
    {
        /// <summary>
        /// Initializes a new instance of the TableSummaryRenderer class.
        /// </summary>
        public TableSummaryRenderer()
        {
        }

        /// <summary>
        /// Override method to get a custom Display View as Label
        /// </summary>
        /// <param name="dataColumn">DataColumnBase type of dataColumn parameter</param>
        /// <param name="view">view is Label type parameter</param>
        public override void OnInitializeDisplayView(DataColumnBase dataColumn, SfLabel view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            if (view != null)
            {
                view.FontFamily = dataColumn.GridColumn.RecordFont;
                view.FontAttributes = Xamarin.Forms.FontAttributes.Bold;
                if (Device.RuntimePlatform == Device.WPF)
                {
                    view.FontSize = 13;
                }
                else
                {
                    view.FontSize = 16;
                }
            }
        }
    }
}
