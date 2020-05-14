#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
	public class ScheduleCustomHeader : IDisposable
	{
		public Context Context { get; set; }

		public TextView MonthText
        {
            get;
            set;
        }

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
            Context = context;
			HeaderLayout = new TableLayout(context);
			density = Context.Resources.DisplayMetrics;
			HeaderLayout.SetBackgroundColor(Color.Argb(255, 214, 214, 214));
			HeaderLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, density.HeightPixels / 14);
			AddHeaderViews();
		}

        internal ImageView ScheduleOption { get; set; }

        internal ImageView SchedulePlus { get; set; }

        internal ImageView ScheduleCalendar { get; set; }

        private void AddHeaderViews()
		{
			mainLayout = new LinearLayout(Context);
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

			leftmainLayout = new LinearLayout(Context);
			leftmainLayout.SetGravity(GravityFlags.Right);
			leftmainLayout.Orientation = Android.Widget.Orientation.Horizontal;

			mainheaderLayout = new LinearLayout(Context);
			mainheaderLayout.Orientation = Android.Widget.Orientation.Horizontal;

			optionLinearlayout = new LinearLayout(Context);
			optionLinearlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(100, density.HeightPixels / 14));
			ScheduleOption = new ImageView(Context);
			ScheduleOption.SetBackgroundResource(Resource.Drawable.scheduleOption);
			optionLinearlayout.AddView(ScheduleOption);
			mainLayout.AddView(optionLinearlayout);

			monthTextlayout = new LinearLayout(Context);
			monthTextlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(density.WidthPixels / 2, density.HeightPixels / 14));
			MonthText = new TextView(Context);
			MonthText.SetTextColor(Color.Black);

			if (IsTabletDevice(Context))
			{
				monthTextlayout.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams(density.WidthPixels / 2, density.HeightPixels / 14));
				monthTextlayout.SetGravity(GravityFlags.Center);
				MonthText.SetPadding(10, 20, 0, 0);
			}

			if (density.Density > 2)
            {
                MonthText.SetPadding(10, 20, 0, 0);
            }

			MonthText.Gravity = GravityFlags.Fill;
			MonthText.SetMinimumHeight(80);
			MonthText.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
			MonthText.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			MonthText.TextSize = 20;
			MonthText.Text = "August 2016";
			monthTextlayout.AddView(MonthText);
			mainLayout.AddView(monthTextlayout);

			plusLinearlayout = new LinearLayout(Context);
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

			SchedulePlus = new ImageView(Context);
			SchedulePlus.SetBackgroundResource(Resource.Drawable.schedulePlus);
			plusLinearlayout.AddView(SchedulePlus);
			leftmainLayout.AddView(plusLinearlayout);

			calendarLinearlayout = new LinearLayout(Context);
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

			ScheduleCalendar = new ImageView(Context);
			ScheduleCalendar.SetBackgroundResource(Resource.Drawable.scheduleCalendar);
			calendarLinearlayout.AddView(ScheduleCalendar);
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

        public void Dispose()
        {
            if (mainLayout != null)
            {
                mainLayout.Dispose();
                mainLayout = null;
            }

            if (leftmainLayout != null)
            {
                leftmainLayout.Dispose();
                leftmainLayout = null;
            }

            if (mainheaderLayout != null)
            {
                mainheaderLayout.Dispose();
                mainheaderLayout = null;
            }

            if (optionLinearlayout != null)
            {
                optionLinearlayout.Dispose();
                optionLinearlayout = null;
            }

            if (monthTextlayout != null)
            {
                monthTextlayout.Dispose();
                monthTextlayout = null;
            }

            if (plusLinearlayout != null)
            {
                plusLinearlayout.Dispose();
                plusLinearlayout = null;
            }

            if (calendarLinearlayout != null)
            {
                calendarLinearlayout.Dispose();
                calendarLinearlayout = null;
            }
        }
    }
}
