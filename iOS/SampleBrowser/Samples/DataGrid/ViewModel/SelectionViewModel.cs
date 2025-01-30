using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser
{
    public class SelectionViewModel : NotificationObject
    {
        public SelectionViewModel()
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
