#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EditingViewModel.cs" company="Syncfusion.com">
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
    /// A ViewModel for Editing sample.
    /// </summary>
    public class EditingViewModel : INotifyPropertyChanged
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<DealerInfo> dealerInformation;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, string[]> shipCities;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the EditingViewModel class.
        /// </summary>
        public EditingViewModel()
        {
            DealerRepository dealerrep = new DealerRepository();
            this.dealerInformation = dealerrep.GetDealerDetails(100);
            this.CustomerNames = dealerrep.Customers.ToObservableCollection();
            this.ShipCities = dealerrep.ShipCity;
            this.CountryList = new List<string>(this.ShipCities.Keys);
        }

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ItemsSource

        /// <summary>
        /// Gets or sets the value of DealerInformation
        /// </summary>
        public ObservableCollection<DealerInfo> DealerInformation
        {
            get { return this.dealerInformation; }
            set { this.dealerInformation = value; }
        }

        /// <summary>
        /// Gets or sets the value of CustomerNames
        /// </summary>
        public ObservableCollection<string> CustomerNames { get; set; }

        /// <summary>
        /// Gets or sets the ship cities.
        /// </summary>
        /// <value>The ship cities.</value>
        public Dictionary<string, string[]> ShipCities
        {
            get
            {
                return this.shipCities;
            }

            set
            {
                this.shipCities = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of countries.
        /// </summary>
        public List<string> CountryList { get; set; }

        #endregion

        #region Property Changed

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="propertyName">string type of propertyName</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}
