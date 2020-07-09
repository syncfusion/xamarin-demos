#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ImageResourceExtension.cs" company="Syncfusion.com">
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
  
    [ContentProperty("Source")]
    [Preserve(AllMembers = true)]

    /// <summary>
    ///  Returns the object created from the markup extension.
    /// </summary>
    public class ImageResourceExtension : IMarkupExtension
    {
        /// <summary>
        /// Gets or sets the value for Source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Used to provide the image source value
        /// </summary>
        /// <param name="serviceProvider">IServiceProvider type parameter</param>
        /// <returns>IServiceProvider type of image Source</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Source == null)
            {
                return null;
            }               

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(this.Source);

            return imageSource;
        }
    }   
}