#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.Cards
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardViewTemplate : SfCardView
	{
        private bool isPotrait = true;
        private double width;
		private Grid grid;
		private int childIndex;

        public CardViewTemplate ()
		{
			InitializeComponent ();

            if (Device.RuntimePlatform == Device.iOS
                || Device.RuntimePlatform == Device.UWP)
            {
                cardView.BorderWidth = 0.5;
                cardView.BorderColor = Color.DarkGray;
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                cardView.HorizontalOptions = LayoutOptions.Center;
                cardView.WidthRequest = 400;
            }

        }

        private void OnCardViewDismissed(object sender, Syncfusion.XForms.Cards.DismissedEventArgs e)
        {      
            (cardView.Parent.BindingContext as CardViewModel).IsCardAlreadySwiped = true;

             grid = cardView.Parent as Grid;

             childIndex = grid.Children.IndexOf(cardView);

            var animation = new Animation(a => grid.RowDefinitions[childIndex].Height = a, cardView.Height, 0);
			animation.Commit(this, "CardViewAnimation", 16, 200, Easing.Linear, (a, c) => Animate(),
			() => false) ; 

            if (Device.RuntimePlatform == Device.UWP)
            {
                Task.Delay(250);
                cardView.Opacity = 0;
            }
        }

        private void Animate()
		{
            if(Device.RuntimePlatform != Device.iOS)
			{
				grid.RowDefinitions[childIndex].Height = cardView.Height;
			}
			else
			{
				cardView.HeightRequest = 0;
			}
		}

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (isPotrait && widthConstraint != double.PositiveInfinity)
            {
                width = widthConstraint;
                isPotrait = false;
            }

            return base.OnMeasure(width, heightConstraint);
        }
    }

    public class FontConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                return "Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {

                return "Segoe MDL2 Assets";

            }
            else
            {
#if COMMONSB
                return "/Assets/Fonts/Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return "/Assets/Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
                }
                else
                {
                    return $"ms-appx:///SampleBrowser.Cards.UWP/Assets/Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
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