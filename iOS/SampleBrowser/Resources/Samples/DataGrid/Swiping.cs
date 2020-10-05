#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using CoreGraphics;
using UIKit;
using System.Threading.Tasks;
using Foundation;

namespace SampleBrowser
{
	public class Swiping:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;
		SwipingViewModel viewModel;
		DetailView detailView;

		UILabel col1;
		UILabel col2;
		UILabel col3;
		UILabel col4;
		UITextField orderIDText;
		UITextField customerIDText;
		UITextField employeeIDText;
		UITextField nameText;
		UIButton save;
		UIButton cancel;


		private bool IsUndoClicked{ get; set; }
		private int swipedRowindex;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Swiping ()
		{
			save = new UIButton ();
			save.SetTitle ("Save", UIControlState.Normal);
			save.BackgroundColor = UIColor.DarkGray;
			save.Font = UIFont.FromName("Helvetica-Bold", 12f);
			save.TouchDown += Save_TouchDown;
			cancel = new UIButton ();
			cancel.SetTitle ("Cancel", UIControlState.Normal);
			cancel.TouchDown += Cancel_TouchDown;
			cancel.BackgroundColor = UIColor.DarkGray;
			cancel.Font = UIFont.FromName("Helvetica-Bold", 12f);
			col1 = new UILabel();
			col1.Text="Order ID";
			col2 = new UILabel();
			col2.Text="Customer ID";
			col3 = new UILabel();
			col3.Text="Employee ID";
			col4 = new UILabel();
			col4.Text="Name";
			orderIDText = new UITextField ();
			orderIDText.AllowsEditingTextAttributes = true;
			orderIDText.ShouldReturn += (textField) => 
				{ 
					orderIDText.ResignFirstResponder();
					return true;
				};			
			customerIDText = new UITextField ();
			customerIDText.ShouldReturn += (textField) => 
			{ 
				customerIDText.ResignFirstResponder();
				return true;
			};		
			employeeIDText = new UITextField ();
			employeeIDText.ShouldReturn += (textField) => 
			{ 
				employeeIDText.ResignFirstResponder();
				return true;
			};		
			nameText = new UITextField ();
			nameText.ShouldReturn += (textField) => 
			{ 
				nameText.ResignFirstResponder();
				return true;
			};		
			orderIDText.Hidden = true;
			customerIDText.Hidden = true;
			employeeIDText.Hidden = true;
			nameText.Hidden = true;
			col1.Hidden = true;
			col2.Hidden = true;
			col3.Hidden = true;
			col4.Hidden = true;
			save.Hidden = true;
			cancel.Hidden = true;

			this.detailView = new DetailView ();
			this.detailView.Hidden = true;		
			this.SfGrid = new SfDataGrid ();
			this.viewModel = new SwipingViewModel ();
			this.SfGrid.ItemsSource = viewModel.OrdersInfo;
			this.SfGrid.AutoGenerateColumns = false;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.ColumnSizer = ColumnSizer.Star;

			UIButton leftSwipeViewText = new UIButton ();
            leftSwipeViewText.SetTitle("Edit", UIControlState.Normal);
            leftSwipeViewText.SetTitleColor(UIColor.White, UIControlState.Normal);
			leftSwipeViewText.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			leftSwipeViewText.BackgroundColor = UIColor.FromRGB(0,158,218);
            leftSwipeViewText.TouchUpInside += LeftSwipeViewButton_TouchUpInside;
            leftSwipeViewText.Frame = new CGRect(56, 0, 60, 45);

			UIButton leftSwipeViewButton = new UIButton ();
			leftSwipeViewButton.SetImage (UIImage.FromFile("Images/Edit.png"),UIControlState.Normal);
            leftSwipeViewButton.BackgroundColor = UIColor.FromRGB(0, 158, 218);
            leftSwipeViewButton.TouchUpInside += LeftSwipeViewButton_TouchUpInside;
            leftSwipeViewButton.Frame = new CGRect(16, 10, 24, 24);

			CustomSwipeView leftSwipeView = new CustomSwipeView ();		
			leftSwipeView.AddSubview (leftSwipeViewButton);
            leftSwipeView.AddSubview(leftSwipeViewText);
            leftSwipeView.Frame = new CGRect(0, 0, 120, 44);
            leftSwipeView.BackgroundColor = UIColor.FromRGB(0, 158, 218);

			UIButton rightSwipeViewText = new UIButton ();
			rightSwipeViewText.SetTitle ("Delete", UIControlState.Normal);
            rightSwipeViewText.SetTitleColor(UIColor.White, UIControlState.Normal);
			rightSwipeViewText.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            rightSwipeViewText.BackgroundColor = UIColor.FromRGB(220, 89, 95);
            rightSwipeViewText.TouchUpInside += RightSwipeViewButton_TouchUpInside;
            rightSwipeViewText.Frame = new CGRect(56, 0, 60, 45);


			UIButton rightSwipeViewButton = new UIButton ();
			rightSwipeViewButton.SetImage (UIImage.FromFile("Images/Delete.png"),UIControlState.Normal);
            rightSwipeViewButton.BackgroundColor = UIColor.FromRGB(220, 89, 95);
			rightSwipeViewButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            rightSwipeViewButton.TouchUpInside += RightSwipeViewButton_TouchUpInside;
            rightSwipeViewButton.Frame = new CGRect(16, 10, 24, 24);

			CustomSwipeView rightSwipeView = new CustomSwipeView ();
			rightSwipeView.AddSubview (rightSwipeViewButton);
            rightSwipeView.AddSubview(rightSwipeViewText);
            rightSwipeView.Frame = new CGRect(0, 0, 120, 44);
            rightSwipeView.BackgroundColor = UIColor.FromRGB(220, 89, 95);

			this.SfGrid.AllowSwiping = true;
			this.SfGrid.LeftSwipeView = leftSwipeView;
			this.SfGrid.RightSwipeView = rightSwipeView;
			this.SfGrid.SwipeEnded += SfGrid_SwipeEnded;
			this.SfGrid.SwipeStarted += SfGrid_SwipeStarted;
            this.SfGrid.GridTapped += SfGrid_GridTapped;
            this.SfGrid.GridLongPressed += SfGrid_GridLongPressed;

            GridTextColumn CustomerID = new GridTextColumn();
            CustomerID.MappingName = "CustomerID";
            CustomerID.HeaderText = "Customer ID";
            GridTextColumn OrderID = new GridTextColumn();
            OrderID.MappingName = "OrderID";
            OrderID.HeaderText = "Order ID";
            GridTextColumn EmployeeID = new GridTextColumn();
            EmployeeID.MappingName = "EmployeeID";
            EmployeeID.HeaderText = "Employee ID";
            GridTextColumn Name = new GridTextColumn();
            Name.MappingName = "FirstName";
            Name.HeaderText = "Name";

			this.SfGrid.Columns.Add(OrderID);
			this.SfGrid.Columns.Add(CustomerID);
			this.SfGrid.Columns.Add(EmployeeID);
			this.SfGrid.Columns.Add(Name);

			this.AddSubview (SfGrid);
			this.AddSubview (detailView);
			this.AddSubview (col1);
			this.AddSubview (col2);
			this.AddSubview (col3);
			this.AddSubview (col4);
			this.AddSubview (orderIDText);
			this.AddSubview (customerIDText);
			this.AddSubview (employeeIDText);
			this.AddSubview (nameText);
			this.AddSubview (save);
			this.AddSubview (cancel);
		}

