#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfRating.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfRating
{
	public partial class Rating_Tablet : SampleView
	{
		SfRatingSettings sfRatingSettings, sfsecondRatingSettings;
		int ratingItemCount;
		String ratingValue, ratingCount, ratingResult;


		public Rating_Tablet()
		{
			InitializeComponent();
            precisionPicker.Items.Add("Standard");
            precisionPicker.Items.Add("Half");
            precisionPicker.Items.Add("Exact");
            precisionPicker.SelectedIndex = 0;
            precisionPicker.SelectedIndexChanged += precisionPicker_SelectedIndexChanged;


			sfRatingSettings = new SfRatingSettings();
			sfRatingSettings.RatedFill = Color.FromHex("#fbd10a");
			sfRatingSettings.UnRatedFill = Color.White;
			sfRatingSettings.RatedStroke = Color.FromHex("#fbd10a");
			sfRatingSettings.RatedStrokeWidth = 1;
			sfRatingSettings.UnRatedStrokeWidth = 1;
			sfRating1.RatingSettings = sfRatingSettings;

			sfsecondRatingSettings = new SfRatingSettings();
			sfsecondRatingSettings.UnRatedFill = Color.White;
			sfsecondRatingSettings.RatedStrokeWidth = 1;
			sfsecondRatingSettings.UnRatedStrokeWidth = 1;
			sfRating2.RatingSettings = sfsecondRatingSettings;

			sfRating1.TooltipPlacement = TooltipPlacement.None;
			sfRating2.TooltipPlacement = TooltipPlacement.None;
			sfRating2.ValueChanged += ValueChanged;

		}

		void ValueChanged(object sender, ValueEventArgs e)
		{
			ratingValue = Convert.ToString(Math.Round(e.Value, 1));
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}

        public void toggleStateChanged(object e, ToggledEventArgs eve)
        {
            if (eve.Value)
            {
                sfRating2.TooltipPlacement = TooltipPlacement.TopLeft;
            }
            else
            {
                sfRating2.TooltipPlacement = TooltipPlacement.None;
            }
        }

		public View getContent()
		{
			return this.Content;
		}
        public View getPropertyContent()
        {
            return this.PropertyView;
        }

		

		public void precisionPicker_SelectedIndexChanged(object c, EventArgs e)
		{
			switch (precisionPicker.SelectedIndex)
			{
				case 0:
					{
						sfRating2.Precision = Precision.Standard;
                        sfRating2.TooltipPrecision = 0;
                        break;
					}
				case 1:
					{
						sfRating2.Precision = Precision.Half;
                        sfRating2.TooltipPrecision = 1;
                        break;
					}
				case 2:
					{
						sfRating2.Precision = Precision.Exact;
                        sfRating2.TooltipPrecision = 1;
                        break;
					}
			}
			ratingValue = Convert.ToString(sfRating2.Value);
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}


		public void itemCountEntry_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				sfRating2.ItemCount = int.Parse(e.NewTextValue);
			}
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);

			if (sfRating2.Value > ratingItemCount)
			{
				ratingValue = "0";
			}
			else
			{
				ratingValue = Convert.ToString(sfRating2.Value);
			}
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}
	}
}


