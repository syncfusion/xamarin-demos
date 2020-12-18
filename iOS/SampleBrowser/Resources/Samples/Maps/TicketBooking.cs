#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using CoreGraphics;
using UIKit;
using Syncfusion.SfMaps.iOS;
using Syncfusion.SfBusyIndicator.iOS;
using Foundation;

namespace SampleBrowser
{
	public class TicketBooking : SampleView
	{
		UIView view;
		UILabel label;
		UIView container;
		UIView subcontainer;
		UIView LayoutA;
		UIView LayoutB;
		UIView LayoutC;
		UIView LayoutD;

		UIButton button1;
		UIButton button2;
		UIButton button3;
		public	UIButton button4;

		UILabel label1;
		UILabel label2;
		UILabel label3;
		UILabel label4;
		public UILabel label5;
		public  UITextView  text1;
		UIScrollView scrollView;

		public static	SFShapeFileLayer layer;
		public	SFMap maps;



		internal SFBusyIndicator busyindicator;


		public override void LayoutSubviews()
		{

			view.Frame = new CGRect(0, 0.0f, Frame.Size.Width, Frame.Size.Height);
		
			label.Frame = new CGRect(0f, 0f, Frame.Size.Width, 50);


			container.Frame = new CGRect(20f, 50f, (Frame.Size.Width / 2)-20, (Frame.Size.Height- (label.Frame.Size.Height+ 30) ));
			maps.Frame = new CGRect(20f, 20f, (Frame.Size.Width / 2), (Frame.Size.Height - ((label.Frame.Size.Height+70) )));
			subcontainer.Frame = new CGRect(Frame.Size.Width / 2, 50f, Frame.Size.Width / 2, Frame.Size.Height - 50f);
			LayoutA.Frame = new CGRect(0f, (Frame.Size.Height / 4) - 110f, subcontainer.Frame.Width-10f ,20);
			LayoutB.Frame = new CGRect(0f, (Frame.Size.Height / 4) - 80f, subcontainer.Frame.Width - 10f, 20);
			LayoutC.Frame = new CGRect(0f, (Frame.Size.Height / 4) - 50f,subcontainer.Frame.Width - 10f, 20);
			LayoutD.Frame=new CGRect(10f, (Frame.Size.Height/4)-15f, subcontainer.Frame.Width - 10f, 2);

			button1.Frame = new CGRect(LayoutA.Frame.Width/3, 0f, 20, 20);
			button2.Frame = new CGRect(LayoutA.Frame.Width / 3, 0f, 20, 20);
			button3.Frame = new CGRect(LayoutA.Frame.Width / 3, 0f, 20, 20);
			button4.Frame = new CGRect(20f, (Frame.Size.Height-120), (Frame.Size.Width / 2) - 30f, 30f);


			label1.Frame= new CGRect((LayoutA.Frame.Width / 3)+(button1.Frame.Width+5f), 0f,Frame.Size.Width-20f , 20f);
			label2.Frame = new CGRect((LayoutA.Frame.Width / 3) + (button1.Frame.Width + 5f), 0f, Frame.Size.Width - 20f, 20f);
			label3.Frame = new CGRect((LayoutA.Frame.Width / 3) + (button1.Frame.Width + 5f), 0f, Frame.Size.Width - 20f, 20f);
			label4.Frame = new CGRect(0f, (Frame.Size.Height/4),subcontainer.Frame.Width  , 20f);
			label5.Frame = new CGRect((subcontainer.Frame.Width/2)-5f, (Frame.Size.Height / 3) , subcontainer.Frame.Width - 10f , 20f);
			text1.Frame = new CGRect(20f, (Frame.Size.Height / 3) + 30f, subcontainer.Frame.Width - 50f, 100f);
			scrollView.Frame = new CGRect(20f, (Frame.Size.Height / 3)+30f,subcontainer.Frame.Width - 50f, 30f);
			SetNeedsDisplay();

		}


		public TicketBooking()
		{


			maps = new SFMap();
			view = new UIView();
			container = new UIView();
			subcontainer = new UIView();
			LayoutA = new UIView();
			LayoutB = new UIView();
			LayoutC = new UIView();
			LayoutD = new UIView();

			button1 = new UIButton();
			button2 = new UIButton();
			button3 = new UIButton();
			button4 = new UIButton();
			label1 = new UILabel();
			label2 = new UILabel();
			label3 = new UILabel();
			label4 = new UILabel();
			label5 = new UILabel();
			text1 = new UITextView();
			scrollView = new UIScrollView();


			view.BackgroundColor = UIColor.White;

			NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(0.3), delegate
			{
				container.AddSubview(maps);

			});



