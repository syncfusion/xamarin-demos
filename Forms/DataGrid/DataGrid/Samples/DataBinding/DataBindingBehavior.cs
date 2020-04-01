#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DataBindingBehavior.cs" company="Syncfusion.com">
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
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.SfDataGrid.XForms.DataPager;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Paging samples
    /// </summary>
    public class DataBindingBehavior : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt selectionPicker;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DataBindingViewModel getGettingStartedViewModel;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.datagrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.getGettingStartedViewModel = new DataBindingViewModel();
            this.selectionPicker = bindAble.FindByName<PickerExt>("SelectionPicker");
            this.selectionPicker.Items.Add("Observable Collection");
            this.selectionPicker.Items.Add("DataTable");
            this.selectionPicker.SelectedIndexChanged += this.SelectionPicker_SelectedIndexChanged;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.datagrid = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Triggers while selected Index was changed, used to set a Collection
        /// </summary>
        /// <param name="sender">OnSelectionChanged event sender</param>
        /// <param name="e">EventArgs e</param>
        private void SelectionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectionPicker.SelectedIndex == 0)
            {
                this.datagrid.Columns.Clear();
                this.datagrid.ItemsSource = this.getGettingStartedViewModel.OrdersInfo;
                GridTextColumn orderIdColumn = new GridTextColumn();
                orderIdColumn.MappingName = "OrderID";
                orderIdColumn.HeaderText = "Order ID";
                orderIdColumn.LineBreakMode = LineBreakMode.TailTruncation;
                orderIdColumn.HeaderFontAttribute = FontAttributes.Bold;
                orderIdColumn.TextAlignment = TextAlignment.End;
                orderIdColumn.HeaderTextAlignment = TextAlignment.Start;
                orderIdColumn.HeaderCellTextSize = 13;
                orderIdColumn.CellTextSize = 13;
                orderIdColumn.Padding = new Thickness(5, 0, 5, 0);

                GridTextColumn customerIdColumn = new GridTextColumn();
                customerIdColumn.MappingName = "EmployeeID";
                customerIdColumn.HeaderText = "Customer ID";
                customerIdColumn.HeaderFontAttribute = FontAttributes.Bold;
                customerIdColumn.LineBreakMode = LineBreakMode.TailTruncation;
                customerIdColumn.TextAlignment = TextAlignment.End;
                customerIdColumn.HeaderTextAlignment = TextAlignment.Start;
                customerIdColumn.HeaderCellTextSize = 13;
                customerIdColumn.CellTextSize = 13;
                customerIdColumn.Padding = new Thickness(5, 0, 5, 0);

                GridTextColumn customerColumn = new GridTextColumn();
                customerColumn.MappingName = "CustomerID";
                customerColumn.HeaderText = "Name";
                customerColumn.HeaderFontAttribute = FontAttributes.Bold;
                customerColumn.LineBreakMode = LineBreakMode.TailTruncation;
                customerColumn.TextAlignment = TextAlignment.Start;
                customerColumn.HeaderTextAlignment = TextAlignment.Start;
                customerColumn.HeaderCellTextSize = 13;
                customerColumn.CellTextSize = 13;
                customerColumn.Padding = new Thickness(5, 0, 0, 0);

                GridTextColumn cityColumn = new GridTextColumn();
                cityColumn.MappingName = "ShipCity";
                cityColumn.HeaderText = "City";
                cityColumn.HeaderFontAttribute = FontAttributes.Bold;
                cityColumn.LineBreakMode = LineBreakMode.TailTruncation;
                cityColumn.TextAlignment = TextAlignment.Start;
                cityColumn.HeaderTextAlignment = TextAlignment.Start;
                cityColumn.HeaderCellTextSize = 13;
                cityColumn.CellTextSize = 13;
                cityColumn.Padding = new Thickness(5, 0, 0, 0);

                this.datagrid.Columns.Add(orderIdColumn);
                this.datagrid.Columns.Add(customerIdColumn);
                this.datagrid.Columns.Add(customerColumn);
                this.datagrid.Columns.Add(cityColumn);
            }
            else if (this.selectionPicker.SelectedIndex == 1)
            {
                this.datagrid.Columns.Clear();
                this.datagrid.ItemsSource = this.GetDataTable();
                GridTextColumn customerId = new GridTextColumn();
                customerId.MappingName = "CustomerID";
                customerId.HeaderText = "Customer ID";
                customerId.HeaderFontAttribute = FontAttributes.Bold;
                customerId.LineBreakMode = LineBreakMode.WordWrap;
                customerId.TextAlignment = TextAlignment.Start;
                customerId.HeaderTextAlignment = TextAlignment.Start;
                customerId.HeaderCellTextSize = 13;
                customerId.CellTextSize = 13;
                customerId.Padding = new Thickness(5, 0, 5, 0);

                GridTextColumn companyName = new GridTextColumn();
                companyName.MappingName = "Company";
                companyName.HeaderText = "Company";
                companyName.HeaderFontAttribute = FontAttributes.Bold;
                companyName.LineBreakMode = LineBreakMode.WordWrap;
                companyName.TextAlignment = TextAlignment.Start;
                companyName.HeaderTextAlignment = TextAlignment.Start;
                companyName.HeaderCellTextSize = 13;
                companyName.CellTextSize = 13;
                companyName.Padding = new Thickness(5, 0, 5, 0);

                GridTextColumn contactName = new GridTextColumn();
                contactName.MappingName = "ContactName";
                contactName.HeaderText = "Contact Name";
                contactName.HeaderFontAttribute = FontAttributes.Bold;
                contactName.LineBreakMode = LineBreakMode.WordWrap;
                contactName.TextAlignment = TextAlignment.Start;
                contactName.HeaderTextAlignment = TextAlignment.Start;
                contactName.HeaderCellTextSize = 13;
                contactName.CellTextSize = 13;
                contactName.Padding = new Thickness(5, 0, 0, 0);

                GridTextColumn city = new GridTextColumn();
                city.MappingName = "City";
                city.HeaderText = "City";
                city.HeaderFontAttribute = FontAttributes.Bold;
                city.LineBreakMode = LineBreakMode.WordWrap;
                city.TextAlignment = TextAlignment.Start;
                city.HeaderTextAlignment = TextAlignment.Start;
                city.HeaderCellTextSize = 13;
                city.CellTextSize = 13;
                city.Padding = new Thickness(5, 0, 0, 0);

                this.datagrid.Columns.Add(customerId);
                this.datagrid.Columns.Add(companyName);
                this.datagrid.Columns.Add(contactName);
                this.datagrid.Columns.Add(city);
            }
        }

        /// <summary>
        /// Create the DataTable
        /// </summary>
        /// <returns>Data Table</returns>
        private DataTable GetDataTable()
        {
            DataTable employeeCollection = new DataTable();
            employeeCollection.Columns.Add("CustomerID", typeof(string));
            employeeCollection.Columns.Add("Company", typeof(string));
            employeeCollection.Columns.Add("ContactName", typeof(string));
            employeeCollection.Columns.Add("City", typeof(string));
            employeeCollection.Rows.Add("ALFKI", "Alferds Futterkiste", "Maria Anders", "Berlin");
            employeeCollection.Rows.Add("ANATR", "Ana Trujilo Emparedados y Hela", "Ana Trujilo", "Mexico D.F.");
            employeeCollection.Rows.Add("ANTON", "Antonio Moreno Taqueria", "Antonio Moreno", "Mexico D.F.");
            employeeCollection.Rows.Add("AROUT", "Around the Horn", "Thomas Hardy", "London");
            employeeCollection.Rows.Add("BERGS", "Berglunds Snabbkop", "Christina Berglund", "Lulea");
            employeeCollection.Rows.Add("BLAUS", "Blauer see Delikatessen", "Hanna Moss", "Mannheim");
            employeeCollection.Rows.Add("BLONP", "Blondel Pere et Fils", "Erederique Citeaux", "Strasbourg");
            employeeCollection.Rows.Add("BOLID", "Bolids Comidas Preparadas", "Martin Sommer", "Madrid");
            employeeCollection.Rows.Add("BONP", "Bon App", "Laurence Lebihan", "Marseille");
            employeeCollection.Rows.Add("BOTTM", "Bottom-Dollar Markets", "Elizabeth Lincoln", "Tsawassen");
            employeeCollection.Rows.Add("BSBEV", "B's Beverages", "Victoria Ashworth", "London");
            employeeCollection.Rows.Add("CACTU", "Cactus Comidas para llevar", "Patricio Simpson", "Bueno Aires");
            employeeCollection.Rows.Add("CENTC", "Centro Comercial Moctezuma", "Francisco Chang", "Mexico D.F.");
            employeeCollection.Rows.Add("CHOPS", "Chop-Suey Chinese", "Yang Wang", "Bern");
            employeeCollection.Rows.Add("COMMI", "Comercio Minerio", "Pedro Afonso", "Sao Paulo");
            employeeCollection.Rows.Add("CONSH", "Consolidated Holdings", "Elizabeth Brown", "London");
            employeeCollection.Rows.Add("DRACD", "Drachenblut Entier", "Sven Ottlieb", "Aachen");
            employeeCollection.Rows.Add("DUMON", "Dumonde Entier", "Janine Labrune", "Nantes");
            employeeCollection.Rows.Add("EASTC", "Eastern Connection", "Ann Devon", "London");
            employeeCollection.Rows.Add("ERNSH", "Ernst Handel", "Roland Mendel", "Graz");
            return employeeCollection;
        }
    }
}
