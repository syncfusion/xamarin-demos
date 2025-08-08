#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfCarousel.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfCarousel
{
    /// <summary>
    /// Carousel tablet.
    /// </summary>
    public partial class Carousel_Tablet : SampleView
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfCarousel.Carousel_Tablet"/> class.
        /// </summary>
        public Carousel_Tablet()
        {
            InitializeComponent();
            modePicker.SelectedIndex = 0;
            carousel.BindingContext = new CarouselViewModel();
            DeviceChanges();
        }

        #endregion

        #region device changes

        /// <summary>
        /// Devices the changes.
        /// </summary>
        void DeviceChanges()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                carousel.ItemHeight = 200;
                carousel.ItemWidth = 150;

            }
            if (Device.RuntimePlatform == Device.Android)
            {
                carousel.ItemHeight = Convert.ToInt32(300);
                carousel.ItemWidth = Convert.ToInt32(180);
                carousel.ScaleOffset = (float)0.70;
            }
        }

        #endregion


        #region viewmode changes

        /// <summary>
        /// Viewmodes the picker selected index changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void viewmodePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (modePicker.SelectedIndex)
            {
                case 0:
                    carousel.ViewMode = ViewMode.Default;
                    break;
                case 1:
                    carousel.ViewMode = ViewMode.Linear;
                    break;
            }
        }

        #endregion

        #region offset changes

        /// <summary>
        /// Offsets the value changed.
        /// </summary>
        /// <param name="c">C.</param>
        /// <param name="e">E.</param>
        public void offsetValue_Changed(object c, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                carousel.Offset = int.Parse(e.NewTextValue);
            }
        }

        #endregion

        #region scale changes

        /// <summary>
        /// Scales the value changed.
        /// </summary>
        /// <param name="c">C.</param>
        /// <param name="e">E.</param>
        public void ScaleValue_Changed(object c, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                if (float.Parse(e.NewTextValue) <= 1)
                {
                    carousel.ScaleOffset = float.Parse(e.NewTextValue);
                }
                else
                {
                    carousel.ScaleOffset = 1.0f;

                }
            }
        }

        #endregion

        #region rotation changes

        /// <summary>
        /// Rotates the value changed.
        /// </summary>
        /// <param name="c">C.</param>
        /// <param name="e">E.</param>
        public void rotateValue_Changed(object c, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                if (float.Parse(e.NewTextValue) > 0 && float.Parse(e.NewTextValue) <= 360)
                {

                    carousel.RotationAngle = int.Parse(e.NewTextValue);
                }
                else
                {
                    carousel.RotationAngle = 45;

                }
            }
        }

        #endregion

        #region SB view

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns>The content.</returns>
        public View getContent()
        {
            return this.Content;

        }

        #endregion

        #region Property view

        /// <summary>
        /// Gets the property view.
        /// </summary>
        /// <returns>The property view.</returns>
        public View getPropertyView()
        {
            return this.PropertyView;
        }

        #endregion


    }
}


