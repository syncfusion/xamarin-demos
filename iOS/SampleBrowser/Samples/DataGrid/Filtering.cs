#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Syncfusion.SfDataGrid;
using System.Globalization;
using CoreGraphics;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class Filtering : SampleView
    {

        #region Fields

        SfDataGrid SfGrid;
        UISearchBar searchbar;
        OptionsView option;
        private FilterViewModel viewmodel;

        #endregion

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public Filtering()
        {
            viewmodel = new FilterViewModel();

            this.SfGrid = new SfDataGrid();
            this.SfGrid.SelectionMode = SelectionMode.Single;
            this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            this.SfGrid.ItemsSource = viewmodel.BookInfo;
            this.SfGrid.HeaderRowHeight = 45;
            this.SfGrid.RowHeight = 45;
            if (Utility.IsIPad)
                this.SfGrid.ColumnSizer = ColumnSizer.Star;
            this.SfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB(219, 219, 219);
            searchbar = new UISearchBar();
            searchbar.OnEditingStarted += HandleOnEditingStarted;
            searchbar.TextChanged += HandleTextChanged;
            searchbar.CancelButtonClicked += HandleCancelButtonClicked;
            if (UIDevice.CurrentDevice.CheckSystemVersion(7, 1))
                searchbar.EnablesReturnKeyAutomatically = false;
            searchbar.Placeholder = "Search in All Columns";
            viewmodel.filtertextchanged = OnFilterChanged;
            option = new OptionsView(viewmodel, searchbar, this);
            this.OptionView = option;
            this.AddSubview(searchbar);
            this.AddSubview(SfGrid);
        }

        internal void PopUpDissmissed()
        {
            this.OptionView.RemoveFromSuperview();
        }

        void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "First Name";
                e.Column.TextMargin = 15;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "LastName")
            {
                e.Column.HeaderText = "Last Name";
                e.Column.TextMargin = 15;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "BookID")
            {
                e.Column.HeaderText = "Book ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "BookName")
            {
                e.Column.HeaderText = "Book Name";
                e.Column.TextMargin = 15;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "Price")
            {
                e.Column.TextAlignment = UITextAlignment.Center;
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
            }
            else if (e.Column.MappingName == "Country")
            {
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
            }
        }

        internal void OnFilterChanged()
        {
            if (this.SfGrid.View != null)
            {
                SfGrid.View.Filter = viewmodel.FilerRecords;
                SfGrid.View.RefreshFilter();
            }
        }

        void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            searchbar.ResignFirstResponder();
            searchbar.SetShowsCancelButton(false, true);
            searchbar.ResignFirstResponder();
        }

        void HandleTextChanged(object sender, UISearchBarTextChangedEventArgs e)
        {
            viewmodel.FilterText = e.SearchText;
        }

        void HandleOnEditingStarted(object sender, EventArgs e)
        {
            searchbar.SetShowsCancelButton(true, true);
        }

        public override void LayoutSubviews()
        {
            searchbar.Frame = (new CGRect(0, 0, this.Frame.Width, 40));
            if (UIDevice.CurrentDevice.CheckSystemVersion(7, 1))
            {
                searchbar.SizeToFit();
                this.SfGrid.Frame = new CGRect(0, searchbar.Bounds.Height, this.Frame.Width, this.Frame.Height - 40);

            }
            else
            {
                searchbar.SizeToFit();
                this.SfGrid.Frame = new CGRect(0, searchbar.Bounds.Height, this.Frame.Width, this.Frame.Height - 40);
            }
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(searchbar !=null)
                {
            searchbar.OnEditingStarted -= HandleOnEditingStarted;
            searchbar.TextChanged -= HandleTextChanged;
            searchbar.CancelButtonClicked -= HandleCancelButtonClicked;
                }
                if(SfGrid !=null)
                {
            SfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
            SfGrid.Dispose();
                }
            searchbar = null;
            option = null;
            viewmodel = null;
            SfGrid = null;
            }
          base.Dispose(disposing);
        }
        public override void OnOptionsViewClosed()
        {
            base.OnOptionsViewClosed();
            option.CommitValues();
        }
    }

	public partial class OptionsView : UIView
	{
		private FilterViewModel filtermodel;
		private UITableView table;
		private UISearchBar bar;
		private UITableView filterconditiontable;
		List<string> items;
		Filtering ParentView;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public OptionsView ()
		{
			items = new List<string> ();
			table = new UITableView ();
			filterconditiontable = new UITableView ();
			table.SectionIndexTrackingBackgroundColor = UIColor.FromRGB (0, 121, 255);
			filterconditiontable.AllowsSelection = true;
			this.AddSubview (filterconditiontable);
			this.AddSubview (table);
		}


		public OptionsView (FilterViewModel model, UISearchBar bar , Filtering parentView) : this ()
		{
			this.ParentView = parentView;
			this.filtermodel = model;
			var columnnames = filtermodel.BookInfo.GetType ().GetGenericArguments () [0].GetProperties ();
			this.bar = bar;
			foreach (var propety in columnnames) {
				items.Add (propety.Name);
			}
			table.Source = new OptionsTableSource (items);
			filterconditiontable.Source = new FilterOptionsTableSource (new List<string> () {
				"Contains",
				"Equals",
				"Not Equals"
			});
			this.AddSubview (filterconditiontable);
			this.AddSubview (table);

		}
        public override void RemoveFromSuperview()
        {
            base.RemoveFromSuperview();
            CommitValues();
        }

        internal void CommitValues()
        {
            filtermodel.SelectedColumn = (table.Source as OptionsTableSource).selectedItem;
            filtermodel.SelectedCondition = (filterconditiontable.Source as FilterOptionsTableSource).selecteditem;
            if (filtermodel.SelectedColumn != null && filtermodel.SelectedCondition != null)
            {
                this.bar.Placeholder = "Search " + filtermodel.SelectedColumn + " with " + filtermodel.SelectedCondition;
                if (this.bar.Text != "")
                    this.ParentView.OnFilterChanged();
            }
            else if ((filtermodel.SelectedColumn != null && filtermodel.SelectedCondition == null) ||
              (filtermodel.SelectedColumn == null && filtermodel.SelectedCondition != null))
            {
#pragma warning disable CS0618 // Type or member is obsolete
                var alert = new UIAlertView("Error", "Should Select Both ColumnName and Condition Type", null, "Cancel", null);
#pragma warning restore CS0618 // Type or member is obsolete
                alert.Frame = new CGRect(50, this.Frame.GetMidX(), 60, this.Frame.GetMidY());
                alert.Show();
            }
        }


		public override void LayoutSubviews ()
		{
			table.Frame = (new CGRect (0, 0, this.Frame.Width, (this.Frame.Height / 2)+13));
			filterconditiontable.Frame=(new CGRect (0, table.Bounds.Bottom + 2, this.Frame.Width, this.Frame.Height));
			base.LayoutSubviews ();
		}
	}
}

