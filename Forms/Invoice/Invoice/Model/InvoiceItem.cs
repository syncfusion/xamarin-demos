#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  XamarinIOInvoice
{
    # region InVoiceItem

    public class InvoiceItem
    {
        #region Fields / Properties

        private string _item;

        private string _quantity = "0";

        private string _rate = "899";

        private string _taxes = "15";

        private string _totalAmount = "0";

       
        public string ItemName
        {
            get
            {
                return _item;
            }
            set
            {
                _item=value;
            }
        }
        public string Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                UpdateTotalAmount();
            }
        }

        public string Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
                UpdateTotalAmount();
            }
        }
        public string Taxes
        {
            get
            {
                return _taxes;
            }
            set
            {
                _taxes = value;
                UpdateTotalAmount();
            }
        }
        public string TotalAmount
        {
            get
            {
                return  _totalAmount;
            }
            set
            {
                _totalAmount = value;
            }
        }
        #endregion

        #region Methods / Events

        void UpdateTotalAmount()
        {
            TotalAmount = "$ " + Product.CalcuateTotal(_rate, _quantity, _taxes).ToString ();

        }

        #endregion
    }

    # endregion
}
