#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Syncfusion.DataSource;

namespace SampleBrowser
{
    public partial class DataSourceOptionsView : UIView
    {
        private DataSourceGettingStartedViewModel filtermodel;
        private UITableView table;
        private UISearchBar bar;
        private UITableView filterconditiontable;
        List<string> items;
        DataSourceGettingStarted ParentView;

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public DataSourceOptionsView()
        {
            items = new List<string>();
            table = new UITableView();
            filterconditiontable = new UITableView();
            table.SectionIndexTrackingBackgroundColor = UIColor.FromRGB(0, 121, 255);
            filterconditiontable.AllowsSelection = true;
            this.AddSubview(filterconditiontable);
            this.AddSubview(table);
        }


        public DataSourceOptionsView(DataSourceGettingStartedViewModel model, UISearchBar bar, DataSourceGettingStarted parentView)
            : this()
        {
            this.ParentView = parentView;
            this.filtermodel = model;
            var columnnames = filtermodel.BookInfo.GetType().GetGenericArguments()[0].GetProperties();
            this.bar = bar;
            foreach (var propety in columnnames)
            {
                items.Add(propety.Name);
            }
            table.Source = new ColumnOptionsTableSource(items);
            filterconditiontable.Source = new DataSourceFilterOptionsTableSource(new List<string>() {
				"Contains",
				"Equals",
				"Not Equals"
			});
            this.AddSubview(filterconditiontable);
            this.AddSubview(table);

        }

        public override void RemoveFromSuperview()
        {
            base.RemoveFromSuperview();
            filtermodel.SelectedColumn = (table.Source as ColumnOptionsTableSource).selectedItem;
            filtermodel.SelectedCondition = (filterconditiontable.Source as DataSourceFilterOptionsTableSource).selecteditem;
            if (filtermodel.SelectedColumn != null && filtermodel.SelectedCondition != null)
            {
                this.bar.Placeholder = "Search " + filtermodel.SelectedColumn + " with " + filtermodel.SelectedCondition;
                if (this.bar.Text != "")
                    this.ParentView.OnFilterChanged();
            }
            else if ((filtermodel.SelectedColumn != null && filtermodel.SelectedCondition == null) ||
              (filtermodel.SelectedColumn == null && filtermodel.SelectedCondition != null))
            {
                var alert = new UIAlertView("Error", "Should Select Both ColumnName and Condition Type", null, "Cancel", null);
                alert.Frame = new CGRect(50, this.Frame.GetMidX(), 60, this.Frame.GetMidY());
                alert.Show();
            }
        }

        public override void LayoutSubviews()
        {
            table.Frame = (new CGRect(0, 0, this.Frame.Width, (this.Frame.Height / 2) + 13));
            filterconditiontable.Frame = (new CGRect(0, table.Bounds.Bottom + 2, this.Frame.Width, this.Frame.Height));
            base.LayoutSubviews();
        }
    }

	public class SortingPickerModel : UIPickerViewModel
	{
		string[] array = new string[]{"Ascending", "Descending"};
		DataSource dataSource;
		UITableView tableView;

		public SortingPickerModel(DataSource datasource, UITableView tableview)
		{
			dataSource = datasource;
			tableView = tableview;
		}

		public override nint GetComponentCount (UIPickerView pickerView)
		{
			return 1;
		}

		public override nint GetRowsInComponent (UIPickerView pickerView, nint component)
		{
			return 2;
		}

		public override string GetTitle (UIPickerView pickerView, nint row, nint component)
		{
			return array[row];
		}

		public override void Selected (UIPickerView pickerView, nint row, nint component)
		{
			dataSource.SortDescriptors.Clear ();
			if (row == 0)
				dataSource.SortDescriptors.Add (new SortDescriptor ("ContactName", Syncfusion.DataSource.ListSortDirection.Ascending));
			else
				dataSource.SortDescriptors.Add (new SortDescriptor ("ContactName", Syncfusion.DataSource.ListSortDirection.Descending));
			tableView.ReloadData ();
		}
		public override UIView GetView (UIPickerView pickerView, nint row, nint component, UIView view)
		{
			UILabel label = new UILabel ();
			label.Font = UIFont.SystemFontOfSize (14f);
			label.Text = array [row]; 
			label.TextAlignment = UITextAlignment.Center;
			return label;
		}
	}


	public enum StackOrientation
	{
		Vertical,
		Horizontal
	}

	public class StackLayout : UIView
	{
		public StackOrientation Orientation { get; set;}

		public StackLayout()
		{
		}

		public override void LayoutSubviews ()
		{
			nfloat x = 0; 
			nfloat y = 0;
			foreach (var child in this.Subviews) {
				if (this.Orientation == StackOrientation.Horizontal) {
					child.Frame = new CGRect (0, 0, child.Frame.Width, this.Frame.Height);
					x = child.Frame.Width + 5;
				}
				else if (this.Orientation == StackOrientation.Vertical) {
					child.Frame = new CGRect (0, 0, this.Frame.Width, child.Frame.Height);
					y = child.Frame.Width + 5;
				}
			}
		}
	}
}
