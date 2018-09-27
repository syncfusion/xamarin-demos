#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 



#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfNavigationDrawer.iOS;

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
	public class NavigationDrawer : SampleView
	{
		private string selectedType;
		UILabel positionLabel,transitionLabel;
		UIButton positionbutton = new UIButton ();
		UILabel usernameLabel;
		UIButton transitionbutton = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView selectionPicker1, selectionPicker2;

		public UITableView table;
		public string[] tableItems;
		UIView HeaderView;
		UIImageView userImg;
		static public SFNavigationDrawer sideMenuController;
		static public MainPageView mainView;
		private readonly IList<string> positionAlignmentlist = new List<string>
		{
			"Left",
			"Right",
			"Top",
			"Bottom"

		};
		private readonly IList<string> transitionAlignmentList = new List<string>
		{
			"SlideOnTop",
			"Reveal",
			"Push"
		};
		public NavigationDrawer ()
		{
			selectionPicker1 = new UIPickerView ();
			selectionPicker2 = new UIPickerView ();
			this.OptionView = new UIView ();

			PickerModel model = new PickerModel (positionAlignmentlist);
			selectionPicker1.Model = model;
			PickerModel model1 = new PickerModel (transitionAlignmentList);
			selectionPicker2.Model = model1;

			positionLabel = new UILabel ();

			positionbutton = new UIButton ();
			transitionbutton = new UIButton ();
			transitionLabel = new UILabel ();



			positionLabel.Text = "Position";
			positionLabel.TextColor = UIColor.Black;
			positionLabel.TextAlignment = UITextAlignment.Left;

			transitionLabel.Text = "Transition";
			transitionLabel.TextColor = UIColor.Black;
			transitionLabel.TextAlignment = UITextAlignment.Left;


			positionbutton.SetTitle("Left",UIControlState.Normal);
			positionbutton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			positionbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			positionbutton.Layer.CornerRadius = 8;
			positionbutton.Layer.BorderWidth = 2;
			positionbutton.TouchUpInside += ShowPicker1;
			positionbutton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;


			transitionbutton.SetTitle("SlideOnTop",UIControlState.Normal);
			transitionbutton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			transitionbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			transitionbutton.Layer.CornerRadius = 8;
			transitionbutton.Layer.BorderWidth = 2;
			transitionbutton.TouchUpInside += ShowPicker2;
			transitionbutton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			doneButton.SetTitle("Done\t",UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246,246,246);

			model.PickerChanged += SelectedIndexChanged;
			model1.PickerChanged += SelectedIndexChanged1;

			selectionPicker1.ShowSelectionIndicator = true;
			selectionPicker1.Hidden = true;

			selectionPicker2.ShowSelectionIndicator = true;
			selectionPicker2.Hidden = true;
//			this.AddSubview (this);
		}


		public override void LayoutSubviews ()
		{

			//NavigationDrawer initialize
			sideMenuController = new SFNavigationDrawer ();
			mainView = new MainPageView(this.Frame);
			UIButton menubutton=new UIButton();
			menubutton.Frame =new CGRect (10, 10, 30, 30);
			menubutton.SetBackgroundImage (new UIImage ("Images/menu.png"), UIControlState.Normal);
			mainView.AddSubview (menubutton);

			sideMenuController.ContentView = mainView;
			if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				sideMenuController.DrawerWidth = (this.Bounds.Width*40)/100;
			}
			else
				sideMenuController.DrawerWidth = (this.Bounds.Width*60)/100;

			sideMenuController.DrawerHeight = this.Bounds.Height;
			mainView.Frame = new CGRect (0, 0, this.Bounds.Width, this.Bounds.Height);

			//Menu Page Design
			table = new UITableView(new CGRect(0, 0, sideMenuController.DrawerWidth, this.Frame.Height)); // defaults to Plain style
			tableItems = new string[] {"Home","Profile","Inbox","Outbox","Sent Items","Trash"};
			TableSource tablesource = new TableSource(tableItems);
			tablesource.customise = false;
			table.Source = tablesource;
			this.BackgroundColor = UIColor.FromRGB(63,134,246);
			HeaderView = new UIView ();
			HeaderView.Frame = new CGRect (0, 0, sideMenuController.DrawerWidth, 100);
			HeaderView.BackgroundColor = UIColor.FromRGB (49, 173, 225);
			UIView centerview = new UIView ();
			centerview.Frame = new CGRect (0, 100, sideMenuController.DrawerWidth, 500);
			centerview.Add (table);
			usernameLabel = new UILabel ();
			usernameLabel.Frame =new CGRect (0, 70, sideMenuController.DrawerWidth, 30);
			usernameLabel.Text="James Pollock";
			usernameLabel.TextColor = UIColor.White;
			usernameLabel.TextAlignment = UITextAlignment.Center;
			HeaderView.AddSubview (usernameLabel);

			userImg=new UIImageView();
			userImg.Frame =new CGRect ((sideMenuController.DrawerWidth/2)-25, 15, 50, 50);
			userImg.Image = new UIImage ("Images/User.png");

			HeaderView.AddSubview (userImg);

			sideMenuController.DrawerHeaderView = HeaderView;
			sideMenuController.DrawerContentView = centerview;
			sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionLeft;

			this.AddSubview (sideMenuController);


			menubutton.TouchDown+= (object sender, System.EventArgs e) => 
			{
				sideMenuController.ToggleDrawer();

			};



			foreach (var view in this.Subviews) {

				sideMenuController.Frame = new CGRect(0,0,this.Frame.Width,this.Frame.Height);
				positionLabel.Frame = new CGRect (this.Frame.X +10, 0, PopoverSize.Width - 20, 30);
				positionbutton.Frame=new CGRect(this.Frame.X +10, 40, PopoverSize.Width - 20, 30);	
				transitionLabel.Frame = new CGRect (this.Frame.X +10, 90, PopoverSize.Width - 20, 30);
				transitionbutton.Frame=new CGRect(this.Frame.X +10,130, PopoverSize.Width - 20, 30);	
				selectionPicker1.Frame = new CGRect (0, PopoverSize.Height/2, PopoverSize.Width, PopoverSize.Height/3);
				selectionPicker2.Frame = new CGRect (0, PopoverSize.Height/2, PopoverSize.Width , PopoverSize.Height/3);
				doneButton.Frame = new CGRect (0, PopoverSize.Height/2.5, PopoverSize.Width, 40);
			}
			this.optionView ();

		}
		public void  optionView()
		{
			this.OptionView.AddSubview (positionLabel);
			this.OptionView.AddSubview (positionbutton);
			this.OptionView.AddSubview (transitionLabel);
			this.OptionView.AddSubview (transitionbutton);
			this.OptionView.AddSubview (selectionPicker1);
			this.OptionView.AddSubview (selectionPicker2);
			this.OptionView.AddSubview (doneButton);
		}
		void ShowPicker1 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			selectionPicker1.Hidden = false;
			selectionPicker2.Hidden = true;
			transitionbutton.Hidden = false;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			selectionPicker2.Hidden = true;
			selectionPicker1.Hidden = true;
			transitionbutton.Hidden = false;
		}

		void ShowPicker2 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			selectionPicker1.Hidden = true;
			selectionPicker2.Hidden = false;
			transitionbutton.Hidden = false;
		}

		private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			positionbutton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Left") {
				sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionLeft;
				sideMenuController.DrawerHeight =this.Frame.Height;
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					sideMenuController.DrawerWidth = (this.Bounds.Width*40)/100;
				}
				else
					sideMenuController.DrawerWidth = (this.Bounds.Width*60)/100;
				
				table.Frame=new CGRect (0, 0, sideMenuController.DrawerWidth, this.Frame.Height);
				usernameLabel.Frame=new CGRect (0, 70, sideMenuController.DrawerWidth, 30);
				userImg.Frame =new CGRect ((sideMenuController.DrawerWidth/2)-25, 15, 50, 50);
			} 
			else if (selectedType == "Top") {
				sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionTop;
				sideMenuController.DrawerHeight =200;
				sideMenuController.DrawerWidth = this.Frame.Width;
				table.Frame=new CGRect (0, 0, this.Frame.Width, 100);
				usernameLabel.Frame=new CGRect (0, 70, this.Frame.Width, 30);
				userImg.Frame =new CGRect ((this.Frame.Width/2)-25, 15, 50, 50);
			}
			else if (selectedType == "Bottom") {
				sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionBottom;
				sideMenuController.DrawerHeight =300;
				sideMenuController.DrawerWidth = this.Frame.Width;
				table.Frame=new CGRect (0, 0, this.Frame.Width, 100);
				usernameLabel.Frame=new CGRect (0, 70, this.Frame.Width, 30);
				userImg.Frame =new CGRect ((this.Frame.Width/2)-25, 15, 50, 50);
			}
			else 
			{
				sideMenuController.Position=SFNavigationDrawerPosition.SFNavigationDrawerPositionRight;
				sideMenuController.DrawerHeight =this.Frame.Height;
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					sideMenuController.DrawerWidth = (this.Bounds.Width*40)/100;
				}
				else
					sideMenuController.DrawerWidth = (this.Bounds.Width*60)/100;
				
				table.Frame=new CGRect (0, 0, sideMenuController.DrawerWidth, this.Frame.Height);
				usernameLabel.Frame=new CGRect (0, 70, sideMenuController.DrawerWidth, 30);
				userImg.Frame =new CGRect ((sideMenuController.DrawerWidth/2)-25, 15, 50, 50);
			} 
		}
		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			transitionbutton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "SlideOnTop") {
				sideMenuController.Transition = SFNavigationDrawerTransition.SFNavigationDrawerTransitionSlideOnTop;
			} else if (selectedType == "Reveal") {
				sideMenuController.Transition = SFNavigationDrawerTransition.SFNavigationDrawerTransitionReveal;
			}
			else{
				sideMenuController.Transition = SFNavigationDrawerTransition.SFNavigationDrawerTransitionPush;
			}
		}
	}
}
