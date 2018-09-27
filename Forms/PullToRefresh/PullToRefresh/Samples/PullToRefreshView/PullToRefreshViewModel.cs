#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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

namespace SampleBrowser.SfPullToRefresh
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class PullToRefreshViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WeatherData> SelectedData
        {
            get { return selectedData; }
            set
            {
                this.selectedData = value;
                RaisePropertyChanged("SelectedData");
            }
        }
        public WeatherData Data
        {
            get { return data; }
            set
            {
                this.data = value;
                RaisePropertyChanged("Data");
            }
        }

        private ObservableCollection<WeatherData> selectedData;
        private WeatherData data;
        private Random randomNumber = new Random();
        private string[] temperatures = new string[] { "humid", "rainy", "cloudy", "windy", "warm" };

        public PullToRefreshViewModel()
        {
            this.SelectedData = GetWeatherData();
            this.Data = SelectedData[0];
        }

        private ObservableCollection<WeatherData> GetWeatherData()
        {
            DateTime now = DateTime.Now;
            ObservableCollection<WeatherData> array = new ObservableCollection<WeatherData>();
            for (int i = 0; i < 7; i++)
            {
                WeatherData data = GetData(now.AddDays(i));
                data.Type = temperatures[i % temperatures.Length] + ".png";
                data.SelectedType = temperatures[i % temperatures.Length] + "selected.png";
                array.Add(data);
            }
            return array;
        }

        private WeatherData GetData(DateTime date)
        {
            string month;
            DateTime now = DateTime.Now;
            month = "" + now.DayOfWeek.ToString() + ", " + " " + now.ToString("MMMM") + " " + now.Date.Day.ToString();
            return new WeatherData(date.ToString("dddd"), month, randomNumber.Next(20, 50), "", "");
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
