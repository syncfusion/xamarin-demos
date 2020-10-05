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
	public class BaseView : UIView
	{
		public BaseView(CGRect frame) : base(frame)
		{
			Frame = frame;
			DrawView();
		}

	
		UILabel label;
		UIImageView image;
      internal WeatherModel model;

		internal  WeatherView selectedView;

        UILabel label1;

		void DrawView()
		{
			label = new UILabel(new CGRect(0, Frame.Height - 130, Frame.Width, 40));
			label.TextColor = UIColor.White;
			label.Font = UIFont.SystemFontOfSize(40);
			label.TextAlignment = UITextAlignment.Center;
			image = new UIImageView();
			image.Frame = new CGRect((Frame.Width / 2) - 70, -25, 150, 100);
			AddSubview(label);
			AddSubview(image);
			label1 = new UILabel(new CGRect(0, Frame.Height - 70, Frame.Width, 30));


			label1.TextColor = UIColor.White;
			label1.Font = UIFont.SystemFontOfSize(14);
			label1.TextAlignment = UITextAlignment.Center;
			AddSubview(label1);

		}

		internal void updateBaseView()
		{
			UIFont arialFont = UIFont.SystemFontOfSize(45);
			NSDictionary arialDict = NSDictionary.FromObjectAndKey(arialFont, UIStringAttributeKey.Font);
			NSMutableAttributedString aAttrString = new NSMutableAttributedString(model.Temp, arialDict);

			NSMutableAttributedString aAttrString1 = new NSMutableAttributedString("°/", arialDict);

			aAttrString.Append(aAttrString1);
			UIFont VerdanaFont = UIFont.SystemFontOfSize(30);
			NSString tel = (NSString)"12";
			NSDictionary verdanaDict = NSDictionary.FromObjectAndKey(VerdanaFont, UIStringAttributeKey.Font);
			NSMutableAttributedString vAttrString = new NSMutableAttributedString(tel, verdanaDict);


			aAttrString.Append(vAttrString);




			label.AttributedText = aAttrString;

			image.Image = new UIImage(model.Type);

			label1.Text = model.Date;

			//selectedView.unSelectView();
		}




}
}

