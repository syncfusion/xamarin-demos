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
    public class RowDragDropTemplate : LinearLayout
    {
        #region Fields

        Paint paint;
        Label label1;
        Label label2;
        Label label3;
        Label label4;
        Label label5;

        #endregion

        #region Constructor

        public RowDragDropTemplate(Context context) : base(context)
        {
            this.SetWillNotDraw(false);
            paint = new Paint(PaintFlags.AntiAlias);
            paint.SetStyle(Paint.Style.Stroke);
            this.Orientation = Orientation.Horizontal;
            paint.Color = Color.Black;
            label1 = new Label(context) { Gravity = GravityFlags.Center };
            label2 = new Label(context) { Gravity = GravityFlags.Center };
            label3 = new Label(context) { Gravity = GravityFlags.Center };
            label4 = new Label(context) { Gravity = GravityFlags.Center, IsLastLabel = true };
            label5 = new Label(context) { Gravity = GravityFlags.Center, IsLastLabel = true };
            this.AddView(label1);
            this.AddView(label2);
            this.AddView(label3);
            this.AddView(label4);
            //this.AddView(label5);
        }

        public RowDragDropTemplate(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public RowDragDropTemplate(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public RowDragDropTemplate(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected RowDragDropTemplate(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawRect(0, 0, this.Width, this.Height, paint);
            base.OnDraw(canvas);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            UpdateLabelWidthAndHeight();
            base.OnLayout(changed, l, t, r, b);
            this.label1.Layout(0, 0, this.Width / 4, this.Height);
            this.label2.Layout(label1.Right, 0, (this.Width / 4) * 2, this.Height);
            this.label3.Layout(label2.Right, 0, (this.Width / 4) * 3, this.Height);
            this.label4.Layout(label3.Right, 0, (this.Width / 4) * 4, this.Height);
            // this.label5.Layout(label4.Right, 0, (this.Width / 4) * 5, this.Height);
        }

        internal void UpdateRow(object rowData)
        {
            var orderInfo = rowData as OrderInfo;
            label1.Text = orderInfo.OrderID;
            label2.Text = orderInfo.EmployeeID;
            label3.Text = orderInfo.CustomerID;
            label4.Text = orderInfo.FirstName;
            //label5.Text = orderInfo.LastName;
        }

        internal void UpdateLabelWidthAndHeight()
        {
            label1.SetWidth(this.Width / 4);
            label2.SetWidth(this.Width / 4);
            label3.SetWidth(this.Width / 4);
            label4.SetWidth(this.Width / 4);
            //label5.SetWidth(this.Width / 5);

            label1.SetHeight(this.Height);
            label2.SetHeight(this.Height);
            label3.SetHeight(this.Height);
            label4.SetHeight(this.Height);
            //label5.SetHeight(this.Height);
        }

        #endregion
    }

    public class Label : TextView
    {
        public bool IsLastLabel { get; set; }

        public Label(Context context) : base(context)
        {
            this.SetWillNotDraw(false);
        }

        public Label(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public Label(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public Label(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected Label(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            if (!IsLastLabel)
                canvas.DrawLine(this.Width - this.Resources.DisplayMetrics.Density / 2, 0, this.Width - this.Resources.DisplayMetrics.Density / 2, this.Height, new Android.Graphics.Paint() { Color = Color.Black });
            base.OnDraw(canvas);
        }
    }
}