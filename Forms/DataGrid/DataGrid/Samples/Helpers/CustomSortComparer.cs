#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomSortComparer.cs" company="Syncfusion.com">
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
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using Syncfusion.Data;
    using Xamarin.Forms;

    /// <summary>
    /// A class that compares two object
    /// </summary>
    public class CustomSortComparer : IComparer<object>, ISortDirection
    {
        /// <summary>
        /// Initializes a new instance of the CustomSortComparer class.
        /// </summary>
        public CustomSortComparer()
        {
        }

        /// <summary>
        /// Gets or sets the value of SortDirection
        /// </summary>
        public Syncfusion.Data.ListSortDirection SortDirection { get; set; }

        /// <summary>
        /// Used to compare the x and y value
        /// </summary>
        /// <param name="x">object type of comparer x value</param>
        /// <param name="y">object type of comparer y value</param>
        /// <returns>sort description</returns>
        public int Compare(object x, object y)
        {
            double namX;
            double namY;
            if (x.GetType() == typeof(SalesByDate))
            {
                namX = ((SalesByDate)x).Total;
                namY = ((SalesByDate)y).Total;
            }
            else if (x.GetType() == typeof(Group))
            {
                namX = this.ConverKeyToDouble((string)((Group)x).Key);
                namY = this.ConverKeyToDouble((string)((Group)y).Key);
            }
            else
            {
                namX = (double)x;
                namY = (double)y;
            }

            // Objects are compared and return the SortDirection
            if (namX > namY)
            {
                return this.SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? 1 : -1;
            }               
            else
            {
                return this.SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? -1 : 1;
            }              
        }

        /// <summary>
        /// Gets the value for a given key
        /// </summary>
        /// <param name="key">string type of key value</param>
        /// <returns>returns the key value</returns>
        private double ConverKeyToDouble(string key)
        {
            if (key.Equals("<1 K"))
            {
                return 0;
            }
            else if (key.Equals(">1 K and <5 K"))
            {
                return 1;
            }
            else if (key.Equals(">5 K and <10 K"))
            {
                return 2;
            }
            else if (key.Equals(">10 K and <50 K"))
            {
                return 3;
            }
            else if (key.Equals(">50 K"))
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
