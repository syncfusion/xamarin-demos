#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GroupingViewModel.cs" company="Syncfusion.com">
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
    /// A ViewModel for Grouping sample.
    /// </summary>
    public class GroupingViewModel : Employee
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<ProductInfo> productDetails;

        /// <summary>
        /// Initializes a new instance of the GroupingViewModel class.
        /// </summary>
        public GroupingViewModel()
        {
            ProductInfoRepository products = new ProductInfoRepository();
            this.ProductDetails = products.GetProductDetails(100);
        }

        /// <summary>
        /// Gets or sets the value of product details and notifies user when value gets changed
        /// </summary>
        /// <value>The product details.</value>
        public List<ProductInfo> ProductDetails
        {
            get
            {
                return this.productDetails;
            }

            set
            {
                this.productDetails = value;
                this.RaisePropertyChanged("ProductDetails");
            }
        }
    }
}
