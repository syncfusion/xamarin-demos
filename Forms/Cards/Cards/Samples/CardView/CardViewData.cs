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
using System.Runtime.CompilerServices;
using System.Text;

namespace SampleBrowser.Cards
{
    public class CardViewData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged();
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string price;

        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        private string offer;

        public string Offer
        {
            get { return offer; }
            set
            {
                offer = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
