#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "TicketInfoRepository.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Xamarin.Forms;

    /// <summary>
    /// A class used to assign collection values for a Model properties
    /// </summary>
    public class TicketInfoRepository
    {
        #region GetTicketDetails

        /// <summary>
        /// Used to get added ItemsSource details
        /// </summary>
        /// <returns>returns added ticketDetails</returns>
        public ObservableCollection<TicketBookingInfo> GetDetails()
        {
            var ticketDetails = new ObservableCollection<TicketBookingInfo>();
            return this.PopulateList(ticketDetails);
        }

        #endregion

        /// <summary>
        ///  Used to add ItemsSource details
        /// </summary>
        /// <param name="items">observable collection type parameter named as items</param>
        /// <returns>returns the added items</returns>
        private ObservableCollection<TicketBookingInfo> PopulateList(ObservableCollection<TicketBookingInfo> items)
        {
            items = new ObservableCollection<TicketBookingInfo>();
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movie1.jpg",
                TheaterName = "ABC Cinemas Dolby Atmos",
                TheaterLocation = "No.15, 12th Main Road, Sector 1",
                Timing1 = "10:00 AM",
                Timing2 = "4:00 PM",
                MovieName = "AB-Team",
                Cast = "Dirk Benedict | Liam Neeson"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movie2.jpg",
                TheaterName = "XYZ Theater 4K Dolby Atmos",
                TheaterLocation = "No.275, 3rd Cross Road, Area 27",
                Timing1 = "11:00 AM",
                Timing2 = "6:00 PM",
                MovieName = "Configuring 2",
                Cast = "Vera Farmiga | Patrick Wilson"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movie3.jpg",
                TheaterName = "QWERTY Theater",
                TheaterLocation = "No.275, 3rd Cross Road, Sector North",
                Timing1 = "10:30 AM",
                MovieName = "Inside 2",
                Cast = "Patrick Wilson | Rose Byrne"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movie4.jpg",
                TheaterName = "FYI Cinemas 4K",
                TheaterLocation = "No.15, 12th Main Road, Sector South",
                Timing1 = "3:00 PM",
                MovieName = "Safest House",
                Cast = "Reyan Reynolds | Denzel Washington"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movie5.jpg",
                TheaterName = "The Cinemas Dolby Digital",
                TheaterLocation = "No.275, 3rd Cross Road, Layout 71",
                Timing1 = "2:30 PM",
                Timing2 = "9:00 PM",
                MovieName = "Run All Day",
                Cast = "Liam Neeson | Genesis Rodriguez"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movie6.jpg",
                TheaterName = "SF Theater Dolby Atmos RDX",
                TheaterLocation = "North West Layout",
                Timing1 = "1:30 PM",
                Timing2 = "6:00 PM",
                MovieName = "Code Red",
                Cast = "Jake Gyllenhaal | Michelle Monaghan"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movies7.jpg",
                TheaterName = "PVS Cinemas 4K Dolby Atmos",
                TheaterLocation = "No.15, 12th Main Road, Area 33",
                Timing1 = "3:30 PM",
                MovieName = "Clash Of The Queens",
                Cast = "Gemma Arteron | Sam Worthington"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movies8.jpg",
                TheaterName = "Grand Theater",
                TheaterLocation = "No.275, 3rd Cross Road, South Sector",
                Timing1 = "6:00 PM",
                MovieName = "A Run Among The TombStones",
                Cast = "Liam Neeson | Dan Stevens"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movies9.jpg",
                TheaterName = "Orion Cinemas Dolby Atmos RDX",
                TheaterLocation = "No.15, 12th Main Road, Area 152",
                Timing1 = "6:00 PM",
                Timing2 = "10:30 PM",
                MovieName = "Unkown Source",
                Cast = "Liam Neeson | Diane Kruger"
            });
            items.Add(new TicketBookingInfo
            {
                MovieImage = "Popup_Movies10.jpg",
                TheaterName = "Elite Cinemas Dolby Atmos RDX",
                TheaterLocation = "No.275, 3rd Cross Road, Sector 77",
                Timing1 = "2:30 PM",
                Timing2 = "6:30 PM",
                MovieName = "AB-Team",
                Cast = "Dirk Benedict | Liam Neeson"
            });
            return items;
        }
    }
}