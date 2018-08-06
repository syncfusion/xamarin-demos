#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinIOInvoice
{
    # region Customer

    public class BillInfo
    {
        #region Fields / Properities

        private string _name = string.Empty;

        private string _date = string.Empty;

        private string _number = string.Empty;

        private string _address = string.Empty;


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {

                _date = value;
            }
        }

        public string InvoiceNumber
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {

                _address = value;
            }
        }

        #endregion

        public BillInfo() { }
    }

    # endregion
}
