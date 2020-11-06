#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class TableSourceCollection : UITableViewSource
	{

		protected string[] tableItems;
		protected string cellIdentifier = "TableCell";
		//HomeScreen owner;

		public TableSourceCollection(string[] items)
		{
			tableItems = items;
			//this.owner = owner;

		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Length;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				return 16;
			else
				return 32;
		}
		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			string item = tableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier); }
			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				cell.TextLabel.Font = UIFont.FromName("Helvetica", 12f);
			else
				cell.TextLabel.Font = UIFont.FromName("Helvetica", 18f);
			cell.TextLabel.Text = item;

			return cell;
		}
	}
}

