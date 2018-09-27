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

namespace PatientMonitor
{
    class Observation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        double hr;

        public double HR
        {
            get
            {
                return hr;
            }
            set
            {
                this.hr = value;
                this.OnPropertyChanged("HR");
            }
        }

        double temp;

        public double Temp
        {
            get
            {
                return temp;
            }
            set
            {
                this.temp = value;
                this.OnPropertyChanged("Temp");
            }
        }

        double bp;

        public double BP
        {
            get
            {
                return bp;
            }
            set
            {
                this.bp = value;
                this.OnPropertyChanged("BP");
            }
        }


        double rr;

        public double RR
        {
            get
            {
                return rr;
            }
            set
            {
                this.rr = value;
                this.OnPropertyChanged("RR");
            }
        }

        DateTime dateTime;

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                this.dateTime = value;
                this.OnPropertyChanged("DateTime");
            }
        }
    }
}
