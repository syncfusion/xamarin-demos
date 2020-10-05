#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using CoreGraphics;
using Foundation;
using Syncfusion.SfSchedule.iOS;
using UIKit;

namespace SampleBrowser
{
    public class ScheduleEditor
    {
        internal UIView Editor;
        internal UIButton button_cancel, button_save, done_button, timezoneButton, doneButton, button_startDate, button_endDate, startTimeZoneButton, endTimeZoneButton;
        internal UITextView label_subject, label_location;
        internal UILabel label_starts, label_ends, startTimeZoneLabel, endTimeZoneLabel, allDaylabel, timezoneLabel;
        internal UISwitch allDaySwitch;
        internal UIPickerView startTimeZonePicker, endTimeZonePicker, timeZonePicker;
        internal UIDatePicker picker_startDate, picker_endDate;
        internal UIScrollView scrollView;

        private SFSchedule schedule;
        private ScheduleViews scheduleViews;

        public ScheduleEditor(SFSchedule sfSchedule, ScheduleViews scheduleView)
        {
            this.schedule = sfSchedule;
            this.scheduleViews = scheduleView;
            Editor = new UIView();
            Editor.BackgroundColor = UIColor.White;
        }

        internal void CreateOptionWindow()
        {
            if (timezoneButton == null)
            {
                timezoneButton = new UIButton();
                timezoneButton.Layer.BorderWidth = 2;
                timezoneButton.Layer.CornerRadius = 4;
                timezoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
                timezoneButton.SetTitle("Default", UIControlState.Normal);
                timezoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            }

            if (timezoneLabel == null)
            {
                timezoneLabel = new UILabel();
                timezoneLabel.Text = "Time Zone";
                timezoneLabel.TextColor = UIColor.Black;
            }

            if (timeZonePicker == null)
            {
                timeZonePicker = new UIPickerView();
                timeZonePicker.Hidden = true;
            }
            if (doneButton == null)
            {
                doneButton = new UIButton();
                doneButton.Hidden = true;
                doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
                doneButton.SetTitle("Done\t", UIControlState.Normal);
                doneButton.BackgroundColor = UIColor.LightGray;
                doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            }

            timezoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                timeZonePicker.Hidden = false;
                doneButton.Hidden = false;
            };
            doneButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                timeZonePicker.Hidden = true;
                doneButton.Hidden = true;
            };

