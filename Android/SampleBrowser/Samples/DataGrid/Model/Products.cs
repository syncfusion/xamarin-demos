#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace SampleBrowser
{
	public class Products : INotifyPropertyChanged
	{
		public Products ()
		{
		}

		#region private variables

		private int supplierID;
		private int productID;
		private string productName;
		private int quantity;
		private int unitPrice;
		private int unitsInStock;
        private string discount;

		#endregion

		#region Public Properties

		public int SupplierID {
			get { return supplierID; }
			set { 
				this.supplierID = value; 
				RaisePropertyChanged ("SupplierID"); 
			}
		}

		public int ProductID {
			get { return productID; }
			set {
				this.productID = value;
				RaisePropertyChanged ("ProductID");
			}
		}

		public string ProductName {
			get { return this.productName; }
			set {
				this.productName = value;
				RaisePropertyChanged ("ProductName");
			}
		}

        public int Quantity
        {
			get { return quantity; }
			set {
				this.quantity = value;
				RaisePropertyChanged ("Quantity"); 
			}
		}

		public int UnitPrice {
			get { return unitPrice; }
			set { 
				this.unitPrice = value;
				RaisePropertyChanged ("UnitPrice");
			}
		}

		public int UnitsInStock {
			get { return unitsInStock; }
			set { 
				this.unitsInStock = value;
				RaisePropertyChanged ("UnitsInStock");
			}
		}

        public string Discount
        {
            get { return this.discount; }
            set
            {
                this.discount = value;
                RaisePropertyChanged("Discount");
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

