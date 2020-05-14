#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace SampleBrowser
{
	public class EmployeeInformation : INotifyPropertyChanged
	{
		public EmployeeInformation ()
		{
		}

		#region Private Variables

		private int employeeID;
		private string firstName;
		private string lastName;
		private string designation;
		private DateTime birthDate;
		private DateTime hireDate;
		private string address;
		private string city;
		private string country;
		private string telePhone;
		private string qualification;

		#endregion

		#region Public Properties

		public int EmployeeID {
			get { return this.employeeID; }
			set {
				this.employeeID = value;
				this.RaisePropertyChanged ("EmployeeID");
			}
		}

		public string Designation {
			get { return this.designation; }
			set {
				this.designation = value;
				this.RaisePropertyChanged ("Designation");
			}
		}

		public string Qualification {
			get { return this.qualification; }
			set {
				this.qualification = value;
				this.RaisePropertyChanged ("Qualification");
			}
		}

		public string FirstName {
			get { return this.firstName; }
			set {
				this.firstName = value;
				this.RaisePropertyChanged ("FirstName");
			}
		}

		public string LastName {
			get { return this.lastName; }
			set {
				this.lastName = value;
				this.RaisePropertyChanged ("LastName");
			}
		}

		public DateTime DateOfBirth {
			get { return this.birthDate; }
			set {
				this.birthDate = value;
				this.RaisePropertyChanged ("DateOfBirth");
			}
		}

		public DateTime DateOfJoining {
			get { return this.hireDate; }
			set {
				this.hireDate = value;
				this.RaisePropertyChanged ("DateOfJoining");
			}
		}

		public string Address {
			get { return this.address; }
			set {
				this.address = value;
				this.RaisePropertyChanged ("Address");
			}
		}

		public string City {
			get { return this.city; }
			set {
				this.city = value;
				this.RaisePropertyChanged ("City");
			}
		}

		public string Country {
			get { return this.country; }
			set {
				this.country = value;
				this.RaisePropertyChanged ("Country");
			}
		}

		public string Telephone {
			get { return this.telePhone; }
			set {
				this.telePhone = value;
				this.RaisePropertyChanged ("Telephone");
			}
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged (String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (name));
		}

		#endregion
	}
}

