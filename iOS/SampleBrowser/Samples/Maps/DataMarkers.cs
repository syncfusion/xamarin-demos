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
	public class DataMarkers: SampleView
	{
		UILabel label;
		UIView view;
		UIView  markerView;
		UIView toastView;
		SFMap maps;
		internal SfBusyIndicator busyindicator;
        bool isDisposed;

		public override void LayoutSubviews ()
		{
			view.Frame =  new CGRect(Frame.Location.X,0,Frame.Size.Width,Frame.Size.Height);
			busyindicator.Frame =  new CGRect(Frame.Location.X,0,Frame.Size.Width,Frame.Size.Height);;
			markerView.Frame = new CGRect(Frame.Location.X+3,Frame.Size.Height-10,Frame.Size.Width-6,30);

			label.Frame=new CGRect(0,0,Frame.Size.Width,40);
			SetNeedsDisplay ();
		}

        protected override void Dispose(bool disposing)
        {
            isDisposed = true;
            base.Dispose(disposing);
        }

        public DataMarkers () 
		{

			view = new UIView ();
			busyindicator = new SfBusyIndicator();
			busyindicator.ViewBoxWidth=75;
			busyindicator.ViewBoxHeight=75;
			busyindicator.Foreground=  UIColor.FromRGB (0x77, 0x97, 0x72);  /*#779772*/
			busyindicator.AnimationType=SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
			view.AddSubview (busyindicator);

			NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (0.3), delegate {
                if (isDisposed)
                    return;
				maps.Frame = new CGRect(Frame.Location.X,60,Frame.Size.Width-6,Frame.Size.Height-60);

				view.AddSubview (maps);
			});
			view.Frame=new CGRect(0,0,300,400);
			markerView = new UIView ();
			label = new UILabel ();
			label.TextAlignment = UITextAlignment.Center;
			label.Text = "Top Population Countries";
			label.Font = UIFont.SystemFontOfSize (18);
			label.Frame=new  CGRect(0,0,300,40);
			label.TextColor = UIColor.Black;
			view.AddSubview (label);

			maps =new SFMap ();

			SFShapeFileLayer layer = new SFShapeFileLayer ();
			layer.Uri = (NSString)NSBundle.MainBundle.PathForResource ("world1", "shp");
			PopulationMarker usa= new PopulationMarker();
			usa.Latitude =38.8833;
			usa.Name ="United States";
			usa.Longitude=-77.0167;
			usa.Population ="321,174,000";			
			layer.Markers.Add(usa);


			PopulationMarker brazil= new PopulationMarker();
			brazil.Latitude=-15.7833;
			brazil.Longitude=-47.8667;
			brazil.Name ="Brazil";
			brazil.Population= "204,436,000";
			layer.Markers.Add(brazil);


			PopulationMarker india= new PopulationMarker();
			india.Latitude=21.0000;
			india.Longitude=78.0000;
			india.Name ="India";
			india.Population ="1,272,470,000";
			layer.Markers.Add(india);


			PopulationMarker china= new PopulationMarker();
			china.Latitude=35.0000;
			china.Longitude=103.0000;
			china.Name ="China";
			china.Population = "1,370,320,000";
			layer.Markers.Add(china);



			PopulationMarker indonesia= new PopulationMarker();
			indonesia.Latitude=-6.1750;
			indonesia.Longitude=106.8283;
			indonesia.Name ="Indonesia";
			indonesia.Population="255,461,700";
			layer.Markers.Add(indonesia);
			maps.Delegate = new MapsDelegate (this);

			maps.Layers.Add (layer);

			AddSubview (view);
			


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




	}

	public class MapsDelegate:SFMapsDelegate
	{
		public MapsDelegate(DataMarkers markers)
		{
			mar= markers;
		}
		DataMarkers mar;

		public override void DidLoad (SFMap map)
		{
			if (mar.busyindicator != null) {
				mar.busyindicator.RemoveFromSuperview ();
				mar.busyindicator = null;
			}
		}


        public override void OnMarkerSelected(SFMap map, MarkerSelectedEventArgs markerSelectedEventArgs)
        {
            PopulationMarker Populationmarker = (PopulationMarker)markerSelectedEventArgs.SelectedMarker;
            mar.displayToastWithMessage((NSString)(Populationmarker.Name + "\n"), (NSString)Populationmarker.Population);

        }

	}

	public class PopulationMarker : SFMapMarker
	{
		public PopulationMarker ()
		{
		}

		public string Population;

		public string Name;

		public override UIView GetView (CGPoint point)
		{

			UIImageView  image= new UIImageView (new CGRect (point.X - 8, point.Y - 25, 15, 23));
			image.Image = new UIImage ("pin.png");
			return image;

		}

		public override CGPoint GetPoint ()
		{
			return new CGPoint (-8, -25);
		}

	}


}

