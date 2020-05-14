#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class WeatherView : UIView
	{
		internal WeatherModel model;
		UILabel label;
		UIImageView image;
		UILabel label1;
		internal    BaseView baseView;
		public WeatherView(CGRect frame) : base(frame)
		{
			UITapGestureRecognizer gesture = new UITapGestureRecognizer();
			// Wire up the event handler (have to use a selector)
			gesture.AddTarget(() => imageViewTapped(gesture));


			AddGestureRecognizer(gesture);
		}
		internal void selectView()
{
			label.TextColor = label1.TextColor = UIColor.FromRGBA(0.984f,0.69f,0.231f,1);
    
			image.Image = new UIImage(model.Type.ToString().Replace(".","-selected."));
}

		internal void unSelectView()
{
			label.TextColor = label1.TextColor = UIColor.White;
       image.Image = new UIImage(model.Type);
    
}

		internal void updateTemp()
		{

				label1.Text = (NSString)model.Temp.ToString() + "°";
			}


		void imageViewTapped(UITapGestureRecognizer gr)
		{
			baseView.model = model;
			baseView.updateBaseView();

			selectView();
			if (baseView.selectedView != null)
			{
				baseView.selectedView.unSelectView();
			}
			baseView.selectedView = this;
		}
   


	internal	void drawView()
		{
			label = new UILabel(new CGRect(0, -15, Frame.Width, 30));
			label.TextColor = UIColor.White;
			label.Font = UIFont.SystemFontOfSize(12);
			label.TextAlignment = UITextAlignment.Center;
			label.Text = model.Day;




			image = new UIImageView();
			image.Image = new UIImage(model.Type);
			image.Frame = new CGRect(12, 25, 75, 50);
			AddSubview(label);
			AddSubview(image);
			label1 = new UILabel(new CGRect(0, 80, Frame.Width, 30));


			label1.TextColor = UIColor.White;
			label1.Font = UIFont.SystemFontOfSize(12);
			label1.TextAlignment = UITextAlignment.Center;
			label1.Text = (NSString)model.Temp.ToString() + "°";
			AddSubview(label1);
		}
    



}
}

