#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "UnBoundColumnViewModel.cs" company="Syncfusion.com">
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
    /// A ViewModel for UnBoundColumn sample.
    /// </summary>
    public class UnBoundColumnViewModel
    {
        #region Field

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<Product> products;

        #endregion

        /// <summary>
        /// Initializes a new instance of the UnBoundColumnViewModel class.
        /// </summary>
        public UnBoundColumnViewModel()
        {
            ProductRepository product = new ProductRepository();
            this.products = product.GetProductDetails(100);
        }

        #region ItemsSource

        /// <summary>
        /// Gets or sets the value of Products
        /// </summary>
        public List<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        #endregion

        #region ItemSource Generator

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        public void SetRowstoGenerate(int count)
        {
            ProductRepository product = new ProductRepository();
            this.products = product.GetProductDetails(100);
        }

        #endregion
    }
}
