#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Foundation;
using UIKit;
using CoreGraphics;

namespace SampleBrowser
{
	public class AllControlsViewCell : UITableViewCell
    {
        #region fields

        public static NSString Key { get; set; } = new NSString("AllControlsViewCell");

        #endregion

        #region ctor

        public AllControlsViewCell() : base(UITableViewCellStyle.Value1, Key)
		{
		}

        #endregion

        #region methods

        public override void LayoutSubviews()
		{
            base.LayoutSubviews();

            this.DetailTextLabel.Frame = new CGRect(
                this.DetailTextLabel.Frame.X - 20,
                this.DetailTextLabel.Frame.Y - 5,
                this.DetailTextLabel.Frame.Width + 20,
                this.DetailTextLabel.Frame.Height + 10);
			
			this.DetailTextLabel.TextColor = UIColor.White;

			if (this.DetailTextLabel.Text == "NEW")
            {
                this.DetailTextLabel.BackgroundColor = UIColor.FromRGB(30, 199, 192);
			}
			else if (this.DetailTextLabel.Text == "UPDATED")
            {
                this.DetailTextLabel.BackgroundColor = UIColor.FromRGB(51, 61, 71);
			}
			else if (this.DetailTextLabel.Text == "PREVIEW")
            {
                this.DetailTextLabel.BackgroundColor = UIColor.FromRGB(255, 180, 0);
			}

			this.DetailTextLabel.Layer.CornerRadius = 10;
            this.DetailTextLabel.ClipsToBounds = true;
            this.DetailTextLabel.TextAlignment = UITextAlignment.Center;
		}

        #endregion
    }
}