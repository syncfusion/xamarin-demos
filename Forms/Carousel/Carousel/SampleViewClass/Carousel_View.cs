#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfCarousel
{
    /// <summary>
    /// Carousel.
    /// </summary>
    public class Carousel_View: SampleView
    {
        #region Constructor
      
        public Carousel_View()
        {
            #region device
           
            if (Device.Idiom == TargetIdiom.Phone || Device.RuntimePlatform == Device.UWP)
            {
                Carousel_Default busy = new Carousel_Default();
                this.Content = busy.getContent();
                this.PropertyView = busy.getProperty();
            }

            #endregion

            #region tablet

            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                Carousel_Tablet busyTab = new Carousel_Tablet();
                this.Content = busyTab.getContent();
                this.PropertyView = busyTab.getPropertyView();
            }

            #endregion
        }

        #endregion
    }
}