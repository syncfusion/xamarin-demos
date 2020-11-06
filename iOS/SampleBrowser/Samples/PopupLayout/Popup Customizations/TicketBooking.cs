#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfDataGrid;
using Syncfusion.SfPopupLayout;

namespace SampleBrowser
{
	public class TicketBooking : SampleView
	{
		#region Fields

		internal static SfDataGrid datagrid;
		TicketBookingViewModel viewModel;
		internal static SfPopupLayout popupLayout;

		#endregion

		#region Constructor
		public TicketBooking()
		{
			CreateDataGrid();
			CreatePopup();
			this.AddSubview(popupLayout);

		}
		#endregion

		private void CreateDataGrid()
		{
			datagrid = new SfDataGrid();
			viewModel = new TicketBookingViewModel();
			datagrid.AutoGenerateColumns = false;
			datagrid.ColumnSizer = ColumnSizer.Star;
			datagrid.RowHeight = 117;

			GridTextColumn movieList = new GridTextColumn();
			movieList.HeaderText = "Movies List";
			movieList.HeaderTextAlignment = UIKit.UITextAlignment.Center;
			movieList.UserCellType = typeof(MovieTile);

			datagrid.Columns.Add(movieList);
			datagrid.ItemsSource = viewModel.TheaterInformation;
		}

		private void CreatePopup()
		{
			popupLayout = new SfPopupLayout();
			popupLayout.Content = datagrid;
		}

		public override void LayoutSubviews()
		{
			popupLayout.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews();
		}
	}
}
