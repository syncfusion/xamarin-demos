#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.ComponentModel;

namespace SampleBrowser
{
    public class CustomerDetails : INotifyPropertyChanged
	{
		#region private variables

		private string _customerID;
		private string _firstname;
		private string _lastname;
		private string _gender;
		private string _city;
		private string _country;

		#endregion

		#region Public Properties

		public string CustomerID {
			get {
				return _customerID;
			}
			set {
				this._customerID = value;
				RaisePropertyChanged ("CustomerID");
			}
		}

		public string FirstName {
			get { 
				return _firstname; 
			}
			set { 
				this._firstname = value;
				RaisePropertyChanged ("FirstName");
			}
		}

		public string LastName {
			get { 
				return _lastname; 
			}
			set { 
				this._lastname = value;
				RaisePropertyChanged ("LastName");
			}
		}

		public string Gender {
			get { 
				return _gender; 
			}
			set { 
				this._gender = value;
				RaisePropertyChanged ("Gender");
			}
		}

		public string City {
			get { 
				return _city; 
			}
			set { 
				this._city = value;
				RaisePropertyChanged ("City");
			}
		}

		public string Country {
			get { 
				return _country; 
			}
			set { 
				this._country = value;
				RaisePropertyChanged ("Country");
			}
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged (String Name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (Name));
		}

		#endregion
	}
}