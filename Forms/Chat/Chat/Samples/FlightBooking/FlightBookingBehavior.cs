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
    using Syncfusion.XForms.Chat;
    using System.Collections.Specialized;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  flight booking sample.
    /// </summary>
    public class FlightBookingBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// flight booking view model.
        /// </summary>
        private FlightBookingViewModel viewModel;

        /// <summary>
        /// sfChat control instance.
        /// </summary>
        private SfChat sfChat;

        /// <summary>
        /// Method will be called when the view is attached to the window
        /// </summary>
        /// <param name="bindable">SampleView type parameter as bindable</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            this.sfChat = bindable.FindByName<SfChat>("sfChat");
            this.viewModel = bindable.FindByName<FlightBookingViewModel>("viewModel");
            this.viewModel.Messages.CollectionChanged += OnMessagesCollectionChanged;
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Method will be called when the view is detached from window
        /// </summary>
        /// <param name="bindable">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            this.viewModel.Messages.CollectionChanged -= OnMessagesCollectionChanged;
            Connectivity.ConnectivityChanged -= this.viewModel.BotService.OnConnectivityChanged;
            this.viewModel.Bot = null;
            if (this.sfChat != null)
            {
                this.sfChat.Dispose();
                this.sfChat = null;
            }
            if (this.viewModel != null)
			{
                this.viewModel = null;
			}

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Raised when message collection is changed.
        /// </summary>
        /// <param name="sender">The object as sender</param>
        /// <param name="e">NotifyCollectionChangedEventArgs as e.</param>
        private async void OnMessagesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var chatItem in e.NewItems)
                {
                    TextMessage textMessage = chatItem as TextMessage;
                    if (textMessage != null && textMessage.Author == this.viewModel.CurrentUser)
                    {
                        this.viewModel.ShowTypingIndicator = true;
                        this.viewModel.BotService.SendMessageToBot(textMessage.Text);
                    }
                    else
                    {
                        await Task.Delay(50);
                        this.sfChat.ScrollToMessage(chatItem);
                    }
                }
            }
        }
    }
}
