#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SampleBrowser.SfCircularGauge
{
    public class PointerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double firstMarkerValue = 2;

        private double secondMarkerValue = 10;

        private double pointerSize = 30;
        public double PointerSize
        {
            get { return pointerSize; }
            set
            {
                pointerSize = value;
                OnPropertyChanged("PointerSize");
            }
        }

        public double FirstMarkerValue
        {
            get { return firstMarkerValue; }
            set
            {
                firstMarkerValue = value;
                OnPropertyChanged("FirstMarkerValue");
            }
        }

        public double SecondMarkerValue
        {
            get { return secondMarkerValue; }
            set
            {
                secondMarkerValue = value;
                OnPropertyChanged("SecondMarkerValue");
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
