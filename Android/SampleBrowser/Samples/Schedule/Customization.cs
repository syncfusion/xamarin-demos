#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Views;
using Android.Content;
using Android.Widget;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using System.Collections.Generic;
using Android.Graphics;
using Java.Util;
using Android.Graphics.Drawables;
using Java.Text;

namespace SampleBrowser
{
	public class Customization : SamplePage, IDisposable
	{
		public Customization()
		{
		}

        /// <summary>
        /// Initialize schedule.
        /// </summary>
		private SfSchedule sfSchedule;

        /// <summary>
        /// Initialize context.
        /// </summary>
		private Context context;

        /// <summary>
        /// Initialize button.
        /// </summary>
        private Button customView;

		public override View GetSampleContent(Context context)
		{
			this.context = context;
			LinearLayout linearLayout = new LinearLayout(context);
			linearLayout.Orientation = Orientation.Vertical;
			
            //creating instance for Schedule
			sfSchedule = new SfSchedule(context);
			HeaderStyle headerStyle = new HeaderStyle();
			headerStyle.BackgroundColor = Color.Argb(255, 214, 214, 214);
			headerStyle.TextColor = Color.Black;

			ViewHeaderStyle viewHeader = new ViewHeaderStyle();
			viewHeader.BackgroundColor = Color.Argb(255, 28, 28, 28);
			viewHeader.DayTextColor = Color.Argb(255, 238, 199, 43);
			viewHeader.DateTextColor = Color.Argb(255, 238, 199, 43);

			sfSchedule.HeaderStyle = headerStyle;

			DayViewSettings dayViewSettings = new DayViewSettings();
			dayViewSettings.TimeSlotBorderStrokeWidth = 2;
			dayViewSettings.VerticalLineStrokeWidth = 0;
			dayViewSettings.VerticalLineColor = Color.Transparent;
			dayViewSettings.TimeSlotBorderColor = Color.LightGray;
			dayViewSettings.NonWorkingHoursTimeSlotBorderColor = Color.LightGray;
			sfSchedule.DayViewSettings = dayViewSettings;

			Button button = new Button(context);
			button.Text = "+ New event";
			button.SetTextColor(Color.White);
			button.Gravity = GravityFlags.Left;
			button.SetBackgroundColor(Color.Rgb(0, 122, 255));
			sfSchedule.SelectionView = button;

			//set the appointment collection
			GetAppointments();
			sfSchedule.ItemsSource = appointmentCollection;
            sfSchedule.AppointmentViewLayout = ViewLayoutOptions.Overlay;
			sfSchedule.MonthCellLoaded += SfSchedule_MonthCellLoaded;
			sfSchedule.LayoutParameters = new FrameLayout.LayoutParams(
				LinearLayout.LayoutParams.MatchParent,
		LinearLayout.LayoutParams.MatchParent);
			sfSchedule.AppointmentLoaded += SfSchedule_AppointmentLoaded;
			sfSchedule.CellTapped += SfSchedule_ScheduleTapped;
			linearLayout.AddView(sfSchedule);
			return linearLayout;
		}

		private TextView currentSelectedView;

        private void SfSchedule_ScheduleTapped(object sender, CellTappedEventArgs e)
		{
			if (currentSelectedView != null)
            {
                currentSelectedView.SetBackgroundColor(Color.ParseColor("#A237B3E6"));
            }
		}

		private void SfSchedule_AppointmentLoaded(object sender, AppointmentLoadedEventArgs e)
		{
            customView = new Button(context);
            customView.Text = e.Appointment.Subject;
            customView.TextAlignment = TextAlignment.Gravity;
            customView.Gravity = GravityFlags.CenterHorizontal;
            customView.SetTextColor(Color.White);
            customView.SetPadding(10, 20, 10, 20);

            if (customView.Text == "B'Day Party")
            {
                customView.SetCompoundDrawablesWithIntrinsicBounds(0, Resource.Drawable.family, 0, 0);
                customView.SetBackgroundColor(Color.ParseColor("#FFA2C139"));
            }
            else if (customView.Text == "Medical Checkup")
            {
                customView.SetCompoundDrawablesWithIntrinsicBounds(0, Resource.Drawable.hospital, 0, 0);
                customView.SetBackgroundColor(Color.ParseColor("#FFD80073"));
            }
            else
            {
                customView.SetCompoundDrawablesWithIntrinsicBounds(0, Resource.Drawable.team, 0, 0);
                customView.SetBackgroundColor(Color.ParseColor("#FF1BA1E2"));
            }

            e.View = customView;
		}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void FrameLayout_Click(object sender, EventArgs e)
		{
			currentSelectedView = sender as TextView;
			currentSelectedView.SetBackgroundColor(Color.ParseColor("#58FAF4"));
		}

