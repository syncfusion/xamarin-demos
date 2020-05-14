#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using UIKit;
using SampleBrowser;

namespace SampleBrowser
{
    /// <summary>
    /// Custom appointment class
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Meeting
    {
        /// <summary>
        /// Gets of sets the Event name for the meeting
        /// </summary>
        public NSString EventName { get; set; }

        /// <summary>
        /// Gets or sets the Organizer for the meeting
        /// </summary>
        public NSString Organizer { get; set; }

        /// <summary>
        /// Gets or sets the From time for the meeting
        /// </summary>
        public NSDate From { get; set; }

        /// <summary>
        /// Gets or sets the To time for the meeting
        /// </summary>
        public NSDate To { get; set; }

        /// <summary>
        /// Gets or sets the color for the meeting
        /// </summary>
        public UIColor Color { get; set; }

        /// <summary>
        /// Gets or sets the minimum height for the meeting
        /// </summary>
        public double MinimumHeight { get; set; }

        /// <summary>
        /// Gets or sets a value to indicate whether the meeting is all day or not
        /// </summary>
        public bool IsAllDay { get; set; }
    }
}
