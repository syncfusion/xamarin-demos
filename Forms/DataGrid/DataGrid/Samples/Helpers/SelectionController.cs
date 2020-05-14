#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SelectionController.cs" company="Syncfusion.com">
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
    /// A custom selection controller for Grid 
    /// </summary>
    public class SelectionController : GridSelectionController
    {
        /// <summary>
        /// Initializes a new instance of the SelectionController class.
        /// </summary>
        /// <param name="datagrid">DataGrid type of Parameter</param>
        public SelectionController(Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid) : base(datagrid)
        {
            this.DataGrid = datagrid;
            this.SelectionColors = new Color[]
            {
            Color.FromRgb(176, 58, 46),
            Color.FromRgb(108, 52, 131),
            Color.FromRgb(31, 97, 141),
            Color.FromRgb(17, 122, 101),
            Color.FromRgb(183, 140, 11)
            };
        }

        /// <summary>
        /// Gets or sets a value indicating whether CanApplyMultipleSelectionColor has true or false value
        /// </summary>
        public bool CanApplyMultipleSelectionColor { get; set; }

        /// <summary>
        /// Gets or sets the array of SelectionColors.
        /// </summary>
        public Color[] SelectionColors { get; set; }

        /// <summary>
        /// Gets the selection color for the given row.
        /// </summary>
        /// <param name="rowIndex">integer type of parameter rowIndex</param>
        /// <param name="rowData">integer type of parameter row data</param>
        /// <returns>returns the given color</returns>
        public override Color GetSelectionColor(int rowIndex, object rowData)
        {
            if (this.CanApplyMultipleSelectionColor && this.SelectionColors != null)
            {
                return this.SelectionColors[rowIndex % 5];
            }              
            else
            {
                return Color.FromHex("#b2d8f7");
            }              
        }
    }
}
