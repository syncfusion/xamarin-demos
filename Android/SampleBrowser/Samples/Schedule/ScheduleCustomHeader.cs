#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Graphics;
using Android.App;
using Android.OS;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using Android.Media;
using Android.Util;

namespace SampleBrowser
{
	public class ScheduleCustomHeader
	{
		Context mContext;

		public TextView monthText;
		internal ImageView scheduleOption, schedulePlus, scheduleCalendar;
		private LinearLayout mainLayout, leftmainLayout, mainheaderLayout;
		private LinearLayout optionLinearlayout, monthTextlayout, plusLinearlayout, calendarLinearlayout;
		private DisplayMetrics density;


		public TableLayout HeaderLayout
		{
			get;
			set;
		}
		public ScheduleCustomHeader(Context context)
		{
			mContext = context;
			HeaderLayout = new TableLayout(context);
			density = mContext.Resources.DisplayMetrics;
			HeaderLayout.SetBackgroundColor(Color.Argb(255, 214, 214, 214));
			HeaderLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, density.HeightPixels / 14);
			AddHeaderViews();
		}

		private void AddHeaderViews()
		{

			mainLayout = new LinearLayout(mContext);
			int mainLayoutWidth = 0;
			if (density.Density > 2)
			{
				mainLayoutWidth = (int)(density.WidthPixels / 1.3);
			}
			else
			{
				mainLayoutWidth = (int)(density.WidthPixels / 1.4);
			}
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(mainLayoutWidth, density.HeightPixels / 14));
			mainLayout.Orientation = Android.Widget.Orientation.Horizontal;

			leftmainLayout = new LinearLayout(mContext);
			leftmainLayout.SetGravity(GravityFlags.Right);
			leftmainLayout.Orientation = Android.Widget.Orientation.Horizontal;

			mainheaderLayout = new LinearLayout(mContext);
			mainheaderLayout.Orientation = Android.Widget.Orientation.Horizontal;

			optionLinearlayout = new LinearLayout(mContext);
			optionLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(100, density.HeightPixels / 14));
			scheduleOption = new ImageView(mContext);
			scheduleOption.SetBackgroundResource(Resource.Drawable.scheduleOption);
			optionLinearlayout.AddView(scheduleOption);
			mainLayout.AddView(optionLinearlayout);

			monthTextlayout = new LinearLayout(mContext);
			monthTextlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(density.WidthPixels / 2, density.HeightPixels / 14));
			monthText = new TextView(mContext);
			monthText.SetTextColor(Color.Black);

			if (IsTabletDevice(mContext))
			{
				monthTextlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(density.WidthPixels / 2, density.HeightPixels / 14));
				monthTextlayout.SetGravity(GravityFlags.Center);
				monthText.SetPadding(10, 20, 0, 0);
			}


			if (density.Density > 2)
				monthText.SetPadding(10, 20, 0, 0);
			monthText.Gravity = GravityFlags.Fill;
			monthText.SetMinimumHeight(80);
			monthText.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
			monthText.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			monthText.TextSize = 20;
			monthText.Text = "August 2016";
			monthTextlayout.AddView(monthText);
			mainLayout.AddView(monthTextlayout);

			plusLinearlayout = new LinearLayout(mContext);
			if (density.Density > 2)
			{
				plusLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(120, density.HeightPixels / 13));
			}
			else if (density.Density < 2 && density.WidthPixels < 600)
			{
				plusLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(70, density.HeightPixels / 13));
			}
			else
			{
				plusLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(90, density.HeightPixels / 13));
			}
			schedulePlus = new ImageView(mContext);
			schedulePlus.SetBackgroundResource(Resource.Drawable.schedulePlus);
			plusLinearlayout.AddView(schedulePlus);
			leftmainLayout.AddView(plusLinearlayout);

			calendarLinearlayout = new LinearLayout(mContext);
			if (density.Density > 2)
			{
				calendarLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(120, density.HeightPixels / 13));
			}
			else if (density.Density < 2 && density.WidthPixels < 600)
			{
				calendarLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(70, density.HeightPixels / 13));
			}
			else
			{
				calendarLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(90, density.HeightPixels / 13));
			}
			scheduleCalendar = new ImageView(mContext);
			scheduleCalendar.SetBackgroundResource(Resource.Drawable.scheduleCalendar);
			calendarLinearlayout.AddView(scheduleCalendar);
			leftmainLayout.AddView(calendarLinearlayout);

			leftmainLayout.SetGravity(GravityFlags.Left);

			mainheaderLayout.AddView(mainLayout);
			mainheaderLayout.AddView(leftmainLayout);


			HeaderLayout.AddView(mainheaderLayout);

		}
		public static bool IsTabletDevice(Android.Content.Context context)
		{
			try
			{
				DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
				float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
				float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
				double size = Java.Lang.Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
				return size >= 6;
			}
			catch
			{
				return false;
			}
		}
	}
}
