#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Syncfusion.SfRadialMenu.Android;

namespace SampleBrowser
{

	public class RadialMenuCustomization : SamplePage
	{
		LinearLayout mainLayout; double width, height; int buttonCount; float density; DoodleDraw dd;
		SfRadialMenu radialMenu;

		public override View GetSampleContent(Context context)
		{
			mainLayout = new LinearLayout(context);
			mainLayout.Orientation = Orientation.Vertical;
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			LinearLayout colorPalatte1 = new LinearLayout(context);
			height = context.Resources.DisplayMetrics.HeightPixels;
			width = context.Resources.DisplayMetrics.WidthPixels;

			density = context.Resources.DisplayMetrics.Density;
			dd = new DoodleDraw(context);
			TextView pickColor = new TextView(context);
			pickColor.Text = "Pick Color";
			pickColor.TextSize = 20;
			pickColor.Left = (int)(5 * density);
			pickColor.SetTextColor(Color.Black);
			//mainLayout.AddView(pickColor);

			buttonCount = (int)(width / (35 * density));

			for (int i = 0; i < buttonCount; i++)
			{
				RoundButton btn = new RoundButton(context, (30 * density), (30 * density), GetRandomColor(), dd);
				btn.LayoutParameters = new ViewGroup.LayoutParams((int)(30 * density), (int)(30 * density));
				colorPalatte1.AddView(new TextView(context), new ViewGroup.LayoutParams((int)(5 * density), ViewGroup.LayoutParams.MatchParent));
				colorPalatte1.AddView(btn);

			}
			colorPalatte1.SetBackgroundColor(Color.LightGray);
			colorPalatte1.SetPadding((int)(10 * density), (int)(10 * density), (int)(10 * density), (int)(10 * density));
			colorPalatte1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			mainLayout.AddView(colorPalatte1);


			dd.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			FrameLayout frame = new FrameLayout(context);
			frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(0.80 * height));
			frame.AddView(dd);
			mainLayout.AddView(frame);
			Typeface typeface = Typeface.CreateFromAsset(context.Assets, "Android.ttf");

