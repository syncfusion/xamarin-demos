#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif

namespace SampleBrowser
{
    public class NavigationTableSource : UITableViewSource
    {
        #region fields

        private string[] tableItems;

		private string cellIdentifier = "TableCell";

		private HomeViewController controller;

        #endregion

        #region ctor

        public NavigationTableSource(HomeViewController controller, string[] items)
		{
			this.controller = controller;
			tableItems = items;
		}

        #endregion

        #region properties

        public bool Customize { get; set; }

        #endregion

        #region methods

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            controller.DrawerEvent((int)indexPath.Item);
		}

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 50;
		}

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

			string item = tableItems[indexPath.Row];

			if (cell == null)
			{
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			}

			cell.TextLabel.Font = UIFont.FromName("Helvetica-Light", 18f);
			cell.TextLabel.TextColor = UIColor.FromRGB(113.0f / 255.0f, 124.0f / 255.0f, 130.0f / 255.0f);
			cell.TextLabel.Text = item;

			if (indexPath.Row == 0)
			{
				cell.ImageView.Image = UIImage.FromBundle("Controls/productpage");
			}
			else if (indexPath.Row == 1)
			{
				cell.ImageView.Image = UIImage.FromBundle("Controls/whatsnew");
			}
			else if (indexPath.Row == 2)
			{
				cell.ImageView.Image = UIImage.FromBundle("Controls/documentation");
			}

			cell.BackgroundColor = UIColor.Clear;

			return cell;
		}

        #endregion
    }
}
