#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
            ImageryLayer layer = new ImageryLayer();
            maps.Layers.Add(layer);
            maps.Delegate = new OSMDelegate(this);
            mainGrid.AddSubview(maps);
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

