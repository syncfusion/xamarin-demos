#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ResizingBehavior.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfPopupLayout
{
    using Xamarin.Forms;

    /// <summary>
    /// Resizing Behavior class performs resizing animation.
    /// </summary>
    public class ResizingBehavior : Behavior<Image>
    {
        /// <summary>
        /// Holds the resizing illustration image.
        /// </summary>
        private Image resizingIllustrationImage;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnAttachedTo(Image image)
        {
            base.OnAttachedTo(image);
            this.resizingIllustrationImage = image;
            this.AnimateResizingIllustrationImage();
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnDetachingFrom(Image image)
        {
            base.OnDetachingFrom(image);
            this.resizingIllustrationImage = null;
        }

        /// <summary>
        /// Used to for animate the resizing illustration image.
        /// </summary>
        private async void AnimateResizingIllustrationImage()
        {
            // Move to left xposition
            await this.resizingIllustrationImage.TranslateTo(100, 0, 1000);
            //// Move to initial xposition
            await this.resizingIllustrationImage.TranslateTo(0, 0, 0);
            this.AnimateResizingIllustrationImage();
        }
    }
}