#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfGauge.iOS;
using System.Collections.ObjectModel;
using System.Collections.Generic;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using nfloat = System.Single;
using System.Drawing;
#endif
namespace SampleBrowser
{
    public class DirectionCompass : SampleView
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        SFCircularGauge gauge;
        UIPickerView opposed;
        UIView option = new UIView();
        SFNeedlePointer pointer2;

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }
            if (Utility.IsIpad)
            {
                gauge.Frame = new CGRect(50, 50, (float)this.Frame.Width - 100, (float)this.Frame.Height - 100);
            }
            else
            {
                gauge.Frame = new CGRect(10, 10, (float)this.Frame.Width - 20, (float)this.Frame.Height - 20);
            }
            base.LayoutSubviews();
        }
        public DirectionCompass()
        {
            this.BackgroundColor = UIColor.White;
            gauge = new SFCircularGauge();
            gauge.BackgroundColor = UIColor.White;
            opposed = new UIPickerView();

            SFCircularScale scale = new SFCircularScale();
            scale.StartValue = 0;
            scale.EndValue = 16;
            scale.Interval = 2;
            scale.LabelOffset = 0.75f;
            scale.StartAngle = 0;
            scale.SweepAngle = 360;
            scale.MinorTicksPerInterval = 1;
            scale.ShowLastLabel = false;
            scale.ScaleStartOffset = 0.99f;
            scale.ScaleEndOffSet = 0.9f;
            scale.MajorTickSettings.Offset = 0.9f;
            scale.MinorTickSettings.Offset = 0.9f;
            scale.MinorTickSettings.EndOffset = 0.4f;
            scale.RimColor = UIColor.FromRGB(224, 224, 224);
            scale.LabelColor = UIColor.FromRGB(75, 75, 75);


            SFNeedlePointer pointer1 = new SFNeedlePointer();
            pointer1.Value = 14;
            pointer1.Color = UIColor.LightGray;
            pointer1.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle;
            pointer1.LengthFactor = 0.65f;
            pointer1.Width = 20;
            pointer1.KnobRadiusFactor = 0;
            pointer1.KnobRadius = 0;
            pointer1.KnobColor = UIColor.White;
            pointer1.KnobStrokeColor = UIColor.White;
            pointer1.KnobStrokeWidth = 3;
            pointer1.EnableAnimation = false;
            scale.Pointers.Add(pointer1);

            pointer2 = new SFNeedlePointer();
            pointer2.Value = 6;
            pointer2.Color = UIColor.Red;
            pointer2.Width = 20;
            pointer2.KnobRadius = 20;
            pointer2.KnobColor = UIColor.White;
            pointer2.KnobStrokeColor = UIColor.White;
            pointer2.KnobStrokeWidth = 3;
            pointer2.LengthFactor = 0.65f;
            pointer2.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle;
            pointer2.EnableAnimation = false;
            scale.Pointers.Add(pointer2);

            gauge.Scales.Add(scale);

            gauge.Delegate = new CutomDelegate();
            this.AddSubview(gauge);
            CreateOptionView();
            this.OptionView = option;
        }

        private void CreateOptionView()
        {

            UILabel text1 = new UILabel();
            text1.Text = "Pointer Color";
            text1.TextAlignment = UITextAlignment.Left;
            text1.TextColor = UIColor.Black;
            text1.Frame = new CGRect(10, 10, 320, 40);
            text1.Font = UIFont.FromName("Helvetica", 14f);

            List<string> position = new List<string> { "Red", "Blue", "Orange" };
            var picker = new DirectionPickerModel(position);

            opposed.Model = picker;
            opposed.SelectedRowInComponent(0);

            opposed.Frame = new CGRect(10, 25, 200, 70);
            picker.ValueChanged += (sender, e) =>
            {
                if (picker.SelectedValue == "Red")
                    pointer2.Color = UIColor.Red;
                else if (picker.SelectedValue == "Blue")
                    pointer2.Color = UIColor.Blue;
                else if (picker.SelectedValue == "Orange")
                    pointer2.Color = UIColor.Orange;
            };


            this.option.AddSubview(text1);
            this.option.AddSubview(opposed);

        }

        protected override void Dispose(bool disposing)
        {
            //		gauge.Delegate = null;
            //gauge.Scales[0].Pointers.Clear();
            //gauge.Scales.Clear();
            //gauge.Dispose();

            base.Dispose(disposing);
        }

    }

    public class DirectionPickerModel : UIPickerViewModel
    {
        List<string> position;
        public EventHandler ValueChanged;
        public string SelectedValue;

        public DirectionPickerModel(List<string> position)
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


    public class CutomDelegate : SFCircularPointerDelegate
    {
        public override object OnLabelCreated(object labelContent, int scaleIndex)
        {
            switch ((NSString)labelContent)
            {
                case "0":
                    labelContent = "S";
                    break;
                case "2":
                    labelContent = "SW";
                    break;
                case "4":
                    labelContent = "W";
                    break;
                case "6":
                    labelContent = "NW";
                    break;
                case "8":
                    labelContent = "N";
                    break;
                case "10":
                    labelContent = "NE";
                    break;
                case "12":
                    labelContent = "E";
                    break;
                case "14":
                    labelContent = "SE";
                    break;
            }

            return base.OnLabelCreated(labelContent, scaleIndex);
        }
    }
}
