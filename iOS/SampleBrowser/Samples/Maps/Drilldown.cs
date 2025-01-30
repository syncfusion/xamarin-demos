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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Drawing;
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
    public class Drilldown : SampleView
    {
        internal SfBusyIndicator busyindicator;
        UIView view;
        internal UILabel label;
        internal UIButton button;
        internal UILabel label1;
        internal UILabel label3;
        internal UILabel header;
        internal SFMap maps;
        internal SFShapeFileLayer layer;
        internal UIView layout;
        bool isDisposed;

        public override void LayoutSubviews()
        {
            view.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            busyindicator.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height); 
            header.Frame = new CGRect(Frame.Location.X, Frame.Size.Height - 50, Frame.Size.Width , 50);
            SetNeedsDisplay();
        }

        protected override void Dispose(bool disposing)
        {
            isDisposed = true;
            base.Dispose(disposing);
        }

        public Drilldown()
        {
            maps = new SFMap();
            maps.EnableZooming = false;
            view = new UIView();

            view.Frame = new CGRect(0, 0, 300, 400);
            busyindicator = new SfBusyIndicator();
            busyindicator.ViewBoxWidth = 75;
            busyindicator.ViewBoxHeight = 75;
            busyindicator.Foreground = UIColor.FromRGB(0x77, 0x97, 0x72);  /*#779772*/
            busyindicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
          

            layout = new UIView();
            layout.Frame = new CGRect(0, 0, 300, 50);
           
            button = new UIButton();
            button.Frame = new CGRect(0, 0, 100, 50);
            button.TouchUpInside += Button_TouchUpInside;
            button.BackgroundColor = UIColor.Clear;
            button.UserInteractionEnabled = true;
            button.Hidden = true;
           
            view.AddSubview(button);
         
            label = new UILabel();
            label.TextAlignment = UITextAlignment.Center;
            label.Text = "World Map";
            label.TextColor = UIColor.Blue;
            label.Font = UIFont.SystemFontOfSize(18);
            label.Frame = new CGRect(0, 0, 100, 50);

            layout.AddSubview(label);

            label1 = new UILabel();
            label1.TextAlignment = UITextAlignment.Center;
            label1.Text = " >> ";
            label1.Font = UIFont.SystemFontOfSize(18);
            label1.Frame = new CGRect(80, 0, 50, 50);

            layout.AddSubview(label1);

            label3 = new UILabel();
            label3.TextAlignment = UITextAlignment.Left;
            label3.Font = UIFont.SystemFontOfSize(18);
            label3.Frame = new CGRect(120, 0, 150, 50);

            layout.AddSubview(label3);
            layout.Hidden = true;
            AddSubview(layout);

            header = new UILabel();
            header.TextAlignment = UITextAlignment.Center;
            header.Text = "Click on a shape to drill";
            header.Font = UIFont.SystemFontOfSize(18);
            header.TextAlignment = UITextAlignment.Center;
           


            view.AddSubview(header);

            NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(0.3), delegate
            {
                if (isDisposed)
                    return;
                    
                maps.Frame = new CGRect(Frame.Location.X, 60, Frame.Size.Width - 6, Frame.Size.Height - 60);

                view.AddSubview(maps);
              
            });

            layer = new SFShapeFileLayer();

            layer.Uri = (NSString)NSBundle.MainBundle.PathForResource("world-map", "shp");
            layer.ShapeIDPath = (NSString)"country";
            layer.ShapeIDTableField = (NSString)"admin";
            layer.ShowMapItems = true;
            layer.EnableSelection = true;
            layer.DataSource = GetDataSource();

            SFShapeSetting shapeSettings = new SFShapeSetting();
            shapeSettings.ColorValuePath = (NSString)"continent";
            SetColorMapping(shapeSettings);
            layer.ShapeSettings = shapeSettings;

            ObservableCollection<SFMapMarker> markers = new ObservableCollection<SFMapMarker>();

            LabelMarker marker1 = new LabelMarker();
            marker1.Name = (NSString)"Asia";
            marker1.Latitude = 63.34303378997662;
            marker1.Longitude = 102.07617561287645;
            markers.Add(marker1);

            LabelMarker marker2 = new LabelMarker();
            marker2.Name = (NSString)"Australia";
            marker2.Latitude = -25.74775493367931;
            marker2.Longitude = 136.80451417932431;
            markers.Add(marker2);

            LabelMarker marker3 = new LabelMarker();
            marker3.Name = (NSString)"Africa";
            marker3.Latitude = 19.025302093442327;
            marker3.Longitude = 15.157534554671087;
            markers.Add(marker3);

            LabelMarker marker4 = new LabelMarker();
            marker4.Name = (NSString)"North America";
            marker4.Latitude = 59.88893689676585;
            marker4.Longitude = -109.3359375;
            markers.Add(marker4);

            LabelMarker marker5 = new LabelMarker();
            marker5.Name = (NSString)"Europe";
            marker5.Latitude = 47.95121990866204;
            marker5.Longitude = 18.468749999999998;
            markers.Add(marker5);

            LabelMarker marker6 = new LabelMarker();
            marker6.Name = (NSString)"South America";
            marker6.Latitude = -6.64607562172573;
            marker6.Longitude = -55.54687499999999;
            markers.Add(marker6);

            layer.Markers = markers;
            layer.ShapeSelectionChanged += DrilldownSelectionChanged;
            SFShapeFileLayer layer1 = new SFShapeFileLayer();
            layer1.Uri = (NSString)NSBundle.MainBundle.PathForResource("south-america", "shp");
            layer1.ShapeIDPath = (NSString)"country";
            layer1.ShapeIDTableField = (NSString)"admin";

            SFShapeSetting shapeSettings1 = new SFShapeSetting();
            shapeSettings1.Fill = UIColor.FromRGB(156, 51, 103);
            layer1.ShapeSettings = shapeSettings1;

            SFShapeFileLayer layer2 = new SFShapeFileLayer();
            layer2.Uri = (NSString)NSBundle.MainBundle.PathForResource("north-america", "shp");
            layer2.ShapeIDPath = (NSString)"country";
            layer2.ShapeIDTableField = (NSString)"admin";

            SFShapeSetting shapeSettings2 = new SFShapeSetting();
            shapeSettings2.Fill = UIColor.FromRGB(193, 54, 100);
            layer2.ShapeSettings = shapeSettings2;

            SFShapeFileLayer layer3 = new SFShapeFileLayer();
            layer3.Uri = (NSString)NSBundle.MainBundle.PathForResource("europe", "shp");
            layer3.ShapeIDPath = (NSString)"country";
            layer3.ShapeIDTableField = (NSString)"admin";

            SFShapeSetting shapeSettings3 = new SFShapeSetting();
            shapeSettings3.Fill = UIColor.FromRGB(98, 45, 108);
            layer3.ShapeSettings = shapeSettings3;

            SFShapeFileLayer layer4 = new SFShapeFileLayer();
            layer4.Uri = (NSString)NSBundle.MainBundle.PathForResource("africa", "shp");
            layer4.ShapeIDPath = (NSString)"country";
            layer4.ShapeIDTableField = (NSString)"admin";

            SFShapeSetting shapeSettings4 = new SFShapeSetting();
            shapeSettings4.Fill = UIColor.FromRGB(128, 48, 106);
            layer4.ShapeSettings = shapeSettings4;

            SFShapeFileLayer layer5 = new SFShapeFileLayer();
            layer5.Uri = (NSString)NSBundle.MainBundle.PathForResource("australia", "shp");
            layer5.ShapeIDPath = (NSString)"country";
            layer5.ShapeIDTableField = (NSString)"admin";

            SFShapeSetting shapeSettings5 = new SFShapeSetting();
            shapeSettings5.Fill = UIColor.FromRGB(42, 40, 112);
            layer5.ShapeSettings = shapeSettings5;

            SFShapeFileLayer layer6 = new SFShapeFileLayer();
            layer6.Uri = (NSString)NSBundle.MainBundle.PathForResource("asia", "shp");
            layer6.ShapeIDPath = (NSString)"country";
            layer6.ShapeIDTableField = (NSString)"admin";

            SFShapeSetting shapeSettings6 = new SFShapeSetting();
            shapeSettings6.Fill = UIColor.FromRGB(70, 42, 109);
            layer6.ShapeSettings = shapeSettings6;

            maps.Layers.Add(layer);
            maps.Layers.Add(layer1);
            maps.Layers.Add(layer2);
            maps.Layers.Add(layer3);
            maps.Layers.Add(layer4);
            maps.Layers.Add(layer5);
            maps.Layers.Add(layer6);

            AddSubview(view);
          
        }

        void DrilldownSelectionChanged(object sender, ShapeSelectedEventArgs args)         {             if (args.Data != null)             {                 NSDictionary dic = (NSDictionary)args.Data;                 NSString continent = (NSString)(dic["continent"]);                 label3.Text = continent;                 header.Hidden = true;                 layout.Hidden = false;                 button.Hidden = false;                 if (continent == "South America")                 {                     maps.BaseMapIndex = 1;                     layer.ShapeSettings.SelectedShapeColor = UIColor.FromRGB(156, 51, 103);                 }                 else if (continent == "North America")                 {                     maps.BaseMapIndex = 2;                     layer.ShapeSettings.SelectedShapeColor = UIColor.FromRGB(193, 54, 100);                 }                 else if (continent == "Europe")                 {                     maps.BaseMapIndex = 3;                     layer.ShapeSettings.SelectedShapeColor = UIColor.FromRGB(98, 45, 108);                 }                 else if (continent == "Africa")                 {                     maps.BaseMapIndex = 4;                     layer.ShapeSettings.SelectedShapeColor = UIColor.FromRGB(128, 48, 106);                 }                 else if (continent == "Australia")                 {                     maps.BaseMapIndex = 5;                     layer.ShapeSettings.SelectedShapeColor = UIColor.FromRGB(42, 40, 112);                 }                 else if (continent == "Asia")                 {                     maps.BaseMapIndex = 6;                     layer.ShapeSettings.SelectedShapeColor = UIColor.FromRGB(70, 42, 109);                 }             }         }  
        void Button_TouchUpInside(object sender, EventArgs e)
        {
            maps.BaseMapIndex = 0;
            header.Hidden = false;
            layout.Hidden = true;
            button.Hidden = true;
        }


        NSMutableArray GetDataSource()
        {
            NSMutableArray data = new NSMutableArray();

            data.Add(getDictionary("Afghanistan", "Asia"));
            data.Add(getDictionary("Angola", "Africa"));
            data.Add(getDictionary("Albania", "Europe"));
            data.Add(getDictionary("United Arab Emirates", "Asia"));
            data.Add(getDictionary("Argentina", "South America"));
            data.Add(getDictionary("Armenia", "Asia"));
            data.Add(getDictionary("French Southern and Antarctic Lands", "Seven seas (open ocean)"));
            data.Add(getDictionary("Australia", "Australia"));
            data.Add(getDictionary("Austria", "Europe"));
            data.Add(getDictionary("Azerbaijan", "Asia"));
            data.Add(getDictionary("Burundi", "Africa"));
            data.Add(getDictionary("Belgium", "Europe"));
            data.Add(getDictionary("Benin", "Africa"));
            data.Add(getDictionary("Burkina Faso", "Africa"));
            data.Add(getDictionary("Bangladesh", "Asia"));
            data.Add(getDictionary("Bulgaria", "Europe"));
            data.Add(getDictionary("The Bahamas", "North America"));
            data.Add(getDictionary("Bosnia and Herzegovina", "Europe"));
            data.Add(getDictionary("Belarus", "Europe"));
            data.Add(getDictionary("Belize", "North America"));
            data.Add(getDictionary("Bolivia", "South America"));
            data.Add(getDictionary("Brazil", "South America"));
            data.Add(getDictionary("Brunei", "Asia"));
            data.Add(getDictionary("Bhutan", "Asia"));
            data.Add(getDictionary("Botswana", "Africa"));
            data.Add(getDictionary("Central African Republic", "Africa"));
            data.Add(getDictionary("Canada", "North America"));
            data.Add(getDictionary("Switzerland", "Europe"));
            data.Add(getDictionary("Chile", "South America"));
            data.Add(getDictionary("China", "Asia"));
            data.Add(getDictionary("Ivory Coast", "Africa"));
            data.Add(getDictionary("Cameroon", "Africa"));
            data.Add(getDictionary("Democratic Republic of the Congo", "Africa"));
            data.Add(getDictionary("Republic of Congo", "Africa"));
            data.Add(getDictionary("Colombia", "South America"));
            data.Add(getDictionary("Costa Rica", "North America"));
            data.Add(getDictionary("Cuba", "North America"));
            data.Add(getDictionary("Northern Cyprus", "Asia"));
            data.Add(getDictionary("Cyprus", "Asia"));
            data.Add(getDictionary("Czech Republic", "Europe"));
            data.Add(getDictionary("Germany", "Europe"));
            data.Add(getDictionary("Djibouti", "Africa"));
            data.Add(getDictionary("Denmark", "Europe"));
            data.Add(getDictionary("Dominican Republic", "North America"));
            data.Add(getDictionary("Algeria", "Africa"));
            data.Add(getDictionary("Ecuador", "South America"));
            data.Add(getDictionary("Egypt", "Africa"));
            data.Add(getDictionary("Eritrea", "Africa"));
            data.Add(getDictionary("Spain", "Europe"));
            data.Add(getDictionary("Estonia", "Europe"));
            data.Add(getDictionary("Ethiopia", "Africa"));
            data.Add(getDictionary("Finland", "Europe"));
            data.Add(getDictionary("Fiji", "Australia"));
            data.Add(getDictionary("Falkland Islands", "South America"));
            data.Add(getDictionary("France", "Europe"));
            data.Add(getDictionary("Gabon", "Africa"));
            data.Add(getDictionary("United Kingdom", "Europe"));
            data.Add(getDictionary("Georgia", "Asia"));
            data.Add(getDictionary("Ghana", "Africa"));
            data.Add(getDictionary("Guinea", "Africa"));
            data.Add(getDictionary("Gambia", "Africa"));
            data.Add(getDictionary("Guinea Bissau", "Africa"));
            data.Add(getDictionary("Equatorial Guinea", "Africa"));
            data.Add(getDictionary("Greece", "Europe"));
            data.Add(getDictionary("Greenland", "North America"));
            data.Add(getDictionary("Guatemala", "North America"));
            data.Add(getDictionary("Guyana", "South America"));
            data.Add(getDictionary("Honduras", "North America"));
            data.Add(getDictionary("Croatia", "Europe"));
            data.Add(getDictionary("Haiti", "North America"));
            data.Add(getDictionary("Hungary", "Europe"));
            data.Add(getDictionary("Indonesia", "Asia"));
            data.Add(getDictionary("India", "Asia"));
            data.Add(getDictionary("Ireland", "Europe"));
            data.Add(getDictionary("Iran", "Asia"));
            data.Add(getDictionary("Iraq", "Asia"));
            data.Add(getDictionary("Iceland", "Europe"));
            data.Add(getDictionary("Israel", "Asia"));
            data.Add(getDictionary("Italy", "Europe"));
            data.Add(getDictionary("Jamaica", "North America"));
            data.Add(getDictionary("Jordan", "Asia"));
            data.Add(getDictionary("Japan", "Asia"));
            data.Add(getDictionary("Kazakhstan", "Asia"));
            data.Add(getDictionary("Kenya", "Africa"));
            data.Add(getDictionary("Kyrgyzstan", "Asia"));
            data.Add(getDictionary("Cambodia", "Asia"));
            data.Add(getDictionary("South Korea", "Asia"));
            data.Add(getDictionary("Kosovo", "Europe"));
            data.Add(getDictionary("Kuwait", "Asia"));
            data.Add(getDictionary("Laos", "Asia"));
            data.Add(getDictionary("Lebanon", "Asia"));
            data.Add(getDictionary("Liberia", "Africa"));
            data.Add(getDictionary("Libya", "Africa"));
            data.Add(getDictionary("Sri Lanka", "Asia"));
            data.Add(getDictionary("Lesotho", "Africa"));
            data.Add(getDictionary("Lithuania", "Europe"));
            data.Add(getDictionary("Luxembourg", "Europe"));
            data.Add(getDictionary("Latvia", "Europe"));
            data.Add(getDictionary("Morocco", "Africa"));
            data.Add(getDictionary("Moldova", "Europe"));
            data.Add(getDictionary("Madagascar", "Africa"));
            data.Add(getDictionary("Mexico", "North America"));
            data.Add(getDictionary("Macedonia", "Europe"));
            data.Add(getDictionary("Mali", "Africa"));
            data.Add(getDictionary("Myanmar", "Asia"));
            data.Add(getDictionary("Montenegro", "Europe"));
            data.Add(getDictionary("Mongolia", "Asia"));
            data.Add(getDictionary("Mozambique", "Africa"));
            data.Add(getDictionary("Mauritania", "Africa"));
            data.Add(getDictionary("Malawi", "Africa"));
            data.Add(getDictionary("Malaysia", "Asia"));
            data.Add(getDictionary("Namibia", "Africa"));
            data.Add(getDictionary("New Caledonia", "Australia"));
            data.Add(getDictionary("Niger", "Africa"));
            data.Add(getDictionary("Nigeria", "Africa"));
            data.Add(getDictionary("Nicaragua", "North America"));
            data.Add(getDictionary("Netherlands", "Europe"));
            data.Add(getDictionary("Norway", "Europe"));
            data.Add(getDictionary("Nepal", "Asia"));
            data.Add(getDictionary("New Zealand", "Australia"));
            data.Add(getDictionary("Oman", "Asia"));
            data.Add(getDictionary("Pakistan", "Asia"));
            data.Add(getDictionary("Panama", "North America"));
            data.Add(getDictionary("Peru", "South America"));
            data.Add(getDictionary("Philippines", "Asia"));
            data.Add(getDictionary("Papua New Guinea", "Australia"));
            data.Add(getDictionary("Poland", "Europe"));
            data.Add(getDictionary("Puerto Rico", "North America"));
            data.Add(getDictionary("North Korea", "Asia"));
            data.Add(getDictionary("Portugal", "Europe"));
            data.Add(getDictionary("Paraguay", "South America"));
            data.Add(getDictionary("Palestine", "Asia"));
            data.Add(getDictionary("Qatar", "Asia"));
            data.Add(getDictionary("Romania", "Europe"));
            data.Add(getDictionary("Russia", "Asia"));
            data.Add(getDictionary("Rwanda", "Africa"));
            data.Add(getDictionary("Western Sahara", "Africa"));
            data.Add(getDictionary("Saudi Arabia", "Asia"));
            data.Add(getDictionary("Sudan", "Africa"));
            data.Add(getDictionary("South Sudan", "Africa"));
            data.Add(getDictionary("Senegal", "Africa"));
            data.Add(getDictionary("Solomon Islands", "Australia"));
            data.Add(getDictionary("Sierra Leone", "Africa"));
            data.Add(getDictionary("El Salvador", "North America"));
            data.Add(getDictionary("Somaliland", "Africa"));
            data.Add(getDictionary("Somalia", "Africa"));
            data.Add(getDictionary("Republic of Serbia", "Europe"));
            data.Add(getDictionary("Suriname", "South America"));
            data.Add(getDictionary("Slovakia", "Europe"));
            data.Add(getDictionary("Slovenia", "Europe"));
            data.Add(getDictionary("Sweden", "Europe"));
            data.Add(getDictionary("Swaziland", "Africa"));
            data.Add(getDictionary("Syria", "Asia"));
            data.Add(getDictionary("Chad", "Africa"));
            data.Add(getDictionary("Togo", "Africa"));
            data.Add(getDictionary("Thailand", "Asia"));
            data.Add(getDictionary("Tajikistan", "Asia"));
            data.Add(getDictionary("Turkmenistan", "Asia"));
            data.Add(getDictionary("East Timor", "Asia"));
            data.Add(getDictionary("Trinidad and Tobago", "North America"));
            data.Add(getDictionary("Tunisia", "Africa"));
            data.Add(getDictionary("Turkey", "Asia"));
            data.Add(getDictionary("Taiwan", "Asia"));
            data.Add(getDictionary("United Republic of Tanzania", "Africa"));
            data.Add(getDictionary("Uganda", "Africa"));
            data.Add(getDictionary("Ukraine", "Europe"));
            data.Add(getDictionary("Uruguay", "South America"));
            data.Add(getDictionary("United States of America", "North America"));
            data.Add(getDictionary("Uzbekistan", "Asia"));
            data.Add(getDictionary("Venezuela", "South America"));
            data.Add(getDictionary("Vietnam", "Asia"));
            data.Add(getDictionary("Vanuatu", "Australia"));
            data.Add(getDictionary("Yemen", "Asia"));
            data.Add(getDictionary("South Africa", "Africa"));
            data.Add(getDictionary("Zambia", "Africa"));
            data.Add(getDictionary("Zimbabwe", "Africa"));

            return data;
        }
        NSDictionary getDictionary(string country, string continent)
        {
            NSString name1 = (NSString)country;
            NSString name2 = (NSString)continent;
            object[] objects = new object[2];
            object[] keys = new object[2];
            keys.SetValue("country", 0);
            keys.SetValue("continent", 1);
            objects.SetValue(name1, 0);
            objects.SetValue(name2, 1);
            return NSDictionary.FromObjectsAndKeys(objects, keys);
        }

        void SetColorMapping(SFShapeSetting setting)
        {
            ObservableCollection<SFMapColorMapping> colorMappings = new ObservableCollection<SFMapColorMapping>();

            SFEqualColorMapping colorMapping1 = new SFEqualColorMapping();
            colorMapping1.Value = (NSString)"North America";
            colorMapping1.Color = UIColor.FromRGB(193, 54, 100);
            colorMappings.Add(colorMapping1);

            SFEqualColorMapping colorMapping2 = new SFEqualColorMapping();
            colorMapping2.Value = (NSString)"South America";
            colorMapping2.Color = UIColor.FromRGB(156, 51, 103);
            colorMappings.Add(colorMapping2);

            SFEqualColorMapping colorMapping3 = new SFEqualColorMapping();
            colorMapping3.Value = (NSString)"Africa";
            colorMapping3.Color = UIColor.FromRGB(128, 48, 106);
            colorMappings.Add(colorMapping3);

            SFEqualColorMapping colorMapping4 = new SFEqualColorMapping();
            colorMapping4.Value = (NSString)"Europe";
            colorMapping4.Color = UIColor.FromRGB(98, 45, 108);
            colorMappings.Add(colorMapping4);

            SFEqualColorMapping colorMapping5 = new SFEqualColorMapping();
            colorMapping5.Value = (NSString)"Asia";
            colorMapping5.Color = UIColor.FromRGB(70, 42, 109);
            colorMappings.Add(colorMapping5);

            SFEqualColorMapping colorMapping6 = new SFEqualColorMapping();
            colorMapping6.Value = (NSString)"Australia";
            colorMapping6.Color = UIColor.FromRGB(42, 40, 112);
            colorMappings.Add(colorMapping6);

            setting.ColorMappings = colorMappings;
        }

    }

    public class LabelMarker : SFMapMarker
    {
        public string Name;

        public LabelMarker()
        {
        }

        public override UIView GetView(CGPoint point)
        {
            UIView view = new UIView();
            view.Frame = new CGRect(point.X - 50, point.Y - 15, 100, 50);
            int y = 0;
            var labels = Name.Split(' ', '\t');
            for (int j = 0; j < labels.Length; j++)
            {
                UILabel labelView = new UILabel(new CGRect(0, y, 100, 20));

                labelView.TextAlignment = UITextAlignment.Center;
                labelView.Text = labels[j];
                labelView.TextColor = UIColor.FromRGB(190, 232, 162);
                labelView.Font = UIFont.SystemFontOfSize(12);
                view.AddSubview(labelView);
                y += 20;
            }
                    
            return view;
        }
    }
}
