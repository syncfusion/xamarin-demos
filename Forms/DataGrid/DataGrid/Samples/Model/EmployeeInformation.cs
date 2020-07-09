#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EmployeeInformation.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains properties and notifies clients that a property value has changed.
    /// </summary>
    public class EmployeeInformation : INotifyPropertyChanged
    {
        #region Private Variables

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int employeeID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string firstName;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string lastName;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string designation;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DateTime birthDate;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DateTime hireDateTime;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string address;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string city;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string country;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string telePhone;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string qualification;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string hireDate;

        #endregion

        /// <summary>
        /// Initializes a new instance of the EmployeeInformation class.
        /// </summary>
        public EmployeeInformation()
        {
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of EmployeeID and notifies user when value gets changed
        /// </summary>
        public int EmployeeID
        {
            get
            {
                return this.employeeID;
            }

            set
            {
                this.employeeID = value;
                this.RaisePropertyChanged("EmployeeID");
            }
        }

        /// <summary>
        /// Gets or sets the value of Designation and notifies user when value gets changed
        /// </summary>
        public string Designation
        {
            get
            {
                return this.designation;
            }

            set
            {
                this.designation = value;
                this.RaisePropertyChanged("Designation");
            }
        }

        /// <summary>
        /// Gets or sets the value of Qualification and notifies user when value gets changed
        /// </summary>
        public string Qualification
        {
            get
            {
                return this.qualification;
            }

            set
            {
                this.qualification = value;
                this.RaisePropertyChanged("Qualification");
            }
        }

        /// <summary>
        /// Gets or sets the value of FirstName and notifies user when value gets changed
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
                this.RaisePropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets the value of LastName and notifies user when value gets changed
        /// </summary>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
                this.RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets the value of DateOfBirth and notifies user when value gets changed
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                this.birthDate = value;
                this.RaisePropertyChanged("DateOfBirth");
            }
        }

        /// <summary>
        /// Gets or sets the value of DateOfJoining and notifies user when value gets changed
        /// </summary>
        public DateTime DateOfJoining
        {
            get
            {
                return this.hireDateTime;
            }

            set
            {
                this.hireDateTime = value;
                this.RaisePropertyChanged("DateOfJoining");
            }
        }

        /// <summary>
        /// Gets or sets the value of Address and notifies user when value gets changed
        /// </summary>
        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
                this.RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the value of City and notifies user when value gets changed
        /// </summary>
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
        /// Gets or sets the value of Country and notifies user when value gets changed
        /// </summary>
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
        /// Gets or sets the value of Telephone and notifies user when value gets changed
        /// </summary>
        public string Telephone
        {
            get
            {
                return this.telePhone;
            }

            set
            {
                this.telePhone = value;
                this.RaisePropertyChanged("Telephone");
            }
        }

        /// <summary>
        /// Gets or sets the value of HireDate and notifies user when value gets changed
        /// </summary>
        public string HireDate
        {
            get
            {
                return this.hireDate;
            }

            set
            {
                this.hireDate = value;
                this.RaisePropertyChanged("Telephone");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter name</param>
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