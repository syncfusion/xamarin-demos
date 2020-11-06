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
using CoreGraphics;

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
	public class TableSource : UITableViewSource {
		public bool customise;
		string[] TableItems;
		string[] ContentItems;
		string item2="test";
		UILabel ll,ll1;
		string CellIdentifier = "TableCell";
		public TableSource (string[] items)
		{
			TableItems = items;
		}
		public TableSource (string[] items,string[] contentitems)
		{
			TableItems = items;
			ContentItems = contentitems;
		}	public override nint RowsInSection (UITableView tableview, nint section)
		{
			int i=TableItems.Length;
			return (nint)i;
		}
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (!customise) {
				NavigationDrawer.mainView.setvalue1 ((int)indexPath.Item);
				NavigationDrawer.sideMenuController.ToggleDrawer ();
			}
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {				
				if (customise)
					return 55;
				else
					return 40;
			} else
				return 40;
		}
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);

			string item = TableItems[indexPath.Row];

			if(ContentItems!=null)
			 item2 = ContentItems[indexPath.Row];
			if (cell == null)
			{ cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier); }
			if (customise) {
				UIView centerview = new UIView ();
				centerview.Frame = cell.Frame;
				centerview.BackgroundColor = UIColor.White;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {	
					ll = new UILabel (new CGRect (100, 2, 100, 20));
					ll1 = new UILabel (new CGRect (100, 20, 300, 30));
				} else {
					 ll = new UILabel (new CGRect (15, 2, 100, 20));
					 ll1 = new UILabel (new CGRect (15, 20, 300, 20));
				}
				ll.Font= UIFont.FromName ("Helvetica", 15f);
				ll.Text = item;
				centerview.Add (ll);
				
				ll1.Text = item2;
				ll1.Lines = 0;
				ll1.Font= UIFont.FromName ("Helvetica", 13f);
				centerview.Add (ll1);
				cell.ContentView.Add (centerview);

			} else {
				cell.TextLabel.Text = item;
			}
			return cell;
		}
	}
}

