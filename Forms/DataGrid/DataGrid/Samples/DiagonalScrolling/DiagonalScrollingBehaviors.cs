#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DiagonalScrollingBehaviors.cs" company="Syncfusion.com">
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
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the DiagonalScrolling samples
    /// </summary>
    public class DiagonalScrollingBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Switch switch1;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">DataGrid type of bindAble parameter</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.dataGrid = bindAble.FindByName<SfDataGrid>("dataGrid");
            if (Device.Idiom == TargetIdiom.Phone)
            {
                this.dataGrid.DefaultColumnWidth = 120;
            }
            else
            {
                this.dataGrid.DefaultColumnWidth = 160;
            }

            this.dataGrid.AutoGeneratingColumn += this.DataGrid_AutoGeneratingColumn;
            this.switch1 = bindAble.FindByName<Switch>("switch1");
            this.switch1.Toggled += this.Switch1_Toggled;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">DataGrid type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.dataGrid.AutoGeneratingColumn -= this.DataGrid_AutoGeneratingColumn;
            this.dataGrid = null;
            this.switch1.Toggled -= this.Switch1_Toggled;
            this.switch1 = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Triggers when switch state changed.
        /// </summary>
        /// <param name="sender">Switch1_Toggled event sender</param>
        /// <param name="e">Switch1_Toggled event args e</param>
        private void Switch1_Toggled(object sender, ToggledEventArgs e)
        {
            this.dataGrid.AllowDiagonalScrolling = e.Value;
        }

        /// <summary>
        /// Fired when column is generated in DataGrid
        /// </summary>
        /// <param name="sender">DataGrid_AutoGeneratingColumn sender</param>
        /// <param name="e">DataGrid_AutoGeneratingColumn event args e</param>
        private void DataGrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            e.Column.HeaderFontAttribute = FontAttributes.Bold;
            e.Column.Padding = new Thickness(5, 0, 5, 0);
            switch (Device.RuntimePlatform)
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
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = TextAlignment.End;
            }
        }
    }
}
