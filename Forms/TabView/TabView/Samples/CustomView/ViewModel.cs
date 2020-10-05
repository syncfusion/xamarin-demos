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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfTabView
{
    public class ViewModelCustomTab  : INotifyPropertyChanged
    {
        private ObservableCollection<ContactsInfo> messageLogs = new ObservableCollection<ContactsInfo>();
        public ObservableCollection<ContactsInfo> MessageLogs
        {
            get
            {
                return messageLogs;
            }

            set
            {
                messageLogs = value;
                RaisePropertyChanged("MessageLogs");
            }
        }

        public ObservableCollection<ContactsInfo> ListData { get; set; }

        private string  readCount= "0";
        public string ReadCount
        {
            get
            {
                return readCount;
            }
            set
            {
                readCount = value;
                RaisePropertyChanged("ReadCount");
            }
        }



        ContactsInfoRepository collection = new ContactsInfoRepository();
        public ViewModelCustomTab()
        {
            MessageLogs = collection.GetContactDetails(2);

            ListData = collection.GetContactDetails(1);
            for (int i = 0; i < 5; i++)
            {
                AddMessage();
            }
            //Device.StartTimer(TimeSpan.FromMilliseconds(0), () =>
            //{
            //    return AddMessage();
            //});


        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
        int count = 0;
        public bool AddMessage()
        {

            if (count++ >= 5)
            {
                return false;
            }

            ReadCount = count.ToString();
            ContactsInfo currentInfo = MessageLogs[MessageLogs.Count-1];
            currentInfo.Read = true;
            currentInfo.DateMonth = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            currentInfo.MessageCount = DateTime.Now.DayOfWeek.ToString();
            MessageLogs.Remove(currentInfo);
            MessageLogs.Insert(0, currentInfo);
            return true;
        }
    }
}
