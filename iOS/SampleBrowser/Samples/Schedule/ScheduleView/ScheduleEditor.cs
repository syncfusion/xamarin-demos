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
        private SFSchedule schedule;
        private ScheduleViews scheduleViews;

        public ScheduleEditor(SFSchedule sfSchedule, ScheduleViews scheduleView)
        {
            this.schedule = sfSchedule;
            this.scheduleViews = scheduleView;
            Editor = new UIView();
            Editor.BackgroundColor = UIColor.White;
        }

        internal UIView Editor { get; set; }

        internal UIButton ButtonCancel { get; set; }
        
        internal UIButton ButtonSave { get; set; }

        internal UIButton DoneButton { get; set; }

        internal UIButton TimezoneButton { get; set; }

        internal UIButton DoneButton1 { get; set; }

        internal UIButton ButtonStartDate { get; set; }

        internal UIButton ButtonEndDate { get; set; }

        internal UIButton StartTimeZoneButton { get; set; }

        internal UIButton EndTimeZoneButton { get; set; }

        internal UITextView LabelSubject { get; set; }

        internal UITextView LabelLocation { get; set; }

        internal UILabel LabelStarts { get; set; }

        internal UILabel LabelEnds { get; set; }

        internal UILabel StartTimeZoneLabel { get; set; }

        internal UILabel EndTimeZoneLabel { get; set; }

        internal UILabel AllDaylabel { get; set; }

        internal UILabel TimezoneLabel { get; set; }

        internal UISwitch AllDaySwitch { get; set; }

        internal UIPickerView StartTimeZonePicker { get; set; }

        internal UIPickerView EndTimeZonePicker { get; set; }

        internal UIPickerView TimeZonePicker { get; set; }

        internal UIDatePicker PickerStartDate { get; set; }

        internal UIDatePicker PickerEndDate { get; set; }

        internal UIScrollView ScrollView { get; set; }

        internal void CreateOptionWindow()
        {
            if (TimezoneButton == null)
            {
                TimezoneButton = new UIButton();
                TimezoneButton.Layer.BorderWidth = 2;
                TimezoneButton.Layer.CornerRadius = 4;
                TimezoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
                TimezoneButton.SetTitle("Default", UIControlState.Normal);
                TimezoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            }

            if (TimezoneLabel == null)
            {
                TimezoneLabel = new UILabel();
                TimezoneLabel.Text = "Time Zone";
                TimezoneLabel.TextColor = UIColor.Black;
            }

            if (TimeZonePicker == null)
            {
                TimeZonePicker = new UIPickerView();
                TimeZonePicker.Hidden = true;
            }

            if (DoneButton1 == null)
            {
                DoneButton1 = new UIButton();
                DoneButton1.Hidden = true;
                DoneButton1.SetTitleColor(UIColor.Black, UIControlState.Normal);
                DoneButton1.SetTitle("Done\t", UIControlState.Normal);
                DoneButton1.BackgroundColor = UIColor.LightGray;
                DoneButton1.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            }

            TimezoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                TimeZonePicker.Hidden = false;
                DoneButton1.Hidden = false;
            };
            DoneButton1.TouchUpInside += (object sender, EventArgs e) =>
            {
                TimeZonePicker.Hidden = true;
                DoneButton1.Hidden = true;
            };

            SchedulePickerModel model = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
            model.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue != "Default")
                {
                    schedule.TimeZone = e.SelectedValue;
                }

                TimezoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
            };

            TimeZonePicker.Model = model;
            TimeZonePicker.ShowSelectionIndicator = true;

            if (Utility.IsIPad)
            {
                TimezoneLabel.Frame = new CGRect(0, 0, 320, 30);
                TimezoneButton.Frame = new CGRect(0, TimezoneLabel.Frame.Bottom, 320, 30);
                DoneButton1.Frame = new CGRect(0, TimezoneButton.Frame.Bottom, 320, 30);
                TimeZonePicker.Frame = new CGRect(0, DoneButton1.Frame.Bottom, 320, 200);
            }
        }

        internal void CreateEditor()
        {
            ButtonCancel = new UIButton();
            ButtonSave = new UIButton();
            LabelSubject = new UITextView();
            LabelLocation = new UITextView();
            LabelEnds = new UILabel();
            LabelStarts = new UILabel();
            ButtonStartDate = new UIButton();
            ButtonEndDate = new UIButton();
            StartTimeZoneLabel = new UILabel();
            EndTimeZoneLabel = new UILabel();
            StartTimeZoneButton = new UIButton();
            EndTimeZoneButton = new UIButton();
            PickerStartDate = new UIDatePicker();
            PickerEndDate = new UIDatePicker();
            DoneButton = new UIButton();
            ScrollView = new UIScrollView();
            StartTimeZonePicker = new UIPickerView();
            EndTimeZonePicker = new UIPickerView();
            AllDaySwitch = new UISwitch();
            AllDaylabel = new UILabel();

            ScrollView.BackgroundColor = UIColor.White;

            LabelSubject.Font = UIFont.SystemFontOfSize(14);
            LabelLocation.Font = UIFont.SystemFontOfSize(14);
            LabelStarts.Font = UIFont.SystemFontOfSize(15);
            LabelEnds.Font = UIFont.SystemFontOfSize(15);
            StartTimeZoneLabel.Font = UIFont.SystemFontOfSize(15);
            EndTimeZoneLabel.Font = UIFont.SystemFontOfSize(15);
            AllDaylabel.Font = UIFont.SystemFontOfSize(15);
            StartTimeZoneButton.Font = UIFont.SystemFontOfSize(15);
            EndTimeZoneButton.Font = UIFont.SystemFontOfSize(15);
            ButtonStartDate.Font = UIFont.SystemFontOfSize(15);
            ButtonEndDate.Font = UIFont.SystemFontOfSize(15);

            ButtonCancel.BackgroundColor = UIColor.FromRGB(229, 229, 229);
            ButtonCancel.Font = UIFont.SystemFontOfSize(15);
            ButtonSave.Font = UIFont.SystemFontOfSize(15);
            ButtonSave.BackgroundColor = UIColor.FromRGB(33, 150, 243);
            ButtonCancel.Layer.CornerRadius = 6;
            ButtonSave.Layer.CornerRadius = 6;
            ButtonStartDate.Layer.CornerRadius = 6;
            ButtonEndDate.Layer.CornerRadius = 6;

            StartTimeZoneLabel.Text = "Start Time Zone";
            StartTimeZoneLabel.TextColor = UIColor.Black;

            EndTimeZoneLabel.Text = "End Time Zone";
            EndTimeZoneLabel.TextColor = UIColor.Black;

            AllDaylabel.Text = "All Day";
            AllDaylabel.TextColor = UIColor.Black;

            AllDaySwitch.On = false;
            AllDaySwitch.OnTintColor = UIColor.FromRGB(33, 150, 243);
            AllDaySwitch.ValueChanged += AllDaySwitch_ValueChanged;

            StartTimeZoneButton.SetTitle("Default", UIControlState.Normal);
            StartTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            StartTimeZoneButton.Layer.BorderWidth = 2;
            StartTimeZoneButton.Layer.CornerRadius = 4;
            StartTimeZoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            StartTimeZoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            StartTimeZoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                StartTimeZonePicker.Hidden = false;
                DoneButton.Hidden = false;

                AllDaylabel.Hidden = true;
                AllDaySwitch.Hidden = true;
                ButtonCancel.Hidden = true;
                ButtonSave.Hidden = true;
                EndTimeZoneLabel.Hidden = true;
                EndTimeZoneButton.Hidden = true;
                Editor.EndEditing(true);
            };

            EndTimeZoneButton.SetTitle("Default", UIControlState.Normal);
            EndTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            EndTimeZoneButton.Layer.BorderWidth = 2;
            EndTimeZoneButton.Layer.CornerRadius = 4;
            EndTimeZoneButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            EndTimeZoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            EndTimeZoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                EndTimeZonePicker.Hidden = false;
                DoneButton.Hidden = false;
                AllDaylabel.Hidden = true;
                AllDaySwitch.Hidden = true;
                ButtonCancel.Hidden = true;
                ButtonSave.Hidden = true;
                EndTimeZoneLabel.Hidden = true;
                EndTimeZoneButton.Hidden = true;
                Editor.EndEditing(true);
            };

            //cancel button
            ButtonCancel.SetTitle("Cancel", UIControlState.Normal);
            ButtonCancel.SetTitleColor(UIColor.FromRGB(59, 59, 59), UIControlState.Normal);
            ButtonCancel.TouchUpInside += (object sender, EventArgs e) =>
            {
                Editor.Hidden = true;
                schedule.Hidden = false;
                Editor.EndEditing(true);
                scheduleViews.HeaderView.Hidden = false;
            };

            //save button
            ButtonSave.SetTitle("Save", UIControlState.Normal);
            ButtonSave.SetTitleColor(UIColor.White, UIControlState.Normal);
            ButtonSave.TouchUpInside += (object sender, EventArgs e) =>
            {
                scheduleViews.HeaderView.Hidden = false;
                if (scheduleViews.IndexOfAppointment != -1)
                {
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.IndexOfAppointment.ToString())].Subject = (NSString)LabelSubject.Text;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.IndexOfAppointment.ToString())].Location = (NSString)LabelLocation.Text;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.IndexOfAppointment.ToString())].StartTime = PickerStartDate.Date;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.IndexOfAppointment.ToString())].EndTime = PickerEndDate.Date;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>)[int.Parse(scheduleViews.IndexOfAppointment.ToString())].IsAllDay = AllDaySwitch.On;
                }
                else
                {
                    ScheduleAppointment appointment = new ScheduleAppointment();
                    appointment.Subject = (NSString)LabelSubject.Text;
                    appointment.Location = (NSString)LabelLocation.Text;
                    appointment.StartTime = PickerStartDate.Date;
                    appointment.EndTime = PickerEndDate.Date;
                    appointment.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);
                    appointment.IsAllDay = AllDaySwitch.On;
                    (schedule.ItemsSource as ObservableCollection<ScheduleAppointment>).Add(appointment);
                }

                Editor.Hidden = true;
                schedule.Hidden = false;
                schedule.ReloadData();
                Editor.EndEditing(true);
            };

            //subject label
            LabelSubject.TextColor = UIColor.Black;
            LabelSubject.TextAlignment = UITextAlignment.Left;
            LabelSubject.Layer.CornerRadius = 8;
            LabelSubject.Layer.BorderWidth = 2;
            LabelSubject.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            //location label
            LabelLocation.TextColor = UIColor.Black;
            LabelLocation.TextAlignment = UITextAlignment.Left;
            LabelLocation.Layer.CornerRadius = 8;
            LabelLocation.Layer.BorderWidth = 2;
            LabelLocation.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            //starts time
            LabelStarts.Text = "Start Time";
            LabelStarts.TextColor = UIColor.Black;

            ButtonStartDate.SetTitle("Start time", UIControlState.Normal);
            ButtonStartDate.Layer.BorderWidth = 2;
            ButtonStartDate.Layer.CornerRadius = 4;
            ButtonStartDate.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            ButtonStartDate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            ButtonStartDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            ButtonStartDate.TouchUpInside += (object sender, EventArgs e) =>
            {
                PickerStartDate.Hidden = false;
                DoneButton.Hidden = false;

                AllDaylabel.Hidden = true;
                AllDaySwitch.Hidden = true;
                ButtonCancel.Hidden = true;
                ButtonSave.Hidden = true;
                EndTimeZoneLabel.Hidden = true;
                EndTimeZoneButton.Hidden = true;
                Editor.EndEditing(true);
            };

            //end time
            LabelEnds.Text = "End Time";
            LabelEnds.TextColor = UIColor.Black;

            //end date
            ButtonEndDate.SetTitle("End time", UIControlState.Normal);
            ButtonEndDate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            ButtonEndDate.Layer.BorderWidth = 2;
            ButtonEndDate.Layer.CornerRadius = 4;
            ButtonEndDate.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            ButtonEndDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            ButtonEndDate.TouchUpInside += (object sender, EventArgs e) =>
            {
                PickerEndDate.Hidden = false;
                DoneButton.Hidden = false;
                AllDaylabel.Hidden = true;
                AllDaySwitch.Hidden = true;
                ButtonCancel.Hidden = true;
                ButtonSave.Hidden = true;
                EndTimeZoneLabel.Hidden = true;
                EndTimeZoneButton.Hidden = true;

                Editor.EndEditing(true);
            };

            //date and time pickers
            PickerStartDate.Hidden = true;
            PickerEndDate.Hidden = true;
            StartTimeZonePicker.Hidden = true;
            EndTimeZonePicker.Hidden = true;
            DoneButton.Hidden = true;

            //done button
            DoneButton.SetTitle("Done", UIControlState.Normal);
            DoneButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            DoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            DoneButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                PickerStartDate.Hidden = true;
                PickerEndDate.Hidden = true;
                StartTimeZonePicker.Hidden = true;
                EndTimeZonePicker.Hidden = true;
                DoneButton.Hidden = true;

                LabelEnds.Hidden = false;
                ButtonEndDate.Hidden = false;
                ButtonStartDate.Hidden = false;
                LabelStarts.Hidden = false;
                EndTimeZoneLabel.Hidden = false;
                StartTimeZoneLabel.Hidden = false;
                AllDaylabel.Hidden = false;
                AllDaySwitch.Hidden = false;
                StartTimeZoneButton.Hidden = false;
                EndTimeZoneButton.Hidden = false;
                ButtonCancel.Hidden = false;
                ButtonSave.Hidden = false;

                String _sDate = DateTime.Parse(PickerStartDate.Date.ToString()).ToString();
                ButtonStartDate.SetTitle(_sDate, UIControlState.Normal);

                String _eDate = DateTime.Parse(PickerEndDate.Date.ToString()).ToString();
                ButtonEndDate.SetTitle(_eDate, UIControlState.Normal);
                Editor.EndEditing(true);
            };

            SchedulePickerModel model = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
            model.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue != "Default" && scheduleViews.SelectedAppointment != null)
                {
                    scheduleViews.SelectedAppointment.StartTimeZone = e.SelectedValue;
                }
               
                StartTimeZoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
            };

            SchedulePickerModel model2 = new SchedulePickerModel(TimeZoneCollection.TimeZoneList);
            model2.PickerChanged += (sender, e) =>
            {
                if (e.SelectedValue != "Default" && scheduleViews.SelectedAppointment != null)
                {
                    scheduleViews.SelectedAppointment.EndTimeZone = e.SelectedValue;
                }

                EndTimeZoneButton.SetTitle(e.SelectedValue, UIControlState.Normal);
            };

            StartTimeZonePicker.Model = model;
            EndTimeZonePicker.Model = model2;
            StartTimeZonePicker.ShowSelectionIndicator = true;
            EndTimeZonePicker.ShowSelectionIndicator = true;

            ScrollView.Add(LabelSubject);
            ScrollView.Add(LabelLocation);
            ScrollView.Add(LabelStarts);
            ScrollView.Add(ButtonStartDate);
            ScrollView.Add(StartTimeZoneLabel);
            ScrollView.Add(StartTimeZoneButton);
            ScrollView.Add(LabelEnds);
            ScrollView.Add(ButtonEndDate);
            ScrollView.Add(EndTimeZoneLabel);
            ScrollView.Add(EndTimeZoneButton);
            ScrollView.Add(StartTimeZonePicker);
            ScrollView.Add(EndTimeZonePicker);
            ScrollView.Add(PickerEndDate);
            ScrollView.Add(PickerStartDate);
            ScrollView.Add(DoneButton);
            ScrollView.Add(AllDaylabel);
            ScrollView.Add(AllDaySwitch);
            ScrollView.Add(ButtonCancel);
            ScrollView.Add(ButtonSave);

            Editor.Add(ScrollView);
        }

        internal void EditorFrameUpdate()
        {
            var childHeight = 30;
            if (Utility.IsIPad)
            {
                childHeight = 40;
            }

            var padding = 20;
            LabelSubject.Frame = new CGRect(ScrollView.Frame.X, ScrollView.Frame.Y, ScrollView.Frame.Size.Width - padding, childHeight);
            LabelLocation.Frame = new CGRect(ScrollView.Frame.X, LabelSubject.Frame.Bottom + 10, ScrollView.Frame.Size.Width - padding, childHeight);
            LabelStarts.Frame = new CGRect(ScrollView.Frame.X, LabelLocation.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            ButtonStartDate.Frame = new CGRect(ScrollView.Frame.X, LabelStarts.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            StartTimeZoneLabel.Frame = new CGRect(ScrollView.Frame.X, ButtonStartDate.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            StartTimeZoneButton.Frame = new CGRect(ScrollView.Frame.X, StartTimeZoneLabel.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            LabelEnds.Frame = new CGRect(ScrollView.Frame.X, StartTimeZoneButton.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            ButtonEndDate.Frame = new CGRect(ScrollView.Frame.X, LabelEnds.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            EndTimeZoneLabel.Frame = new CGRect(ScrollView.Frame.X, ButtonEndDate.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            EndTimeZoneButton.Frame = new CGRect(ScrollView.Frame.X, EndTimeZoneLabel.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            AllDaylabel.Frame = new CGRect(ScrollView.Frame.X, EndTimeZoneButton.Frame.Bottom + 10, (ScrollView.Frame.Size.Width / 2) - padding, childHeight);
            AllDaySwitch.Frame = new CGRect(AllDaylabel.Frame.Right, EndTimeZoneButton.Frame.Bottom + 10, (ScrollView.Frame.Size.Width / 2) - padding, childHeight);
            ButtonCancel.Frame = new CGRect(ScrollView.Frame.X, AllDaySwitch.Frame.Bottom + 10, (ScrollView.Frame.Size.Width / 2) - padding, childHeight);
            ButtonSave.Frame = new CGRect(ButtonCancel.Frame.Right + 10, AllDaySwitch.Frame.Bottom + 10, (ScrollView.Frame.Size.Width / 2) - padding, childHeight);

            PickerStartDate.Frame = new CGRect(ScrollView.Frame.X, ButtonEndDate.Frame.Bottom, ScrollView.Frame.Size.Width - padding, 200);
            PickerEndDate.Frame = new CGRect(ScrollView.Frame.X, ButtonEndDate.Frame.Bottom, ScrollView.Frame.Size.Width - padding, 200);
            StartTimeZonePicker.Frame = new CGRect(ScrollView.Frame.X, ButtonEndDate.Frame.Bottom, ScrollView.Frame.Size.Width - padding, 200);
            EndTimeZonePicker.Frame = new CGRect(ScrollView.Frame.X, ButtonEndDate.Frame.Bottom, ScrollView.Frame.Size.Width - padding, 200);
            DoneButton.Frame = new CGRect(ScrollView.Frame.X, ButtonEndDate.Frame.Bottom, ScrollView.Frame.Size.Width - padding, childHeight);
            ScrollView.ContentSize = new CGSize(ScrollView.Frame.Size.Width - padding, ButtonCancel.Frame.Bottom);
        }

        internal void Disablechild()
        {
            StartTimeZoneButton.UserInteractionEnabled = false;
            StartTimeZoneButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
            EndTimeZoneButton.UserInteractionEnabled = false;
            EndTimeZoneButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
        }

        internal void EnableChild()
        {
            StartTimeZoneButton.UserInteractionEnabled = true;
            StartTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            EndTimeZoneButton.UserInteractionEnabled = true;
            EndTimeZoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
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

            if (scheduleViews.SelectedAppointment != null)
            {
                scheduleViews.SelectedAppointment.IsAllDay = (sender as UISwitch).On;
            }
        }
    }
}