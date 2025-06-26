#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfChat
{
    using Syncfusion.XForms.Chat;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for GettingStarted sample.
    /// </summary>
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Backing field for the IsBadgeViewVisibleProperty.
        /// </summary>
        private bool isBadgeViewVisible = false;

        /// <summary>
        /// Chat conversation message collection.
        /// </summary>
        private ObservableCollection<object> messages;

        /// <summary>
        /// Author assinging temporary array.
        /// </summary>
        private int[] authorArray;

        /// <summary>
        /// current user of chat.
        /// </summary>
        private Author currentUser;

        /// <summary>
        /// message conversation set.
        /// </summary>
        private List<string> messageList;

        /// <summary>
        /// Indicates the typing indicator visibility. 
        /// </summary>
        private bool showTypingIndicator;

        /// <summary>
        /// Chat typing indicator.
        /// </summary>
        private ChatTypingIndicator typingIndicator;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public GettingStartedViewModel()
        {
            this.Messages = new ObservableCollection<object>();
            this.TypingIndicator = new ChatTypingIndicator();
            this.InitializeAuthors();
            this.InitializeMessageList();
            this.authorArray = new int[] { 0, 1, 2, 2, 0, 3, 4, 0, 3, 0, 5, 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 5, 1 };
            this.MapAuthorToMessage();
            this.CurrentUser = this.AuthorsCollection[0];
            this.InitConvo();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the Chat typing indicator value.
        /// </summary>
        public ChatTypingIndicator TypingIndicator
        {
            get
            {
                return this.typingIndicator;
            }

            private set
            {
                this.typingIndicator = value;
                RaisePropertyChanged("TypingIndicator");
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

            private set
            {
                this.showTypingIndicator = value;
                RaisePropertyChanged("ShowTypingIndicator");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the badge view is visible or not.
        /// </summary>
        public bool IsBadgeViewVisible
        {
            get
            {
                return this.isBadgeViewVisible;
            }

            set
            {
                this.isBadgeViewVisible = value;
                RaisePropertyChanged("IsBadgeViewVisible");
            }
        }

        /// <summary>
        /// Gets or sets the group message conversation.
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
                RaisePropertyChanged("Messages");
            }
        }

        /// <summary>
        /// Gets or sets the current author.
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

        #endregion

        #region Internal Properties

        /// <summary>
        /// Gets a sets the value indicates GettingStarted view managed resource are disposed or not.
        /// </summary>
        internal bool IsDisposed
        {
            get;
            set;
        }

        /// <summary>
        /// Chat conversation authors collection.
        /// </summary>
        internal ObservableCollection<Author> AuthorsCollection
        {
            get;
            set;
        }

        /// <summary>
        /// Dictionary that holds the message and its respective author.
        /// </summary>
        internal Dictionary<int, Author> AuthorMessageDataBase
        {
            get;
            set;
        }

        #endregion

        #region Property Changed

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        #region Private Methods

        #region Init

        /// <summary>
        /// Initializes the message collection for group conversation.
        /// </summary>
        private void InitializeMessageList()
        {
            this.messageList = new List<string>
            {
                "Hi guys, good morning! I'm very delighted to share with you the news that our team is going to launch a new mobile application.",
                "Oh! That's great.",
                "That is good news.",
                "Are we going to develop the app natively or hybrid?",
                "We should develop this app in Xamarin, since it provides native experience and performance.",
                 "I haven't heard of Xamarin. What's Xamarin?",
                 "Xamarin.Forms is a new library that lets you build native UIs for iOS, Android, and Windows Phone from one shared C# codebase.",
                 "You can check out this link to get started with Xamarin.",
                 "That's great! I will look into it.",
                "Yes, please do. It saves a lot of development time from what I've heard. We may have to dig deeper to know more.",
                "What kind of application is it and when are we going to launch?",
                "A kind of Emergency Broadcast App.",
                "Can you please elaborate?",
                "The app will help users broadcast emergency messages to friends and family from their phones with location data during emergency situations.",
                "Can we extend this idea and broadcast the data all the time? It will be better if we provide options to broadcast to selected people based on timing or profiles.",
                "That's a great idea. We can consider that in our requirement.",
                "Do we have a layout design for the new app?",
                 "We will have a dedicated design engineer to design the layout once the requirement is finalized.",
                 "Is this app going to be supported in wearable technology, too?",
                 "No, not yet. We are going to develop the mobile version first. Support for wearable watches can be considered for the next version, though.",
                "Are we going to recruit a new team? Otherwise, will we migrate our existing engineers?",
                 "Since our current project is going to be complete by the end of next month, we can move the required resources from there to the development of this app. I will all the details by the end of next week.",
                 "Wow! That's great.",
                "Cool. Cheers",

            };
        }

        /// <summary>
        /// Initializes the author collection.
        /// </summary>
        private void InitializeAuthors()
        {
            this.AuthorsCollection = new ObservableCollection<Author>();
            this.AuthorsCollection.Add(new Author() { Name = "Nancy", Avatar = "People_Circle16.png" });
            this.AuthorsCollection.Add(new Author() { Name = "Andrea", Avatar = "People_Circle2.png" });
            this.AuthorsCollection.Add(new Author() { Name = "Harrison", Avatar = "People_Circle14.png" });
            this.AuthorsCollection.Add(new Author() { Name = "Margaret", Avatar = "People_Circle7.png" });
            this.AuthorsCollection.Add(new Author() { Name = "Steven", Avatar = "People_Circle5.png" });
            this.AuthorsCollection.Add(new Author() { Name = "Michale", Avatar = "People_Circle23.png" });
        }

        /// <summary>
        /// Initializes the conversation and adds messages.
        /// </summary>
        private async void InitConvo()
        {
            if (this.IsDisposed)
            {
                return;
            }
            
            this.Messages.Add(this.CreateMessage(this.messageList[0], this.AuthorMessageDataBase[0]));
            for (int i = 1; i < this.messageList.Count; i++)
            {
                AuthorStartedTyping(this.AuthorMessageDataBase[i]);
                if (AuthorMessageDataBase[i] == AuthorsCollection[0])
                {
                    await Task.Delay(3000).ConfigureAwait(true);
                }
                else
                {
                    await Task.Delay(2000).ConfigureAwait(true);
                }
                
                if (this.IsDisposed)
                {
                    return;
                }
                
                this.ShowTypingIndicator = false;
                this.Messages.Add(this.CreateMessage(this.messageList[i], this.AuthorMessageDataBase[i]));
                await Task.Delay(1000).ConfigureAwait(true);
                if (this.IsDisposed)
                {
                    return;
                }
            }
            await Task.Delay(1000).ConfigureAwait(true);
            InitConvo();
        }

        /// <summary>
        /// Initializes which message belongs to which author.
        /// </summary>
        private void MapAuthorToMessage()
        {
            this.AuthorMessageDataBase = new Dictionary<int, Author>();
            for (int i = 0; i < this.messageList.Count; i++)
            {
                this.AuthorMessageDataBase.Add(i, this.AuthorsCollection[this.authorArray[i]]);
            }
        }

        #endregion

        /// <summary>
        /// Creating message to based on the given string.
        /// </summary>
        /// <param name="text">The text of the new message.</param>
        /// <param name="auth">The author of the new message.</param>
        /// <returns>The <see cref="TextMessage"/> created with the given string.</returns>
        private TextMessage CreateMessage(string text, Author auth)
        {
            if (text.Contains("get started with Xamarin"))
            {
                return new HyperlinkMessage()
                {
                    DateTime = DateTime.Now,
                    Author = auth,
                    Text = text,
                    Url = "https://docs.microsoft.com/en-us/xamarin/get-started/"
                };
            }
            return new TextMessage()
            {
                DateTime = DateTime.Now,
                Author = auth,
                Text = text,
            };
        }

        /// <summary>
        /// Updates the typing indicator based on the current typing author.
        /// </summary>
        private void AuthorStartedTyping(Author auth)
        {
            if (auth != this.CurrentUser)
            {
                this.TypingIndicator.Authors.Clear();
                if (auth.Name == "Margaret")
                {
                    this.TypingIndicator.Authors.Add(auth);
                    this.TypingIndicator.Authors.Add(this.AuthorsCollection[4]);
                    this.TypingIndicator.Text = auth.Name + " and " + this.AuthorsCollection[4].Name + " are typing ...";
                }
                else
                {
                    this.TypingIndicator.Authors.Add(auth);
                    this.TypingIndicator.Text = auth.Name + " is typing ...";
                }

                this.TypingIndicator.AvatarViewType = Syncfusion.XForms.Chat.AvatarViewType.Image;
                this.ShowTypingIndicator = true;
            }
        }

        #endregion
    }
}
