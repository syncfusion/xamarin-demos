#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Graphics;
using Android.Util;
using Android.Widget;
using Syncfusion.SfDataGrid;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace SampleBrowser
{
    public class SwipeDelete : SamplePage
    {

        SfDataGrid sfGrid;
        SwipingViewModel viewModel;
        SwipeView swipe;
        LinearLayout linear;

        public bool IsUndoClicked { get; set; }
        private int swipedRowindex;
        private bool isSuspend;         

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            FrameLayout frame = new FrameLayout(context);            
            linear = new LinearLayout(context);
            linear.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            linear.Orientation = Orientation.Horizontal;            

            TextView swipeViewUndo = new TextView(context);
            swipeViewUndo.Text = "UNDO";
            swipeViewUndo.SetTypeface(swipeViewUndo.Typeface, TypefaceStyle.Bold);
            swipeViewUndo.Gravity = GravityFlags.Center;
            swipeViewUndo.SetTextColor(Color.White);
            swipeViewUndo.SetBackgroundColor(Color.ParseColor("#1AAA87"));
            swipeViewUndo.Click += swipeViewUndo_Click;

            TextView swipeViewText = new TextView(context);
            swipeViewText.SetPadding((int)(25 * context.Resources.DisplayMetrics.Density), 0, 0, 0);
            swipeViewText.Text = "Deleted";
            swipeViewText.Gravity = GravityFlags.CenterVertical | GravityFlags.Left; 
            swipeViewText.SetTextColor(Color.White);
            swipeViewText.SetBackgroundColor(Color.ParseColor("#1AAA87"));
            linear.SetBackgroundColor(Color.ParseColor("#1AAA87"));

            viewModel = new SwipingViewModel();            
            viewModel.SetRowstoGenerate(100);

            sfGrid = new SfDataGrid(context);
            sfGrid.AutoGenerateColumns = false;
            sfGrid.ItemsSource = (viewModel.OrdersInfo);
            sfGrid.AllowSwiping = true;            
            sfGrid.ColumnSizer = ColumnSizer.Star;            

            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            int width = metrics.WidthPixels;            
            
            sfGrid.MaxSwipeOffset = width;           
            swipe = new SwipeView(context);
            var undoWidth = (int)(100 * context.Resources.DisplayMetrics.Density);
            linear.AddView(swipeViewText, (sfGrid.MaxSwipeOffset - undoWidth), (int)sfGrid.RowHeight);
            linear.AddView(swipeViewUndo, undoWidth, (int)sfGrid.RowHeight);
            swipe.SetBackgroundColor(Color.ParseColor("#1AAA87"));
            swipe.AddView(linear);
            sfGrid.LeftSwipeView = swipe;
            sfGrid.RightSwipeView = swipe;
            sfGrid.SwipeEnded += sfGrid_SwipeEnded;
            sfGrid.SwipeStarted += sfGrid_SwipeStarted;

            GridTextColumn CustomerID = new GridTextColumn();
            CustomerID.MappingName = "CustomerID";
            CustomerID.HeaderText = "Customer ID";
            GridTextColumn OrderID = new GridTextColumn();
            OrderID.MappingName = "OrderID";
            OrderID.HeaderText = "Order ID";
            GridTextColumn EmployeeID = new GridTextColumn();
            EmployeeID.MappingName = "EmployeeID";
            EmployeeID.HeaderText = "Employee ID";
            GridTextColumn Name = new GridTextColumn();
            Name.MappingName = "FirstName";
            Name.HeaderText = "Name";

            sfGrid.Columns.Add(OrderID);
            sfGrid.Columns.Add(CustomerID);
            sfGrid.Columns.Add(EmployeeID);
            sfGrid.Columns.Add(Name);            
            frame.AddView(sfGrid);
            return frame;

        }

        void swipeViewUndo_Click(object sender, EventArgs e)
        {
            var removedData = viewModel.OrdersInfo[swipedRowindex - 1];
            var isSelected = sfGrid.SelectedItems.Contains(removedData);
            viewModel.OrdersInfo.Remove(removedData);
            viewModel.OrdersInfo.Insert(swipedRowindex - 1, removedData);
            if (isSelected)
                sfGrid.SelectedItems.Add(removedData);
            IsUndoClicked = true;
        }

        void sfGrid_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {           
                if (isSuspend)
                    e.Cancel = true;
        }        

        private async void sfGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            isSuspend = true;
            swipedRowindex = e.RowIndex;
            if (Math.Abs(e.SwipeOffset) >= sfGrid.MaxSwipeOffset / 2)
            {
                await Task.Delay(2000);
                if (!IsUndoClicked)
                    viewModel.OrdersInfo.RemoveAt(swipedRowindex - 1);                    
                else
                {
                    var removedData = viewModel.OrdersInfo[swipedRowindex - 1];
                    var isSelected = sfGrid.SelectedItems.Contains(removedData);
                    viewModel.OrdersInfo.Remove(removedData);
                    viewModel.OrdersInfo.Insert(swipedRowindex - 1, removedData);
                    if (isSelected)
                        sfGrid.SelectedItems.Add(removedData);
                    IsUndoClicked = false;
                }
                isSuspend = false;
            }
            else
                isSuspend = false;
        }
    }
}