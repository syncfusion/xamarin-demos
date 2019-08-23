#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Graphics;
using Android.Views;
using System.Globalization;

namespace SampleBrowser
{
	public class DataVirtualization:SamplePage
	{
		SfDataGrid sfGrid;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			sfGrid.AutoGeneratingColumn += GridAutoGenerateColumn;
			sfGrid.ItemsSource = new DataVirtualizationViewModel ().ViewSource;
			sfGrid.GridStyle.AlternatingRowColor = Color.Rgb (206, 206, 206);
			return sfGrid;

		}

		void GridAutoGenerateColumn (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
			} else if (e.Column.MappingName == "Name") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ContactID") {
				e.Column.HeaderText = "Contact ID";
			} else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Title") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "SickLeaveHours") {
				e.Column.HeaderText = "Sick Leave Hours";
			} else if (e.Column.MappingName == "Salary") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "BirthDate") {
				e.Column.HeaderText = "Birth Date";
				e.Column.TextAlignment = GravityFlags.Center;
				e.Column.Format = "d";
			}
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= GridAutoGenerateColumn;
			sfGrid.Dispose ();
			sfGrid = null;
		}
	}
}

