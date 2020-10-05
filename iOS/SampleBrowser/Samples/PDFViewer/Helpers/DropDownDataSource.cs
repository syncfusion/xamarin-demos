#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using UIKit;
using CoreGraphics;
using System.Linq;
using Foundation;
using System;

namespace SampleBrowser
{
    internal class DropDownDataSource : UITableViewSource
	{        
        private DropDownMenuItem[] m_ListItems;
		private const string m_CellIdentifier = "DropDownListCell";
		private UIColor m_TextColor;
		private UIColor m_CellColor;
        private UIColor m_BackgroundColor;
        public event DropDownMenuItemChangedHandler DropDownMenuItemChanged;
        public UIColor CellColor {
			get {
				return m_CellColor;
			}
			set {
				m_CellColor = value;
			}
		}
		public UIColor TextColor
        {
            get
            {
                return m_TextColor;
            }
            set
            {
                m_TextColor = value;
            }
        }
		public UIColor BackgroundColor
        {
            get
            {
                return m_BackgroundColor;
            }
            set
            {
                m_BackgroundColor = value;
            }
        }
		public DropDownDataSource(DropDownMenuItem[] listItems, UIColor textColor)
		{
			this.m_TextColor = textColor;
			this.m_ListItems = listItems;
		}
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var item = m_ListItems [indexPath.Row];
			var cell = tableView.DequeueReusableCell (m_CellIdentifier) as UITableViewCell;
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, m_CellIdentifier);
			}
			if (m_BackgroundColor != null)
				cell.BackgroundColor = m_BackgroundColor;
			if (this.m_TextColor != null)
				cell.TextLabel.TextColor = m_TextColor;
			cell.TextLabel.Text = item.DisplayText;
			if (this.m_CellColor != null)
				cell.TintColor = CellColor;
			return cell;
		}
		public override System.nint RowsInSection (UITableView tableview, System.nint section)
		{
			return this.m_ListItems.Length;
		}
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var oldItem = m_ListItems.FirstOrDefault (x => x.IsSelected);
			if (oldItem != null)
				oldItem.IsSelected = false;
			var oldCell = tableView.VisibleCells.FirstOrDefault (c => ((UITableViewCell)c).Accessory == UITableViewCellAccessory.Checkmark) as UITableViewCell;
			if (oldCell != null)
				oldCell.Accessory = UITableViewCellAccessory.None;
			m_ListItems [indexPath.Row].IsSelected = true;
			var cell = tableView.CellAt (indexPath) as UITableViewCell;
			cell.Accessory = UITableViewCellAccessory.None;
			if (DropDownMenuItemChanged != null && oldItem.DisplayText != cell.TextLabel.Text) {
				DropDownMenuItemChanged (indexPath.Row, m_ListItems [indexPath.Row]);
			}
		}
	}
}
