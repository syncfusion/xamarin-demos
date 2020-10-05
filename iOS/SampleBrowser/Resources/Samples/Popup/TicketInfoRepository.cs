#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using UIKit;

namespace SampleBrowser
{
	public class TicketInfoRepository
	{
		public TicketInfoRepository()
		{
		}

		#region GetTicketDetails

		public ObservableCollection<TicketBookingInfo> GetDetails()
		{
			ObservableCollection<TicketBookingInfo> ticketDetails = new ObservableCollection<TicketBookingInfo>();
			return PopulateList(ticketDetails);
		}
		#endregion


		private ObservableCollection<TicketBookingInfo> PopulateList(ObservableCollection<TicketBookingInfo> items)
		{

			items = new ObservableCollection<TicketBookingInfo>();

			items.Add(new TicketBookingInfo() { TheaterName = "ABC Cinemas Dolby Atmos", TheaterLocation = "No.15, 12th Main Road, Sector 1", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "10:00 AM", Timing2 = "4:00 PM", MovieName = "A-Team", Cast = "Dirk Benedict | Liam Neeson", MovieImage = UIImage.FromBundle("Images/Popup_Movie1.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "XYZ Theater 4K Dolby Atmos", TheaterLocation = "No.275, 3rd Cross Road,Area 27", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "11:00 AM", Timing2 = "6:00 PM", MovieName = "Conjuring 2", Cast = "Vera Farmiga | Patrick Wilson", MovieImage = UIImage.FromBundle("Images/Popup_Movie2.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "QWERTY Theater", TheaterLocation = "No.275, 3rd Cross Road,Sector North", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "10:30 AM", MovieName = "Insidious 2", Cast = "Patrick Wilson | Rose Byrne", MovieImage = UIImage.FromBundle("Images/Popup_Movie3.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "FYI Cinemas 4K", TheaterLocation = "No.15, 12th Main Road,Sector South", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "3:00 PM", MovieName = "Safe House", Cast = "Reyan Reynolds | Denzel Washington", MovieImage = UIImage.FromBundle("Images/Popup_Movie4.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "The Cinemas Dolby Digital", TheaterLocation = "No.275, 3rd Cross Road,Layout 71", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "2:30 PM", Timing2 = "9:00 PM", MovieName = "Run All Night", Cast = "Liam Neeson | Genesis Rodriguez", MovieImage = UIImage.FromBundle("Images/Popup_Movie5.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "SF Theater Dolby Atmos RDX", TheaterLocation = "North West Layout", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "1:30 PM", Timing2 = "6:00 PM", MovieName = "Source Code", Cast = "Jake Gyllenhaal | Michelle Monaghan", MovieImage = UIImage.FromBundle("Images/Popup_Movie6.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "Grid Cinemas 4K Dolby Atmos", TheaterLocation = "No.15, 12th Main Road,Area 33", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "3:30 PM", MovieName = "Clash Of The Titans", Cast = "Gemma Arteron | Sam Worthington", MovieImage = UIImage.FromBundle("Images/Popup_Movie7.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "Grand Theater", TheaterLocation = "No.275, 3rd Cross Road,South Sector", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "6:00 PM", MovieName = "A Walk Among The TombStones", Cast = "Liam Neeson | Dan Stevens", MovieImage = UIImage.FromBundle("Images/Popup_Movie8.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "Layout Cinemas Dolby Atmos RDX", TheaterLocation = "No.15, 12th Main Road,Area 152", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "6:00 PM", Timing2 = "10:30 PM", MovieName = "Unkown", Cast = "Liam Neeson | Diane Kruger", MovieImage = UIImage.FromBundle("Images/Popup_Movie9.png") });

			items.Add(new TicketBookingInfo() { TheaterName = "Xamarin Cinemas Dolby Atmos RDX", TheaterLocation = "No.275, 3rd Cross Road,Sector 77", InfoImage = UIImage.FromBundle("Images/Popup_info.png"), Timing1 = "2:30 PM", Timing2 = "6:30 PM", MovieName = "A-Team", Cast = "Dirk Benedict | Liam Neeson", MovieImage = UIImage.FromBundle("Images/Popup_Movie10.png") });

			return items;
		}

	}
}