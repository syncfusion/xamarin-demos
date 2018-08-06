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
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Android.Util;

namespace SampleBrowser
{
	public class ScheduleViewOptionLayout
	{
		private Context mContext;
		private LinearLayout mainLayout, borderLayout;
		private SfSchedule sfSchedule;
		internal TextView day, week, workweek, month;
		internal DisplayMetrics density;
		public FrameLayout OptionLayout
		{
			get;
			set;
		}

		public ScheduleViewOptionLayout(Context context, SfSchedule _schedule)
		{
			mContext = context;
			sfSchedule = _schedule;
			density = mContext.Resources.DisplayMetrics;
			OptionLayout = new FrameLayout(context);
			OptionLayout.SetBackgroundColor(Color.White);
			OptionLayout.LayoutParameters = new ViewGroup.LayoutParams(density.WidthPixels / 3, density.HeightPixels / 3);
			borderLayout = new LinearLayout(context);
			borderLayout.SetBackgroundColor(Color.LightGray);
			borderLayout.SetPadding(1, 1, 1, 1);
			borderLayout.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 3), (density.HeightPixels / 3));
			AddHeaderViews();
		}

		private void AddHeaderViews()
		{
			mainLayout = new LinearLayout(mContext);
			mainLayout.SetBackgroundColor(Color.White);
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 3), (density.HeightPixels / 3));
			mainLayout.Orientation = Android.Widget.Orientation.Vertical;

			day = new TextView(mContext);
			day.Text = "Day";
			day.TextSize = 20;
			day.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 3) / 4);
			//Where 20 as a textsize
			day.SetPadding(10, day.LayoutParameters.Height / 2 - 20, 0, 0);

			week = new TextView(mContext);
			week.Text = "Week";
			week.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 3) / 4);
			week.TextSize = 20;
			//Where 20 as a textsize
			week.SetPadding(10, week.LayoutParameters.Height / 2 - 20, 0, 0);

			workweek = new TextView(mContext);
			workweek.Text = "Workweek";
			workweek.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 3) / 4);
			workweek.TextSize = 20;
			//Where 20 as a textsize
			workweek.SetPadding(10, workweek.LayoutParameters.Height / 2 - 20, 0, 0);

			month = new TextView(mContext);
			month.Text = "Month";
			month.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 3) / 4);
			month.TextSize = 20;
			//Where 20 as a textsize
			month.SetPadding(10, month.LayoutParameters.Height / 2 - 20, 0, 0);

			View divider1 = new View(mContext);
			divider1.SetBackgroundColor(Color.LightGray);
			divider1.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 3), 2);

			View divider2 = new View(mContext);
			divider2.SetBackgroundColor(Color.LightGray);
			divider2.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 3), 2);

			View divider3 = new View(mContext);
			divider3.SetBackgroundColor(Color.LightGray);
			divider3.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 3), 2);

			mainLayout.AddView(day);
			mainLayout.AddView(divider1);
			mainLayout.AddView(week);
			mainLayout.AddView(divider2);
			mainLayout.AddView(workweek);
			mainLayout.AddView(divider3);
			mainLayout.AddView(month);
			borderLayout.AddView(mainLayout);
			OptionLayout.AddView(borderLayout);
		}

		private void Day_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.DayView;
		}
	}
}

