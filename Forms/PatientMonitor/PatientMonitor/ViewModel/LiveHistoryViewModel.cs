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
    class LiveHistoryViewModel : INotifyPropertyChanged
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

        public ObservableCollection<Observation> LiveObservations { get; set; }

        public ObservableCollection<Observation> HistoryObservations { get; set; }

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

        bool isLive;

        public bool IsLive
        {
            get
            {
                return isLive;
            }
            set
            {
                this.isLive = value;

                if(this.IsLive)
                {
                    Device.StartTimer(TimeSpan.FromSeconds(.5), () => {
                       return this.UpdateLiveObservation();
                    });

                    this.IsHistoryView = false;
                }
                else
                {
                    this.IsHistoryView = true;
                }

                this.OnPropertyChanged("IsLive");
            }
        }

        bool isHistoryView;

        public bool IsHistoryView
        {
            get
            {
                return isHistoryView;
            }
            set
            {
                this.isHistoryView = value;
                this.OnPropertyChanged("isHistoryView");
            }
        }

        public LiveHistoryViewModel(Patient patient)
        {
            this.Patient = patient;
            this.HistoryObservations = this.Patient.Observations;
            this.LiveObservations = new ObservableCollection<Observation>();

            foreach(var observation in this.HistoryObservations)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    if (this.LiveObservations.Count < 40)
                    {
                        this.LiveObservations.Add(observation);
                    }
                    else
                    {
                        this.LiveObservations.RemoveAt(0);
                        this.LiveObservations.Add(observation);
                    }
                }
                else
                {
                    if (this.LiveObservations.Count < 100)
                    {
                        this.LiveObservations.Add(observation);
                    }
                    else
                    {
                        this.LiveObservations.RemoveAt(0);
                        this.LiveObservations.Add(observation);
                    }
                }
            }

            this.IsLive = true;
        }
        public bool UpdateLiveObservation()
        {
            int Value = 0;
            int BP = 0, Temp = 0, RR = 0, HR = 0;
            if (!this.IsLive)
            {
                return false;
            }

            Random ran = new Random();
            Observation observation = new Observation();
            if (Value == 0)
            {
                BP = ran.Next(30, 90);
                observation.BP = BP;
                Temp = ran.Next(50, 90);
                observation.Temp = Temp;
                RR = ran.Next(12, 40);
                observation.RR = RR;
                HR = ran.Next(30, 90);
                observation.HR = HR;
                Value++;
            }
            //else if (i % 5 == 0)
            //{

            //    BP = ran.Next(30, 90);
            //    observation.BP = BP;
            //    Temp = ran.Next(50, 90);
            //    observation.Temp = Temp;
            //    RR = ran.Next(12, 40);
            //    observation.RR = RR;
            //    HR = ran.Next(30, 90);
            //    observation.HR = HR;
            //}
            else
            {
                int i=0;
                if ( i== 0)
                {
                    observation.BP = BP;
                    observation.Temp = Temp;
                    observation.RR = RR;
                    observation.HR = HR;
                    i++;
                }
                else if(i==1)
                {
                    observation.BP = BP;
                    observation.Temp = Temp;
                    observation.RR = RR;
                    observation.HR = HR;
                    i++;
                }
                else if (i == 2)
                {
                    observation.BP = BP;
                    observation.Temp = Temp;
                    observation.RR = RR;
                    observation.HR = HR;
                    i++;
                }
                else if (i == 3)
                {
                    observation.BP = BP;
                    observation.Temp = Temp;
                    observation.RR = RR;
                    observation.HR = HR;
                    i++;
                }
                else
                {
                    observation.BP = BP;
                    observation.Temp = Temp;
                    observation.RR = RR;
                    observation.HR = HR;
                    i = 0;
                    Value = 0;
                }
                
            }
            observation.DateTime = this.LiveObservations.Last().DateTime.AddSeconds(1);
            if (Device.Idiom == TargetIdiom.Phone)
            {
                if (this.LiveObservations.Count < 40)
                {
                    this.LiveObservations.Add(observation);
                }
                else
                {
                    this.LiveObservations.RemoveAt(0);
                    this.LiveObservations.Add(observation);
                }
            }
            else
            {
                if (this.LiveObservations.Count < 100)
                {
                    this.LiveObservations.Add(observation);
                }
                else
                {
                    this.LiveObservations.RemoveAt(0);
                    this.LiveObservations.Add(observation);
                }
            }

            return true;
        }
    
        public void UpdateHistory()
        {
            this.HistoryObservations.Add(this.LiveObservations[this.LiveObservations.Count-1]);
        }
    }
}