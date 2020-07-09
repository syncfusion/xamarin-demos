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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class FileManager : INotifyPropertyChanged
    {
        private string fileName;
        private int imageIcon;
        private ObservableCollection<FileManager> subFolder;

        public ObservableCollection<FileManager> SubFolder
        {
            get
            {
                return subFolder;
            }

            set
            {
                subFolder = value;
                RaisedOnPropertyChanged("SubFolder");
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
                RaisedOnPropertyChanged("FileName");
            }
        }

        public int ImageIcon
        {
            get
            {
                return imageIcon;
            }

            set
            {
                imageIcon = value;
                RaisedOnPropertyChanged("ImageIcon");
            }
        }

        public FileManager()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}