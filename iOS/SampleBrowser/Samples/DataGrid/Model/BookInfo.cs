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
    [Foundation.Preserve(AllMembers = true)]
    public class BookInfo : INotifyPropertyChanged
	{
		public BookInfo ()
		{
		}

		#region private variables

		private int bookID;
		private int customerID;
		private string firstName;
		private string lastName;
		private int price;
		private string bookName;
		private string country;

		#endregion

		#region Public Properties

		public int CustomerID {
			get { return customerID; }
			set {
				this.customerID = value;
				RaisePropertyChanged ("CustomerID");
			}
		}

		public int BookID {
			get { return bookID; }
			set { 
				this.bookID = value; 
				RaisePropertyChanged ("BookID"); 
			}
		}

		public string FirstName {
			get { return this.firstName; }
			set {
				this.firstName = value;
				RaisePropertyChanged ("FirstName");
			}
		}

		public string LastName {
			get { return this.lastName; }
			set {
				this.lastName = value;
				RaisePropertyChanged ("LastName");
			}
		}

		public string BookName {
			get { return bookName; }
			set { 
				this.bookName = value;
				RaisePropertyChanged ("BookName");
			}
		}

		public int Price {
			get { return price; }
			set { 
				this.price = value;
				RaisePropertyChanged ("Price");
			}
		}

		public string Country {
			get { return country; }
			set { 
				this.country = value;
				RaisePropertyChanged ("Country");
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

