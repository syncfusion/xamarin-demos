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

namespace SampleBrowser
{
	public class SwipeDelete:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;
		SwipingViewModel viewModel;

		private bool IsUndoClicked{ get; set; }
		private int swipedRowindex;
		private bool isSuspend;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public SwipeDelete ()
		{
			this.SfGrid = new SfDataGrid ();
			this.viewModel = new SwipingViewModel ();
			this.SfGrid.ItemsSource = viewModel.OrdersInfo;
			this.SfGrid.AutoGenerateColumns = false;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.ColumnSizer = ColumnSizer.Star;

			UILabel leftSwipeViewText = new UILabel ();
			leftSwipeViewText.Text = "Deleted";
            leftSwipeViewText.TextColor = UIColor.White;
			leftSwipeViewText.TextAlignment = UITextAlignment.Left;
            leftSwipeViewText.BackgroundColor = UIColor.FromRGB(26, 170, 135);


			UILabel leftSwipeViewButton = new UILabel();
			leftSwipeViewButton.UserInteractionEnabled = true;
            leftSwipeViewButton.Text = "UNDO";
			leftSwipeViewButton.TextColor = UIColor.White;
            leftSwipeViewButton.Font = UIFont.BoldSystemFontOfSize(14);
            leftSwipeViewButton.TextAlignment = UITextAlignment.Right;
            leftSwipeViewButton.BackgroundColor = UIColor.FromRGB(26,170,135);
            leftSwipeViewButton.AddGestureRecognizer(new UITapGestureRecognizer(UndoTapped)); 

			SwipeView leftSwipeView = new SwipeView ();
			leftSwipeView.BackgroundColor = UIColor.FromRGB(26, 170, 135);
			leftSwipeView.AddSubview (leftSwipeViewText);
			leftSwipeView.AddSubview (leftSwipeViewButton);	

			UILabel rightSwipeViewText = new UILabel ();
			rightSwipeViewText.Text = "Deleted";
            rightSwipeViewText.TextColor = UIColor.White;
			rightSwipeViewText.TextAlignment = UITextAlignment.Left;
            rightSwipeViewText.BackgroundColor = UIColor.FromRGB(26, 170, 135);
						
			UILabel rightSwipeViewButton = new UILabel ();
			rightSwipeViewButton.UserInteractionEnabled = true;
            rightSwipeViewButton.Text = "UNDO";
			rightSwipeViewButton.TextColor = UIColor.White;
            rightSwipeViewButton.Font = UIFont.BoldSystemFontOfSize(14);
            rightSwipeViewButton.TextAlignment = UITextAlignment.Right;
            rightSwipeViewButton.BackgroundColor = UIColor.FromRGB(26, 170, 135);
            rightSwipeViewButton.AddGestureRecognizer(new UITapGestureRecognizer(UndoTapped));

            SwipeView rightSwipeView = new SwipeView ();
			rightSwipeView.BackgroundColor = UIColor.FromRGB(26, 170, 135);
			rightSwipeView.AddSubview (rightSwipeViewText);
			rightSwipeView.AddSubview (rightSwipeViewButton);

			this.SfGrid.AllowSwiping = true;
			this.SfGrid.LeftSwipeView = leftSwipeView;
			this.SfGrid.RightSwipeView = rightSwipeView;
			this.SfGrid.SwipeEnded += SfGrid_SwipeEnded;
			this.SfGrid.SwipeStarted += SfGrid_SwipeStarted;

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
		}

		void UndoTapped (UITapGestureRecognizer gesture)
		{
            if (gesture.State == UIGestureRecognizerState.Ended)
            {
                var removedData = viewModel.OrdersInfo[swipedRowindex - 1];
                var isSelected = SfGrid.SelectedItems.Contains(removedData);
                viewModel.OrdersInfo.Remove(removedData);
                viewModel.OrdersInfo.Insert(swipedRowindex - 1, removedData);
                if (isSelected)
                    SfGrid.SelectedItems.Add(removedData);
                IsUndoClicked = true;
            }
		}

		void SfGrid_SwipeStarted (object sender, SwipeStartedEventArgs e)
		{
			SfGrid.MaxSwipeOffset = (int)SfGrid.Frame.Width;	
			if (isSuspend)
				e.Cancel = true;
		}

		private async void SfGrid_SwipeEnded (object sender, SwipeEndedEventArgs e)
		{
			isSuspend = true;
			swipedRowindex = e.RowIndex;
			if(Math.Abs(e.SwipeOffset) >= SfGrid.MaxSwipeOffset/2)
			{
				await Task.Delay(2000);
				if (!IsUndoClicked)
					viewModel.OrdersInfo.RemoveAt(swipedRowindex - 1);
				else
				{
					var removedData = viewModel.OrdersInfo[swipedRowindex - 1];
					var isSelected = SfGrid.SelectedItems.Contains(removedData);
					viewModel.OrdersInfo.Remove(removedData);
					viewModel.OrdersInfo.Insert(swipedRowindex - 1, removedData);
					if (isSelected)
						SfGrid.SelectedItems.Add(removedData);
					IsUndoClicked = false;
				}isSuspend = false;
			}
			else 
				isSuspend= false;
		}

		public override void LayoutSubviews ()
		{
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            SfGrid.Dispose();
            base.Dispose(disposing);
        }
    }
		
	public class SwipeView : UIView
	{
		public override bool Hidden 
		{
			get { return base.Hidden; }
			set { base.Hidden = value;}
		}

		public SwipeView()
		{
		}

		public override void LayoutSubviews()
		{
			var start = 0;
			var childWidth = this.Frame.Width / 2;
			try
			{
				this.Subviews[0].Frame = new CGRect(start + 20, 0, childWidth - 20, this.Frame.Height);
				this.Subviews[1].Frame = new CGRect(childWidth, 0, childWidth - 15, this.Frame.Height);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}		
}

