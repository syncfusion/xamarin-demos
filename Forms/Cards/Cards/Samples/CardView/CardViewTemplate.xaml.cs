#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.Cards
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardViewTemplate : StackLayout
	{
		public CardViewTemplate ()
		{
			InitializeComponent ();

            if (Device.RuntimePlatform == Device.iOS
                || Device.RuntimePlatform == Device.UWP)
            {
                cardView.BorderWidth = 0.5;
                cardView.BorderColor = Color.DarkGray;
            }

            if(Device.RuntimePlatform == Device.iOS)
            {
                label.Text = "*";
            }
		}

        private void OnCardViewDismissed(object sender, Syncfusion.XForms.Cards.DismissedEventArgs e)
        {
            (cardView.BindingContext as CardViewModel).IsCardAlreadySwiped = true;
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