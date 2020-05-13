#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Globalization;
using Android.Graphics;

namespace SampleBrowser
{
    public class Selection : SamplePage
    {
        SfDataGrid sfGrid;
        SelectionViewModel viewModel;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            sfGrid = new SfDataGrid(context);
            viewModel = new SelectionViewModel();
            sfGrid.ItemsSource = (viewModel.ProductDetails);
            sfGrid.AutoGeneratingColumn += OnAutoGenerateColumn;
            sfGrid.SelectedIndex = 1;
            sfGrid.SelectionMode = SelectionMode.Multiple;
			sfGrid.NavigationMode = NavigationMode.Cell;
            sfGrid.SelectionController = new CustomSelectionController(sfGrid);
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.GridStyle = new SelectionStyle();
            return sfGrid;
        }

        public override Android.Views.View GetPropertyWindowLayout(Android.Content.Context context)
        {
            View view = new View(context);
            Spinner spin = new Spinner(context, SpinnerMode.Dialog);
            List<String> adapter = new List<String>() { "Single", "Single/Deselect", "Multiple", "None" };
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            spin.Adapter = dataAdapter;
            TextView txt = new TextView(context);
            txt.Text = "Set Selection Mode";
            txt.TextSize = 15f;
            txt.SetPadding(10, 10, 10, 10);
            spin.SetPadding(10, 10, 10, 10);

            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Orientation.Horizontal;
            linear.AddView(txt);
            linear.AddView(spin);
            spin.SetSelection(2);
            spin.ItemSelected += OnSelectionModeChanged;
            return linear;
        }

        void OnSelectionModeChanged(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position == 0)
                sfGrid.SelectionMode = SelectionMode.Single;
            if (e.Position == 1)
                sfGrid.SelectionMode = SelectionMode.SingleDeselect;
            if (e.Position == 2)
                sfGrid.SelectionMode = SelectionMode.Multiple;
            if (e.Position == 3)
                sfGrid.SelectionMode = SelectionMode.None;
        }

        void OnAutoGenerateColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "ProductID")
            {
                e.Column.HeaderText = "Product ID";
            }
            else if (e.Column.MappingName == "Product")
            {
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "UserRating")
            {
                e.Column.HeaderText = "User Rating";
            }
            else if (e.Column.MappingName == "ProductModel")
            {
                e.Column.HeaderText = "Product Model";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Price")
            {
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
            }
            else if (e.Column.MappingName == "ShippingDays")
            {
                e.Column.HeaderText = "Shipping Days";
            }
            else if (e.Column.MappingName == "ProductType")
            {
                e.Column.HeaderText = "Product Type";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Availability")
            {
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }

        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= OnAutoGenerateColumn;
            sfGrid.Dispose();
            viewModel = null;
            sfGrid = null;
        }
    }

    public class CustomSelectionController : GridSelectionController
    {
        public CustomSelectionController(SfDataGrid sfGrid)
        {
            this.DataGrid = sfGrid;
        }
        protected override void SetSelectionAnimation(VirtualizingCellsControl rowElement)
        {
            rowElement.Alpha = 0.5f;
            rowElement.Animate().Alpha(0.5f).SetDuration(1000).AlphaBy(1f).WithEndAction(new Java.Lang.Runnable(() =>
            {
                try
                {
                    rowElement.Alpha = 1f;
                }
                catch { }
            }));
        }
    }

    public class SelectionStyle:DefaultStyle
    {
        public SelectionStyle()
        {
            
        }

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}

