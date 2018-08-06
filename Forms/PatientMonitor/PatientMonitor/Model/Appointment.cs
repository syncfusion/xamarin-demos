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
using Xamarin.Forms;

namespace PatientMonitor
{
    class Appointment : INotifyPropertyChanged
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

        Patient patient;

        public Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                this.patient = value;
                this.OnPropertyChanged("Patient");
            }
        }

        string subject;

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                this.subject = value;
                this.OnPropertyChanged("Subject");
            }
        }

        string notes;

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                this.notes = value;
                this.OnPropertyChanged("Notes");
            }
        }

        DateTime startTime;

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                this.startTime = value;
                this.OnPropertyChanged("StartTime");
            }
        }

        DateTime endTime;

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                this.endTime = value;
                this.OnPropertyChanged("EndTime");
            }
        }

        private Color eventColor;
        public Color EventColor
        {
            get
            {
                return eventColor;
            }
            set
            {
                this.eventColor = value;
                this.OnPropertyChanged("EventColor");
            }
        }

    }
}
