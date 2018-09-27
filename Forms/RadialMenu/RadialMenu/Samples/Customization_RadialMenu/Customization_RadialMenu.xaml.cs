#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Xamarin.Forms;
using System.Globalization;

namespace SampleBrowser.SfRadialMenu
{
    public partial class Customization_RadialMenu : SampleView
    {
        Rotator_ViewModel rotator_ViewModel;
        public Customization_RadialMenu()
        {
            InitializeComponent();
            //teamUSARadialMenu.Point = new Point(0, 0);
            rotator_ViewModel = new Rotator_ViewModel();
            sfRotator.BindingContext = rotator_ViewModel;
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), TimerElapsed);

            if(Device.RuntimePlatform == Device.iOS)
            {
                rowHeight.Height = 240;
            }
          
        }

        #region Event Handler
        void Handle_ItemTapped(object sender, Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs e)
        {
            Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem item1 = sender as Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem;
            rotator_ViewModel.RotatorCollection[sfRotator.SelectedIndex].TeamColor = item1.BackgroundColor;
            teamUSARadialMenu.Close();
        }

        #endregion

        private bool TimerElapsed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                teamUSARadialMenu.Show();
            });
            return false;
        }

        public override void OnDisappearing()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                teamUSARadialMenu.Dispose();
            }
            base.OnDisappearing();
        }
    }
    public class CustomizationFontConversion : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (parameter != null && parameter is string)
                    return "radialmenu_RadialMenu.ttf#" + parameter.ToString();
                else
                    return "radialmenu_RadialMenu.ttf";
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                
                    return "RadialMenu";
                
            }
            else
            {
#if COMMONSB
                return "radialmenu_RadialMenu.ttf#RadialMenu";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return "radialmenu_RadialMenu.ttf#RadialMenu";
                }
                else
                {
                    return "SampleBrowser.SfRadialMenu.UWP\\radialmenu_RadialMenu.ttf#RadialMenu";
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
