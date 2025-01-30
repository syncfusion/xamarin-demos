using System;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class TicketBookingViewModel
	{
		public TicketBookingViewModel()
		{
			TicketInfoRepository details = new TicketInfoRepository();
			theaterInformation = details.GetDetails();
		}

		#region ItemsSource

		private ObservableCollection<TicketBookingInfo> theaterInformation;

		public ObservableCollection<TicketBookingInfo> TheaterInformation
		{
			get { return this.theaterInformation; }
			set { this.theaterInformation = value; }
		}

		#endregion

	}
}
