#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ImageConverter.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// Converter for returning the required image source.
    /// </summary>
    public class ImageConverter : IValueConverter
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double? data;

        #region IValueConverter implementation

        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <summary>Implement this method to convert <paramref name="value" /> to <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.</summary>
        /// <returns>To be added.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var assembly = Assembly.GetAssembly(Application.Current.GetType());
            this.data = value as double?;
            if (this.data != null && this.data > 0)
            {
#if COMMONSB
                return ImageSource.FromResource("SampleBrowser.Icons.DataGrid.GreenUp.png",assembly);
            }
			else
                {
                  return ImageSource.FromResource("SampleBrowser.Icons.DataGrid.RedDown.png",assembly);
                }
				
#else
                return ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.GreenUp.png", assembly);
            }
            else
            {
                return ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.RedDown.png", assembly);
            }
#endif
        }

        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <summary> Implement this method to convert <paramref name="value" /> back from <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.</summary>
        /// <returns> To be added.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.data;
        }

        #endregion
    }
}
