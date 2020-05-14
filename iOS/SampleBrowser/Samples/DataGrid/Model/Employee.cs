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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
    public class NotificationObject : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged Implementation

		public void RaisePropertyChanged (string propName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propName));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}

	public class BaseEmployee : NotificationObject
	{
		#region Private variable

		private int employeeID;

		#endregion

		#region Public property

		public int EmployeeID {
			get { return this.employeeID; }
			set {
				this.employeeID = value;
				this.RaisePropertyChanged ("EmployeeID");
			}
		}

		#endregion
	}

	public class Employee : BaseEmployee
	{
		#region Private variables

		private string name;
		private int contactID;
		private string title;
		private DateTime birthDate;
		private string gender;
		private double sickLeaveHours;
		private decimal salary;

		#endregion

		#region Public Property

		public int ContactID {
			get { return this.contactID; }
			set {
				this.contactID = value;
				this.RaisePropertyChanged ("ContactID");
			}
		}

		public string Name {
			get { return this.name; }
			set {
				this.name = value;
				this.RaisePropertyChanged ("Name");
			}
		}

		public decimal Salary {
			get { return this.salary; }
			set {
				this.salary = value;
				this.RaisePropertyChanged ("Salary");
			}
		}

		public string Title {
			get { return this.title; }
			set {
				this.title = value;
				this.RaisePropertyChanged ("Title");
			}
		}

		public DateTime BirthDate {
			get { return this.birthDate; }
			set {
				this.birthDate = value;
				this.RaisePropertyChanged ("BirthDate");
			}
		}

		public string Gender {
			get { return this.gender; }
			set {
				this.gender = value;
				this.RaisePropertyChanged ("Gender");
			}
		}

		public double SickLeaveHours {
			get { return this.sickLeaveHours; }
			set {
				this.sickLeaveHours = value;
				this.RaisePropertyChanged ("SickLeaveHours");
			}
		}

		#endregion
	}
}
