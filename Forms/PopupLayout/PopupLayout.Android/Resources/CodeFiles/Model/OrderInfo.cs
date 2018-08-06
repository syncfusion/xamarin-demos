#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfPopupLayout
{
    [Preserve(AllMembers = true)]
    public class OrderInfo : INotifyPropertyChanged
	{
		public OrderInfo ()
		{
		}

		#region private variables

		private string _orderID;
		private string _employeeID;
		private string _customerID;
		private string _shipCountry;

		#endregion

		#region Public Properties

		public string OrderID {
			get {
				return _orderID; 
			}
			set { 
				this._orderID = value; 
				RaisePropertyChanged ("OrderID"); 
			}
		}

		public string EmployeeID {
			get { 
				return _employeeID; 
			}
			set { 
				this._employeeID = value;
				RaisePropertyChanged ("EmployeeID");
			}
		}

		public string CustomerID {
			get {
				return _customerID;
			}
			set {
				this._customerID = value;
				RaisePropertyChanged ("CustomerID");
			}
		}

		public string ShipCountry {
			get { 
				return _shipCountry; 
			}
			set { 
				this._shipCountry = value;
				RaisePropertyChanged ("ShipCountry");
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

