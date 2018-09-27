#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace SampleBrowser.SfPopupLayout
{
    public class BookingInfo : INotifyPropertyChanged
    {
        private string movieName;
        private string subHeading;
        private ImageSource movieImage;
        
        public BookingInfo()
        {

        }

        public BookingInfo(string Name)
        {
            movieName = Name;
        }

        public string MovieName
        {
            get { return movieName; }
            set
            {
                if (movieName != value)
                {
                    movieName = value;
                    this.RaisedOnPropertyChanged("MovieName");
                }
            }
        }

        public string SubHeading
        {
            get { return subHeading; }
            set
            {
                if (subHeading != value)
                {
                    subHeading = value;
                    this.RaisedOnPropertyChanged("SubHeading");
                }
            }
        }

        public ImageSource MovieImage
        {
            get { return this.movieImage; }
            set
            {
                this.movieImage = value;
                this.RaisedOnPropertyChanged("MovieImage");
            }
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
