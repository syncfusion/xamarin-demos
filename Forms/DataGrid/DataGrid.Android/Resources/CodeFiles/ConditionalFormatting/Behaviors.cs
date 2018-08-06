#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ConditionalFormattingBehaviors: Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid)
        {
            dataGrid.QueryCellStyle += DataGrid_QueryCellStyle;
            base.OnAttachedTo(dataGrid);
        }

        private void DataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            if(e.Column.MappingName == "Name")
            {
                e.Style.FontAttribute = FontAttributes.Bold;
                e.Handled = true;
            }
        }

        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid)
        {
            dataGrid.QueryCellStyle -= DataGrid_QueryCellStyle;
            base.OnDetachingFrom(dataGrid);
        }
    }
}
