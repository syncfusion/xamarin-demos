#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "BadgeViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfBadgeView
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;

    /// <summary>
    /// Notification View Model class.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed.")]
    public class NotificationViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationViewModel" /> class
        /// </summary>
        public NotificationViewModel()
        {
            this.Collection = new ObservableCollection<NotificationModel>();

            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle1.png",
                Name = "Blessy",
                Message = "Hi, I have sent you a photo",
                Time = "Monday",
                Count = string.Empty
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle5.png",
                Name = "Aaron",
                Message = "Family meeting tomorrow at 6:30 PM",
                Time = "11:30 PM",
                Count = "99+"
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle2.png",
                Name = "Tara",
                Message = "Hi, I am Tara, How are you?",
                Time = "11:12 PM",
                Count = "3"
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle3.png",
                Name = "Jeni",
                Message = "video",
                Time = "07:53 PM",
                Count = "137",
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle4.png",
                Name = "Flora",
                Message = "I have received your gift",
                Time = "04:40 PM",
                Count = string.Empty
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle6.png",
                Name = "Sara",
                Count = "47",
                Message = "done thanks",
                Time = "Yesterday"
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle8.png",
                Name = "Stephan",
                Count = string.Empty,
                Time = "07.46 PM",
                Message = "ok fine"
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle7.png",
                Name = "Maria",
                Count = string.Empty,
                Time = "07.46 PM",
                Message = "Hi, How are you?"
            });
            this.Collection.Add(new NotificationModel()
            {
                Image = "People_Circle9.png",
                Name = "Ancy",
                Message = "Hi, i have sent you a photo",
                Time = "Monday",
                Count = "8"
            });
        }
        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the collection of Badge Model
        /// </summary>
        public ObservableCollection<NotificationModel> Collection { get; set; }

        #endregion Properties
    }
}