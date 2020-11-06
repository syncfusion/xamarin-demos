#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace SampleBrowser.SfChat
{
    /// <summary>
    /// A class contains necessary details to book flight.
    /// </summary>
    public class FlightBookingModel
    {
        /// <summary>
        /// Gets or sets the Destination country.
        /// </summary>
        public string DestinationCountry { get; set; }

        /// <summary>
        /// Gets or sets the Destination city.
        /// </summary>
        public string DestinationCity { get; set; }

        /// <summary>
        /// Gets or sets the airway.
        /// </summary>
        public string Airway { get; set; }

        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        public string TravelDate { get; set; }

        /// <summary>
        /// Gets or sets the passenger count.
        /// </summary>
        public string MembersCount { get; set; }
    }

    /// <summary>
    /// A class contains the conversation details.
    /// </summary>
    public class Conversation
    {
        /// <summary>
        /// Gets or sets the conversation id.
        /// </summary>
        public string ConversationId { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets value indicates the connection expire time.
        /// </summary>
        public string Expires_in { get; set; }

        /// <summary>
        /// Gets or sets the stream url.
        /// </summary>
        public string StreamUrl { get; set; }
    }

    /// <summary>
    /// A class contains the conversation activities and water mark.
    /// </summary>
    public class ActivitySet
    {
        public List<Activity> Activities { get; set; }
        public string Watermark { get; set; }
    }
}
