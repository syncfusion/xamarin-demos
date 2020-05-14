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
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using System.Collections.Generic;
using Java.Util;
using Java.Text;
using Android.Util;
using Android.Views.InputMethods;
using Android.Graphics.Drawables;

namespace SampleBrowser
{
	public class ScheduleAppointmentEditor : IDisposable
	{
        #region Properties and variables

        private Context con;
		private EditText subjectInput, locationInput;
		private Switch allDaySwitch;
		private SfSchedule sfSchedule;
		private Spinner endTimeZonePicker, startTimeZonePicker;
		private TextView startDateName, startTimeName, endDateName, endTimeName;
		
		private SimpleDateFormat dateFormat = new SimpleDateFormat("MMM dd,  yyyy", Locale.Us);
		private SimpleDateFormat timeFormat = new SimpleDateFormat("hh:mm aa", Locale.Us);

		public LinearLayout EditorLayout
		{
			get;
			set;
		}

		public ScheduleAppointment SelectedAppointment { get; set; }

		private Calendar selectedDate;
		private Calendar startTime;
		private Calendar endTime;

		private DisplayMetrics density;

		#endregion

		#region Constructor

		public ScheduleAppointmentEditor(Context context, SfSchedule schedule)
		{
			con = context;
			sfSchedule = schedule;
			density = con.Resources.DisplayMetrics;
			EditorLayout = new LinearLayout(context);
			EditorLayout.Orientation = Orientation.Vertical;
			EditorLayout.SetBackgroundColor(Color.White);
			EditorLayout.SetPaddingRelative(30, 30, 30, 30);
			AddInputControls();
		}

        internal Button SaveButton { get; set; }

        internal Button CancelButton { get; set; }

        internal ScrollView ScrollView { get; set; }

        #endregion

        #region Methods
        private void AddInputControls()
		{
			var padding = 30;
			ScrollView = new ScrollView(con);
			ScrollView.ScrollTo(0, 0);
			var inputControlLayout = new LinearLayout(con);
			inputControlLayout.Orientation = Orientation.Vertical;

			subjectInput = new EditText(con);
			subjectInput.Gravity = GravityFlags.Fill;
			subjectInput.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, density.HeightPixels / 12);
			subjectInput.SetTextColor(Color.Black);
			subjectInput.Hint = "Event name";
			subjectInput.TextSize = 30;
			subjectInput.SetLines(1);

			subjectInput.KeyPress += (object sender, View.KeyEventArgs e) =>
			 {
				 e.Handled = false;
				 if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
				 {
					 InputMethodManager inputmanager = (InputMethodManager)con.GetSystemService(Context.InputMethodService);
					 inputmanager.HideSoftInputFromWindow(subjectInput.WindowToken, 0);
					 e.Handled = true;
				 }
			 };

			inputControlLayout.AddView(subjectInput);

			locationInput = new EditText(con);
			locationInput.SetTextColor(Color.Black);
			locationInput.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, density.HeightPixels / 12);
			locationInput.Gravity = GravityFlags.Fill;
			locationInput.SetMinimumHeight(80);
			locationInput.SetLines(1);
			locationInput.TextSize = 18;
			locationInput.Hint = "Location";
			locationInput.KeyPress += (object sender, View.KeyEventArgs e) =>
						{
							e.Handled = false;
							if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
							{
								InputMethodManager inputmanager = (InputMethodManager)con.GetSystemService(Context.InputMethodService);
								inputmanager.HideSoftInputFromWindow(subjectInput.WindowToken, 0);
								e.Handled = true;
							}
						};
			inputControlLayout.AddView(locationInput);

			LinearLayout timeLayout = new LinearLayout(con);
			timeLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			timeLayout.Orientation = Orientation.Vertical;

