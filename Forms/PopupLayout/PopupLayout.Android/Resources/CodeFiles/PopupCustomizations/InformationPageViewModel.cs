#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    internal class InformationPageViewModel 
    {
        public ImageSource TicketImageSource { get; set; }

        public ImageSource ParkingImageSource { get; set; }

        public ImageSource FoodCourtImageSource { get; set; }

        public InformationPageViewModel()
        {
#if COMMONSB
            TicketImageSource = ImageSource.FromResource("SampleBrowser.Images.Popup_MTicket.png", typeof(InformationPageViewModel).GetTypeInfo().Assembly);
            ParkingImageSource = ImageSource.FromResource("SampleBrowser.Images.Popup_Parking.png", typeof(InformationPageViewModel).GetTypeInfo().Assembly);
            FoodCourtImageSource = ImageSource.FromResource("SampleBrowser.Images.Popup_FoodCourt.png", typeof(InformationPageViewModel).GetTypeInfo().Assembly);
#else
            TicketImageSource = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.Popup_MTicket.png", typeof(InformationPageViewModel).GetTypeInfo().Assembly);
            ParkingImageSource = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.Popup_Parking.png", typeof(InformationPageViewModel).GetTypeInfo().Assembly);
            FoodCourtImageSource = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.Popup_FoodCourt.png", typeof(InformationPageViewModel).GetTypeInfo().Assembly);
#endif
        }
    }

}