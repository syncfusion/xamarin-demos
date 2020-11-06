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
    public class GaugeCustomization : SampleView
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }



        SFCircularGauge gauge1;
        SFCircularGauge gauge2;
        UISlider slider;
        UIView option = new UIView();
        SFRangePointer pointer1;
        SFNeedlePointer pointer2;
        SFRangePointer pointer3;
        UIPickerView rangePointerColor;
        UIPickerView needlePointerColor;
        UIPickerView rangeColor;
        SFCircularRange range;
        SFCircularRange range1;

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
                gauge1.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height / 2);
                gauge2.Frame = new CGRect(0, this.Frame.Height / 2 , this.Frame.Width, this.Frame.Height / 2);
            }             
            
            base.LayoutSubviews();
        }
        public GaugeCustomization()
        {
            gauge1 = new SFCircularGauge();
            rangePointerColor = new UIPickerView();
            needlePointerColor = new UIPickerView();
            rangeColor = new UIPickerView();
            SFGaugeHeader header1 = new SFGaugeHeader();
            header1.Position = new CGPoint(0.5, 0.06);
            header1.Text = (Foundation.NSString)"800 GB";
            header1.TextColor = UIColor.Black;
            header1.TextStyle = UIFont.SystemFontOfSize(20);
            gauge1.Headers.Add(header1);

            SFCircularScale scale1 = new SFCircularScale();
            scale1.StartAngle = 110;
            scale1.SweepAngle = 250;
            scale1.StartValue = 0;
            scale1.EndValue = 1000;
            scale1.Interval = 500;
            scale1.ShowLabels = false;
            scale1.ShowTicks = false;
            scale1.ShowRim = false;
            scale1.MinorTicksPerInterval = 0;

            pointer1 = new SFRangePointer();
            pointer1.Value = 800;
            pointer1.KnobRadius = 0;
			pointer1.EnableAnimation = false;
            pointer1.Color = UIColor.FromRGB(255, 221, 0);
            pointer1.KnobColor = UIColor.FromRGB(255, 221, 0);
            pointer1.Width = 20;
            pointer1.Offset = 0.7f;
            scale1.Pointers.Add(pointer1);

            pointer2 = new SFNeedlePointer();
            pointer2.Value = 800;
            pointer2.Color = UIColor.FromRGB(66, 66, 66);
            pointer2.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle;
            pointer2.LengthFactor = 0.7f;
            pointer2.Width = 5f;
            pointer2.KnobRadiusFactor = 0.1f;
            pointer2.KnobColor = UIColor.FromRGB(66, 66, 66);
            scale1.Pointers.Add(pointer2);

            range = new SFCircularRange();
            range.StartValue = 0;
            range.EndValue = 1000;
            range.Offset = 0.7f;
            range.Width = 20;
            range.Color = UIColor.FromRGB(224, 224, 224);
            scale1.Ranges.Add(range);
            gauge1.Scales.Add(scale1);

            gauge2 = new SFCircularGauge();
            SFGaugeHeader header2 = new SFGaugeHeader();
            header2.Position = new CGPoint(0.5, 0.5);
            header2.Text = (Foundation.NSString)"800 GB";
            header2.TextColor = UIColor.Black;
            header2.TextStyle = UIFont.SystemFontOfSize(20);
            SFGaugeHeader header3 = new SFGaugeHeader();
            header3.Position = new CGPoint(0.5, 0.6);
            header3.Text = (Foundation.NSString)"Used";
            header3.TextColor = UIColor.Gray;
            header3.TextStyle = UIFont.SystemFontOfSize(18);
            gauge2.Headers.Add(header2);
            gauge2.Headers.Add(header3);

            SFCircularScale scale2 = new SFCircularScale();
            scale2.StartAngle = -180;
            scale2.SweepAngle = 180;
            scale2.StartValue = 0;
            scale2.EndValue = 1000;
            scale2.Interval = 500;
            scale2.ShowLabels = false;
            scale2.ShowTicks = false;
            scale2.ShowRim = false;
            scale2.MinorTicksPerInterval = 0;

            pointer3 = new SFRangePointer();
            pointer3.Value = 800;
		    pointer3.EnableAnimation = false;
            pointer3.Color = UIColor.FromRGB(255, 221, 0);
            pointer3.Width = 20;
            pointer3.Offset = 0.8f;
            scale2.Pointers.Add(pointer3);

            range1 = new SFCircularRange();
            range1.StartValue = 0;
            range1.EndValue = 1000;
            range1.Offset = 0.8f;
            range1.Width = 20;
            range1.Color = UIColor.FromRGB(224, 224, 224);
            scale2.Ranges.Add(range1);
            gauge2.Scales.Add(scale2);
            this.AddSubview(gauge1);
            this.AddSubview(gauge2);
            CreateOptionView();
            this.OptionView = option;
        }

        private void CreateOptionView()
        {
            UILabel text = new UILabel();
            text.Text = "Change Pointer Value";
            text.TextAlignment = UITextAlignment.Left;
            text.TextColor = UIColor.Black;
            text.Frame = new CGRect(10, 10, 320, 20);
            text.Font = UIFont.FromName("Helvetica", 14f);

            slider = new UISlider();
            slider.Frame = new CGRect(5, 40, 320, 20);
            slider.MinValue = 0f;
            slider.MaxValue = 1000f;
            slider.Value = 60f;
            slider.ValueChanged += (object sender, EventArgs e) =>
            {
                pointer1.Value = slider.Value;
                pointer2.Value = slider.Value;
                pointer3.Value = slider.Value;
            };

            UILabel text1 = new UILabel();
            text1.Text = "RangePointer Color";
            text1.TextAlignment = UITextAlignment.Left;
            text1.TextColor = UIColor.Black;
            text1.Frame = new CGRect(10, 70, 320, 20);
            text1.Font = UIFont.FromName("Helvetica", 14f);

            List<string> position = new List<string> { "Yellow", "Green", "Purple" };
            var picker = new OpposedPickerModel(position);

            rangePointerColor.Model = picker;
            rangePointerColor.SelectedRowInComponent(0);
            rangePointerColor.Frame = new CGRect(10, 100, 200, 40);
            picker.ValueChanged += (sender, e) =>
            {
                if (picker.SelectedValue == "Yellow")
                {
                    pointer1.Color = UIColor.Yellow;
                    pointer3.Color = UIColor.Yellow;
                }
                else if (picker.SelectedValue == "Green")
                {
                    pointer1.Color = UIColor.Green;
                    pointer3.Color = UIColor.Green;
                }
                else if (picker.SelectedValue == "Purple")
                {
                    pointer1.Color = UIColor.Purple;
                    pointer3.Color = UIColor.Purple;
                }
            };

            UILabel text2 = new UILabel();
            text2.Text = "NeedlePointer Color";
            text2.TextAlignment = UITextAlignment.Left;
            text2.TextColor = UIColor.Black;
            text2.Frame = new CGRect(10, 150, 320, 20);
            text2.Font = UIFont.FromName("Helvetica", 14f);


            List<string> position1 = new List<string> { "Gray", "Red", "Brown" };
            var picker1 = new RangePickerModel(position1);

            needlePointerColor.Model = picker1;
            needlePointerColor.Frame = new CGRect(10, 170, 200, 40);
            picker1.ValueChanged += (sender, e) =>
            {
                if (picker1.SelectedValue == "Gray")
                {
                    pointer2.Color = UIColor.Gray;

                }
                else if (picker1.SelectedValue == "Red")
                {
                    pointer2.Color = UIColor.Red;
                }
                else if (picker1.SelectedValue == "Brown")
                {
                    pointer2.Color = UIColor.Brown;
                }

            };

            UILabel text3 = new UILabel();
            text3.Text = "Range Color";
            text3.TextAlignment = UITextAlignment.Left;
            text3.TextColor = UIColor.Black;
            text3.Frame = new CGRect(10, 220, 320, 20);
            text3.Font = UIFont.FromName("Helvetica", 14f);

            List<string> position2 = new List<string> { "Light Gray", "Blue", "Orange" };
            var picker2 = new MarkerPickerModel(position2);

            rangeColor.Model = picker2;
            rangeColor.SelectedRowInComponent(0);
            rangeColor.Frame = new CGRect(10, 250, 250, 40);
            picker2.ValueChanged += (sender, e) =>
            {
                if (picker2.SelectedValue == "Light Gray")
                {
                    range.Color = UIColor.LightGray;
                    range1.Color = UIColor.LightGray;
                }
                else if (picker2.SelectedValue == "Blue")
                {
                    range.Color = UIColor.Blue;
                    range1.Color = UIColor.Blue;
                }
                else if (picker2.SelectedValue == "Orange")
                {
                    range.Color = UIColor.Orange;
                    range1.Color = UIColor.Orange;
                }

            };

            this.option.AddSubview(text);

            this.option.AddSubview(slider);
            this.option.AddSubview(text1);

            this.option.AddSubview(rangePointerColor);
            this.option.AddSubview(text2);

            this.option.AddSubview(needlePointerColor);
            this.option.AddSubview(text3);

            this.option.AddSubview(rangeColor);
        }

        public class OpposedPickerModel : UIPickerViewModel
        {
            List<string> position;
            public EventHandler ValueChanged;
            public string SelectedValue;

            public OpposedPickerModel(List<string> position)
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

        public class RangePickerModel : UIPickerViewModel
        {
            List<string> position;
            public EventHandler ValueChanged;
            public string SelectedValue;

            public RangePickerModel(List<string> position)
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

        public class MarkerPickerModel : UIPickerViewModel
        {
            List<string> position;
            public EventHandler ValueChanged;
            public string SelectedValue;

            public MarkerPickerModel(List<string> position)
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

        protected override void Dispose(bool disposing)
        {
            //gauge1.Scales[0].Pointers.Clear();
            //gauge1.Scales.Clear();
            //gauge1.Dispose();
            //gauge2.Scales[0].Pointers.Clear();
            //gauge2.Scales.Clear();
            //gauge2.Dispose();
            base.Dispose(disposing);
        }
    }
}
