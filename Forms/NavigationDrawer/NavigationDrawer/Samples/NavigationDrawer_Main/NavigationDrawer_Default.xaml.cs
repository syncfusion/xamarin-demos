#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.ListView.XForms;
using Syncfusion.SfNavigationDrawer.XForms;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfNavigationDrawer
{
    public partial class NavigationDrawer_Default : SampleView
    {
		ObservableCollection<Message> messageContent = new ObservableCollection<Message>();
		MenuCollectionViewModel vm;
        public NavigationDrawer_Default()
        {
            InitializeComponent();

			vm = new MenuCollectionViewModel();
			navigationDrawer.ContentView = new Archive_Default(vm.MenuCollection[0].MessageContent, "Inbox");

			navigationDrawer.ContentView.BackgroundColor = Color.White;

			this.listView.ItemsSource = vm.MenuCollection;

			for (int i = 0; i < 7; i++)
			{
				messageContent.Add(vm.MenuCollection[0].MessageContent[i]);
			}

			this.listView1.ItemsSource = messageContent;
			if (Device.RuntimePlatform == Device.iOS)
			{
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    apiNameLabel.FontSize = 12;
                    defaultDrawerLabel.FontSize = 12;
                    secondaryDrawerLabel.FontSize = 12;
                    transitionLabel.FontSize = 12;
                    positionLabel.FontSize = 12;
                    defaultTransitionPicker.WidthRequest = 101;
                    transitionPicker.WidthRequest = 101;
                    defaultPositionPicker.WidthRequest = 101;
                    positionPicker.WidthRequest = 101;
                }
				navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth);
				navigationDrawer.DrawerHeight = (float)(Core.SampleBrowser.ScreenHeight);
				navigationDrawer.DrawerHeaderHeight = 150;
			}
			else
            {
				secondaryDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
				defaultDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
			}
            if (Device.Idiom == TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP || (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)))
			{
				userImage.VerticalOptions = LayoutOptions.Center;
				navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
				navigationDrawer.Margin = new Thickness(-2, 0, -2, 0);
			}
            //navigationDrawer.DrawerHeight = (float)(Core.SampleBrowser.ScreenHeight * 0.6);
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
			if (Device.RuntimePlatform == Device.iOS)
				navigationDrawer.IsOpen = false;
			else
				navigationDrawer.ToggleDrawer();
           
		}

		void Handle_ItemTapped1(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
			var tempListView = sender as Syncfusion.ListView.XForms.SfListView;
			for (int i = 0; i < 8; i++)
			{
				var tempItem = (listView1.ItemsSource as ObservableCollection<MenuCollectionModel>)[i];
				if ((e.ItemData as MenuCollectionModel) != tempItem)
				{
					tempItem.FontColor = Color.FromHex("#8e8e92");
				}
			}

			var temp = e.ItemData as MenuCollectionModel;
			temp.FontColor = Color.FromHex("#007ad0");
			navigationDrawer.ContentView = new Archive_Default(temp.MessageContent, (e.ItemData as MenuCollectionModel).MenuItem).Content;
			if (Device.RuntimePlatform == Device.iOS)
				navigationDrawer.IsOpen = false;
			else
                navigationDrawer.ToggleSecondaryDrawer();
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
