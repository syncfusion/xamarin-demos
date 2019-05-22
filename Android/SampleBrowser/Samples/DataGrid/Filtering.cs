#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Widget;
using Android.Graphics;
using Android.Views;
using System.Globalization;

namespace SampleBrowser
{
	public class Filtering:SamplePage
	{
		SfDataGrid sfGrid;
		FilteringViewModel viewModel;
		SearchView filterText;
		Spinner conditionDropdown;
		Spinner columnDropdown;
		ArrayAdapter condtionAdapter;
		GridLayout gridlayout;
		TextView conditionTextView;
		TextView columnTextView;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Orientation.Vertical;
			sfGrid = new SfDataGrid (context);
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            viewModel = new FilteringViewModel (context);
			viewModel.SetRowstoGenerate (100);
			sfGrid.GridStyle.AlternatingRowColor = Color.Rgb (206, 206, 206);
			this.sfGrid.AutoGeneratingColumn += GridAutoGenerateColumn;
			sfGrid.ItemsSource = (viewModel.BookInfo);
            filterText = new SearchView(context);
            filterText.SetQueryHint( "Enter the Text to filter");
            filterText.QueryTextChange += OnFilterTextChanged;
            viewModel.filtertextchanged = OnFilterChanged;
            linear.AddView(filterText);
            linear.AddView(sfGrid);
			return linear;
		}

		public override View GetPropertyWindowLayout (Android.Content.Context context)
		{
			gridlayout = new GridLayout (context); 
			gridlayout.RowCount = 2;
			gridlayout.ColumnCount = 2;

			conditionTextView = new TextView (context);
			conditionTextView.Text = "Select the Condition to filter";
			columnTextView = new TextView (context);
			columnTextView.Text = "Select the Column to filter";
			columnDropdown = new Spinner(context, SpinnerMode.Dialog);
			var columnAdapter = ArrayAdapter.CreateFromResource (context, Resource.Array.column_array, Android.Resource.Layout.SimpleSpinnerItem);
			columnAdapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			columnDropdown.Adapter = columnAdapter;
			conditionDropdown = new Spinner (context, SpinnerMode.Dialog);
			condtionAdapter = new ArrayAdapter (context, Android.Resource.Layout.SimpleSpinnerItem);
			condtionAdapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			conditionDropdown.Adapter = condtionAdapter;
			columnDropdown.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (OnColumnSelected);
			conditionDropdown.ItemSelected += OnConditionSelected;
			gridlayout.LayoutParameters = new LinearLayout.LayoutParams (LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
			gridlayout.AddView (columnTextView);
			gridlayout.AddView (columnDropdown);
			gridlayout.AddView (conditionTextView);
			gridlayout.AddView (conditionDropdown);
			return gridlayout;
		}
		private void OnColumnSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner newSpinner = (Spinner)sender;
			viewModel.SelectedColumn = newSpinner.GetItemAtPosition (e.Position).ToString ();

			if (viewModel.SelectedColumn == "All Columns") {
				conditionDropdown.Visibility = ViewStates.Gone;
				conditionTextView.Visibility = ViewStates.Gone;
			}
			else {
				conditionDropdown.Visibility = ViewStates.Visible;
				conditionTextView.Visibility = ViewStates.Visible;
				foreach (var prop in typeof(BookInfo).GetProperties()) {
					if (prop.Name == viewModel.SelectedColumn) {
						var type = prop.GetType ();
						if (prop.PropertyType == typeof(Java.Lang.String)) {
							condtionAdapter.Clear ();
							condtionAdapter.Add ("Equals");
							condtionAdapter.Add ("Contains");
							if (this.viewModel.SelectedCondition == "Equals")
								this.viewModel.SelectedCondition = "Equals";
							else
								this.viewModel.SelectedCondition = "Contains";
						} else {
							condtionAdapter.Clear ();
							condtionAdapter.Add ("Equals");
							condtionAdapter.Add ("NotEquals");
							if (this.viewModel.SelectedCondition == "Equals")
								this.viewModel.SelectedCondition = "Equals";
							else
								this.viewModel.SelectedCondition = "NotEquals";
						}
					}
				}
			}
			if (filterText.Query != "")
				this.OnFilterChanged ();
		}

		void OnFilterChanged ()
		{
			if (sfGrid.View != null) {
				this.sfGrid.View.Filter = viewModel.FilerRecords;
				this.sfGrid.View.RefreshFilter ();
			}
		}

        void OnFilterTextChanged(object sender, SearchView.QueryTextChangeEventArgs e)
		{
            viewModel.FilterText = (sender as SearchView).Query.ToString();
		}

		void GridAutoGenerateColumn (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "BookID") {
				e.Column.HeaderText = "Book ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "BookName") {
				e.Column.HeaderText = "Book Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Price") {
				e.Column.TextAlignment = GravityFlags.Center;
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "Country") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			}
		}

		private void OnConditionSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner newSpinner = (Spinner)sender;
			viewModel.SelectedCondition = newSpinner.GetItemAtPosition (e.Position).ToString ();
			if (filterText.Query != "")
				this.OnFilterChanged ();
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= GridAutoGenerateColumn;
			sfGrid.Dispose ();
			conditionDropdown = null;
			columnDropdown = null;
			filterText = null;
			columnTextView = null;
			conditionTextView = null;
			sfGrid = null;
			viewModel = null;
			condtionAdapter = null; 
			gridlayout.RemoveAllViews();
			gridlayout = null;
		}
			
	}
}

