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
    /// <summary>
    /// Meeting class
    /// </summary>
    [Preserve(AllMembers = true)]
	public class Meeting
	{
        /// <summary>
        /// Gets or sets event name
        /// </summary>
		public string EventName { get; set; }

        /// <summary>
        /// Gets or sets organizer
        /// </summary>
		public string Organizer { get; set; }

        /// <summary>
        /// Gets or sets contact ID
        /// </summary>
		public string ContactID { get; set; }

        /// <summary>
        /// Gets or sets capacity
        /// </summary>
		public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets date
        /// </summary>
		public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets date
        /// </summary>
		public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets color
        /// </summary>
		public Color Color { get; set; }

        /// <summary>
        /// Gets or sets minimum height
        /// </summary>
        public double MinimumHeight { get; set; }

        /// <summary>
        /// Gets or sets all day
        /// </summary>
        public bool IsAllDay { get; set; }

        /// <summary>
        /// Gets or sets start time zone
        /// </summary>
        public string StartTimeZone { get; set; }

        /// <summary>
        /// Gets or sets end time zone
        /// </summary>
        public string EndTimeZone { get; set; }
	}
}