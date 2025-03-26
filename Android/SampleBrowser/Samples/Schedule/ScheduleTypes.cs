#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Android.Views;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using Android.Graphics;
using Java.Util;
using Android.App;
using Java.Text;
using Android.Util;

namespace SampleBrowser
{
	public class ScheduleTypes : SamplePage, IDisposable
	{
		private SfSchedule sfSchedule;
		private LinearLayout linearLayout;
		private IList<Calendar> visibleDates;
		private ScheduleCustomHeader scheduleCustomHeader;
		private ScheduleAppointmentEditor editor;
		private ScheduleViewOptionLayout viewOptionLayout;
		private ScheduleAppointment selectedAppointment;
		private int indexOfAppointment = -1;
		private DisplayMetrics density;
		private FrameLayout mainLayout;
		private FrameLayout propertylayout;

		private Context con;

		public override View GetSampleContent(Context context)
		{
			mainLayout = new FrameLayout(context);
			con = context;
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			density = con.Resources.DisplayMetrics;
			linearLayout = new LinearLayout(context);
			linearLayout.Orientation = Orientation.Vertical;
			linearLayout.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

			//creating instance for Schedule
			sfSchedule = new SfSchedule(context);
			sfSchedule.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
			sfSchedule.ScheduleView = ScheduleView.DayView;
			sfSchedule.HeaderHeight = 0;
			scheduleCustomHeader = new ScheduleCustomHeader(context);

			ViewHeaderStyle viewHeader = new ViewHeaderStyle();
			viewHeader.BackgroundColor = Color.Argb(255, 242, 242, 242);
			sfSchedule.ViewHeaderStyle = viewHeader;

			//set the appointment collection
			GetAppointments();
			sfSchedule.ItemsSource = appointmentCollection;

			linearLayout.AddView(scheduleCustomHeader.HeaderLayout);
			linearLayout.AddView(sfSchedule);

			editor = new ScheduleAppointmentEditor(context, sfSchedule);
			editor.EditorLayout.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

			viewOptionLayout = new ScheduleViewOptionLayout(con, sfSchedule);
			
            //viewOptionLayout.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
			mainLayout.AddView(linearLayout);
			mainLayout.AddView(editor.EditorLayout);
			mainLayout.AddView(viewOptionLayout.OptionLayout);
			mainLayout.GetChildAt(2).SetY(density.HeightPixels / 14);
			editor.EditorLayout.Visibility = ViewStates.Invisible;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
			HookEvents();
			propertylayout = SetOptionPage(context);
			return mainLayout;
		}

		public override View GetPropertyWindowLayout(Context context)
		{
			return propertylayout;
		}

		private FrameLayout SetOptionPage(Context context)
		{
			FrameLayout propertyLayout = new FrameLayout(context);
			LinearLayout layout = new LinearLayout(context);
			layout.Orientation = Android.Widget.Orientation.Vertical;
			layout.SetBackgroundColor(Color.White);

			TextView scheduleTimeZone = new TextView(con);
            scheduleTimeZone.Text = "Time Zone";
			scheduleTimeZone.TextSize = 18;
			scheduleTimeZone.SetTextColor(Color.Black);
			Spinner timeZone_spinner = new Spinner(con, SpinnerMode.Dialog);
			timeZone_spinner.SetMinimumHeight(60);
			timeZone_spinner.SetBackgroundColor(Color.Gray);
			timeZone_spinner.DropDownWidth = 600;
			timeZone_spinner.SetGravity(GravityFlags.CenterHorizontal);
			layout.AddView(scheduleTimeZone);
			layout.AddView(timeZone_spinner);

			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(con, Android.Resource.Layout.SimpleSpinnerItem, TimeZoneCollection.TimeZoneList);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			timeZone_spinner.Adapter = dataAdapter;
			timeZone_spinner.ItemSelected += TimeZone_Spinner_ItemSelected;
			propertyLayout.AddView(layout);

			return propertyLayout;
		}

