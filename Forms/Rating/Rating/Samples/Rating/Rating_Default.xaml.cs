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
	public partial class Rating_Default : SampleView
	{
		SfRatingSettings sfRatingSettings, sfsecondRatingSettings;
		int ratingItemCount;
		String ratingValue, ratingCount, ratingResult;

		public Rating_Default()
		{
			InitializeComponent();

			//Rating Settings
			sfRatingSettings = new SfRatingSettings();
			sfRatingSettings.RatedFill = Color.FromHex("#fbd10a");
			sfRatingSettings.UnRatedFill = Color.White;
			sfRatingSettings.RatedStroke = Color.FromHex("#fbd10a");
			sfRatingSettings.RatedStrokeWidth = 1;
			sfRatingSettings.UnRatedStrokeWidth = 1;
			sfRating1.RatingSettings = sfRatingSettings;

			//Rating Settings
			sfsecondRatingSettings = new SfRatingSettings();
			sfsecondRatingSettings.UnRatedFill = Color.White;
			sfsecondRatingSettings.RatedStrokeWidth = 1;
			sfsecondRatingSettings.UnRatedStrokeWidth = 1;
			sfRating2.RatingSettings = sfsecondRatingSettings;
			Grid.SetColumn(movieImage, 0);
			Grid.SetColumn(descStack, 1);
			Grid.SetRow(title, 0);
			Grid.SetRow(mainGrid, 1);
			Grid.SetRow(bottomStack, 2);

			sfRating1.TooltipPlacement = TooltipPlacement.None;
			sfRating2.TooltipPlacement = TooltipPlacement.None;
			sfRating2.ValueChanged += ValueChanged;

            ratingValueLayout.Padding = new Thickness(0, 30, 0, 0);

            if (Device.RuntimePlatform == Device.Android)
			{
				sfRating2.ItemSize = 10;
                description.FontSize = 12;
			}
            if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                sfRating1.ItemSize = 10;
                sfRating2.ItemSize = 20;
                description.FontSize = 11;
                description.Text = "In 1973, French street performer Philippe Petit is trying to make a living in Paris with juggling acts and wire walking, much to the chagrin of his father.";
                ratingValueLayout.Padding = new Thickness(0, 10, 0, 0);
            }
			getRating();

			GetOptionPage();
		}

		void ValueChanged(object sender, ValueEventArgs e)
		{
			ratingValue = Convert.ToString(Math.Round(e.Value, 1));
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}

        private void GetOptionPage()
		{
			Grid.SetColumn(toolTipLabel, 0);
			Grid.SetColumn(toolTipPlacementOption, 1);
			Grid.SetColumn(itemCountLabel, 0);
			Grid.SetColumn(itemCount, 1);
			precisionPicker.Items.Add("Standard");
			precisionPicker.Items.Add("Half");
			precisionPicker.Items.Add("Exact");
			precisionPicker.SelectedIndex = 0;
			precisionPicker.SelectedIndexChanged += precisionPicker_SelectedIndexChanged;         
            itemCount.ValueChanged += (object sender,Syncfusion.SfNumericUpDown.XForms.ValueEventArgs  e) =>
			{
               
				Decimal temp = Convert.ToDecimal(e.Value);
				int count = (int)temp;
                sfRating2.ItemCount = count;

				ratingItemCount = sfRating2.ItemCount;
				ratingCount = Convert.ToString(ratingItemCount);

				if (sfRating2.Value > ratingItemCount)
				{
                    sfRating2.Value = 0;
					ratingValue = "0";
				}
				else
				{
					ratingValue = Convert.ToString(sfRating2.Value);
				}

				ratingResult = " " + ratingValue + "/" + ratingCount;
				showValue.Text = ratingResult;
			};
			toolTipPlacementOption.Toggled += toggleStateChanged;
			toolTipPlacementOption.IsToggled = false;
			toolTipPlacementOption.HorizontalOptions = LayoutOptions.End;

            if (Device.RuntimePlatform == Device.iOS)
			{
				column1.Width = 120;
				column2.Width = 180;
				description.FontSize = 12;
				toolTipPlacementOption.VerticalOptions = LayoutOptions.Start;
				itemCountLabel.VerticalOptions = LayoutOptions.Center;
				toolTipLabel.VerticalOptions = LayoutOptions.End;
				optionLayout.Spacing = 0;
				optionLayout.Padding = new Thickness(0, 0, 10, 0);
				Label dummyLabel = new Label();
				optionLayout.Children.Insert(3, dummyLabel);
			}
			
			else if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
				sampleLayout.Padding = new Thickness(10, 0, 10, 0);
				descStack.Padding = new Thickness(0, 0, 10, 0);
				optionLayout.Padding = new Thickness(10, 0, 10, 0);
			}

			if (Device.RuntimePlatform == "UWP" && (Device.Idiom == TargetIdiom.Phone))
			{
				precisionPicker.HeightRequest = 40;
			}
		}

		void precisionPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (precisionPicker.SelectedIndex)
			{
				case 0:
					{
						sfRating2.Precision = Precision.Standard;
                        ratingValue = Convert.ToString(Math.Round(sfRating2.Value));
                        sfRating2.TooltipPrecision = 0;
                        break;
					}
				case 1:
					{
						sfRating2.Precision = Precision.Half;
                        float ratingvalue = (float)sfRating2.Value;
                        if (Math.Round(sfRating2.Value) != sfRating2.Value)
                        {
                           if(Math.Round(sfRating2.Value)> sfRating2.Value)
                            {
                                ratingValue = Convert.ToString(Math.Round(sfRating2.Value)- 0.5);
                            }
                           else
                           {
                                ratingValue = Convert.ToString(Math.Round(sfRating2.Value) + 0.5);
                           }
                        }
                        else
                        {
                            ratingValue = Convert.ToString(Math.Round(sfRating2.Value));
                        }

                        sfRating2.TooltipPrecision = 1;
                        break;
					}
				case 2:
					{
						sfRating2.Precision = Precision.Exact;
                        sfRating2.TooltipPrecision = 1;
                        var decimalvalue = Math.Round(sfRating2.Value, 2);
                        ratingValue = Convert.ToString(decimalvalue);
                        break;
					}
			}
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}

		void toggleStateChanged(object sender, ToggledEventArgs e)
		{
			if (e.Value)
				sfRating2.TooltipPlacement = TooltipPlacement.TopLeft;
			else
				sfRating2.TooltipPlacement = TooltipPlacement.None;
		}

		void getRating()
		{
            if (Device.RuntimePlatform == Device.Android)
			{
				sfRating1.ItemSize = 17;
				sfRating2.ItemSize = 30;
				sfRating2.ItemSpacing = 5;
			}
            else if (Device.RuntimePlatform == Device.iOS)
			{
				movieImage.VerticalOptions = LayoutOptions.Start;
				movieImage.HeightRequest = 260;
				description.Text = "In 1973, French street performer Philippe Petit is trying to make a living in Paris with juggling acts and wire walking. He visits the dentist and, while in the waiting room, sees a picture in a magazine of the Twin Towers in New York City.\n";
				sfRating1.ItemSize = 15;
				sfRating2.ItemSize = 30;
				sfRating2.ItemSpacing = 10;
				sfRating2.ItemCount = 5;
				sfRating1.WidthRequest = sfRating1.ItemCount * sfRating1.ItemSize;
				sfRating1.HeightRequest = sfRating1.ItemSize;
				sfRating2.HeightRequest = sfRating2.ItemSize;
			}
			else if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
			{
               itemCount.HeightRequest = 40;
				if ((Device.Idiom != TargetIdiom.Tablet) && Device.Idiom != TargetIdiom.Desktop)
				{
					sfRating1.HeightRequest = 40;
					sfRating2.HeightRequest = 40;
					time.HorizontalOptions = LayoutOptions.Start;
					//description.HeightRequest = 80;
					description.VerticalOptions = LayoutOptions.FillAndExpand;
					description.LineBreakMode = LineBreakMode.WordWrap;
					precisionPicker.HeightRequest = 90;
				}
			}
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



