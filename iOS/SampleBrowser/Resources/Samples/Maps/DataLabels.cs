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
    public class DataLabels : SampleView
    {
        internal SFBusyIndicator busyindicator;
        UIPickerView smartLabelMode;
        UIPickerView intersectActionMode;
        UIView option = new UIView();
        UIView view;
        UILabel label;
        SFShapeFileLayer layer;

        public override void LayoutSubviews()
        {
            view.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            busyindicator.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height); ;
            SetNeedsDisplay();
        }
        public DataLabels()
        {
            smartLabelMode = new UIPickerView();
            intersectActionMode = new UIPickerView();

            SFMap maps = new SFMap();
            view = new UIView();
            view.Frame = new CGRect(0, 0, 300, 400);
            busyindicator = new SFBusyIndicator();
            busyindicator.ViewBoxWidth = 75;
            busyindicator.ViewBoxHeight = 75;
            busyindicator.Foreground = UIColor.FromRGB(0x77, 0x97, 0x72);  /*#779772*/
            busyindicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
            view.AddSubview(busyindicator);

            NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(0.3), delegate {
                maps.Frame = new CGRect(Frame.Location.X, 60, Frame.Size.Width - 6, Frame.Size.Height - 60);

                view.AddSubview(maps);
            });

            layer = new SFShapeFileLayer();

            layer.Uri = (NSString)NSBundle.MainBundle.PathForResource("usa_state", "shp");
            layer.ShapeIDPath = (NSString)"Name";
            layer.ShapeIDTableField = (NSString)"STATE_NAME";
            layer.ShowMapItems = true;
            layer.DataSource = GetDataSource();

            SFShapeSetting shapeSettings = new SFShapeSetting();
            shapeSettings.ColorValuePath = (NSString)"Type";
            shapeSettings.ValuePath = (NSString)"Name";
            shapeSettings.Fill = UIColor.FromRGB(169, 217, 247);
            SetColorMapping(shapeSettings);
            layer.ShapeSettings = shapeSettings;

            SFDataLabelSetting dataLabelSetting = new SFDataLabelSetting();
            dataLabelSetting.SmartLabelMode = IntersectAction.Trim;
            dataLabelSetting.IntersectionAction = IntersectAction.None;
            layer.DataLabelSettings = dataLabelSetting;

            maps.Layers.Add(layer);
            AddSubview(view);
            CreateOptionView();
            this.OptionView = option;
            maps.Delegate = new MapsDataLabelsDelegate(this);
        }

        private void CreateOptionView()
        {

            UILabel text1 = new UILabel();
            text1.Text = "SmartLabelMode";
            text1.TextAlignment = UITextAlignment.Left;
            text1.TextColor = UIColor.Black;
            text1.Frame = new CGRect(10, 10, 320, 40);
            text1.Font = UIFont.FromName("Helvetica", 14f);

            List<string> position1 = new List<string> { "None", "Trim", "Hide" };
            var picker1 = new SmartLabelPickerModel(position1);

            smartLabelMode.Model = picker1;
            smartLabelMode.SelectedRowInComponent(0);
            smartLabelMode.Frame = new CGRect(10, 50, 200, 40);
            picker1.ValueChanged += (sender, e) =>
            {
                if (picker1.SelectedValue == "None")
                    layer.DataLabelSettings.SmartLabelMode = IntersectAction.None;
                else if (picker1.SelectedValue == "Trim")
                    layer.DataLabelSettings.SmartLabelMode = IntersectAction.Trim;
                else if (picker1.SelectedValue == "Hide")
                    layer.DataLabelSettings.SmartLabelMode = IntersectAction.Hide;
               
            };

            UILabel text2 = new UILabel();
            text2.Text = "Intersection Action";
            text2.TextAlignment = UITextAlignment.Left;
            text2.TextColor = UIColor.Black;
            text2.Frame = new CGRect(10, 90, 320, 40);
            text2.Font = UIFont.FromName("Helvetica", 14f);

            List<string> position2 = new List<string> { "None", "Trim", "Hide" };
            var picker2 = new IntersectActionPickerModel(position2);

            intersectActionMode.Model = picker2;
            intersectActionMode.SelectedRowInComponent(0);
            intersectActionMode.Frame = new CGRect(10, 140, 200, 40);
            picker2.ValueChanged += (sender, e) =>
            {
                if (picker2.SelectedValue == "None")
                    layer.DataLabelSettings.IntersectionAction = IntersectAction.None;
                else if (picker2.SelectedValue == "Trim")
                    layer.DataLabelSettings.IntersectionAction = IntersectAction.Trim;
                else if (picker2.SelectedValue == "Hide")
                    layer.DataLabelSettings.IntersectionAction = IntersectAction.Hide;
               
            };

            this.option.AddSubview(text1);
            this.option.AddSubview(smartLabelMode);
            this.option.AddSubview(text2);
            this.option.AddSubview(intersectActionMode);
        }

        void SetColorMapping(SFShapeSetting setting)
        {
            ObservableCollection<SFMapColorMapping> colorMappings = new ObservableCollection<SFMapColorMapping>();

            SFEqualColorMapping colorMapping1 = new SFEqualColorMapping();
            colorMapping1.Value = (NSString)"Rice";
            colorMapping1.Color = UIColor.FromRGB(181, 228, 133);
            colorMappings.Add(colorMapping1);

            SFEqualColorMapping colorMapping2 = new SFEqualColorMapping();
            colorMapping2.Value = (NSString)"Vegetables";
            colorMapping2.Color = UIColor.FromRGB(236, 155, 121);
            colorMappings.Add(colorMapping2);

            SFEqualColorMapping colorMapping3 = new SFEqualColorMapping();
            colorMapping3.Value = (NSString)"Wheat";
            colorMapping3.Color = UIColor.FromRGB(145, 120, 227);
            colorMappings.Add(colorMapping3);

            SFEqualColorMapping colorMapping4 = new SFEqualColorMapping();
            colorMapping4.Value = (NSString)"Grains";
            colorMapping4.Color = UIColor.FromRGB(228, 193, 108);
            colorMappings.Add(colorMapping4);

            SFEqualColorMapping colorMapping5 = new SFEqualColorMapping();
            colorMapping5.Value = (NSString)"Oats";
            colorMapping5.Color = UIColor.FromRGB(223, 129, 156);
            colorMappings.Add(colorMapping5);

            setting.ColorMappings = colorMappings;
        }

        NSMutableArray GetDataSource()
        {
            NSMutableArray array = new NSMutableArray();

            array.Add(getDictionary("Alabama", "Vegetables", 42));
            array.Add(getDictionary("Alabama", "Vegetables", 42));
            array.Add(getDictionary("Alaska", "Vegetables", 0));
            array.Add(getDictionary("Arizona", "Rice", 36));
            array.Add(getDictionary("Arkansas", "Vegetables", 46));
            array.Add(getDictionary("California", "Rice", 24));
            array.Add(getDictionary("Colorado", "Rice", 31));
            array.Add(getDictionary("Connecticut", "Grains", 18));
            array.Add(getDictionary("Delaware", "Grains", 28));
            array.Add(getDictionary("District of Columbia", "Grains", 27));
            array.Add(getDictionary("Florida", "Rice", 48));
            array.Add(getDictionary("Georgia", "Oats", 44));
            array.Add(getDictionary("Hawaii", "Grains", 49));
            array.Add(getDictionary("Idaho", "Grains", 8));
            array.Add(getDictionary("Illinois", "Vegetables", 26));
            array.Add(getDictionary("Indiana", "Grains", 21));
            array.Add(getDictionary("Iowa", "Vegetables", 13));
            array.Add(getDictionary("Kansas", "Rice", 33));
            array.Add(getDictionary("Kentucky", "Grains", 32));
            array.Add(getDictionary("Louisiana", "Oats", 47));
            array.Add(getDictionary("Maine", "Oats", 3));
            array.Add(getDictionary("Maryland", "Grains", 30));
            array.Add(getDictionary("Massachusetts", "Grains", 14));
            array.Add(getDictionary("Michigan", "Grains", 50));
            array.Add(getDictionary("Minnesota", "Wheat", 10));
            array.Add(getDictionary("Mississippi", "Vegetables", 43));
            array.Add(getDictionary("Missouri", "Oats", 35));
            array.Add(getDictionary("Montana", "Grains", 2));
            array.Add(getDictionary("Nebraska", "Rice", 15));
            array.Add(getDictionary("Nevada", "Wheat", 22));
            array.Add(getDictionary("New Hampshire", "Grains", 12));
            array.Add(getDictionary("New Jersey", "Vegetables", 20));
            array.Add(getDictionary("New Mexico", "Oats", 41));
            array.Add(getDictionary("New York", "Vegetables", 16));
            array.Add(getDictionary("North Carolina", "Rice", 38));
            array.Add(getDictionary("North Dakota", "Grains", 4));
            array.Add(getDictionary("Ohio", "Vegetables", 25));
            array.Add(getDictionary("Oklahoma", "Rice", 37));
            array.Add(getDictionary("Oregon", "Wheat", 11));
            array.Add(getDictionary("Pennsylvania", "Oats", 17));
            array.Add(getDictionary("Rhode Island", "Grains", 19));
            array.Add(getDictionary("South Carolina", "Rice", 45));
            array.Add(getDictionary("South Dakota", "Grains", 5));
            array.Add(getDictionary("Tennessee", "Vegetables", 39));
            array.Add(getDictionary("Texas", "Vegetables", 40));
            array.Add(getDictionary("Utah", "Rice", 23));
            array.Add(getDictionary("Vermont", "Grains", 9));
            array.Add(getDictionary("Virginia", "Rice", 34));
            array.Add(getDictionary("Washington", "Vegetables", 1));
            array.Add(getDictionary("West Virginia", "Grains", 29));
            array.Add(getDictionary("Wisconsin", "Oats", 7));
            array.Add(getDictionary("Wyoming", "Wheat", 6));
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

    public class SmartLabelPickerModel : UIPickerViewModel
    {
        List<string> position;
        public EventHandler ValueChanged;
        public string SelectedValue;

        public SmartLabelPickerModel(List<string> position)
        {
            this.position = position;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return position.Count;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return position[(int)row]; ;
        }

        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel label = new UILabel(new Rectangle(0, 0, 130, 40));
            label.TextColor = UIColor.Black;
            label.Font = UIFont.FromName("Helvetica", 14f);
            label.TextAlignment = UITextAlignment.Center;
            label.Text = position[(int)row];
            return label;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var position1 = position[(int)row];
            SelectedValue = position1;
            ValueChanged?.Invoke(null, null);
        }
    }

    public class IntersectActionPickerModel : UIPickerViewModel
    {
        List<string> position;
        public EventHandler ValueChanged;
        public string SelectedValue;

        public IntersectActionPickerModel(List<string> position)
        {
            this.position = position;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return position.Count;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return position[(int)row]; ;
        }

        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel label = new UILabel(new Rectangle(0, 0, 130, 40));
            label.TextColor = UIColor.Black;
            label.Font = UIFont.FromName("Helvetica", 14f);
            label.TextAlignment = UITextAlignment.Center;
            label.Text = position[(int)row];
            return label;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var position1 = position[(int)row];
            SelectedValue = position1;
            ValueChanged?.Invoke(null, null);
        }
    }

    public class MapsDataLabelsDelegate : SFMapsDelegate
    {
        public MapsDataLabelsDelegate(DataLabels dataLabels)
        {
            sample = dataLabels;
        }
        DataLabels sample;

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
