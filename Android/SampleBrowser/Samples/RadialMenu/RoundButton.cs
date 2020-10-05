#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace SampleBrowser
{
	internal class RoundButton : View ,View.IOnClickListener
	{
	    internal Color fillColor; DoodleDraw doodleDraw;
		internal RoundButton(Context context,float height,float width,Color color,DoodleDraw doodle) :
			base(context)
		{
			
			SetWillNotDraw(false);
			this.height = height;
			this.width = width;
			fillColor = color;
			doodleDraw = doodle; 
			Initialize();
		}

		public RoundButton(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
			
		}

		public RoundButton(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle)
		{
			
		}
		RectF circle;
		internal void Initialize()
		{
			this.SetOnClickListener(this);
			circle = new RectF(0, 0, width, height);
			Invalidate();
		}

		protected override void OnDraw(Canvas canvas)
		{
			base.OnDraw(canvas);
			Paint buttonPaint = new Paint(PaintFlags.AntiAlias);

			if (circle != null)
			{
				buttonPaint.AntiAlias = true;
				buttonPaint.SetStyle(Paint.Style.Fill);
				buttonPaint.Color = fillColor;
				buttonPaint.Dither = true;
				canvas.DrawRoundRect(circle, 360, 360, buttonPaint);
			}
		}

		public void OnClick(View v)
		{
			if (doodleDraw != null)
				doodleDraw.drawColor = (v as RoundButton).fillColor;
		}



		float  width, height;




	}
}

