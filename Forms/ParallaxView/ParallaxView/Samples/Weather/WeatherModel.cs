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
    /// A class contains Properties and notifies when property value has changed 
    /// </summary>
    public class WeatherModel : INotifyPropertyChanged
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string temperature;
        private string day;
        private ImageSource weatherConditions;
        private string weatherDetails;


        /// <summary>
        /// Initializes a new instance of the WeatherData class.
        /// </summary>
        /// <param name="day">string type parameter named as day</param>
        public WeatherModel(string day,string temperature,string conditions,string details)
        {
            this.Day = day;
            this.temperature = temperature+ "°C" ;
            this.WeatherConditions = ImageSource.FromFile(conditions.ToString());
            this.weatherDetails = details;
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the value of Day and notifies user when collection value gets changed.
        /// </summary>
        public string Day
        {
            get
            {
                return this.day;
            }

            set
            {
                this.day = value;
                this.RaisePropertyChanged("Day");
            }
        }

        /// <summary>
        /// Gets or sets the value of Day and notifies user when collection value gets changed.
        /// </summary>
        public string Temperature
        {
            get
            {
                return this.temperature;
            }

            set
            {
                this.temperature = value;
                this.RaisePropertyChanged("Temperature");
            }
        }

        /// <summary>
        /// Gets or sets the value of Day and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource WeatherConditions
        {
            get
            {
                return this.weatherConditions;
            }

            set
            {
                this.weatherConditions = value;
                this.RaisePropertyChanged("WeatherConditions");
            }
        }

        /// <summary>
        /// Gets or sets the value of Day and notifies user when collection value gets changed.
        /// </summary>
        public string WeatherDetails
        {
            get
            {
                return this.weatherDetails;
            }

            set
            {
                this.weatherDetails = value;
                this.RaisePropertyChanged("WeatherDetails");
            }
        }


        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter named as name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
