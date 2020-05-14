#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SampleBrowser
{
    public class MailFolder : INotifyPropertyChanged
    {

        private string folderName;
        private int mailsCount;
        private ObservableCollection<MailFolder> subFolder;

        public ObservableCollection<MailFolder> SubFolder
        {
            get { return subFolder; }
            set
            {
                subFolder = value;
                RaisedOnPropertyChanged("SubFolder");
            }
        }

        public string FolderName
        {
            get { return folderName; }
            set
            {
                folderName = value;
                RaisedOnPropertyChanged("FolderName");
            }
        }
        public int MailsCount
        {
            get { return mailsCount; }
            set
            {
                mailsCount = value;
                RaisedOnPropertyChanged("MailsCount");
            }
        }
        public MailFolder()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}