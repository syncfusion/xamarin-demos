#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<MessageInfo> messageInfo;
        private string newText;
        internal Syncfusion.ListView.XForms.SfListView ListView;
        private ImageSource sendIcon;

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

        public ImageSource SendIcon
        {
            get
            { return sendIcon; }
            set
            { sendIcon = value; }
        }

        public ICommand SendCommand { get; set; }

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
            MessageInfo = Message.GenerateInfo();
        }

        #endregion

        #region InitializeCommand
        private void InitializeSendCommand()
        {
            Assembly assembly = typeof(DataTemplateSelector).GetTypeInfo().Assembly;
#if COMMONSB
            SendIcon = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.SendIcon.png", assembly);
#else
            SendIcon = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.SendIcon.png", assembly);
#endif
            NewText = "";
            SendCommand = new Command(() =>
            {
                if (!string.IsNullOrWhiteSpace(NewText))
                {
                    MessageInfo.Add(new MessageInfo
                    {
#if COMMONSB
                        OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                        OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                        Text = NewText,
                        TemplateType = TemplateType.OutGoingText,
                        DateTime = string.Format("{0:HH:mm}", DateTime.Now)
                    });
                    (ListView.LayoutManager as LinearLayout).ScrollToRowIndex(MessageInfo.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.Start);
                }
                NewText = null;
            });
        }

        #endregion
    }
}
