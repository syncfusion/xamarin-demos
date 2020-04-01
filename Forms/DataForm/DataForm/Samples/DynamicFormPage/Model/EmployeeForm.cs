#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Internals;
using System.ComponentModel.DataAnnotations;

namespace SampleBrowser.SfDataForm
{
    /// <summary>
    /// Represents the Employee information of the data form dynamic forms sample.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class EmployeeForm : INotifyPropertyChanged
    {
        #region Fields       
        /// <summary>
        /// Represents the name of the employee information.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the last name of the employee information.
        /// </summary>
        private string lastname;

        /// <summary>
        /// Represents the phone number of the employee information.
        /// </summary>
        private string phonenumber;

        /// <summary>
        /// Represents the country of the employee information.
        /// </summary>
        private string country;

        /// <summary>
        /// Represents the address of the employee information.
        /// </summary>
        private string employeeAddress;

        /// <summary>
        /// Represents the city of the employee information.
        /// </summary>
        private string city;

        /// <summary>
        /// Represents the first zip of the employee information.
        /// </summary>
        private string employeeZip;

        /// <summary>
        /// Represents the team of the employee information.
        /// </summary>
        private string team;

        /// <summary>
        /// Represents the track hours of the employee information.
        /// </summary>
        private bool trackhours;

        /// <summary>
        /// Represents the type here of the employee information.
        /// </summary>
        private string typehere;
        #endregion

        public EmployeeForm()
        {

        }

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties  
        /// <summary>
        /// Gets or sets the name field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4 , ShowLabel = false)]
        [Display(Prompt ="Enter name")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the last name field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4 , ShowLabel = false)]
        [Display(Prompt = "Enter last name")]
        public string LastName
        {
            get
            {
                return this.lastname;
            }
            set
            {
                this.lastname = value;
                this.RaisePropertyChanged("LastName");

            }
        }

        /// <summary>
        /// Gets or sets the phone number field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4 , ShowLabel = false)]
        [Display(Prompt = "Enter phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber
        {
            get
            {
                return this.phonenumber;
            }
            set
            {
                this.phonenumber = value;
                this.RaisePropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets the country field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4, ShowLabel = false)]
        [Display(Prompt = "Enter country")]
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
                this.RaisePropertyChanged("Country");
            }
        }

        /// <summary>
        /// Gets or sets the address field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4 , ShowLabel = false)]
        [Display(Prompt = "Enter address")]
        [DataType(DataType.MultilineText)]
        public string EmployeeAddress
        {
            get
            {
                return this.employeeAddress;
            }
            set
            {
                this.employeeAddress = value;
                this.RaisePropertyChanged("EmployeeAddress");
            }
        }

        /// <summary>
        /// Gets or sets the city field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 2, ShowLabel = false)]
        [Display(Prompt = "Enter city")]
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                this.RaisePropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets the zip1 field.
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        [Display(Prompt = " Enter zip")]
        [DisplayOptions(ColumnSpan = 2 , ShowLabel = false)]
        public string EmployeeZip
        {
            get
            {
                return this.employeeZip;
            }
            set
            {
                this.employeeZip = value;
                this.RaisePropertyChanged("EmployeeZip");
            }
        }

        /// <summary>
        /// Gets or sets the team field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4 , ShowLabel = false)]
        [Display(Prompt = "Enter team name")]
        public string Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value;
                this.RaisePropertyChanged("Team");
            }
        }

        /// <summary>
        /// Gets or sets the track hours field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4)]
        [Display(ShortName = "Track hours")]
        public bool Trackhours
        {
            get
            {
                return this.trackhours;
            }
            set
            {
                this.trackhours = value;
                this.RaisePropertyChanged("Trackhours");
            }
        }

        /// <summary>
        /// Gets or sets the type here field.
        /// </summary>
        [DisplayOptions(ColumnSpan = 4 , ShowLabel = false)]
        [Display(Prompt = "Enter your comments")]
        [DataType(DataType.MultilineText)]
        public string Typehere
        {
            get
            {
                return typehere;
            }
            set
            {
                typehere = value;
                this.RaisePropertyChanged("Typehere");
            }
        }
        #endregion
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
