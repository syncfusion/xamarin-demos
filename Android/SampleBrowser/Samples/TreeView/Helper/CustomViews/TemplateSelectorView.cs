#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;
using Syncfusion.Android.TreeView;
using Android.Util;
using Android.Runtime;

namespace SampleBrowser
{
    public class TemplateView : LinearLayout
    {
        #region Fields

        private ContentLabel label1;
        private ContentLabel label2;
        private int expanderWidth;

        #endregion

        #region Constructor

        public TemplateView(Context context, TreeViewItemInfoBase itemInfo) : base(context)
        {
            this.Orientation = Orientation.Horizontal;
            label1 = new ContentLabel(context);
            label1.Gravity = GravityFlags.CenterVertical;
            label1.SetPadding(0, 0, 0, 0);
            label2 = new ContentLabel(context);
            label2.Gravity = GravityFlags.Center;
            expanderWidth = (int)(itemInfo as TreeViewItemInfo).TreeView.ExpanderWidth;
            this.AddView(label1);
            this.AddView(label2);
        }

        #endregion

        #region Methods

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            var density = Resources.DisplayMetrics.Density;
            var measuredwidth = (int)(40 * density);
            var measuredheight = (int)(40 * density);
            var labelPadding = (int)(10 * density);
            var labelwidth = Math.Abs(widthMeasureSpec - measuredwidth);
            this.label1.SetMinimumHeight(measuredheight);
            this.label1.SetMinimumWidth(labelwidth);
            this.label2.SetMinimumHeight(measuredheight - (labelPadding * 2));
            this.label2.SetMinimumWidth(measuredwidth - labelPadding);
            this.label2.Measure(measuredwidth - labelPadding, measuredheight - (labelPadding * 2));
            this.label1.Measure(labelwidth, measuredheight);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var density = Resources.DisplayMetrics.Density;
            var measuredwidth = (int)(40 * density);
            var padding = (int)(10 * density);
            var measuredheight = (int)(40 * density);
            var expanderwidth = (int)(expanderWidth * density);
            this.label1.Layout(0, 0, this.Width - (measuredwidth + expanderwidth), measuredheight);
            this.label2.Layout(this.Width - (measuredwidth + expanderwidth), padding, this.Width- (expanderwidth + padding), measuredheight - padding);
        }
        #endregion
    }
}