using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser
{
    public class FrozenViewViewModel
    {
        #region Constructor

        public FrozenViewViewModel()
        {
            SetRowstoGenerate(100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<Products> products;

        public ObservableCollection<Products> Products
        {
            get { return products; }
            set { this.products = value; }
        }

        #endregion

        #region ItemsSource Generator

        public void SetRowstoGenerate(int count)
        {
            ProductRepository product = new ProductRepository();
            products = product.GetProductDetails(count);
        }

        #endregion
    }
}
