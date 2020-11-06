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
    /// Carousel pull to refresh.
    /// </summary>
    public class Carousel_PullToRefresh:SampleView
    {
        #region  constructor

        public Carousel_PullToRefresh()
        {
            #region device and tablet

            PullToRefresh_Default busy = new PullToRefresh_Default();
            this.Content = busy.getContent();


            #endregion

        }

        #endregion
    }
}
