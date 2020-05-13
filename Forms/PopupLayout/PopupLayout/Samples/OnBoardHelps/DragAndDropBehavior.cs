#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DragAndDropBehavior.cs" company="Syncfusion.com">
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
    /// Drag and drop Behavior class performs drag and drop animation.
    /// </summary>
    public class DragAndDropBehavior : Behavior<Image>
    {
        /// <summary>
        /// Holds the hand symbol of the drag and drop layout.
        /// </summary>
        private Image handSymbol;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnAttachedTo(Image image)
        {
            base.OnAttachedTo(image);
            this.handSymbol = image;
            this.AnimateDragAndDropIllustration();
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="image">Image which is attached.</param>
        protected override void OnDetachingFrom(Image image)
        {
            base.OnDetachingFrom(image);
            this.handSymbol = null;
        }

        /// <summary>
        /// used to animate drag and drop image illustration.
        /// </summary>
        private async void AnimateDragAndDropIllustration()
        {
            this.handSymbol.AnchorY = 10;
            //// Rotate View to 10 degree
            await this.handSymbol.RotateTo(10, 500);

            ////transalte View to based on x, y point
            await this.handSymbol.TranslateTo(25, 25, 500);

            ////Reset rotaion,x,y position
            this.handSymbol.Rotation = 0;
            await this.handSymbol.TranslateTo(0, 0, 0);

            this.AnimateDragAndDropIllustration();
        }
    }
}
