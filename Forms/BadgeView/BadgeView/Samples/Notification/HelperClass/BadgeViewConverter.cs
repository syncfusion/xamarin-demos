#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "BadgeViewConverter.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfBadgeView
{
    using System;
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    /// BadgeView Converter Class
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed.")]
    public class BadgeViewConverter : IValueConverter
	{
        /// <summary>
        /// This method is used to convert the string to color
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the target type</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>Return the color</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return Color.Black;
            }
            else
            {
                return Color.FromHex("#007cee");
            }
        }

        /// <summary>
        /// This method is used to convert back the color to string
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the target type</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>Returns the string</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
			return null;
        }
	}
}