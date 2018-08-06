#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using System.Collections;

namespace SampleBrowser.SfSchedule
{
    internal class AppointmentEditorBehavior : Behavior<SampleView>
    {
        #region Fields

        private Syncfusion.SfSchedule.XForms.SfSchedule schedule { get; set; }
        private ListView scheduleViewList;
        private Label header;
        private Button scheduleViewButton;
        private Button editorButton;
        private EditorLayout editorLayout;
        private Picker timeZonePicker;
        private int indexOfAppointment = 0;
        private bool isNewAppointment = false;

        #endregion

        #region OnAttached
        protected override void OnAttachedTo(SampleView bindable)
        {
            scheduleViewButton = ((bindable.Content as Grid).Children[0] as Grid).Children[0] as Button;
            header = ((bindable.Content as Grid).Children[0] as Grid).Children[1] as Label;
            editorButton = ((bindable.Content as Grid).Children[0] as Grid).Children[2] as Button;

            schedule = ((bindable.Content as Grid).Children[1] as Syncfusion.SfSchedule.XForms.SfSchedule);
            scheduleViewList = ((bindable.Content as Grid).Children[2] as ListView);
            editorLayout = ((bindable.Content as Grid).Children[3] as EditorLayout);

            timeZonePicker = bindable.PropertyView.FindByName<Picker>("timeZonePicker");
			timeZonePicker.ItemsSource = TimeZoneCollection.TimeZoneList;
            timeZonePicker.SelectedIndex = 0;
            timeZonePicker.SelectedIndexChanged += TimeZonePicker_SelectedIndexChanged;
          
            schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
            schedule.MonthInlineAppointmentTapped += Schedule_MonthInlineAppointmentTapped;
            schedule.CellDoubleTapped += Schedule_CellDoubleTapped;
            schedule.CellTapped += Schedule_CellTapped;
            scheduleViewList.ItemSelected += ScheduleViewList_ItemSelected;

            scheduleViewButton.Clicked += ScheduleViewButton_Clicked;
            editorButton.Clicked += EditorButton_Clicked;

            (editorLayout.BindingContext as EditorLayoutViewModel).AppointmentModified += EditorLayout_AppointmentModified;
            (editorLayout.Behaviors[0] as EditorLayoutBehavior).AddEditorElements();
        }
        #endregion

        #region EditorLayout_AppointmentModified
        private void EditorLayout_AppointmentModified(object sender, ScheduleAppointmentModifiedEventArgs e)
        {
            editorLayout.IsVisible = false;
            if (e.IsModified)
            {
                if (isNewAppointment)
                {
                    (schedule.DataSource as ObservableCollection<Meeting>).Add(e.Appointment);
                }
                else
                {
                    (schedule.DataSource as ObservableCollection<Meeting>).RemoveAt(indexOfAppointment);
                    (schedule.DataSource as ObservableCollection<Meeting>).Insert(indexOfAppointment, e.Appointment);
                }
            }
        }
        #endregion

        #region EditorButton_Clicked

