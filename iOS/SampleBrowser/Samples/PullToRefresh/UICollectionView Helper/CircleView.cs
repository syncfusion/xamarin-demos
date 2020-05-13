#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using CoreAnimation;
using CoreText;

namespace SampleBrowser
{
    public class CircleView : UIView
    {
        private const double radians = Math.PI / 180;
        public UIColor ViewColor { get; set; }

        public string text { get; set; }

        public CircleView() : base()
        {
            this.BackgroundColor = UIColor.Clear;
            this.text = null;
        }

        public CircleView(CGRect frame) : base(frame)
        {
            this.Frame = frame;
            this.BackgroundColor = UIColor.Clear;
            this.text = null;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            using (CGContext context = UIGraphics.GetCurrentContext())
            {
                var radius = this.Frame.Width / 2;
                CGPath path = new CGPath();
                path.AddArc(this.Frame.Width / 2, this.Frame.Height / 2, radius - 1, 0, (nfloat)(360 * radians), true);
                ViewColor.SetColor();
                context.AddPath(path);
                context.DrawPath(CGPathDrawingMode.FillStroke);

                UIColor.White.SetColor();
                CTFont font = new CTFont("Arial", 20);
                NSAttributedString stringToBeDrawn = new NSAttributedString(text, new CTStringAttributes()
                {
                    Font = font,
                    ForegroundColorFromContext = true,
                });

                context.TranslateCTM(this.Frame.Width / 2 - stringToBeDrawn.Size.Width / 2, this.Frame.Height / 2 + stringToBeDrawn.Size.Height / 4);
                context.ScaleCTM(1, -1);
                CTLine line = new CTLine(stringToBeDrawn);
                line.Draw(context);

                font = null;
                stringToBeDrawn = null;
                path = null;
            }
        }
    }
}