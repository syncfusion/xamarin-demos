#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "Notification.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Xamarin.Forms;

    /// <summary>
    /// Getting Started class
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class Notification : SampleView
    {
        private bool isUpdate = false;
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification" /> class.
        /// </summary>
        public Notification()
        {
            this.InitializeComponent();
            statusBadge.BadgeSettings.Offset = new Point(-5, 5);
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    {
                        callsBadge.BadgeSettings.TextPadding = new Thickness(3);
                        callsBadge.BadgeSettings.Offset = new Point(0, 2);
                    }

                    break;
                case Device.Android:
                    {
                        callsBadge.BadgeSettings.Offset = new Point(0, 2);
                    }

                    break;
                case Device.UWP:
                    {
                        callsBadge.BadgeSettings.Offset = new Point(-2, 0);
                        callsBadge.BadgeSettings.TextPadding = new Thickness(3);
                        chatBadge.BadgeSettings.Offset = new Point(0, 3);
                    }

                    break;
            }

            isUpdate = true;
            DynamicUpdate();
        }

        #endregion
        private async void DynamicUpdate()
        {
            double badgeText = 1;
            while (isUpdate && this.chatBadge != null)
            {
                badgeText += 1;
                this.chatBadge.BadgeText = badgeText.ToString();
                await Task.Delay(2000);
            }
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            isUpdate = false;
        }
    }
}