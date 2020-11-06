#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Chat;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SampleBrowser.SfChat
{
    /// <summary>
    /// A view model for flight booking sample.
    /// </summary>
    public class FlightBookingViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// current user of chat.
        /// </summary>
        private Author currentUser;

        /// <summary>
        /// bot author.
        /// </summary>
        private Author bot;

        /// <summary>
        /// Indicates the typing indicator visibility. 
        /// </summary>
        private bool showTypingIndicator;

        /// <summary>
        /// used to check network connection state.
        /// </summary>
        private bool isConnectionnotEstablished;

        /// <summary>
        /// Chat typing indicator.
        /// </summary>
        private ChatTypingIndicator typingIndicator;

        /// <summary>
        /// chat conversation messages.
        /// </summary>
        private ObservableCollection<object> messages;

        /// <summary>
        /// used to define busy indicator visible state.
        /// </summary>
        private bool showBusyIndicator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightBookingViewModel"/> class.
        /// </summary>
        public FlightBookingViewModel()
        {
            this.Messages = new ObservableCollection<object>();
            this.Bot = new Author() { Name = "Barry", Avatar = "ChatRobot.png" };
            this.ShowBusyIndicator = true;
            this.IsConnectionNotEstablished = false;
            this.BotService = new BotService(this);
            this.TypingIndicator = new ChatTypingIndicator();
            this.TypingIndicator.Authors.Add(this.Bot);
            this.TypingIndicator.AvatarViewType = AvatarViewType.Image;
            this.TypingIndicator.Text = "Barry is typing ...";
            this.CurrentUser = new Author() { Name = "Nancy", Avatar = "People_Circle16.png" };
        }

        /// <summary>
        /// Gets or sets the Chat typing indicator value.
        /// </summary>
        public ChatTypingIndicator TypingIndicator
        {
            get
            {
                return this.typingIndicator;
            }
            set
            {
                this.typingIndicator = value;
                RaisePropertyChanged("TypingIndicator");
            }
        }

        /// <summary>
        /// Gets or sets the message conversation.
        /// </summary>
        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the typing indicator is visible or not.
        /// </summary>
        public bool ShowTypingIndicator
        {
            get
            {
                return this.showTypingIndicator;
            }
            set
            {
                this.showTypingIndicator = value;
                RaisePropertyChanged("ShowTypingIndicator");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the busy indicator is visible or not.
        /// </summary>
        public bool ShowBusyIndicator
        {
            get
            {
                return this.showBusyIndicator;
            }
            set
            {
                this.showBusyIndicator = value;
                RaisePropertyChanged("ShowBusyIndicator");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the internet connection is established or not.
        /// </summary>
        public bool IsConnectionNotEstablished
        {
            get
            {
                return this.isConnectionnotEstablished;
            }
            set
            {
                this.isConnectionnotEstablished = value;
                RaisePropertyChanged("IsConnectionNotEstablished");
            }
        }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        /// <summary>
        /// Get or sets the bot author.
        /// </summary>
        public Author Bot
        {
            get
            {
                return this.bot;
            }
            set
            {
                this.bot = value;
                RaisePropertyChanged("Bot");
            }
        }

        /// <summary>
        /// Gets or sets the bot service.
        /// </summary>
        internal BotService BotService { get; set; }

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</m>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
