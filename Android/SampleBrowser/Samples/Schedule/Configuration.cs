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
	public class Configuration : SamplePage
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
			getAppointments();
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
		public void getAppointments()
		{

			appointmentCollection = new ScheduleAppointmentCollection();
			setColors();
			RandomNumbers();
			setSubjects();
			setStartTime();
			setEndTime();

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

		private void setSubjects()
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

		private void setColors()
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

		List<Int32> randomNums;
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

		private void setStartTime()
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
					randomNums[count], 0, 0
				);
				startTimeCollection.Add(startTime);
				count++;
			}
		}
		private void setEndTime()
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
					randomNums[count] + 1, 0, 0
				);
				endTimeCollection.Add(endTime);
				count++;
			}
		}
		private ObservableCollection<Calendar> SetBlackoutDates()
		{
			ObservableCollection<Calendar> black_dates = new ObservableCollection<Calendar>();
			Calendar currentDate = Calendar.Instance;
			Calendar firstDate = (Calendar)currentDate.Clone();
			firstDate.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
			   21

			);
			black_dates.Add(firstDate);
			Calendar secondDate = (Calendar)currentDate.Clone();
			secondDate.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
			  22
			);
			black_dates.Add(secondDate);
			Calendar thirdDate = (Calendar)currentDate.Clone();
			thirdDate.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
			   23
			);
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
		private SfRangeSlider workHour_rangeSlider;
		private CheckBox show_week_number;
		private TextView workingHours_txtBlock;
		private CheckBox show_Non_Accessible_Block_checkBox;
		private CheckBox show_Blackout_Dates;
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
			Spinner sType_spinner = new Spinner(context, SpinnerMode.Dialog);
			sType_spinner.SetMinimumHeight(60);
			sType_spinner.SetBackgroundColor(Color.Gray);
			sType_spinner.DropDownWidth = 600;
			sType_spinner.SetPadding(10, 10, 0, 10);
			sType_spinner.SetGravity(GravityFlags.CenterHorizontal);
			layout.AddView(scheduleType_txtBlock);
			layout.AddView(sType_spinner);

			List<String> list = new List<String>();
			list.Add("Week View");
			list.Add("Day View");
			list.Add("Work Week View");
			list.Add("Month View");

			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource
		  (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sType_spinner.Adapter = dataAdapter;
			sType_spinner.ItemSelected += sType_spinner_ItemSelected;


			View divider1 = new View(context);
			divider1.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2));
			divider1.SetBackgroundColor(Color.Gray);
			otherviewsLayout.AddView(divider1);


			//Working Hours Duration
			workingHours_txtBlock = new TextView(context);
			workingHours_txtBlock.SetPadding(0, 20, 0, 0);
			workingHours_txtBlock.Text = "Working Hours Duration";
			workingHours_txtBlock.TextSize = 20;
			workingHours_txtBlock.SetTextColor(Color.Black);
			workHour_rangeSlider = new SfRangeSlider(context);
			workHour_rangeSlider.SetPadding(0, 0, 0, 30);
			workHour_rangeSlider.Minimum = 0;
			workHour_rangeSlider.Maximum = 24;
			workHour_rangeSlider.TickFrequency = 2;
			workHour_rangeSlider.StepFrequency = 1;
			workHour_rangeSlider.RangeStart = weekViewSetting.WorkStartHour;
			workHour_rangeSlider.RangeEnd = weekViewSetting.WorkEndHour;
			workHour_rangeSlider.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100);
			workHour_rangeSlider.RangeChanged += workHour_rangeSlider_RangeChanged;

			workHour_rangeSlider.ShowRange = true;
			workHour_rangeSlider.ValuePlacement = ValuePlacement.TopLeft;
			workHour_rangeSlider.ToolTipPlacement = ToolTipPlacement.None;
			workHour_rangeSlider.TickPlacement = TickPlacement.None;
			workHour_rangeSlider.ShowValueLabel = true;
			workHour_rangeSlider.SnapsTo = SnapsTo.StepValues;
			if (context.Resources.DisplayMetrics.Density < 2)
			{
				workHour_rangeSlider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 150);
			}
			else if (context.Resources.DisplayMetrics.Density == 2)
			{
				workHour_rangeSlider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200);
			}
			else
			{
				workHour_rangeSlider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 250);
			}
			otherviewsLayout.AddView(workingHours_txtBlock);
			otherviewsLayout.AddView(workHour_rangeSlider);

			View divider2 = new View(context);
			divider2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
			divider2.SetBackgroundColor(Color.Gray);
			otherviewsLayout.AddView(divider2);

			show_Non_Accessible_Block_checkBox = new CheckBox(context);
			show_Non_Accessible_Block_checkBox.SetPadding(0, 10, 0, 10);
			show_Non_Accessible_Block_checkBox.Text = "Show Non-Accessible Blocks";
			show_Non_Accessible_Block_checkBox.TextSize = 20;
			show_Non_Accessible_Block_checkBox.SetTextColor(Color.Black);
			show_Non_Accessible_Block_checkBox.Checked = true;
			show_Non_Accessible_Block_checkBox.CheckedChange += show_Non_Accessible_Block_checkBox_CheckedChange;
			otherviewsLayout.AddView(show_Non_Accessible_Block_checkBox);

			View monthlayoutDivider = new View(context);
			monthlayoutDivider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
			monthlayoutDivider.SetBackgroundColor(Color.Gray);
			monthViewLayout.AddView(monthlayoutDivider);
			//Show black out dates 
			show_Blackout_Dates = new CheckBox(context);
			show_Blackout_Dates.SetPadding(0, 10, 0, 10);
			show_Blackout_Dates.Text = "Show Blackout days";
			show_Blackout_Dates.TextSize = 20;
			show_Blackout_Dates.Checked = true;
			show_Blackout_Dates.SetTextColor(Color.Black);
			show_Blackout_Dates.CheckedChange += show_Blackout_Dates_CheckedChange;
			monthViewLayout.AddView(show_Blackout_Dates);

			//Show week number 
			show_week_number = new CheckBox(context);
			show_week_number.SetPadding(0, 10, 0, 10);
			show_week_number.Text = "Show Week number";
			show_week_number.TextSize = 20;
			show_week_number.Checked = true;
			show_week_number.SetTextColor(Color.Black);
			show_week_number.CheckedChange += show_week_number_CheckedChange;
			monthViewLayout.AddView(show_week_number);

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
				monthViewLayout.Visibility = ViewStates.Invisible;

			propertyLayout.AddView(layout);
			return propertyLayout;
		}
		private void sType_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
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
		private void workHour_rangeSlider_RangeChanged(object sender, RangeChangedEventArgs e)
		{
			sfschedule.DayViewSettings.WorkStartHour = e.RangeStart;
			sfschedule.DayViewSettings.WorkEndHour = e.RangeEnd;
			sfschedule.WeekViewSettings.WorkStartHour = e.RangeStart;
			sfschedule.WeekViewSettings.WorkEndHour = e.RangeEnd;
			sfschedule.WorkWeekViewSettings.WorkStartHour = e.RangeStart;
			sfschedule.WorkWeekViewSettings.WorkEndHour = e.RangeEnd;
		}
		//void onCheckedChanged(CompoundButton buttonView, bool isChecked)  
		private void show_Non_Accessible_Block_checkBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
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
		private void show_Blackout_Dates_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
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
		private void show_week_number_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
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
		public override void Destroy()
		{
			if (sfschedule != null)
			{
				sfschedule.Dispose();
				sfschedule = null;
			}
			if (workHour_rangeSlider != null)
			{
				workHour_rangeSlider.RangeChanged -= workHour_rangeSlider_RangeChanged;
				workHour_rangeSlider.Dispose();
				workHour_rangeSlider = null;
			}
			if (show_Non_Accessible_Block_checkBox != null)
			{
				show_Non_Accessible_Block_checkBox.CheckedChange -= show_Non_Accessible_Block_checkBox_CheckedChange;
				show_Non_Accessible_Block_checkBox.Dispose();
				show_Non_Accessible_Block_checkBox = null;
			}
			if (show_Blackout_Dates != null)
			{
				show_Blackout_Dates.CheckedChange -= show_Blackout_Dates_CheckedChange;
				show_Blackout_Dates.Dispose();
				show_Blackout_Dates = null;
			}
			if (show_week_number != null)
			{
				show_week_number.CheckedChange -= show_week_number_CheckedChange;
				show_week_number.Dispose();
				show_week_number = null;
			}
			base.Destroy();
		}

		public override void OnApplyChanges()
		{
			base.OnApplyChanges();
		}
	}
}
