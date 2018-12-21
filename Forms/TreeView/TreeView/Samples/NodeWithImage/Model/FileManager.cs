#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class FileManager : INotifyPropertyChanged
    {
        #region Fields

        private string fileName;
        private ImageSource imageIcon;
        private ObservableCollection<FileManager> subFiles;

        #endregion

        #region Constructor
        public FileManager()
        {
        }

        #endregion

        #region Properties
        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                RaisedOnPropertyChanged("SubFiles");
            }
        }

        public string ItemName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisedOnPropertyChanged("FolderName");
            }
        }
        public ImageSource ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisedOnPropertyChanged("ImageIcon");
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