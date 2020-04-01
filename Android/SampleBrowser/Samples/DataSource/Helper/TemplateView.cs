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
using Android.Graphics.Drawables;
using Com.Syncfusion.Rating;
using Android.Util;
using Android.Graphics.Drawables.Shapes;

namespace SampleBrowser
{
    public class GettingStartedTemplate : GridLayout
    {
        #region Field

        private ImageView imageView;
        private TextView label1;
        private TextView label2;
        private TextView label3;
        private TextView label4;
        private GridLayout detailsLayout;
        #endregion

        public GettingStartedTemplate(Context context) : base(context)
        {
            this.ColumnCount = 2;
            this.RowCount = 1;
            var paddingValue = (int)(15 * Resources.DisplayMetrics.Density);
            this.SetPadding(paddingValue, paddingValue, paddingValue / 2, paddingValue);
            imageView = new ImageView(context);
            imageView.SetMaxHeight((int)(100 * this.Resources.DisplayMetrics.Density));
            imageView.SetMaxWidth((int)(80 * this.Resources.DisplayMetrics.Density));
            label1 = new TextView(context);
            label2 = new TextView(context);
            label3 = new TextView(context);
            label4 = new TextView(context);

            detailsLayout = new GridLayout(context);
            detailsLayout.RowCount = 4;
            detailsLayout.ColumnCount = 1;
            detailsLayout.AddView(label1);
            detailsLayout.AddView(label2);
            detailsLayout.AddView(label3);
            detailsLayout.AddView(label4);

            this.AddView(imageView, (int)(80 * this.Resources.DisplayMetrics.Density), (int)(100 * this.Resources.DisplayMetrics.Density));
            this.AddView(detailsLayout, ViewGroup.LayoutParams.MatchParent, (int)(100 * this.Resources.DisplayMetrics.Density));
        }

        public void UpdateValue(object obj)
        {
            var bookDetails = obj as BookDetails;
            imageView.SetImageBitmap(bookDetails.CustomerImage);
            label1.Text = "Name : " + bookDetails.CustomerName;
            label2.Text = "Book ID : " + bookDetails.BookID.ToString();
            label3.Text = "Book name : " + bookDetails.BookName;
            label4.Text = "Price : " + "$" + bookDetails.Price.ToString();
        }

        private void UpdateHeight()
        {
            var imageWidth = (int)(this.Resources.DisplayMetrics.WidthPixels * 0.35);
            detailsLayout.SetPadding((int)(this.Resources.DisplayMetrics.WidthPixels * 0.15), 0, 0, 0);
            var labelWidth = this.Resources.DisplayMetrics.WidthPixels - (imageWidth / 2);
            var labelHeight = ((int)(100 * this.Resources.DisplayMetrics.Density)) / 4;
            label1.SetMinimumHeight(labelHeight);
            label1.SetMinimumWidth(labelWidth);
            label2.SetMinimumHeight(labelHeight);
            label2.SetMinimumWidth(labelWidth);
            label3.SetMinimumHeight(labelHeight);
            label3.SetMinimumWidth(labelWidth);
            label4.SetMinimumHeight(labelHeight);
            label4.SetMinimumWidth(labelWidth);

            label1.Measure(labelWidth, labelHeight);
            label2.Measure(labelWidth, labelHeight);
            label3.Measure(labelWidth, labelHeight);
            label4.Measure(labelWidth, labelHeight);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            UpdateHeight();
            base.OnSizeChanged(w, h, oldw, oldh);
        }
    }

    public class ConctactTemplate : GridLayout
    {
        private CircleView label1;
        private TextView label2;
        private TextView label3;
        private GridLayout detailsLayout;

        public ConctactTemplate(Context context) : base(context)
        {
            this.SetPadding(25, 25, 25, 25);
            this.ColumnCount = 2;
            this.RowCount = 1;
            label1 = new CircleView(context);
           
            label1.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
            label1.TextSize = 25;
            label1.Gravity = GravityFlags.Center;
            label1.SetTextColor(Color.White);

            label2 = new TextView(context);
            label3 = new TextView(context);
            label2.Gravity = GravityFlags.Start;
            label3.Gravity = GravityFlags.Start;
            label2.SetTextColor(Color.Black);
            label2.TextSize = 18;
            label3.TextSize = 14;
            label3.SetTextColor(Color.LightGray);

            detailsLayout = new GridLayout(context);
            detailsLayout.RowCount = 4;
            detailsLayout.ColumnCount = 1;
            detailsLayout.AddView(label2);
            detailsLayout.AddView(label3);
            detailsLayout.SetPadding((int)(20 * this.Resources.DisplayMetrics.Density), (int)(5 * this.Resources.DisplayMetrics.Density), 0, 0);
            this.AddView(label1, (int)(50 * this.Resources.DisplayMetrics.Density), (int)(50 * this.Resources.DisplayMetrics.Density));
            this.AddView(detailsLayout);
        }

        public void UpdateValue(object obj)
        {
            var contact = obj as Contacts;
            label1.Text = contact.ContactName[0].ToString();
            label2.Text = contact.ContactName;
            label3.Text = contact.ContactNumber;
            label1.CircleColor = contact.ContactColor;
        }
    }

    public class CircleView : TextView
    {
        private Paint paint;
        private Paint textPaint;

        public Color CircleColor { get; set; }
         
        public CircleView(Context context) : base(context)
        {
            CircleColor = Color.White;
            paint = new Paint(PaintFlags.AntiAlias);
            paint.SetStyle(Android.Graphics.Paint.Style.FillAndStroke);
            textPaint = new Paint(PaintFlags.AntiAlias);
            textPaint.SetStyle(Android.Graphics.Paint.Style.Stroke);
            textPaint.TextSize = 20;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnDraw(Canvas canvas)
        {
            paint.Color = CircleColor;
            var x = this.Width / 2;
            canvas.DrawCircle(x, x, x, paint);
            base.OnDraw(canvas);
        }
    }
}