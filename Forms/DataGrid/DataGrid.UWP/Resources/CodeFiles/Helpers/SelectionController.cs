#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    public class SelectionController : GridSelectionController
    {
        public bool CanApplyMultipleSelectionColor { get; set; }

        public Color[] SelectionColors { get; set; }

        public SelectionController(Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid) : base(datagrid)
        {
            this.DataGrid = datagrid;
            SelectionColors = new Color[]
            {
            Color.FromRgb(176,58,46),
            Color.FromRgb(108,52,131),
            Color.FromRgb(31,97,141),
            Color.FromRgb(17,122,101),
            Color.FromRgb(183,140,11)
            };
        }
        //Code to set multiple selection colors
        public override Color GetSelectionColor(int rowIndex, object rowData)
        {
            if (CanApplyMultipleSelectionColor && SelectionColors != null)
                return SelectionColors[rowIndex % 5];
            else
                return Color.FromRgb(76, 161, 254);
        }
    }
}
