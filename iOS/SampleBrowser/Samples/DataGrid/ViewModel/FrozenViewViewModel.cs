#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
