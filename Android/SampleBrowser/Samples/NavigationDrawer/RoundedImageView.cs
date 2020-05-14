#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using Android.Content;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;

namespace SampleBrowser
{
	public  class RoundedImageView :ImageView
	{
		int width;

		public RoundedImageView (Context context,int _width, int _height) :
		base (context)
		{
			width = _width;
		}

		public RoundedImageView (Context context, IAttributeSet attrs) :
		base (context, attrs)
		{

		}

		public RoundedImageView (Context context, IAttributeSet attrs, int defStyle) :
		base (context, attrs, defStyle)
		{

		}

		protected override void OnDraw (Canvas canvas)
		{			
			Drawable drawable =  Drawable;
			if (drawable == null) {
				return;
			}
			if (Width == 0 || Height == 0) {
				return;
			}
			Bitmap b = ((BitmapDrawable) drawable).Bitmap;
			Bitmap bitmap = b.Copy(Bitmap.Config.Argb8888, true);
			int w = width;
			Bitmap roundBitmap =  getRoundedCroppedBitmap(bitmap, w);

			canvas.DrawBitmap(roundBitmap, 0, 0, null);
		}

		public static Bitmap getRoundedCroppedBitmap(Bitmap bitmap, int radius) {
			Bitmap finalBitmap;
			if (bitmap.Width != radius || bitmap.Height!= radius)
				finalBitmap = Bitmap.CreateScaledBitmap(bitmap, radius, radius,
					false);
			else
				finalBitmap = bitmap;
			Bitmap output = Bitmap.CreateBitmap(finalBitmap.Width,
				finalBitmap.Height, Bitmap.Config.Argb8888);
			Canvas canvas = new Canvas(output);

			 Paint paint = new Paint();
			Rect rect = new Rect(0, 0, finalBitmap.Width,
				finalBitmap.Height);

			paint.AntiAlias=true;
			paint.FilterBitmap=true;
			paint.Dither=true;
			canvas.DrawARGB(0, 0, 0, 0);
			paint.Color=Color.ParseColor("#BAB399");
			canvas.DrawCircle(finalBitmap.Width / 2 + 0.7f,
				finalBitmap.Height / 2 + 0.7f,
				finalBitmap.Width / 2 + 0.1f, paint);
			paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.SrcIn));
			canvas.DrawBitmap(finalBitmap, rect, rect, paint);

			return output;
		}	
	}
}

