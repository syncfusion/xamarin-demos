#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    [Preserve(AllMembers = true)]
	public class Meeting
	{
		public string EventName { get; set; }
		public string Organizer { get; set; }
		public string ContactID { get; set; }
		public int Capacity { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public Color color { get; set; }
        public double MinimumHeight { get; set; }
        public bool IsAllDay { get; set; }
        public string StartTimeZone { get; set; }
        public string EndTimeZone { get; set; }
	}
}

