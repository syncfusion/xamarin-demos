#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class UnboundColumnsBehaviors : Behavior<SampleView>
    {
        public Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        protected override void OnAttachedTo(SampleView bindable)
        {
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            dataGrid.QueryCellStyle += DataGrid_QueryCellStyle;
            base.OnAttachedTo(bindable);
        }

        private void DataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Style.BackgroundColor = Color.FromRgb(225, 245, 254);
            }
            e.Handled = true;
        }
    }
}
