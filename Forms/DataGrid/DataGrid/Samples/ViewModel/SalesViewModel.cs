#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SalesViewModel.cs" company="Syncfusion.com">
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
    /// A ViewModel for Sales class.
    /// </summary>
    public class SalesViewModel
    {
        #region Field

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<SalesByDate> dailySalesDetails = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the SalesViewModel class.
        /// </summary>
        public SalesViewModel()
        {
        }

        #endregion

        #region ItemsSource

        /// <summary>
        /// Gets the value of DailySalesDetails
        /// </summary>
        public ObservableCollection<SalesByDate> DailySalesDetails
        {
            get
            {
                if (this.dailySalesDetails == null)
                {
                    return new SalesRepository().GetSalesDetailsByDay(5);
                }
                else
                {
                    return this.dailySalesDetails;
                }
            }
        }

        #endregion
    }
}
