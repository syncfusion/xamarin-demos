#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PullToRefreshViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfPullToRefresh
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for PullToRefresh sample.
    /// </summary>
    public class PullToRefreshViewModel : INotifyPropertyChanged
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly Random randomNumber = new Random();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly string[] selectedtemperatures = { "Humid", "Rainy", "Cloudy", "Wind", "Warm" };
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly string[] temperatures = { "Humid", "Rainy", "Cloudy", "WindUnselected", "Warm" };
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private WeatherData data;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<WeatherData> selectedData;

        /// <summary>
        /// Initializes a new instance of the PullToRefreshViewModel class.
        /// </summary>
        public PullToRefreshViewModel()
        {
            this.SelectedData = this.GetWeatherData();
            this.Data = this.SelectedData[0];
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the value of Selected Data and notifies user when collection value gets changed.
        /// </summary>
        public ObservableCollection<WeatherData> SelectedData
        {
            get
            {
                return this.selectedData;
            }

            set
            {
                this.selectedData = value;
                this.RaisePropertyChanged("SelectedData");
            }
        }

        /// <summary>
        /// Gets or sets the value of Data and notifies user when collection value gets changed.
        /// </summary>
        public WeatherData Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
                this.RaisePropertyChanged("Data");
            }
        }

        /// <summary>
        /// Generates weather data values
        /// </summary>
        /// <returns>data value</returns>
        private ObservableCollection<WeatherData> GetWeatherData()
        {
            DateTime now = DateTime.Now;
            ObservableCollection<WeatherData> array = new ObservableCollection<WeatherData>();
            for (int i = 0; i < 7; i++)
            {
                WeatherData data = this.GetData(now.AddDays(i));
                data.Type = this.temperatures[i % this.temperatures.Length] + ".png";
                data.SelectedType = this.selectedtemperatures[i % this.temperatures.Length] + "Selected.png";
                array.Add(data);
            }

            return array;
        }

        /// <summary>
        /// Generates date time
        /// </summary>
        /// <param name="date">Date Time value parameter named date</param>
        /// <returns>date time value</returns>
        private WeatherData GetData(DateTime date)
        {
            string month;
            DateTime now = DateTime.Now;
            month = string.Empty + now.DayOfWeek + ", " + string.Empty + now.ToString("MMMM") + " " + now.Date.Day;
            return new WeatherData(date.ToString("dddd"), month, this.randomNumber.Next(20, 50), string.Empty, string.Empty);
        }

        #region INotifyPropertyChanged

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter named as name represent propertyName</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}