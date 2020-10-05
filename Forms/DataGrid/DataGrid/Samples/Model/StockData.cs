#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "StockData.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains properties and notifies clients that a property value has changed.
    /// </summary>  
    public class StockData : INotifyPropertyChanged
    {
        #region Private Members

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string symbol;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string account;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double lastTrade;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double stockChange;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double previousClose;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double open;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private long volume;

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public properties

        /// <summary>
        /// Gets or sets the stock change.
        /// </summary>
        /// <value>The stock change.</value>
        public double StockChange
        {
            get
            {
                return this.stockChange;
            }

            set
            {
                this.stockChange = value;
                this.RaisePropertyChanged("StockChange");
            }
        }

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        /// <value>The open.</value>
        public double Open
        {
            get
            {
                return this.open;
            }

            set
            {
                this.open = value;
                this.RaisePropertyChanged("Open");
            }
        }

        /// <summary>
        /// Gets or sets the last trade.
        /// </summary>
        /// <value>The last trade.</value>
        public double LastTrade
        {
            get
            {
                return this.lastTrade;
            }

            set
            {
                this.lastTrade = value;
                this.RaisePropertyChanged("LastTrade");
            }
        }

        /// <summary>
        /// Gets or sets the previous close.
        /// </summary>
        /// <value>The previous close.</value>
        public double PreviousClose
        {
            get
            {
                return this.previousClose;
            }

            set
            {
                this.previousClose = value;
                this.RaisePropertyChanged("PreviousClose");
            }
        }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }

            set
            {
                this.symbol = value;
                this.RaisePropertyChanged("Symbol");
            }
        }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>The account.</value>
        public string Account
        {
            get
            {
                return this.account;
            }

            set
            {
                this.account = value;
                this.RaisePropertyChanged("Account");
            }
        }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        public long Volume
        {
            get
            {
                return this.volume;
            }

            set
            {
                this.volume = value;
                this.RaisePropertyChanged("Volume");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the on.
        /// </summary>
        /// <param name="other">The other.</param>
        public void InitializeOn(StockData other)
        {
            this.Symbol = other.Symbol;
            this.LastTrade = other.LastTrade;
            this.StockChange = other.StockChange;
            this.PreviousClose = other.PreviousClose;
            this.Open = other.Open;
            this.Volume = other.Volume;
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="propertyName">string type of parameter propertyName</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}