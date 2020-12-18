#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.TreeView.Engine;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Threading.Tasks;
using XFSfTreeView = Syncfusion.XForms.TreeView.SfTreeView;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class ChatInfo : INotifyPropertyChanged
    {
        private Assembly assembly;

        private string conversationMessage = "";
        private ObservableCollection<Conversation> conversations;
        private string sendIcon;
        private string replyIcon;

        public ObservableCollection<Conversation> Conversations
        {
            get { return conversations; }
            set
            {
                conversations = value;
                RaisedOnPropertyChanged("Conversations");
            }
        }

        public string ReplyIcon
        {
            get { return replyIcon; }
            set
            {
                replyIcon = value;
                RaisedOnPropertyChanged("ReplyIcon");
            }
        }

        public string SendIcon
        {
            get { return sendIcon; }
            set
            {
                sendIcon = value;
                RaisedOnPropertyChanged("SendIcon");
            }
        }

        public string ConversationMessage
        {
            get { return conversationMessage; }
            set
            {
                conversationMessage = value;
                RaisedOnPropertyChanged("ConversationMessage");
            }
        }

        public string UserIcon
        {
            get;
            set;
        }

        public ICommand NewConversationCommand { get; private set; }

        public ICommand NewReplyCommand { get; private set; }

        public ICommand ReplyEditCommand { get; private set; }

        public ICommand ExpandActionCommand { get; private set; }

        public event EventHandler<ChatEventArgs> ConversationAdded;

        protected virtual void OnConversationAdded(ChatEventArgs e)
        {
            EventHandler<ChatEventArgs> handler = ConversationAdded;
            handler?.Invoke(this, e);
        }

        public event EventHandler<ReplyEditEventArgs> ReplyTapped;

        protected virtual void OnReplyTapped(ReplyEditEventArgs e)
        {
            EventHandler<ReplyEditEventArgs> handler = ReplyTapped;
            handler?.Invoke(this, e);
        }

        public event EventHandler<ChatEventArgs> ReplyAdded;

        protected virtual void OnReplyAdded(ChatEventArgs e)
        {
            EventHandler<ChatEventArgs> handler = ReplyAdded;
            handler?.Invoke(this, e);
        }

        public ChatInfo()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            assembly = typeof(AutoFitContent).GetTypeInfo().Assembly;

            this.Conversations = this.GenerateConversations();
            SendIcon = "\ue745";
            UserIcon = "User.png";
            ReplyIcon = "\ue710";

            NewConversationCommand = new Command(OnConversationAdding);
            ReplyEditCommand = new Command(OnInitializeReply);
            ExpandActionCommand = new Command(OnExpandAction);
            NewReplyCommand = new Command(OnReplyConversation);
        }

        private void OnReplyConversation(object sender)
        {
            var treeViewNode = sender as TreeViewNode;
            var content = (IChatMessageInfo)treeViewNode.Content;
            Conversation conversation = null;
            if (content is Conversation)
                conversation = (Conversation)content;
            else if (content is Reply)
                conversation = (Conversation)treeViewNode.ParentNode.Content;
            if (conversation != null && !string.IsNullOrWhiteSpace(content.ReplyMessage))
            {
                var replies = conversation.Replies;
                replies.Insert(replies.Count, new Reply
                {
                    Message = content.ReplyMessage,
                    Date = DateTime.Now,
                    Name = "Me",
                    ProfileIcon = "User.png",
                    TextColor = Color.FromHex("#f23518")
                });
                conversation.Replies = replies;
                content.IsInEditMode = false;
                if (content is Conversation)
                    conversation.IsNeedExpand = true;
                OnReplyAdded(new ChatEventArgs() { ChatMessageItem = content, Conversation = conversation });
            }
            content.ReplyMessage = null;
        }

        private void OnExpandAction(object sender)
        {
            var node = sender as TreeViewNode;
            node.IsExpanded = !node.IsExpanded;
        }

        private void ResetEditMode()
        {
            foreach (Conversation conversation in this.Conversations)
            {
                if (conversation.IsInEditMode)
                {
                    conversation.IsInEditMode = false;
                    conversation.ReplyMessage = null;
                }
                foreach (Reply reply in conversation.Replies)
                {
                    if (reply.IsInEditMode)
                    {
                        reply.IsInEditMode = false;
                        reply.ReplyMessage = null;
                        break;
                    }
                }
            }
        }

        private void OnInitializeReply(object sender)
        {
            var content = (sender as TreeViewNode).Content;
            this.ResetEditMode();
            if (content is Conversation)
            {
                var conversation = (Conversation)content;
                conversation.IsInEditMode = true;
                conversation.IsNeedExpand = false;
            }
            else if (content is Reply)
            {
                Reply reply = (Reply)content;
                reply.IsInEditMode = true;
            }
            OnReplyTapped(new ReplyEditEventArgs() { Content = content });
        }
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion

        private void OnConversationAdding()
        {
            ChatInfo instance = this;
            if (!string.IsNullOrWhiteSpace(instance.ConversationMessage))
            {
                Conversation conversation = new Conversation
                {
                    Message = instance.ConversationMessage,
                    Date = DateTime.Now,
                    Name = "Me",
                    ProfileIcon = "User.png",
                    TextColor = Color.FromHex("#f23518")
                };
                instance.Conversations.Add(conversation);
                OnConversationAdded(new ChatEventArgs() { Conversation = conversation });
            }
            instance.ConversationMessage = null;
        }

        internal ObservableCollection<Conversation> GenerateConversations()
        {
            // Conversations
            var conversation1 = new Conversation() { Name = "Thomas", Message = "Hi Guys, good morning! I’m delighted to share with you the news that our team is going to develop a new mobile application.", Date = DateTime.Now.AddHours(-4), ProfileIcon = "People_Circle8.png", IsNeedExpand = true };

            conversation1.Replies.Add(new Reply() { Name = "Catherine", Message = "What kind of application?", Date = DateTime.Now.AddHours(-3).AddMinutes(-30), ProfileIcon = "People_Circle6.png" });
            conversation1.Replies.Add(new Reply() { Name = "Thomas", Message = "An emergency broadcast app. The app will help users broadcast emergency messages to friends and family from mobile devices with location information during emergencies.", Date = DateTime.Now.AddHours(-3).AddMinutes(-10), ProfileIcon = "People_Circle8.png" });
            conversation1.Replies.Add(new Reply() { Name = "Nancy", Message = "Could it broadcast data all the time? It would be better to provide options to broadcast to select people based on time or profile.", Date = DateTime.Now.AddHours(-2).AddMinutes(-30), ProfileIcon = "People_Circle9.png" });
            conversation1.Replies.Add(new Reply() { Name = "Catherine", Message = "That’s a great idea. Let’s consider that in our requirements.", Date = DateTime.Now.AddHours(-2).AddMinutes(-20), ProfileIcon = "People_Circle6.png" });

            var conversation2 = new Conversation() { Name = "Andrew", Message = "Are we going to develop it as a native or hybrid app?", Date = DateTime.Now.AddHours(-1).AddMinutes(-50), ProfileIcon = "People_Circle5.png", IsNeedExpand = true };

            conversation2.Replies.Add(new Reply() { Name = "Thomas", Message = "We’ll develop it in Xamarin, which provides native experience and performance.", Date = DateTime.Now.AddHours(-1).AddMinutes(-30), ProfileIcon = "People_Circle8.png" });
            conversation2.Replies.Add(new Reply() { Name = "Catherine", Message = "I haven’t heard of Xamarin. Can someone share details about it?", Date = DateTime.Now.AddMinutes(-59), ProfileIcon = "People_Circle6.png" });
            conversation2.Replies.Add(new Reply() { Name = "Andrew", Message = "Xamarin is a library that enables you to build native UIs for iOS, Android, and Windows Phone from a single, shared C# code base.", Date = DateTime.Now.AddMinutes(-45), ProfileIcon = "People_Circle5.png" });

            var conversation3 = new Conversation() { Name = "Nancy", Message = "Will this app be supported in wearable technology too?", Date = DateTime.Now.AddMinutes(-35), ProfileIcon = "People_Circle9.png", IsNeedExpand = true };

            conversation3.Replies.Add(new Reply() { Name = "Thomas", Message = "No. We are going to develop it for the phone version first. Support for wearable watches can be considered in the next version.", Date = DateTime.Now.AddMinutes(-25), ProfileIcon = "People_Circle8.png" });
            conversation3.Replies.Add(new Reply() { Name = "Andrew", Message = "Are we going to recruit a new team? If not, will we migrate our existing engineers from the current product?", Date = DateTime.Now.AddMinutes(-20), ProfileIcon = "People_Circle5.png" });
            conversation3.Replies.Add(new Reply() { Name = "Nancy", Message = "This is going to be great!", Date = DateTime.Now.AddMinutes(-13), ProfileIcon = "People_Circle9.png" });

            var conversationList = new ObservableCollection<Conversation>();
            conversationList.Add(conversation1);
            conversationList.Add(conversation2);
            conversationList.Add(conversation3);
            return conversationList;
        }

    }

    public class ReplyEditEventArgs : EventArgs
    {
        public object Content { get; set; }
    }

    public class ChatEventArgs : EventArgs
    {
        public object ChatMessageItem { get; set; }
        public Conversation Conversation { get; set; }
    }
}