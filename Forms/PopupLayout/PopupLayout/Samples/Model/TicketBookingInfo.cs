#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "TicketBookingInfo.cs" company="Syncfusion.com">
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
    /// A class contains Properties and Notifies that a property value has changed 
    /// </summary>
    public class TicketBookingInfo
    {
        /// <summary>
        /// Gets or sets the MovieName
        /// </summary>
        public string MovieName { get; set; }

        /// <summary>
        /// Gets or sets the Cast
        /// </summary>
        public string Cast { get; set; }

        /// <summary>
        /// Gets or sets the MovieImage
        /// </summary>
        public string MovieImage { get; set; }

        /// <summary>
        /// Gets or sets the Timing1
        /// </summary>
        public string Timing1 { get; set; }

        /// <summary>
        /// Gets or sets the Timing2
        /// </summary>
        public string Timing2 { get; set; }

        /// <summary>
        /// Gets or sets the TheaterName
        /// </summary>
        public string TheaterName { get; set; }

        /// <summary>
        /// Gets or sets the TheaterLocation
        /// </summary>
        public string TheaterLocation { get; set; }
    }
}