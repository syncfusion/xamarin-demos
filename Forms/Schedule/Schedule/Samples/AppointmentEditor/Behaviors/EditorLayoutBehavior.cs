#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Editor Layout Behavior class.
    /// </summary>
    internal class EditorLayoutBehavior : Behavior<StackLayout>
    {
        #region Fields

        /// <summary>
        /// editor scroll view.
        /// </summary>
        private ScrollView editorScrollView;

        /// <summary>
        /// save button.
        /// </summary>
        private Button saveButton;

        /// <summary>
        /// cancel button.
        /// </summary>
        private Button cancelButton;

        /// <summary>
        /// Save button grid.
        /// </summary>
        private Grid saveButtonGrid;

        /// <summary>
        /// cancel button grid.
        /// </summary>
        private Grid cancelButtonGrid;

        /// <summary>
        /// end date picker.
        /// </summary>
        private DatePicker endDatePicker;

        /// <summary>
        /// end time picker.
        /// </summary>
        private TimePicker endTimePicker;

        /// <summary>
        /// selected appointment.
        /// </summary>
        private Meeting selectedAppointment;

        /// <summary>
        /// selected date.
        /// </summary>
        private DateTime selectedDate;

        /// <summary>
        /// start date picker.
        /// </summary>
        private DatePicker startDatePicker;

        /// <summary>
        /// start time picker.
        /// </summary>
        private TimePicker startTimePicker;

        /// <summary>
        /// editor layout.
        /// </summary>
        private StackLayout editorLayout;

        /// <summary>
        /// Allday grid.
        /// </summary>
        private Grid allDayGrid;

        /// <summary>
        /// Allday label.
        /// </summary>
        private Label allDayLabel;

        /// <summary>
        /// all day switch.
        /// </summary>
        private Switch switchAllDay;

        /// <summary>
        /// event name text.
        /// </summary>
        private Entry eventNameText;

        /// <summary>
        /// organizer text.
        /// </summary>
        private Entry organizerText;

        /// <summary>
        /// editor buttons.
        /// </summary>
        private Grid editorButtonsGrid;

        /// <summary>
        /// end time label layout
        /// </summary>
        private Grid endTimeLabelLayout;

        /// <summary>
        /// start date time picker layout.
        /// </summary>
        private Grid startDateTimePickerLayout;

        /// <summary>
        /// start date picker layout
        /// </summary>
        private Grid startDatePickerLayout;

        /// <summary>
        /// start time picker layout.
        /// </summary>
        private Grid startTimePickerLayout;

        /// <summary>
        /// end date time picker layout.
        /// </summary>
        private Grid endDateTimePickerLayout;

        /// <summary>
        /// end date picker layout.
        /// </summary>
        private Grid endDatePickerLayout;

        /// <summary>
        /// end time picker layout.
        /// </summary>
        private Grid endTimePickerLayout;

        /// <summary>
        /// start time label layout.
        /// </summary>
        private Grid startTimeLabelLayout;

        /// <summary>
        /// organizer layout.
        /// </summary>
        private Grid organizerLayout;

        /// <summary>
        /// start time zone picker.
        /// </summary>
        private Picker startTimeZonePicker;

        /// <summary>
        /// end time zone picker
        /// </summary>
        private Picker endTimeZonePicker;

        /// <summary>
        /// start time zone
        /// </summary>
        private string startTimeZone;

        /// <summary>
        /// end time zone
        /// </summary>
        private string endTimeZone;

        #endregion

        #region OpenEditor

        /// <summary>
        /// Method for editor open
        /// </summary>
        /// <param name="appointment">appointment value</param>
        /// <param name="date">date value</param>
        public void OpenEditor(Meeting appointment, DateTime date)
        {
            this.editorScrollView.ScrollToAsync(0, 0, false);
            this.cancelButton.BackgroundColor = Color.FromHex("#E5E5E5");
            this.saveButton.BackgroundColor = Color.FromHex("#2196F3");
            this.eventNameText.Placeholder = "Event name";
            this.organizerText.Placeholder = "Organizer";
            this.selectedAppointment = null;
            if (appointment != null)
            {
                this.selectedAppointment = appointment;
                this.selectedDate = date;
            }
            else
            {
                this.selectedDate = date;
            }

            this.UpdateEditor();
        }

        #endregion

        #region UpdateElements

        /// <summary>
        /// Method for editor elements
        /// </summary>
        internal void AddEditorElements()
        {
            if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Phone)
            {
                this.organizerLayout.IsVisible = false;

                this.startDateTimePickerLayout.Padding = new Thickness(20, 0, 20, 0);
                this.startDateTimePickerLayout.ColumnDefinitions.Clear();
                this.startDateTimePickerLayout.RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                };
                Grid.SetRow(this.startDatePickerLayout, 0);
                Grid.SetColumnSpan(this.startDatePickerLayout, 3);
                Grid.SetColumn(this.startTimePickerLayout, 0);
                Grid.SetColumnSpan(this.startTimePickerLayout, 3);
                Grid.SetRow(this.startTimePickerLayout, 1);
                this.startDatePickerLayout.HeightRequest = 40;
                this.startTimePickerLayout.HeightRequest = 40;
                this.startTimeLabelLayout.Padding = new Thickness(20, 5, 0, 0);
                this.startDateTimePickerLayout.Padding = new Thickness(20, 0, 20, 0);

                this.endDateTimePickerLayout.ColumnDefinitions.Clear();
                this.endDateTimePickerLayout.Padding = new Thickness(20, 0, 20, 0);
                this.endDateTimePickerLayout.RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                };
                Grid.SetRow(this.endDatePickerLayout, 0);
                Grid.SetRow(this.endTimePickerLayout, 1);
                Grid.SetColumnSpan(this.endDatePickerLayout, 3);
                Grid.SetColumn(this.endTimePickerLayout, 0);
                Grid.SetColumnSpan(this.endTimePickerLayout, 3);
                this.endDatePickerLayout.HeightRequest = 40;
                this.endTimePickerLayout.HeightRequest = 40;
                this.endTimeLabelLayout.Padding = new Thickness(20, 5, 0, 0);
            }
            else if (Device.RuntimePlatform == "Android")
            {
                this.editorLayout.Padding = 20;
            }
        }

        #endregion

        #region Get TimeZone Index from TimeZoneCollection

        #region OnAttached

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(StackLayout bindable)
        {
            this.editorLayout = bindable;

            this.editorScrollView = bindable.FindByName<ScrollView>("editorScrollView");
            this.eventNameText = bindable.FindByName<Entry>("eventNameText");
            this.organizerText = bindable.FindByName<Entry>("organizerText");

            this.cancelButtonGrid = bindable.FindByName<Grid>("cancelButtonGrid");
            this.saveButtonGrid = bindable.FindByName<Grid>("saveButtonGrid");

            this.cancelButton = bindable.FindByName<Button>("cancelButton");
            this.saveButton = bindable.FindByName<Button>("saveButton");

            this.editorButtonsGrid = bindable.FindByName<Grid>("editorButtons");

            this.endDatePicker = bindable.FindByName<DatePicker>("endDate_picker");
            this.endTimePicker = bindable.FindByName<TimePicker>("endTime_picker");

            this.startDatePicker = bindable.FindByName<DatePicker>("startDate_picker");
            this.startTimePicker = bindable.FindByName<TimePicker>("startTime_picker");

            this.allDayGrid = bindable.FindByName<Grid>("allDayGrid");
            this.allDayLabel = bindable.FindByName<Label>("allDayLabel");
            this.switchAllDay = bindable.FindByName<Switch>("switchAllDay");

            this.startTimeZonePicker = bindable.FindByName<Picker>("startTimeZonePicker");
            this.startTimeZonePicker.SelectedIndex = 0;
            this.startTimeZonePicker.ItemsSource = TimeZoneCollection.TimeZoneList;
            this.startTimeZonePicker.SelectedIndexChanged += this.StartTimeZonePicker_SelectedIndexChanged;

            this.endTimeZonePicker = bindable.FindByName<Picker>("endTimeZonePicker");
            this.endTimeZonePicker.SelectedIndex = 0;
            this.endTimeZonePicker.ItemsSource = TimeZoneCollection.TimeZoneList;
            this.endTimeZonePicker.SelectedIndexChanged += this.EndTimeZonePicker_SelectedIndexChanged;

            this.endTimeLabelLayout = bindable.FindByName<Grid>("endTimeLabel_layout");
            this.startDateTimePickerLayout = bindable.FindByName<Grid>("StartdateTimePicker_layout");
            this.startDatePickerLayout = bindable.FindByName<Grid>("start_datepicker_layout");
            this.organizerLayout = bindable.FindByName<Grid>("organizer_layout");

            this.startTimePickerLayout = bindable.FindByName<Grid>("start_timepicker_layout");
            this.startTimeLabelLayout = bindable.FindByName<Grid>("startTimeLabel_layout");
            this.endDateTimePickerLayout = bindable.FindByName<Grid>("EndDateTimePicker_layout");

            this.endDatePickerLayout = bindable.FindByName<Grid>("end_datepicker_layout");
            this.endDateTimePickerLayout = bindable.FindByName<Grid>("EndDateTimePicker_layout");
            this.endTimePickerLayout = bindable.FindByName<Grid>("end_timepicker_layout");

            //// Editor Layout Date and time Picker Alignment for UWP
            if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Desktop)
            {
                this.startDatePicker.HorizontalOptions = LayoutOptions.StartAndExpand;
                this.startTimePicker.HorizontalOptions = LayoutOptions.StartAndExpand;

                this.endDatePicker.HorizontalOptions = LayoutOptions.StartAndExpand;
                this.endTimePicker.HorizontalOptions = LayoutOptions.StartAndExpand;

                this.startDatePicker.WidthRequest = 450;
                this.startTimePicker.WidthRequest = 450;

                this.endDatePicker.WidthRequest = 450;
                this.endTimePicker.WidthRequest = 450;
            }

            if (Device.RuntimePlatform == "WPF")
            {
                editorLayout.BackgroundColor = Color.FromHex("#80000000");
                editorLayout.Spacing = 0;

                editorScrollView.BackgroundColor = Color.White;
                editorScrollView.WidthRequest = 450;
                editorScrollView.HorizontalOptions = LayoutOptions.Center;
                editorScrollView.VerticalOptions = LayoutOptions.FillAndExpand;
                editorScrollView.Padding = new Thickness(20, 20, 20, 0);

                editorButtonsGrid.BackgroundColor = Color.White;
                editorButtonsGrid.WidthRequest = 450;
                editorButtonsGrid.HeightRequest = 70;
                editorButtonsGrid.HorizontalOptions = LayoutOptions.Center;
                editorButtonsGrid.Padding = new Thickness(20, 0, 20, 20);

                cancelButtonGrid.Padding = new Thickness(20, 20, 10, 10);
                saveButtonGrid.Padding = new Thickness(10, 20, 20, 10);

                allDayLabel.VerticalOptions = LayoutOptions.Center;
            }
            else
            {
                allDayGrid.HeightRequest = 40;

                allDayLabel.HeightRequest = 40;

                editorButtonsGrid.HeightRequest = 50;
                editorButtonsGrid.Padding = new Thickness(20, 0, 20, -10);

                saveButtonGrid.Padding = new Thickness(0, 0, 0, 0);
                cancelButtonGrid.Padding = new Thickness(0, 0, 0, 0);
            }

            this.saveButton.Clicked += this.SaveButton_Clicked;
            this.cancelButton.Clicked += this.CancelButton_Clicked;
            this.switchAllDay.Toggled += this.SwitchAllDay_Toggled;
        }

        #endregion

        #region OnDetachingFrom

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(StackLayout bindable)
        {
            this.saveButton.Clicked -= this.SaveButton_Clicked;
            this.cancelButton.Clicked -= this.CancelButton_Clicked;
            this.switchAllDay.Toggled -= this.SwitchAllDay_Toggled;

            this.startTimeZonePicker.SelectedIndexChanged -= this.StartTimeZonePicker_SelectedIndexChanged;
            this.endTimeZonePicker.SelectedIndexChanged -= this.EndTimeZonePicker_SelectedIndexChanged;

            this.organizerLayout = null;
            this.editorLayout = null;
            this.eventNameText = null;
            this.organizerText = null;
            this.cancelButton = null;
            this.saveButton = null;
            this.saveButtonGrid = null;
            this.cancelButtonGrid = null;
            this.editorButtonsGrid = null;
            this.endDatePicker = null;
            this.endTimePicker = null;
            this.startDatePicker = null;
            this.startTimePicker = null;
            this.allDayGrid = null;
            this.allDayLabel = null;
            this.switchAllDay = null;

            this.endTimeLabelLayout = null;
            this.startDateTimePickerLayout = null;
            this.startDatePickerLayout = null;

            this.startTimePickerLayout = null;
            this.startTimeLabelLayout = null;
            this.endDateTimePickerLayout = null;

            this.endDatePickerLayout = null;
            this.endDateTimePickerLayout = null;
            this.endTimePickerLayout = null;
        }
        #endregion

        /// <summary>
        /// Method for time zone.
        /// </summary>
        /// <param name="timeZone">time zone</param>
        /// <returns>return the time zone</returns>
        private int GetTimeZoneIndex(string timeZone)
        {
            for (int i = 0; i < TimeZoneCollection.TimeZoneList.Count; i++)
            {
                if (timeZone.Equals(TimeZoneCollection.TimeZoneList[i]))
                {
                    return i;
                }
            }

            return 0;
        }

        #endregion

        #region Start TimeZone Picker_Selected

        /// <summary>
        /// method for selecting start time zone
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e"> Event Args</param>
        private void StartTimeZonePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as Picker).SelectedItem as string == "Default")
            {
                this.startTimeZone = string.Empty;
            }
            else
            {
                this.startTimeZone = (sender as Picker).SelectedItem as string;
            }
        }

        #endregion

        #region End TimeZone Picker_Selected

        /// <summary>
        /// Method for selecting end time zone.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void EndTimeZonePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as Picker).SelectedItem as string == "Default")
            {
                this.endTimeZone = string.Empty;
            }
            else
            {
                this.endTimeZone = (sender as Picker).SelectedItem as string;
            }
        }

        #endregion

        /// <summary>
        /// Method for all day switch toggled.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        #region SwitchAllDay_Toggled
        private void SwitchAllDay_Toggled(object sender, ToggledEventArgs e)
        {
            if ((sender as Switch).IsToggled)
            {
                this.startTimePicker.Time = new TimeSpan(12, 0, 0);
                this.startTimePicker.IsEnabled = false;
                this.endTimePicker.Time = new TimeSpan(12, 0, 0);
                this.endTimePicker.IsEnabled = false;
                this.startTimeZonePicker.IsEnabled = false;
                this.endTimeZonePicker.IsEnabled = false;
            }
            else
            {
                this.startTimePicker.IsEnabled = true;
                this.endTimePicker.IsEnabled = true;
                (sender as Switch).IsToggled = false;
                this.startTimeZonePicker.IsEnabled = true;
                this.endTimeZonePicker.IsEnabled = true;
            }
        }
        #endregion

        #region CancelButton_Clicked

        /// <summary>
        /// Method for cancel.
        /// </summary>
        /// <param name="sender">Return the object</param>
        /// <param name="e">Event Args</param>
        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            ScheduleAppointmentModifiedEventArgs args = new ScheduleAppointmentModifiedEventArgs();
            args.Appointment = null;
            args.IsModified = false;
            (this.editorLayout.BindingContext as EditorLayoutViewModel).OnAppointmentModified(args);
            this.editorLayout.IsVisible = false;
        }
        #endregion

        #region SaveButton_Clicked

        /// <summary>
        /// Method for save button.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var endDate = this.endDatePicker.Date;
            var startDate = this.startDatePicker.Date;
            var endTime = this.endTimePicker.Time;
            var startTime = this.startTimePicker.Time;

            if (endDate < startDate)
            {
                Application.Current.MainPage.DisplayAlert(" ", "End time should be greater than start time", "OK");
            }
            else if (endDate == startDate)
            {
                if (endTime < startTime)
                {
                    Application.Current.MainPage.DisplayAlert(" ", "End time should be greater than start time", "OK");
                }
                else
                {
                    this.AppointmentDetails();
                    this.editorLayout.IsVisible = false;
                }
            }
            else
            {
                this.AppointmentDetails();
                this.editorLayout.IsVisible = false;
            }
        }
        #endregion

        #region AppointmentDetails

        /// <summary>
        /// Method for appointment details.
        /// </summary>
        private void AppointmentDetails()
        {
            if (this.selectedAppointment == null)
            {
                this.selectedAppointment = new Meeting();
                this.selectedAppointment.Color = Color.FromHex("#5EDAF2");
            }

            if (this.eventNameText.Text != null)
            {
                this.selectedAppointment.EventName = this.eventNameText.Text.ToString();
                if (string.IsNullOrEmpty(this.selectedAppointment.EventName))
                {
                    this.selectedAppointment.EventName = "Untitled";
                }
            }

            if (this.organizerText.Text != null)
            {
                this.selectedAppointment.Organizer = this.organizerText.Text.ToString();
            }

            this.selectedAppointment.From = this.startDatePicker.Date.Add(this.startTimePicker.Time);
            this.selectedAppointment.To = this.endDatePicker.Date.Add(this.endTimePicker.Time);
            this.selectedAppointment.IsAllDay = this.switchAllDay.IsToggled;
            this.selectedAppointment.StartTimeZone = this.startTimeZone;
            this.selectedAppointment.EndTimeZone = this.endTimeZone;

            ScheduleAppointmentModifiedEventArgs args = new ScheduleAppointmentModifiedEventArgs();
            args.Appointment = this.selectedAppointment;
            args.IsModified = true;
            (this.editorLayout.BindingContext as EditorLayoutViewModel).OnAppointmentModified(args);
        }

        #endregion

        #region UpdateEditor

        /// <summary>
        /// Method for update editor.
        /// </summary>
        private void UpdateEditor()
        {
            if (this.selectedAppointment != null)
            {
                this.eventNameText.Text = this.selectedAppointment.EventName.ToString();
                this.organizerText.Text = this.selectedAppointment.Organizer;
                this.startDatePicker.Date = this.selectedAppointment.From;
                this.endDatePicker.Date = this.selectedAppointment.To;
                this.startTimeZonePicker.SelectedIndex = this.GetTimeZoneIndex(this.selectedAppointment.StartTimeZone);
                this.endTimeZonePicker.SelectedIndex = this.GetTimeZoneIndex(this.selectedAppointment.EndTimeZone);

                if (!this.selectedAppointment.IsAllDay)
                {
                    this.startTimePicker.Time = new TimeSpan(this.selectedAppointment.From.Hour, this.selectedAppointment.From.Minute, this.selectedAppointment.From.Second);
                    this.endTimePicker.Time = new TimeSpan(this.selectedAppointment.To.Hour, this.selectedAppointment.To.Minute, this.selectedAppointment.To.Second);
                    this.switchAllDay.IsToggled = false;
                }
                else
                {
                    this.startTimePicker.Time = new TimeSpan(12, 0, 0);
                    this.startTimePicker.IsEnabled = false;
                    this.endTimePicker.Time = new TimeSpan(12, 0, 0);
                    this.endTimePicker.IsEnabled = false;
                    this.switchAllDay.IsToggled = true;
                }
            }
            else
            {
                this.eventNameText.Text = "";
                this.organizerText.Text = "";
                this.switchAllDay.IsToggled = false;
                this.startDatePicker.Date = this.selectedDate;
                this.startTimePicker.Time = new TimeSpan(this.selectedDate.Hour, this.selectedDate.Minute, this.selectedDate.Second);
                this.endDatePicker.Date = this.selectedDate;
                if (this.selectedDate.Hour == 23)
                {
                    this.endTimePicker.Time = new TimeSpan(this.selectedDate.Hour, this.selectedDate.Minute + 59, this.selectedDate.Second + 59);
                }
                else
                {
                    this.endTimePicker.Time = new TimeSpan(this.selectedDate.Hour + 1, this.selectedDate.Minute, this.selectedDate.Second);
                }

                this.startTimeZonePicker.SelectedIndex = 0;
                this.endTimeZonePicker.SelectedIndex = 0;
            }
        }

        #endregion
    }
}
