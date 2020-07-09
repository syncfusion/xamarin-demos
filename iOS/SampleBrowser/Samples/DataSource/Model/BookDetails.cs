#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using UIKit;

namespace SampleBrowser
{
    public class BookDetails : INotifyPropertyChanged
    {
        public BookDetails()
        {
        }

        #region private variables

        private int bookID;
        private string customerName;
        private int price;
        private string bookName;
        private UIImage customerImage;

        #endregion

        #region Public Properties

        public int BookID
        {
            get { return bookID; }
            set
            {
                this.bookID = value;
                RaisePropertyChanged("BookID");
            }
        }

        public UIImage CustomerImage
        {
            get { return this.customerImage; }
            set
            {
                this.customerImage = value;
                RaisePropertyChanged("CustomerImage");
            }
        }

        public string CustomerName
        {
            get { return this.customerName; }
            set
            {
                this.customerName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string BookName
        {
            get { return bookName; }
            set
            {
                this.bookName = value;
                RaisePropertyChanged("BookName");
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                this.price = value;
                RaisePropertyChanged("Price");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}

