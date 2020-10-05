#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using UIKit;

namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
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
		private int balancescale;
		private bool isopen;
		private int transaction;
		private UIImage customerImage;

		#endregion

		#region Public Properties

		public int CustomerID {
			get { return customerID; }
			set {
				this.customerID = value;
				RaisePropertyChanged ("Customer ID");
			}
		}

		public int BranchNo {
			get { return branchNo; }
			set { 
				this.branchNo = value; 
				RaisePropertyChanged ("Branch No"); 
			}
		}

		public string CustomerName {
			get { return this.customerName; }
			set {
				this.customerName = value;
				RaisePropertyChanged ("Customer Name");
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
			get {
				return balancescale;
			}
			set {
				balancescale = value;
				RaisePropertyChanged ("BalanceScale");
			}
		}

		public bool IsOpen {
			get {
				return isopen;
			}
			set {
				isopen = value;
				RaisePropertyChanged ("IsOpen");
			}
		}

		public UIImage CustomerImage {
			get {
				return customerImage;
			}
			set {
				customerImage = value;
			}
		}

		public int Transactions {
			get { return transaction; }
			set { 
				this.transaction = value;
				RaisePropertyChanged ("ChartValue");
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

