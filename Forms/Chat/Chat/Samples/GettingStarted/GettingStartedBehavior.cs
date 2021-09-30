#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.BadgeView;
using Syncfusion.XForms.Chat;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfChat
{
    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the getting started sample.
    /// </summary
    public class GettingStartedBehavior : Behavior<SampleView>
    {
        #region Fields

        /// <summary>
        /// flight booking view model.
        /// </summary>
        private GettingStartedViewModel viewModel;

        /// <summary>
        /// flight booking view model.
        /// </summary>
        private int unReadMessageCount;

        /// <summary>
        /// sfChat control instance.
        /// </summary>
        private Syncfusion.XForms.Chat.SfChat sfChat;

        /// <summary>
        /// sfBadgeView control instance.
        /// </summary>
        private Syncfusion.XForms.BadgeView.SfBadgeView sfBadgeView;

        /// <summary>
        /// sfBadgeView badge settings instance.
        /// </summary>
        private Syncfusion.XForms.BadgeView.BadgeSetting badgeSetting;

        /// <summary>
        /// The page that hosts the load more sameple.
        /// </summary>
        private SampleView sampleView;

        /// <summary>
        /// Tap gesture for the badge view.
        /// </summary>
        private TapGestureRecognizer tap;

        #endregion

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            tap = new TapGestureRecognizer();
            tap.Tapped += ScrollToBottom;
            this.sampleView = bindable;
            this.sfChat = bindable.FindByName<Syncfusion.XForms.Chat.SfChat>("sfChat");
            this.viewModel = bindable.FindByName<GettingStartedViewModel>("viewModel");
            this.sfBadgeView = bindable.FindByName<Syncfusion.XForms.BadgeView.SfBadgeView>("ScrollDown");
            this.sfBadgeView.GestureRecognizers.Add(tap);
            this.viewModel.Messages.CollectionChanged += MessageCollectionChanged;
            this.sfChat.Scrolled += ChatScrolled;
            badgeSetting = new Syncfusion.XForms.BadgeView.BadgeSetting();
            badgeSetting.BadgeType = Syncfusion.XForms.BadgeView.BadgeType.Primary;
            badgeSetting.BadgeAnimation = Syncfusion.XForms.BadgeView.BadgeAnimation.None;
            badgeSetting.BadgePosition = Syncfusion.XForms.BadgeView.BadgePosition.TopLeft;
            if (Device.RuntimePlatform == "Android")
            {
                badgeSetting.Offset = new Point(-1, 1);
            }
            else if (Device.RuntimePlatform == "UWP")
            {
                badgeSetting.Offset = new Point(-7, -10);
            }
            else
                badgeSetting.Offset = new Point(0, -1);
            sfBadgeView.WidthRequest = 60;
            badgeSetting.FontSize = 10;
            sfBadgeView.BadgeSettings = badgeSetting;
        }

        /// <summary>
        /// Raised when the chat scrolled.
        /// </summary>
        /// <param name="sender">The object as sender.</param>
        /// <param name="e">ChatScrolledEventArgs as e.</param>
        private void ChatScrolled(object sender, ChatScrolledEventArgs e)
        {
            sfChat.CanAutoScrollToBottom = e.IsBottomReached;
            viewModel.IsBadgeViewVisible = !e.IsBottomReached;
            if (e.IsBottomReached)
            {
                sfBadgeView.BadgeText = string.Empty;
                this.unReadMessageCount = 0;
            }
        }

        /// <summary>
        /// Raised when the image button tapped.
        /// </summary>
        /// <param name="sender">The object as sender.</param>
        /// <param name="e">EventArgs as e.</param>
        private void ScrollToBottom(object sender, EventArgs e)
        {
            this.viewModel.IsBadgeViewVisible = false;
            this.sfChat.ScrollToMessage(sfChat.Messages[sfChat.Messages.Count - 1]);
        }

        /// <summary>
        /// Raised when the viewmodel message collection changed.
        /// </summary>
        /// <param name="sender">The object as sender.</param>
        /// <param name="e">NotifyCollectionChangedEventArgs as e.</param>
        private void MessageCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var chatItem in e.NewItems)
                {
                    if ((chatItem as TextMessage) != null && viewModel.IsBadgeViewVisible)
                    {
                        this.unReadMessageCount++;
                        sfBadgeView.BadgeText = this.unReadMessageCount.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Clears the instances used in this sample. 
        /// </summary>
        private void Dispose()
        {
            this.sfChat.Scrolled -= ChatScrolled;
            if (this.sfChat != null)
            {
                this.sfChat.Dispose();
                this.sfChat = null;
            }
            if (this.viewModel != null)
            {
                this.viewModel = null;
            }
        }

        /// <summary>
        /// Method will be called when the view is detached from window
        /// </summary>
        /// <param name="bindable">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            this.Dispose();
            this.tap.Tapped -= ScrollToBottom;
            this.tap = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
