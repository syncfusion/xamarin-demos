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
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfExpander
{
    [Preserve(AllMembers = true)]
    public class InvoiceViewModel : INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<InvoiceItem> ItemInfo { get; set; }

        #endregion

        #region Constructor

        public InvoiceViewModel()
        {
            ItemInfo = new ObservableCollection<InvoiceItem>();
            for (int i = 0; i < items.Count(); i++)
            {
                var invoiceItem = new InvoiceItem();
                invoiceItem.ItemName = items[i];
                invoiceItem.ItemPrice = prices[i];
                ItemInfo.Add(invoiceItem);
            }
        }

        #endregion

        #region Fields

        string[] items = new string[]
        {
        "2018 Subaru Outback",
        "All-Weather Mats",
        "Door Edge Guard Kit",
        "Rear Bumper Cover",
        "Wheel Locks",
        "Gas Full Tank"
        };

        string[] prices = new string[]
        {
            "$35,705.00",
            "$101.00",
            "$162.00",
            "$107.00",
            "$81.00",
            "$64.00"
        };

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
