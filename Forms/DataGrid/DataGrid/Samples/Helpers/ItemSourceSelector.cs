#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ItemSourceSelector.cs" company="Syncfusion.com">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using Syncfusion.SfDataGrid.XForms;

    /// <summary>
    ///  Implementation class for ItemsSourceSelector interface
    /// </summary>
    public class ItemSourceSelector : IItemsSourceSelector
    {
        /// <summary>
        /// Implementation class for ItemsSourceSelector interface
        /// </summary>
        /// <param name="record"> The record </param>
        /// <param name="dataContext">The Binding Context</param>
        /// <returns>The Collection</returns>
        public IEnumerable GetItemsSource(object record, object dataContext)
        {
            if (record == null)
            {
                return null;
            }

            var orderinfo = record as DealerInfo;
            var countryName = orderinfo.ShipCountry;
            var viewModel = dataContext as EditingViewModel;

            // Returns ShipCity collection based on ShipCountry.
            if (viewModel.ShipCities.ContainsKey(countryName))
            {
                string[] shipcities = null;
                viewModel.ShipCities.TryGetValue(countryName, out shipcities);
                return shipcities.ToList();
            }

            return null;
        }
    }
}
