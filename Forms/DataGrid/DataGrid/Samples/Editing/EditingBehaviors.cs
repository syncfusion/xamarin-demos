#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EditingBehaviors.cs" company="Syncfusion.com">
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
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
 
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Editing samples
    /// </summary>
    public class EditingBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid myGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid transparent;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid customView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfDataGrid dataGrid;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected async override void OnAttachedTo(SampleView bindAble)
        {
            var assembly = Assembly.GetAssembly(Application.Current.GetType());
            await Task.Delay(200);
            this.customView = bindAble.FindByName<Grid>("customLayout");
            this.transparent = bindAble.FindByName<Grid>("transparent");
            this.dataGrid = bindAble.FindByName<SfDataGrid>("dataGrid");
            this.dataGrid.CurrentCellEndEdit += this.DataGrid_CurrentCellEndEdit;
            this.myGrid = new Grid();
            this.myGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.RowDefinitions = new RowDefinitionCollection
            {
            new RowDefinition { Height = new GridLength(1.1, GridUnitType.Star) },
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            };
            this.myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            this.myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.8, GridUnitType.Star) });
            this.myGrid.Children.Add(
                new Image()
            {
                Opacity = 1.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = "EditIllustration.png",
            },
            1, 
            1);
            this.myGrid.BackgroundColor = Color.Transparent;
            this.myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Collapse) });
            this.customView.Children.Add(this.myGrid);

            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.dataGrid.CurrentCellEndEdit += this.DataGrid_CurrentCellEndEdit;
            this.myGrid = null;
            this.transparent = null;
            this.customView = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Occurs when the edit mode ends for current cell.
        /// </summary>
        /// <param name="sender">The DataGrid instance.</param>
        /// <param name="e">Provides data of current cell.</param>
        private void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs e)
        {
            var datagrid = sender as SfDataGrid;
            if (datagrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName != "ShipCountry")
            {
                return;
            }

            if ((string)e.NewValue != (string)e.OldValue)
            {
                var datarow = datagrid.GetRowGenerator().Items.FirstOrDefault(dr => dr.RowIndex == e.RowColumnIndex.RowIndex);
                (datarow.RowData as DealerInfo).ShipCity = null;
                datarow.IsSelectedRow = false;
                this.dataGrid.UpdateDataRow(e.RowColumnIndex.RowIndex);
            }
        }

        /// <summary>
        /// Used this method for removing the child element of CustomView 
        /// </summary>
        private void Collapse()
        {
            this.myGrid.IsEnabled = false;
            this.myGrid.IsVisible = false;
            this.transparent.IsVisible = false;
            this.customView.Children.Remove(this.myGrid);
            this.customView.Children.Remove(this.transparent);
        }
    }
}
