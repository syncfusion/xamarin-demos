#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Appointment Editor Behavior class.
    /// </summary>
    internal class AppointmentEditorBehavior : Behavior<SampleView>
    {
        #region Fields

        /// <summary>
        /// schedule view list.
        /// </summary>
        private ListView scheduleViewList;

        /// <summary>
        /// header label.
        /// </summary>
        private Label header;

        /// <summary>
        /// schedule view button.
        /// </summary>
        private Button scheduleViewButton;

        /// <summary>
        /// Schedule header grid.
        /// </summary>
        private Grid scheduleHeaderGrid;

        /// <summary>
        /// editor button.
        /// </summary>
        private Button editorButton;

        /// <summary>
        /// editor layout.
        /// </summary>
        private EditorLayout editorLayout;

        /// <summary>
        /// time zone picker.
        /// </summary>
        private Picker timeZonePicker;

        /// <summary>
        /// appointment index.
        /// </summary>
        private int indexOfAppointment = 0;

        /// <summary>
        /// new appointment.
        /// </summary>
        private bool isNewAppointment = false;

        /// <summary>
        /// Gets or sets schedule.
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule
        {
            get;
            set;
        }

        #endregion

        #region OnAttached

        /// <summary>
        /// Begins when the behavior attached to the view. 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            this.scheduleHeaderGrid = ((bindable.Content as Grid).Children[0] as Grid);
            this.scheduleViewButton = ((bindable.Content as Grid).Children[0] as Grid).Children[0] as Button;
            this.header = ((bindable.Content as Grid).Children[0] as Grid).Children[1] as Label;
            this.editorButton = ((bindable.Content as Grid).Children[0] as Grid).Children[2] as Button;

            this.schedule = (bindable.Content as Grid).Children[1] as Syncfusion.SfSchedule.XForms.SfSchedule;
            this.scheduleViewList = (bindable.Content as Grid).Children[2] as ListView;
            this.editorLayout = (bindable.Content as Grid).Children[3] as EditorLayout;

            this.timeZonePicker = bindable.FindByName<Picker>("timeZonePicker");
            this.timeZonePicker.ItemsSource = TimeZoneCollection.TimeZoneList;
            this.timeZonePicker.SelectedIndex = 0;
            this.timeZonePicker.SelectedIndexChanged += this.TimeZonePicker_SelectedIndexChanged;

            this.schedule.VisibleDatesChangedEvent += this.Schedule_VisibleDatesChangedEvent;
            this.schedule.MonthInlineAppointmentTapped += this.Schedule_MonthInlineAppointmentTapped;
            this.schedule.CellDoubleTapped += this.Schedule_CellDoubleTapped;
            this.schedule.CellTapped += this.Schedule_CellTapped;
            if (Device.RuntimePlatform == Device.Android)
            {
                this.schedule.ViewHeaderStyle.DateFontSize = 24;
            }

            this.scheduleViewList.ItemSelected += this.ScheduleViewList_ItemSelected;

            this.scheduleViewButton.Clicked += this.ScheduleViewButton_Clicked;
            this.editorButton.Clicked += this.EditorButton_Clicked;

            (this.editorLayout.BindingContext as EditorLayoutViewModel).AppointmentModified += this.EditorLayout_AppointmentModified;
            (this.editorLayout.Behaviors[0] as EditorLayoutBehavior).AddEditorElements();

            if (Device.RuntimePlatform == "Android")
            {
                this.scheduleHeaderGrid.ColumnDefinitions[0].Width = new GridLength(0.1, GridUnitType.Star);
                this.header.FontSize = 20;
            }
        }
        #endregion

        #region OnDetachingFrom

        /// <summary>
        /// Begins when the behavior attached to the view
        /// </summary>
        /// <param name="bindable">bindable param</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            this.schedule.VisibleDatesChangedEvent -= this.Schedule_VisibleDatesChangedEvent;
            this.schedule.MonthInlineAppointmentTapped -= this.Schedule_MonthInlineAppointmentTapped;
            this.schedule.CellDoubleTapped -= this.Schedule_CellDoubleTapped;
            this.schedule.CellTapped -= this.Schedule_CellTapped;
            this.scheduleViewList.ItemSelected -= this.ScheduleViewList_ItemSelected;

            this.scheduleViewButton.Clicked -= this.ScheduleViewButton_Clicked;
            this.editorButton.Clicked -= this.EditorButton_Clicked;
            (this.editorLayout.BindingContext as EditorLayoutViewModel).AppointmentModified -= this.EditorLayout_AppointmentModified;

            this.scheduleHeaderGrid = null;
            this.scheduleViewButton = null;
            this.header = null;
            this.editorButton = null;
            this.schedule = null;
            this.scheduleViewList = null;
            this.editorLayout = null;
        }
        #endregion

        #region EditorLayout_AppointmentModified

        /// <summary>
        /// editor layout
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Schedule Appointment Modified Event args</param>
        private void EditorLayout_AppointmentModified(object sender, ScheduleAppointmentModifiedEventArgs e)
        {
            this.editorLayout.IsVisible = false;
            if (e.IsModified)
            {
                if (this.isNewAppointment)
                {
                    (this.schedule.DataSource as ObservableCollection<Meeting>).Add(e.Appointment);
                }
                else
                {
                    (this.schedule.DataSource as ObservableCollection<Meeting>).RemoveAt(this.indexOfAppointment);
                    (this.schedule.DataSource as ObservableCollection<Meeting>).Insert(this.indexOfAppointment, e.Appointment);
                }
            }
        }
        #endregion

        #region EditorButton_Clicked

        /// <summary>
        /// Method for editor button.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void EditorButton_Clicked(object sender, EventArgs e)
        {
            this.scheduleViewList.IsVisible = false;
            this.editorLayout.IsVisible = true;

            (this.editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor(null, DateTime.Today);
            this.isNewAppointment = true;
        }
        #endregion

        #region ScheduleViewButton_Clicked

        /// <summary>
        /// Method for schedule view visible.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void ScheduleViewButton_Clicked(object sender, EventArgs e)
        {
            if (this.scheduleViewList.IsVisible)
            {
                this.scheduleViewList.IsVisible = false;
            }
            else
            {
                this.scheduleViewList.IsVisible = true;
            }
        }

        #endregion

        #region TimeZone Picker_Selected

        /// <summary>
        /// Method for selecting time zone
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void TimeZonePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as Picker).SelectedItem as string == "Default")
            {
                this.schedule.TimeZone = string.Empty;
            }
            else
            {
                this.schedule.TimeZone = (sender as Picker).SelectedItem as string;
            }
        }

        #endregion

        #region ListItemSelected

        /// <summary>
        /// Method for selecting schedule view
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void ScheduleViewList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is ScheduleTypeClass)
            {
                if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Day view"))
                {
                    this.schedule.ScheduleView = ScheduleView.DayView;
                }
                else if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Week view"))
                {
                    this.schedule.ScheduleView = ScheduleView.WeekView;
                }
                else if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Work week view"))
                {
                    this.schedule.ScheduleView = ScheduleView.WorkWeekView;
                }
                else if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Month view"))
                {
                    this.schedule.ScheduleView = ScheduleView.MonthView;
                }
                else if((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Timeline view"))
                {
                    this.schedule.ScheduleView = ScheduleView.TimelineView;
                }

                this.schedule.SelectionStyle = new Syncfusion.SfSchedule.XForms.SelectionStyle();
            }

            (sender as ListView).IsVisible = false;
        }
        #endregion

        #region CellTapped

        /// <summary>
        /// Method for schedule cell tapped
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Cell Tapped Event Args</param>
        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            this.scheduleViewList.IsVisible = false;
        }
        #endregion

        #region CellDoubleTapped

        /// <summary>
        /// Method for cell double tapped
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="args">cell tapped event args</param>
        private void Schedule_CellDoubleTapped(object sender, Syncfusion.SfSchedule.XForms.CellTappedEventArgs args)
        {
            this.scheduleViewList.IsVisible = false;
            this.editorLayout.IsVisible = true;
            if (this.schedule.ScheduleView == ScheduleView.MonthView)
            {
                //create Apppointment
                (this.editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor(null, args.Datetime);
                this.isNewAppointment = true;
            }
            else
            {
                if (args.Appointment != null)
                {
                    ObservableCollection<Meeting> appointment = new ObservableCollection<Meeting>();
                    appointment = (ObservableCollection<Meeting>)this.schedule.DataSource;
                    this.indexOfAppointment = appointment.IndexOf((Meeting)args.Appointment);
                    (this.editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor((Meeting)args.Appointment, args.Datetime);
                    this.isNewAppointment = false;
                }
                else
                {
                    //create Apppointment
                    (this.editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor(null, args.Datetime);
                    this.isNewAppointment = true;
                }
            }
        }
        #endregion

        #region MonthInlineAppointmentTapped

        /// <summary>
        /// Method for schedule inline tapped.
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Month Inline Appointment Tapped Event Args</param>
        private void Schedule_MonthInlineAppointmentTapped(object sender, Syncfusion.SfSchedule.XForms.MonthInlineAppointmentTappedEventArgs e)
        {
            if (e.Appointment != null)
            {
                this.editorLayout.IsVisible = true;
                ObservableCollection<Meeting> appointment = new ObservableCollection<Meeting>();
                appointment = (ObservableCollection<Meeting>)this.schedule.DataSource;
                this.indexOfAppointment = appointment.IndexOf((Meeting)e.Appointment);
                (this.editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor((Meeting)e.Appointment, e.selectedDate);
                this.isNewAppointment = false;
            }
        }
        #endregion

        #region VisibleDateChanged Event

        /// <summary>
        /// Method for visible dates changed.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">visible dates args</param>
        private void Schedule_VisibleDatesChangedEvent(object sender, Syncfusion.SfSchedule.XForms.VisibleDatesChangedEventArgs args)
        {
            this.scheduleViewList.IsVisible = false;
          
            if (this.schedule.ScheduleView == Syncfusion.SfSchedule.XForms.ScheduleView.DayView)
            {
                if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Phone)
                {
                    this.header.Text = args.visibleDates[0].Date.ToString("dd MMMM yyyy");
                }
                else
                {
                    this.header.Text = args.visibleDates[0].Date.ToString("MMMM yyyy");
                }
            }
            else
            {
                this.header.Text = args.visibleDates[args.visibleDates.Count / 2].Date.ToString("MMMM yyyy");
            }
        }

        #endregion
    }
}
