#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser.SfTabView
{
    public class ViewModel
    {
        public ObservableCollection<ContactsInfo> DialledCalls1 { get; set; }
        public ObservableCollection<ContactsInfo> ReceivedCalls1 { get; set; }
        public ObservableCollection<ContactsInfo> MissedCalls1 { get; set; }
        public ObservableCollection<ContactsInfo> ListData1 { get; set; }
        public ObservableCollection<ContactsInfo> FavoriteListData1 { get; set; }
        public ObservableCollection<ContactsInfo> SpeedDial1 { get; set; }
        public ObservableCollection<ContactsInfo> DialledCalls2 { get; set; }
        public ObservableCollection<ContactsInfo> ReceivedCalls2 { get; set; }
        public ObservableCollection<ContactsInfo> MissedCalls2 { get; set; }
        public ObservableCollection<ContactsInfo> ListData2 { get; set; }
        public ObservableCollection<ContactsInfo> FavoriteListData2 { get; set; }
        public ObservableCollection<ContactsInfo> SpeedDial2 { get; set; }

        ContactsInfoRepository collection = new ContactsInfoRepository();
        public  ViewModel()
        {
            DialledCalls1 = collection.GetContactDetails(2);
            ReceivedCalls1 = collection.GetContactDetails(3);
            MissedCalls1 = collection.GetContactDetails(4);
            ListData1 = collection.GetContactDetails(1);
            FavoriteListData1 = collection.GetContactDetails(7);
            SpeedDial1 = collection.GetContactDetails(27);

            DialledCalls2 = collection.GetContactDetails(3);
            ReceivedCalls2 = collection.GetContactDetails(4);
            MissedCalls2 = collection.GetContactDetails(7);
            ListData2 = collection.GetContactDetails(1);
            FavoriteListData2 = collection.GetContactDetails(9);
            SpeedDial2 = collection.GetContactDetails(29);
        }
    }
}
