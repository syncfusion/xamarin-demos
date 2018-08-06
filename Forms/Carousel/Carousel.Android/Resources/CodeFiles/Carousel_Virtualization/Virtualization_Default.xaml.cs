#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfCarousel
{
    /// <summary>
    /// Virtualization default.
    /// </summary>
    public partial class Virtualization_Default : SampleView
    {
        CarouselViewModel carouselViewModel;

        #region VirtualizationDefault

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfCarousel.Virtualization_Default"/> class.
        /// </summary>
        public Virtualization_Default()
        {
            InitializeComponent();
            carouselViewModel = new CarouselViewModel();
            if (Device.OS == TargetPlatform.iOS && Device.Idiom == TargetIdiom.Phone)
            {
                brandCarousel.MinimumHeightRequest = 200;
                brandCarousel.HeightRequest = 200;
                brandCarousel.ItemHeight = 175;
                brandCarousel.ItemWidth = 140;
            }
            carouselLayout.BindingContext = carouselViewModel;
            brandCarousel.SelectionChanged += BrandCarousel_SelectionChanged;
            selection.Text = brandCarousel.SelectedIndex + " / " + (carouselViewModel.DataCollection.Count - 1);
        }

        private void BrandCarousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            selection.Text = brandCarousel.SelectedIndex +" / " + (carouselViewModel.DataCollection.Count-1);
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

        /// <summary>
        /// Handles the clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            virtualizationButton.IsVisible = false;
            brandCarousel.IsVisible = true;
            selection.IsVisible = true;
            brandCarousel.ItemsSource = carouselViewModel.DataCollection;
        }


        #region handle event

        /// <summary>
        /// Handles the tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (previousLabel != null)
                previousLabel.Text = "C";
            selectedModel = (sender as ImageAdv).ModelObject;
            this.iconName.Text = selectedModel.Unicode;
            this.iconText.Text = selectedModel.Name.Replace("-", " ").Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "");
            this.iconName.TextColor = selectedModel.ItemColor;
            this.Dialog.IsVisible = true;
            this.Dialog.Opacity = 0;
            this.Dialog.FadeTo(1, 500, Easing.Linear);
        }

        /// <summary>
        /// Handles the tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Color_Tapped(object sender, System.EventArgs e)
        {
            if (previousLabel != null)
                previousLabel.Text = "C";
            (sender as Label).Text = "B";
            selectedModel.ItemColor = (sender as Label).TextColor;
            this.iconName.TextColor = selectedModel.ItemColor;
            previousLabel = (sender as Label);
        }

        /// <summary>
        /// Yeses the handle.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Yes_Handle(object sender, System.EventArgs e)
        {
            this.Dialog.Opacity = 1;
            this.Dialog.IsVisible = false;
            selectedModel = null;
        }
        #endregion

        #region Member

        private Label previousLabel = null;
        private CarouselModel selectedModel = null;
        #endregion
    }
}
