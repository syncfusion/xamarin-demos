#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "RenderingDynamicDataViewModel.cs" company="Syncfusion.com">
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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.Data;
    using Syncfusion.Data.Extensions;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for RenderingDynamicData sample.
    /// </summary>
    public class RenderingDynamicDataViewModel : INotifyPropertyChanged
    {
        #region Members

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<StockData> data;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random r = new Random(123345345);
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int noOfUpdates = 500;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<string> stockSymbols = new List<string>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] accounts = new string[]
        {
            "American Funds",
            "College Savings",
            "Day Trading",
            "Mountain Range",
            "Fidelity Funds",
            "Mortages",
            "Housing Loans"
        };

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the RenderingDynamicDataViewModel class. 
        /// </summary>
        public RenderingDynamicDataViewModel()
        {
            this.data = new ObservableCollection<StockData>();
            this.AddRows(200);
            this.ResetRefreshFrequency(2500);
        }

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public ObservableCollection<StockData> Stocks
        {
            get { return this.data; }
        }

        /// <summary>
        /// Gets or sets the value of SelectedItem notifies user when value gets changed
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return this.noOfUpdates;
            }

            set
            {
                this.noOfUpdates = 2;
                this.RaisePropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets the value of ComboCollection
        /// </summary>
        public List<int> ComboCollection
        {
            get { return new List<int> { 500, 5000, 50000, 500000 }; }
        }

        #region Timer and updating code

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            Device.StartTimer(
                TimeSpan.FromMilliseconds(200),
                () =>
                {
                    Timer_Tick();
                    return true;
                });
        }

        /// <summary>
        /// Used to reset the refresh frequency
        /// </summary>
        /// <param name="changesPerTick">integer type parameter changesPerTick</param>
        public void ResetRefreshFrequency(int changesPerTick)
        {
            this.noOfUpdates = changesPerTick;
            this.StartTimer();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        private void Timer_Tick()
        {
            int startTime = DateTime.Now.Millisecond;
            this.noOfUpdates = 100;
            this.ChangeRows(this.noOfUpdates);
        }

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The given count.</param>
        private void AddRows(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                var newRec = new StockData();
                newRec.Symbol = this.ChangeSymbol();
                newRec.Account = this.ChangeAccount(i);
                newRec.Open = Math.Round(this.r.NextDouble() * 30, 2);
                newRec.LastTrade = Math.Round(1 + (this.r.NextDouble() * 50));
                double d = this.r.NextDouble();
                if (d < .5)
                {
                    newRec.StockChange = Math.Round(d, 2);
                }
                else
                {
                    newRec.StockChange = Math.Round(d, 2) * -1;
                }

                newRec.PreviousClose = Math.Round(this.r.NextDouble() * 30, 2);
                newRec.Volume = this.r.Next();
                this.data.Add(newRec);
            }
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <returns>returns builder value</returns>
        private string ChangeSymbol()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            do
            {
                builder = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor((26 * random.NextDouble()) + 65)));
                    builder.Append(ch);
                }
            }
            while (this.stockSymbols.Contains(builder.ToString()));
            this.stockSymbols.Add(builder.ToString());
            return builder.ToString();
        }

        /// <summary>
        /// Changes the account.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>returns the get calculated value</returns>
        private string ChangeAccount(int index)
        {
            return this.accounts[index % this.accounts.Length];
        }

        /// <summary>
        /// Changes the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void ChangeRows(int count)
        {
            if (this.data.Count < count)
            {
                count = this.data.Count;
            }

            for (int i = 0; i < count; ++i)
            {
                int recNo = this.r.Next(this.data.Count);
                StockData recRow = this.data[recNo];

                this.data[recNo].LastTrade = Math.Round(1 + (this.r.NextDouble() * 50));

                double d = this.r.NextDouble();
                if (d < .5)
                {
                    this.data[recNo].StockChange = Math.Round(d, 2);
                }
                else
                {
                    this.data[recNo].StockChange = Math.Round(d, 2) * -1;
                }

                this.data[recNo].Open = Math.Round(this.r.NextDouble() * 50, 2);
                this.data[recNo].PreviousClose = Math.Round(this.r.NextDouble() * 30, 2);
                this.data[recNo].Volume = this.r.Next();
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type of name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
