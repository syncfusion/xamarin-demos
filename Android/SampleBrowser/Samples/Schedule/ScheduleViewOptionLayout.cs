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
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Android.Util;

namespace SampleBrowser
{
	public class ScheduleViewOptionLayout : IDisposable
	{
		private Context con;
		private LinearLayout mainLayout, borderLayout;
		private SfSchedule sfSchedule;

        public FrameLayout OptionLayout
		{
			get;
			set;
		}

		public ScheduleViewOptionLayout(Context context, SfSchedule schedule)
		{
			con = context;
			sfSchedule = schedule;
			Density = con.Resources.DisplayMetrics;
			OptionLayout = new FrameLayout(context);
			OptionLayout.SetBackgroundColor(Color.White);
			OptionLayout.LayoutParameters = new ViewGroup.LayoutParams(Density.WidthPixels / 3, Density.HeightPixels / 3);
			borderLayout = new LinearLayout(context);
			borderLayout.SetBackgroundColor(Color.LightGray);
			borderLayout.SetPadding(1, 1, 1, 1);
			borderLayout.LayoutParameters = new ViewGroup.LayoutParams(Density.WidthPixels / 3, Density.HeightPixels / 3);
			AddHeaderViews();
		}

        internal DisplayMetrics Density { get; set; }

        internal TextView Day { get; set; }

        internal TextView Week { get; set; }

        internal TextView Workweek { get; set; }

        internal TextView Month { get; set; }

        private void AddHeaderViews()
		{
			mainLayout = new LinearLayout(con);
			mainLayout.SetBackgroundColor(Color.White);
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams(Density.WidthPixels / 3, Density.HeightPixels / 3);
			mainLayout.Orientation = Android.Widget.Orientation.Vertical;

			Day = new TextView(con);
			Day.Text = "Day";
			Day.TextSize = 20;
			Day.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (Density.HeightPixels / 3) / 4);
			
            //Where 20 as a textsize
			Day.SetPadding(10, (Day.LayoutParameters.Height / 2) - 20, 0, 0);

			Week = new TextView(con);
			Week.Text = "Week";
			Week.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (Density.HeightPixels / 3) / 4);
			Week.TextSize = 20;
			
            //Where 20 as a textsize
			Week.SetPadding(10, (Week.LayoutParameters.Height / 2) - 20, 0, 0);

			Workweek = new TextView(con);
			Workweek.Text = "Workweek";
			Workweek.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (Density.HeightPixels / 3) / 4);
			Workweek.TextSize = 20;
			
            //Where 20 as a textsize
			Workweek.SetPadding(10, (Workweek.LayoutParameters.Height / 2) - 20, 0, 0);

			Month = new TextView(con);
			Month.Text = "Month";
			Month.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (Density.HeightPixels / 3) / 4);
			Month.TextSize = 20;
			
            //Where 20 as a textsize
			Month.SetPadding(10, (Month.LayoutParameters.Height / 2) - 20, 0, 0);

			View divider1 = new View(con);
			divider1.SetBackgroundColor(Color.LightGray);
			divider1.LayoutParameters = new ViewGroup.LayoutParams(Density.WidthPixels / 3, 2);

			View divider2 = new View(con);
			divider2.SetBackgroundColor(Color.LightGray);
			divider2.LayoutParameters = new ViewGroup.LayoutParams(Density.WidthPixels / 3, 2);

			View divider3 = new View(con);
			divider3.SetBackgroundColor(Color.LightGray);
			divider3.LayoutParameters = new ViewGroup.LayoutParams(Density.WidthPixels / 3, 2);

			mainLayout.AddView(Day);
			mainLayout.AddView(divider1);
			mainLayout.AddView(Week);
			mainLayout.AddView(divider2);
			mainLayout.AddView(Workweek);
			mainLayout.AddView(divider3);
			mainLayout.AddView(Month);
			borderLayout.AddView(mainLayout);
			OptionLayout.AddView(borderLayout);
		}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void Day_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.DayView;
		}

        public void Dispose()
        {
           if (sfSchedule!= null)
            {
                sfSchedule.Dispose();
                sfSchedule = null;
            }

            if (mainLayout != null)
            {
                mainLayout.Dispose();
                mainLayout = null;
            }

            if (borderLayout != null)
            {
                borderLayout.Dispose();
                borderLayout = null;
            }
        }
    }
}