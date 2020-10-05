#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Syncfusion.SfCarousel.iOS;
namespace SampleBrowser
{
    /// <summary>
    /// Load more sample.
    /// </summary>
    public class LoadMoreSample:SampleView
    {
        #region private variables

        UILabel applicationLabel, foodLabel, bankingLabel;
        UIView LoadMoreLayout;
        UIAlertView alertWindow;
        SFCarousel applicationCarousel,foodCarousel,bankCarousel;
        UIScrollView carouselScrollview;
        CarouselViewModel carouselViewModel;

        #endregion

        #region Loadmore sample
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.LoadMoreSample"/> class.
        /// </summary>
        public LoadMoreSample()
        {
            carouselScrollview = new UIScrollView();
            alertWindow = new UIAlertView();
            alertWindow.AddButton("OK");
            carouselViewModel = new CarouselViewModel();

            LoadMoreLayout = new UIView();
            LoadMoreLayout.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            carouselScrollview.BackgroundColor =UIColor.FromRGB(249, 249, 249);
            applicationLabel = new UILabel();
            applicationLabel.Text = "Application";
            applicationLabel.TextColor = UIColor.FromRGBA(nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse("0.9764705882352941"));
            applicationLabel.Font = UIFont.FromName("Helvetica", 18f);

            applicationCarousel = new SFCarousel();
            applicationCarousel.ItemWidth = 150;
            applicationCarousel.ItemHeight = 150;
            applicationCarousel.AllowLoadMore = true;
            applicationCarousel.LoadMoreItemsCount = 4;
            UILabel loadmore2 = new UILabel() { TextColor = UIColor.Black, Text = "Load More...", Font = UIFont.FromName("Helvetica-Bold", 13f), TextAlignment = UITextAlignment.Center };
            loadmore2.Frame = new CoreGraphics.CGRect(12, 61, 150, 17);
            UIView loadView2 = new UIView();
            loadView2.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            loadView2.AddSubview(loadmore2);
            applicationCarousel.LoadMoreView = loadView2;
            applicationCarousel.ViewMode = SFCarouselViewMode.SFCarouselViewModeLinear;
            applicationCarousel.ItemsSource = carouselViewModel.ApplicationCollection;
            applicationCarousel.ItemSpacing = 15;
            applicationCarousel.DrawView += DrawAdapterView;

            foodLabel = new UILabel();
            foodLabel.Text = "Food";
            foodLabel.TextColor = UIColor.FromRGBA(nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse("0.9764705882352941"));
            foodLabel.Font = UIFont.FromName("Helvetica", 18f);

            foodCarousel = new SFCarousel();
            foodCarousel.ItemWidth = 150;
            foodCarousel.ItemHeight = 150;
            foodCarousel.AllowLoadMore = true;
            foodCarousel.LoadMoreItemsCount = 4;
            UILabel loadmore = new UILabel() {TextColor=UIColor.Black, Text = "Load More...", Font = UIFont.FromName("Helvetica-Bold", 13f),TextAlignment=UITextAlignment.Center };
            UIView loadView = new UIView();
            loadmore.Frame = new CoreGraphics.CGRect(12, 61, 150, 17);
            loadView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            loadView.AddSubview(loadmore);
            foodCarousel.LoadMoreView = loadView;

            foodCarousel.ItemSpacing = 15;
            foodCarousel.ViewMode = SFCarouselViewMode.SFCarouselViewModeLinear;
            foodCarousel.ItemsSource = carouselViewModel.TransportCollection;
            foodCarousel.DrawView += DrawFoodAdapterView;

            LoadMoreLayout.AddSubview(applicationLabel);
            LoadMoreLayout.AddSubview(applicationCarousel);
            LoadMoreLayout.AddSubview(foodLabel);
            LoadMoreLayout.AddSubview(foodCarousel);
          
            bankingLabel = new UILabel();
            bankingLabel.Text = "Banking";
            bankingLabel.TextColor = UIColor.FromRGBA(nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse((51 / 255.0).ToString()), nfloat.Parse("0.9764705882352941"));
            bankingLabel.Font = UIFont.FromName("Helvetica", 18f);

            bankCarousel = new SFCarousel();
            bankCarousel.ItemWidth = 150;
            bankCarousel.ItemHeight = 150;
            bankCarousel.AllowLoadMore = true;
            bankCarousel.LoadMoreItemsCount = 4;
            UILabel loadmore1 = new UILabel() { TextColor = UIColor.Black, Text = "Load More...", Font = UIFont.FromName("Helvetica-Bold", 13f), TextAlignment = UITextAlignment.Center };
            UIView loadView1 = new UIView();
            loadmore1.Frame = new CoreGraphics.CGRect(12, 61, 150, 17);
            loadView1.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            loadView1.AddSubview(loadmore1);
            bankCarousel.LoadMoreView = loadView1;

            bankCarousel.ItemSpacing = 15;
            bankCarousel.ViewMode = SFCarouselViewMode.SFCarouselViewModeLinear;
            bankCarousel.ItemsSource = carouselViewModel.OfficeCollection;
            bankCarousel.DrawView += DrawBankAdapterView;

            LoadMoreLayout.AddSubview(applicationLabel);
            LoadMoreLayout.AddSubview(applicationCarousel);
            LoadMoreLayout.AddSubview(foodLabel);
            LoadMoreLayout.AddSubview(foodCarousel);
            LoadMoreLayout.AddSubview(bankingLabel);
            LoadMoreLayout.AddSubview(bankCarousel);


            carouselScrollview.AddSubview(LoadMoreLayout);
            this.AddSubview(carouselScrollview);
        }
        #endregion
        private void DrawAdapterView(object sender, DrawViewEventArgs e)
        {
            UIView carouselView = new UIView();
            carouselView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            carouselView.Frame = new CoreGraphics.CGRect(0, 0, 150, 150);
            UILabel iconLabel = new UILabel();
            iconLabel.Frame = new CoreGraphics.CGRect(35, 30, 80, 80);
            iconLabel.Text = (carouselViewModel.ApplicationCollection[e.Index] as CarouselModel).Unicode;
            iconLabel.Font = UIFont.FromName("Sample", 55f);
            iconLabel.TextColor = (carouselViewModel.ApplicationCollection[e.Index] as CarouselModel).ItemColor;
            iconLabel.TextAlignment = UITextAlignment.Center;
            carouselView.AddSubview(iconLabel);
            e.View = carouselView;

        }
        private void DrawFoodAdapterView(object sender, DrawViewEventArgs e)
        {
            UIView carouselView = new UIView();
            carouselView.UserInteractionEnabled = true;
            carouselView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            carouselView.Frame = new CoreGraphics.CGRect(0, 0, 100, 100);
            UILabel iconLabel = new UILabel();
            iconLabel.Frame = new CoreGraphics.CGRect(35, 30, 80, 80);
            iconLabel.Text = (carouselViewModel.TransportCollection[e.Index] as CarouselModel).Unicode;
            iconLabel.Font = UIFont.FromName("Sample", 55);
            iconLabel.TextColor = (carouselViewModel.TransportCollection[e.Index] as CarouselModel).ItemColor;
            iconLabel.TextAlignment = UITextAlignment.Center;
            carouselView.AddSubview(iconLabel);
            e.View = carouselView;


        }
        private void DrawBankAdapterView(object sender, DrawViewEventArgs e)
        {
            UIView carouselView = new UIView();
            carouselView.UserInteractionEnabled = true;
            carouselView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            carouselView.Frame = new CoreGraphics.CGRect(0, 0, 100, 100);
            UILabel iconLabel = new UILabel();
            iconLabel.Frame = new CoreGraphics.CGRect(35, 30, 80, 80);
            iconLabel.Text = (carouselViewModel.OfficeCollection[e.Index] as CarouselModel).Unicode;
            iconLabel.Font = UIFont.FromName("Sample", 55);
            iconLabel.TextColor = (carouselViewModel.OfficeCollection[e.Index] as CarouselModel).ItemColor;
            iconLabel.TextAlignment = UITextAlignment.Center;
            carouselView.AddSubview(iconLabel);
            e.View = carouselView;


        }
        #region size update

