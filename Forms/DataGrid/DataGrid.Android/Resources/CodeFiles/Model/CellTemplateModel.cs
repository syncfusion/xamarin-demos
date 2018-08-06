#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataGrid
{
    [Preserve(AllMembers = true)]
    public class CellTemplateModel
	{
		#region Private Variables

		private int employeeID;
		private string firstName;
		private string designation;
		private DateTime birthDate;
		private ImageSource image;
		private string city;
		private string country;
		private string telePhone;
		private string about;

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
			
		public string Name {
			get { return this.firstName; }
			set {
				this.firstName = value;
				this.RaisePropertyChanged ("FirstName");
			}
		}
			
		public DateTime DateOfBirth {
			get { return this.birthDate; }
			set {
				this.birthDate = value;
				this.RaisePropertyChanged ("DateOfBirth");
			}
		}
			
		public ImageSource Image {
			get { return this.image; }
			set {
				this.image = value;
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

		public string About
		{
			get { return this.about; }
			set {
				this.about = value;
				this.RaisePropertyChanged ("About");
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

