#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace SampleBrowser.SfChat
{
    using SampleBrowser.Core;
    using Syncfusion.XForms.BadgeView;
    using Syncfusion.XForms.Chat;
    using System;
    using System.Collections.Specialized;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  flight booking sample.
    /// </summary>
    public class LoadMoreBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// flight booking view model.
        /// </summary>
        private LoadMoreViewModel viewModel;

        /// <summary>
        /// sfChat control instance.
        /// </summary>
        private SfChat sfChat;

        /// <summary>
        /// load more behavior picker.
        /// </summary>
        private PickerExt LoadMorePicker;

        /// <summary>
        /// sfBadgeView control instance.
        /// </summary>
        private SfBadgeView sfBadgeView;

        /// <summary>
        /// sfBadgeView badge settings instance.
        /// </summary>
        private BadgeSetting badgeSetting;

        /// <summary>
        /// The page that hosts the load more sameple.
        /// </summary>
        private SampleView sampleView;

        /// <summary>
        /// The main view that contains the SfChat instance.
        /// </summary>
        private LoadMoreView loadMoreView;

        /// <summary>
        /// Tap recognizer for badge view.
        /// </summary>
        private TapGestureRecognizer tap;

        /// <summary>
        /// Method will be called when the view is attached to the window
        /// </summary>
        /// <param name="bindable">SampleView type parameter as bindable</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            this.sampleView = bindable;
            tap = new TapGestureRecognizer();
            tap.Tapped += ScrollToBottom;
            this.LoadMorePicker = bindable.FindByName<PickerExt>("LoadMoreBehaviorPicker");
            this.LoadMorePicker.Items.Add("Manual");
            this.LoadMorePicker.Items.Add("Auto");
            this.LoadMorePicker.SelectedIndexChanged += LoadMoreSelectedIndexChanged;
            this.InitViews(bindable);
            base.OnAttachedTo(bindable);
        }

        private void InitViews(View sampleView = null)
        {
            if (sampleView != null)
            {
                this.loadMoreView = sampleView.FindByName<LoadMoreView>("LoadMoreView");
                this.sfChat = loadMoreView.FindByName<SfChat>("sfChat");
                this.viewModel = loadMoreView.FindByName<LoadMoreViewModel>("viewModel");
                this.InitBadgeView(loadMoreView.FindByName<SfBadgeView>("ScrollDown"));
                this.sfChat.Scrolled += ChatScrolled;
            }
            else
            {
                this.loadMoreView = new LoadMoreView();
                this.sfChat = loadMoreView.FindByName<SfChat>("sfChat");
                this.viewModel = loadMoreView.FindByName<LoadMoreViewModel>("viewModel");
                this.InitBadgeView(loadMoreView.FindByName<SfBadgeView>("ScrollDown"));
                this.sfChat.Scrolled += ChatScrolled;
            }
        }

        /// <summary>
        /// Initializes the badge view.
        /// </summary>
        private void InitBadgeView(SfBadgeView badgeView)
        {
            this.sfBadgeView = badgeView;
            this.sfBadgeView.GestureRecognizers.Add(tap);
            badgeSetting = new BadgeSetting();
            badgeSetting.BadgeType = BadgeType.Primary;
            badgeSetting.BadgePosition = BadgePosition.TopLeft;
            badgeSetting.Offset = new Point(1, 3);
            sfBadgeView.BadgeSettings = badgeSetting;
        }

        /// <summary>
        /// Raised when the image button tapped.
        /// </summary>
        /// <param name="sender">The object as sender.</param>
        /// <param name="e">EventArgs as e.</param>
        private void ScrollToBottom(object sender, EventArgs e)
        {
            this.sfChat.ScrollToMessage(sfChat.Messages[sfChat.Messages.Count - 1]);
        }

        /// <summary>
        /// Raised when the chat scrolled.
        /// </summary>
        /// <param name="sender">The object as sender.</param>
        /// <param name="e">ChatScrolledEventArgs as e.</param>
        private void ChatScrolled(object sender, ChatScrolledEventArgs e)
        {
            sfChat.CanAutoScrollToBottom = e.IsBottomReached;
            viewModel.IsVisible = !e.IsBottomReached;
        }

        /// <summary>
        /// Triggers while selected Index was changed, used to set a Load More Behavior
        /// </summary>
        /// <param name="sender">OnSelectionChanged event sender</param>
        /// <param name="e">EventArgs e</param>
        private void LoadMoreSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LoadMorePicker.SelectedIndex == 0)
            {
                if (this.sfChat.LoadMoreBehavior != Syncfusion.ListView.XForms.LoadMoreOption.Manual)
                {
                    this.Dispose();
                    this.sampleView.Content = null;
                    this.InitViews();
                    this.sampleView.Content = this.loadMoreView;
                    this.viewModel.LoadMoreBehavior = Syncfusion.ListView.XForms.LoadMoreOption.Manual;
                }
            }
            else if (this.LoadMorePicker.SelectedIndex == 1)
            {
                if (this.sfChat.LoadMoreBehavior != Syncfusion.ListView.XForms.LoadMoreOption.Auto)
                {
                    this.Dispose();
                    this.sampleView.Content = null;
                    this.InitViews();
                    this.sampleView.Content = this.loadMoreView;
                    this.viewModel.LoadMoreBehavior = Syncfusion.ListView.XForms.LoadMoreOption.Auto;
                }
            }
        }

        /// <summary>
        /// Disposes the created instances.
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
        protected override void OnDetachingFrom(SampleView bindable)
        {
            this.LoadMorePicker.SelectedIndexChanged -= LoadMoreSelectedIndexChanged;
            this.Dispose();
            this.tap.Tapped -= ScrollToBottom;
            this.tap = null;
            base.OnDetachingFrom(bindable);
        }

    }
}