			TextView startTimeLabel = new TextView(con);
			startTimeLabel.Text = "FROM";
			startTimeLabel.Gravity = GravityFlags.CenterVertical;
			startTimeLabel.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, density.HeightPixels / 12);
			startTimeLabel.TextSize = 18;
			timeLayout.AddView(startTimeLabel);

			//startTime row
			LinearLayout minuteLayout = new LinearLayout(con);
			minuteLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, density.HeightPixels / 12);
			minuteLayout.Orientation = Orientation.Horizontal;

			startDateName = new TextView(con);
			startDateName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			startDateName.TextSize = 18;
			startDateName.SetPadding(0, 0, density.WidthPixels / 4, 0);
			startDateName.SetTextColor(Color.Black);
			minuteLayout.AddView(startDateName);

			startTimeName = new TextView(con);
			startTimeName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			startTimeName.TextSize = 18;
			startTimeName.SetTextColor(Color.Black);
			minuteLayout.AddView(startTimeName);
			timeLayout.AddView(minuteLayout);

			TextView startTimeZoneLabel = new TextView(con);
			startTimeZoneLabel.Text = "Start Time Zone";
			startTimeZoneLabel.TextSize = 18;
			startTimeZoneLabel.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, density.HeightPixels / 13);
			startTimeZoneLabel.SetTextColor(Color.Black);

			startTimeZonePicker = new Spinner(con, SpinnerMode.Dialog);
			startTimeZonePicker.SetMinimumHeight(60);
			startTimeZonePicker.SetBackgroundColor(Color.LightGray);
			startTimeZonePicker.DropDownWidth = 600;
			startTimeZonePicker.SetGravity(GravityFlags.Center);
			timeLayout.AddView(startTimeZoneLabel);
			timeLayout.AddView(startTimeZonePicker);

			ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>(con, Android.Resource.Layout.SimpleSpinnerItem, TimeZoneCollection.TimeZoneList);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			startTimeZonePicker.Adapter = dataAdapter;
			startTimeZonePicker.ItemSelected += StartTimeZone_Spinner_ItemSelected;

			//endTime label row
			TextView endTimeLabel = new TextView(con);
			endTimeLabel.Text = "TO";
			endTimeLabel.Gravity = GravityFlags.CenterVertical;
			endTimeLabel.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, density.HeightPixels / 11);
			endTimeLabel.TextSize = 18;
			timeLayout.AddView(endTimeLabel);

			//endTime row
			LinearLayout minuteToLayout = new LinearLayout(con);
			minuteToLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, density.HeightPixels / 12);
			minuteToLayout.Orientation = Orientation.Horizontal;

			endDateName = new TextView(con);
			endDateName.SetRawInputType(Android.Text.InputTypes.DatetimeVariationTime);
			endDateName.SetTextColor(Color.Black);
			endDateName.SetPadding(0, 0, density.WidthPixels / 4, 0);
			endDateName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			endDateName.TextSize = 18;
			minuteToLayout.AddView(endDateName);

			endTimeName = new TextView(con);
			endTimeName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			endTimeName.SetTextColor(Color.Black);
			endTimeName.TextSize = 18;
			minuteToLayout.AddView(endTimeName);
			timeLayout.AddView(minuteToLayout);

			TextView endTimeZoneLabel = new TextView(con);
			endTimeZoneLabel.Text = "End Time Zone";
			endTimeZoneLabel.TextSize = 18;
			endTimeZoneLabel.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, density.HeightPixels / 13);
			endTimeZoneLabel.SetTextColor(Color.Black);
			endTimeZonePicker = new Spinner(con, SpinnerMode.Dialog);
			endTimeZonePicker.SetMinimumHeight(60);
			endTimeZonePicker.SetBackgroundColor(Color.LightGray);
			endTimeZonePicker.DropDownWidth = 600;
			endTimeZonePicker.SetGravity(GravityFlags.Center);
			timeLayout.AddView(endTimeZoneLabel);
			timeLayout.AddView(endTimeZonePicker);

			ArrayAdapter<string> endTimeZoneAdapter = new ArrayAdapter<string>(con, Android.Resource.Layout.SimpleSpinnerItem, TimeZoneCollection.TimeZoneList);
			endTimeZoneAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			endTimeZonePicker.Adapter = endTimeZoneAdapter;
			endTimeZonePicker.ItemSelected += EndTimeZone_Spinner_ItemSelected;
			inputControlLayout.AddView(timeLayout);

			var allDaylayout = new LinearLayout(con);
			allDaylayout.SetPadding(0, 10, 0, 0);
			allDaylayout.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, density.HeightPixels / 12);
			allDaylayout.Orientation = Orientation.Horizontal;
			TextView allDayLabel = new TextView(con);
			allDayLabel.Text = "All Day";
			allDayLabel.TextSize = 18;
			allDayLabel.Gravity = GravityFlags.CenterVertical;
			allDayLabel.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 2) - padding, LinearLayout.LayoutParams.MatchParent);
			allDayLabel.SetTextColor(Color.Black);

			allDaySwitch = new Switch(con);
			allDaySwitch.Checked = false;
			allDaySwitch.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 2) - padding, LinearLayout.LayoutParams.MatchParent);
			allDaySwitch.Gravity = GravityFlags.CenterVertical;
			allDaySwitch.CheckedChange += AllDaySwitch_CheckedChange;

			allDaylayout.AddView(allDayLabel);
			allDaylayout.AddView(allDaySwitch);
			inputControlLayout.AddView(allDaylayout);

			var buttonlayout = new LinearLayout(con);
			buttonlayout.SetPadding(0, 10, 0, 0);
			buttonlayout.Orientation = Orientation.Horizontal;

			CancelButton = new Button(con);
			CancelButton.SetBackgroundColor(Color.LightGray);
			CancelButton.SetPadding(0, 10, 30, 10);
			CancelButton.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 2) - padding, LinearLayout.LayoutParams.MatchParent);
			CancelButton.Text = "Cancel";
			CancelButton.TextSize = 15;
			CancelButton.SetTextColor(Color.Black);
			buttonlayout.AddView(CancelButton);

			SaveButton = new Button(con);
			SaveButton.SetBackgroundColor(Color.ParseColor("#2196F3"));
			SaveButton.SetPadding(0, 10, 30, 10);
			SaveButton.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels / 2) - padding, LinearLayout.LayoutParams.MatchParent);
			SaveButton.Text = "Save";
			SaveButton.TextSize = 15;
			SaveButton.SetTextColor(Color.White);
			buttonlayout.AddView(SaveButton);

			inputControlLayout.AddView(buttonlayout);
			ScrollView.AddView(inputControlLayout);
			EditorLayout.AddView(ScrollView);
			HookEvents();
		}

		private void AllDaySwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
			{
				this.DisableChid();
			}
			else
			{
				this.EnableChid();
			}

			if (SelectedAppointment != null)
			{
				SelectedAppointment.IsAllDay = e.IsChecked;
			}
		}

		private void StartTimeZone_Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			if ((e.Parent.GetChildAt(0) as TextView) != null)
			{
				(e.Parent.GetChildAt(0) as TextView).TextSize = 18;
			}

			string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
			if (selectedItem != "Default" && SelectedAppointment != null)
			{
				SelectedAppointment.StartTimeZone = selectedItem;
			}
		}

		private void EndTimeZone_Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			if ((e.Parent.GetChildAt(0) as TextView) != null)
			{
				(e.Parent.GetChildAt(0) as TextView).TextSize = 18;
			}

			string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
			if (selectedItem != "Default" && SelectedAppointment != null)
			{
				SelectedAppointment.EndTimeZone = selectedItem;
			}
		}

		public void UpdateEditor(ScheduleAppointment appointment, Calendar date)
		{
			SelectedAppointment = appointment;
			selectedDate = date;
			if (appointment != null)
			{
				subjectInput.Text = appointment.Subject.ToString();
                locationInput.Text = appointment.Location;
				startDateName.Text = dateFormat.Format(appointment.StartTime.Time);
				startTimeName.Text = timeFormat.Format(appointment.StartTime.Time);
				endDateName.Text = dateFormat.Format(appointment.EndTime.Time);
				endTimeName.Text = timeFormat.Format(appointment.EndTime.Time);
				startTime = appointment.StartTime;
				endTime = appointment.EndTime;
				allDaySwitch.Checked = appointment.IsAllDay;
				if (appointment.IsAllDay)
				{
					this.DisableChid();
				}
				else
				{
					this.EnableChid();
				}
			}
			else
			{
				subjectInput.Text = "";
				startDateName.Text = dateFormat.Format(date.Time);
				startTimeName.Text = timeFormat.Format(date.Time) + " ";
				Calendar endTime1 = (Calendar)date.Clone();
                endTime1.Add(CalendarField.Hour, 1);
				endDateName.Text = dateFormat.Format(endTime1.Time);
				endTimeName.Text = timeFormat.Format(endTime1.Time) + " ";
				startTime = date;
				endTime = endTime1;
				allDaySwitch.Checked = false;
				this.EnableChid();
			}
		}

		/// <summary>
		/// Disable the time and timezone spinner while slecte the non all day appointment.
		/// </summary>
		private void DisableChid()
		{
			startTimeName.Text = "12:00 AM";
			endTimeName.Text = "12:00 AM";
			startTimeName.SetTextColor(Color.Gray);
			endTimeName.SetTextColor(Color.Gray);
			startTimeName.Enabled = false;
			startTimeName.Clickable = false;
			endTimeName.Enabled = false;
			endTimeName.Clickable = false;
			startTimeZonePicker.Enabled = false;
			startTimeZonePicker.Clickable = false;
			endTimeZonePicker.Enabled = false;
			endTimeZonePicker.Clickable = false;
		}

		/// <summary>
		/// Enable the time and timezone spinner while slecte the non all day appointment.
		/// </summary>
		private void EnableChid()
		{
			if (SelectedAppointment != null)
			{
				endTimeName.Text = timeFormat.Format(SelectedAppointment.EndTime.Time);
				startTimeName.Text = timeFormat.Format(SelectedAppointment.StartTime.Time);
			}
			else if (selectedDate != null)
			{
				startTimeName.Text = timeFormat.Format(selectedDate.Time) + " ";
				Calendar endTime = (Calendar)selectedDate.Clone();
				endTime.Add(CalendarField.Hour, 1);
				endTimeName.Text = timeFormat.Format(endTime.Time) + " ";
			}

			startTimeName.SetTextColor(Color.Black);
			endTimeName.SetTextColor(Color.Black);
			startTimeName.Enabled = true;
			startTimeName.Clickable = true;
			endTimeName.Enabled = true;
			endTimeName.Clickable = true;
			startTimeZonePicker.Enabled = true;
			startTimeZonePicker.Clickable = true;
			endTimeZonePicker.Enabled = true;
			endTimeZonePicker.Clickable = true;
		}

		private void HookEvents()
		{
			startDateName.Click += StartDateName_Click;
			startTimeName.Click += StartTimeName_Click;
			endDateName.Click += EndDateName_Click;
			endTimeName.Click += EndTimeName_Click;
			CancelButton.Click += CancelButton_Click;
			SaveButton.Click += SaveButton_Click;
		}

		private void StartTimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			Calendar modifiedTime = Calendar.Instance;
			modifiedTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			modifiedTime.Set(CalendarField.Minute, e.Minute);
			startTimeName.Text = timeFormat.Format(modifiedTime.Time);

			startTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			startTime.Set(CalendarField.Minute, e.Minute);
			endTime.Set(CalendarField.HourOfDay, e.HourOfDay + 1);
			endTime.Set(CalendarField.Minute, e.Minute);
			endTimeName.Text = timeFormat.Format(endTime.Time);
			startTimeName.Text = timeFormat.Format(modifiedTime.Time);
		}

		private void EndTimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			Calendar modifiedTime = Calendar.Instance;
			modifiedTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			modifiedTime.Set(CalendarField.Minute, e.Minute);
			endTimeName.Text = timeFormat.Format(modifiedTime.Time);
			endTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			endTime.Set(CalendarField.Minute, e.Minute);

			endTimeName.Text = timeFormat.Format(modifiedTime.Time);
		}

        private void StartDatePickerCallback(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            Calendar modifiedDate = Calendar.Instance;
            modifiedDate.Set(CalendarField.DayOfMonth, e.DayOfMonth);
            modifiedDate.Set(CalendarField.Month, e.Month);
            modifiedDate.Set(CalendarField.Year, e.Year);

            startDateName.Text = dateFormat.Format(modifiedDate.Time);
            startTimeName.Text = timeFormat.Format(modifiedDate.Time);

            Calendar startDatePickerDate = Calendar.Instance;
            startDatePickerDate.Set(CalendarField.DayOfMonth, e.DayOfMonth);
            startDatePickerDate.Set(CalendarField.Month, e.Month);
            startDatePickerDate.Set(CalendarField.Year, e.Year);
            startTime = (Calendar)startDatePickerDate.Clone();
            startDateName.Text = dateFormat.Format(modifiedDate.Time);
        }

		private void EndDatePickerCallback(object sender, DatePickerDialog.DateSetEventArgs e)
		{
            Calendar modifiedDate = Calendar.Instance;
			modifiedDate.Set(CalendarField.DayOfMonth, e.DayOfMonth);
			modifiedDate.Set(CalendarField.Month, e.Month);
			modifiedDate.Set(CalendarField.Year, e.Year);

			endDateName.Text = dateFormat.Format(modifiedDate.Time);
			endTimeName.Text = timeFormat.Format(modifiedDate.Time);
            Calendar endDatePickerDate = Calendar.Instance;
            endDatePickerDate.Set(CalendarField.DayOfMonth, e.DayOfMonth);
			endDatePickerDate.Set(CalendarField.Month, e.Month);
			endDatePickerDate.Set(CalendarField.Year, e.Year);
            endTime = (Calendar)endDatePickerDate.Clone();

			endDateName.Text = dateFormat.Format(modifiedDate.Time);
        }

		#endregion

		#region Events

		private void StartDateName_Click(object sender, EventArgs e)
		{
			DatePickerDialog datePickerDialog = new DatePickerDialog(
                                                                     con,
																	 StartDatePickerCallback,
																	 startTime.Get(CalendarField.Year),
																	 startTime.Get(CalendarField.Month),
																	 startTime.Get(CalendarField.DayOfMonth));

			datePickerDialog.Show();
		}

		private void StartTimeName_Click(object sender, EventArgs e)
		{
			TimePickerDialog timePicker = new TimePickerDialog(
                                                               con,
															   StartTimePickerCallback,
															   startTime.Get(CalendarField.HourOfDay),
															   startTime.Get(CalendarField.Minute),
															   false);
			timePicker.Show();
		}

		private void EndDateName_Click(object sender, EventArgs e)
		{
			DatePickerDialog datePickerDialog = new DatePickerDialog(
                                                                     con,
																	 EndDatePickerCallback,
																	 endTime.Get(CalendarField.Year),
																	 endTime.Get(CalendarField.Month),
																	 endTime.Get(CalendarField.DayOfMonth));

			datePickerDialog.Show();
		}

		private void EndTimeName_Click(object sender, EventArgs e)
		{
			TimePickerDialog timePicker = new TimePickerDialog(
                                                               con,
															   EndTimePickerCallback,
															   endTime.Get(CalendarField.HourOfDay),
															   endTime.Get(CalendarField.Minute),
															   false);
			timePicker.Show();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (SelectedAppointment == null)
			{
				SelectedAppointment = new ScheduleAppointment();
			}

			SelectedAppointment.Subject = subjectInput.Text;
            SelectedAppointment.Location = locationInput.Text;
            SelectedAppointment.StartTime = (Calendar)startTime.Clone();
			SelectedAppointment.EndTime = (Calendar)endTime.Clone();
			SelectedAppointment.IsAllDay = allDaySwitch.Checked;

			EditorLayout.Visibility = ViewStates.Invisible;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			EditorLayout.Visibility = ViewStates.Invisible;
		}

        public void Dispose()
        {
            if (subjectInput != null)
            {
                subjectInput.Dispose();
                subjectInput = null;
            }

            if (locationInput != null)
            {
                locationInput.Dispose();
                locationInput = null;
            }

            if (allDaySwitch != null)
            {
                allDaySwitch.CheckedChange -= AllDaySwitch_CheckedChange;
                allDaySwitch.Dispose();
                allDaySwitch = null;
            }

            if (endTimeZonePicker != null)
            {
                endTimeZonePicker.ItemSelected -= EndTimeZone_Spinner_ItemSelected;
                endTimeZonePicker.Dispose();
                endTimeZonePicker = null;
            }

            if (startTimeZonePicker != null)
            {
                startTimeZonePicker.ItemSelected -= StartTimeZone_Spinner_ItemSelected;
                startTimeZonePicker.Dispose();
                startTimeZonePicker = null;
            }

            if (startDateName != null)
            {
                startDateName.Click -= StartDateName_Click;
                startDateName.Dispose();
                startDateName = null;
            }

            if (startTimeName != null)
            {
                startTimeName.Click -= StartTimeName_Click;
                startTimeName.Dispose();
                startTimeName = null;
            }

            if (endDateName != null)
            {
                endDateName.Click -= EndDateName_Click;
                endDateName.Dispose();
                endDateName = null;
            }

            if (endTimeName != null)
            {
                endTimeName.Click -= EndTimeName_Click;
                endTimeName.Dispose();
                endTimeName = null;
            }

            if (dateFormat != null)
            {
                dateFormat.Dispose();
                dateFormat = null;
            }

            if (timeFormat != null)
            {
                timeFormat.Dispose();
                timeFormat = null;
            }
        }
        #endregion
    }
}