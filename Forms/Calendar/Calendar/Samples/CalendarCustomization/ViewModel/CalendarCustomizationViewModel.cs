#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
    public class CalendarCustomizationViewModel : INotifyPropertyChanged
    {
        Random random = new Random();
        public bool IsCurrentMonth { get; set; }
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public DateTime Date { get; set; }

        private double celcius;

        public double Celcius
        {
            get 
            { 
                return celcius; 
            }

            set 
            { 
                celcius = value; OnPropertyChanged("Celcius");
            }
        }

        private string image;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Image
        {
            get 
            { 
                return image;
            }

            set
            { 
                image = value; 
                OnPropertyChanged("Image"); 
            }
        }

        public CalendarCustomizationViewModel(bool iscurrentmonth, DateTime date)
        {
            IsCurrentMonth = iscurrentmonth;
            this.Date = date;
            this.Title = " ";
            this.Temperature = " ";
            this.Wind = " ";
            this.Humidity = " ";
            if (IsCurrentMonth)
            {
                UpdateCelcius();

            }
        }

        private void UpdateCelcius()
        {
            if (this.Date.Day % 5 == 0)
            {
                this.Celcius = 50;
            }
            else if (this.Date.Day % 3 == 0)
            {
                this.Celcius = 80;
            }
            else
            {
                this.Celcius = 120;
            }

            if (Celcius > 10 && Celcius < 60)
            {
                this.Image = "RainyWeather.png";
            }
            else if (Celcius > 60 && Celcius < 100)
            {
                this.Image = "CloudSunny.png";
            }
            else
            {
                this.Image = "Sunny.png";
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

