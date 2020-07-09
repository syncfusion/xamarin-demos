#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using Syncfusion.SfNavigationDrawer.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfNavigationDrawer
{
    public partial class NavigationDrawer_Tablet : SampleView
    {
		ObservableCollection<Message> messageContent = new ObservableCollection<Message>();
		MenuCollectionViewModel vm;

		public NavigationDrawer_Tablet()
        {
            InitializeComponent();
			vm = new MenuCollectionViewModel();
			navigationDrawer.ContentView = new Archive_Default(vm.MenuCollection[0].MessageContent, "Inbox");
			navigationDrawer.ContentView.BackgroundColor = Color.White;
			if (Device.RuntimePlatform == Device.Android)
				navigationDrawer.TouchThreshold = 10;
			else
				navigationDrawer.TouchThreshold = 100;
			this.listView.ItemsSource = vm.MenuCollection;

			for (int i = 0; i < 7; i++)
			{
				messageContent.Add(vm.MenuCollection[0].MessageContent[i]);
			}

			this.listView1.ItemsSource = messageContent;
			if (Device.RuntimePlatform == Device.iOS)
			{
                navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 1.1);
                navigationDrawer.DrawerHeaderHeight = 150;
			}
			else
			{
                if ((float)(Core.SampleBrowser.ScreenWidth) > 0)
                {
                    secondaryDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
                    defaultDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
                }
			}
            if (Device.RuntimePlatform == Device.UWP || (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone))
            {
                secondaryDrawer.DrawerWidth = 400;
                defaultDrawer.DrawerWidth = 400;
            }
            if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Tablet)
			{
				userImage.HorizontalOptions = LayoutOptions.Center;
				userNameLabel.HorizontalOptions = LayoutOptions.Center;
				userImage.Margin = new Thickness(7, 14, 0, 0);
				drawerContentViewGrid.Padding = new Thickness(13, 1, 0.5, 1);
				secondaryDrawer.DrawerHeaderHeight = 60;
				notificationText.HeightRequest = 60;
				notificationText.Margin = new Thickness(10, 20, 0, 0);
			}
			if (Device.RuntimePlatform == Device.Android && Device.Idiom == TargetIdiom.Tablet)
			{
				userImage.HorizontalOptions = LayoutOptions.Center;
				userNameLabel.HorizontalOptions = LayoutOptions.Center;
			}
            else if ((Device.RuntimePlatform != Device.iOS))
            {
                navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
				navigationDrawer.DrawerHeaderHeight = 150;
			}
            if (Device.Idiom == TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP || (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)))
			{

				userImage.VerticalOptions = LayoutOptions.Center;
				navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
			}
            if ((Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)  || Device.RuntimePlatform == Device.UWP)
			{
				if (Device.Idiom == TargetIdiom.Desktop)
				{
					navigationDrawer.DrawerWidth = 400;
					userImage.VerticalOptions = LayoutOptions.Center;
				}
			}
			navigationDrawer.DrawerHeight = (float)Core.SampleBrowser.ScreenHeight;
			navigationDrawer.DrawerFooterHeight = 0;
			navigationDrawer.Duration = 400;
			navigationDrawer.Position = Position.Left;
			navigationDrawer.Transition = Syncfusion.SfNavigationDrawer.XForms.Transition.SlideOnTop;
			this.Padding = new Thickness(-5);
			loadPropertyView();
		}

		void Handle_QueryItemSize(object sender, Syncfusion.ListView.XForms.QueryItemSizeEventArgs e)
		{
			if (e.ItemIndex == 0 || e.ItemIndex == 3)
			{
				e.ItemSize = 105;
				e.Handled = true;
			}
		}

		void Handle_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
			var tempListView = sender as Syncfusion.ListView.XForms.SfListView;
			for (int i = 0; i < 8; i++)
			{
				var tempItem = (listView.ItemsSource as ObservableCollection<MenuCollectionModel>)[i];
				if ((e.ItemData as MenuCollectionModel) != tempItem)
				{
					tempItem.FontColor = Color.FromHex("#8e8e92");
				}
			}

			var temp = e.ItemData as MenuCollectionModel;
			temp.FontColor = Color.FromHex("#007ad0");
			navigationDrawer.ContentView = new Archive_Default(temp.MessageContent, (e.ItemData as MenuCollectionModel).MenuItem).Content;
			if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
				navigationDrawer.IsOpen = false;
			else
				navigationDrawer.ToggleDrawer();
		}

		void loadPropertyView()
		{
			optionLayout.Padding = new Thickness(0, 0, 10, 0);
			transitionPicker.Items.Add("SlideOnTop");
			transitionPicker.Items.Add("Push");
			transitionPicker.Items.Add("Reveal");
			transitionPicker.SelectedIndex = 0;
			transitionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			{
				switch (transitionPicker.SelectedIndex)
				{
					case 0:
						{
							navigationDrawer.SecondaryDrawerSettings.Transition = Transition.SlideOnTop;
						}
						break;
					case 1:
						{
							navigationDrawer.SecondaryDrawerSettings.Transition = Transition.Push;
						}
						break;
					case 2:
						{
							navigationDrawer.SecondaryDrawerSettings.Transition = Transition.Reveal;
						}
						break;
				}
			};

			defaultTransitionPicker.Items.Add("SlideOnTop");
			defaultTransitionPicker.Items.Add("Push");
			defaultTransitionPicker.Items.Add("Reveal");
			defaultTransitionPicker.SelectedIndex = 0;
			defaultTransitionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			{
				switch (defaultTransitionPicker.SelectedIndex)
				{
					case 0:
						{
							navigationDrawer.DefaultDrawerSettings.Transition = Transition.SlideOnTop;
						}
						break;
					case 1:
						{
							navigationDrawer.DefaultDrawerSettings.Transition = Transition.Push;
						}
						break;
					case 2:
						{
							navigationDrawer.DefaultDrawerSettings.Transition = Transition.Reveal;
						}
						break;
				}
			};

			positionPicker.Items.Add("Left");
			positionPicker.Items.Add("Right");
			positionPicker.Items.Add("Top");
			positionPicker.Items.Add("Bottom");
			positionPicker.SelectedIndex = 1;
			positionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			{
				switch (positionPicker.SelectedIndex)
				{
					case 0:
						{
							navigationDrawer.SecondaryDrawerSettings.Position = Position.Left;
						}
						break;
					case 1:
						{
							navigationDrawer.SecondaryDrawerSettings.Position = Position.Right;
						}
						break;
					case 2:
						{
							navigationDrawer.SecondaryDrawerSettings.Position = Position.Top;
						}
						break;
					case 3:
						{
							navigationDrawer.SecondaryDrawerSettings.Position = Position.Bottom;
						}
						break;
				}
			};


			defaultPositionPicker.Items.Add("Left");
			defaultPositionPicker.Items.Add("Right");
			defaultPositionPicker.Items.Add("Top");
			defaultPositionPicker.Items.Add("Bottom");
			defaultPositionPicker.SelectedIndex = 0;
			defaultPositionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			{
				switch (defaultPositionPicker.SelectedIndex)
				{
					case 0:
						{
							navigationDrawer.DefaultDrawerSettings.Position = Position.Left;
						}
						break;
					case 1:
						{
							navigationDrawer.DefaultDrawerSettings.Position = Position.Right;
						}
						break;
					case 2:
						{
							navigationDrawer.DefaultDrawerSettings.Position = Position.Top;
						}
						break;
					case 3:
						{
							navigationDrawer.DefaultDrawerSettings.Position = Position.Bottom;
						}
						break;
				}
			};
		}
		public View getContent()
		{
			return this.Content;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}
	}
}

