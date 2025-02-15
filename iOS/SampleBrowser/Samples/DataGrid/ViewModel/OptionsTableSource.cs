﻿using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    public class OptionsTableSource : UITableViewSource
    {
        public List<string> tableItems;
        string cellIdentifier = "TableCell";
        string[] keys = new string[] { };
        public string selectedItem = null;

        public OptionsTableSource(List<string> items)
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
}
