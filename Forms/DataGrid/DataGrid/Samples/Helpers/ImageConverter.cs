#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ImageConverter.cs" company="Syncfusion.com">
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
                if (parameter is Label)
                {
                    var label = parameter as Label;
                    label.FontFamily = "./Assets/Fonts/#SB Icons";
                    label.TextColor = Color.FromRgb(76, 175, 80);
                    return "\ue727";
                }

                return new FontImageSource
                {
                    Glyph = "\ue727",
                    FontFamily = (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.macOS) ? "SB Icons" : Device.RuntimePlatform == Device.Android ? "SB Icons.ttf#" : "SB Icons.ttf#SB Icons",
                    Color = Color.FromRgb(76, 175, 80)
                };
            }
            else
            {
                if (parameter is Label)
                {
                    var label = parameter as Label;
                    label.FontFamily = "./Assets/Fonts/#SB Icons";
                    label.TextColor = Color.FromRgb(239, 83, 80);
                    return "\ue729";
                }

                return new FontImageSource
                {
                    Glyph = "\ue729",
                    FontFamily = (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.macOS) ? "SB Icons" : Device.RuntimePlatform == Device.Android ? "SB Icons.ttf#" : "SB Icons.ttf#SB Icons",
                    Color = Color.FromRgb(239, 83, 80)
                };
            }
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
