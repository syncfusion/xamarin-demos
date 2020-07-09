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
using Com.Syncfusion.Rangenavigator;
using Android.Util;
using Android.Graphics;

namespace SampleBrowser
{
    public class CustomRangeNavigator : SfDateTimeRangeNavigator
    {
        public CustomRangeNavigator(Context context) : base(context) { }

        public CustomRangeNavigator(Context context, IAttributeSet attrs) : base(context, attrs) { }

        public CustomRangeNavigator(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }

        protected override void DrawLeftThumb(Android.Graphics.Canvas p0, float x1, float y1, float x2, float y2)
        {
            float density = Context.Resources.DisplayMetrics.Density;
            Paint paint = new Paint();
            paint.AntiAlias = true;
            RectF rounderRectF = new RectF(x2 - (16.5f * density), y2 - (3.33f * density), x2 + (1.66f * density), y2 + (16.5f * density));
            paint.Color = (Color.ParseColor("#5f6872"));
            p0.DrawRoundRect(rounderRectF, 7, 7, paint);
            Path path = new Path();
            path.MoveTo(x2, y2 - (16.66f * density));
            path.LineTo(x2, y2);
            path.LineTo(x2 - (16.66f * density), y2 - (2 * density));
            path.Close();
            p0.DrawPath(path, paint);
            paint.StrokeWidth = (3.33f * density);
            p0.DrawLine(x1, y1, x2, y2, paint);
            SetLeftThumbBounds(new RectF(x2 - 25, y1 - 25, x2 + 25, y2 + 25));
        }

        protected override void DrawRightThumb(Android.Graphics.Canvas p0, float x1, float y1, float x2, float y2)
        {
            float density = Context.Resources.DisplayMetrics.Density;
            Paint paint = new Paint();
            paint.AntiAlias = true;
            RectF rounderRectF = new RectF(x2 - (1.66f * density), y2 - (3.33f * density), x2 + (16.66f * density), y2 + (16.66f * density));
            paint.Color = (Color.ParseColor("#5f6872"));
            p0.DrawRoundRect(rounderRectF, 7, 7, paint);
            Path path = new Path();
            path.MoveTo(x2, y2 - (16.66f * density));
            path.LineTo(x2, y2);
            path.LineTo(x2 + (16.66f * density), y2 - (2 * density));
            path.Close();
            p0.DrawPath(path, paint);
            paint.StrokeWidth = (3.33f * density);
            p0.DrawLine(x1, y1, x2, y2, paint);
            SetRightThumbBounds(new RectF(x2 - 25, y1 - 25, x2 + 25, y2 + 25));
        }
    }
}