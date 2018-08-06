#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DataSource;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Foundation;

namespace SampleBrowser
{
    public class TableViewSource : UITableViewSource
    {

        #region Field

        DataSource dataSource;

        #endregion

        #region Constructor

        public TableViewSource(DataSource sfDataSource )
        {
            dataSource = sfDataSource;
        }

        #endregion

        #region implemented abstract members of UITableViewDataSource

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var item = dataSource.DisplayItems[indexPath.Row];
            if (item is BookDetails)
            {
                CustomTableCell cell = tableView.DequeueReusableCell("TableCell") as CustomTableCell;
                if (cell == null)
                    cell = new CustomTableCell();
                cell.UpdateCell(item);
                return cell;
            }
            else if (item is Contacts)
            {
                ContactCell cell = tableView.DequeueReusableCell("TableCell") as ContactCell;
                if (cell == null)
                    cell = new ContactCell();
                cell.UpdateValue(item);
                return cell;
            }
            else if (item is GroupResult)
            {
                var groupCell = new UITableViewCell();
                var group = item as GroupResult;
                groupCell.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);
                groupCell.TextLabel.Text = group.Key.ToString();
                groupCell.BackgroundColor = UIColor.FromRGB(217, 217, 217);
                return groupCell;
            }        
            return new UITableViewCell();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return (nint)dataSource.DisplayItems.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (dataSource.DisplayItems[indexPath.Row] is GroupResult)
                return 30;
            else
                return tableView.RowHeight;
        }

        #endregion
    }

    public class ColumnOptionsTableSource : UITableViewSource
    {
        public List<string> tableItems;
        string cellIdentifier = "TableCell";
        string[] keys = new string[] { };
        public string selectedItem = null;

        public ColumnOptionsTableSource(List<string> items)
        {
            tableItems = items;
            keys = new string[] { "ColumnName" };
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            cell.TextLabel.Text = tableItems[indexPath.Row];
            cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
            return cell;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            selectedItem = tableItems[indexPath.Row];
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return keys[section];
        }
    }

    public class DataSourceFilterOptionsTableSource : UITableViewSource
    {
        public List<string> tableItems;
        string cellIdentifier = "TableCell";
        string[] keys = new string[] { };
        public string selecteditem = null;

        public DataSourceFilterOptionsTableSource(List<string> items)
        {
            tableItems = items;
            keys = new string[] { "Filter Condition Type" };
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
            cell.TextLabel.Text = tableItems[indexPath.Row];
            cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
            return cell;
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, Foundation.NSIndexPath indexPath)
        {
            if (cell.Selected)
            {
                cell.BackgroundColor = UIColor.Red;
            }
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            selecteditem = tableItems[indexPath.Row];
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return keys[section];
        }
    }


}
