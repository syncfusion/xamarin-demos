#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDataGrid;
using Android.Graphics;
using System.Threading.Tasks;
using Android.Util;
using Android.Views.InputMethods;
using Android.Content.Res;

namespace SampleBrowser
{
    public class Swiping : SamplePage
    {

        SfDataGrid sfGrid;
        FrameLayout parentLayout;
        SwipingViewModel viewModel;
        int swipedRowIndex;

        TextView optionHeading;
        TextView col1;
        TextView col2;
        TextView col3;
        TextView col4;
        EditText orderIDText;
        EditText customerIDText;
        EditText employeeIDText;
        EditText nameText;
        Button save;
        Button cancel;


        LinearLayout editor;
        LinearLayout body;
        LinearLayout bodyRow1;
        LinearLayout bodyRow2;
        LinearLayout bodyRow3;
        LinearLayout bodyRow4;
        LinearLayout optionView;
        LinearLayout bottom;
        SwipeView leftSwipeView;
        SwipeView rightSwipeView;
        LinearLayout editView;
        LinearLayout deleteView;

        private int swipedRowindex;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            parentLayout = new FrameLayout(context);

            optionHeading = new TextView(context);
            optionHeading.Gravity = GravityFlags.CenterHorizontal;
            body = new LinearLayout(context);
            optionView = new LinearLayout(context);
            optionView.SetBackgroundColor(Color.Gray);
            editor = new LinearLayout(context);
            bottom = new LinearLayout(context);

            bodyRow1 = new LinearLayout(context);
            bodyRow1.Orientation = Android.Widget.Orientation.Horizontal;
            bodyRow1.SetGravity(GravityFlags.CenterHorizontal);
            bodyRow2 = new LinearLayout(context);
            bodyRow2.Orientation = Android.Widget.Orientation.Horizontal;
            bodyRow2.SetGravity(GravityFlags.CenterHorizontal);
            bodyRow3 = new LinearLayout(context);
            bodyRow3.Orientation = Android.Widget.Orientation.Horizontal;
            bodyRow3.SetGravity(GravityFlags.CenterHorizontal);
            bodyRow4 = new LinearLayout(context);
            bodyRow4.Orientation = Android.Widget.Orientation.Horizontal;
            bodyRow4.SetGravity(GravityFlags.CenterHorizontal);


            col1 = new TextView(context);
            col1.Text = "Order ID";
            col2 = new TextView(context);
            col2.Text = "Customer ID";
            col3 = new TextView(context);
            col3.Text = "Employee ID";
            col4 = new TextView(context);
            col4.Text = "Name";

            orderIDText = new EditText(context);
            orderIDText.Gravity = GravityFlags.Start;
            customerIDText = new EditText(context);
            employeeIDText = new EditText(context);
            nameText = new EditText(context);

            save = new Button(context);
            save.Click += save_Click;
            cancel = new Button(context);
            cancel.Click += cancel_Click;

            editView = new LinearLayout(context);
            editView.TextAlignment = TextAlignment.Center;
            editView.Orientation = Android.Widget.Orientation.Horizontal;
            editView.Click += editView_Click;

            deleteView = new LinearLayout(context);
            deleteView.TextAlignment = TextAlignment.Center;
            deleteView.Orientation = Android.Widget.Orientation.Horizontal;
            deleteView.Click += swipeViewImage_Click;

            ImageView editImage = new ImageView(context);
            editImage.SetImageResource(Resource.Drawable.Edit);
            editImage.SetBackgroundColor(Color.ParseColor("#42A5F5"));
            editImage.SetPadding((int)(10 * Resources.System.DisplayMetrics.Density), 0, 0, 0);
            
            TextView edit = new TextView(context);
            edit.Text = "EDIT";
            edit.TextAlignment = TextAlignment.Center;
            edit.Gravity = GravityFlags.Center;
            edit.SetTextColor(Color.White);
            //edit.SetPadding((int)(16 * Resources.System.DisplayMetrics.Density), 0, (int)(16 * Resources.System.DisplayMetrics.Density), 0);
            edit.SetBackgroundColor(Color.ParseColor("#42A5F5"));

