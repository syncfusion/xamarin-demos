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
	public class BubbleVisualization : SampleView
	{
		internal SFBusyIndicator busyindicator;
		UIView view;
		UILabel label;

		public override void LayoutSubviews ()
		{
			view.Frame =  new CGRect(Frame.Location.X,0,Frame.Size.Width,Frame.Size.Height);
			busyindicator.Frame =  new CGRect(Frame.Location.X,0,Frame.Size.Width,Frame.Size.Height);;
			SetNeedsDisplay ();
		}
		public BubbleVisualization ()
		{
			SFMap maps = new SFMap ();
			view = new UIView ();
			view.Frame=new CGRect(0,0,300,400);
			busyindicator = new SFBusyIndicator ();
			busyindicator.ViewBoxWidth=75;
			busyindicator.ViewBoxHeight=75;
			busyindicator.Foreground=  UIColor.FromRGB (0x77, 0x97, 0x72);  /*#779772*/
			busyindicator.AnimationType=SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
			view.AddSubview (busyindicator);
			label = new UILabel ();
			label.TextAlignment = UITextAlignment.Center;
			label.Text = "Top Population Countries With Bubbles";
			label.Font = UIFont.SystemFontOfSize (18);
			label.Frame=new  CGRect(0,0,300,40);
			label.TextColor = UIColor.Black;
			view.AddSubview (label);

			NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (0.3), delegate {
				maps.Frame = new CGRect(Frame.Location.X,60,Frame.Size.Width-6,Frame.Size.Height-60);

				view.AddSubview (maps);
			});

			SFShapeFileLayer layer = new SFShapeFileLayer ();
		
			layer.Uri = (NSString)NSBundle.MainBundle.PathForResource ("world1", "shp");

			layer.DataSource = GetDataSource();

			SFBubbleMarkerSetting marker = new SFBubbleMarkerSetting ();
			marker.MaxSize = 35;
			marker.MinSize = 25;
			marker.ValuePath = (NSString)"Population";
			SFShapeSetting shapeSettings = new SFShapeSetting ();
			shapeSettings.valuePath = (NSString)"Country";
			shapeSettings.Fill = UIColor.FromRGB (0xA9,0xD9,0xF7);
			shapeSettings.StrokeColor = UIColor.White;
			layer.ShapeSettings = shapeSettings;
			layer.ShowMapItems = true;
			layer.BubbleMarkerSetting = marker;
			maps.Layers.Add (layer);
			AddSubview (view);
			maps.Delegate = new MapsBubbleDelegate (this);

		}

		NSMutableArray GetDataSource()
		{
			NSMutableArray array = new NSMutableArray ();
			array.Add(getDictionary("BRA",204436000 ,22));
			array.Add(getDictionary("USA" ,321174000,167));
			array.Add(getDictionary("RUS" ,146267288,134));
			array.Add(getDictionary("IND" ,1272470000,73));
			array.Add(getDictionary("CHI" ,1370320000,30));
			array.Add(getDictionary("INO" ,255461700,72));

			return array;
		}

		NSDictionary getDictionary(string name,double population,int index)
		{
			NSString name1= (NSString)name;
			object[] objects= new object[3];
			object[] keys=new object[3];

			keys.SetValue ("Country", 0);
			keys.SetValue ("Population", 1);
			keys.SetValue ("index", 2);
			objects.SetValue (name1, 0);
			objects.SetValue (population, 1);
			objects.SetValue (index, 2);
			return NSDictionary.FromObjectsAndKeys (objects, keys);
		}


	}

	public class MapsBubbleDelegate:SFMapsDelegate
	{
		public MapsBubbleDelegate(BubbleVisualization bubble)
		{
			sample= bubble;
		}
		BubbleVisualization sample;

		public override void DidLoad (SFMap map)
		{
			if (sample.busyindicator != null) {
				sample.busyindicator.RemoveFromSuperview ();
				sample.busyindicator = null;
			}
		}
	}
}

