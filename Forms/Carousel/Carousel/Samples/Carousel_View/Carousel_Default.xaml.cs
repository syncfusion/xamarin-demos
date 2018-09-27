#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfCarousel.XForms;
using System.Collections.ObjectModel;
using SampleBrowser.Core;

namespace SampleBrowser.SfCarousel
{
    /// <summary>
    /// Carousel default.
    /// </summary>
    public partial class Carousel_Default : SampleView
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfCarousel.Carousel_Default"/> class.
        /// </summary>
        public Carousel_Default()
        {
            InitializeComponent();
            viewmodePicker.SelectedIndex = 0;
            carousel.BindingContext = new CarouselViewModel();
            DeviceChanges();
        }

        #endregion

        #region device changes

        /// <summary>
        /// Devices the changes.
        /// </summary>
        private void DeviceChanges()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                carousel.ItemHeight = 200;
                carousel.ItemWidth = 150;
                optionLayout.Padding = new Thickness(0, 0, 10, 0);
            }
            if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                carousel.ItemHeight = (int)Core.SampleBrowser.ScreenHeight / 2;
                carousel.ItemWidth = (int)Core.SampleBrowser.ScreenWidth / 2;
                carousel.HeightRequest = 400;
                carousel.WidthRequest = 800;
                carouselLayout.Padding = new Thickness(0, 40, 0, 0);
            }
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                carousel.SelectedItemOffset = 160;
                carousel.HeightRequest = 600;
                carousel.WidthRequest = 800;
                carousel.HorizontalOptions = LayoutOptions.CenterAndExpand;
                carouselLayout.Padding = new Thickness(0, 80, 0, 0);
            }
            if (Device.RuntimePlatform == Device.UWP)
            {
                carousel.ScaleOffset = 0.5f;
            }
            if (Device.RuntimePlatform == Device.Android)
            {
                carousel.ItemHeight = Convert.ToInt32(250);
                carousel.ItemWidth = Convert.ToInt32(180);
                carouselLayout.Padding = new Thickness(0, 60, 0, 0);
                carousel.ScaleOffset = (float)0.70;
            }

        }
        #endregion

        #region Options

        /// <summary>
        /// Offsets the value changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OffsetValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            Decimal temp = Convert.ToDecimal(offset.Value);
            float offsetvalue = (float)temp;
            carousel.Offset = offsetvalue;
        }

        /// <summary>
        /// Handles the value event handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void HandleValueEventHandler(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            Decimal tempvalue = Convert.ToDecimal(scale.Value);
            float scalevalue = (float)tempvalue;

            if (scalevalue <= 1)
            {
                carousel.ScaleOffset = scalevalue;
            }
            else
            {
                carousel.ScaleOffset = 1.0f;
            }

        }

        /// <summary>
        /// Handles the value event handler1.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void HandleValueEventHandler1(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            Decimal temp = Convert.ToDecimal(rotateangle.Value);
            int rotationangle = (int)temp;
            if (rotationangle > 0 && rotationangle <= 360)
            {
                carousel.RotationAngle = rotationangle;
            }
            else
            {
                carousel.RotationAngle = 45;
            }
        }

        /// <summary>
        /// Viewmodes the picker selected index changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void viewmodePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (viewmodePicker.SelectedIndex)
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

        #region SampleBrowser view


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
        /// Gets the property.
        /// </summary>
        /// <returns>The property.</returns>
        public View getProperty()
        {
            return this.PropertyView;
        }

        #endregion
    }
}


