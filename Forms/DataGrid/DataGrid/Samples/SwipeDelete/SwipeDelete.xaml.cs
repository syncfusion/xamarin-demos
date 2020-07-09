#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SwipeDelete.xaml.cs" company="Syncfusion.com">
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

    /// <summary>
    /// A sampleView that contains the SwipeDelete sample.
    /// </summary>
    public partial class SwipeDelete : SampleView
    {
        #region Field

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int swipedRowindex;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ContentView leftTemplateView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ContentView rightTemplateView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool isSuspend;

        #endregion

        #region Constructor 

        /// <summary>
        /// Initializes a new instance of the SwipeDelete class.
        /// </summary>
        public SwipeDelete()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets a value indicating whether FilterText has true or false value
        /// </summary>
        public bool IsUndoClicked { get; set; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Triggers while DataGrid Property was changed
        /// </summary>
        /// <param name="sender">DataGrid_PropertyChanged event sender </param>
        /// <param name="e">DataGrid_PropertyChanged args e</param>
        private void DataGrid_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width")
            {
                dataGrid.MaxSwipeOffset = dataGrid.Width;
            }          
        }

        /// <summary>
        /// Triggers while DataGrid swiping was started
        /// </summary>
        /// <param name="sender">DataGrid_SwipeStarted event sender </param>
        /// <param name="e">DataGrid_SwipeStarted args e</param>
        private void DataGrid_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            if (this.isSuspend)
            {
                e.Cancel = true;
            }             
        }

        /// <summary>
        /// Triggers while DataGrid swiping was ended
        /// </summary>
        /// <param name="sender">DataGrid_SwipeEnded event sender </param>
        /// <param name="e">DataGrid_SwipeEnded args e</param>
        private void DataGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            this.swipedRowindex = e.RowIndex;
            if (Math.Abs(e.SwipeOffset) >= dataGrid.Width)
            {
                if (e.SwipeOffset > 0)
                {
                   this.leftTemplateView.Content.IsVisible = true;
                }                  
                else
                {
                    this.rightTemplateView.Content.IsVisible = true;
                }
                   
                this.DoDeleting();
            }
        }

        /// <summary>
        /// Used this method to remove the record rows while delete was presses 
        /// </summary>
        private async void DoDeleting()
        {
            this.isSuspend = true;
            await Task.Delay(2000);
            if (this.leftTemplateView.Content.IsVisible)
            {
                this.leftTemplateView.Content.IsVisible = false;
            }              
            else if (this.rightTemplateView.Content.IsVisible)
            {
                this.rightTemplateView.Content.IsVisible = false;
            }
                
            if (!this.IsUndoClicked)
            {
                this.viewModel.OrdersInfo.RemoveAt(this.swipedRowindex - 1);
            }           
            else
            {
                var removedData = viewModel.OrdersInfo[this.swipedRowindex - 1];
                var isSelected = dataGrid.SelectedItems.Contains(removedData);
                viewModel.OrdersInfo.Remove(removedData);
                viewModel.OrdersInfo.Insert(this.swipedRowindex - 1, removedData);
                if (isSelected)
                {
                    dataGrid.SelectedItems.Add(removedData);
                }
                
                this.IsUndoClicked = false;
            }

            this.isSuspend = false;
        }

        /// <summary>
        /// Tigers while Label binding context was changed
        /// </summary>
        /// <param name="sender">Label_BindingContextChanged sender</param>
        /// <param name="e">Label_BindingContextChanged event args e</param>
        private void Label_BindingContextChanged(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label.GestureRecognizers.Count == 0)
            {
                label.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Undo) });
            }
        }

        /// <summary>
        /// Tigers while right template binding context was changed
        /// </summary>
        /// <param name="sender">RightTemplate_BindingContextChanged sender</param>
        /// <param name="e">RightTemplate_BindingContextChanged event args e</param>
        private void RightTemplate_BindingContextChanged(object sender, EventArgs e)
        {
            this.rightTemplateView = sender as ContentView;
        }

        /// <summary>
        /// Tigers while Left template binding context was changed
        /// </summary>
        /// <param name="sender">RightTemplate_BindingContextChanged sender</param>
        /// <param name="e">RightTemplate_BindingContextChanged event args e</param>
        private void LeftTemplate_BindingContextChanged(object sender, EventArgs e)
        {
            this.leftTemplateView = sender as ContentView;
        }

        /// <summary>
        /// Used this method for undo operation while label was touched
        /// </summary>
        private void Undo()
        {
            this.IsUndoClicked = true;
        }

        #endregion
    }
}
