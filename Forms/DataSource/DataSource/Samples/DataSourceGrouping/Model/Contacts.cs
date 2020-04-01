#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.DataSource
{
    [Preserve(AllMembers = true)]
    public class Contacts : INotifyPropertyChanged
    {
        private string contactName;
        private string contactNumber;
        private string displayString;
        private Color color;

        public Contacts(string name, string number)
        {
            contactName = name;
            contactNumber = number;
            displayString = name[0].ToString();
        }
        public string ContactName
        {
            get { return contactName; }
            set
            {
                if (contactName != value)
                {
                    contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                if (contactNumber != value)
                {
                    contactNumber = value;
                    this.RaisedOnPropertyChanged("ContactNumber");
                }
            }
        }

        public string DisplayString
        {
            get { return displayString; }
            set             
            {
                if (displayString != value)
                {
                    displayString = value;
                    this.RaisedOnPropertyChanged("DisplayString");
                }
            }
        }

        public Color ContactColor
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    this.RaisedOnPropertyChanged("ContactColor");
                }
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