			Button touchDraw = new Button(context);
			touchDraw.Text = "Touch to draw";
			touchDraw.SetTextColor(Color.Blue);
			touchDraw.SetBackgroundColor(Color.Transparent);
			touchDraw.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 3, context.Resources.DisplayMetrics);
			frame.AddView(touchDraw, new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Center));

			radialMenu = new SfRadialMenu(context);
			radialMenu.RimColor = Color.Transparent;
			FrameLayout penLayout = new FrameLayout(context);
			penLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView penImage = new ImageView(context);
			penImage.LayoutParameters = penLayout.LayoutParameters;
			penImage.SetImageResource(Resource.Drawable.green);
			penImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView penText = new TextView(context);
			penText.LayoutParameters = penLayout.LayoutParameters;
			penText.Text = "L";
			penText.Typeface = typeface;
			penText.TextSize = 20;
			penText.TextAlignment = TextAlignment.Center;
			penText.Gravity = GravityFlags.Center;
			penText.SetTextColor(Color.White);
			penLayout.AddView(penImage);
			penLayout.AddView(penText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem pen = new SfRadialMenuItem(context) { View = penLayout, ItemWidth = 70, ItemHeight = 70 };
			pen.ItemTapped += Pen_ItemTapped;
			radialMenu.Items.Add(pen);

			FrameLayout brushLayout = new FrameLayout(context);
			brushLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView brushImage = new ImageView(context);
			brushImage.LayoutParameters = brushLayout.LayoutParameters;
			brushImage.SetImageResource(Resource.Drawable.green);
			brushImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView brushText = new TextView(context);
			brushText.LayoutParameters = brushLayout.LayoutParameters;
			brushText.Text = "A";
			brushText.Typeface = typeface;
			brushText.TextSize = 20;
			brushText.TextAlignment = TextAlignment.Center;
			brushText.Gravity = GravityFlags.Center;
			brushText.SetTextColor(Color.White);
			brushLayout.AddView(brushImage);
			brushLayout.AddView(brushText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem brush = new SfRadialMenuItem(context) { View = brushLayout, ItemWidth = 70, ItemHeight = 70 };
			brush.SetBackgroundColor(Color.Transparent);
			brush.ItemTapped += Brush_ItemTapped; ;
			radialMenu.Items.Add(brush);

			FrameLayout eraserLayout = new FrameLayout(context);
			eraserLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView eraserImage = new ImageView(context);
			eraserImage.LayoutParameters = eraserLayout.LayoutParameters;
			eraserImage.SetImageResource(Resource.Drawable.green);
			eraserImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView eraserText = new TextView(context);
			eraserText.LayoutParameters = eraserLayout.LayoutParameters;
			eraserText.Text = "R";
			eraserText.Typeface = typeface;
			eraserText.TextSize = 20;
			eraserText.TextAlignment = TextAlignment.Center;
			eraserText.Gravity = GravityFlags.Center;
			eraserText.SetTextColor(Color.White);
			eraserLayout.AddView(eraserImage);
			eraserLayout.AddView(eraserText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem eraser = new SfRadialMenuItem(context) { View = eraserLayout, ItemWidth = 70, ItemHeight = 70 };
			eraser.ItemTapped += Eraser_ItemTapped;
			eraser.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(eraser);

			FrameLayout clearLayout = new FrameLayout(context);
			clearLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView clearImage = new ImageView(context);
			clearImage.LayoutParameters = clearLayout.LayoutParameters;
			clearImage.SetImageResource(Resource.Drawable.green);
			clearImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView clearText = new TextView(context);
			clearText.LayoutParameters = clearLayout.LayoutParameters;
			clearText.Text = "Q";
			clearText.Typeface = typeface;
			clearText.TextSize = 20;
			clearText.TextAlignment = TextAlignment.Center;
			clearText.Gravity = GravityFlags.Center;
			clearText.SetTextColor(Color.White);
			clearLayout.AddView(clearImage);
			clearLayout.AddView(clearText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem clear = new SfRadialMenuItem(context) { View = clearLayout, ItemWidth = 70, ItemHeight = 70 };
			clear.ItemTapped += Clear_ItemTapped;
			clear.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(clear);

			FrameLayout thickLayout = new FrameLayout(context);
			thickLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView thickImage = new ImageView(context);
			thickImage.LayoutParameters = thickLayout.LayoutParameters;
			thickImage.SetImageResource(Resource.Drawable.green);
			thickImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView thickText = new TextView(context);
			thickText.LayoutParameters = thickLayout.LayoutParameters;
			thickText.Text = "G";
			thickText.Typeface = typeface;
			thickText.TextSize = 20;
			brushText.TextAlignment = TextAlignment.Center;
			thickText.Gravity = GravityFlags.Center;
			thickText.SetTextColor(Color.White);
			thickLayout.AddView(thickImage);
			thickLayout.AddView(thickText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem thickBrush = new SfRadialMenuItem(context) { View = thickLayout, ItemWidth = 70, ItemHeight = 70 };
			thickBrush.ItemTapped += ThickBrush_ItemTapped;
			thickBrush.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(thickBrush);

			FrameLayout paintBoxLayout = new FrameLayout(context);
			paintBoxLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView paintBoxImage = new ImageView(context);
			paintBoxImage.LayoutParameters = paintBoxLayout.LayoutParameters;
			paintBoxImage.SetImageResource(Resource.Drawable.green);
			paintBoxImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView paintBoxText = new TextView(context);
			paintBoxText.LayoutParameters = paintBoxLayout.LayoutParameters;
			paintBoxText.Text = "V";
			paintBoxText.Typeface = typeface;
			paintBoxText.TextSize = 20;
			paintBoxText.TextAlignment = TextAlignment.Center;
			paintBoxText.Gravity = GravityFlags.Center;
			paintBoxText.SetTextColor(Color.White);
			paintBoxLayout.AddView(paintBoxImage);
			paintBoxLayout.AddView(paintBoxText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem paintBox = new SfRadialMenuItem(context) { View = paintBoxLayout, ItemWidth = 70, ItemHeight = 70 };
			paintBox.ItemTapped += PaintBox_ItemTapped;
			paintBox.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(paintBox);

			FrameLayout menuLayout = new FrameLayout(context);
			menuLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView menuImage = new ImageView(context);
			menuImage.LayoutParameters = menuLayout.LayoutParameters;
			menuImage.SetImageResource(Resource.Drawable.blue);
			menuImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView menuText = new TextView(context);
			menuText.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			menuText.Text = "U";
			menuText.Typeface = typeface;
			menuText.TextSize = 40;
			menuText.TextAlignment = TextAlignment.Center;
			menuText.Gravity = GravityFlags.Center;
			menuText.SetTextColor(Color.White);
			menuLayout.AddView(menuImage);
			menuLayout.AddView(menuText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			radialMenu.CenterButtonView = menuLayout;
			radialMenu.IsDragEnabled = false;
			radialMenu.OuterRimColor = Color.Transparent;
			radialMenu.CenterButtonRadius = 30;
			radialMenu.RimRadius = 100;
            radialMenu.SelectionColor = Color.Transparent;
			radialMenu.CenterButtonBackground = Color.Transparent;
			frame.AddView(radialMenu, new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Center));
            radialMenu.Point = new Point(0,(int)(context.Resources.DisplayMetrics.HeightPixels / context.Resources.DisplayMetrics.Density / 3.5));

			touchDraw.Click += (sender, e) =>
			{
				touchDraw.Visibility = ViewStates.Gone;
			};
			return mainLayout;
		}

		private int getNavigationBarHeight(Android.Content.Context con)
		{
			int navBarHeight = 0;
			int resourceId = con.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
			if (resourceId > 0)
			{
				navBarHeight = con.Resources.GetDimensionPixelSize(resourceId);
			}
			return navBarHeight;
		}

		View GetIconView(Context con, Typeface typeface, string v1, int v2)
		{
			FrameLayout frame = new FrameLayout(con);
			ImageView backImage = new ImageView(con);
			backImage.SetScaleType(ImageView.ScaleType.FitXy);
			frame.LayoutParameters = new FrameLayout.LayoutParams(v2, v2);
			backImage.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			frame.AddView(backImage);
			TextView menuIcon = new TextView(con);
			menuIcon.Text = v1;
			menuIcon.TextSize = 10 * density;
			menuIcon.Typeface = typeface;
			frame.AddView(menuIcon);
			return frame;
		}

		static Random rand = new Random();



		public static Color GetRandomColor()
		{
			Color color = Color.Rgb(rand.Next(255), rand.Next(255), rand.Next(255));
			return color;
		}

		public void OnClick(View v)
		{
			if (v != null)
			{
				dd.drawColor = (v as RoundButton).fillColor;
				dd.Invalidate();
			}
		}

		void Pen_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
		{
			dd.strokeWidth = 2;
			dd.isPaintTapped = false;
			radialMenu.Close();
			//dd.Invalidate();
		}

		void Brush_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
		{
			dd.style = Paint.Style.Stroke;
			dd.strokeWidth = 12;
			dd.isPaintTapped = false;
			radialMenu.Close();
			//dd.Invalidate();
		}

		void ThickBrush_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
		{
			dd.style = Paint.Style.Stroke;
			dd.strokeWidth = 80;
			dd.isPaintTapped = false;
			radialMenu.Close();
		}

		void Eraser_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
		{
			dd.style = Paint.Style.Stroke;
			dd.strokeWidth = 30;
			dd.drawColor = Color.White;
			dd.isPaintTapped = false;
			radialMenu.Close();
		}

		void PaintBox_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
		{
			dd.isPaintTapped = true;
			radialMenu.Close();
		}

		void Clear_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
		{
			dd.isPaintTapped = false;
			dd.mCanvas.DrawColor(Color.White, PorterDuff.Mode.Clear);
			dd.mPath.Reset();
			dd.Invalidate();
			radialMenu.Close();
		}
	}
}