            SchedulePickerModel model = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
            model.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue != "Default")
                {
                    schedule.TimeZone = e.SelectedValue;
                }
                timezoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
            };

            timeZonePicker.Model = model;
            timeZonePicker.ShowSelectionIndicator = true;

            if (Utility.IsIpad)
            {
                timezoneLabel.Frame = new CGRect(0, 0, 320, 30);
                timezoneButton.Frame = new CGRect(0, timezoneLabel.Frame.Bottom, 320, 30);
                doneButton.Frame = new CGRect(0, timezoneButton.Frame.Bottom, 320, 30);
                timeZonePicker.Frame = new CGRect(0, doneButton.Frame.Bottom, 320, 200);
            }
        }

        internal void CreateEditor()
        {
            button_cancel = new UIButton();
            button_save = new UIButton();
            label_subject = new UITextView();
            label_location = new UITextView();
            label_ends = new UILabel();
            label_starts = new UILabel();
            button_startDate = new UIButton();
            button_endDate = new UIButton();
            startTimeZoneLabel = new UILabel();
            endTimeZoneLabel = new UILabel();
            startTimeZoneButton = new UIButton();
            endTimeZoneButton = new UIButton();
            picker_startDate = new UIDatePicker();
            picker_endDate = new UIDatePicker();
            done_button = new UIButton();
            scrollView = new UIScrollView();
            startTimeZonePicker = new UIPickerView();
            endTimeZonePicker = new UIPickerView();
            allDaySwitch = new UISwitch();
            allDaylabel = new UILabel();

            scrollView.BackgroundColor = UIColor.White;

            label_subject.Font = UIFont.SystemFontOfSize(14);
            label_location.Font = UIFont.SystemFontOfSize(14);
            label_starts.Font = UIFont.SystemFontOfSize(15);
            label_ends.Font = UIFont.SystemFontOfSize(15);
            startTimeZoneLabel.Font = UIFont.SystemFontOfSize(15);
            endTimeZoneLabel.Font = UIFont.SystemFontOfSize(15);
            allDaylabel.Font = UIFont.SystemFontOfSize(15);
            startTimeZoneButton.Font = UIFont.SystemFontOfSize(15);
            endTimeZoneButton.Font = UIFont.SystemFontOfSize(15);
            button_startDate.Font = UIFont.SystemFontOfSize(15);
            button_endDate.Font = UIFont.SystemFontOfSize(15);

            button_cancel.BackgroundColor = UIColor.FromRGB(229, 229, 229);
            button_cancel.Font = UIFont.SystemFontOfSize(15);
            button_save.Font = UIFont.SystemFontOfSize(15);
            button_save.BackgroundColor = UIColor.FromRGB(33, 150, 243);
            button_cancel.Layer.CornerRadius = 6;
            button_save.Layer.CornerRadius = 6;
            button_startDate.Layer.CornerRadius = 6;
            button_endDate.Layer.CornerRadius = 6;


            startTimeZoneLabel.Text = "Start Time Zone";
            startTimeZoneLabel.TextColor = UIColor.Black;

            endTimeZoneLabel.Text = "End Time Zone";
            endTimeZoneLabel.TextColor = UIColor.Black;

            allDaylabel.Text = "All Day";
            allDaylabel.TextColor = UIColor.Black;

            allDaySwitch.On = false;
            allDaySwitch.OnTintColor = UIColor.FromRGB(33, 150, 243);
            allDaySwitch.ValueChanged += AllDaySwitch_ValueChanged;

            startTimeZoneButton.SetTitle("Default", UIControlState.Normal);
            startTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            startTimeZoneButton.Layer.BorderWidth = 2;
            startTimeZoneButton.Layer.CornerRadius = 4;
            startTimeZoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            startTimeZoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            startTimeZoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {

                startTimeZonePicker.Hidden = false;
                done_button.Hidden = false;

                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;
                Editor.EndEditing(true);

            };

            endTimeZoneButton.SetTitle("Default", UIControlState.Normal);
            endTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            endTimeZoneButton.Layer.BorderWidth = 2;
            endTimeZoneButton.Layer.CornerRadius = 4;
            endTimeZoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            endTimeZoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            endTimeZoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {

                endTimeZonePicker.Hidden = false;
                done_button.Hidden = false;
                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;
                Editor.EndEditing(true);
            };


            //cancel button
            button_cancel.SetTitle("Cancel", UIControlState.Normal);
            button_cancel.SetTitleColor(UIColor.FromRGB(59, 59, 59), UIControlState.Normal);// UIColor.FromRGB(59, 59, 59);
            button_cancel.TouchUpInside += (object sender, EventArgs e) =>
            {

                Editor.Hidden = true;
                schedule.Hidden = false;
                Editor.EndEditing(true);
                scheduleViews.headerView.Hidden = false;

            };

            //save button
            button_save.SetTitle("Save", UIControlState.Normal);
            button_save.SetTitleColor(UIColor.White, UIControlState.Normal);
            button_save.TouchUpInside += (object sender, EventArgs e) =>
            {
                scheduleViews.headerView.Hidden = false;
                if (scheduleViews.indexOfAppointment != -1)
                {
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.indexOfAppointment.ToString())].Subject = (NSString)label_subject.Text;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.indexOfAppointment.ToString())].Location = (NSString)label_location.Text;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.indexOfAppointment.ToString())].StartTime = picker_startDate.Date;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.indexOfAppointment.ToString())].EndTime = picker_endDate.Date;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.indexOfAppointment.ToString())].IsAllDay = allDaySwitch.On;
                }
                else
                {
                    ScheduleAppointment appointment = new ScheduleAppointment();
                    appointment.Subject = (NSString)label_subject.Text;
                    appointment.Location = (NSString)label_location.Text;
                    appointment.StartTime = picker_startDate.Date;
                    appointment.EndTime = picker_endDate.Date;
                    appointment.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);
                    appointment.IsAllDay = allDaySwitch.On;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>).Add(appointment);
                }
                Editor.Hidden = true;
                schedule.Hidden = false;
                schedule.ReloadData();
                Editor.EndEditing(true);
            };

            //subject label
            label_subject.TextColor = UIColor.Black;
            label_subject.TextAlignment = UITextAlignment.Left;
            label_subject.Layer.CornerRadius = 8;
            label_subject.Layer.BorderWidth = 2;
            label_subject.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;


            //location label
            label_location.TextColor = UIColor.Black;
            label_location.TextAlignment = UITextAlignment.Left;
            label_location.Layer.CornerRadius = 8;
            label_location.Layer.BorderWidth = 2;
            label_location.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            //starts time

            label_starts.Text = "Start Time";
            label_starts.TextColor = UIColor.Black;

            button_startDate.SetTitle("Start time", UIControlState.Normal);
            button_startDate.Layer.BorderWidth = 2;
            button_startDate.Layer.CornerRadius = 4;
            button_startDate.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            button_startDate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            button_startDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            button_startDate.TouchUpInside += (object sender, EventArgs e) =>
            {
                picker_startDate.Hidden = false;
                done_button.Hidden = false;

                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;
                Editor.EndEditing(true);
            };

            //end time

            label_ends.Text = "End Time";
            label_ends.TextColor = UIColor.Black;


            //end date
            button_endDate.SetTitle("End time", UIControlState.Normal);
            button_endDate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            button_endDate.Layer.BorderWidth = 2;
            button_endDate.Layer.CornerRadius = 4;
            button_endDate.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            button_endDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            button_endDate.TouchUpInside += (object sender, EventArgs e) =>
            {
                picker_endDate.Hidden = false;
                done_button.Hidden = false;
                allDaylabel.Hidden = true;
                allDaySwitch.Hidden = true;
                button_cancel.Hidden = true;
                button_save.Hidden = true;
                endTimeZoneLabel.Hidden = true;
                endTimeZoneButton.Hidden = true;

                Editor.EndEditing(true);
            };

            //date and time pickers
            picker_startDate.Hidden = true;
            picker_endDate.Hidden = true;
            startTimeZonePicker.Hidden = true;
            endTimeZonePicker.Hidden = true;
            done_button.Hidden = true;

            //done button
            done_button.SetTitle("Done", UIControlState.Normal);
            done_button.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            done_button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            done_button.TouchUpInside += (object sender, EventArgs e) =>
            {
                picker_startDate.Hidden = true;
                picker_endDate.Hidden = true;
                startTimeZonePicker.Hidden = true;
                endTimeZonePicker.Hidden = true;
                done_button.Hidden = true;

                label_ends.Hidden = false;
                button_endDate.Hidden = false;
                button_startDate.Hidden = false;
                label_starts.Hidden = false;
                endTimeZoneLabel.Hidden = false;
                startTimeZoneLabel.Hidden = false;
                allDaylabel.Hidden = false;
                allDaySwitch.Hidden = false;
                startTimeZoneButton.Hidden = false;
                endTimeZoneButton.Hidden = false;
                button_cancel.Hidden = false;
                button_save.Hidden = false;

                String _sDate = DateTime.Parse((picker_startDate.Date.ToString())).ToString();
                button_startDate.SetTitle(_sDate, UIControlState.Normal);

                String _eDate = DateTime.Parse((picker_endDate.Date.ToString())).ToString();
                button_endDate.SetTitle(_eDate, UIControlState.Normal);
                Editor.EndEditing(true);

            };

            SchedulePickerModel model = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
            model.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue != "Default" && scheduleViews.selectedAppointment != null)
                    scheduleViews.selectedAppointment.StartTimeZone = e.SelectedValue;
                startTimeZoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
            };

            SchedulePickerModel model2 = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
            model2.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue != "Default" && scheduleViews.selectedAppointment != null)
                    scheduleViews.selectedAppointment.EndTimeZone = e.SelectedValue;
                endTimeZoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
            };

            startTimeZonePicker.Model = model;
            endTimeZonePicker.Model = model2;
            startTimeZonePicker.ShowSelectionIndicator = true;
            endTimeZonePicker.ShowSelectionIndicator = true;

            scrollView.Add(label_subject);
            scrollView.Add(label_location);
            scrollView.Add(label_starts);
            scrollView.Add(button_startDate);
            scrollView.Add(startTimeZoneLabel);
            scrollView.Add(startTimeZoneButton);
            scrollView.Add(label_ends);
            scrollView.Add(button_endDate);
            scrollView.Add(endTimeZoneLabel);
            scrollView.Add(endTimeZoneButton);
            scrollView.Add(startTimeZonePicker);
            scrollView.Add(endTimeZonePicker);
            scrollView.Add(picker_endDate);
            scrollView.Add(picker_startDate);
            scrollView.Add(done_button);
            scrollView.Add(allDaylabel);
            scrollView.Add(allDaySwitch);
            scrollView.Add(button_cancel);
            scrollView.Add(button_save);

            Editor.Add(scrollView);
        }

        internal void EditorFrameUpdate()
        {
            var childHeight = 30;
            if (Utility.IsIpad)
            {
                childHeight = 40;
            }
            var padding = 20;
            label_subject.Frame = new CGRect(scrollView.Frame.X, scrollView.Frame.Y, scrollView.Frame.Size.Width - padding, childHeight);
            label_location.Frame = new CGRect(scrollView.Frame.X, label_subject.Frame.Bottom + 10, scrollView.Frame.Size.Width - padding, childHeight);
            label_starts.Frame = new CGRect(scrollView.Frame.X, label_location.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            button_startDate.Frame = new CGRect(scrollView.Frame.X, label_starts.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            startTimeZoneLabel.Frame = new CGRect(scrollView.Frame.X, button_startDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            startTimeZoneButton.Frame = new CGRect(scrollView.Frame.X, startTimeZoneLabel.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            label_ends.Frame = new CGRect(scrollView.Frame.X, startTimeZoneButton.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            button_endDate.Frame = new CGRect(scrollView.Frame.X, label_ends.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            endTimeZoneLabel.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            endTimeZoneButton.Frame = new CGRect(scrollView.Frame.X, endTimeZoneLabel.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            allDaylabel.Frame = new CGRect(scrollView.Frame.X, endTimeZoneButton.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);
            allDaySwitch.Frame = new CGRect(allDaylabel.Frame.Right, endTimeZoneButton.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);
            button_cancel.Frame = new CGRect(scrollView.Frame.X, allDaySwitch.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);
            button_save.Frame = new CGRect(button_cancel.Frame.Right + 10, allDaySwitch.Frame.Bottom + 10, scrollView.Frame.Size.Width / 2 - padding, childHeight);

            picker_startDate.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, 200);
            picker_endDate.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, 200);
            startTimeZonePicker.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, 200);
            endTimeZonePicker.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, 200);
            done_button.Frame = new CGRect(scrollView.Frame.X, button_endDate.Frame.Bottom, scrollView.Frame.Size.Width - padding, childHeight);
            scrollView.ContentSize = new CGSize(scrollView.Frame.Size.Width - padding, button_cancel.Frame.Bottom);
        }

        internal void Disablechild()
        {
            startTimeZoneButton.UserInteractionEnabled = false;
            startTimeZoneButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
            endTimeZoneButton.UserInteractionEnabled = false;
            endTimeZoneButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
        }

        internal void EnableChild()
        {
            startTimeZoneButton.UserInteractionEnabled = true;
            startTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            endTimeZoneButton.UserInteractionEnabled = true;
            endTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
        }

        private void AllDaySwitch_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as UISwitch).On)
            {
                this.Disablechild();
            }
            else
            {
                this.EnableChild();
            }

            if (scheduleViews.selectedAppointment != null)
            {
                scheduleViews.selectedAppointment.IsAllDay = (sender as UISwitch).On;
            }
        }
    }
}