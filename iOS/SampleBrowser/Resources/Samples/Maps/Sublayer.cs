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
        internal SFBusyIndicator busyindicator;
        UIView view;
        UILabel label;

        public override void LayoutSubviews()
        {
            view.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            busyindicator.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height); ;
            SetNeedsDisplay();
        }
        public Sublayer()
        {
            SFMap maps = new SFMap();
            view = new UIView();
            view.Frame = new CGRect(0, 0, 300, 400);
            busyindicator = new SFBusyIndicator();
            busyindicator.ViewBoxWidth = 75;
            busyindicator.ViewBoxHeight = 75;
            busyindicator.Foreground = UIColor.FromRGB(0x77, 0x97, 0x72);  /*#779772*/
            busyindicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
            view.AddSubview(busyindicator);
            label = new UILabel();
            label.TextAlignment = UITextAlignment.Center;
            label.Text = "Samsung Semiconductor office locations in USA";
            label.Font = UIFont.SystemFontOfSize(18);
            label.Frame = new CGRect(0, 0, 400, 40);
            label.TextColor = UIColor.Black;
            view.AddSubview(label);

            NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(0.3), delegate {
                maps.Frame = new CGRect(Frame.Location.X, 60, Frame.Size.Width - 6, Frame.Size.Height - 60);

                view.AddSubview(maps);
            });

            SFShapeFileLayer layer = new SFShapeFileLayer();

            layer.Uri = (NSString)NSBundle.MainBundle.PathForResource("usa_state", "shp");
            layer.ShapeIDPath = (NSString)"Name";
            layer.ShapeIDTableField = (NSString)"STATE_NAME";
            layer.ShowMapItems = true;
            layer.DataSource = GetDataSource();

            SFShapeSetting shapeSettings = new SFShapeSetting();
            shapeSettings.ValuePath = (NSString)"Type";
            shapeSettings.Fill = UIColor.FromRGB(229, 229, 229);
            shapeSettings.StrokeColor = UIColor.FromRGB(208, 208, 208);
            shapeSettings.StrokeThickness = 2;
            layer.ShapeSettings = shapeSettings;

            SFDataLabelSetting dataLabelSetting = new SFDataLabelSetting();
            dataLabelSetting.SmartLabelMode = IntersectAction.Trim;
            layer.DataLabelSettings = dataLabelSetting;

            SFShapeFileLayer subLayer = new SFShapeFileLayer();
            subLayer.Uri = (NSString)NSBundle.MainBundle.PathForResource("Texas", "shp");

            SFMapMarker marker1 = new SFMapMarker();
            marker1.Latitude = 32.870404;
            marker1.Longitude = -99.467014;
            subLayer.Markers.Add(marker1);

            SFShapeFileLayer subLayer1 = new SFShapeFileLayer();
            subLayer1.Uri = (NSString)NSBundle.MainBundle.PathForResource("California", "shp");

            SFMapMarker marker2 = new SFMapMarker();
            marker2.Latitude = 38.778259;
            marker2.Longitude = -120.463228;
            subLayer1.Markers.Add(marker2);

            SFShapeSetting subshapeSettings = new SFShapeSetting();
            subshapeSettings.Fill = UIColor.FromRGB(177, 216, 245);
            subshapeSettings.StrokeColor = UIColor.FromRGB(141, 204, 244);
            subshapeSettings.StrokeThickness = 1;

            subLayer.ShapeSettings = subshapeSettings;
            subLayer1.ShapeSettings = subshapeSettings;


            layer.Sublayers.Add(subLayer);
            layer.Sublayers.Add(subLayer1);
            maps.Layers.Add(layer);
            AddSubview(view);
            maps.Delegate = new MapsSublayerDelegate(this);
        }

        NSMutableArray GetDataSource()
        {
            NSMutableArray array = new NSMutableArray();

            array.Add(getDictionary("Alabama", "AL", 42));
            array.Add(getDictionary("Alaska", "AK", 0));
            array.Add(getDictionary("Arizona", "AR", 36));
            array.Add(getDictionary("Arkansas", "AN", 46));
            array.Add(getDictionary("California", "CA", 24));
            array.Add(getDictionary("Colorado", "CO", 31));
            array.Add(getDictionary("Connecticut", "CN", 18));
            array.Add(getDictionary("Delaware", "DE", 28));
            array.Add(getDictionary("District of Columbia", "DC", 27));
            array.Add(getDictionary("Florida", "FL", 48));
            array.Add(getDictionary("Georgia", "GE", 44));
            array.Add(getDictionary("Hawaii", "HA", 49));
            array.Add(getDictionary("Idaho", "ID", 8));
            array.Add(getDictionary("Illinois", "IL", 26));
            array.Add(getDictionary("Indiana", "IN", 21));
            array.Add(getDictionary("Iowa", "IO", 13));
            array.Add(getDictionary("Kansas", "KA", 33));
            array.Add(getDictionary("Kentucky", "KE", 32));
            array.Add(getDictionary("Louisiana", "LO", 47));
            array.Add(getDictionary("Maine", "MA", 3));
            array.Add(getDictionary("Maryland", "MY", 30));
            array.Add(getDictionary("Massachusetts", "MS", 14));
            array.Add(getDictionary("Michigan", "MI", 50));
            array.Add(getDictionary("Minnesota", "MN", 10));
            array.Add(getDictionary("Mississippi", "MP", 43));
            array.Add(getDictionary("Missouri", "MO", 35));
            array.Add(getDictionary("Montana", "MT", 2));
            array.Add(getDictionary("Nebraska", "NE", 15));
            array.Add(getDictionary("Nevada", "NV", 22));
            array.Add(getDictionary("New Hampshire", "NH", 12));
            array.Add(getDictionary("New Jersey", "NJ", 20));
            array.Add(getDictionary("New Mexico", "NM", 41));
            array.Add(getDictionary("New York", "NY", 16));
            array.Add(getDictionary("North Carolina", "NC", 38));
            array.Add(getDictionary("North Dakota", "ND", 4));
            array.Add(getDictionary("Ohio", "OH", 25));
            array.Add(getDictionary("Oklahoma", "OK", 37));
            array.Add(getDictionary("Oregon", "OR", 11));
            array.Add(getDictionary("Pennsylvania", "PE", 17));
            array.Add(getDictionary("Rhode Island", "RH", 19));
            array.Add(getDictionary("South Carolina", "SC", 45));
            array.Add(getDictionary("South Dakota", "SD", 5));
            array.Add(getDictionary("Tennessee", "TE", 39));
            array.Add(getDictionary("Texas", "TX", 40));
            array.Add(getDictionary("Utah", "UT", 23));
            array.Add(getDictionary("Vermont", "VE", 9));
            array.Add(getDictionary("Virginia", "VI", 34));
            array.Add(getDictionary("Washington", "WA", 1));
            array.Add(getDictionary("West Virginia", "WV", 29));
            array.Add(getDictionary("Wisconsin", "WI", 7));
            array.Add(getDictionary("Wyoming", "WY", 6));
            return array;
        }

        NSDictionary getDictionary(string name, string type, int index)
        {
            NSString name1 = (NSString)name;
            object[] objects = new object[3];
            object[] keys = new object[3];
            keys.SetValue("Name", 0);
            keys.SetValue("index", 1);
            keys.SetValue("Type", 2);
            objects.SetValue(name1, 0);
            objects.SetValue(index, 1);
            objects.SetValue(type, 2);
            return NSDictionary.FromObjectsAndKeys(objects, keys);
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