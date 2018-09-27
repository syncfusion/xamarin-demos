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
    # region Product

    public static class Product
    {
        # region Fields / Properties

        public static string WinRT = "WinRT";

        public static string WinRTRate = "399";

        public static string WinRTax = "7";

        public static string WindowsPhone = "Windows Phone";

        public static string WindowsPhoneRate = "99";

        public static string WindowsPhoneTax = "7";

        public static string HTML = "HTML5/JavaScript";

        public static string HTMLRate = "599";

        public static string HTMLTax = "7";

        public static string OruBase = "OruBase";

        public static string OruBaseRate = "995";

        public static string OruBaseTax = "7";

        # endregion

        #region Methods / Events

        public static double CalcuateTotal(string rate, string quantity, string tax)
        {
            return Convert.ToDouble(rate.Replace("$ ", "")) * Convert.ToDouble(quantity.Replace("Quantity: ", "")) + (Convert.ToDouble(rate.Replace("$ ", "")) * (Convert.ToDouble(tax.Replace("$ ", "")) / 100));
        }

    #endregion
    }

    #endregion
}
