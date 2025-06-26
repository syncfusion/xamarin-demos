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
using System.Globalization;
using Syncfusion.SfPullToRefresh;
using System.Threading.Tasks;
using Android.Widget;
using System.Collections.Generic;
using Android.Graphics;
using Android.Content;

namespace SampleBrowser
{
	public class SfDataGridInPullToRefresh:SamplePage
	{
        SfPullToRefresh pullToRefresh;
		SfDataGrid sfGrid;
		GettingStartedViewModel viewModel;
        
		public override View GetSampleContent (Android.Content.Context context)
		{
            pullToRefresh = new SfPullToRefresh(context);
            pullToRefresh.Refreshing += Pull_Refreshing;
            sfGrid = new SfDataGrid (context);
            sfGrid.HeaderRowHeight = 52;
            pullToRefresh.RefreshContentThreshold = 52;
            sfGrid.RowHeight = 48;
			viewModel = new GettingStartedViewModel ();
            sfGrid.SelectionMode = SelectionMode.Single;
			viewModel.SetRowstoGenerate (100);
            sfGrid.AutoGenerateColumns = false;
            GridGenerateColumns();
            sfGrid.ColumnSizer = ColumnSizer.Star;
			sfGrid.ItemsSource = (viewModel.OrdersInfo);
            sfGrid.AllowResizingColumn = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            pullToRefresh.PullableContent = sfGrid;
            return pullToRefresh;
		}


        void GridGenerateColumns()
        {
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "OrderID", HeaderText = "Order ID" });
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID", TextAlignment = GravityFlags.CenterVertical });
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "Freight", Format = "C", CultureInfo = new CultureInfo("en-US"), TextAlignment = GravityFlags.Center });
            sfGrid.Columns.Add(new GridTextColumn() { MappingName = "ShipCity", HeaderText = "Ship City", TextAlignment = GravityFlags.CenterVertical });
        }

        private async void Pull_Refreshing(object sender, RefreshingEventArgs e)
        {
            await Task.Delay(3000);
            if (viewModel != null)
                viewModel.ItemsSourceRefresh();
            e.Refreshed = true;
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            FrameLayout propertyLayout = new FrameLayout(context);
            LinearLayout container = new LinearLayout(context);
            container.Orientation = Orientation.Vertical;
            container.SetBackgroundColor(Color.White);
            container.SetPadding(15, 15, 15, 20);
            TextView transitiontype = new TextView(context);
            transitiontype.Text = "Tranisition Type";
            transitiontype.TextSize = 20;
            transitiontype.SetPadding(0, 0, 0, 10);
            transitiontype.SetTextColor(Color.Black);
            Spinner transitionTypeSpinner = new Spinner(context, SpinnerMode.Dialog);
            transitionTypeSpinner.SetMinimumHeight(60);
            transitionTypeSpinner.SetBackgroundColor(Color.Gray);
            transitionTypeSpinner.DropDownWidth = 600;
            transitionTypeSpinner.SetPadding(10, 10, 0, 10);
            transitionTypeSpinner.SetGravity(GravityFlags.CenterHorizontal);
            container.AddView(transitiontype);
            container.AddView(transitionTypeSpinner);
            List<String> list = new List<String>();
            list.Add("SlideOnTop");
            list.Add("Push");
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            transitionTypeSpinner.Adapter = dataAdapter;
            transitionTypeSpinner.ItemSelected += transitionTypeSpinner_ItemSelected;
             if (pullToRefresh.TransitionType == TransitionType.SlideOnTop)
                transitionTypeSpinner.SetSelection(0);
            else
                transitionTypeSpinner.SetSelection(1);
            propertyLayout.AddView(container);
            return propertyLayout;
        }

        void transitionTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            String selectedItem = spinner.GetItemAtPosition(e.Position).ToString();

            if (pullToRefresh != null)
            {
                if (selectedItem.Equals("SlideOnTop"))
                {
                    pullToRefresh.TransitionType = TransitionType.SlideOnTop;
                    pullToRefresh.PullingThreshold = 120;
                }
                else if (selectedItem.Equals("Push"))
                {
                    pullToRefresh.TransitionType = TransitionType.Push;
                    pullToRefresh.PullingThreshold = 140;
                }
            }
        }

        public override void Destroy()
        {
            pullToRefresh.Refreshing -= Pull_Refreshing;
            viewModel = null;
            pullToRefresh.Dispose();
            pullToRefresh = null;
        }

    }
}

