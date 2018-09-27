#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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

namespace SampleBrowser.SfDataGrid
{
    public partial class SwipeDelete : SampleView
    {
        #region Property

        public bool IsUndoClicked { get; set; }

        #endregion

        #region Field

        private int swipedRowindex;
        private ContentView leftTemplateView;
        private ContentView rightTemplateView;
        private bool isSuspend;

        #endregion

        #region Constructor 

        public SwipeDelete()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void dataGrid_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width")
                dataGrid.MaxSwipeOffset = dataGrid.Width;
        }

        private void dataGrid_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            if (isSuspend)
                e.Cancel = true;
        }

        private void dataGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            swipedRowindex = e.RowIndex;
            if (Math.Abs(e.SwipeOffset) >= dataGrid.Width)
            {
                if (e.SwipeOffset > 0)
                    leftTemplateView.Content.IsVisible = true;
                else
                    rightTemplateView.Content.IsVisible = true;
                doDeleting();
            }
        }


        private async void doDeleting()
        {
            isSuspend = true;
            await Task.Delay(2000);
            if (leftTemplateView.Content.IsVisible)
                leftTemplateView.Content.IsVisible = false;
            else if (rightTemplateView.Content.IsVisible)
                rightTemplateView.Content.IsVisible = false;
            if (!IsUndoClicked)
                viewModel.OrdersInfo.RemoveAt(swipedRowindex - 1);
            else
            {
                var removedData = viewModel.OrdersInfo[swipedRowindex - 1];
                var isSelected = dataGrid.SelectedItems.Contains(removedData);
                viewModel.OrdersInfo.Remove(removedData);
                viewModel.OrdersInfo.Insert(swipedRowindex - 1, removedData);
                if (isSelected)
                    dataGrid.SelectedItems.Add(removedData);
                IsUndoClicked = false;
            }
            isSuspend = false;
        }

        private void label_BindingContextChanged(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label.GestureRecognizers.Count == 0)
            {
                label.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Undo) });
            }
        }

        private void rightTemplate_BindingContextChanged(object sender, EventArgs e)
        {
            rightTemplateView = sender as ContentView;
        }

        private void leftTemplate_BindingContextChanged(object sender, EventArgs e)
        {
            leftTemplateView = sender as ContentView;
        }

        private void Undo()
        {
            IsUndoClicked = true;
        }

        #endregion

    }
}
