#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Sfrangeslider;
using System.Collections.Generic;
using Java.Util;
using Android.Graphics;
using Java.Text;
using Android.App;
using Android.OS;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class Configuration : SamplePage, IDisposable
	{
		public Configuration()
		{
		}

		private SfSchedule sfschedule;
		private FrameLayout propertylayout;
		private MonthViewSettings monthsettings;
		private bool isInitialLoad = false;

        public override View GetSampleContent(Context context)
		{
			sfschedule = new SfSchedule(context);
			weekViewSetting = new WeekViewSettings();
			monthsettings = new MonthViewSettings();
			propertylayout = new FrameLayout(context);
			isInitialLoad = true;
			propertylayout = SetOptionPage(context);
			GetAppointments();
			sfschedule.ItemsSource = appointmentCollection;

			sfschedule.ScheduleView = ScheduleView.WeekView;

			sfschedule.DayViewSettings.NonAccessibleBlocks = SetNonAccessibleBlocks();
			sfschedule.WeekViewSettings.NonAccessibleBlocks = SetNonAccessibleBlocks();
			sfschedule.WorkWeekViewSettings.NonAccessibleBlocks = SetNonAccessibleBlocks();

            monthsettings.BlackoutDates = SetBlackoutDates();
            monthsettings.ShowWeekNumber = true;
            sfschedule.MonthViewSettings = monthsettings;

            sfschedule.LayoutParameters = new FrameLayout.LayoutParams(
                LinearLayout.LayoutParams.MatchParent, 
                LinearLayout.LayoutParams.MatchParent);
			LinearLayout layout = new LinearLayout(context);
			layout.Orientation = Android.Widget.Orientation.Vertical;
			layout.AddView(sfschedule);
			return layout;
		}

		private List<String> subjectCollection;
		private List<String> colorCollection;
		private List<Calendar> startTimeCollection;
		private List<Calendar> endTimeCollection;
		private ScheduleAppointmentCollection appointmentCollection;

		//Creating appointments for ScheduleAppointmentCollection
		public void GetAppointments()
		{
			appointmentCollection = new ScheduleAppointmentCollection();
			SetColors();
			RandomNumbers();
			SetSubjects();
			SetStartTime();
			SetEndTime();

			for (int i = 0; i < 10; i++)
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
		}

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

		private List<Int32> randomNums;

        private void RandomNumbers()
		{
			randomNums = new List<Int32>();
			Java.Util.Random rand = new Java.Util.Random();
			for (int i = 0; i < 10; i++)
			{
				int randomNum = rand.NextInt((15 - 9) + 1) + 9;
				randomNums.Add(randomNum);
			}
		}

		private void SetStartTime()
		{
			Calendar currentDate = Calendar.Instance;
			startTimeCollection = new List<Calendar>();
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
		}

		private void SetEndTime()
		{
			Calendar currentDate = Calendar.Instance;
			endTimeCollection = new List<Calendar>();
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
				endTimeCollection.Add(endTime);
				count++;
			}
		}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private ObservableCollection<Calendar> SetBlackoutDates()
		{
			ObservableCollection<Calendar> black_dates = new ObservableCollection<Calendar>();
			Calendar currentDate = Calendar.Instance;
			Calendar firstDate = (Calendar)currentDate.Clone();
			firstDate.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
			   21);
			black_dates.Add(firstDate);
			Calendar secondDate = (Calendar)currentDate.Clone();
			secondDate.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
			  22);
			black_dates.Add(secondDate);
			Calendar thirdDate = (Calendar)currentDate.Clone();
			thirdDate.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
			   23);
			black_dates.Add(thirdDate);
			return black_dates;
		}

        private NonAccessibleBlocksCollection SetNonAccessibleBlocks()
        {
            NonAccessibleBlocksCollection nonAccessibleBlocksCollection = new NonAccessibleBlocksCollection();
            NonAccessibleBlock lunch = new NonAccessibleBlock();
            lunch.StartTime = 13;
            lunch.EndTime = 14;
            lunch.Text = "Lunch Break";
            nonAccessibleBlocksCollection.Add(lunch);
            nonAccessibleBlocks = nonAccessibleBlocksCollection;
            return nonAccessibleBlocks;
        }

		private WeekViewSettings weekViewSetting;
		private SfRangeSlider workHourRangeSlider;
		private CheckBox showWeekNumber;
		private TextView workingHoursTxtBlock;
		private CheckBox showNonAccessibleBlockcheckBox;
		private CheckBox showBlackoutDates;
		private LinearLayout monthViewLayout, otherviewsLayout;
		private NonAccessibleBlocksCollection nonAccessibleBlocks;

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
			layout.SetPadding(15, 15, 15, 20);

			monthViewLayout = new LinearLayout(context);
			monthViewLayout.Orientation = Android.Widget.Orientation.Vertical;
			monthViewLayout.SetBackgroundColor(Color.White);
			monthViewLayout.SetPadding(15, 15, 15, 20);

			otherviewsLayout = new LinearLayout(context);
			otherviewsLayout.Orientation = Android.Widget.Orientation.Vertical;
			otherviewsLayout.SetBackgroundColor(Color.White);
			otherviewsLayout.SetPadding(15, 15, 15, 20);

			//Schedule Type
			TextView scheduleType_txtBlock = new TextView(context);
			scheduleType_txtBlock.Text = "Select the Schedule Type";
			scheduleType_txtBlock.TextSize = 20;
			scheduleType_txtBlock.SetPadding(0, 0, 0, 10);
			scheduleType_txtBlock.SetTextColor(Color.Black);
			Spinner typeSpinner = new Spinner(context, SpinnerMode.Dialog);
            typeSpinner.SetMinimumHeight(60);
            typeSpinner.SetBackgroundColor(Color.Gray);
            typeSpinner.DropDownWidth = 600;
            typeSpinner.SetPadding(10, 10, 0, 10);
            typeSpinner.SetGravity(GravityFlags.CenterHorizontal);
			layout.AddView(scheduleType_txtBlock);
			layout.AddView(typeSpinner);

			List<String> list = new List<String>();
			list.Add("Week View");
			list.Add("Day View");
			list.Add("Work Week View");
			list.Add("Month View");

			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            typeSpinner.Adapter = dataAdapter;
            typeSpinner.ItemSelected += SType_spinner_ItemSelected;

			View divider1 = new View(context);
			divider1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
			divider1.SetBackgroundColor(Color.Gray);
			otherviewsLayout.AddView(divider1);

            //Working Hours Duration
            workingHoursTxtBlock = new TextView(context);
            workingHoursTxtBlock.SetPadding(0, 20, 0, 0);
            workingHoursTxtBlock.Text = "Working Hours Duration";
            workingHoursTxtBlock.TextSize = 20;
            workingHoursTxtBlock.SetTextColor(Color.Black);
            workHourRangeSlider = new SfRangeSlider(context);
            workHourRangeSlider.SetPadding(0, 0, 0, 30);
            workHourRangeSlider.Minimum = 0;
            workHourRangeSlider.Maximum = 24;
            workHourRangeSlider.TickFrequency = 2;
            workHourRangeSlider.StepFrequency = 1;
            workHourRangeSlider.RangeStart = weekViewSetting.WorkStartHour;
            workHourRangeSlider.RangeEnd = weekViewSetting.WorkEndHour;
            workHourRangeSlider.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100);
            workHourRangeSlider.RangeChanged += WorkHour_rangeSlider_RangeChanged;

            workHourRangeSlider.ShowRange = true;
            workHourRangeSlider.ValuePlacement = ValuePlacement.TopLeft;
            workHourRangeSlider.ToolTipPlacement = ToolTipPlacement.None;
            workHourRangeSlider.TickPlacement = TickPlacement.None;
            workHourRangeSlider.ShowValueLabel = true;
            workHourRangeSlider.SnapsTo = SnapsTo.StepValues;
			if (context.Resources.DisplayMetrics.Density < 2)
			{
                workHourRangeSlider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 150);
			}
			else if (context.Resources.DisplayMetrics.Density == 2)
			{
                workHourRangeSlider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200);
			}
			else
			{
                workHourRangeSlider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 250);
			}

			otherviewsLayout.AddView(workingHoursTxtBlock);
			otherviewsLayout.AddView(workHourRangeSlider);

			View divider2 = new View(context);
			divider2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
			divider2.SetBackgroundColor(Color.Gray);
			otherviewsLayout.AddView(divider2);

            showNonAccessibleBlockcheckBox = new CheckBox(context);
            showNonAccessibleBlockcheckBox.SetPadding(0, 10, 0, 10);
            showNonAccessibleBlockcheckBox.Text = "Show Non-Accessible Blocks";
            showNonAccessibleBlockcheckBox.TextSize = 20;
            showNonAccessibleBlockcheckBox.SetTextColor(Color.Black);
            showNonAccessibleBlockcheckBox.Checked = true;
            showNonAccessibleBlockcheckBox.CheckedChange += Show_Non_Accessible_Block_checkBox_CheckedChange;
			otherviewsLayout.AddView(showNonAccessibleBlockcheckBox);

			View monthlayoutDivider = new View(context);
			monthlayoutDivider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
			monthlayoutDivider.SetBackgroundColor(Color.Gray);
			monthViewLayout.AddView(monthlayoutDivider);

            //Show black out dates 
            showBlackoutDates = new CheckBox(context);
            showBlackoutDates.SetPadding(0, 10, 0, 10);
            showBlackoutDates.Text = "Show Blackout days";
            showBlackoutDates.TextSize = 20;
            showBlackoutDates.Checked = true;
            showBlackoutDates.SetTextColor(Color.Black);
            showBlackoutDates.CheckedChange += Show_Blackout_Dates_CheckedChange;
			monthViewLayout.AddView(showBlackoutDates);

            //Show week number 
            showWeekNumber = new CheckBox(context);
            showWeekNumber.SetPadding(0, 10, 0, 10);
            showWeekNumber.Text = "Show Week number";
            showWeekNumber.TextSize = 20;
            showWeekNumber.Checked = true;
            showWeekNumber.SetTextColor(Color.Black);
            showWeekNumber.CheckedChange += Show_week_number_CheckedChange;
			monthViewLayout.AddView(showWeekNumber);

			View monthLayoutdivider2 = new View(context);
			monthLayoutdivider2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
			monthLayoutdivider2.SetBackgroundColor(Color.Gray);
			monthViewLayout.AddView(monthLayoutdivider2);

			View divider5 = new View(context);
			divider5.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
			divider5.SetBackgroundColor(Color.Gray);
			otherviewsLayout.AddView(divider5);

			FrameLayout collapsedLayouts = new FrameLayout(context);

			collapsedLayouts.AddView(otherviewsLayout);
			collapsedLayouts.AddView(monthViewLayout);

			layout.AddView(collapsedLayouts);

			if (sfschedule.ScheduleView != ScheduleView.MonthView)
            {
                monthViewLayout.Visibility = ViewStates.Invisible;
            }

			propertyLayout.AddView(layout);
			return propertyLayout;
		}

		private void SType_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			String selectedItem = spinner.GetItemAtPosition(e.Position).ToString();

			if (sfschedule != null)
			{
				monthViewLayout.Visibility = ViewStates.Invisible;
				otherviewsLayout.Visibility = ViewStates.Visible;
				if (selectedItem.Equals("Day View"))
				{
					sfschedule.ScheduleView = ScheduleView.DayView;
				}
				else if (selectedItem.Equals("Week View"))
				{
					sfschedule.ScheduleView = ScheduleView.WeekView;
					sfschedule.EnableNavigation = true;
				}
				else if (selectedItem.Equals("Work Week View"))
				{
					sfschedule.ScheduleView = ScheduleView.WorkWeekView;
				}
				else if (selectedItem.Equals("Month View"))
				{
					monthViewLayout.Visibility = ViewStates.Visible;
					otherviewsLayout.Visibility = ViewStates.Invisible;
					sfschedule.ScheduleView = ScheduleView.MonthView;
				}
			}
		}
		
        //  void RangeChanged(Object o, double v, double v1)
		private void WorkHour_rangeSlider_RangeChanged(object sender, RangeChangedEventArgs e)
		{
			sfschedule.DayViewSettings.WorkStartHour = e.RangeStart;
			sfschedule.DayViewSettings.WorkEndHour = e.RangeEnd;
			sfschedule.WeekViewSettings.WorkStartHour = e.RangeStart;
			sfschedule.WeekViewSettings.WorkEndHour = e.RangeEnd;
			sfschedule.WorkWeekViewSettings.WorkStartHour = e.RangeStart;
			sfschedule.WorkWeekViewSettings.WorkEndHour = e.RangeEnd;
		}
		
        //void onCheckedChanged(CompoundButton buttonView, bool isChecked)  
		private void Show_Non_Accessible_Block_checkBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
			{
				sfschedule.DayViewSettings.NonAccessibleBlocks.Add(SetNonAccessibleBlocks()[0]);
				sfschedule.WeekViewSettings.NonAccessibleBlocks.Add(SetNonAccessibleBlocks()[0]);
				sfschedule.WorkWeekViewSettings.NonAccessibleBlocks.Add(SetNonAccessibleBlocks()[0]);
			}
			else
			{
                sfschedule.DayViewSettings.NonAccessibleBlocks.Clear();
                sfschedule.WeekViewSettings.NonAccessibleBlocks.Clear();
                sfschedule.WorkWeekViewSettings.NonAccessibleBlocks.Clear();
			}
		}

		//   void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
		private void Show_Blackout_Dates_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
			{
				if (!isInitialLoad)
				{
					sfschedule.MonthViewSettings.BlackoutDates = SetBlackoutDates();
					isInitialLoad = false;
				}
			}
			else
			{
                sfschedule.MonthViewSettings.BlackoutDates.Clear();
			}

			isInitialLoad = false;
		}

		//void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
		private void Show_week_number_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
			{
				if (sfschedule != null)
				{
					sfschedule.MonthViewSettings.ShowWeekNumber = true;
				}
			}
			else
			{
				sfschedule.MonthViewSettings.ShowWeekNumber = false;
			}
		}

		public override void OnApplyChanges()
		{
			base.OnApplyChanges();
		}

        public void Dispose()
        {
            if (sfschedule != null)
            {
                sfschedule.Dispose();
                sfschedule = null;
            }

            if (propertylayout != null)
            {
                propertylayout.Dispose();
                propertylayout = null;
            }

            if (monthViewLayout != null)
            {
                monthViewLayout.Dispose();
                monthViewLayout = null;
            }

            if (otherviewsLayout != null)
            {
                otherviewsLayout.Dispose();
                otherviewsLayout = null;
            }

            if (workHourRangeSlider != null)
            {
                workHourRangeSlider.RangeChanged -= WorkHour_rangeSlider_RangeChanged;
                workHourRangeSlider.Dispose();
                workHourRangeSlider = null;
            }

            if (showWeekNumber != null)
            {
                showWeekNumber.CheckedChange -= Show_week_number_CheckedChange;
                showWeekNumber.Dispose();
                showWeekNumber = null;
            }

            if (workingHoursTxtBlock != null)
            {
                workingHoursTxtBlock.Dispose();
                workingHoursTxtBlock = null;
            }

            if (showNonAccessibleBlockcheckBox != null)
            {
                showNonAccessibleBlockcheckBox.CheckedChange -= Show_Non_Accessible_Block_checkBox_CheckedChange;
                showNonAccessibleBlockcheckBox.Dispose();
                showNonAccessibleBlockcheckBox = null;
            }

            if (showBlackoutDates != null)
            {
                showBlackoutDates.CheckedChange -= Show_Blackout_Dates_CheckedChange;
                showBlackoutDates.Dispose();
                showBlackoutDates = null;
            }

            if (monthViewLayout != null)
            {
                monthViewLayout.Dispose();
                monthViewLayout = null;
            }
        }
    }
}
