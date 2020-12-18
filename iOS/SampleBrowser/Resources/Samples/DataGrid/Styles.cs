#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfDataGrid;
using UIKit;
using System.Globalization;

namespace SampleBrowser
{
	public class Styles:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;
		UISegmentedControl segmentControl;
		GridGettingStartedViewModel viewmodel;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Styles()
		{
			this.SfGrid = new SfDataGrid ();
			viewmodel = new GridGettingStartedViewModel ();
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.ItemsSource = viewmodel.OrdersInfo;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.SelectionMode = SelectionMode.Multiple;
			this.SfGrid.GridViewCreated += SfGrid_GridViewCreated;
			segmentControl = new UISegmentedControl();
			segmentControl.ControlStyle = UISegmentedControlStyle.Bezeled;
			segmentControl.InsertSegment("Dark", 0,true);
			segmentControl.InsertSegment("Blue", 1, true);
			segmentControl.InsertSegment("Red", 2, true);
			segmentControl.InsertSegment("Green", 3, true);
            segmentControl.InsertSegment("Purple", 4, true);
            segmentControl.SelectedSegment = 0;
			segmentControl.ValueChanged += SegmentControl_ValueChanged;
			this.AddSubview (segmentControl);
			this.AddSubview (SfGrid);
		}

		void SegmentControl_ValueChanged (object sender, EventArgs e)
		{
			nint value = segmentControl.SelectedSegment;
			if (value == 0) {
				this.SfGrid.GridStyle = new Dark ();
			} else if (value == 1) {
				this.SfGrid.GridStyle = new Blue ();
			} else if (value == 2) {
				this.SfGrid.GridStyle = new Red ();
			} else if (value == 3) {
				this.SfGrid.GridStyle = new Green ();
            }
            else if (value == 4)
            {
                this.SfGrid.GridStyle = new Purple();
            }
        }

		void SfGrid_GridViewCreated (object sender, GridViewCreatedEventArgs e)
		{
			this.SfGrid.SelectedItem = viewmodel.OrdersInfo [3];
			this.SfGrid.GridStyle = new Dark();
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "Order ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Index") {
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 15;
			} else if (e.Column.MappingName == "ShippingDate") {
				e.Column.HeaderText = "Shipping Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "IsClosed") {
				e.Column.HeaderText = "Is Closed";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			}				
		}

		public override void LayoutSubviews ()
		{
			segmentControl.Frame = new CGRect (0, 0, this.Frame.Width, 30);
			this.SfGrid.Frame = new CGRect (0, segmentControl.Frame.Height, this.Frame.Width, this.Frame.Height - 30);
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            SfGrid.Dispose();
            base.Dispose(disposing);
        }
    }
}