            ImageView deleteImage = new ImageView(context);
            deleteImage.SetImageResource(Resource.Drawable.Delete);
            deleteImage.SetBackgroundColor(Color.ParseColor("#EF5350"));
            deleteImage.SetPadding((int)(5 * Resources.System.DisplayMetrics.Density), 0, 0, 0);

            TextView delete = new TextView(context);
            delete.Text = "DELETE";
            delete.TextAlignment = TextAlignment.Center;
            delete.Gravity = GravityFlags.Center;
            //delete.SetPadding((int)(14 * Resources.System.DisplayMetrics.Density), 0, (int)(10 * Resources.System.DisplayMetrics.Density), (int)(14 * Resources.System.DisplayMetrics.Density));
            delete.SetTextColor(Color.White);
            delete.SetBackgroundColor(Color.ParseColor("#EF5350"));

            viewModel = new SwipingViewModel();
            viewModel.SetRowstoGenerate(100);

            sfGrid = new SfDataGrid(context);
            sfGrid.AutoGenerateColumns = false;
            sfGrid.ItemsSource = (viewModel.OrdersInfo);
            sfGrid.AllowSwiping = true;
            sfGrid.RowHeight = 70;
            sfGrid.ColumnSizer = ColumnSizer.Star;

            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            int width = metrics.WidthPixels;

            sfGrid.MaxSwipeOffset = (int)(100 * metrics.Density);
            leftSwipeView = new SwipeView(context);
            rightSwipeView = new SwipeView(context);

            editView.AddView(editImage, (int)(30 * Resources.System.DisplayMetrics.Density), (int)sfGrid.RowHeight);
            editView.AddView(edit, sfGrid.MaxSwipeOffset - 30, (int)sfGrid.RowHeight);

            deleteView.AddView(deleteImage, (int)(30 * Resources.System.DisplayMetrics.Density), (int)sfGrid.RowHeight);
            deleteView.AddView(delete, sfGrid.MaxSwipeOffset - 30, (int)sfGrid.RowHeight);

            leftSwipeView.AddView(editView, sfGrid.MaxSwipeOffset, (int)sfGrid.RowHeight);
            rightSwipeView.AddView(deleteView, sfGrid.MaxSwipeOffset, (int)sfGrid.RowHeight);

            sfGrid.LeftSwipeView = leftSwipeView;
            sfGrid.RightSwipeView = rightSwipeView;
            sfGrid.SwipeEnded += sfGrid_SwipeEnded;
            sfGrid.SwipeStarted += sfGrid_SwipeStarted;

            GridTextColumn CustomerID = new GridTextColumn();
            CustomerID.MappingName = "CustomerID";
            CustomerID.HeaderText = "Customer ID";
            GridTextColumn OrderID = new GridTextColumn();
            OrderID.MappingName = "OrderID";
            OrderID.HeaderText = "Order ID";
            OrderID.TextMargin = new Thickness(16, 0, 0, 0);
            OrderID.HeaderTextMargin= new Thickness(16, 0, 0, 0);

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
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            parentLayout.AddView(sfGrid);

            editor.SetBackgroundColor(Color.White);
            editor.Orientation = Android.Widget.Orientation.Vertical;
            optionHeading.Text = "EDIT DETAILS";
            optionHeading.SetTypeface(null, TypefaceStyle.Bold);
            optionHeading.Gravity = GravityFlags.Center;

