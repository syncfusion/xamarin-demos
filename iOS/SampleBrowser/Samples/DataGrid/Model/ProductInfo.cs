#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;

namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
    public class ProductInfo : NotificationObject
	{
		#region Private Members

		private int productID;
		private string productModel;
		private int userRating;
		private string product;
		private bool availability;
		private double price;
		private int shippingDays;
		private string productType;

		#endregion

		#region Properties
		[Preserve]
		public int ProductID {
			get { return this.productID; }
			set {
				this.productID = value;
				this.RaisePropertyChanged ("ProductID");
			}
		}
		[Preserve]
		public string Product {
			get { return this.product; }
			set {
				this.product = value;
				this.RaisePropertyChanged ("Product");
			}
		}
		[Preserve]
		public int UserRating {
			get { return this.userRating; }
			set {
				this.userRating = value;
				this.RaisePropertyChanged ("UserRating");
			}
		}
		[Preserve]
		public string ProductModel {
			get { return this.productModel; }
			set {
				this.productModel = value;
				this.RaisePropertyChanged ("ProductModel");
			}
		}
		[Preserve]
		public double Price {
			get { return this.price; }
			set {
				this.price = value;
				this.RaisePropertyChanged ("Price");
			}
		}
		[Preserve]
		public int ShippingDays {
			get { return this.shippingDays; }
			set {
				this.shippingDays = value;
				this.RaisePropertyChanged ("ShippingDays");
			}
		}
		[Preserve]
		public bool Availability {
			get { return this.availability; }
			set {
				this.availability = value;
				this.RaisePropertyChanged ("Availability");
			}
		}
		[Preserve]
		public string ProductType {
			get { return this.productType; }
			set {
				this.productType = value;
				this.RaisePropertyChanged ("ProductType");
			}
		}

		#endregion
	}
}

