#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfBusyIndicator.iOS;
using System;
using System.Net;
using System.Threading.Tasks;
using Syncfusion.SfMaps.iOS;
using Foundation;
using CoreGraphics;
using UIKit;
using Syncfusion.SfCarousel.iOS;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class OSM : SampleView
    {
        bool TapGesture_ShouldReceiveTouch(UIGestureRecognizer recognizer, UITouch touch)
        {
            if (touch.TapCount == 1)
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.openstreetmap.org/copyright"));
            }
            return true;
        }

        internal SfBusyIndicator busyindicator;
        UIView view;
        UIView mainGrid;
        UIView childGrid;
        double previousWidth;
        double previousHeight;
        CGSize label1Size;
        CGSize label2Size;
        UILabel label1;
        UILabel label2;
        bool isDisposed;
        SFMap maps;
        UILabel label;
        bool isConnected;
        SfCarousel carousel;
        List<string> imageList;
        List<string> headerList;
        List<string> descriptionList;
        NSMutableArray<SfCarouselItem> carouselItems;
        ImageryLayer layer;

        public override void LayoutSubviews()
        {
            view.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            busyindicator.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            if (childGrid != null)

                childGrid.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            if (mainGrid != null)
                mainGrid.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            if (maps != null)
                maps.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            if (label1 != null && label2 != null)
            {
                label1.Frame = new CGRect(Frame.Size.Width - (label1Size.Width + label2Size.Width) - 4,
                                          Frame.Size.Height - label2Size.Height - 4,
                                         label1Size.Width + 4, label1Size.Height + 4);
                label2.Frame = new CGRect(Frame.Size.Width - label2Size.Width - 2,
                                          Frame.Size.Height - label2Size.Height - 4,
                                          label2Size.Width + 4, label2Size.Height + 4);

            }

            if (carousel != null)
            {
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                {
                    carousel.ItemHeight = Frame.Size.Height * 0.2f;
                }
                else
                {
                    carousel.ItemHeight = Frame.Size.Height * 0.150f;
                }

                carousel.Frame = new CGRect(0, Frame.Size.Height - carousel.ItemHeight - label2Size.Height, Frame.Size.Width, carousel.ItemHeight);

                carousel.ItemWidth = Frame.Size.Width * 0.75f;
                carousel.SelectedItemOffset = (carousel.ItemWidth / 2) - 30;
                AddCarouselItems();
            }

            if (childGrid != null && childGrid.Subviews.Length > 0
               && previousWidth == view.Frame.Size.Width && previousHeight == view.Frame.Size.Height)
                return;
            double row = 0;
            double column = 0;

            if (view.Frame.Size.Height > 0)
            {
                row = view.Frame.Size.Height / 512;
                if (Math.Ceiling(row) <= 0)
                    row = 1;
                else
                    row = Math.Ceiling(row);
                previousHeight = view.Frame.Size.Height;
            }
            if (view.Frame.Size.Width > 0)
            {
                column = view.Frame.Size.Width / 512;
                if (Math.Ceiling(column) <= 0)
                    column = 1;
                else
                    column = Math.Ceiling(column);
                previousWidth = view.Frame.Size.Width;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    UIImageView image = new UIImageView();
                    image.Image = UIImage.FromBundle("grid.png");
                    var xPos = i * 512;
                    var yPos = j * 512;
                    image.Frame = new CGRect(xPos, yPos, 512, 512);
                    childGrid.AddSubview(image);
                    SetNeedsDisplay();
                }
            }
            childGrid.ClipsToBounds = true;
            SetNeedsDisplay();
        }

        private void AddCarouselItems()
        {
            AddCarouselContent();

            for (int i = 0; i <= 6; i++)
            {
                var width = carousel.ItemWidth * 0.6;
                SfCarouselItem items = new SfCarouselItem();
                items.BackgroundColor = UIColor.White;
                UIStackView stackView = new UIStackView();
                stackView.BackgroundColor = UIColor.White;
                stackView.Axis = UILayoutConstraintAxis.Horizontal;
                stackView.Frame = new CGRect(0, 0, carousel.ItemWidth, carousel.ItemHeight);
                stackView.Layer.CornerRadius = 10;
                stackView.Layer.BorderColor = UIColor.LightGray.CGColor;
                stackView.Layer.BorderWidth = 0.5f;

                UIStackView stackView1 = new UIStackView();
                stackView1.Axis = UILayoutConstraintAxis.Vertical;
                stackView1.Frame = new CGRect(0, 0, width, carousel.ItemHeight);

                UILabel label1 = new UILabel();
                label1.Text = headerList[i];
                label1.Font = UIFont.SystemFontOfSize(14, UIFontWeight.Bold);

                label1.Frame = new CGRect(10, 5, width, carousel.ItemHeight * 0.25);
                stackView1.Add(label1);

                UILabel label = new UILabel();
                label.Text = descriptionList[i];
                label.Font = UIFont.SystemFontOfSize(10, UIFontWeight.Regular);
                label.Lines = 4;
                label.ContentMode = UIViewContentMode.TopLeft;
                label.LineBreakMode = UILineBreakMode.WordWrap | UILineBreakMode.TailTruncation;
                label.Frame = new CGRect(10, carousel.ItemHeight * 0.25, stackView1.Frame.Width - 10, carousel.ItemHeight * 0.75);
                stackView1.Add(label);

                UIImageView uiImageView = new UIImageView();
                uiImageView.Image = UIImage.FromBundle(imageList[i]);
                uiImageView.Frame = new CGRect(width + 8, 10, carousel.ItemWidth * 0.4 - 16, carousel.ItemHeight - 20);
                uiImageView.Layer.CornerRadius = 7;
                uiImageView.Layer.BorderColor = UIColor.LightGray.CGColor;
                uiImageView.ClipsToBounds = true; 

                stackView.Add(stackView1);
                stackView.Add(uiImageView);

                items.View = stackView;
                carouselItems.Add(items);
            }

            carousel.DataSource = carouselItems;
        }

        private void AddCarouselContent()
        {
            imageList = new List<string>();
            imageList.Add("Mexico.jpg");
            imageList.Add("Peru.jpg");
            imageList.Add("Christ.jpg");
            imageList.Add("Colosseum.jpg");
            imageList.Add("Petra.jpg");
            imageList.Add("TajMahal.jpg");
            imageList.Add("China_wall.jpg");

            headerList = new List<string>();
            headerList.Add("Chichen Itza, Mexico");
            headerList.Add("Machu Picchu, Peru");
            headerList.Add("Chirst the Redeemer, Brazil");
            headerList.Add("Colosseum, Rome");
            headerList.Add("Petra, Jordan");
            headerList.Add("Taj Mahal, India");
            headerList.Add("Great wall of China, China");


            descriptionList = new List<string>();
            descriptionList.Add("Mayan ruins on Mexico's Yucatan Peninsula. It was one of the largest Maya cities, thriving from around A.D. 600 to 1200.");
            descriptionList.Add("An inca citadel built in the mid-1400s. It was not widely known until the early 20th century.");
            descriptionList.Add("An enormous statue of Jesus Christ with open arms. A symbol of Christianity across the world, the statue has also become a cultural icon of both Rio de Janeiro and Brazil.");
            descriptionList.Add("Built between A.D. 70 and 80. It is one of the most popular touristattractions in Europe.");
            descriptionList.Add("It is a historic and archaeological city in southern Jordan. Petra lies around Jabal Al-Madbah in a basin surrounded by mountains which form the eastern flank of the Arabah valley that runs from the Dead Sea to the Gulf of Aqaba.");
            descriptionList.Add("It is an ivory-white marble mausoleum on the southern bank of the river Yamuna in the Indian city of Agra.");
            descriptionList.Add("The Great Wall of China is a series of fortifications that were built across the historical northern borders of ancient Chinese states and Imperial China as protection against various nomadic groups from the Eurasian Steppe.");


            carouselItems = new NSMutableArray<SfCarouselItem>();
        }

        public OSM()
        {

            view = new UIView();
            view.Frame = new CGRect(0, 0, 300, 400);
            AddMainView();
            busyindicator = new SfBusyIndicator();
            busyindicator.ViewBoxWidth = 75;
            busyindicator.ViewBoxHeight = 75;
            busyindicator.Foreground = UIColor.FromRGB(0x77, 0x97, 0x72);  /*#779772*/
            busyindicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
            IsConnectedToNetwork();
        }
      
        protected override void Dispose(bool disposing)
        {
            isDisposed = true;
            base.Dispose(disposing);
        }
        async void IsConnectedToNetwork()
        {
            isConnected = await IsConnected();
            if (isDisposed)
                return;
            if (isConnected)
            {
                view.AddSubview(busyindicator);
                NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(0.3), delegate
                {
                    if (isDisposed)
                        return;
                    maps.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
                    view.AddSubview(mainGrid);
                });
            }
            else
            {
                label = new UILabel();
                label.TextAlignment = UITextAlignment.Center;
                label.Text = "Since this application requires network connection, " +
                    "Please check your network connection";
                label.Font = UIFont.SystemFontOfSize(14);
                label.Frame = new CGRect(0, 0, 300, 300);
                label.TextColor = UIColor.Black;
                label.LineBreakMode = UILineBreakMode.WordWrap;
                label.Lines = 2;
                view.AddSubview(label);
            }
            AddSubview(view);
        }

        async Task<bool> IsConnected()
        {

            var webRequest = (HttpWebRequest)WebRequest.Create("https://www.openstreetmap.org");
            webRequest.Method = "HEAD";

            try
            {
                using (var httpResponse = await webRequest.GetResponseAsync() as HttpWebResponse)
                {
                    if (httpResponse != null && httpResponse.StatusCode == HttpStatusCode.OK)
                        return true;

                    return false;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        void AddMainView()
        {
            if (childGrid == null)
                childGrid = new UIView();
            mainGrid = new UIView();
            mainGrid.BackgroundColor = UIColor.FromRGB(243, 239, 233);
            mainGrid.AddSubview(childGrid);
            maps = new SFMap();
            maps.ZoomLevel = 4;
            maps.MinimumZoom = 4;
            maps.MaximumZoom = 10;
            layer = new ImageryLayer();
            layer.GeoCoordinates = new CGPoint(27.1751, 78.0421);

            PopulationMarker marker1 = new PopulationMarker();
            marker1.Latitude = 20.6843f;
            marker1.Longitude = -88.5678f;
            layer.Markers.Add(marker1);

            PopulationMarker marker2 = new PopulationMarker();
            marker2.Latitude = -13.1631f;
            marker2.Longitude = -72.5450f;
            layer.Markers.Add(marker2);

            PopulationMarker marker3 = new PopulationMarker();
            marker3.Latitude = -22.9519f;
            marker3.Longitude = -43.2106f;
            layer.Markers.Add(marker3);

            PopulationMarker marker4 = new PopulationMarker();
            marker4.Latitude = 41.8902;
            marker4.Longitude = 12.4922;
            layer.Markers.Add(marker4);

            PopulationMarker marker5 = new PopulationMarker();
            marker5.Latitude = 30.3285;
            marker5.Longitude = 35.4444;
            layer.Markers.Add(marker5);

            PopulationMarker marker6 = new PopulationMarker();
            marker6.Latitude = 27.1751;
            marker6.Longitude = 78.0421;
            layer.Markers.Add(marker6);

            PopulationMarker marker7 = new PopulationMarker();
            marker7.Latitude = 40.4319;
            marker7.Longitude = 116.5704;
            layer.Markers.Add(marker7);

            maps.Layers.Add(layer);
            maps.Delegate = new OSMDelegate(this);
            mainGrid.AddSubview(maps);

            carousel = new SfCarousel();
            carousel.RotationAngle = 0;
            carousel.SelectedIndex = 5;
            carousel.SelectionChanged += Carousel_SelectionChanged;

            mainGrid.AddSubview(carousel);

            label1 = new UILabel();
            label1.TextColor = UIColor.Black;
            label1.LayoutMargins = new UIEdgeInsets(2, 2, 3, 2);
            label1.Font = UIFont.FromName("Helvetica", 12);
            var text = new NSString("©");
            var stringAtribute = new NSDictionary(UIStringAttributeKey.Font, label1.Font,
                                                  UIStringAttributeKey.ForegroundColor, UIColor.Black);
            UIStringAttributes strAtr = new UIStringAttributes(stringAtribute);
            label1.Text = text;
            label1Size = text.GetSizeUsingAttributes(strAtr);
            label1.BackgroundColor = UIColor.White;
            mainGrid.AddSubview(label1);
            label2 = new UILabel();
            label2.TextColor = UIColor.FromRGB(0, 212, 255);
            label2.LayoutMargins = new UIEdgeInsets(1, 2, 3, 2);
            label2.Font = UIFont.FromName("Helvetica", 12);
            var text1 = new NSString("OpenStreetMap contributors.");
            var stringAtribute1 = new NSDictionary(UIStringAttributeKey.Font, label2.Font,
                                                   UIStringAttributeKey.ForegroundColor, UIColor.FromRGB(0, 212, 255));
            UIStringAttributes strAtr1 = new UIStringAttributes(stringAtribute);
            label2.Text = text1;
            label2Size = text1.GetSizeUsingAttributes(strAtr1);
            label2.BackgroundColor = UIColor.White;
            label2.UserInteractionEnabled = true;
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer();
            tapGesture.ShouldReceiveTouch += TapGesture_ShouldReceiveTouch;
            label2.AddGestureRecognizer(tapGesture);
            mainGrid.AddSubview(label2);
        }

        private void Carousel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (int)(sender as SfCarousel).SelectedIndex;
            if (index == 0)
            {
                layer.GeoCoordinates = new CGPoint(20.6843, -88.5678);
            }
            else if (index == 1)
            {
                layer.GeoCoordinates = new CGPoint(-13.1631, -72.5450);
            }
            else if (index == 2)
            {
                layer.GeoCoordinates = new CGPoint(-22.9519, -43.2106);
            }
            else if (index == 3)
            {
                layer.GeoCoordinates = new CGPoint(41.8902, 12.4922);
            }
            else if (index == 4)
            {
                layer.GeoCoordinates = new CGPoint(30.3285, 35.4444);
            }
            else if (index == 5)
            {
                layer.GeoCoordinates = new CGPoint(27.1751, 78.0421);
            }
            else if (index == 6)
            {
                layer.GeoCoordinates = new CGPoint(40.4319, 116.5704);
            }
        }
    }



    public class OSMDelegate : SFMapsDelegate
    {
        OSM sample;
        public OSMDelegate(OSM osm)
        {
            sample = osm;
        }
        public override void DidLoad(SFMap map)
        {
            if (sample.busyindicator != null)
            {
                sample.busyindicator.RemoveFromSuperview();
                sample.busyindicator = null;
            }
        }
    }
}

