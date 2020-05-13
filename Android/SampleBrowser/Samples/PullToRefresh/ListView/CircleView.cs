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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Util;

namespace SampleBrowser
{
    public class CircleViewOfTemplate : FrameLayout
    {
        public string Text { get; set; }

        public Color backgroundColor { get; set; }

        public CircleViewOfTemplate(Context context) : base(context)
        {
            Text = string.Empty;
            backgroundColor = Color.Rgb(0, 191, 255);
            SetWillNotDraw(false);
        }

        public CircleViewOfTemplate(Context context, IAttributeSet attributeSet) : base(context, attributeSet)
        {
            Text = string.Empty;
            backgroundColor = Color.Rgb(0, 191, 255);
            SetWillNotDraw(false);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            var radius = 25 * Resources.DisplayMetrics.Density;
            Paint paint = new Paint()
            {
                Color = backgroundColor,
                AntiAlias = true,
            };

            Paint textPaint = new Paint()
            {
                Color = Color.White,
                AntiAlias = true,
                TextSize = 25 * Resources.DisplayMetrics.Density,
                TextAlign = Paint.Align.Center
            };

            canvas.DrawCircle(this.Width / 2,
                              this.Height / 2,
                              radius,
                              paint);
            //Height is added with 7.5, to get the text at center
            canvas.DrawText(Text, this.Width / 2, (float)(this.Height / 2 + 7.5 * Resources.DisplayMetrics.Density), textPaint);
            paint = null;
            textPaint = null;
        }
    }
}