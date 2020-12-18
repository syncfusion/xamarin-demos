#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomGroupingBehavior.cs" company="Syncfusion.com">
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
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  CustomGrouping samples
    /// </summary>
    public class CustomGroupingBehavior : Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">dataGrid type of bindAble</param>
        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid bindAble)
        {
            this.dataGrid = bindAble;
            this.dataGrid.CellRenderers.Remove("CaptionSummary");
            this.dataGrid.CellRenderers.Add("CaptionSummary", new GroupCaptionRenderer());
            this.dataGrid.CellRenderers.Remove("TableSummary");
            this.dataGrid.CellRenderers.Add("TableSummary", new TableSummaryRenderer());
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">DataGrid type of parameter bindAble</param>
        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid bindAble)
        {
            this.dataGrid = null;
            base.OnDetachingFrom(bindAble);
        }
    }
}
