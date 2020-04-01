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
using System.Text;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfAccordion
{
    [Preserve(AllMembers = true)]
	
    public class InvoiceItem : INotifyPropertyChanged
    {
        #region Fields

        private string itemName;
        private string itemPrice;

        #endregion

        #region Properties

        public string ItemName
        {
            get { return itemName; }
            set
            {
                if (itemName != value)
                {
                    itemName = value;
                    this.RaisedOnPropertyChanged("ItemName");
                }
            }
        }
        public string ItemPrice
        {
            get { return itemPrice; }
            set
            {
                if (itemPrice != value)
                {
                    itemPrice = value;
                    this.RaisedOnPropertyChanged("ItemPrice");
                }
            }
        }

        #endregion

        #region Interface Member

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
