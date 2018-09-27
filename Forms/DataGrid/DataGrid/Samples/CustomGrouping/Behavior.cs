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
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class CustomGroupingBehavior : Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid = bindable;
            dataGrid.CellRenderers.Remove("CaptionSummary");
            dataGrid.CellRenderers.Add("CaptionSummary", new GroupCaptionRenderer());
            dataGrid.CellRenderers.Remove("TableSummary");
            dataGrid.CellRenderers.Add("TableSummary", new TableSummaryRenderer());
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
