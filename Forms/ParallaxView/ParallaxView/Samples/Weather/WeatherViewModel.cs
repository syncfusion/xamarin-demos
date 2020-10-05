#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        private ObservableCollection<WeatherModel> selectedData;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource parallaxImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource buildingImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource cloudImage;
        private string weatherImage;

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
        public ObservableCollection<WeatherModel> SelectedData
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
        private ObservableCollection<WeatherModel> GetWeatherData()
        {
            DateTime now = DateTime.Now;
            Assembly assembly = typeof(WeatherViewModel).GetTypeInfo().Assembly;
            ObservableCollection<WeatherModel> array = new ObservableCollection<WeatherModel>();          
            for (int i = 0; i < 7; i++)
            {
                now = DateTime.Now.AddDays(i);
                string date = string.Empty + now.DayOfWeek + ", " + string.Empty + now.ToString("MMMM") + " " + now.Date.Day;
                var temperature= weatherdegrees[i];
                if (i == 0)
                {
                    weatherImage = "Thunder.png";
                }
                else if (i == 1)
                {
                    weatherImage = "Sunny.png";
                }
                else if (i == 2)
                {
                    weatherImage = "Foggy.png";
                }
                else if (i == 3)
                {
                    weatherImage = "RainyWeather.png";
                }
                else if (i == 4)
                {
                    weatherImage = "CloudSunny.png";
                }
                else if (i == 5)
                {
                    weatherImage = "Weather.png";
                }
                else if (i == 6)
                {
                    weatherImage = "Snowfall.png";
                }

                var weatherDetails = weatherConditions[i];
                WeatherModel data = new WeatherModel(date,temperature, weatherImage,weatherDetails);

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
