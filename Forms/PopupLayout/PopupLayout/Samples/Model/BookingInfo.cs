#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "BookingInfo.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;

    /// <summary>
    /// A class contains Properties and Notifies that a property value has changed 
    /// </summary>
    public class BookingInfo : INotifyPropertyChanged
    {
        /// <summary>
        /// backing field for MovieImage.
        /// </summary>
        private ImageSource movieImage;

        /// <summary>
        /// backing field for MovieName.
        /// </summary>
        private string movieName;

        /// <summary>
        /// backing field for SubHeading.
        /// </summary>
        private string subHeading;

        /// <summary>
        /// Initializes a new instance of the BookingInfo class.
        /// </summary>
        public BookingInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BookingInfo class.
        /// </summary>
        /// <param name="name">string type of parameter name</param>
        public BookingInfo(string name)
        {
            this.movieName = name;
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the MovieName and notifies user when collection value gets changed.
        /// </summary>
        public string MovieName
        {
            get
            {
                return this.movieName;
            }

            set
            {
                if (this.movieName != value)
                {
                    this.movieName = value;
                    this.RaisedOnPropertyChanged("MovieName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the SubHeading and notifies user when collection value gets changed.
        /// </summary>
        public string SubHeading
        {
            get
            {
                return this.subHeading;
            }

            set
            {
                if (this.subHeading != value)
                {
                    this.subHeading = value;
                    this.RaisedOnPropertyChanged("SubHeading");
                }
            }
        }

        /// <summary>
        /// Gets or sets the MovieImage and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource MovieImage
        {
            get
            {
                return this.movieImage;
            }

            set
            {
                this.movieImage = value;
                this.RaisedOnPropertyChanged("MovieImage");
            }
        }

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="propertyName">string type of parameter named as propertyName</param>
        public void RaisedOnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}