			view.Frame = new CGRect(0, 0, 300, 400);
			label = new UILabel();
			label.TextAlignment = UITextAlignment.Center;
			label.Text = "Ticketing System";
			label.Font = UIFont.SystemFontOfSize(18);
			label.Frame = new CGRect(0, 0, 300, 40);
			label.TextColor = UIColor.Black;
			view.AddSubview(label);

			//container.BackgroundColor = UIColor.Red;
			container.Layer.CornerRadius = 5;
			container.Layer.BorderWidth = 3;
			container.Layer.BorderColor = UIColor.Gray.CGColor;


			layer = new SFShapeFileLayer();
			layer.ShapeSettings.SelectedShapeColor = UIColor.FromRGB(98, 170, 95);
			layer.Uri = (NSString)NSBundle.MainBundle.PathForResource("Custom", "shp");
			layer.EnableSelection = true;
			layer.ShapeSettings.SelectedShapeStrokeThickness = 0;
			layer.DataSource = GetDataSource();

			SetColorMapping(layer.ShapeSettings);
			layer.GeometryType = SFGeometryType.SFGeometryTypePoints;
			layer.SelectionMode = SFSelectionMode.SFSelectionModeMultiple;
			layer.ShapeIDPath = (NSString)"SeatNumber";
			layer.ShapeSettings.ColorValuePath = (NSString)"SeatNumber";

			layer.ShapeSettings.valuePath = (NSString)"SeatNumber";
			layer.ShapeSettings.Fill = UIColor.Gray;
			layer.ShapeIDTableField = (NSString)"seatno";


			maps.Delegate = new MapsCustomDelegate(this, layer);
			maps.Layers.Add(layer);
			container.Add(maps);

			view.Add(container);




			subcontainer.BackgroundColor = UIColor.White;
			subcontainer.Layer.CornerRadius = 5;

			//LayoutA.BackgroundColor = UIColor.Green;
			LayoutA.Layer.CornerRadius = 5;
			button1.BackgroundColor = UIColor.Gray;
			button1.Layer.CornerRadius = 5;


			LayoutA.Add(button1);
			label1.Text = "Available";
			label1.Font = UIFont.SystemFontOfSize(12);
			label1.TextColor = UIColor.Black;

			LayoutA.Add(label1);
			subcontainer.Add(LayoutA);



			//LayoutB.BackgroundColor = UIColor.Purple;
			LayoutB.Layer.CornerRadius = 5;
			button2.BackgroundColor = UIColor.FromRGB(98, 170, 95);
			button2.Layer.CornerRadius = 5;
			LayoutB.Add(button2);
			label2.Text = "Selected";
			label2.TextColor = UIColor.Black;
			label2.Font = UIFont.SystemFontOfSize(12);
			LayoutB.Add(label2);
			subcontainer.Add(LayoutB);



			LayoutC.Layer.CornerRadius = 5;
			button3.BackgroundColor = UIColor.FromRGB(255, 165, 0);
			button3.Layer.CornerRadius = 5;
			LayoutC.Add(button3);
			label3.Text = "Booked";
			label3.TextColor = UIColor.Black;
			label3.Font = UIFont.SystemFontOfSize(12);
			LayoutC.Add(label3);
			subcontainer.Add(LayoutC);


			LayoutD.BackgroundColor = UIColor.Gray;
			LayoutD.Layer.CornerRadius = 5;
			subcontainer.Add(LayoutD);

			label4.Text = "Seats Selected";
			label4.TextAlignment = UITextAlignment.Center;
			label4.TextColor = UIColor.Blue;
			label4.Font = UIFont.SystemFontOfSize(12);
			subcontainer.Add(label4);

			label5.Text = "";
			label5.TextAlignment = UITextAlignment.Left;
			label5.TextColor = UIColor.Black;
			label5.Font = UIFont.SystemFontOfSize(20);
			subcontainer.Add(label5);



			text1.Text = "";
			//text1.BackgroundColor = UIColor.Blue;
			text1.TextAlignment = UITextAlignment.Center;
			text1.TextColor = UIColor.Black;
			text1.Font = UIFont.SystemFontOfSize(12);

			subcontainer.Add(text1);



