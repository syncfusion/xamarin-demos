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
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class NodeImageView : LinearLayout
    {
        #region Fields

        private ContentLabel label1;
        private ExpanderImage imageIcon; 

        #endregion

        #region Constructor

        public NodeImageView(Context context) : base(context)
        {
            this.Orientation = Orientation.Horizontal;
            label1 = new ContentLabel(context);
            label1.Gravity = GravityFlags.CenterVertical;
            imageIcon = new ExpanderImage(context);
            this.AddView(imageIcon);
            this.AddView(label1);
        }

        #endregion

        #region Methods

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var density = Resources.DisplayMetrics.Density;
            var measuredwidth = (int)(40 * density);
            var measuredheight = (int)(45 * density);
            var labelwidth = Math.Abs(widthMeasureSpec - measuredwidth); 
            this.label1.SetMinimumHeight(measuredheight);
            this.label1.SetMinimumWidth(labelwidth);
            this.imageIcon.SetMinimumHeight(measuredheight);
            this.imageIcon.SetMinimumWidth(measuredwidth);
            this.imageIcon.Measure(measuredwidth, measuredheight);
            this.label1.Measure(labelwidth, measuredheight);
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var density = Resources.DisplayMetrics.Density;
            var measuredwidth = (int)(40 * density);
            var measuredheight = (int)(45 * density);
            this.imageIcon.Layout(0, 0, measuredwidth, measuredheight);
            this.label1.Layout(measuredwidth, 0, Width, measuredheight);
        }

        #endregion
    }

    internal class ContentLabel : TextView
    {
        public ContentLabel(Context context) : base(context)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            this.SetMeasuredDimension(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
        }
    }

    internal class ExpanderImage : ImageView
    {
        public ExpanderImage(Context context) : base(context)
        {
            this.SetScaleType(ScaleType.CenterInside);
            var padding = (int)(5 * Resources.DisplayMetrics.Density);
            this.SetPadding(padding, padding, padding, padding);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            this.SetMeasuredDimension(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
        }
    }
}