#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GroupDataTimeConverter.cs" company="Syncfusion.com">
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
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using Syncfusion.Data;
    using Xamarin.Forms;

    /// <summary>
    /// Converter for CustomGrouping sample.
    /// </summary>
    public class GroupDataTimeConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the GroupDataTimeConverter class.
        /// </summary>
        public GroupDataTimeConverter()
        {
        }

        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <summary>Implement this method to convert <paramref name="value" /> to <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.</summary>
        /// <returns>To be added.</returns>
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var saleinfo = value as SalesByDate;
            if (saleinfo.Total > 1000 && saleinfo.Total < 5000)
            {
                return ">1 K and <5 K";
            }
            else if (saleinfo.Total > 5000 && saleinfo.Total < 10000)
            {
                return ">5 K and <10 K";
            }
            else if (saleinfo.Total > 10000 && saleinfo.Total < 50000)
            {
                return ">10 K and <50 K";
            }
            else if (saleinfo.Total > 20000 && saleinfo.Total < 50000)
            {
                return ">20 K and <50 K";
            }
            else if (saleinfo.Total > 50000)
            {
                return ">50 K";
            }
            else
            {
                return "<1 K";
            }
        }

        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <summary> Implement this method to convert <paramref name="value" /> back from <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.</summary>
        /// <returns> To be added.</returns>
        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
