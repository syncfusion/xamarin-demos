#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
 using System; using System.Collections.Generic; using System.Drawing;

#if __UNIFIED__ using Foundation; using UIKit; using CoreGraphics;  #else using MonoTouch.Foundation; using MonoTouch.UIKit; using MonoTouch.CoreGraphics; using nint = System.Int32; using nuint = System.Int32; using CGSize = System.Drawing.SizeF; using CGRect = System.Drawing.RectangleF; using nfloat  = System.Single; #endif using Syncfusion.SfGauge.iOS; namespace SampleBrowser {     public class ScaleandPointers:SampleView     {         SFLinearGauge linearGauge; 		SFLinearScale scale; 		UIPickerView opposed; 		UIPickerView rangeCap; 		UIPickerView markerShape; 		UIView option = new UIView(); 		SFSymbolPointer pointer; 		SFBarPointer pointer1;          static bool UserInterfaceIdiomIsPhone         {             get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }         }          #region View lifecycle         public override void LayoutSubviews()         {                 foreach (var view in this.Subviews)                 {                     view.Frame = Bounds;                     linearGauge.Frame = new CGRect(0, -20, this.Frame.Size.Width, this.Frame.Size.Height + 20);                 }                         base.LayoutSubviews();         }         public ScaleandPointers()         {             opposed = new UIPickerView(); 			rangeCap = new UIPickerView(); 			markerShape = new UIPickerView();              //LinearGauge             this.BackgroundColor = UIColor.White;              linearGauge = new SFLinearGauge();             linearGauge.BackgroundColor = UIColor.White;             linearGauge.Header = new SFLinearLabel();   			scale  = new SFLinearScale();             scale.Minimum = 0;             scale.Maximum = 100;             scale.Interval = 10;             scale.CornerRadius = 20;             scale.CornerRadiusType = CornerRadiusType.End;             scale.ScaleBarSize = 40;             scale.LabelColor = UIColor.FromRGB(66, 66, 66);             scale.LabelFont = UIFont.FromName("Helvetica", 14f);             scale.MinorTicksPerInterval = 1; 			scale.MinorTickSettings.Length = 8;             scale.ScaleBarColor = UIColor.FromRGB(224,233,249);              SFLinearTickSettings major = new SFLinearTickSettings();             major.Thickness = 1f;             major.Length = 10;             major.Color = UIColor.FromRGB(158, 158, 158);             scale.MajorTickSettings = major;               pointer = new SFSymbolPointer();             pointer.SymbolPosition = SymbolPointerPosition.Away;             pointer.Thickness = 12;             pointer.Value = 30;             pointer.Color = UIColor.FromRGB(91, 134, 229); 			pointer.MarkerShape = MarkerShape.Triangle;             scale.Pointers.Add(pointer);              pointer1 = new SFBarPointer();             pointer1.Value = 75;             pointer1.CornerRadiusValue = 15;             pointer1.CornerRadiusType = CornerRadiusType.End; 			pointer1.Thickness = 30;              GaugeGradientStop color1 = new GaugeGradientStop();             color1.Value = 0;             color1.Color = UIColor.FromRGB(54, 209, 220);             pointer1.GradientStops.Add(color1);              GaugeGradientStop color2 = new GaugeGradientStop();             color2.Value = 75;             color2.Color = UIColor.FromRGB(91, 134, 229);             pointer1.GradientStops.Add(color2);              scale.Pointers.Add(pointer1);              linearGauge.Scales.Add(scale);              this.AddSubview(linearGauge); 			CreateOptionView(); 			this.OptionView = option;         }  		private void CreateOptionView() 		{  			UILabel text1 = new UILabel(); 			text1.Text = "Opposite position"; 			text1.TextAlignment = UITextAlignment.Left; 			text1.TextColor = UIColor.Black; 			text1.Frame = new CGRect(10, 10, 320, 40); 			text1.Font = UIFont.FromName("Helvetica", 14f);  			List<string> position = new List<string> { "True", "False" }; 			var picker = new OpposedPickerModel(position);  			opposed.Model = picker; 			opposed.SelectedRowInComponent(0);
			opposed.Frame = new CGRect(10, 50, 200, 40); 			picker.ValueChanged += (sender, e) =>
			 {
				 if (picker.SelectedValue == "True")
					 scale.OpposedPosition = true;
				 else if (picker.SelectedValue == "False")
					 scale.OpposedPosition = false;
			 };

			UILabel text2 = new UILabel();
			text2.Text = "Range Cap"; 			text2.TextAlignment = UITextAlignment.Left; 			text2.TextColor = UIColor.Black; 			text2.Frame = new CGRect(10, 90, 320, 40);
			text2.Font = UIFont.FromName("Helvetica", 14f);


			List<string> position1 = new List<string> { "Start", "End", "Both", "None" };
			var picker1 = new RangePickerModel(position1);

			rangeCap.Model = picker1;
			rangeCap.Frame = new CGRect(10, 140, 200, 40);
			picker1.ValueChanged += (sender, e) =>
			{
				if (picker1.SelectedValue == "Start") 				{
					pointer1.CornerRadiusType = CornerRadiusType.Start;
					scale.CornerRadiusType = CornerRadiusType.Start; 				}
				else if (picker1.SelectedValue == "End") 				{ 					pointer1.CornerRadiusType = CornerRadiusType.End;
					scale.CornerRadiusType = CornerRadiusType.End; 				}
				else if (picker1.SelectedValue == "Both") 				{ 					pointer1.CornerRadiusType = CornerRadiusType.Both;
					scale.CornerRadiusType = CornerRadiusType.Both; 				}
				else if (picker1.SelectedValue == "None") 				{ 					pointer1.CornerRadiusType = CornerRadiusType.None;
					scale.CornerRadiusType = CornerRadiusType.None; 				}
			};

			UILabel text3 = new UILabel();
			text3.Text = "Marker Shape"; 			text3.TextAlignment = UITextAlignment.Left; 			text3.TextColor = UIColor.Black; 			text3.Frame = new CGRect(10, 180, 320, 40);
			text3.Font = UIFont.FromName("Helvetica", 14f);

			List<string> position2 = new List<string> { "Triangle", "Inverted Triangle", "Circle", "Diamond", "Rectangle", "Image" };
			var picker2 = new MarkerPickerModel(position2);

			markerShape.Model = picker2; 			markerShape.SelectedRowInComponent(0); 			markerShape.Frame = new CGRect(10, 220, 250, 40);
			picker2.ValueChanged += (sender, e) =>
						 {
							 if (picker2.SelectedValue == "Triangle")
								 pointer.MarkerShape = MarkerShape.Triangle;
							 else if (picker2.SelectedValue == "Inverted Triangle")
								 pointer.MarkerShape = MarkerShape.InvertedTriangle;
							 else if (picker2.SelectedValue == "Circle")
								 pointer.MarkerShape = MarkerShape.Circle;
							 else if (picker2.SelectedValue == "Diamond") 								 pointer.MarkerShape = MarkerShape.Diamond;
							 else if (picker2.SelectedValue == "Rectangle") 								 pointer.MarkerShape = MarkerShape.Rectangle;
							 else if (picker2.SelectedValue == "Image")
							 { 								 pointer.MarkerShape = MarkerShape.Image;
								 pointer.ImageSource = "location.png";
							 }
						 };  			this.option.AddSubview(text1); 			this.option.AddSubview(opposed);
			this.option.AddSubview(text2);
			this.option.AddSubview(rangeCap);
			this.option.AddSubview(text3);
			this.option.AddSubview(markerShape);
		}          #endregion     }  	public class OpposedPickerModel : UIPickerViewModel 	{ 		List<string> position; 		public EventHandler ValueChanged; 		public string SelectedValue;  		public OpposedPickerModel(List<string> position) 		{ 			this.position = position; 		}  		public override nint GetRowsInComponent(UIPickerView pickerView, nint component) 		{ 			return position.Count; 		}  		public override nint GetComponentCount(UIPickerView pickerView) 		{ 			return 1; 		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return position[(int)row]; ; 		}

        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel label = new UILabel(new Rectangle(0, 0, 130, 40));
            label.TextColor = UIColor.Black;
            label.Font = UIFont.FromName("Helvetica", 14f);
            label.TextAlignment = UITextAlignment.Center;
            label.Text = position[(int)row];
            return label;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component) 		{ 			var position1 = position[(int)row]; 			SelectedValue = position1; 			ValueChanged?.Invoke(null, null); 		} 	}

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
		} 	}

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
	} } 