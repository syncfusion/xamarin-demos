#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewGalleryInfo : INotifyPropertyChanged
    {
        #region Fields

        private string image;
        private string imageTitle;
        private string createdData;
        private bool isSelected;
        private bool isFavorite;

        #endregion

        #region Constructor

        public ListViewGalleryInfo()
        {

        }

        #endregion

        #region Properties

        public bool IsFavorite
        {
            get { return isFavorite; }
            set
            {
                isFavorite = value;
                OnPropertyChanged("IsFavorite");
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public string ImageTitle
        {
            get { return imageTitle; }
            set
            {
                imageTitle = value;
                OnPropertyChanged("ImageTitle");
            }
        }

        public string CreatedDate
        {
            get { return createdData; }
            set
            {
                createdData = value;
                OnPropertyChanged("CreatedDate");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
