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
    public class DiagonalScrollingBehaviors:Behavior<Syncfusion.SfDataGrid.XForms.SfDataGrid>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;

        protected override void OnAttachedTo(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid = bindable;
            if (Device.Idiom == TargetIdiom.Phone)
                dataGrid.DefaultColumnWidth = 120;
            else
                dataGrid.DefaultColumnWidth = 160;
            dataGrid.AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Syncfusion.SfDataGrid.XForms.SfDataGrid bindable)
        {
            dataGrid.AutoGeneratingColumn -= dataGrid_AutoGeneratingColumn;
            dataGrid = null;
            base.OnDetachingFrom(bindable);
        }

        private void dataGrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            e.Column.HeaderFontAttribute = FontAttributes.Bold;
            e.Column.Padding = new Thickness(5, 0, 5, 0);
            switch(Device.RuntimePlatform)
            {
                case Device.Android:
                    e.Column.HeaderCellTextSize = 14;
                    break;
                case Device.iOS:
                    e.Column.HeaderCellTextSize = 12;
                    break;
                case Device.UWP:
                    e.Column.HeaderCellTextSize = 12;
                    break;
            }
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    e.Column.CellTextSize = 14;
                    break;
                case Device.iOS:
                    e.Column.CellTextSize = 12;
                    break;
                case Device.UWP:
                    e.Column.CellTextSize = 12;
                    break;
            }
            e.Column.HeaderTextAlignment = TextAlignment.Start;

            if (e.Column.MappingName == "Freight")
            {
                e.Column.TextAlignment = TextAlignment.End;
                e.Column.Format = "C";
            }
            else if (e.Column.MappingName == "Gender")
            {
                e.Column.TextAlignment = TextAlignment.Start;
            }
            else if (e.Column.MappingName == "ShipCity")
            {
                e.Column.TextAlignment = TextAlignment.Start;
                e.Column.HeaderText = "Ship City";
            }
            else if (e.Column.MappingName == "ShipCountry")
            {
                e.Column.TextAlignment = TextAlignment.Start;
                e.Column.HeaderText = "Ship Country";
            }
            else if (e.Column.MappingName == "ShippingDate")
            {
                e.Column.TextAlignment = TextAlignment.Center;
                e.Column.HeaderText = "Shipping Date";
                e.Column.Format = "d";
            }
            else if (e.Column.MappingName == "IsClosed")
            {
                e.Column.HeaderText = "Is Closed";
                e.Column.TextAlignment = TextAlignment.Start;
            }
        }
    }
}
