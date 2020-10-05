#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EmployeeInfo.cs" company="Syncfusion.com">
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
    public class EmployeeInfo : INotifyPropertyChanged
    {
        #region private variables

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int salary;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int employeeID;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string name;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string title;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string company;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int age;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double bonus;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool isavaialble;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string doj;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string imagename;

        #endregion

        /// <summary>
        /// Initializes a new instance of the EmployeeInfo class.
        /// </summary>
        public EmployeeInfo()
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
        /// Gets or sets the value of Name and notifies user when value gets changed
        /// </summary>
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
        /// Gets or sets the value of Age and notifies user when value gets changed
        /// </summary>
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        /// <summary>
        /// Gets or sets the value of Title and notifies user when value gets changed
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the value of Salary and notifies user when value gets changed
        /// </summary>
        public int Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                this.salary = value;
                this.RaisePropertyChanged("Salary");
            }
        }

        /// <summary>
        /// Gets or sets the value of Company and notifies user when value gets changed
        /// </summary>
        public string Company
        {
            get
            {
                return this.company;
            }

            set
            {
                this.company = value;
                this.RaisePropertyChanged("Company");
            }
        }

        /// <summary>
        /// Gets or sets the value of Bonus and notifies user when value gets changed
        /// </summary>
        public double Bonus
        {
            get
            {
                return this.bonus;
            }

            set
            {
                this.bonus = value;
                this.RaisePropertyChanged("Bonus");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsAvailable is true or false and notifies user when value gets changed
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                return this.isavaialble;
            }

            set
            {
                this.isavaialble = value;
                this.RaisePropertyChanged("IsAvailable");
            }
        }

        /// <summary>
        /// Gets or sets the value of DOJ and notifies user when value gets changed
        /// </summary>
        public string DOJ
        {
            get
            {
                return this.doj;
            }

            set
            {
                this.doj = value;
                this.RaisePropertyChanged("ShippingDate");
            }
        }

        /// <summary>
        /// Gets or sets the value of ImageName and notifies user when value gets changed
        /// </summary>
        public string ImageName
        {
            get
            {
                return this.imagename;
            }

            set
            {
                this.imagename = value;
                this.RaisePropertyChanged("ImageName");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation
     
        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type of parameter name</param>
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
