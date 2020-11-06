#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "WeatherData.cs" company="Syncfusion.com">
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
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains Properties and notifies when property value has changed 
    /// </summary>
    public class WeatherData : INotifyPropertyChanged
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string id;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string day;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string imageName;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string month;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string selectedType;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double temperature;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string type;

        /// <summary>
        /// Initializes a new instance of the WeatherData class.
        /// </summary>
        /// <param name="day">string type parameter named as day</param>
        /// <param name="month">string type parameter named as month</param>
        /// <param name="temperature">string type parameter named as temperature</param>
        /// <param name="type">string type parameter named as type</param>
        /// <param name="selectedType">string type parameter named as selectedType</param>
        public WeatherData(string day, string month, double temperature, string type, string selectedType)
        {
            this.Day = day;
            this.Month = month;
            this.Temperature = temperature;
            this.SelectedType = selectedType;
            this.Type = type;
            this.ID = type;
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
        /// Gets or sets the value of Month and notifies user when collection value gets changed.
        /// </summary>
        public string Month
        {
            get
            {
                return this.month;
            }

            set
            {
                this.month = value;
                this.RaisePropertyChanged("Month");
            }
        }

        /// <summary>
        /// Gets or sets the value of Temperature and notifies user when collection value gets changed.
        /// </summary>
        public double Temperature
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
        /// Gets or sets the value of SelectedType and notifies user when collection value gets changed.
        /// </summary>
        public string SelectedType
        {
            get
            {
                return this.selectedType;
            }

            set
            {
                this.selectedType = value;
                this.RaisePropertyChanged("SelectedType");
            }
        }

        /// <summary>
        /// Gets or sets the value of ID and notifies user when collection value gets changed.
        /// </summary>
        public string ID
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
                this.RaisePropertyChanged("ID");
            }
        }

        /// <summary>
        /// Gets or sets the value of Type and notifies user when collection value gets changed.
        /// </summary>
        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
                this.ImageName = this.type;
            }
        }

        /// <summary>
        /// Gets or sets the value of ImageName and notifies user when collection value gets changed.
        /// </summary>
        public string ImageName
        {
            get
            {
                return this.imageName;
            }

            set
            {
                this.imageName = value;
                this.RaisePropertyChanged("ImageName");
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