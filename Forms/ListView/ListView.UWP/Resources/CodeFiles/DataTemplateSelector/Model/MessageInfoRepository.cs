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
using System.Diagnostics;
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
    public class MessageInfoRepository : MessageInfo
    {
        private static Assembly assembly = typeof(DataTemplateSelector).GetTypeInfo().Assembly;

        #region Constructor
        public MessageInfoRepository()
        {

        }

        #endregion

        #region MessageInfo
        internal ObservableCollection<MessageInfo> GenerateInfo()
        {
            var MessageInfo = new ObservableCollection<MessageInfo>();
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[0],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-77)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[1],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowse.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Nancy",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-75)),
                TemplateType = TemplateType.IncomingText
            });

            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[2],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Andrew",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-73)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[3],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Nancy",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-72)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[4],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-70)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[5],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Andrew",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-69)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[6],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-67)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[7],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile2.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile2.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Catherine",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-66)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[8],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-64)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[9],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Andrew",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-54)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[10],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-50)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[11],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Nancy",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-48)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[12],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-47)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[13],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Andrew",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-45)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[14],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-44)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[15],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Andrew",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-42)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[16],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-39)),
                TemplateType = TemplateType.OutGoingText
            });

            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[17],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Nancy",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-30)),
                TemplateType = TemplateType.IncomingText
            });

            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[18],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-28)),
                TemplateType = TemplateType.OutGoingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[19],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Andrew",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-24)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[20],
#if COMMONSB
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                DateTime = string.Format("{0:d/MM/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-21)),
                TemplateType = TemplateType.OutGoingText
            });

            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[21],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile3.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Andrew",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-15)),
                TemplateType = TemplateType.IncomingText
            });
            MessageInfo.Add(new MessageInfo()
            {
                Text = Descriptions[22],
#if COMMONSB
                ProfileImage = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#else
                ProfileImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.Profile1.png", assembly),
                IncomingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.IncomingIndicatorImage.png", assembly),
#endif
                Username = "Nancy",
                DateTime = string.Format("{0:d/M/yyyy HH:mm}", System.DateTime.Now.AddMinutes(-10)),
                TemplateType = TemplateType.IncomingText
            });
            return MessageInfo;
        }

        #endregion

        #region Properties

        public string[] Descriptions = new string[]
        {
            "Hi Guys, Good morning! I’m very delighted to share with you the news that our team is going to launch a new mobile application.",
            "Oh! That’s great.",
            "That is a good news.",
            "What kind of application are we gonna launch?.",
            "A kind of “Emergency Broadcast App”.",
            "Can you please elaborate?",
            "The app will help users to broadcast emergency messages to friends and family from mobile with location during emergency situations.",
            "Can we extend this idea broadcast the data all the time? It will be better if we provide options to broadcast to selected people based on timings or profiles.",
            "That’s a great idea. We can consider that in our requirement.",
            "Do we have any layout design for the new app?",
            "Yes, of course. We will be having a dedicated design engineer for design the layout once the requirement is finalized.",
            "Are we going to develop the app in native or hybrid?",
            "We should develop this App in Xamarin which provides native experience and performance.",
            "I haven’t heard of Xamarin Can someone share details about Xamarin?",
            "Xamarin.Forms is a new library that enables you to build native UIs for iOS, Android and Windows Phone from a single, shared C# codebase.",
            "That’s great! I will take a look into it.",
            "Yes, you can. It saves a lot of development time to what I have heard. We may have to dig in deeper for knowing more.",
            "Does this app going to be supported in wearable technology too?",
            "No. We are going to develop the mobile version first. Support for wearable watch can be considered in the next version.",
            "Are we going to recruit a new team? Otherwise, will be migrate our existing engineers from the current product.",
            "Since our current product is going to complete by the end of next month, we can move the required resources from the current product to this app development. I will share the complete requirement by end of next week.",
            "Ayah! That’s great.",
            "Cool. Cheers"
        };

        public ImageSource[] TemplateImages = new ImageSource[]
       {
#if COMMONSB
           ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.TemplateImage0.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.TemplateImage1.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.TemplateImage2.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.TemplateImage3.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.TemplateImage4.jpg", assembly),
#else
           ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.TemplateImage0.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.TemplateImage1.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.TemplateImage2.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.TemplateImage3.jpg", assembly),
            ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.TemplateImage4.jpg", assembly),
#endif
       };

        #endregion
    }

    #region Field
    public enum TemplateType
    {
        IncomingText,
        OutGoingText,
        IncomingImage
    }

    #endregion
}