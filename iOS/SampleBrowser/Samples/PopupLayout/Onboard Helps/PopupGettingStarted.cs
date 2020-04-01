#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;
using System.Globalization;
using CoreGraphics;
using Syncfusion.iOS.PopupLayout;
using System.Linq;
using System.Reflection;
using Foundation;
using System.Threading;
using System.Timers;
using CoreAnimation;
using System.Threading.Tasks;

namespace SampleBrowser
{
	public class PopupGettingStarted : SampleView
	{
        #region Fields

        SfDataGrid SfGrid;
		int clickCount = 0;
		UIView mainView;
		SfPopupLayout sfPopUp;
		UIView backgroundView;
		UIImageView imageView;
		UIImageView img;
		UITapGestureRecognizer tapGesture;

        SwipingViewModel viewModel;
        DetailView detailView;
        UIButton nextButton;
        UILabel col1;
        UILabel col2;
        UILabel col3;
        UILabel col4;
        UITextField orderIDText;
        UITextField customerIDText;
        UITextField employeeIDText;
        UITextField nameText;
        private int swipedRowindex;
        private bool canCollapseVisibilty = false;
        private bool IsUndoClicked { get; set; }

		#endregion

		static bool UserInterfaceIdiomIsPhone
		{
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        public PopupGettingStarted()
        {
            mainView = new UIView();
            CreatePopup();
            this.CreateDataGrid();
            this.nextButton = new UIButton();
            nextButton.SetTitle("Next", UIControlState.Normal);
            nextButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            nextButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            nextButton.BackgroundColor = UIColor.Clear;
            nextButton.TouchDown += NextButton_TouchDown;
            sfPopUp.Content = mainView;
			sfPopUp.PopupView.BackgroundColor = UIColor.Clear;
            mainView.AddSubview(SfGrid);

            this.AddSubview(sfPopUp);
            this.AddSubview(nextButton);
            tapGesture = new UITapGestureRecognizer() { NumberOfTapsRequired = 1 };
            tapGesture.AddTarget(() => { BackgroundViewPressed(tapGesture); });
        }

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
            this.SfGrid.Frame = new CGRect(mainView.Frame.Left, mainView.Frame.Top, mainView.Frame.Width, mainView.Frame.Height );
            this.sfPopUp.Frame = new CGRect(0, 0, this.Frame.Width , this.Frame.Height);
            this.nextButton.Frame = new CGRect(this.Frame.Width - 100, this.Frame.Height- 60, 100, 30);
            detailView.Frame = new CGRect(10, this.SfGrid.Frame.Top + 100, SfGrid.Frame.Width - 20, 200);
            col1.Frame = new CGRect(detailView.Frame.Right * 0.15, detailView.Frame.Top + 20, detailView.Frame.Right / 2, 20);
            col2.Frame = new CGRect(detailView.Frame.Right * 0.15, col1.Frame.Bottom + 10, detailView.Frame.Right / 2, 20);
            col3.Frame = new CGRect(detailView.Frame.Right * 0.15, col2.Frame.Bottom + 10, detailView.Frame.Right / 2, 20);
            col4.Frame = new CGRect(detailView.Frame.Right * 0.15, col3.Frame.Bottom + 10, detailView.Frame.Right / 2, 20);
            orderIDText.Frame = new CGRect(col1.Frame.Right, detailView.Frame.Top + 20, detailView.Frame.Right, 20);
            customerIDText.Frame = new CGRect(col2.Frame.Right, orderIDText.Frame.Bottom + 10, detailView.Frame.Right, 20);
            employeeIDText.Frame = new CGRect(col3.Frame.Right, customerIDText.Frame.Bottom + 10, detailView.Frame.Right, 20);
            nameText.Frame = new CGRect(col4.Frame.Right, employeeIDText.Frame.Bottom + 10, detailView.Frame.Right, 20);

			var navigationBar = (((mainView.Superview as UIView).Window.RootViewController)as UINavigationController).NavigationBar;
		}

