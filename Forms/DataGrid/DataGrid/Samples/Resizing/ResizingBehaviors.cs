#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ResizingBehaviors.cs" company="Syncfusion.com">
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
    using Syncfusion.Data.Extensions;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Resizing samples
    /// </summary>
    public class ResizingBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid myGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt resizingPicker;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid customView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid transparent;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of parameter bindAble</param>
        protected async override void OnAttachedTo(SampleView bindAble)
        {
            var assembly = Assembly.GetAssembly(this.GetType());
            await Task.Delay(200);
            this.customView = bindAble.FindByName<Grid>("customLayout");
            this.transparent = bindAble.FindByName<Grid>("transparent");
            this.datagrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.resizingPicker = bindAble.FindByName<PickerExt>("ResizingPicker");
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                this.datagrid.Columns.ForEach(column => column.MaximumWidth = 500);
            }
                
            if (Device.RuntimePlatform != Device.UWP)
            {
                this.datagrid.ResizingMode = ResizingMode.OnMoved;
                this.resizingPicker.SelectedIndex = 0;
            }
            else
            {
                this.datagrid.ResizingMode = ResizingMode.OnTouchUp;
                this.resizingPicker.SelectedIndex = 1;
            }

            this.resizingPicker.SelectedIndexChanged += this.OnSelectionChanged;
            this.datagrid.GridStyle = new DefaultStyle();
            this.myGrid = new Grid();
            this.myGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(0.6, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            };
            this.myGrid.Children.Add(
                new Image()
            {
                Opacity = 1.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = "ResizingIllustration.png",
            }, 
            0, 
            0);
            this.myGrid.BackgroundColor = Color.Transparent;
            this.myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Collapse) });
            this.customView.Children.Add(this.myGrid);

            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.resizingPicker.SelectedIndexChanged -= this.OnSelectionChanged;
            this.datagrid = null;
            this.myGrid = null;
            this.transparent = null;
            this.customView = null;
            this.resizingPicker = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Used this method to remove the grid from CustomView 
        /// </summary>
        private void Collapse()
        {
            this.myGrid.Opacity = 1.0;
            this.myGrid.IsEnabled = false;
            this.myGrid.IsVisible = false;
            this.transparent.IsVisible = false;
            this.customView.Children.Remove(this.myGrid);
            this.customView.Children.Remove(this.transparent);
        }

        /// <summary>
        /// Triggers when resizing picker selection was changed
        /// </summary>
        /// <param name="sender">OnSelectionChanged event sender</param>
        /// <param name="e">OnSelectionChanged args e</param>
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (this.resizingPicker.SelectedIndex == 0)
            {
                this.datagrid.ResizingMode = ResizingMode.OnMoved;
            }
            else
            {
                this.datagrid.ResizingMode = ResizingMode.OnTouchUp;
            }
        }
    }
}
