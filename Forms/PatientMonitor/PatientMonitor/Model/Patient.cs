#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PatientMonitor
{
    class Patient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        ImageSource image;

        public ImageSource Image
        {
            get
            {
                return image;
            }
            set
            {
                this.image = value;
                this.OnPropertyChanged("Image");
            }
        }
        
        double hr;

        public double HR
        {
            get
            {
                if(this.Observations.Count > 0)
                {
                    return this.Observations[this.Observations.Count - 1].HR;
                }

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
                if (this.Observations.Count > 0)
                {
                    return this.Observations[this.Observations.Count - 1].Temp;
                }

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
                if (this.Observations.Count > 0)
                {
                    return this.Observations[this.Observations.Count - 1].BP;
                }

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
                if (this.Observations.Count > 0)
                {
                    return this.Observations[this.Observations.Count - 1].RR;
                }

                return rr;
            }
            set
            {
                this.rr = value;
                this.OnPropertyChanged("RR");
            }
        }


        int rNo;

        public int RNo
        {
            get
            {
                return rNo;
            }
            set
            {
                this.rNo = value;
                this.OnPropertyChanged("RNo");
            }
        }

        public ObservableCollection<Observation> Observations { get; set; }

        public Patient()
        {
            this.Observations = new ObservableCollection<Observation>();
        }

        private void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
