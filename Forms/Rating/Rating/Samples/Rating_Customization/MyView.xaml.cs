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

namespace SampleBrowser.SfRating
{
	public partial class CustomRatingView : Grid
	{
		public CustomRatingView(string imageSource, string percentageText, string ratingText, Rating_Customization Parent)
		{
			InitializeComponent();
			image.Source = imageSource;
			percentageLabel.Text = percentageText;
			this.ratingText.Text = ratingText;
			Parent.RatingLabel.Add(percentageLabel);
			if (Device.RuntimePlatform == "UWP")
			{
				percentageLabel.FontSize = 10;
				percentageLabel.Margin = new Thickness(2);
                percentageLabel.BackgroundColor = Color.FromHex("#FF5500");
            }
			if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
            {
                percentageLabel.WidthRequest = 25;
            }

		}
	}
}
