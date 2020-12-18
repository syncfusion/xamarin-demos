#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using Android.Graphics;

namespace SampleBrowser
{
	public class BankInfo:INotifyPropertyChanged
	{
		public BankInfo ()
		{
		}

		#region private variables

		private int branchNo;
		private int customerID;
		private string customerName;
		private int savings;
		private int currentbalance;
		private int balanceScale;
		private bool isOpen;
		private Bitmap customerImage;

		#endregion

		#region Public Properties

		public int CustomerID {
			get { return customerID; }
			set {
				this.customerID = value;
				RaisePropertyChanged ("CustomerID");
			}
		}

		public int BranchNo {
			get { return branchNo; }
			set { 
				this.branchNo = value; 
				RaisePropertyChanged ("BranchNo"); 
			}
		}

		public string CustomerName {
			get { return this.customerName; }
			set {
				this.customerName = value;
				RaisePropertyChanged ("CustomerName");
			}
		}


		public int Savings {
			get { return savings; }
			set { 
				this.savings = value;
				RaisePropertyChanged ("Savings");
			}
		}

		public int Current {
			get { return currentbalance; }
			set { 
				this.currentbalance = value;
				RaisePropertyChanged ("CurrentBalance");
			}
		}

		public int BalanceScale {
			get { return this.balanceScale; }
			set { 
				this.balanceScale = value;
				RaisePropertyChanged ("BalanceScale");
			}
		}

		public bool IsOpen {
			get { return this.isOpen; }
			set {
				this.isOpen = value;
				RaisePropertyChanged ("IsOpen");
			}
		}

		public Bitmap CustomerImage {
			get { return this.customerImage; }
			set {
				this.customerImage = value;
				RaisePropertyChanged ("CustomerImage");
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

