#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    public class Contacts
    {
        private string contactName;
        private string contactNumber;
        private UIColor color;

        public Contacts(string name, string number)
        {
            contactName = name;
            contactNumber = number;
        }
        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public UIColor ContactColor
        {
            get { return color; }
            set
            {
                color = value;
            }
        }
    }
}