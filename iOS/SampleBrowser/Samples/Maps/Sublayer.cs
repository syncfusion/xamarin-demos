#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfBusyIndicator.iOS;
using System;
using Syncfusion.SfMaps.iOS;
#if __UNIFIED__
using Foundation;
using CoreGraphics;


using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGPoint= System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif


namespace SampleBrowser
{
    public class Sublayer : SampleView
    {
        internal SfBusyIndicator busyindicator;
        UIView view;
        UILabel label;
        bool isDisposed;

        public override void LayoutSubviews()
        {
            view.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            busyindicator.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height); 
            label.Frame = new CGRect(0f, 0f, Frame.Size.Width, 40);
            SetNeedsDisplay();
        }

        protected override void Dispose(bool disposing)
        {
            isDisposed = true;
            base.Dispose(disposing);
        }
        public Sublayer()
        {
            SFMap maps = new SFMap();
            view = new UIView();
            view.Frame = new CGRect(0, 0, 300, 400);
            busyindicator = new SfBusyIndicator();
            busyindicator.ViewBoxWidth = 75;
            busyindicator.ViewBoxHeight = 75;
            busyindicator.Foreground = UIColor.FromRGB(0x77, 0x97, 0x72);  /*#779772*/
            busyindicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
            view.AddSubview(busyindicator);
            label = new UILabel();
            label.TextAlignment = UITextAlignment.Center;
            label.Text = "Rivers in Australia";
            label.Font = UIFont.SystemFontOfSize(18);
            label.Frame = new CGRect(0, 0, 400, 40);
            label.TextColor = UIColor.Black;
            view.AddSubview(label);

            NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(0.3), delegate {
                if (isDisposed)
                    return;
                maps.Frame = new CGRect(Frame.Location.X, 60, Frame.Size.Width - 6, Frame.Size.Height - 60);

                view.AddSubview(maps);
            });

            SFShapeFileLayer layer = new SFShapeFileLayer();

            layer.Uri = (NSString)NSBundle.MainBundle.PathForResource("australia", "shp");

            SFShapeSetting shapeSettings = new SFShapeSetting();
            shapeSettings.StrokeThickness = 1;
            shapeSettings.StrokeColor = UIColor.White;
            shapeSettings.Fill = UIColor.FromRGB(172, 249, 247);
            layer.ShapeSettings = shapeSettings;

            SFShapeFileLayer subLayer = new SFShapeFileLayer();
            subLayer.Uri = (NSString)NSBundle.MainBundle.PathForResource("river", "shp");
            SFShapeSetting subLayerSettings = new SFShapeSetting();
            subLayerSettings.StrokeThickness = 2;
            subLayerSettings.Fill = UIColor.FromRGB(0, 168, 204);
            subLayer.ShapeSettings = subLayerSettings;

            layer.Sublayers.Add(subLayer);

            maps.Layers.Add(layer);
            AddSubview(view);
            maps.Delegate = new MapsSublayerDelegate(this);
        }

      

    }
    public class MapsSublayerDelegate : SFMapsDelegate
    {
        public MapsSublayerDelegate(Sublayer sublayer)
        {
            sample = sublayer;
        }
        Sublayer sample;

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
