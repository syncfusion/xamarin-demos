#region Copyright Syncfusion Inc. 2001-2023.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfChat
{
    using Syncfusion.ListView.XForms;
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
    /// ViewModel for Load More sample.
    /// </summary>
    public class LoadMoreViewModel : INotifyPropertyChanged
    {
        #region Fields

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
        /// visible of the Badgeview.
        /// </summary>
        private bool isVisible = false;

        /// <summary>
        /// bool value for chat IsBusy.
        /// </summary>
        private bool isBusy = false;

        /// <summary>
        ///  bool value indicate chat in Bottom.
        /// </summary>
        private bool isBottom;

        /// <summary>
        /// bool value indicate load more command execution.
        /// </summary>
        private bool loadMoreCommandExecute;

        /// <summary>
        /// Field for load more behavior property.
        /// </summary
        private LoadMoreOption loadMoreBehavior = LoadMoreOption.Manual;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public LoadMoreViewModel()
        {
            this.Messages = new ObservableCollection<object>();
            this.InitializeAuthors();
            this.InitializeMessageList();
            this.authorArray = new int[] { 0, 1, 2, 1, 0, 1, 0, 2, 1, 0, 0, 2, 0, 1, 0, 2, 1, 0, 2, 1, 0, 2, 1, 0, 2, 1, 0, 2, 0, 1, 0, 2, 0, 2, 1, 0, 2, 0, 2, 1, 2, 0, 0, 2, 0, 1, 0, 2, 0, 1, 0, 1, 0, 2, 0, 0, 1, 2, 0, 1 };
            this.MapAuthorToMessage();
            this.CurrentUser = this.AuthorsCollection[0];
            LoadMoreCommand = new Command<object>(LoadMoreItems, CanLoadMoreItems);
            this.InitConvo();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the LoadMoreBehavior of SfChat.
        /// </summary>
        public LoadMoreOption LoadMoreBehavior
        {
            get
            {
                return this.loadMoreBehavior;
            }

            set
            {
                this.loadMoreBehavior = value;
                RaisePropertyChanged("LoadMoreBehavior");
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

        /// <summary>
        /// Gets or sets the load more command.
        /// </summary>
        public ICommand LoadMoreCommand { get; set; }

        /// <summary>
        /// Gets or sets the IsBusy.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        /// <summary>
        /// Gets or sets the IsBottom to inidicate the chat reach bottom or not.
        /// </summary>
        public bool IsBottom
        {
            get
            {
                return this.isBottom;
            }
            set
            {
                this.isBottom = value;
                RaisePropertyChanged("IsBottom");
            }
        }

        /// <summary>
        /// Gets or sets the LoadMoreCommand to inidicate load more command execute or not.
        /// </summary>
        public bool LoadMoreCommandExecute
        {
            get
            {
                return this.loadMoreCommandExecute;
            }
            set
            {
                this.loadMoreCommandExecute = value;
                RaisePropertyChanged("LoadMoreCommandExecute");
            }
        }

        /// <summary>
        /// Gets or sets the IsVisible to inidicate the visible of badgeview or not.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
                RaisePropertyChanged("IsVisible");
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
                "Good morning.",
                "Good morning.",
                "Morning.",
                "Is this all of us?",
                "Yes, Tammy has a couple of vid conferences, so I’m going to email her a summary when we’re done.",
                 "Ok.",
                 "Did everyone get the email with Jamie’s registry link?",
                 "Yes. The link worked.",
                 "There’s some cute stuff on there. You wanted to go in together on one of the more expensive things?",
                "Yeah. Did you see that stroller? I was looking at it.",
                "Here 👇",
                "Oh, yeah. I saw that. It’s very cool that it turns into a car seat.",
                "It has really good reviews, so I assume they did a lot of research before picking it.",
                "They want the teal version, right?",
                "That’s what comes up when I click the registry link, so I assume so.",
                "“Lake Blue”.",
                "Looks teal to me.",
                 "It’s better than just plain black, in any case.",
                 "True.",
                 "How many of us are pooling for it?",
                "Tammy is a probably. Neal gave me a max of $30, and Son just said sure. I think he just doesn’t want to shop for baby things. So at least 5, probably 6.",
                 "😂 That’s so Son.",
                 "So that puts us at between $26 and $31 per person, before tax. That’s not too bad.",
                "Yeah. I mean, I’m sure Jamie would love toys and books, but I figure there should be at least something from her list at the shower.",
                "I’m ok with it.",
                "Yeah, me, too.",
                "Great. I’ll just send an email to Tammy for when she gets out of her calls.",
                "Do you have Prime?",
                "Yes! Although I think I’d get free shipping at that price point, anyway.",
                "It’s nice that it’s on sale, too.",
                "Yeah, that’s why I want to get it ordered today. Also so I have time to inspect it a bit, make sure it works.",
                "Are we wrapping it at all?",
                "I have this giant bow in my closet I can put on it. I don’t even remember where it came from. It’s purple.",
                "Gender-neutral. Yay.",
                "They know the gender, though, right?",
                "Yes. It’s a girl. Jamie’s not big on surprises. She likes purple, though.",
                "That works, then.",
                "Do you want to do our own cards?",
                "You know Son won’t get one.",
                "We can just tell them who the stroller’s from.",
                "Yeah. We should keep a list at the party of who gave what anyway.",
                "I think that’s customary. For thank you cards.",
                "So yes, we’ll all do our own cards.",
                "Is the party in the conference room or the break room?",
                "Conference room. Mae has it booked for us.",
                "That’s good. Cleaner and easier to hide gifts in.",
                "Easier to decorate without getting in people’s way, too.",
                "You don’t want people spilling their lunches all over the tablecloth?",
                "That would be bad.",
                "😂 😂 😂",
                "I think Mae’s going to do the decorating in the morning. Aisha authorized a small budget for balloons and stuff.",
                "Tell her to let us know if she needs any help. I should have some downtime around 10:30.",
                "Ok, thanks. I will.",
                "Ack. I wish I could help, but I’ve got vid calls myself scheduled all that morning.",
                "No problem. I think there’ll be plenty of people.",
                "I’ll email everyone when Tammy gets back to me about the gift.",
                "Ok, that sounds good.",
                "Yes. I’ll see you two later.",
                "Thanks for meeting with me. Bye.",
                "Bye 👋 👋 👋"
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
        private void InitConvo()
        {
            if (this.IsDisposed)
            {
                return;
            }

            for (int i = messageList.Count - 8; i < messageList.Count; i++)
            {
                this.Messages.Add(this.CreateMessage(this.messageList[i], this.AuthorMessageDataBase[i]));
            }
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
            if (text.Contains("Here 👇"))
            {
                return new HyperlinkMessage()
                {
                    DateTime = DateTime.Now,
                    Author = auth,
                    Text = text,
                    Url = "https://www.amazon.com/Safety-1st-Smooth-OnBoard-Monument/dp/B01JRY00CW/ref=sr_1_6?dchild=1&keywords=stroller&qid=1592569167&refinements=p_72%3A2661618011&rnid=2661617011&sr=8-6&th=1"
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
        /// Action Raised when the load more command.
        /// </summary>        
        private bool CanLoadMoreItems(object obj)
        {
            if (this.Messages.Count >= this.messageList.Count)
            {
                IsBusy = false;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Action raised when the load more command is executed.
        /// </summary>
        private async void LoadMoreItems(object obj)
        {
            try
            {
                LoadMoreCommandExecute = true;
                IsBusy = true;
                await Task.Delay(3000);
                LoadMoreMessages();
            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
                LoadMoreCommandExecute = false;
                if ((this.LoadMoreBehavior == LoadMoreOption.Auto || this.LoadMoreBehavior == LoadMoreOption.AutoOnScroll) && this.messageList.Count == this.Messages.Count)
                {
                    this.LoadMoreBehavior = LoadMoreOption.None;
                }
            }
        }

        /// <summary>
        /// Adds the older messages to <see cref="SfChat"/>'s message collection.
        /// </summary>
        /// <param name="index">index of message collection.</param>
        /// <param name="count">count of the message to be added.</param>
        private void LoadMoreMessages()
        {        
            for (int i = 1; i <= 10 ; i++)
            {
                if (this.messageList.Count != this.Messages.Count)
                {
                    this.Messages.Insert(0, this.CreateMessage(messageList[this.messageList.Count - this.Messages.Count - 1], AuthorMessageDataBase[this.messageList.Count - this.Messages.Count - 1]));
                }
            }
        }
       
        #endregion
    }
}

