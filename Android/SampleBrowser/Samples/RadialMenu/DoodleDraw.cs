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
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	public class DoodleDraw : View
	{
		private Paint mPaint;
		public DoodleDraw(Context context) :
			base(context)
		{
			mPath = new Path();
			mBitmapPaint = new Paint(PaintFlags.Dither);

		}

		public int width;
		public int height;
		private Bitmap mBitmap;
		internal Canvas mCanvas;
		internal Path mPath;
		private Paint mBitmapPaint;

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			mBitmap = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
			mCanvas = new Canvas(mBitmap);
		}

		internal Color drawColor = Color.Green; internal int strokeWidth = 12; internal Paint.Style style = Paint.Style.Stroke;
		protected override void OnDraw(Canvas canvas)
		{
			base.OnDraw(canvas);
			mPaint = new Paint();
			mPaint.AntiAlias = true;
			mPaint.Dither = true;
			mPaint.Color = drawColor;
			mPaint.SetStyle(style);
			mPaint.StrokeJoin = Paint.Join.Round;
			mPaint.StrokeCap = Paint.Cap.Round;
			mPaint.StrokeWidth = strokeWidth;
			if (!isPaintTapped)
			{
				canvas.DrawBitmap(mBitmap, 0, 0, mBitmapPaint);
				canvas.DrawPath(mPath, mPaint);
			}
			else
			{
				canvas.DrawColor(drawColor);
			}
		}

		private float mX, mY;
		private static float TOUCH_TOLERANCE = 4;
		internal bool isPaintTapped = false;

		private void touch_start(float x, float y)
		{
			mPath.Reset();
			mPath.MoveTo(x, y);
			mX = x;
			mY = y;
		}

		private void touch_move(float x, float y)
		{
			float dx = Math.Abs(x - mX);
			float dy = Math.Abs(y - mY);
			if (dx >= TOUCH_TOLERANCE || dy >= TOUCH_TOLERANCE)
			{
				mPath.QuadTo(mX, mY, (x + mX) / 2, (y + mY) / 2);
				mX = x;
				mY = y;
			}
		}

		private void touch_up()
		{
			mPath.LineTo(mX, mY);
			// commit the path to our offscreen
			mCanvas.DrawPath(mPath, mPaint);
			// kill this so we don't double draw
			mPath.Reset();
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			float x = e.GetX();

			float y = e.GetY();

			switch (e.ActionMasked)
			{
				case MotionEventActions.Down:
					touch_start(x, y);
					Invalidate();
					break;
				case MotionEventActions.Move:
					touch_move(x, y);
					Invalidate();
					break;
				case MotionEventActions.Up:
					touch_up();
					Invalidate();
					break;
			}
			return true;
		}



	}
}
