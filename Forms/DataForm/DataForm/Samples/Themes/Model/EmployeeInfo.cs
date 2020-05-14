#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Syncfusion.XForms.DataForm;
using System.ComponentModel.DataAnnotations;

namespace SampleBrowser.SfDataForm
{
    public enum Gender
    {
        /// <summary>
        /// The male.
        /// </summary>
        Male,

        /// <summary>
        /// The female.
        /// </summary>
        Female
    }

    public enum Marital
    {
       /// <summary>
       /// The single.
       /// </summary>
        Single,

        /// <summary>
        /// The unmarried.
        /// </summary>
        Married
    }
    public class EmployeeInfo : INotifyPropertyChanged
    {
        /// <summary>
        /// The employee identifier.
        /// </summary>
        private string employeeID;

        /// <summary>
        /// The first name.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The gender.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// Represents the birth date of the employee.
        /// </summary>
        private DateTime dateofBirth = new DateTime(1995,05,14);

        /// <summary>
        /// The name of the father.
        /// </summary>
        private string fatherName;

        /// <summary>
        /// The name of the mother.
        /// </summary>
        private string motherName;

        /// <summary>
        /// The marital status.
        /// </summary>
        private Marital maritalStatus;

        /// <summary>
        /// Represents the email field of the employee.
        /// </summary>
        private string email;

        /// <summary>
        /// The address.
        /// </summary>
        private string address;

        /// <summary>
        /// The department.
        /// </summary>
        private string department;

        /// <summary>
        /// The team.
        /// </summary>
        private string team;

        /// <summary>
        /// The reporting person.
        /// </summary>
        private string reportingPerson;

        /// <summary>
        /// The name of the manager.
        /// </summary>
        private string managerName;

        /// <summary>
        /// The designation.
        /// </summary>
        private string designation;

        /// <summary>
        /// The date joined.
        /// </summary>
        private DateTime dateJoined = DateTime.Now.AddYears(-2);

        public EmployeeInfo()
        {
            
        }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Display(ShortName = "Employee ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your employee id.")]
        public string EmployeeID
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
         /// Gets or sets the first name of employee.
         /// </summary>
         /// <value>The first name.</value>
        [Display(ShortName = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name.")]
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
        /// Gets or sets the last name of employee.
        /// </summary>
        /// <value>The last name.</value>
        [Display(ShortName = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name.")]
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
        /// Gets or sets the gender of employee.
        /// </summary>
        /// <value>The gender.</value>
        [Display(ShortName = "Gender")]
        public Gender Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
                this.RaisePropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets or sets the dateof birth of employee.
        /// </summary>
        /// <value>The dateof birth.</value>
        [Display(ShortName = "Date of Birth")]
        public DateTime DateofBirth
        {
            get
            {
                return this.dateofBirth;
            }

            set
            {
                this.dateofBirth = value;
                this.RaisePropertyChanged("DateofBirth");
            }
        }

        /// <summary>
        /// Gets or sets the name of the father of employee.
        /// </summary>
        /// <value>The name of the father.</value>
        [Display(ShortName = "Father's Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your father's name.")]
        public string FatherName
        {
            get
            {
                return this.fatherName;
            }

            set
            {
                this.fatherName = value;
                this.RaisePropertyChanged("FatherName");
            }
        }

        /// <summary>
        /// Gets or sets the name of the mother of employee.
        /// </summary>
        /// <value>The name of the mother.</value>
        [Display(ShortName = "Mother's Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your mother's name.")]
        public string MotherName
        {
            get
            {
                return this.motherName;
            }

            set
            {
                this.motherName = value;
                this.RaisePropertyChanged("MotherName");
            }
        }

        /// <summary>
        /// Gets or sets the marital status of employee.
        /// </summary>
        /// <value>The marital status.</value>
        [Display(ShortName = "Marital Status")]
        public Marital MaritalStatus
        {
            get
            {
                return this.maritalStatus;
            }

            set
            {
                this.maritalStatus = value;
                this.RaisePropertyChanged("MaritalStatus");
            }
        }

        /// <summary>
        /// Gets or sets the address of employee.
        /// </summary>
        /// <value>The address.</value>
        [Display(ShortName = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address.")]
        [DataType(DataType.MultilineText)]
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
        /// Gets or sets the department of employee.
        /// </summary>
        /// <value>The department.</value>
        [Display(ShortName = "Department")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your department.")]
        public string Department
        {
            get
            {
                return this.department;
            }

            set
            {
                this.department = value;
                this.RaisePropertyChanged("Department");
            }
        }

        /// <summary>
        /// Gets or sets the team name of employee.
        /// </summary>
        /// <value>The team.</value>
        [Display(ShortName = "Team")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your team name.")]
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
        /// Gets or sets the name of reporting person.
        /// </summary>
        /// <value>The reporting person.</value>
        [Display(ShortName = "Reporting Person")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your reporting person name.")]
        public string ReportingPerson
        {
            get
            {
                return this.reportingPerson;
            }

            set
            {
                this.reportingPerson = value;
                this.RaisePropertyChanged("ReportingPerson");
            }
        }

        /// <summary>
        /// Gets or sets the name of the manager of employee.
        /// </summary>
        /// <value>The name of the manager.</value>
        [Display(ShortName = "Manager Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your manager name.")]
        public string ManagerName
        {
            get
            {
                return this.managerName;
            }

            set
            {
                this.managerName = value;
                this.RaisePropertyChanged("ManagerName");
            }
        }

        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>The email identifier.</value>
        [Display(ShortName = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail id.")]
        public string EmailID
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                this.RaisePropertyChanged("EmailID");
            }
        }

        /// <summary>
        /// Gets or sets the designation of employee.
        /// </summary>
        /// <value>The designation.</value>
        [Display(ShortName = "Designation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your designation.")]
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
        /// Gets or sets the date joined.
        /// </summary>
        /// <value>The date joined.</value>
        [Display(ShortName = "Date Joined")]
        public DateTime DateJoined
        {
            get
            {
                return this.dateJoined;
            }

            set
            {
                this.dateJoined = value;
                this.RaisePropertyChanged("DateJoined");
            }
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when propery value is changed.
        /// </summary>
        /// <param name="name">Property name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
