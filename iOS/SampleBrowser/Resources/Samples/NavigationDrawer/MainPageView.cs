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
	public class MainPageView : UIView
	{
		public UIView content;
		UIView background;
		UITableView maintable;
		public string[] tableItems;
		public string[] contentItems;
		UILabel headerContentLabel;
		UILabel textBlockLabel1;
		public MainPageView (CGRect bounds)
		{
			headerContentLabel = new UILabel ();
			this.BackgroundColor = UIColor.FromRGB(49,173,225);
			this.Frame = new CGRect (0, 0, bounds.Width, bounds.Height);
			content =new UIView(new CGRect(0,0,this.Frame.Width,this.Frame.Height));
			background=new UIView(new CGRect(0,50,this.Frame.Width,this.Frame.Height+72));
			background.BackgroundColor = UIColor.White;
			setvalue1 (0);
			this.Add(background);
			background.Add(content);

			headerContentLabel.Frame =new CGRect ((bounds.Width/2)-100, 10, 200, 30);
			headerContentLabel.Text="Home";
			headerContentLabel.TextColor = UIColor.White;
			headerContentLabel.TextAlignment = UITextAlignment.Center;
			this.AddSubview (headerContentLabel);
		}
		public MainPageView ()
		{


		}


		public void setvalue1(int index)
		{
			foreach(UIView sub in this.Subviews)
			{
				if(sub==content)
					sub.RemoveFromSuperview();
			}
			content.RemoveFromSuperview ();
			content =new UIView(new CGRect(0,0,this.Frame.Width,this.Frame.Height));
			if (index == 0) {
				headerContentLabel.Text = "Home";
				content.BackgroundColor = UIColor.White;

				textBlockLabel1 = new UILabel ();
				textBlockLabel1.Frame = new CGRect (15, 10, content.Frame.Width-20, 300);
				textBlockLabel1.Text = "Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus. Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet. Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula. Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.";
				textBlockLabel1.LineBreakMode = UILineBreakMode.WordWrap;
				textBlockLabel1.TextAlignment = UITextAlignment.Justified;
				textBlockLabel1.Lines = 0;
				textBlockLabel1.Font = UIFont.FromName ("Helvetica", 15f);
				content.AddSubview (textBlockLabel1);
			}
			else if (index == 1) {
				headerContentLabel.Text = "Profile";
				content.BackgroundColor = UIColor.White;
				UILabel usernameLabel = new UILabel ();
				usernameLabel.Frame =new CGRect ((this.Frame.Width/2), 20, 200, 30);
				usernameLabel.Text="James Pollock";
				usernameLabel.TextAlignment = UITextAlignment.Left;
				content.AddSubview (usernameLabel);
				UILabel userageLabel = new UILabel ();
				userageLabel.Frame =new CGRect ((this.Frame.Width/2), 45, 200, 30);
				userageLabel.Text="Age 30";
				userageLabel.Font = UIFont.FromName ("Helvetica", 18f);
				userageLabel.TextAlignment = UITextAlignment.Left;
				content.AddSubview (userageLabel);
				UILabel emptyLabel = new UILabel ();
				emptyLabel.Frame =new CGRect (10, 120, this.Frame.Width-20, 1);
				emptyLabel.BackgroundColor = UIColor.Gray;
				content.AddSubview (emptyLabel);
				UIImageView userImgLabel=new UIImageView();
				userImgLabel.Frame =new CGRect ((this.Frame.Width/2)-100, 10, 80, 80);
				userImgLabel.Image = new UIImage ("Images/User.png");

				content.Add (userImgLabel);
				UILabel commentLabel = new UILabel ();
				commentLabel.Frame =new CGRect (20, 130, this.Frame.Width-40, 200);
				commentLabel.Text="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout." +
					" The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters. \n\nWhen looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters." +
					"\n\n James Pollock";
				commentLabel.Font = UIFont.FromName ("Helvetica", 15f);
				commentLabel.LineBreakMode = UILineBreakMode.WordWrap;
				commentLabel.Lines = 0;
				content.AddSubview (commentLabel);

			}else if (index == 2) {
				headerContentLabel.Text = "Inbox";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) 
				{
					
					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" ,"Keven","Walton"};
					contentItems = new string[] 
					{"Hi John, See you at 7AM", "Hi Caster, See you at 9AM", "Hi Joey, See you at 11AM", "Hi Xavier, See you at 12PM", "Hi Gonzalez, See you at 1PM", "Hi Rodriguez, See you at 2PM",
						"Hi Ruben, See you at 4PM","Hi Keven, See you at 5PM","Hi Walton, See you at 7PM"

					};
				}
				else {
					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" };
					contentItems = new string[] {"Hi John, See you at 10AM", "Hi Caster, See you at 11AM", "Hi Joey, See you at 1PM", "Hi Xavier, See you at 2PM", "Hi Gonzalez, See you at 3PM", "Hi Rodriguez, See you at 4PM",
						"Hi Ruben, See you at 6PM"
					};
				}
				TableSource tablesource = new TableSource (tableItems, contentItems);
				tablesource.customise = true;
				maintable.Source = tablesource;
				content.Add (maintable);

			} else if (index == 3) {
				headerContentLabel.Text = "Outbox";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) 
				{

					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" ,"Keven","Walton"};
					contentItems = new string[] 
					{"Hi John, See you at 7AM", "Hi Caster, See you at 9AM", "Hi Joey, See you at 11AM", "Hi Xavier, See you at 12PM", "Hi Gonzalez, See you at 1PM", "Hi Rodriguez, See you at 2PM",
						"Hi Ruben, See you at 4PM","Hi Keven, See you at 5PM","Hi Walton, See you at 7PM"

					};
				}
				else {
					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" };
					contentItems = new string[] {"Hi John, See you at 10AM", "Hi Caster, See you at 11AM", "Hi Joey, See you at 1PM", "Hi Xavier, See you at 2PM", "Hi Gonzalez, See you at 3PM", "Hi Rodriguez, See you at 4PM",
						"Hi Ruben, See you at 6PM"
					};
				}
				TableSource tablesource = new TableSource (tableItems, contentItems);
				tablesource.customise = true;
				maintable.Source = tablesource;
				content.Add (maintable);
			}else if (index == 4) {
				headerContentLabel.Text = "Sent";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) 
				{

					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" ,"Keven","Walton"};
					contentItems = new string[] 
					{"Hi John, See you at 7AM", "Hi Caster, See you at 9AM", "Hi Joey, See you at 11AM", "Hi Xavier, See you at 12PM", "Hi Gonzalez, See you at 1PM", "Hi Rodriguez, See you at 2PM",
						"Hi Ruben, See you at 4PM","Hi Keven, See you at 5PM","Hi Walton, See you at 7PM"

					};
				}
				else {
					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" };
					contentItems = new string[] {"Hi John, See you at 10AM", "Hi Caster, See you at 11AM", "Hi Joey, See you at 1PM", "Hi Xavier, See you at 2PM", "Hi Gonzalez, See you at 3PM", "Hi Rodriguez, See you at 4PM",
						"Hi Ruben, See you at 6PM"
					};
				}
				TableSource tablesource = new TableSource (tableItems, contentItems);
				tablesource.customise = true;
				maintable.Source = tablesource;
				content.Add (maintable);
			}
			else if (index == 5) {
				headerContentLabel.Text = "Trash";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) 
				{

					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" ,"Keven","Walton"};
					contentItems = new string[] 
					{"Hi John, See you at 7AM", "Hi Caster, See you at 9AM", "Hi Joey, See you at 11AM", "Hi Xavier, See you at 12PM", "Hi Gonzalez, See you at 1PM", "Hi Rodriguez, See you at 2PM",
						"Hi Ruben, See you at 4PM","Hi Keven, See you at 5PM","Hi Walton, See you at 7PM"

					};
				}
				else {
					tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" };
					contentItems = new string[] {"Hi John, See you at 10AM", "Hi Caster, See you at 11AM", "Hi Joey, See you at 1PM", "Hi Xavier, See you at 2PM", "Hi Gonzalez, See you at 3PM", "Hi Rodriguez, See you at 4PM",
						"Hi Ruben, See you at 6PM"
					};
				}
				TableSource tablesource = new TableSource (tableItems, contentItems);
				tablesource.customise = true;
				maintable.Source = tablesource;
				content.Add (maintable);
			}
			background.Add(content);
		}
	}
}