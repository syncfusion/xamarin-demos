#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    public class GroupCaptionRenderer : GridCaptionSummaryCellRenderer
    {
        public override void OnInitializeDisplayView(DataColumnBase dataColumn, SfLabel view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            if (view != null)
            {
                view.TextColor = Color.FromHex("#0079FF");
                view.FontFamily = dataColumn.GridColumn.RecordFont;
                view.FontSize = 16;
            }
        }
    }

    public class TableSummaryRenderer : GridTableSummaryCellRenderer
    {
        public TableSummaryRenderer()
        {

        }

        public override void OnInitializeDisplayView(DataColumnBase dataColumn, SfLabel view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            if (view != null)
            {
                view.FontFamily = dataColumn.GridColumn.RecordFont;
                view.FontAttributes = Xamarin.Forms.FontAttributes.Bold;
                view.FontSize = 16;
            }

        }
    }

}