        private void EditorButton_Clicked(object sender, EventArgs e)
        {
            scheduleViewList.IsVisible = false;
            editorLayout.IsVisible = true;

            (editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor(null, DateTime.Today);
            isNewAppointment = true;
        }
        #endregion

        #region ScheduleViewButton_Clicked
        private void ScheduleViewButton_Clicked(object sender, EventArgs e)
        {
            if(scheduleViewList.IsVisible)
            {
                scheduleViewList.IsVisible = false;
            }
            else
            {
                scheduleViewList.IsVisible = true;
            }
        }

        #endregion

        #region TimeZone Picker_Selected

        private void TimeZonePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as Picker).SelectedItem as string == "Default")
            {
                schedule.TimeZone = string.Empty;
            }
            else
            {
                schedule.TimeZone = (sender as Picker).SelectedItem as string;
            }
        }

        #endregion

        #region ListItemSelected
        private void ScheduleViewList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is ScheduleTypeClass)
            {
                if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Day view"))
                {
                    schedule.ScheduleView = ScheduleView.DayView;
                }
                else if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Week view"))
                {
                    schedule.ScheduleView = ScheduleView.WeekView;
                }
                else if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Work week view"))
                {
                    schedule.ScheduleView = ScheduleView.WorkWeekView;
                }
                else if ((e.SelectedItem as ScheduleTypeClass).ScheduleType.Equals("Month view"))
                {
                    schedule.ScheduleView = ScheduleView.MonthView;
                }

                schedule.SelectionStyle = new Syncfusion.SfSchedule.XForms.SelectionStyle();
            }
            (sender as ListView).IsVisible = false;
        }
        #endregion

        #region CellTapped
        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            scheduleViewList.IsVisible = false;
        }
        #endregion

        #region CellDoubleTapped

        private void Schedule_CellDoubleTapped(object sender, Syncfusion.SfSchedule.XForms.CellTappedEventArgs args)
        {
            scheduleViewList.IsVisible = false;
            editorLayout.IsVisible = true;
            if (schedule.ScheduleView == ScheduleView.MonthView)
            {
                //create Apppointment
                (editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor(null, args.Datetime);
                isNewAppointment = true;
            }
            else
            {
                if (args.Appointment != null)
                {
                    ObservableCollection<Meeting> appointment = new ObservableCollection<Meeting>();
                    appointment = (ObservableCollection<Meeting>)schedule.DataSource;
                    indexOfAppointment = appointment.IndexOf((Meeting)args.Appointment);
                    (editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor((Meeting)args.Appointment, args.Datetime);
                    isNewAppointment = false;
                }
                else
                {
                    //create Apppointment
                    (editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor(null, args.Datetime);
                    isNewAppointment = true;
                }
            }
        }
        #endregion

        #region MonthInlineAppointmentTapped
        private void Schedule_MonthInlineAppointmentTapped(object sender, Syncfusion.SfSchedule.XForms.MonthInlineAppointmentTappedEventArgs e)
        {
            if (e.Appointment != null)
            {
				editorLayout.IsVisible = true;
                ObservableCollection<Meeting> appointment = new ObservableCollection<Meeting>();
                appointment = (ObservableCollection<Meeting>)schedule.DataSource;
                indexOfAppointment = appointment.IndexOf((Meeting)e.Appointment);
                (editorLayout.Behaviors[0] as EditorLayoutBehavior).OpenEditor((Meeting)e.Appointment, e.selectedDate);
                isNewAppointment = false;
            }
        }
        #endregion

        #region VisibleDateChanged Event

        private void Schedule_VisibleDatesChangedEvent(object sender, Syncfusion.SfSchedule.XForms.VisibleDatesChangedEventArgs args)
        {
            scheduleViewList.IsVisible = false;
          
            if (schedule.ScheduleView == Syncfusion.SfSchedule.XForms.ScheduleView.DayView)
            {
                if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Phone)
                    header.Text = args.visibleDates[0].Date.ToString("dd MMMM yyyy");
                else
                    header.Text = args.visibleDates[0].Date.ToString("MMMM yyyy");
            }
            else
                header.Text = args.visibleDates[args.visibleDates.Count / 2].Date.ToString("MMMM yyyy");

        }

        #endregion
  
        #region OnDetachingFrom
        protected override void OnDetachingFrom(SampleView bindable)
        {
            schedule.VisibleDatesChangedEvent -= Schedule_VisibleDatesChangedEvent;
            schedule.MonthInlineAppointmentTapped -= Schedule_MonthInlineAppointmentTapped;
            schedule.CellDoubleTapped -= Schedule_CellDoubleTapped;
            schedule.CellTapped -= Schedule_CellTapped;
            scheduleViewList.ItemSelected -= ScheduleViewList_ItemSelected;

            scheduleViewButton.Clicked -= ScheduleViewButton_Clicked;
            editorButton.Clicked -= EditorButton_Clicked;
            (editorLayout.BindingContext as EditorLayoutViewModel).AppointmentModified -= EditorLayout_AppointmentModified;
            
            scheduleViewButton = null;
            header = null;
            editorButton = null;
            schedule = null;
            scheduleViewList = null;
            editorLayout = null;
        }
        #endregion
    }
}
