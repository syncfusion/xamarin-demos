#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    interface IChatMessageInfo
    {
        string Message { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
        string ReplyMessage { get; set; }
        bool IsInEditMode { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Conversation : IChatMessageInfo, INotifyPropertyChanged
    {
        private string message;
        private string replyMessage;
        private string profileIcon;
        private DateTime date;
        private string name;
        private ObservableCollection<Reply> replies = new ObservableCollection<Reply>();

        private Color textColor= Color.FromHex("#757575");
        private bool isInEditMode;
        private bool isNeedExpand = false;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisedOnPropertyChanged("Message");
            }
        }

        public string ReplyMessage
        {
            get { return replyMessage; }
            set
            {
                replyMessage = value;
                RaisedOnPropertyChanged("ReplyMessage");
            }
        }

        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set
            {
                isInEditMode = value;
                RaisedOnPropertyChanged("IsInEditMode");
            }
        }

        public bool IsNeedExpand
        {
            get { return isNeedExpand; }
            set
            {
                isNeedExpand = value;
                RaisedOnPropertyChanged("IsNeedExpand");
            }
        }

        public string ProfileIcon
        {
            get { return profileIcon; }
            set
            {
                profileIcon = value;
                RaisedOnPropertyChanged("ProfileIcon");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisedOnPropertyChanged("Date");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisedOnPropertyChanged("Name");
            }
        }

        public ObservableCollection<Reply> Replies
        {
            get { return replies; }
            set
            {
                replies = value;
                if (replies.Count > 0 && !IsNeedExpand)
                    IsNeedExpand = true;
                RaisedOnPropertyChanged("Replies");
            }
        }

        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                RaisedOnPropertyChanged("TextColor");
            }
        }

        public Conversation()
        {
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
    }

    [Preserve(AllMembers = true)]
    public class Reply : IChatMessageInfo, INotifyPropertyChanged
    {
        private string message = null;
        private string replyMessage;
        private Assembly assembly;
        private string profileIcon;
        private DateTime date;
        private string name;

        private Color textColor = Color.FromHex("#757575");
        private bool isInEditMode;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisedOnPropertyChanged("Message");
            }
        }

        public string ProfileIcon
        {
            get { return profileIcon; }
            set
            {
                profileIcon = value;
                RaisedOnPropertyChanged("ProfileIcon");
            }
        }

        public string ReplyMessage
        {
            get { return replyMessage; }
            set
            {
                replyMessage = value;
                RaisedOnPropertyChanged("ReplyMessage");
            }
        }

        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set
            {
                isInEditMode = value;
                RaisedOnPropertyChanged("IsInEditMode");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisedOnPropertyChanged("Date");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisedOnPropertyChanged("Name");
            }
        }

        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                RaisedOnPropertyChanged("TextColor");
            }
        }

        public Reply()
        {
            assembly = typeof(AutoFitContent).GetTypeInfo().Assembly;
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
    }
}
