#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SampleBrowser.Core;
using System.Globalization;

namespace SampleBrowser.SfRadialMenu
{
	public partial class SlotIndex_RadialMenu : SampleView
	{
		double height, width;
		double height1, width1;
		public SlotIndex_RadialMenu()
		{
			InitializeComponent();

			if (Device.RuntimePlatform == Device.Android)
			{
				height = Core.SampleBrowser.ScreenHeight / 5.1;
				width = Core.SampleBrowser.ScreenWidth / 2 - radial_Menu.CenterButtonRadius * 1.5;
			}
			else if (Device.RuntimePlatform == Device.iOS)
			{
				height = Core.SampleBrowser.ScreenHeight / 6 + radial_Menu.CenterButtonRadius;
				width = Core.SampleBrowser.ScreenWidth / 2 - radial_Menu.CenterButtonRadius * 2;
			}
			//else if (Device.RuntimePlatform == Device.Windows)
			//{
			//    height = App.ScreenHeight / 5.1;
			//    width = App.ScreenWidth / 2 - radial_Menu.CenterButtonRadius * 1.5;
			//    facebook.Margin = new Thickness(0, 3, 0, 0);
			//    twitter.Margin = new Thickness(0, 3, 0, 0);
			//    google.Margin = new Thickness(0, 3, 0, 0);
			//    if (Device.Idiom == TargetIdiom.Phone)
			//    {
			//        radial_Menu.RimRadius = 130.0;
			//    }
			//}

			TapGestureRecognizer facebook_Tap = new TapGestureRecognizer();
			facebook_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your Facebook account?", null, "OK");

			};
			facebook.GestureRecognizers.Add(facebook_Tap);
			TapGestureRecognizer google_Tap = new TapGestureRecognizer();
			google_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your Google Plus account?", null, "OK");

			};
			google.GestureRecognizers.Add(google_Tap);

			TapGestureRecognizer twitter_Tap = new TapGestureRecognizer();
			twitter_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your Twitter account?", null, "OK");

			};
			twitter.GestureRecognizers.Add(twitter_Tap);

			TapGestureRecognizer linkedIn_Tap = new TapGestureRecognizer();
			linkedIn_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your LinkedIn account?", null, "OK");

			};
			linkedIn.GestureRecognizers.Add(linkedIn_Tap);
			this.SizeChanged += SlotIndex_RadialMenu_SizeChanged;
		}

		private void SlotIndex_RadialMenu_SizeChanged(object sender, EventArgs e)
		{
			if (this.Height < this.Width)
			{
				syncfusionText.Text = "Syncfusion is the enterprise technology partner of choice for software development, delivering a broad range of web, mobile, and desktop controls coupled with a service-oriented approach throughout the entire application lifecycle.";
			}
			else
			{
				syncfusionText.Text = "Syncfusion is the enterprise technology partner of choice for software development, delivering a broad range of web, mobile, and desktop controls coupled with a service-oriented approach throughout the entire application lifecycle. Syncfusion has established itself as the trusted partner worldwide for use in mission-critical applications. Founded in 2001 and headquartered in Research Triangle Park, N.C., Syncfusion has more than 12,000 customers, including large financial institutions, Fortune 100 companies, and global IT consultancies.";
			}
			if (Device.RuntimePlatform == Device.Android)
			{
				height1 = this.Height / 2.55;
				width1 = this.Width / 2 - radial_Menu.CenterButtonRadius * 1.5;
			}
			else if (Device.RuntimePlatform == Device.iOS)
			{
				height1 = this.Height / 3 + radial_Menu.CenterButtonRadius;
				width1 = this.Width / 2 - radial_Menu.CenterButtonRadius * 2;
			}
			else if (Device.RuntimePlatform == Device.UWP)
			{
				height1 = this.Height / 2.55;
				width1 = this.Width / 2 - radial_Menu.CenterButtonRadius * 1.5;
				facebook.Margin = new Thickness(0, 3, 0, 0);
				twitter.Margin = new Thickness(0, 3, 0, 0);
				google.Margin = new Thickness(0, 3, 0, 0);
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    radial_Menu.RimRadius = 180.0;
                }
                if (Device.Idiom == TargetIdiom.Phone)
				{
					radial_Menu.RimRadius = 150.0;
				}
			}
			radial_Menu.Point = new Point(width1, height1);
		}

		public override void OnDisappearing()
		{
			if (Device.RuntimePlatform == Device.UWP)
			{
				radial_Menu.Dispose();
			}
			base.OnDisappearing();
		}
	}
	public class SlotIndexFontConversion : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (Device.RuntimePlatform == Device.Android)
			{
				if (parameter != null && parameter is string)
					return "radialmenu_socialicons.ttf#" + parameter.ToString();
				else
					return "radialmenu_socialicons.ttf";
			}
			else if (Device.RuntimePlatform == Device.iOS)
			{

				return "Social";

			}
			else
			{
#if COMMONSB
                return "radialmenu_socialicons.ttf#Social_Icons";
#else
                if (Core.SampleBrowser.IsIndividualSB)
				{
					return "radialmenu_socialicons.ttf#Social_Icons";
				}
				else
				{
					return "SampleBrowser.SfRadialMenu.UWP\\radialmenu_socialicons.ttf#Social_Icons";
				}
#endif
            }
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

}