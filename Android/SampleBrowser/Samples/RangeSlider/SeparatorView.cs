#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
	public class SeparatorView : View
	{
		float ScreenWidth;
		public SeparatorView (Context context,float width) :
			base (context)
		{
			Initialize (width);
		}

		public SeparatorView (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			//Initialize ();
		}

		public SeparatorView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			//Initialize ();
		}

		void Initialize (float width)
		{
			ScreenWidth = width;
			this.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
		}
		public Color separatorColor= Color.LightGray;
		protected override void OnDraw (Android.Graphics.Canvas canvas)
		{
			base.OnDraw (canvas);
			Paint pnt=new Paint();
			pnt.Color = separatorColor;
			pnt.StrokeWidth = 5;

			canvas.DrawLine(0,0,this.ScreenWidth,0,pnt);
		}
	}
}

