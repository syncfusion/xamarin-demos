#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Xamarin.Forms;
using Syncfusion.SfCarousel.XForms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SampleBrowser.SfCarousel
{
    /// <summary>
    /// Pull to refresh default.
    /// </summary>
    public partial class PullToRefresh_Default : SampleView
    {
        CarouselViewModel carouselViewModel;

        #region PullToRefresh Default view

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfCarousel.PullToRefresh_Default"/> class.
        /// </summary>
        public PullToRefresh_Default()
        {
            InitializeComponent();
            carouselViewModel = new CarouselViewModel();
            carouselLayout.BindingContext = carouselViewModel;
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

        #region handle event

        /// <summary>
        /// Handles the tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_Tapped(object sender, System.EventArgs e)
        {
           // Device.OpenUri(new Uri("https://www.syncfusion.com/downloads"));
        }
        #endregion
    }
}