            bodyRow1.AddView(col1, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), (int)(50 * sfGrid.Resources.DisplayMetrics.Density));
            bodyRow1.AddView(orderIDText, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), ViewGroup.LayoutParams.WrapContent);
            bodyRow2.AddView(col2, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), (int)(50 * sfGrid.Resources.DisplayMetrics.Density));
            bodyRow2.AddView(customerIDText, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), ViewGroup.LayoutParams.WrapContent);
            bodyRow3.AddView(col3, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), (int)(50 * sfGrid.Resources.DisplayMetrics.Density));
            bodyRow3.AddView(employeeIDText, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), ViewGroup.LayoutParams.WrapContent);
            bodyRow4.AddView(col4, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), (int)(50 * sfGrid.Resources.DisplayMetrics.Density));
            bodyRow4.AddView(nameText, (int)(100 * sfGrid.Resources.DisplayMetrics.Density), ViewGroup.LayoutParams.WrapContent);

            body.Orientation = Android.Widget.Orientation.Vertical;
            body.SetGravity(GravityFlags.CenterHorizontal);
            body.AddView(bodyRow1);
            body.AddView(bodyRow2);
            body.AddView(bodyRow3);
            body.AddView(bodyRow4);

            save.Text = "Save";
            cancel.Text = "Cancel";
            bottom.Orientation = Android.Widget.Orientation.Horizontal;
            bottom.AddView(save);
            bottom.AddView(cancel);
            bottom.SetGravity(GravityFlags.Center);

            editor.AddView(optionHeading);
            editor.AddView(body);
            editor.AddView(bottom);
            optionView.AddView(editor, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            if (parentLayout.ChildCount == 1)
                parentLayout.AddView(optionView, 1);
            parentLayout.GetChildAt(0).Visibility = ViewStates.Visible;
            parentLayout.GetChildAt(1).Visibility = ViewStates.Invisible;
            return parentLayout;
        }

        void cancel_Click(object sender, EventArgs e)
        {
            parentLayout.GetChildAt(1).Visibility = ViewStates.Invisible;
            parentLayout.GetChildAt(0).Visibility = ViewStates.Visible;
            // issue fix for XAMARINANDROID-1603 Keyboard will not get collapsed after editing a row in swiping.
            HideKeyBoard();
        }

        void save_Click(object sender, EventArgs e)
        {
            parentLayout.GetChildAt(1).Visibility = ViewStates.Invisible;
            parentLayout.GetChildAt(0).Visibility = ViewStates.Visible;
            commitValues();
            // issue fix for XAMARINANDROID-1603 Keyboard will not get collapsed after editing a row in swiping.
            HideKeyBoard();
        }

        void editView_Click(object sender, EventArgs e)
        {
            parentLayout.GetChildAt(1).Visibility = ViewStates.Visible;
            parentLayout.GetChildAt(0).Visibility = ViewStates.Invisible;
            initializeTextFields();
        }

        private void commitValues()
        {
            if (swipedRowindex > 0)
            {
                var swipedRowData = this.viewModel.OrdersInfo[this.swipedRowindex - 1];
                swipedRowData.OrderID = this.orderIDText.Text;
                swipedRowData.CustomerID = this.customerIDText.Text;
                swipedRowData.EmployeeID = this.employeeIDText.Text;
                swipedRowData.FirstName = this.nameText.Text;
            }
        }

        /// <summary>
        /// HidesKeyboard
        /// </summary>
        private void HideKeyBoard()
        {
            var inputView = parentLayout.GetChildAt(1);
            using (InputMethodManager inputMethodManager = (InputMethodManager)inputView.Context.GetSystemService(Context.InputMethodService))
            {
                inputMethodManager.HideSoftInputFromWindow(inputView.WindowToken, HideSoftInputFlags.None);
            }
        }
        private void initializeTextFields()
        {
            if (swipedRowindex > 0)
            {
                var swipedRowData = this.viewModel.OrdersInfo[this.swipedRowindex - 1];
                orderIDText.Text = swipedRowData.OrderID;
                this.customerIDText.Text = swipedRowData.CustomerID;
                this.employeeIDText.Text = swipedRowData.EmployeeID;
                this.nameText.Text = swipedRowData.FirstName;
            }
        }

        void sfGrid_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            swipedRowIndex = e.RowIndex;
            orderIDText.Text = (e.RowData as OrderInfo).OrderID;
            customerIDText.Text = (e.RowData as OrderInfo).CustomerID;
            employeeIDText.Text = (e.RowData as OrderInfo).EmployeeID;
            nameText.Text = (e.RowData as OrderInfo).FirstName;
        }

        private void sfGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            swipedRowindex = e.RowIndex;
        }

        void swipeViewImage_Click(object sender, EventArgs e)
        {
            viewModel.OrdersInfo.RemoveAt(swipedRowindex - 1);
        }

        public override void Destroy()
        {
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }
    }
}