			button4.BackgroundColor = UIColor.Clear;
			button4.Enabled = false;
			button4.Alpha = (float)0.5;
			button4.Layer.CornerRadius = 5;
			button4.Layer.BorderColor = UIColor.Gray.CGColor;
			button4.Layer.BorderWidth = 2;
			button4.SetTitle("Clear Selection", UIControlState.Normal);
			button4.SetTitleColor(UIColor.Red, UIControlState.Normal);
			button4.TouchDown += (sender, e) => {

				layer.SelectedItems = new NSMutableArray();
				button4.Enabled = false;
				button4.Alpha = (float)0.5;
				label5.Text=" " ;
				text1.Text = " ";


				};
		     subcontainer.Add(button4);


			view.Add(subcontainer);



			AddSubview(view);


		}

		public	void selection(string selectedItems)
		{
			
			text1.Text = selectedItems;

		
		}


		NSMutableArray GetDataSource()
		{
			NSMutableArray array = new NSMutableArray();
			for (int i = 1; i <= 21; i++)
			{
				array.Add(getDictionary("" + i));

			}
			return array;
		}


		NSDictionary getDictionary(string seatno)
		{
			NSString name1 = (NSString)seatno;
			object[] objects = new object[1];
			object[] keys = new object[1];
			keys.SetValue("SeatNumber", 0);
			objects.SetValue(name1, 0);


			return NSDictionary.FromObjectsAndKeys(objects, keys);
		}

		void SetColorMapping(SFShapeSetting setting)
		{
			NSMutableArray colorMappings = new NSMutableArray();
			SFEqualColorMapping colorMapping1 = new SFEqualColorMapping();
			colorMapping1.Value = (NSString)"1";
			colorMapping1.Color = UIColor.FromRGB(255, 165, 0); 
			colorMappings.Add(colorMapping1);

			SFEqualColorMapping colorMapping2 = new SFEqualColorMapping();
			colorMapping2.Value = (NSString)"2";
			colorMapping2.Color = UIColor.FromRGB(255, 165, 0);
			colorMappings.Add(colorMapping2);

			SFEqualColorMapping colorMapping3 = new SFEqualColorMapping();
			colorMapping3.Value = (NSString)"8";
			colorMapping3.Color = UIColor.FromRGB(255, 165, 0); 
			colorMappings.Add(colorMapping3);

			SFEqualColorMapping colorMapping4 = new SFEqualColorMapping();
			colorMapping4.Value = (NSString)"9";
			colorMapping4.Color = UIColor.FromRGB(255, 165, 0); 
			colorMappings.Add(colorMapping4);

			setting.ColorMappings = colorMappings;
		}


	}







	class MapsCustomDelegate : SFMapsDelegate
	{


		public MapsCustomDelegate(TicketBooking sample,SFShapeFileLayer layer)
		{
			mapping = sample;
			mappingLayer = layer;

		}
		TicketBooking mapping;
		SFShapeFileLayer mappingLayer;
		public override void DidSelectShape(SFMap map, NSObject data)
		{			

			mapping.label5.Text =mappingLayer.SelectedItems.Count.ToString();
			var selected = mappingLayer.SelectedItems;
			string text = "";
			if (mappingLayer.SelectedItems.Count == 0)
			{
				mapping.button4.Enabled = false;
				mapping.button4.Alpha = (float)0.5;

			}
			for (nuint i = 0; i < mappingLayer.SelectedItems.Count; i++)
			{

				NSObject item = (NSObject)mappingLayer.SelectedItems.GetItem<NSObject>(i);
				NSDictionary dic1 = (NSDictionary)item;

				if ((NSString)(dic1["SeatNumber"]) == "1" || (NSString)(dic1["SeatNumber"]) == "2" || (NSString)(dic1["SeatNumber"]) == "8" || (NSString)(dic1["SeatNumber"]) == "9")
				{


					selected.RemoveObject(nint.Parse(i.ToString()));
					mappingLayer.SelectedItems = selected;
					mapping.label5.Text = mappingLayer.SelectedItems.Count.ToString();
					if (selected.Count == 0)
					{
						mapping.button4.Enabled = false;
						mapping.button4.Alpha = (float)0.5;
					}
					else
					{
						if (text.EndsWith(","))
						{
							text=text.Remove(text.Length - 1);
						}
					}

				}
				else {
					if (i == mappingLayer.SelectedItems.Count - 1)
					{
						
						text += "S" + ((NSString)(dic1["SeatNumber"]));
					}
					else
					{
						
						text += "S" + ((NSString)(dic1["SeatNumber"]) + ",");
					}
					mapping.button4.Enabled = true;
					mapping.button4.Alpha = (float)1;

				}

			}

			mapping.selection(text);



		}
	}
}
