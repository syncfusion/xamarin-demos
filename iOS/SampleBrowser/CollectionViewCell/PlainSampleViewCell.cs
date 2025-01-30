using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class PlainSampleViewCell : UICollectionViewCell
    {
        #region fields

        private UILabel label;

        private UIImageView imageView;

        #endregion

        #region ctor

        public PlainSampleViewCell()
		{
		}

        [Export("initWithFrame:")]
        public PlainSampleViewCell(CGRect frame) : base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };

            label = new UILabel
            {
                Center = ContentView.Center,
                TextColor = UIColor.Red,
                Frame = this.Frame
            };

            imageView = new UIImageView(UIImage.FromBundle("menu.png"))
            {
                Transform = CGAffineTransform.MakeScale(0.7f, 0.7f),
                Frame = this.Frame
            };

            ContentView.AddSubview(label);
        }

        protected PlainSampleViewCell(IntPtr handle) : base(handle)
		{
		}

        #endregion

        #region properties

        public UIImage Image
        {
            set { imageView.Image = value; }
        }

        public NSString Text
        {
            set { label.Text = value; }
        }

        #endregion
    }
}
