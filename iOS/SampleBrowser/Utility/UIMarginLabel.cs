using System.Drawing;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
	internal class UIMarginLabel : UILabel
	{
        #region ctor

        public UIMarginLabel()
		{
		}

        #endregion

        #region properties

        public UIEdgeInsets Insets { get; set; }

        #endregion

        #region methods

        public override void DrawText(CGRect rect)
		{
			base.DrawText(Insets.InsetRect(rect));
		}

        #endregion
    }
}