#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfPullToRefresh
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class WeatherData : INotifyPropertyChanged
    {
        public WeatherData(String day, String month, double temperature, String type, String selectedType)
        {
            
            Day = day;
            Month = month;
            Temperature = temperature;
            SelectedType = selectedType;
            Type = type;
            ID = type;
        }

        private string day;
        public string Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
                RaisePropertyChanged("Day");
            }
        }

        private string month;
        public string Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
                RaisePropertyChanged("Month");
            }
        }

        private double temperature;
        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }

        private string selectedType;
        public String SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                selectedType = value;
                RaisePropertyChanged("SelectedType");
            }
        }

        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("ID");
            }
        }
        private String type;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Type
        {
            get { return type; }
            set
            {
                type = value;
#if COMMONSB
                ImageName = ImageSource.FromResource("SampleBrowser.Icons."+type, this.GetType().Assembly);
#else
                ImageName = ImageSource.FromResource("SampleBrowser.SfPullToRefresh.Icons." + type, this.GetType().Assembly);
#endif

            }
        }

        private ImageSource imageName;
        public ImageSource ImageName
        {
            get
            {
                return imageName;
            }
            set
            {
                imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}


