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
using System.Collections.ObjectModel;
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
        bool TapGesture_ShouldReceiveTouch(UIGestureRecognizer recognizer, UITouch touch)
        {
            if (touch.TapCount == 1)
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population"));
            }
            return true;
        }

        internal SfBusyIndicator busyindicator;
        UIView view;
        UILabel label;
        UILabel label2;
        CGSize label2Size;
        bool isDisposed;

        public override void LayoutSubviews ()
        {
            view.Frame =  new CGRect(Frame.Location.X,0,Frame.Size.Width,Frame.Size.Height);
            busyindicator.Frame =  new CGRect(Frame.Location.X,0,Frame.Size.Width,Frame.Size.Height);
            label.Frame = new CGRect(0f, 0f, Frame.Size.Width, 40);
            label2.Frame = new CGRect(Frame.Size.Width - 50,
                                          Frame.Size.Height - 20,
                                      Frame.Size.Width, 20);
            SetNeedsDisplay ();

        }
       
        protected override void Dispose(bool disposing)
        {
            isDisposed = true;
            base.Dispose(disposing);
        }

        public BubbleVisualization ()
        {
            
            SFMap maps = new SFMap ();
            view = new UIView ();
            view.Frame=new CGRect(0,0,300,400);
            busyindicator = new SfBusyIndicator();
            busyindicator.ViewBoxWidth=75;
            busyindicator.ViewBoxHeight=75;
            busyindicator.Foreground=  UIColor.FromRGB (0x77, 0x97, 0x72);  /*#779772*/
            busyindicator.AnimationType=SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
            view.AddSubview (busyindicator);
            label = new UILabel ();
            label.TextAlignment = UITextAlignment.Center;
            label.Text = "Top 40 Population Countries With Bubbles";
			label.Font = UIFont.SystemFontOfSize (18);
			label.Frame=new  CGRect(0,0,400,40);
			label.TextColor = UIColor.Black;
			view.AddSubview (label);

			NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (0.3), delegate {
                if (isDisposed)
                    return;
				maps.Frame = new CGRect(Frame.Location.X,60,Frame.Size.Width-6,Frame.Size.Height-60);

				view.AddSubview (maps);
			});

			SFShapeFileLayer layer = new SFShapeFileLayer ();
            layer.Uri = (NSString)NSBundle.MainBundle.PathForResource("world1", "shp");
            layer.ShapeIDPath = (NSString)"Country";
            layer.ShapeIDTableField = (NSString)"NAME";
            layer.ShowMapItems = true;
			layer.DataSource = GetDataSource();

			SFShapeSetting shapeSettings = new SFShapeSetting ();
            shapeSettings.Fill = UIColor.LightGray;
			layer.ShapeSettings = shapeSettings;
			
            SFBubbleMarkerSetting marker = new SFBubbleMarkerSetting();
            marker.ValuePath = (NSString)"Percent";
            marker.ColorValuePath = (NSString)"Percent";

            BubbleCustomTooltipSetting tooltipSetting = new BubbleCustomTooltipSetting();
            tooltipSetting.ShowTooltip = true;
            marker.TooltipSettings = tooltipSetting;

            ObservableCollection<SFMapColorMapping> colorMappings = new ObservableCollection<SFMapColorMapping>();

            SFRangeColorMapping rangeColorMapping1 = new SFRangeColorMapping();
            rangeColorMapping1.To = 20;
            rangeColorMapping1.From = 4;
            rangeColorMapping1.LegendLabel = (NSString)"Above 4%";
            rangeColorMapping1.Color = UIColor.FromRGB(46, 118, 159);
            colorMappings.Add(rangeColorMapping1);

            SFRangeColorMapping rangeColorMapping2 = new SFRangeColorMapping();
            rangeColorMapping2.To = 4;
            rangeColorMapping2.From = 2;
            rangeColorMapping2.LegendLabel = (NSString)"4% - 2%";
            rangeColorMapping2.Color = UIColor.FromRGB(216, 68, 68);
            colorMappings.Add(rangeColorMapping2);

            SFRangeColorMapping rangeColorMapping3 = new SFRangeColorMapping();
            rangeColorMapping3.To = 2;
            rangeColorMapping3.From = 1;
            rangeColorMapping3.LegendLabel = (NSString)"2% - 1%";
            rangeColorMapping3.Color = UIColor.FromRGB(129, 111, 40);
            colorMappings.Add(rangeColorMapping3);

            SFRangeColorMapping rangeColorMapping4 = new SFRangeColorMapping();
            rangeColorMapping4.To = 1;
            rangeColorMapping4.From = 0;
            rangeColorMapping4.LegendLabel = (NSString)"Below 1%";
            rangeColorMapping4.Color = UIColor.FromRGB(127, 56, 160);
            colorMappings.Add(rangeColorMapping4);

            marker.ColorMappings = colorMappings;
           
			layer.BubbleMarkerSetting = marker;

            SFMapLegendSettings mapLegendSettings = new SFMapLegendSettings();
            mapLegendSettings.ShowLegend = true;
            mapLegendSettings.LegendType = LegendType.Bubbles;
           
            layer.LegendSettings = mapLegendSettings;

			maps.Layers.Add (layer);
			

            label2 = new UILabel();
            label2.TextAlignment = UITextAlignment.Center;
            var text1 = new NSString("en.wikipedia.org");
            label2.Text = text1;
            label2.Font = UIFont.SystemFontOfSize(12);
            var stringAtribute = new NSDictionary(UIStringAttributeKey.Font, label2.Font,
                                                  UIStringAttributeKey.ForegroundColor, UIColor.FromRGB(0, 191, 255));
            UIStringAttributes strAtr1 = new UIStringAttributes(stringAtribute);
            label2Size = text1.GetSizeUsingAttributes(strAtr1);
            label2.TextColor = UIColor.FromRGB(0, 191, 255);
            label2.Frame = new CGRect(Frame.Size.Width, Frame.Size.Height - 20, 100, 20);
            label2.UserInteractionEnabled = true;
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer();
            tapGesture.ShouldReceiveTouch += TapGesture_ShouldReceiveTouch;
            label2.AddGestureRecognizer(tapGesture);

            view.AddSubview(label2);

            AddSubview (view);
            maps.Delegate = new MapsBubbleDelegate (this);

        }

        NSMutableArray GetDataSource()
        {
            NSMutableArray array = new NSMutableArray ();
            array.Add(getDictionary("China", 1393730000, 18.2));
            array.Add(getDictionary("India", 1336180000, 17.5));
            array.Add(getDictionary("United States", 327726000, 4.29));
            array.Add(getDictionary("Indonesia", 265015300, 3.47));
            array.Add(getDictionary("Pakistan", 209503000, 2.78));
            array.Add(getDictionary("Brazil", 201795000, 2.74));
            array.Add(getDictionary("Nigeria", 197306006, 2.53));
            array.Add(getDictionary("Bangladesh", 165086000, 2.16));
            array.Add(getDictionary("Russia", 146877088, 1.92));
            array.Add(getDictionary("Japan", 126490000, 1.66));
            array.Add(getDictionary("Mexico", 124737789, 1.63));
            array.Add(getDictionary("Ethiopia", 107534882, 1.41));
            array.Add(getDictionary("Philippines", 106375000, 1.39));
            array.Add(getDictionary("Egypt", 97459100, 1.27));
            array.Add(getDictionary("Vietnam", 94660000, 1.24));
            array.Add(getDictionary("Germany", 82740900, 1.08));
            array.Add(getDictionary("Iran", 81737800, 1.07));
            array.Add(getDictionary("Turkey", 80810525, 1.06));
            array.Add(getDictionary("Thailand", 69183173, 0.91));
            array.Add(getDictionary("France", 67297000, 0.88));
            array.Add(getDictionary("United Kingdom", 66040229, 0.86));
            array.Add(getDictionary("Italy", 60436469, 0.79));
            array.Add(getDictionary("South Africa", 57725600, 0.76));
            array.Add(getDictionary("Colombia", 49918600, 0.65));
            array.Add(getDictionary("Spain", 46659302, 0.61));
            array.Add(getDictionary("Argentina", 44494502, 0.58));
            array.Add(getDictionary("Poland", 38433600, 0.5));
            array.Add(getDictionary("Canada", 37206700, 0.48));
            array.Add(getDictionary("Saudi Arabia", 33413660, 0.44));
            array.Add(getDictionary("Malaysia", 32647000, 0.42));
            array.Add(getDictionary("Nepal", 29218867, 0.38));
            array.Add(getDictionary("Australia", 25015400, 0.32));
            array.Add(getDictionary("Kazakhstan", 18253300, 0.24));
            array.Add(getDictionary("Cambodia", 16069921, 0.21));
            array.Add(getDictionary("Belgium", 11414214, 0.15));
            array.Add(getDictionary("Greece", 10768193, 0.14));
            array.Add(getDictionary("Sweden", 10171524, 0.13));
            array.Add(getDictionary("Somalia", 15181925, 0.12));
            array.Add(getDictionary("Austria", 8830487, 0.12));
            array.Add(getDictionary("Bulgaria", 7050034, 0.092));
            
			return array;
		}

        NSDictionary getDictionary(string name,double population,double percent)
		{
			NSString name1= (NSString)name;
			object[] objects= new object[3];
			object[] keys=new object[3];

			keys.SetValue ("Country", 0);
			keys.SetValue ("Population", 1);
			keys.SetValue ("Percent", 2);
			objects.SetValue (name1, 0);
			objects.SetValue (population, 1);
			objects.SetValue (percent, 2);
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

    public class BubbleCustomTooltipSetting : TooltipSetting
    {
        public BubbleCustomTooltipSetting()
        {

        }

        public override UIView GetView(object shapeData)
        {
            NSDictionary dic = (NSDictionary)shapeData;

            UIView view = new UIView();
            NSString topText = (NSString)(dic["Country"]);
            NSString bottomText = (NSString)(dic["Percent"].ToString() + "%");

            UILabel topLabel = new UILabel();
            topLabel.Text = topText;
            topLabel.Font = UIFont.SystemFontOfSize(12);
            topLabel.TextColor = UIColor.White;
            topLabel.TextAlignment = UITextAlignment.Center;

            UILabel bottomLabel = new UILabel();
            bottomLabel.Text = bottomText;
            bottomLabel.Font = UIFont.SystemFontOfSize(12);
            bottomLabel.TextColor = UIColor.White;
            bottomLabel.TextAlignment = UITextAlignment.Center;

            view.AddSubview(topLabel);
            view.AddSubview(bottomLabel);

            CGSize expectedLabelSize1 = topText.GetSizeUsingAttributes(new UIStringAttributes() { Font = topLabel.Font });
            CGSize expectedLabelSize2 = bottomText.GetSizeUsingAttributes(new UIStringAttributes() { Font = bottomLabel.Font });

            view.Frame = new CGRect(0.0f, 0.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width), 35.0f);
            topLabel.Frame = new CGRect(0.0f, 0.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width), 15.0f);
            bottomLabel.Frame = new CGRect(0.0f, 20.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width), 15.0f);

            return view;
        }
    }
}

