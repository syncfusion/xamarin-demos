using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser
{
    public class UnboundViewModel
    {
        public UnboundViewModel()
        {
            ProductRepository product = new ProductRepository();
            products = product.GetProductDetails(100);
        }

        #region ItemsSource

        private ObservableCollection<Products> products;

        public ObservableCollection<Products> Products
        {
            get { return products; }
            set { this.products = value; }
        }

        #endregion
    }
}
