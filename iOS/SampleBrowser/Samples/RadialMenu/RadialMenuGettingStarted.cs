#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfRadialMenu.iOS;
using UIKit;
using System.Linq;
namespace SampleBrowser
{
	public class RadialMenuGettingStarted : SampleView
	{
		SfRadialMenu radialMenu;

		String[] layer = new string[] { "\uE701", "\uE702", "\uEA8F", "\uE706", "\uEBAA","\uE7E8"};
		String[] wifi = new string[] { "\uEC3B", "\uEC3A", "\uEC39", "\uEC38", "\uEC37" };
		String[] battery = new string[] { "\uEBB8","\uEBBC","\uEBC0" };
		String[] brightness = new string[] { "\uEC8A", "\uEC8A", "\uE706" };
		String[] profile = new string[] { "\uE7ED", "\uE877", "\uEA8F" };
		String[] power = new string[] { "\uE708", "\uE777", "\uE7E8" };
		UILabel eventLog;
		UISwitch enableRotation, isDragEnabled;
		UIView option = new UIView();
		UILabel rimSizeLabel, enableRotationLabel, isDragEnabledLabel;
		UISlider rimSizeSlider;
		UITableView table;
		string[] tableItems;
		public RadialMenuGettingStarted()
		{
			eventLog = new UILabel();
			eventLog.Lines = 0;
			eventLog.Text = "Event Log :";
			eventLog.BackgroundColor = UIColor.White;
			eventLog.LineBreakMode = UILineBreakMode.WordWrap;

			table = new UITableView(this.Bounds); // defaults to Plain style
			tableItems = new string[100];
			Add(eventLog);
			table.Source = new TableSourceCollection(tableItems);
			Add(table);

			radialMenu = new SfRadialMenu();
			CGRect apprect = UIScreen.MainScreen.Bounds;
			radialMenu.Position = new CGPoint(apprect.Width / 2, 100);
			radialMenu.RimColor = UIColor.FromRGB(230, 230, 230);
			radialMenu.CenterButtonRadius = 30;
			radialMenu.RimRadius = 80;
			radialMenu.CenterButtonText = "\uE713";
			radialMenu.CenterButtonBackText = "\uE72B";
			radialMenu.CenterButtonIconFont = UIFont.FromName("Segoe MDL2 Assets", 30);
			radialMenu.CenterButtonTextColor = UIColor.White;
			radialMenu.CenterButtonBorderColor = UIColor.White;
			radialMenu.CenterButtonBorderThickness = 4;
			radialMenu.OuterRimColor = UIColor.FromRGB(124, 201, 255);
			radialMenu.RimActiveColor = UIColor.FromRGB(0, 191, 255);
			radialMenu.CenterButtonBackgroundColor = UIColor.FromRGB(153, 153, 153);
			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				radialMenu.CenterButtonRadius = 50;
				radialMenu.RimRadius = 160;
				radialMenu.EnableCenterButtonAnimation = false;
				radialMenu.CenterButtonIconFont = UIFont.FromName("Segoe MDL2 Assets", 60);
			}
			radialMenu.Opening += RadialMenu_Opening;
			radialMenu.Closed += RadialMenu_Closed;
			radialMenu.CenterButtonTapped += RadialMenu_CenterButtonTapped;
			for (int i = 0; i < 6; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem() {IconFont = UIFont.FromName("Segoe MDL2 Assets",20), FontIcon=layer[i]};
				item.ItemTapped+= Item_ItemTapped;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					item.IconFont = UIFont.FromName("Segoe MDL2 Assets", 30);
				item.Tag = 100 + i;
				radialMenu.Items.Add(item);
			}
			for (int i = 0; i < 4; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem() { IconFont = UIFont.FromName("Segoe MDL2 Assets", 20), FontIcon = wifi[i] };
				item.ItemTapped += Item_ItemTapped1;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					item.IconFont = UIFont.FromName("Segoe MDL2 Assets", 30);
				radialMenu.Items[0].Items.Add(item);
			}
			for (int i = 0; i < 4; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem() { IconFont = UIFont.FromName("Segoe MDL2 Assets", 20), FontIcon = wifi[i] };
				item.ItemTapped += Item_ItemTapped2;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					item.IconFont = UIFont.FromName("Segoe MDL2 Assets", 30);
				radialMenu.Items[1].Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem() { IconFont = UIFont.FromName("Segoe MDL2 Assets", 20), FontIcon = profile[i] };
				item.ItemTapped += Item_ItemTapped3;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					item.IconFont = UIFont.FromName("Segoe MDL2 Assets", 30);
				radialMenu.Items[2].Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem() { IconFont = UIFont.FromName("Segoe MDL2 Assets", 20), FontIcon = brightness[i] };
				item.ItemTapped += Item_ItemTapped4;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					item.IconFont = UIFont.FromName("Segoe MDL2 Assets", 30);
				radialMenu.Items[3].Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem() { IconFont = UIFont.FromName("Segoe MDL2 Assets", 20), FontIcon = battery[i] };
				item.ItemTapped += Item_ItemTapped5;
				radialMenu.Items[4].Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem() { IconFont = UIFont.FromName("Segoe MDL2 Assets", 20), FontIcon = power[i] };
				item.ItemTapped += Item_ItemTapped6;
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					item.IconFont = UIFont.FromName("Segoe MDL2 Assets", 30);
				radialMenu.Items[5].Items.Add(item);
			}
			this.Add(radialMenu);
			addOptionView();
			this.OptionView = option;
		}
		int i = 0;
		void RadialMenu_CenterButtonTapped(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "Menu button has been tapped";
			table.ReloadData();
			i++;
		}
		void RadialMenu_Closed(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "Menu has been closed";
			table.ReloadData();
			i++;
		}
		void RadialMenu_Opening(object sender, RadialMenuEventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "Menu has been opened";
			table.ReloadData();
			i++;
		}
		void Item_ItemTapped(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}
			if((sender as SfRadialMenuItem).Tag == 100)
				tableItems[i] = "Navigated to WIFI signals";
			else if((sender as SfRadialMenuItem).Tag == 101)
				tableItems[i]="Navigated to BlueTooth Signals";
			else if ((sender as SfRadialMenuItem).Tag == 102)
				tableItems[i] = "Navigated to Profile settings";
			else if ((sender as SfRadialMenuItem).Tag == 103)
				tableItems[i] = "Navigated to Brightness settings";
			else if ((sender as SfRadialMenuItem).Tag == 104)
				tableItems[i] = "Navigated to Battery saver options";
			else if ((sender as SfRadialMenuItem).Tag == 105)
				tableItems[i] = "Navigated to Power options";
			table.ReloadData();
			i++;
		}
		void Item_ItemTapped1(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "WIFI signal has been activated";
			table.ReloadData();
			i++;
		}
		void Item_ItemTapped2(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "BlueTooth signal has been activated";
			table.ReloadData();
			i++;
		}
		void Item_ItemTapped3(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "Profile settings has been changed";
			table.ReloadData();
			i++;
		}
		void Item_ItemTapped4(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "Device brightness has been changed";
			table.ReloadData();
			i++;
		}
		void Item_ItemTapped5(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "Battery Saver activated";
			table.ReloadData();
			i++;
		}
		void Item_ItemTapped6(object sender, EventArgs e)
		{
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}

			tableItems[i] = "Power options has been tapped";
			table.ReloadData();
			i++;
		}
		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				{
					eventLog.Frame = new CGRect(16, Frame.Height - 250, Frame.Width, 30);
					table.Frame = new CGRect(0,Frame.Height-220,Frame.Width-18,200);

					rimSizeLabel.Frame = new CGRect(10, 20, Frame.Width-20, 30);
					rimSizeSlider.Frame = new CGRect(10, 70, Frame.Width - 20, 30);
					enableRotationLabel.Frame = new CGRect(10, 120, Frame.Width - 20, 30);
					enableRotation.Frame = new CGRect(Frame.Width-60, 120, 50, 30);
					isDragEnabledLabel.Frame = new CGRect(10, 170, Frame.Width - 20, 30);
					isDragEnabled.Frame = new CGRect(Frame.Width - 60, 170, 50, 30);
				}
				else
				{
					radialMenu.Position = new CGPoint(Frame.Width / 2, Frame.Height/4);

					eventLog.Frame = new CGRect(16, Frame.Height/2, Frame.Width, 30);
					table.Frame = new CGRect(0, Frame.Height/2+30, Frame.Width - 18, Frame.Height/2-50);

					rimSizeLabel.Frame = new CGRect(10, 30, PopoverSize.Width - 20, 30);
					rimSizeSlider.Frame = new CGRect(10, 80, PopoverSize.Width - 20, 30);
					enableRotationLabel.Frame = new CGRect(10, 130, PopoverSize.Width - 20, 30);
					enableRotation.Frame = new CGRect(PopoverSize.Width - 60, 130, 50, 30);
					isDragEnabledLabel.Frame = new CGRect(10, 180, PopoverSize.Width - 20, 30);
					isDragEnabled.Frame = new CGRect(PopoverSize.Width - 60, 180, 50, 30);
				}
			}
			base.LayoutSubviews();
		}

		void addOptionView()
		{
			loadOptionView();
			this.option.AddSubview(rimSizeLabel);
			this.option.AddSubview(rimSizeSlider);
			this.option.AddSubview(enableRotationLabel);
			this.option.AddSubview(enableRotation);
			this.option.AddSubview(isDragEnabledLabel);
			this.option.AddSubview(isDragEnabled);
		}
		void loadOptionView()
		{
			//menuButtonSize
			rimSizeLabel = new UILabel();
			rimSizeLabel.Text = "Rim Radius";
			rimSizeLabel.TextColor = UIColor.Black;
			rimSizeLabel.TextAlignment = UITextAlignment.Left;

			rimSizeSlider = new UISlider();
			rimSizeSlider.MinValue = 80f;
			rimSizeSlider.MaxValue = 160f;
			rimSizeSlider.Value = 80f;
			rimSizeSlider.ValueChanged += (object sender, EventArgs e) =>
			 {
				radialMenu.RimRadius = rimSizeSlider.Value;
			 };

			//enableRotationLabel
			enableRotationLabel = new UILabel();
			enableRotationLabel.Text = "Rotation Enabled";
			enableRotationLabel.TextColor = UIColor.Black;
			enableRotationLabel.TextAlignment = UITextAlignment.Left;

			//enableRotation
			enableRotation = new UISwitch();
			enableRotation.On = true;
			enableRotation.ValueChanged += (sender, e) =>
			{
				if (((UISwitch)sender).On)
					radialMenu.EnableRotation = true;
				else
					radialMenu.EnableRotation = false;
			};

			//isDragEnabledLabel
			isDragEnabledLabel = new UILabel();
			isDragEnabledLabel.Text = "Drag Enabled";
			isDragEnabledLabel.TextColor = UIColor.Black;
			isDragEnabledLabel.TextAlignment = UITextAlignment.Left;

			//isDragEnabled
			isDragEnabled = new UISwitch();
			isDragEnabled.On = true;
			isDragEnabled.ValueChanged += (sender, e) =>
			{
				if (((UISwitch)sender).On)
					radialMenu.IsDragEnabled = true;
				else
					radialMenu.IsDragEnabled = false;
			};
		}
	}
}

