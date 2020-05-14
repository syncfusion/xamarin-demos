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
using System.Text;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class MailFolder : INotifyPropertyChanged
    {
        #region Feilds

        private string folderName;
        private int mailsCount;
        private ObservableCollection<SubFolder> subFolders;

        #endregion

        #region Constructor
        public MailFolder()
        {
        }

        #endregion

        #region Properties
        public ObservableCollection<SubFolder> SubFolder
        {
            get { return subFolders; }
            set
            {
                subFolders = value;
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

        #endregion

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
    public class SubFolder : INotifyPropertyChanged
    {
        #region Feilds

        private string folderName;
        private int mailsCount;

        #endregion

        #region Constructor
        public SubFolder()
        {
        }

        #endregion

        #region Properties

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

        #endregion

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
