#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Syncfusion.SfBusyIndicator.iOS;


#endregion
using System;
using Syncfusion.SfMaps.iOS;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
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
	public class ColorMapping: SampleView
	{
		internal SFBusyIndicator busyindicator;
		UIView view;
		UILabel label;
		UIView  markerView;
		UIView toastView;
		SFShapeFileLayer layer;

		public override void LayoutSubviews ()
		{
			view.Frame =  new CGRect(Frame.Location.X,0.0f,Frame.Size.Width,Frame.Size.Height);
			busyindicator.Frame =  new CGRect(Frame.Location.X,0.0f,Frame.Size.Width,Frame.Size.Height);;
			markerView.Frame = new CGRect(Frame.Location.X+3,Frame.Size.Height-10,Frame.Size.Width-6,30);
			layer.LegendSettings.Position = new CGPoint (15, Frame.Height - 100);
			label.Frame=new CGRect(0f,0f,Frame.Size.Width,40);
			SetNeedsDisplay ();
		}
		public ColorMapping ()
		{
			SFMap	maps = new SFMap ();
			view = new UIView ();
			busyindicator = new SFBusyIndicator ();
			busyindicator.ViewBoxWidth=75;
			busyindicator.ViewBoxHeight=75;
			busyindicator.Foreground=  UIColor.FromRGB (0x77, 0x97, 0x72);  /*#779772*/
			busyindicator.AnimationType=SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
			view.AddSubview (busyindicator);

			NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (0.3), delegate {
				maps.Frame = new CGRect(Frame.Location.X,60,Frame.Size.Width-6,Frame.Size.Height-60);

				view.AddSubview (maps);
			});
			view.Frame=new CGRect(0,0,300,400);
			markerView = new UIView ();
			label = new UILabel ();
			label.TextAlignment = UITextAlignment.Center;
			label.Text = "Primary Agricultural Activity of USA";
			label.Font = UIFont.SystemFontOfSize (18);
			label.Frame=new  CGRect(0,0,300,40);
			label.TextColor = UIColor.Black;
			view.AddSubview (label);



			layer = new SFShapeFileLayer();
			layer.Uri = (NSString)NSBundle.MainBundle.PathForResource ("usa_state", "shp");
			layer.DataSource = GetDataSource ();
			SetColorMapping(layer.ShapeSettings);
			layer.ShapeSettings.ColorValuePath =(NSString)"Type";
			layer.ShapeSettings.StrokeColor = UIColor.White;
			layer.LegendSettings = new SFMapLegendSettings ();
			layer.LegendSettings.Position = new CGPoint (5, 75);
			layer.LegendSettings.ShowLegend = true;
			layer.EnableSelection = true;
			maps.Layers.Add (layer);
			AddSubview (view);
			maps.Delegate = new MapsColorMappingDelegate (this);

			
		}

		NSMutableArray GetDataSource()
		{
			NSMutableArray array = new NSMutableArray ();

			array.Add(getDictionary("Alabama" , "Vegetables" , 42));
			array.Add(getDictionary( "Alaska" , "Vegetables" , 0 ));
			array.Add(getDictionary( "Arizona" , "Rice" , 36 ));
			array.Add(getDictionary( "Arkansas" , "Vegetables" , 46 ));
			array.Add(getDictionary( "California" , "Rice" , 24 ));
			array.Add(getDictionary( "Colorado" , "Rice" , 31));
			array.Add(getDictionary( "Connecticut" , "Grains" , 18 ));
			array.Add(getDictionary( "Delaware" , "Grains" , 28 ));
			array.Add(getDictionary( "District of Columbia" , "Grains" , 27 ));
			array.Add(getDictionary( "Florida" , "Rice" , 48 ));
			array.Add(getDictionary( "Georgia" , "Rice" , 44));
			array.Add(getDictionary( "Hawaii" , "Grains" , 49 ));
			array.Add(getDictionary( "Idaho" , "Grains" , 8 ));
			array.Add(getDictionary( "Illinois" , "Vegetables" , 26 ));
			array.Add(getDictionary( "Indiana" , "Grains" , 21 ));
			array.Add(getDictionary( "Iowa" , "Vegetables" , 13 ));
			array.Add(getDictionary( "Kansas" , "Rice" , 33 ));
			array.Add(getDictionary( "Kentucky" , "Grains" , 32 ));
			array.Add(getDictionary( "Louisiana" , "Rice" , 47 ));
			array.Add(getDictionary( "Maine" , "Grains" , 3 ));
			array.Add(getDictionary( "Maryland" , "Grains" , 30 ));
			array.Add(getDictionary( "Massachusetts" , "Grains" , 14 ));
			array.Add(getDictionary( "Michigan" , "Grains" , 50 ));
			array.Add(getDictionary( "Minnesota" , "Wheat" , 10 ));
			array.Add(getDictionary( "Mississippi" , "Vegetables" , 43 ));
			array.Add(getDictionary( "Missouri" , "Vegetables" , 35 ));
			array.Add(getDictionary( "Montana" , "Grains" , 2 ));
			array.Add(getDictionary( "Nebraska" , "Rice" , 15 ));
			array.Add(getDictionary( "Nevada" , "Wheat" , 22 ));
			array.Add(getDictionary( "New Hampshire" , "Grains" , 12 ));
			array.Add(getDictionary( "New Jersey" , "Vegetables" , 20 ));
			array.Add(getDictionary( "New Mexico" , "Rice" , 41 ));
			array.Add(getDictionary( "New York" , "Vegetables" , 16 ));
			array.Add(getDictionary( "North Carolina" , "Rice" , 38 ));
			array.Add(getDictionary( "North Dakota" , "Grains" , 4 ));
			array.Add(getDictionary( "Ohio" , "Vegetables" , 25 ));
			array.Add(getDictionary( "Oklahoma" , "Rice" , 37 ));
			array.Add(getDictionary( "Oregon" , "Wheat" , 11 ));
			array.Add(getDictionary( "Pennsylvania" , "Vegetables" , 17 ));
			array.Add(getDictionary( "Rhode Island" , "Grains" , 19 ));
			array.Add(getDictionary( "South Carolina" , "Rice" , 45 ));
			array.Add(getDictionary( "South Dakota" , "Grains" , 5 ));
			array.Add(getDictionary( "Tennessee" , "Vegetables" , 39 ));
			array.Add(getDictionary( "Texas" , "Vegetables" , 40 ));
			array.Add(getDictionary( "Utah" , "Rice" , 23 ));
			array.Add(getDictionary( "Vermont" , "Grains" , 9 ));
			array.Add(getDictionary( "Virginia" , "Rice" , 34 ));
			array.Add(getDictionary( "Washington" , "Vegetables" , 1 ));
			array.Add(getDictionary( "West Virginia" , "Grains" , 29 ));
			array.Add(getDictionary( "Wisconsin" , "Grains" , 7 ));
			array.Add(getDictionary( "Wyoming" , "Wheat" , 6 ));
			return array;
		}

		public void displayToastWithMessage(NSString toastMessage,NSString typeLabel)
		{   

			UIWindow keyWindow = UIApplication.SharedApplication.KeyWindow;
			if(toastView!=null)
			{
				toastView.RemoveFromSuperview();
			}


			toastView = new UIView ();
			UILabel label1 = new UILabel ();
			UILabel label2=new UILabel ();
			label1.TextColor = label2.TextColor = UIColor.White;
			label1.Font = UIFont.SystemFontOfSize (16);
			label1.Text= toastMessage;
			label2.Text = typeLabel;
			label2.Font =UIFont.SystemFontOfSize (12);
			label1.TextAlignment = label2.TextAlignment = UITextAlignment.Center;;
			toastView.AddSubview (label1);
			toastView.AddSubview (label2);

			toastView.Alpha =1;

			toastView.BackgroundColor = UIColor.Black.ColorWithAlpha (0.7f);
			toastView.Layer.CornerRadius = 10;

			CGSize expectedLabelSize1= toastMessage.GetSizeUsingAttributes (new UIStringAttributes() { Font = label1.Font });
			CGSize expectedLabelSize2= typeLabel.GetSizeUsingAttributes (new UIStringAttributes() { Font = label2.Font });
			keyWindow.AddSubview(toastView);
			toastView.Frame = new CGRect(0.0f, 0.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width)+20, 45.0f);
			label1.Frame = new CGRect(0.0f, 5.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width)+15, 15.0f);
			label2.Frame = new CGRect(0.0f, 25.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width)+15, 15.0f);


			toastView.Center = markerView.Center;


			UIView.Animate (4, 0, UIViewAnimationOptions.CurveEaseInOut,
				() => {
					toastView.Alpha= 0.7f;
				}, 
				() => {

					toastView.RemoveFromSuperview();
				}
			);


		}


		NSDictionary getDictionary(string name,string type,int index)
		{
			NSString name1= (NSString)name;
			object[] objects= new object[3];
			object[] keys=new object[3];
			keys.SetValue ("Country", 0);
			keys.SetValue ("index", 1);
			keys.SetValue ("Type", 2);
			objects.SetValue (name1, 0);
			objects.SetValue (index, 1);
			objects.SetValue (type, 2);
			return NSDictionary.FromObjectsAndKeys (objects, keys);
		}

		void SetColorMapping(SFShapeSetting setting)
		{
			NSMutableArray colorMappings = new NSMutableArray ();
			SFEqualColorMapping colorMapping1= new SFEqualColorMapping();
			colorMapping1.Value= (NSString)"Vegetables";
			colorMapping1.LegendLabel= (NSString)"Vegetables";
			colorMapping1.Color =  UIColor.FromRGB (0x29, 0xBB, 0x9C);
			colorMappings.Add(colorMapping1);

			SFEqualColorMapping colorMapping2= new SFEqualColorMapping();
			colorMapping2.Value=(NSString) "Rice";
			colorMapping2.LegendLabel= (NSString)"Rice";
			colorMapping2.Color = UIColor.FromRGB (0xFD, 0x8C, 0x48);
			colorMappings.Add(colorMapping2);

			SFEqualColorMapping colorMapping3= new SFEqualColorMapping();
			colorMapping3.Value=(NSString) "Wheat";
			colorMapping3.LegendLabel= (NSString)"Wheat";
			colorMapping3.Color =UIColor.FromRGB (0xE5, 0x4D, 0x42);
			colorMappings.Add(colorMapping3);

			SFEqualColorMapping colorMapping4= new SFEqualColorMapping();
			colorMapping4.Value= (NSString)"Grains";
			colorMapping4.LegendLabel= (NSString)"Grains";
			colorMapping4.Color =UIColor.FromRGB (0x3A, 0x99, 0xD9);
			colorMappings.Add(colorMapping4);

			setting.ColorMappings = colorMappings;
		}

	}

	public class MapsColorMappingDelegate:SFMapsDelegate
	{
		public MapsColorMappingDelegate(ColorMapping sample)
		{
			mapping= sample;
		}
		ColorMapping mapping;

		public override void DidLoad (SFMap map)
		{
			if (mapping.busyindicator != null) {
				mapping.busyindicator.RemoveFromSuperview ();
				mapping.busyindicator = null;
			}
		}

		public override void DidSelectShape (SFMap map, NSObject data)
		{
			if(data!=null)
			{
				
			NSDictionary dic = (NSDictionary)data;


			mapping.displayToastWithMessage ((NSString)(dic["Country"] +"\n") ,(NSString)dic["Type"]);
			}
		}




	}
}

