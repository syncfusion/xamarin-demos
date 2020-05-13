#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

            #region command execution

            //brandCarousel.PullToRefershCommand = new Command(BrandCarouselPullToRefreshAction);
            //dataCarousel.PullToRefershCommand = new Command(DataCarouselPullToRefreshAction);
            //gadgetCarousel.PullToRefershCommand = new Command(GadgetCarouselPullToRefreshAction);

            #endregion
        }

        #endregion

        #region BrandCarousel PullToRefreshAction

        /// <summary>
        /// Brands the carousel pull to refresh action.
        /// </summary>

        //private async void BrandCarouselPullToRefreshAction()
        //{
        //    int count = (brandCarousel.ItemsSource as ObservableCollection<CarouselModel>).Count;
        //    if (count + 5 <= carouselViewModel.ApplicationCollection.Count)
        //    {
        //        brandCarousel.IsBusy = true;
        //        await Task.Delay(new TimeSpan(0, 0, 2));

        //        for (int i = count; i < count + 5; i++)
        //        {
        //            (brandCarousel.ItemsSource as ObservableCollection<CarouselModel>).Add(carouselViewModel.BrandCollection[i]);
        //        }
        //        brandCarousel.IsBusy = false;
        //    }
        //    else
        //        brandCarousel.IsBusy = false;

        //}

        #endregion

        #region DataCarousel PullToRefreshAction

        /// <summary>
        /// Data  carousel pull to refresh action.
        /// </summary>

        //private async void DataCarouselPullToRefreshAction()
        //{
        //    int count = (dataCarousel.ItemsSource as ObservableCollection<CarouselModel>).Count;
        //    if (count + 5 <= carouselViewModel.TransportCollection.Count)
        //    {
        //        dataCarousel.IsBusy = true;
        //        await Task.Delay(new TimeSpan(0, 0, 2));

        //        for (int i = count; i < count + 5; i++)
        //        {
        //            (dataCarousel.ItemsSource as ObservableCollection<CarouselModel>).Add(carouselViewModel.DataValueCollection[i]);
        //        }
        //        dataCarousel.IsBusy = false;
        //    }
        //    else
        //        dataCarousel.IsBusy = false;

        //}

        #endregion

        #region  GadgetCarousel PullToRefreshAction

        /// <summary>
        /// GadgetCarousel pull to refresh action.
        /// </summary>
        //private async void GadgetCarouselPullToRefreshAction()
        //{
        //    int count = (gadgetCarousel.ItemsSource as ObservableCollection<CarouselModel>).Count;
        //    if (count + 5 <= carouselViewModel.OfficeCollection.Count)
        //    {
        //        gadgetCarousel.IsBusy = true;
        //        await Task.Delay(new TimeSpan(0, 0, 2));

        //        for (int i = count; i < count + 5; i++)
        //        {
        //            (gadgetCarousel.ItemsSource as ObservableCollection<CarouselModel>).Add(carouselViewModel.GadgetCollection[i]);
        //        }
        //        gadgetCarousel.IsBusy = false;
        //    }
        //    else
        //        gadgetCarousel.IsBusy = false;

        //}

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
            Device.OpenUri(new Uri("https://www.syncfusion.com/downloads"));
        }
        #endregion
    }
}