        void NextButton_TouchDown(object sender, EventArgs e)
        {
            clickCount++;
            sfPopUp.IsOpen = false;
            if (imageView == null)
            {
                imageView = new UIImageView();
            }
            if (clickCount == 1)
            {
                imageView = null;
                imageView = new UIImageView();

                UIView hostingView = new UIView();
                imageView.Image = UIImage.FromFile("Images/Popup_ResizingIllustration.png");
                sfPopUp.PopupView.Frame = new CGRect(1, this.Frame.Y, this.Frame.Width, 130);
                hostingView.Frame = new CGRect(0, 0, 160, 130);
                imageView.Frame = new CGRect(this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(0, 2)).X, 0, 130, 130);
                imageView.Center = new CGPoint(this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(0, 2)).X, this.Frame.Y);
                hostingView.AddSubview(imageView);
                sfPopUp.PopupView.ContentView = hostingView;
                sfPopUp.IsOpen = true;
            }
            else if (clickCount == 2)
            {
                imageView = null;
                imageView = new UIImageView();
                imageView.Image = UIImage.FromFile("Images/Popup_EditIllustration.png");
                sfPopUp.PopupView.ContentView = imageView;
                var point = this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(4, 2));
                sfPopUp.PopupView.Frame = new CGRect(point.X, point.Y, 150, 150);
                sfPopUp.IsOpen = true;
            }
            else if (clickCount == 3)
            {
                imageView = null;
                UIView hostingView = new UIView();
                imageView = new UIImageView();
                imageView.StopAnimating();
                imageView.Image = UIImage.FromFile("Images/Popup_SwipeIllustration.png");
                var point = this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(4, 0));
                sfPopUp.PopupView.Frame = new CGRect(point.X, point.Y - 10, 300, 150);
                hostingView.Frame = new CGRect(0, sfPopUp.PopupView.Frame.Top, 300, 150);
                imageView.Frame = new CGRect(point.X, 0, 200, 150);
                hostingView.AddSubview(imageView);
                sfPopUp.PopupView.ContentView = hostingView;
                sfPopUp.IsOpen = true;
            }
            else if (clickCount == 4)
            {
                UIView view = new UIView();
                imageView = null;
                imageView = new UIImageView();
                imageView.Image = UIImage.FromFile("Images/Popup_DragAndDropIllustration.png");
                imageView.Frame = new CGRect(0, 0, 200, 100);
                var point = this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(4, 0));
                view.AddSubview(imageView);
                img = new UIImageView();
                img.Image = UIImage.FromFile("Images/Popup_HandSymbol.png");
                img.Frame = new CGRect(10, 0, 20, 20);
                view.AddSubview(img);
                sfPopUp.PopupView.ContentView = view;
                sfPopUp.PopupView.Frame = new CGRect(point.X + 10, point.Y + 5, 200, 100);
                nextButton.SetTitle("Ok,Got It", UIControlState.Normal);
                sfPopUp.IsOpen = true;
            }
            else if (clickCount > 4)
            {
                backgroundView.RemoveFromSuperview();
                nextButton.RemoveFromSuperview();
            }
        }

		private void CreateDataGrid()
		{
            col1 = new UILabel();
            col1.Text = "Order ID";
            col2 = new UILabel();
            col2.Text = "Customer ID";
            col3 = new UILabel();
            col3.Text = "Employee ID";
            col4 = new UILabel();
            col4.Text = "Name";
            orderIDText = new UITextField();
            orderIDText.AllowsEditingTextAttributes = true;
            orderIDText.ShouldReturn += (textField) =>
            {
                orderIDText.ResignFirstResponder();
                return true;
            };
            customerIDText = new UITextField();
            customerIDText.ShouldReturn += (textField) =>
            {
                customerIDText.ResignFirstResponder();
                return true;
            };
            employeeIDText = new UITextField();
            employeeIDText.ShouldReturn += (textField) =>
            {
                employeeIDText.ResignFirstResponder();
                return true;
            };
            nameText = new UITextField();
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

            this.detailView = new DetailView();
            this.detailView.Hidden = true;
            this.SfGrid = new SfDataGrid();
            this.SfGrid.GridLoaded += SfGrid_GridLoaded;

            this.SfGrid.AllowDraggingRow = true;
            this.SfGrid.AllowEditing = true;
            this.SfGrid.AllowResizingColumn = true;
            this.SfGrid.SelectionMode = SelectionMode.Single;
            this.SfGrid.NavigationMode = NavigationMode.Cell;
            this.SfGrid.EditTapAction = TapAction.OnDoubleTap;

            this.viewModel = new SwipingViewModel();
            this.SfGrid.ItemsSource = viewModel.OrdersInfo;
            this.SfGrid.AutoGenerateColumns = false;
			this.SfGrid.GridStyle = new CustomStyles();
            this.SfGrid.ShowRowHeader = false;
            this.SfGrid.HeaderRowHeight = 45;
            this.SfGrid.RowHeight = 45;
            this.SfGrid.ColumnSizer = ColumnSizer.Star;

            UIButton leftSwipeViewText = new UIButton();
            leftSwipeViewText.SetTitle("Delete", UIControlState.Normal);
            leftSwipeViewText.SetTitleColor(UIColor.White, UIControlState.Normal);
            leftSwipeViewText.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            leftSwipeViewText.BackgroundColor = UIColor.FromRGB(220, 89, 95);
            leftSwipeViewText.TouchDown += LeftSwipeViewButton_TouchDown;
            leftSwipeViewText.Frame = new CGRect(56, 0, 60, 45);

            UIButton leftSwipeViewButton = new UIButton();

            leftSwipeViewButton.SetImage(UIImage.FromFile("Images/Popup_Delete.png"), UIControlState.Normal);
            leftSwipeViewButton.BackgroundColor = UIColor.FromRGB(220, 89, 95);
            leftSwipeViewButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            leftSwipeViewButton.TouchDown += LeftSwipeViewButton_TouchDown;
            leftSwipeViewButton.Frame = new CGRect(16, 10, 24, 24);

            CustomSwipeView leftSwipeView = new CustomSwipeView();
            leftSwipeView.AddSubview(leftSwipeViewButton);
            leftSwipeView.AddSubview(leftSwipeViewText);
            leftSwipeView.Frame = new CGRect(0, 0, 120, 44);
            leftSwipeView.BackgroundColor = UIColor.FromRGB(220, 89, 95);

            this.SfGrid.AllowSwiping = true;
            this.SfGrid.LeftSwipeView = leftSwipeView;

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
		}

        void LeftSwipeViewButton_TouchDown (object sender, EventArgs e)
        {
            viewModel.OrdersInfo.RemoveAt(swipedRowindex - 1);
        }   

        void SfGrid_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            SfGrid.MaxSwipeOffset = 120;
        }

        private void initializeTextFields()
        {
            if (swipedRowindex > 0)
            {
                var swipedRowData = this.viewModel.OrdersInfo[this.swipedRowindex - 1];
                orderIDText.Text = swipedRowData.OrderID;
                this.customerIDText.Text = swipedRowData.CustomerID;
                this.employeeIDText.Text = swipedRowData.EmployeeID;
                this.nameText.Text = swipedRowData.FirstName;
            }
        }

        private void SfGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            swipedRowindex = e.RowIndex;
            initializeTextFields();
        }

		private void SfGrid_GridLoaded(object sender, GridLoadedEventArgs e)
		{
            // Fix for popup is not shown in OnBoardHelps sample opening.
            // Popup is not shown initially, Since we have set PopupView Hidden property to false from WillMoveToWindow override for collapsing the view visibility when goes to other window.
            canCollapseVisibilty = true;
            sfPopUp.PopupView.Frame = new CGRect(this.Frame.Width - 25, this.Frame.Y, 150, 100);
			sfPopUp.Show();
		}

		private void CreatePopup()
		{
			sfPopUp = new SfPopupLayout();
            sfPopUp.StaysOpen = true;
			sfPopUp.PopupView.AnimationMode = AnimationMode.None;
			sfPopUp.PopupView.PopupStyle.BorderThickness = 0;
			sfPopUp.PopupView.PopupStyle.BorderColor = UIColor.Clear;
			sfPopUp.PopupView.ShowFooter = false;
			sfPopUp.PopupView.ShowHeader = false;
			sfPopUp.Opened += SfPopUp_PopupOpened;
			sfPopUp.Closed += SfPopUp_PopupClosed;
			sfPopUp.BackgroundColor = UIColor.Clear;

			imageView = new UIImageView();
			imageView.Image = UIImage.FromFile("Images/Popup_InfoNotification.png");
            sfPopUp.PopupView.ContentView = imageView;
		}

        public override void WillMoveToWindow(UIWindow window)
        {
            //This method is called by the runtime when navigate one window to another window.
            base.WillMoveToWindow(window);
            if (this.Window != null && (this.Window.RootViewController as UINavigationController).TopViewController is SampleBrowser.HomeViewController)
                return;
            if (sfPopUp.PopupView != null && canCollapseVisibilty)
            {
                if (window == null && sfPopUp.IsOpen)
                    //Setting PopupView Visibility when navigate one window to another window.
                    sfPopUp.PopupView.Hidden = true;
                else
                    sfPopUp.PopupView.Hidden = false;
            }
        }

        private void SfPopUp_PopupClosed(object sender, EventArgs e)
		{
			//if (clickCount == 5)
				//backgroundView.RemoveFromSuperview();
		}

		private void SfPopUp_PopupOpened(object sender, EventArgs e)
		{
			AddBackgroundView();
			if (clickCount == 0)
			{
				Action moveUpDown = () =>
				{
					var ypos = this.Frame.Y + 16;
					imageView.Center = new CGPoint(imageView.Center.X, ypos);
				};

				UIView.Animate(1, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat, moveUpDown, () => { });
			}
			else if (clickCount == 1)
			{
				Action moveLeftRight = () =>
				{
					var xpos = imageView.Center.X + 60;
					var ypos = sfPopUp.PopupView.Center.Y;
                    imageView.Center = new CGPoint(xpos, imageView.Center.Y);
				};

				UIView.Animate(2, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Repeat, moveLeftRight, () => { });
			}
			else if (clickCount == 2)
			{
				imageView.Alpha = 0.0f;
				Action setOpacity = () =>
				{
					imageView.Alpha = 1.0f;
				};

				UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveEaseInOut , setOpacity ,async () => 
				{
					imageView.Alpha = 0.0f;
					await Task.Delay(200);
					imageView.Alpha = 1.0f;
					await Task.Delay(1000);
					LoopAnimate();
				});
			}
			else if (clickCount == 3)
			{
				Action moveLeftRight = () =>
				{
					var xpos = sfPopUp.PopupView.Center.X + 60;
					var ypos = imageView.Center.Y;
					imageView.Center = new CGPoint(xpos, ypos);
				};

				UIView.Animate(2, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Repeat, moveLeftRight, () => { });
			}
			else if (clickCount == 4)
			{
				CGPoint fromPt = new CGPoint(img.Center.X + 10, img.Center.Y + 10);
				img.Layer.Position = new CGPoint(img.Center.X + 70, img.Center.Y + 70);
				CGPath path = new CGPath();
				path.AddLines(new CGPoint[] { fromPt, new CGPoint(30, 20),new CGPoint(40, 25), new CGPoint(50, 30), new CGPoint(60, 40),new CGPoint(70, 50),new CGPoint(80, 60), new CGPoint(80,70) });
				CAKeyFrameAnimation animPosition = (CAKeyFrameAnimation)CAKeyFrameAnimation.FromKeyPath("position");
				animPosition.Path = path;
				animPosition.RepeatCount = int.MaxValue;
				animPosition.Duration = 1.25;
				img.Layer.AddAnimation(animPosition, "position");
			}
		}

		private void LoopAnimate()
		{
			if (clickCount > 2)
				return;
			else
			{
				imageView.Alpha = 0.0f;
				Action setOpacity = () =>
				{
					imageView.Alpha = 1.0f;
				};

				UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveEaseInOut, setOpacity, async () =>
								{
									imageView.Alpha = 0.0f;
									await Task.Delay(200);
									imageView.Alpha = 1.0f;
									await Task.Delay(1000);
									LoopAnimate();
								});
			}
		}

		private void AddBackgroundView()
		{
            if (mainView.Subviews.FirstOrDefault(x => x.Tag == 100) == null)
            {
                backgroundView = new UIView();
                backgroundView.Tag = 100;
                backgroundView.BackgroundColor = UIColor.Black;
                backgroundView.Alpha = 0.82f;
                backgroundView.AddGestureRecognizer(tapGesture);
                this.mainView.AddSubview(backgroundView);
                backgroundView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            }
		}

        private void BackgroundViewPressed(UITapGestureRecognizer tapGesture)
		{
            clickCount++;
            sfPopUp.IsOpen = false;
            if (imageView == null)
            {
                imageView = new UIImageView();
            }
            if (clickCount == 1)
            {
                imageView = null;
                imageView = new UIImageView();

                UIView hostingView = new UIView();
                imageView.Image = UIImage.FromFile("Images/Popup_ResizingIllustration.png");
                sfPopUp.PopupView.Frame = new CGRect(1, this.Frame.Y, this.Frame.Width, 130);
                hostingView.Frame = new CGRect(0, 0, 160, 130);
                imageView.Frame = new CGRect(this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(0, 2)).X, 0, 130, 130);
                imageView.Center = new CGPoint(this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(0, 2)).X, this.Frame.Y);
                hostingView.AddSubview(imageView);
                sfPopUp.PopupView.ContentView = hostingView;
                sfPopUp.IsOpen = true;
            }
            else if (clickCount == 2)
            {
                imageView = null;
                imageView = new UIImageView();
                imageView.Image = UIImage.FromFile("Images/Popup_EditIllustration.png");
                sfPopUp.PopupView.ContentView = imageView;
                var point = this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(4, 2));
                sfPopUp.PopupView.Frame = new CGRect(point.X, point.Y, 150, 150);
                sfPopUp.IsOpen = true;
            }
            else if (clickCount == 3)
            {
                imageView = null;
                UIView hostingView = new UIView();
                imageView = new UIImageView();
                imageView.StopAnimating();
                imageView.Image = UIImage.FromFile("Images/Popup_SwipeIllustration.png");
                var point = this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(4, 0));
                sfPopUp.PopupView.Frame = new CGRect(point.X, point.Y - 10, 300, 150);
                hostingView.Frame = new CGRect(0, sfPopUp.PopupView.Frame.Top, 300, 150);
                imageView.Frame = new CGRect(point.X, 0, 200, 150);
                hostingView.AddSubview(imageView);
                sfPopUp.PopupView.ContentView = hostingView;
                sfPopUp.IsOpen = true;
            }
            else if (clickCount == 4)
            {
                UIView view = new UIView();
                imageView = null;
                imageView = new UIImageView();
                imageView.Image = UIImage.FromFile("Images/Popup_DragAndDropIllustration.png");
                imageView.Frame = new CGRect(0, 0, 200, 100);
                var point = this.SfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(4, 0));
                view.AddSubview(imageView);
                img = new UIImageView();
                img.Image = UIImage.FromFile("Images/Popup_HandSymbol.png");
                img.Frame = new CGRect(10, 0, 20, 20);
                view.AddSubview(img);
                sfPopUp.PopupView.ContentView = view;
                sfPopUp.PopupView.Frame = new CGRect(point.X + 10, point.Y + 5, 200, 100);
                nextButton.SetTitle("Ok,Got It", UIControlState.Normal);
                sfPopUp.IsOpen = true;
            }
            else if (clickCount > 4)
            {
                backgroundView.RemoveFromSuperview();
                nextButton.RemoveFromSuperview();
            }
		}

		protected override void Dispose(bool disposing)
		{
            //sfPopUp.DismissPopup(true);
            if (backgroundView != null)
            {
                mainView.WillRemoveSubview(backgroundView);
                mainView.SendSubviewToBack(backgroundView);
                sfPopUp.RemoveFromSuperview();
                backgroundView.BackgroundColor = UIColor.Brown;
                backgroundView.UserInteractionEnabled = false;
                backgroundView.Frame = new CGRect(0, 0, 0, 0);
                backgroundView.RemoveFromSuperview();
                nextButton.RemoveFromSuperview();
                backgroundView = null;
            }
            base.Dispose(disposing);
            if (SfGrid != null)
                SfGrid.Dispose();
            if (sfPopUp != null)
                sfPopUp.Dispose();
            mainView = null;
        }
	}
}

