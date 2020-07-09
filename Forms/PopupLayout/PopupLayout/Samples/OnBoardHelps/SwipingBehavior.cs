#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SwipingBehavior.cs" company="Syncfusion.com">
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
    /// Swiping Behavior class performs swiping animation.
    /// </summary>
    public class SwipingBehavior : Behavior<Image>
    {
        /// <summary>
        /// Holds the swiping illustration image.
        /// </summary>
        private Image swipeIllustrationImage;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnAttachedTo(Image image)
        {
            base.OnAttachedTo(image);
            this.swipeIllustrationImage = image;
            this.AnimateSwipeIllustration();
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnDetachingFrom(Image image)
        {
            base.OnDetachingFrom(image);
            this.swipeIllustrationImage = null;
        }

        /// <summary>
        /// used to animate swiping illustration.
        /// </summary>
        private async void AnimateSwipeIllustration()
        {
            await this.swipeIllustrationImage.TranslateTo(90, 0, 1800);
            await this.swipeIllustrationImage.TranslateTo(0, 0, 0);
            this.AnimateSwipeIllustration();
        }
    }
}