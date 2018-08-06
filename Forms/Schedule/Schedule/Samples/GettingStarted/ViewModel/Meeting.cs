#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    /// <summary>
    /// Custom appointment class
    /// </summary>
    public class Meeting
    {
        /// <summary>
        /// Gets of sets the Event name for the meeting
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the Organizer for the meeting
        /// </summary>
        public string Organizer { get; set; }

        /// <summary>
        /// Gets or sets the From time for the meeting
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the To time for the meeting
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets the color for the meeting
        /// </summary>
        public Color color { get; set; }

        /// <summary>
        /// Gets or sets the minimum height for the meeting
        /// </summary>
        public double MinimumHeight { get; set; }

        /// <summary>
        /// Gets or sets a value to indicate whether the meeting is all day or not
        /// </summary>
        public bool isAllDay { get; set; }
    }
}