        private void SfGrid_GridLongPressed(object sender, GridLongPressedEventArgs e)
        {
            this.CloseEditWindow();
        }

        private void SfGrid_GridTapped(object sender, GridTappedEventArgs e)
        {
            this.CloseEditWindow();
        }

        void Cancel_TouchDown(object sender, EventArgs e)
        {
            CloseEditWindow();
        }

        private void CloseEditWindow()
        {
            hideOptionViews();
            initializeTextFields();
        }

		void Save_TouchDown (object sender, EventArgs e)
		{
			commitValues ();
			hideOptionViews ();
		}

		private void commitValues ()
		{
			if (swipedRowindex > 0) {
				var swipedRowData = this.viewModel.OrdersInfo [this.swipedRowindex - 1];
				swipedRowData.OrderID = this.orderIDText.Text;
				swipedRowData.CustomerID = this.customerIDText.Text;
				swipedRowData.EmployeeID = this.employeeIDText.Text;
				swipedRowData.FirstName = this.nameText.Text;
			}
		}

		private void hideOptionViews()
		{
			this.detailView.Hidden = true;
			this.col1.Hidden = true;
			this.col2.Hidden = true;
			this.col3.Hidden = true;
			this.col4.Hidden = true;
			this.orderIDText.Hidden = true;
			this.customerIDText.Hidden = true;
			this.employeeIDText.Hidden = true;
			this.nameText.Hidden = true;
			this.save.Hidden = true;
			this.cancel.Hidden = true;
		}

