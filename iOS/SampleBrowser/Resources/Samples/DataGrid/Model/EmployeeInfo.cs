#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace SampleBrowser
{
	public class EmployeeInfo:INotifyPropertyChanged
	{
		public EmployeeInfo ()
		{
		}

		#region private variables

		private int salary;
		private int employeeID;
		private string name;
		private string title;
		private string company;
		private int age;
		private int bonus;

		#endregion

		#region Public Properties

		public int EmployeeID {
			get { return employeeID; }
			set {
				this.employeeID = value;
				RaisePropertyChanged ("EmployeeID");
			}
		}

		public string Name {
			get { return this.name; }
			set {
				this.name = value;
				RaisePropertyChanged ("Name");
			}
		}

		public int Age {
			get{ return age; }
			set{ age = value; }
		}

		public string  Title {
			get { return title; }
			set { 
				this.title = value;
				RaisePropertyChanged ("Title");
			}
		}

		public int Salary {
			get { return salary; }
			set { 
				this.salary = value; 
				RaisePropertyChanged ("Salary"); 
			}
		}

		public string Company {
			get{ return company; }
			set{ company = value; }
		}

		public int Bonus {
			get{ return bonus; }
			set{ bonus = value; }
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


