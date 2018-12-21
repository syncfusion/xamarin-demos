#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SampleBrowser.SfParallaxView
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for PullToRefresh sample.
    /// </summary>
    public class WeatherViewModel : INotifyPropertyChanged
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly Random randomNumber = new Random();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<WeatherData> selectedData;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource parallaxImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource buildingImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource cloudImage;

        private string[] weatherConditions = new string[] { "Heavy thunder", "Sunny", "Foggy", "Rainy", "Warm", "Cloudy","Snowfall" };
        private string[] weatherdegrees = new string[] { "18", "40", "20", "25", "32", "28", "15" };


        /// <summary>
        /// Initializes a new instance of the PullToRefreshViewModel class.
        /// </summary>
        public WeatherViewModel()
        {
            this.SelectedData = this.GetWeatherData();
            Assembly assembly = typeof(WeatherViewModel).GetTypeInfo().Assembly;
            ParallaxImage = ImageSource.FromFile("pxcloud.png");
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
        /// Generates weather data values
        /// </summary>
        /// <returns>data value</returns>
        private ObservableCollection<WeatherData> GetWeatherData()
        {
            DateTime now = DateTime.Now;
            Assembly assembly = typeof(WeatherViewModel).GetTypeInfo().Assembly;
            ObservableCollection<WeatherData> array = new ObservableCollection<WeatherData>();          
            for (int i = 0; i < 7; i++)
            {
                now = DateTime.Now.AddDays(i);
                string date = string.Empty + now.DayOfWeek + ", " + string.Empty + now.ToString("MMMM") + " " + now.Date.Day;
                var temperature= weatherdegrees[i];
                var weatherImage = "weather_"+(i+1)+".png";
                var weatherDetails = weatherConditions[i];
                WeatherData data = new WeatherData(date,temperature, weatherImage,weatherDetails);

                array.Add(data);
            }

            return array;
        }

        /// <summary>
        /// Gets or sets the value of ImageName and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource ParallaxImage
        {
            get
            {
                return this.parallaxImage;
            }

            set
            {
                this.parallaxImage = value;
                this.RaisePropertyChanged("ParallaxImage");
            }
        }


        /// <summary>
        /// Gets or sets the value of ImageName and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource BuildingImage
        {
            get
            {
                return this.buildingImage;
            }

            set
            {
                this.buildingImage = value;
                this.RaisePropertyChanged("BuildingImage");
            }
        }


        /// <summary>
        /// Gets or sets the value of ImageName and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource CloudImage
        {
            get
            {
                return this.cloudImage;
            }

            set
            {
                this.cloudImage = value;
                this.RaisePropertyChanged("CloudImage");
            }
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