		private void initializeTextFields()
		{
			if (swipedRowindex > 0) {
				var swipedRowData = this.viewModel.OrdersInfo [this.swipedRowindex - 1];
				orderIDText.Text = swipedRowData.OrderID;
				this.customerIDText.Text = swipedRowData.CustomerID;
				this.employeeIDText.Text = swipedRowData.EmployeeID;
				this.nameText.Text = swipedRowData.FirstName;
			}
		}

		void LeftSwipeViewButton_TouchUpInside(object sender, EventArgs e)
		{
			this.detailView.Hidden = false;
			this.col1.Hidden = false;
			this.col2.Hidden = false;
			this.col3.Hidden = false;
			this.col4.Hidden = false;
			this.orderIDText.Hidden = false;
			this.customerIDText.Hidden = false;
			this.employeeIDText.Hidden = false;
			this.nameText.Hidden = false;
			this.save.Hidden = false;
			this.cancel.Hidden= false;
		}			

		void RightSwipeViewButton_TouchUpInside(object sender, EventArgs e)
		{			
			viewModel.OrdersInfo.RemoveAt(swipedRowindex - 1);
		}

		public override void LayoutSubviews ()
		{
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			detailView.Frame = new CGRect (10, this.SfGrid.Frame.Top + 100, SfGrid.Frame.Width - 20, 200);
			col1.Frame = new CGRect (detailView.Frame.Right * 0.15, detailView.Frame.Top + 20, detailView.Frame.Right /2, 20);
			col2.Frame = new CGRect (detailView.Frame.Right * 0.15, col1.Frame.Bottom + 10, detailView.Frame.Right /2, 20);
			col3.Frame = new CGRect (detailView.Frame.Right * 0.15, col2.Frame.Bottom + 10, detailView.Frame.Right /2, 20);
			col4.Frame = new CGRect (detailView.Frame.Right * 0.15, col3.Frame.Bottom + 10, detailView.Frame.Right /2, 20);
			orderIDText.Frame= new CGRect( col1.Frame.Right,detailView.Frame.Top+ 20,detailView.Frame.Right,20);
			customerIDText.Frame= new CGRect( col2.Frame.Right,orderIDText.Frame.Bottom +10,detailView.Frame.Right,20);
			employeeIDText.Frame= new CGRect( col3.Frame.Right,customerIDText.Frame.Bottom +10,detailView.Frame.Right,20);
			nameText.Frame= new CGRect( col4.Frame.Right,employeeIDText.Frame.Bottom +10,detailView.Frame.Right,20);
			save.Frame = new CGRect (detailView.Frame.Right / 4, nameText.Frame.Bottom + 20, 50, 20);
			cancel.Frame = new CGRect (save.Frame.Right +10, nameText.Frame.Bottom + 20, 80, 20);
			base.LayoutSubviews ();
		}

		void SfGrid_SwipeStarted (object sender, SwipeStartedEventArgs e)
		{
            SfGrid.MaxSwipeOffset = 120;
		}

		private void SfGrid_SwipeEnded (object sender, SwipeEndedEventArgs e)
		{			
			swipedRowindex = e.RowIndex;
			initializeTextFields ();
		}

        protected override void Dispose(bool disposing)
        {
            save.TouchDown -= Save_TouchDown;
            cancel.TouchDown -= Cancel_TouchDown;
            SfGrid.SwipeEnded -= SfGrid_SwipeEnded;
            SfGrid.SwipeStarted -= SfGrid_SwipeStarted;
            SfGrid.GridTapped -= SfGrid_GridTapped;
            SfGrid.GridLongPressed -= SfGrid_GridLongPressed;
            SfGrid.Dispose();
            base.Dispose(disposing);
            col1 = null;
            col2 = null;
            col3 = null;
            col4 = null;
            orderIDText = null;
            customerIDText = null;
            employeeIDText = null;
            nameText = null;
            save = null;
            cancel = null;
            viewModel = null;
            detailView = null;
            SfGrid = null;
        }
    }
		
	public class DetailView : UIView
	{		
		public DetailView ()
		{			
			this.BackgroundColor = UIColor.LightGray;
		}			
	}

	public class CustomSwipeView : UIView
	{
		public override bool Hidden
		{
			get { return base.Hidden; }
			set { base.Hidden = value; }
		}

		public CustomSwipeView()
		{
		}

		public override void LayoutSubviews()
		{
			var start = 0;
			var childWidth = this.Frame.Width / 3;
			
		}
	}
}
