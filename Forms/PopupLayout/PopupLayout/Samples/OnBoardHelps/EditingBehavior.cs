#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EditingBehavior.cs" company="Syncfusion.com">
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
    using System.Threading.Tasks;
    using Xamarin.Forms;

    /// <summary>
    /// Editing Behavior class performs editing animation.
    /// </summary>
    public class EditingBehavior : Behavior<Image>
    {
        /// <summary>
        /// Holds the edit illustration image.
        /// </summary>
        private Image editIllustrationImage;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnAttachedTo(Image image)
        {
            base.OnAttachedTo(image);
            this.editIllustrationImage = image;
            this.AnimateEditIllustrationImage();
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnDetachingFrom(Image image)
        {
            base.OnDetachingFrom(image);
            this.editIllustrationImage = null;
        }

        /// <summary>
        /// Used animate edit Illustration Image
        /// </summary>
        private async void AnimateEditIllustrationImage()
        {
            // Default opacity value as zero and we set 1 as dynamically, we have dont this operation two time due to achive 
            // double click animate view.
            this.editIllustrationImage.Opacity = 0;
            await this.editIllustrationImage.FadeTo(1, 250);
            this.editIllustrationImage.Opacity = 0;
            await this.editIllustrationImage.FadeTo(1, 250);
            await Task.Delay(1000);
            this.AnimateEditIllustrationImage();
        }
    }
}