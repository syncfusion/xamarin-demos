#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomerInfo.cs" company="Syncfusion.com">
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
    /// A class for comparing CustomerInfo Objects
    /// </summary>
    public class CustomerInfo : IComparer<object>, ISortDirection
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int namX;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int namY;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        //// Get or Set the SortDirection value
        private Syncfusion.Data.ListSortDirection sortDirection;

        /// <summary>
        /// Gets or sets the value of SortDirection
        /// </summary>
        public Syncfusion.Data.ListSortDirection SortDirection
        {
            get { return this.sortDirection; }
            set { this.sortDirection = value; }
        }

        /// <summary>
        /// Used to compare the x and y value
        /// </summary>
        /// <param name="x">object type of comparer x value</param>
        /// <param name="y">object type of comparer y value</param>
        /// <returns>sort description</returns>
        public int Compare(object x, object y)
        {
            //// For Customers Type data
            //// else if => For Group type Data   

            if (x.GetType() == typeof(CustomerDetails))
            {
                //// Calculating the length of CustomerName if the object type is Customers
                this.namX = ((CustomerDetails)x).FirstName.Length;
                this.namY = ((CustomerDetails)y).FirstName.Length;
            }
            else if (x.GetType() == typeof(Group))
            {
                //// Calculating the group key length
                this.namX = ((Group)x).Key.ToString().Length;
                this.namY = ((Group)y).Key.ToString().Length;
            }
            else
            {
                this.namX = x.ToString().Length;
                this.namY = y.ToString().Length;
            }

            //// Objects are compared and return the SortDirection
            if (this.namX.CompareTo(this.namY) > 0)
            {
                return this.SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? 1 : -1;
            }
            else if (this.namX.CompareTo(this.namY) == -1)
            {
                return this.SortDirection == Syncfusion.Data.ListSortDirection.Ascending ? -1 : 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
