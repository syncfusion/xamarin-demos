#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
   public class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<MessageInfo> messageInfo;
        private string newText;
        private string sendIcon;
        #endregion

        #region Properties
        public ObservableCollection<MessageInfo> MessageInfo
        {
            get { return messageInfo; }
            set { this.messageInfo = value; }
        }

        public string NewText
        {
            get { return newText; }
            set
            {
                newText = value;
                OnPropertyChanged("NewText");
            }
        }

        public string SendIcon
        {
            get
            { return sendIcon; }
            set
            { sendIcon = value; }
        }

        public Command<object> SendCommand { get; set; }

        public Command<object> LoadCommand { get; set; }

        #endregion

        #region Interface

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Interface

        #region Constructor
        public ViewModel()
        {
            InitializeSendCommand();
            GenerateSource();
        }

        #endregion

        #region GenerateSource
        public void GenerateSource()
        {
            MessageInfoRepository Message = new MessageInfoRepository();
            LoadCommand = new Command<object>(OnLoaded);
            MessageInfo = Message.GenerateInfo();
        }

        #endregion

        #region InitializeCommand

        private void InitializeSendCommand()
        {
            SendIcon = "\ue745";
            SendCommand = new Command<object>(OnSendCommand);
            NewText = "";
        }

        private void OnSendCommand(object obj)
        {
            var Listview = obj as Syncfusion.ListView.XForms.SfListView;
            if (!string.IsNullOrWhiteSpace(NewText))
            {
                MessageInfo.Add(new MessageInfo
                {
                    Text = NewText,
                    TemplateType = TemplateType.OutGoingText,
                    DateTime = string.Format("{0:HH:mm}", DateTime.Now)
                });
                (Listview.LayoutManager as LinearLayout).ScrollToRowIndex(MessageInfo.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.Start);
            }
            NewText = null;
        }

        private void OnLoaded(object obj)
        {
            var ListView = obj as Syncfusion.ListView.XForms.SfListView;
            var scrollView = ListView.Parent as ScrollView;
            ListView.HeightRequest = scrollView.Height;

            if (Device.RuntimePlatform == Device.macOS)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ListView.ScrollTo(2500);
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    (ListView.LayoutManager as LinearLayout).ScrollToRowIndex(this.MessageInfo.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.Start);
                });
            }
        }
        #endregion
    }
}
