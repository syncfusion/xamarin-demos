
using Syncfusion.SfCarousel.iOS;

using System;
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
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif
namespace SampleBrowser
{
    /// <summary>
    /// Load more.
    /// </summary>
    public class LoadMoreCarousel : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.LoadMore"/> class.
        /// </summary>
        public LoadMoreCarousel()
        {
            LoadMoreSample phoneView = new LoadMoreSample();
            this.AddSubview(phoneView);
        }

        /// <summary>
        /// Layouts the subviews.
        /// </summary>
        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }
        }
    }
}