        /// <summary>
        /// Layouts the subviews.
        /// </summary>
        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    carouselScrollview.Frame = new CoreGraphics.CGRect(0, 0, this.Frame.Width, this.Frame.Height);
                    carouselScrollview.ContentSize = new CoreGraphics.CGSize(this.Frame.Width, this.Frame.Height);
                    LoadMoreLayout.Frame = new CoreGraphics.CGRect(0, 0, this.Frame.Width, this.Frame.Height);
                    applicationLabel.Frame = new CoreGraphics.CGRect(18, 22, this.Frame.Width, 24);
                    applicationCarousel.Frame = new CoreGraphics.CGRect(0, 64, this.Frame.Width, 150);
                    foodLabel.Frame = new CoreGraphics.CGRect(18, 248, this.Frame.Width, 24);
                    foodCarousel.Frame = new CoreGraphics.CGRect(0, 290, this.Frame.Width, 150);
                    bankingLabel.Frame = new CoreGraphics.CGRect(18, 474, this.Frame.Width, 24);
                    bankCarousel.Frame = new CoreGraphics.CGRect(0, 516, this.Frame.Width, 150);

                }
                else
                {
                    carouselScrollview.Frame = new CoreGraphics.CGRect(0,0,this.Frame.Width, this.Frame.Height);
                    carouselScrollview.ContentSize = new CoreGraphics.CGSize(this.Frame.Width, this.Frame.Height);
                    LoadMoreLayout.Frame = new CoreGraphics.CGRect(0, 0, this.Frame.Width, this.Frame.Height);
                    applicationLabel.Frame=new CoreGraphics.CGRect(18, 22, this.Frame.Width, 24);
                    applicationCarousel.Frame = new CoreGraphics.CGRect(0, 64, this.Frame.Width, 150);
                    foodLabel.Frame = new CoreGraphics.CGRect(18, 248, this.Frame.Width, 24);
                    foodCarousel.Frame = new CoreGraphics.CGRect(0, 290, this.Frame.Width, 150);
                }
            }
               
            base.LayoutSubviews();
        }

        #endregion

    }
}
