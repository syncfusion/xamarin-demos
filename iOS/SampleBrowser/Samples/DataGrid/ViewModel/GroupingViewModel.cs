#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser
{
    public class GroupingViewModel : NotificationObject
    {
        public GroupingViewModel()
        {
            ProductInfoRespository products = new ProductInfoRespository();
            ProductDetails = products.GetProductDetails(100);
        }

        private List<ProductInfo> productDetails;

        /// <summary>
        /// Gets or sets the product details.
        /// </summary>
        /// <value>The product details.</value>
        public List<ProductInfo> ProductDetails
        {
            get { return productDetails; }
            set
            {
                productDetails = value;
                RaisePropertyChanged("ProductDetails");
            }
        }
    }
}
