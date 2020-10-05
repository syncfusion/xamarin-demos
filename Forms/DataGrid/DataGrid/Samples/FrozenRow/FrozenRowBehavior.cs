#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "FrozenRowBehavior.cs" company="Syncfusion.com">
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
    using SampleBrowser.Core;
    using Syncfusion.GridCommon.ScrollAxis;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;
 
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the FrozenRow samples
    /// </summary>
    public class FrozenRowBehavior : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private RelativeLayout relativeLayout;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">A sampleView type of parameter bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.relativeLayout = bindAble.FindByName<RelativeLayout>("relative");
            this.dataGrid.GridLoaded += this.DataGrid_GridLoaded;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.dataGrid.GridLoaded -= this.DataGrid_GridLoaded;
            this.dataGrid = null;
            this.relativeLayout = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when DataGrid is loaded 
        /// </summary>
        /// <param name="sender">DataGrid_GridLoaded event sender</param>
        /// <param name="e">GridLoadedEventArgs of e</param>
        private void DataGrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            var point = this.dataGrid.RowColumnIndexToPoint(new RowColumnIndex(this.dataGrid.FrozenRowsCount, 0));
            BoxView boxView = new BoxView();
            boxView.HeightRequest = 1.0;
            boxView.BackgroundColor = Color.FromHex("#757575");
            boxView.Opacity = 100;
            this.relativeLayout.Children.Add(boxView, Constraint.Constant(point.X), Constraint.Constant(point.Y + this.dataGrid.RowHeight), widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }));
        }
    }
}
