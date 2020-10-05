#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfRotator.XForms;
using SampleBrowser.Core;

namespace SampleBrowser.SfRotator
{
	public partial class Rotator_Default : SampleView
	{
        void Handle_ClickedAdd(object sender, System.EventArgs e)
        {
			totalCart++;
			TotalCart.Text = "(" + totalCart.ToString() + ")";
        }

        int totalCart = 0;
        void Handle_ClickedBuy(object sender, System.EventArgs e)
        {


            //App.Current.MainPage.DisplayAlert("Order Details", "Order has been placed successfully", "OK");
        }

        void Handle_Clicked(object sender, System.EventArgs e)
		{
            mButton.BackgroundColor = sButton.BackgroundColor = xButton.BackgroundColor = xLButton.BackgroundColor = Color.White;
			mButton.TextColor = sButton.TextColor = xButton.TextColor = xLButton.TextColor = Color.Black;
            (sender as Button).BackgroundColor = Color.FromHex("#f1852a");
            (sender as Button).TextColor = Color.White;
		}

		double width;

		public Rotator_Default()
		{
			InitializeComponent();
			width = Core.SampleBrowser.ScreenWidth;
			sfRotator.BindingContext = new RotatorViewModel();
			SettingsWindow();
			sfRotator.SelectedIndex = 1;
            ratingImage.Margin = new Thickness(10, 0, 2, 0);

            if (Device.RuntimePlatform == Device.UWP)
			{
                List<SfRotatorItem> rotatoritems = new List<SfRotatorItem>();
                rotatoritems.Add(new SfRotatorItem() { Image = ImagePathConverter.GetImageSource("SampleBrowser.SfRotator.Duck0.png") });
                rotatoritems.Add(new SfRotatorItem() { Image = ImagePathConverter.GetImageSource("SampleBrowser.SfRotator.Duck1.png") });
                rotatoritems.Add(new SfRotatorItem() { Image = ImagePathConverter.GetImageSource("SampleBrowser.SfRotator.Duck2.png") });
                rotatoritems.Add(new SfRotatorItem() { Image = ImagePathConverter.GetImageSource("SampleBrowser.SfRotator.Duck3.png") });
                rotatoritems.Add(new SfRotatorItem() { Image = ImagePathConverter.GetImageSource("SampleBrowser.SfRotator.Duck4.png") });
                rotatoritems.Add(new SfRotatorItem() { Image = ImagePathConverter.GetImageSource("SampleBrowser.SfRotator.Duck5.png") });
                sfRotator.ItemsSource = null;
                sfRotator.ItemTemplate = null;
                sfRotator.ItemsSource = rotatoritems;
                mButton.FontSize = 22;
                xLButton.FontSize = 22;
                sButton.FontSize = 22;
                xButton.FontSize = 22;
                
                if (Device.Idiom != TargetIdiom.Phone)
				{
                    maingrid.HorizontalOptions = LayoutOptions.Center;
					grid.HorizontalOptions = LayoutOptions.Start;
					grid.Margin = new Thickness(10);
                    header.HorizontalOptions = LayoutOptions.Start;
                    header.Margin = new Thickness(10,0,10,0);
                    header.WidthRequest = 550;
					grid.WidthRequest = 550;
                    controlsize.Height = 315;
                    sfRotator.HeightRequest = 250;
                }
				else
				{
                    controlsize.Height = 270;
                    sfRotator.HeightRequest = 270;
                    sfRotator.WidthRequest = 260;
				}
			}
            else if(Device.RuntimePlatform == Device.Android)
            {
                root.HorizontalOptions = LayoutOptions.Center;
            }
			if (Device.RuntimePlatform == Device.iOS)
				sfRotator.NavigationStripPosition = NavigationStripPosition.Bottom;
            sfRotator.HeightRequest = sfRotator.WidthRequest;

            mButton.BackgroundColor = sButton.BackgroundColor = xButton.BackgroundColor = xLButton.BackgroundColor = Color.White;
            mButton.TextColor = sButton.TextColor = xButton.TextColor = xLButton.TextColor = Color.Black;

		}

		private void SettingsWindow()
		{
            directionPicker.Items.Add("BottomToTop");
            directionPicker.Items.Add("Horizontal"); 
			directionPicker.Items.Add("LeftToRight");
			directionPicker.Items.Add("RightToLeft");
			directionPicker.Items.Add("TopToBottom");
            directionPicker.Items.Add("Vertical");

            directionPicker.SelectedIndex = 1;

			directionPicker.SelectedIndexChanged += picker1_SelectedIndexChanged;
			tabPicker.Items.Add("Bottom");
			tabPicker.Items.Add("Top");
			tabPicker.Items.Add("Left");
			tabPicker.Items.Add("Right");
			tabPicker.SelectedIndex = 3;

			modePicker.Items.Add("Dots");
			modePicker.Items.Add("Thumbnail");
			modePicker.SelectedIndex = 1;

			tabPicker.SelectedIndexChanged += picker2_SelectedIndexChanged;

			modePicker.SelectedIndexChanged += picker3_SelectedIndexChanged;
			toggleButton.Toggled += toggleStateChanged;


			if (Device.RuntimePlatform == Device.Android)
			{
				mButton.FontSize = 15;
				sButton.FontSize = 15;
				xButton.FontSize = 15;
				xLButton.FontSize = 15;
			}
			else if (Device.RuntimePlatform == Device.iOS)
			{
				sfRotator.WidthRequest = width;
               // sfRotator.HeightRequest = App.ScreenWidth;
				emptyLabel.WidthRequest = 200;

			}
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
			{
				emptyLabel.WidthRequest = 150;
				directionPicker.HeightRequest = 90;
				tabPicker.HeightRequest = 90;
				directionLabel.Text = "  " + "Tick Placement";
				directionLabel.HeightRequest = 22;
				tabLabel.Text = "  " + "Label Placement";
				tabLabel.HeightRequest = 22;
				modeLabel.Text = "  " + "Label Placement";
				modeLabel.HeightRequest = 22;
				emptyLabel.Text = "  " + "Label";
				emptyLabel.HeightRequest = 22;

			}
		}

        void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (directionPicker.SelectedIndex)
            {
                case 0:
                    {
                        sfRotator.NavigationDirection = NavigationDirection.BottomToTop;
                        break;
                    }
                case 1:
                    {
                        sfRotator.NavigationDirection = NavigationDirection.Horizontal;
                        break;
                    }
                case 2:
                    {
                        sfRotator.NavigationDirection = NavigationDirection.LeftToRight;
                        break;
                    }
                case 3:
                    {
                        sfRotator.NavigationDirection = NavigationDirection.RightToLeft;
                        break;
                    }
                case 4:
                    {
                        sfRotator.NavigationDirection = NavigationDirection.TopToBottom;
                        break;
                    }
                case 5:
                    {
                        sfRotator.NavigationDirection = NavigationDirection.Vertical;
                        break;
                    }
            }
        }

		void picker2_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabPicker.SelectedIndex)
			{
				case 0:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Bottom;
						break;
					}
				case 1:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Top;
						break;
					}
				case 2:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Left;
						break;
					}
				case 3:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Right;
						break;
					}
			}
		}
		void picker3_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (modePicker.SelectedIndex)
			{
				case 0:
					{
						sfRotator.NavigationStripMode = NavigationStripMode.Dots;
						break;
					}
				case 1:
					{
						sfRotator.NavigationStripMode = NavigationStripMode.Thumbnail;
						break;
					}

			}
		}
		void toggleStateChanged(object sender, ToggledEventArgs e)
		{
			sfRotator.EnableAutoPlay = e.Value;
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
