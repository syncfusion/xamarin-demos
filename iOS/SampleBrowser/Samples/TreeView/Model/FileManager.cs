#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using UIKit;
namespace SampleBrowser
{
    public class FileManager : INotifyPropertyChanged
    {

        private string fileName;
        private UIImage imageIcon;
        private ObservableCollection<FileManager> subFolder;

        public ObservableCollection<FileManager> SubFolder
        {
            get { return subFolder; }
            set 
			{
				subFolder = value; 
				RaisedOnPropertyChanged("SubFolder");
			}
        }

        public string FileName
        {
            get { return fileName; }
            set 
			{
				fileName = value;
				RaisedOnPropertyChanged("FileName"); 
			}
        }
        public UIImage ImageIcon
        {
            get { return imageIcon; }
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

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}