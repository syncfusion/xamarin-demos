using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace SampleBrowser
{
    public class ContextMenuViewModel
    {
        public ContextMenuViewModel()
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
