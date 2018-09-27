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
using SampleBrowser.Core;
using Syncfusion.GridCommon.ScrollAxis;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class FrozenRowBehavior: Behavior<SampleView>
    {
        public Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private RelativeLayout relativeLayout;

        protected override void OnAttachedTo(SampleView bindable)
        {
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            relativeLayout = bindable.FindByName<RelativeLayout>("relative");
            dataGrid.GridLoaded += DataGrid_GridLoaded;
            base.OnAttachedTo(bindable);
        }

        private void DataGrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            var point = dataGrid.RowColumnIndexToPoint(new RowColumnIndex(dataGrid.FrozenRowsCount, 0));
            BoxView boxView = new BoxView();
            boxView.HeightRequest = 1.0;
            boxView.BackgroundColor = Color.FromHex("#757575");
            boxView.Opacity = 100;
            relativeLayout.Children.Add(boxView, Constraint.Constant(point.X), Constraint.Constant(point.Y + dataGrid.RowHeight), widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }));
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            dataGrid.GridLoaded -= DataGrid_GridLoaded;
            dataGrid = null;
            relativeLayout = null;
            base.OnDetachingFrom(bindable);
        }

    }
}
