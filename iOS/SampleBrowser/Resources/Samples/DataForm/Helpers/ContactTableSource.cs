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

using Foundation;
using UIKit;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    /// <summary>
    /// Table source for TableView.
    /// </summary>
    public class ContactTableSource : UITableViewSource
    {
        internal ObservableCollection<ContactInfo> TableItems;
        string CellIdentifier = "TableCell";

        DataFormController dataFormController;

        public ContactTableSource(DataFormController controller, ObservableCollection<ContactInfo> items)
        {
            TableItems = items;
            dataFormController = controller;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            ContactInfo item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }
          
            cell.TextLabel.Text = item.ContactName;          
            cell.ImageView.Image = item.ContactImage;            
            
            return cell;
        }
        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true; // return false if you don't allow re-ordering
        }
        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true; // return false if you wish to disable editing for a specific indexPath or for all rows
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Show DataForm while selecting a table view cell.
            dataFormController.refreshLayout = false;
            dataFormController.UpDateDataFormView(TableItems[indexPath.Row] as ContactInfo);
            dataFormController.UpdateView();
            var navigationController = UIApplication.SharedApplication.KeyWindow.RootViewController as UINavigationController;
            navigationController.PushViewController(dataFormController, false);
        }
    }
}