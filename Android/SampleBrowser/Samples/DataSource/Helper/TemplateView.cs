#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

        ImageView ImageView;
        TextView Label1;
        TextView Label2;
        TextView Label3;
        TextView Label4;
        GridLayout DetailsLayout;
        #endregion

        public GettingStartedTemplate(Context context) : base(context)
        {
            this.ColumnCount = 2;
            this.RowCount = 1;
            var paddingValue = (int)(15 * Resources.DisplayMetrics.Density);
            this.SetPadding(paddingValue, paddingValue, paddingValue / 2, paddingValue);
            var height = (int)(100 * this.Resources.DisplayMetrics.Density);
            ImageView = new ImageView(context);
            ImageView.SetMaxHeight(((int)(100 * this.Resources.DisplayMetrics.Density)));
            ImageView.SetMaxWidth(((int)(80 * this.Resources.DisplayMetrics.Density)));
            Label1 = new TextView(context);
            Label2 = new TextView(context);
            Label3 = new TextView(context);
            Label4 = new TextView(context);

            DetailsLayout = new GridLayout(context);
            DetailsLayout.RowCount = 4;
            DetailsLayout.ColumnCount = 1;
            DetailsLayout.AddView(Label1);
            DetailsLayout.AddView(Label2);
            DetailsLayout.AddView(Label3);
            DetailsLayout.AddView(Label4);

            this.AddView(ImageView, (int)(80 * this.Resources.DisplayMetrics.Density), (int)(100 * this.Resources.DisplayMetrics.Density));
            this.AddView(DetailsLayout, ViewGroup.LayoutParams.MatchParent, (int)(100 * this.Resources.DisplayMetrics.Density));
        }

        public void UpdateValue(object obj)
        {
            var bookDetails = obj as BookDetails;
            ImageView.SetImageBitmap(bookDetails.CustomerImage);
            Label1.Text = "Name : " + bookDetails.CustomerName;
            Label2.Text = "Book ID : " + bookDetails.BookID.ToString();
            Label3.Text = "Book name : " + bookDetails.BookName;
            Label4.Text = "Price : " + "$" + bookDetails.Price.ToString();
        }

        private void UpdateHeight()
        {
            var imageWidth = (int)(this.Resources.DisplayMetrics.WidthPixels * 0.35);
            DetailsLayout.SetPadding((int)(this.Resources.DisplayMetrics.WidthPixels * 0.15), 0, 0, 0);
            var labelWidth = this.Resources.DisplayMetrics.WidthPixels - imageWidth / 2;
            var labelHeight = (int)(100 * this.Resources.DisplayMetrics.Density) / 4;
            Label1.SetMinimumHeight(labelHeight);
            Label1.SetMinimumWidth(labelWidth);
            Label2.SetMinimumHeight(labelHeight);
            Label2.SetMinimumWidth(labelWidth);
            Label3.SetMinimumHeight(labelHeight);
            Label3.SetMinimumWidth(labelWidth);
            Label4.SetMinimumHeight(labelHeight);
            Label4.SetMinimumWidth(labelWidth);

            Label1.Measure(labelWidth, labelHeight);
            Label2.Measure(labelWidth, labelHeight);
            Label3.Measure(labelWidth, labelHeight);
            Label4.Measure(labelWidth, labelHeight);
        }
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            UpdateHeight();
            base.OnSizeChanged(w, h, oldw, oldh);
        }
    }

    public class ConctactTemplate : GridLayout
    {
        CircleView Label1;
        TextView Label2;
        TextView Label3;
        GridLayout DetailsLayout;
        public ConctactTemplate(Context context) : base(context)
        {
            this.SetPadding(25, 25, 25, 25);
            this.ColumnCount = 2;
            this.RowCount = 1;
            Label1 = new CircleView(context);
           
            Label1.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
            Label1.TextSize = 25;
            Label1.Gravity = GravityFlags.Center;
            Label1.SetTextColor(Color.White);

            Label2 = new TextView(context);
            Label3 = new TextView(context);
            Label2.Gravity = GravityFlags.Start;
            Label3.Gravity = GravityFlags.Start;
            Label2.SetTextColor(Color.Black);
            Label2.TextSize = 18;
            Label3.TextSize = 14;
            Label3.SetTextColor(Color.LightGray);

            DetailsLayout = new GridLayout(context);
            DetailsLayout.RowCount = 4;
            DetailsLayout.ColumnCount = 1;
            DetailsLayout.AddView(Label2);
            DetailsLayout.AddView(Label3);
            DetailsLayout.SetPadding((int)(20 * this.Resources.DisplayMetrics.Density), (int)(5 * this.Resources.DisplayMetrics.Density), 0, 0);
            this.AddView(Label1, (int)(50 * this.Resources.DisplayMetrics.Density), (int)(50 * this.Resources.DisplayMetrics.Density));
            this.AddView(DetailsLayout);
        }

        public void UpdateValue(object obj)
        {
            var contact = obj as Contacts;
            Label1.Text = contact.ContactName[0].ToString();
            Label2.Text = contact.ContactName;
            Label3.Text = contact.ContactNumber;
            Label1.CircleColor = contact.ContactColor;
        }
    }

    public class CircleView : TextView
    {
        Paint paint;
        Random r;
        Paint textPaint;
        public Color CircleColor { get; set; }
         
        public CircleView(Context context) : base(context)
        {
            CircleColor = Color.White;
            r = new Random();
            paint = new Paint(PaintFlags.AntiAlias);
            paint.SetStyle(Android.Graphics.Paint.Style.FillAndStroke);
            textPaint =  new Paint(PaintFlags.AntiAlias);
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
            canvas.DrawCircle(x, x, x , paint);
            base.OnDraw(canvas);
        }
    }

}