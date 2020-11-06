#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;
using System.Globalization;
using CoreGraphics;
using Syncfusion.SfPullToRefresh;
using System.Threading.Tasks;

namespace SampleBrowser
{
	public class SfDataGridInPullToRefresh : SampleView
	{
		#region Fields

		SfDataGrid SfGrid;
        SfPullToRefresh pullToRefresh;
        GridGettingStartedViewModel viewModel;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public SfDataGridInPullToRefresh()
		{
            this.pullToRefresh = new SfPullToRefresh();
            this.pullToRefresh.RefreshContentThreshold = 45;
			this.SfGrid = new SfDataGrid ();
            this.SfGrid.SelectionMode = SelectionMode.Single;
            this.SfGrid.AutoGenerateColumns = false;
            this.SfGrid.ColumnSizer = ColumnSizer.Star;
            this.GridGenerateColumns();
            viewModel = new GridGettingStartedViewModel();
			this.SfGrid.ItemsSource = viewModel.OrdersInfo;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB (219, 219, 219);
            this.SfGrid.AllowResizingColumn = true;
            this.SfGrid.GridStyle = new CustomGridStyle();
            this.pullToRefresh.PullableContent = SfGrid;
            this.pullToRefresh.Refreshing += PullToRefresh_Refreshing;
			this.AddSubview (this.pullToRefresh);
            this.OptionView = new Options(pullToRefresh);
        }

        private async void PullToRefresh_Refreshing(object sender, RefreshingEventArgs e)
        {
            await Task.Delay(3000);
            viewModel.ItemsSourceRefresh();
            e.Refreshed = true;
        }

        void GridGenerateColumns()
        {
            this.SfGrid.Columns.Add(new GridTextColumn() { MappingName = "OrderID", HeaderText = "Order ID" });
            this.SfGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID", TextMargin = 10, TextAlignment = UITextAlignment.Left });
            this.SfGrid.Columns.Add(new GridTextColumn() { MappingName = "Freight", Format = "C", CultureInfo = new CultureInfo("en-US"), TextAlignment = UITextAlignment.Center });
            this.SfGrid.Columns.Add(new GridTextColumn() { MappingName = "ShipCity", HeaderText = "Ship City", TextMargin = 10, TextAlignment = UITextAlignment.Left });
        }

		public override void LayoutSubviews ()
		{
            this.Superview.SendSubviewToBack(this);
            this.pullToRefresh.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if (SfGrid != null)
                    SfGrid.Dispose();
                if (pullToRefresh != null)
                {
                    pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
                    pullToRefresh.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }

}

