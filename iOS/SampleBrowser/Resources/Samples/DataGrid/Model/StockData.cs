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
	public class StockData : INotifyPropertyChanged
	{
		#region Private Members

		private string symbol;
		private string account;
		private double lastTrade;
		private double stockChange;
		private double previousClose;
		private double open;
		private long volume;
        private string product;

		#endregion

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        /// <value>The Product.</value>
        public string Product
        {
            get
            {
                return product;
            }
            set
            {

                product = value;
                RaisePropertyChanged("Product");
            }
        }

		/// <summary>
		/// Gets or sets the stock change.
		/// </summary>
		/// <value>The stock change.</value>
		public double StockChange {
			get {
				return stockChange;
			}
			set {

				stockChange = value;
				RaisePropertyChanged ("StockChange");
			}
		}

		/// <summary>
		/// Gets or sets the open.
		/// </summary>
		/// <value>The open.</value>
		public double Open {
			get {
				return open;
			}
			set {

				open = value;
				RaisePropertyChanged ("Open");
			}
		}

		/// <summary>
		/// Gets or sets the last trade.
		/// </summary>
		/// <value>The last trade.</value>
		public double LastTrade {
			get {
				return lastTrade;
			}
			set {

				lastTrade = value;
				RaisePropertyChanged ("LastTrade");
			}
		}

		/// <summary>
		/// Gets or sets the previous close.
		/// </summary>
		/// <value>The previous close.</value>
		public double PreviousClose {
			get {
				return previousClose;
			}
			set {

				previousClose = value;
				RaisePropertyChanged ("PreviousClose");
			}
		}

		/// <summary>
		/// Gets or sets the symbol.
		/// </summary>
		/// <value>The symbol.</value>
		public string Symbol {
			get {
				return symbol;
			}
			set {

				symbol = value;
				RaisePropertyChanged ("Symbol");
			}
		}

		/// <summary>
		/// Gets or sets the account.
		/// </summary>
		/// <value>The account.</value>
		public string Account {
			get {
				return account;
			}
			set {

				account = value;
				RaisePropertyChanged ("Account");
			}
		}

		/// <summary>
		/// Gets or sets the volume.
		/// </summary>
		/// <value>The volume.</value>
		public long Volume {
			get {
				return volume;
			}
			set {

				volume = value;
				RaisePropertyChanged ("Volume");
			}
		}

		/// <summary>
		/// Initializes the on.
		/// </summary>
		/// <param name="other">The other.</param>
		public void InitializeOn (StockData other)
		{
			this.Symbol = other.Symbol;
			this.LastTrade = other.LastTrade;
			this.StockChange = other.StockChange;
			this.PreviousClose = other.PreviousClose;
			this.Open = other.Open;
			this.Volume = other.Volume;
            this.Product = other.Product;
		}


		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged (string propertyName)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}

		#endregion
	}
}

