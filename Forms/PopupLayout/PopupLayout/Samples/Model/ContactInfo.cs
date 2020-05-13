#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ContactInfo.cs" company="Syncfusion.com">
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
    public class ContactInfo : INotifyPropertyChanged
    {
        /// <summary>
        /// backing field for CallTime.
        /// </summary>
        private string callTime;

        /// <summary>
        /// backing field for ContactImage.
        /// </summary>
        private string contactImage;

        /// <summary>
        /// backing field for ContactName.
        /// </summary>
        private string contactName;

        /// <summary>
        /// Initializes a new instance of the ContactInfo class.
        /// </summary>
        public ContactInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContactInfo class.
        /// </summary>
        /// <param name="name">string type parameter named as name</param>
        public ContactInfo(string name)
        {
            this.contactName = name;
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>       
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets ContactName and notifies user when collection value gets changed.
        /// </summary>
        public string ContactName
        {
            get
            {
                return this.contactName;
            }

            set
            {
                if (this.contactName != value)
                {
                    this.contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }

        /// <summary>
        /// Gets or sets CallTime and notifies user when collection value gets changed.
        /// </summary>
        public string CallTime
        {
            get
            {
                return this.callTime;
            }

            set
            {
                if (this.callTime != value)
                {
                    this.callTime = value;
                    this.RaisedOnPropertyChanged("CallTime");
                }
            }
        }

        /// <summary>
        /// Gets or sets ContactImage and notifies user when collection value gets changed.
        /// </summary>
        public string ContactImage
        {
            get
            {
                return this.contactImage;
            }

            set
            {
                this.contactImage = value;
                this.RaisedOnPropertyChanged("ContactImage");
            }
        }

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="propertyName">string type parameter named as propertyName</param>
        public void RaisedOnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}