		private void SfSchedule_MonthCellLoaded(object sender, MonthCellLoadedEventArgs e)
		{
			Calendar calendar = e.Calendar;
			FrameLayout frameLayout = new FrameLayout(context);
			if (calendar != null)
			{
				GradientDrawable gradientDrawable = new GradientDrawable(
						GradientDrawable.Orientation.TopBottom,
						new int[] { 255, 0 }); //0xFF616261
				gradientDrawable.SetCornerRadius(0f);
				TextView monthCellText = new TextView(context);
				String text = new SimpleDateFormat("dd").Format(calendar.Time);
				monthCellText.Text = text;
				if ((calendar.Get(CalendarField.DayOfWeek) == Calendar.Sunday) || (calendar.Get(CalendarField.DayOfWeek) == Calendar.Saturday))
				{
					monthCellText.SetTextColor(Color.Red);
				}
                else
				{
					monthCellText.SetTextColor(Color.Black);
				}

                if ((calendar.Get(CalendarField.Year) == Calendar.Instance.Get(CalendarField.Year)) && (calendar.Get(CalendarField.Month) == Calendar.Instance.Get(CalendarField.Month) && (calendar.Get(CalendarField.DayOfMonth) == Calendar.Instance.Get(CalendarField.DayOfMonth))))
				{
					monthCellText.SetTextColor(Color.LightBlue);
				}

				monthCellText.TextSize = 18;
				monthCellText.Gravity = GravityFlags.CenterHorizontal;
				monthCellText.SetPadding(0, 10, 0, 0);
				LinearLayout layout = new LinearLayout(context);

				Button appDot = new Button(context);
				LinearLayout.LayoutParams params1 = new LinearLayout.LayoutParams(
						LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
				params1.SetMargins(0, 80, 0, 0);
				appDot.LayoutParameters = params1;
				GradientDrawable appDotDrawable = new GradientDrawable();
				appDotDrawable.SetColor(255);
				appDotDrawable.SetCornerRadius(15);
				appDotDrawable.SetStroke(0, Color.Red);
				layout.SetGravity(GravityFlags.CenterHorizontal);
				appDot.Background = appDotDrawable;
				appDot.LayoutParameters = new ViewGroup.LayoutParams(10, 10);
				layout.Orientation = Orientation.Vertical;
				View line = new View(context);
				line.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 1);
				line.SetBackgroundColor(Color.Gray);
				layout.AddView(line);
				layout.AddView(monthCellText);
				if (e.Appointments != null && e.Appointments.Count > 0)
				{
					layout.AddView(appDot);
				}

				frameLayout.AddView(layout);
			}

			e.View = frameLayout;
		}

		private List<string> subjectCollection = new List<string>();
		private List<string> colorCollection = new List<string>();
		private List<Calendar> startTimeCollection = new List<Calendar>();
		private List<Calendar> endTimeCollection = new List<Calendar>();
		private ScheduleAppointmentCollection appointmentCollection;

		//Creating appointments for ScheduleAppointmentCollection
		private void GetAppointments()
		{
			appointmentCollection = new ScheduleAppointmentCollection();
			SetColors();
			RandomNumbers();
			SetSubjects();
			SetStartTime();
			SetEndTime();
			for (int i = 0; i < 3; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
				scheduleAppointment.Subject = subjectCollection[i];
				scheduleAppointment.StartTime = startTimeCollection[i];
				scheduleAppointment.EndTime = endTimeCollection[i];
				appointmentCollection.Add(scheduleAppointment);
			}
		}

		private void SetSubjects()
		{
			subjectCollection = new List<String>();
			subjectCollection.Add("B'Day Party");
			subjectCollection.Add("Medical Checkup");
			subjectCollection.Add("Conference");
		}

		// adding colors collection
		private void SetColors()
		{
			colorCollection = new List<String>();
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
		}

		private List<int> randomNums = new List<int>();

        private void RandomNumbers()
		{
			randomNums = new List<int>();
			Java.Util.Random rand = new Java.Util.Random();
			for (int i = 0; i < 3; i++)
			{
				int randomNum = rand.NextInt((11 - 9) + 1) + 9;
				randomNums.Add(randomNum);
			}
		}
		
        // adding StartTime collection
		private void SetStartTime()
		{
			startTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			for (int i = 0; i < 3; i++)
			{
				Calendar startTime = (Calendar)currentDate.Clone();
				startTime.Set(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[i],
					0,
					0);
				startTimeCollection.Add(startTime);
			}
		}

		// adding EndTime collection
		private void SetEndTime()
		{
			endTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			for (int i = 0; i < 3; i++)
			{
				Calendar endTime = (Calendar)currentDate.Clone();
				endTime.Set(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[i] + 2,
					0,
					0);
				endTimeCollection.Add(endTime);
			}
		}

		public void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			String selectedItem = spinner.GetItemAtPosition(e.Position).ToString();

			if (selectedItem.Equals("Day View"))
			{
				sfSchedule.ScheduleView = ScheduleView.DayView;
			}
			else if (selectedItem.Equals("Month View"))
			{
				sfSchedule.ScheduleView = ScheduleView.MonthView;
			}
		}

		public void OnNothingSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.WeekView;
		}

		public ScheduleAppointment P2 { get; set; }

		public View P1 { get; set; }

        public void Dispose()
        {
            if (sfSchedule != null)
            {
                sfSchedule.MonthCellLoaded -= SfSchedule_MonthCellLoaded;
                sfSchedule.AppointmentLoaded -= SfSchedule_AppointmentLoaded;
                sfSchedule.CellTapped -= SfSchedule_ScheduleTapped;
                sfSchedule.Dispose();
                sfSchedule = null;
            }

            if (customView != null)
            {
                customView.Dispose();
                customView = null;
            }
        }
    }
}