		private void TimeZone_Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			if ((e.Parent.GetChildAt(0) as TextView) != null)
			{
				(e.Parent.GetChildAt(0) as TextView).TextSize = 18;
			}

			string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
			if (selectedItem != "Default")
			{
				sfSchedule.TimeZone = selectedItem;
			}
		}

		private void HookEvents()
		{
			scheduleCustomHeader.ScheduleCalendar.Click += ScheduleCalendar_Click;
			scheduleCustomHeader.SchedulePlus.Click += EditorLayout_Click;
			scheduleCustomHeader.ScheduleOption.Click += ScheduleOption_Click;
            sfSchedule.CellTapped += SfSchedule_CellTapped;
			sfSchedule.CellDoubleTapped += SfSchedule_DoubleTapped;
			sfSchedule.VisibleDatesChanged += SfSchedule_VisibleDatesChanged;

			editor.SaveButton.Click += SaveButton_Click;
			editor.CancelButton.Click += CancelButton_Click;

			viewOptionLayout.Day.Click += Day_Click;
			viewOptionLayout.Week.Click += Week_Click;
			viewOptionLayout.Workweek.Click += Workweek_Click;
			viewOptionLayout.Month.Click += Month_Click;
		}

        private void SfSchedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            if (sfSchedule.ScheduleView == ScheduleView.MonthView)
            {
                sfSchedule.ScheduleView = ScheduleView.DayView;
                sfSchedule.MoveToDate = e.Calendar;
            }
        }

        private void SfSchedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
		{
			visibleDates = e.VisibleDates;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;

			SimpleDateFormat dateFormat = new SimpleDateFormat("MMMM yyyy", Locale.Us);
			if (sfSchedule.ScheduleView == ScheduleView.DayView)
			{
				scheduleCustomHeader.MonthText.Text = dateFormat.Format(visibleDates[0].Time);
			}
			else if (sfSchedule.ScheduleView == ScheduleView.WeekView)
			{
				scheduleCustomHeader.MonthText.Text = dateFormat.Format(visibleDates[visibleDates.Count / 2].Time);
			}
			else if (sfSchedule.ScheduleView == ScheduleView.WorkWeekView)
			{
				scheduleCustomHeader.MonthText.Text = dateFormat.Format(visibleDates[visibleDates.Count / 2].Time);
			}
			else
			{
				scheduleCustomHeader.MonthText.Text = dateFormat.Format(visibleDates[visibleDates.Count / 2].Time);
			}
		}

		private void SfSchedule_DoubleTapped(object sender, CellTappedEventArgs e)
		{
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
			var schedule = sender as SfSchedule;
			if ((e.ScheduleAppointment as ScheduleAppointment) != null)
			{
				selectedAppointment = e.ScheduleAppointment as ScheduleAppointment;
				indexOfAppointment = (schedule.ItemsSource as ScheduleAppointmentCollection).IndexOf(e.ScheduleAppointment as ScheduleAppointment);
			}
			else
			{
				selectedAppointment = null;
				indexOfAppointment = -1;
			}

				linearLayout.Visibility = ViewStates.Invisible;
				editor.EditorLayout.Visibility = ViewStates.Visible;
			    editor.ScrollView.ScrollTo(0, 0);
				editor.UpdateEditor(e.ScheduleAppointment as ScheduleAppointment, e.Calendar as Calendar);
		}

		private void ScheduleCalendar_Click(object sender, EventArgs e)
		{
			sfSchedule.MoveToDate = Calendar.GetInstance(Locale.English);
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void EditorLayout_Click(object sender, EventArgs e)
		{
			linearLayout.Visibility = ViewStates.Invisible;
			editor.EditorLayout.Visibility = ViewStates.Visible;
			editor.UpdateEditor(null, visibleDates[0]);
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void ScheduleOption_Click(object sender, EventArgs e)
		{
			ShowInputDialog();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			linearLayout.Visibility = ViewStates.Visible;
			editor.EditorLayout.Visibility = ViewStates.Invisible;

			if (selectedAppointment != null)
			{
                (sfSchedule.ItemsSource as ScheduleAppointmentCollection).RemoveAt(indexOfAppointment);
                (sfSchedule.ItemsSource as ScheduleAppointmentCollection).Add(editor.SelectedAppointment);
			}
			else
			{
                (sfSchedule.ItemsSource as ScheduleAppointmentCollection).Add(editor.SelectedAppointment);
			}

			editor.SelectedAppointment = null;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			linearLayout.Visibility = ViewStates.Visible;
			editor.EditorLayout.Visibility = ViewStates.Invisible;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		protected void ShowInputDialog()
		{
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Visible;
		}

		private void Day_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.DayView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void Month_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.MonthView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void Workweek_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.WorkWeekView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void Week_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.WeekView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private List<string> subjectCollection = new List<string>();
        private List<string> minTimeSubjectCollection = new List<string>();
		private List<string> colorCollection = new List<string>();
		private List<Calendar> startTimeCollection = new List<Calendar>();
        private List<Calendar> minStartTimeCollection = new List<Calendar>();
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
			for (int i = 0; i < 10; i++)
			{
				var scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
				scheduleAppointment.Subject = subjectCollection[i];
				scheduleAppointment.StartTime = startTimeCollection[i];
				scheduleAppointment.EndTime = endTimeCollection[i];
                if (i == 4 || i == 9)
                {
                    scheduleAppointment.IsAllDay = true;
                }

                appointmentCollection.Add(scheduleAppointment);
			}

            // Minimum Height Appointments
            for (int i = 0; i < 5; i++)
            {
                var scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
                scheduleAppointment.Subject = minTimeSubjectCollection[i];
                scheduleAppointment.StartTime = minStartTimeCollection[i];
                scheduleAppointment.EndTime = minStartTimeCollection[i];
               
                // Setting Mininmum Appointment Height for Schedule Appointments
                scheduleAppointment.MinHeight = 50;
                appointmentCollection.Add(scheduleAppointment);
            }
		}

        private void SetSubjects()
		{
			subjectCollection = new List<String>();
			subjectCollection.Add("GoToMeeting");
			subjectCollection.Add("Business Meeting");
			subjectCollection.Add("Conference");
			subjectCollection.Add("Project Status Discussion");
			subjectCollection.Add("Auditing");
			subjectCollection.Add("Client Meeting");
			subjectCollection.Add("Generate Report");
			subjectCollection.Add("Target Meeting");
			subjectCollection.Add("General Meeting");
			subjectCollection.Add("Pay House Rent");
			subjectCollection.Add("Car Service");
			subjectCollection.Add("Medical Check Up");
			subjectCollection.Add("Wedding Anniversary");
			subjectCollection.Add("Sam's Birthday");
			subjectCollection.Add("Jenny's Birthday");
          
            // MinimumHeight Appointment Subjects
            minTimeSubjectCollection.Add("Work log alert");
            minTimeSubjectCollection.Add("Birthday wish alert");
            minTimeSubjectCollection.Add("Task due date");
            minTimeSubjectCollection.Add("Status mail");
            minTimeSubjectCollection.Add("Start sprint alert");
		}

		// adding colors collection
		private void SetColors()
		{
			colorCollection = new List<String>();
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FF00ABA9");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF00ABA9");
		}

		private List<int> randomNums = new List<int>();

        private void RandomNumbers()
		{
			randomNums = new List<int>();
			Java.Util.Random rand = new Java.Util.Random();
			for (int i = 0; i < 10; i++)
			{
				int randomNum = rand.NextInt((15 - 9) + 1) + 9;
				randomNums.Add(randomNum);
			}
		}
		
        // adding StartTime collection
		private void SetStartTime()
		{
			startTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				Calendar startTime = (Calendar)currentDate.Clone();
				startTime.Set(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[count],
					0,
					0);
				startTimeCollection.Add(startTime);
				count++;
			}

            // Zero duration Appoitments
            minStartTimeCollection = new List<Calendar>();
           
            for (int i = 0; i < 5; i++)
            {
                Calendar startTime = (Calendar)currentDate.Clone();
                startTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    randomNums[i],
                    30,
                    0);
                minStartTimeCollection.Add(startTime);
            }
		}

		// adding EndTime collection
		private void SetEndTime()
		{
			endTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				Calendar endTime = (Calendar)currentDate.Clone();
				endTime.Set(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[count] + 1,
					0,
					0);
                if (i == 4 || i == 2)
                {
                    endTime.Set(
                    currentDate.Get(CalendarField.Year),
                    currentDate.Get(CalendarField.Month),
                    currentDate.Get(CalendarField.DayOfMonth) + i,
                    randomNums[count] + 20,
                    0,
                    0);
                }

                endTimeCollection.Add(endTime);
				count++;
			}
		}

        public void Dispose()
        {
            if (sfSchedule != null)
            {
                sfSchedule.CellTapped -= SfSchedule_CellTapped;
                sfSchedule.CellDoubleTapped -= SfSchedule_DoubleTapped;
                sfSchedule.VisibleDatesChanged -= SfSchedule_VisibleDatesChanged;
                sfSchedule.Dispose();
                sfSchedule = null;
            }

            if (mainLayout != null)
            {
                mainLayout.Dispose();
                mainLayout = null;
            }

            if (propertylayout != null)
            {
                propertylayout.Dispose();
                propertylayout = null;
            }

            if (linearLayout != null)
            {
                linearLayout.Dispose();
                linearLayout = null;
            }

            if (editor != null)
            {
                if (editor.SaveButton != null)
                {
                    editor.SaveButton.Click -= SaveButton_Click;
                    editor.SaveButton.Dispose();
                    editor.SaveButton = null;
                }

                if (editor.CancelButton != null)
                {
                    editor.CancelButton.Click -= CancelButton_Click;
                    editor.CancelButton.Dispose();
                    editor.CancelButton = null;
                }

                editor.Dispose();
                editor = null;
            }

            if (scheduleCustomHeader != null)
            {
                if (scheduleCustomHeader.ScheduleCalendar != null)
                {
                    scheduleCustomHeader.ScheduleCalendar.Click -= ScheduleCalendar_Click;
                    scheduleCustomHeader.ScheduleCalendar.Dispose();
                    scheduleCustomHeader.ScheduleCalendar = null;
                }

                if (scheduleCustomHeader.SchedulePlus != null)
                {
                    scheduleCustomHeader.SchedulePlus.Click -= EditorLayout_Click;
                    scheduleCustomHeader.SchedulePlus.Dispose();
                    scheduleCustomHeader.SchedulePlus = null;
                }

                if (scheduleCustomHeader.ScheduleOption != null)
                {
                    scheduleCustomHeader.ScheduleOption.Click -= ScheduleOption_Click;
                    scheduleCustomHeader.ScheduleOption.Dispose();
                    scheduleCustomHeader.ScheduleOption = null;
                }

                scheduleCustomHeader.Dispose();
                scheduleCustomHeader = null;
            }

            if (viewOptionLayout != null)
            {
                if (viewOptionLayout.Day != null)
                {
                    viewOptionLayout.Day.Click -= Day_Click;
                    viewOptionLayout.Day.Dispose();
                    viewOptionLayout.Day = null;
                }

                if (viewOptionLayout.Week != null)
                {
                    viewOptionLayout.Week.Click -= Week_Click;
                    viewOptionLayout.Week.Dispose();
                    viewOptionLayout.Week = null;
                }

                if (viewOptionLayout.Workweek != null)
                {
                    viewOptionLayout.Workweek.Click -= Workweek_Click;
                    viewOptionLayout.Workweek.Dispose();
                    viewOptionLayout.Workweek = null;
                }

                if (viewOptionLayout.Month != null)
                {
                    viewOptionLayout.Month.Click -= Month_Click;
                    viewOptionLayout.Month.Dispose();
                    viewOptionLayout.Month = null;
                }

                viewOptionLayout.Dispose();
                viewOptionLayout = null;
            }

            if (minTimeSubjectCollection != null)
            {
                minTimeSubjectCollection.Clear();
                minTimeSubjectCollection = null;
            }

            if (minStartTimeCollection != null)
            {
                minStartTimeCollection.Clear();
                minStartTimeCollection = null;
            }
        }
    }

	public static class TimeZoneCollection
	{
		public static IList<string> TimeZoneList { get; set; } = new List<string>()
        {
                "Default",
                "AUS Central Standard Time",
                "AUS Eastern Standard Time",
                "Afghanistan Standard Time",
                "Alaskan Standard Time",
                "Arab Standard Time",
                "Arabian Standard Time",
                "Arabic Standard Time",
                "Argentina Standard Time",
                "Atlantic Standard Time",
                "Azerbaijan Standard Time",
                "Azores Standard Time",
                "Bahia Standard Time",
                "Bangladesh Standard Time",
                "Belarus Standard Time",
                "Canada Central Standard Time",
                "Cape Verde Standard Time",
                "Caucasus Standard Time",
                "Cen. Australia Standard Time",
                "Central America Standard Time",
                "Central Asia Standard Time",
                "Central Brazilian Standard Time",
                "Central Europe Standard Time",
                "Central European Standard Time",
                "Central Pacific Standard Time",
                "Central Standard Time",
                "China Standard Time",
                "Dateline Standard Time",
                "E. Africa Standard Time",
                "E. Australia Standard Time",
                "E. South America Standard Time",
                "Eastern Standard Time",
                "Egypt Standard Time",
                "Ekaterinburg Standard Time",
                "FLE Standard Time",
                "Fiji Standard Time",
                "GMT Standard Time",
                "GTB Standard Time",
                "Georgian Standard Time",
                "Greenland Standard Time",
                "Greenwich Standard Time",
                "Hawaiian Standard Time",
                "India Standard Time",
                "Iran Standard Time",
                "Israel Standard Time",
                "Jordan Standard Time",
                "Kaliningrad Standard Time",
                "Korea Standard Time",
                "Libya Standard Time",
                "Line Islands Standard Time",
                "Magadan Standard Time",
                "Mauritius Standard Time",
                "Middle East Standard Time",
                "Montevideo Standard Time",
                "Morocco Standard Time",
                "Mountain Standard Time",
                "Mountain Standard Time (Mexico)",
                "Myanmar Standard Time",
                "N. Central Asia Standard Time",
                "Namibia Standard Time",
                "Nepal Standard Time",
                "New Zealand Standard Time",
                "Newfoundland Standard Time",
                "North Asia East Standard Time",
                "North Asia Standard Time",
                "Pacific SA Standard Time",
                "Pacific Standard Time",
                "Pacific Standard Time (Mexico)",
                "Pakistan Standard Time",
                "Paraguay Standard Time",
                "Romance Standard Time",
                "Russia Time Zone 10",
                "Russia Time Zone 11",
                "Russia Time Zone 3",
                "Russian Standard Time",
                "SA Eastern Standard Time",
                "SA Pacific Standard Time",
                "SA Western Standard Time",
                "SE Asia Standard Time",
                "Samoa Standard Time",
                "Singapore Standard Time",
                "South Africa Standard Time",
                "Sri Lanka Standard Time",
                "Syria Standard Time",
                "Taipei Standard Time",
                "Tasmania Standard Time",
                "Tokyo Standard Time",
                "Tonga Standard Time",
                "Turkey Standard Time",
                "US Eastern Standard Time",
                "US Mountain Standard Time",
                "UTC",
                "UTC+12",
                "UTC-02",
                "UTC-11",
                "Ulaanbaatar Standard Time",
                "Venezuela Standard Time",
                "Vladivostok Standard Time",
                "W. Australia Standard Time",
                "W. Central Africa Standard Time",
                "W. Europe Standard Time",
                "West Asia Standard Time",
                "West Pacific Standard Time",
            "Yakutsk Standard Time"
        };
	}
}