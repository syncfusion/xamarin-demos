#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfRadialMenu
{
    public class Rotator_ViewModel : INotifyPropertyChanged
    {
        public Rotator_ViewModel()
        {
            RotatorCollection.Add(new Rotator_Model("Team Eagle", Color.FromHex("#f99363"), "35", "4", "36", "19", "9", "85"));
            RotatorCollection.Add(new Rotator_Model("Team Tiger", Color.FromHex("#7d8ff2"), "2", "1", "22", "1", "1", "18"));

        }
        private List<Rotator_Model> rotatorCollection = new List<Rotator_Model>();

        public List<Rotator_Model> RotatorCollection
        {
            get
            {
                return rotatorCollection;
            }
            set
            {
                rotatorCollection = value;
                RaisepropertyChanged("RotatorCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}

