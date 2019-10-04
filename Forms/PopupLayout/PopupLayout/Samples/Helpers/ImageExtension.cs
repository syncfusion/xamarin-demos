#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ImageExtension.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfPopupLayout
{
    using System.Reflection;
    using Xamarin.Forms;

    /// <summary>
    /// A class that contains ImageExtensions.
    /// </summary>
    internal static class ImageExtension
    {
        /// <summary>
        /// Gets the Source for the given Image.
        /// </summary>
        /// <param name="imageName">The name of the image.</param>
        /// <returns>Returns the image source of the given Image.</returns>
        internal static ImageSource GetImageSource(this string imageName)
        {
#if COMMONSB
            return
 ImageSource.FromResource("SampleBrowser.Images." + imageName + ".png", typeof(ImageExtension).GetTypeInfo().Assembly);
#else
            return ImageSource.FromResource(
                "SampleBrowser.SfPopupLayout.Images." + imageName + ".png",
                typeof(ImageExtension).GetTypeInfo().Assembly);
#endif
        }
    }
}