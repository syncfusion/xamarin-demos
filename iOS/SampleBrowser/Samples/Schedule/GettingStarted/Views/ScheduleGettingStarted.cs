#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.iOS;
using Foundation;
using UIKit;
using CoreGraphics;
using SampleBrowser;

namespace SampleBrowser
{
    [Preserve(AllMembers = true)]
    public class ScheduleGettingStarted : SampleView
    {
        /// <summary>
        /// Variable for schedule
        /// </summary>
        private SFSchedule schedule;

        /// <summary>
        /// Collection of custom appointment
        /// </summary>
        private AppointmentCollection appointmentCollection;

        /// <summary>
        /// Collection of schedule views to show in picker
        /// </summary>
        private readonly IList<string> scheduleViews = new List<string>();

        /// <summary>
        /// Selected view variable to indicate the view selection in picker
        /// </summary>
        private string selectedView;

        /// <summary>
        /// Schedule view picker to show the option menu to choose schedule view
        /// </summary>
        private UIPickerView scheduleViewPicker = new UIPickerView();

        /// <summary>
        /// Label to display the title of option menu
        /// </summary>
        private UILabel label = new UILabel();

        /// <summary>
        /// Button to display the first option in picker
        /// </summary>
        private UIButton button = new UIButton();

        /// <summary>
        /// Text button to display the done and close the picker
        /// </summary>
        private UIButton textButton = new UIButton();

        /// <summary>
        /// Initialize a new instance of the class <see cref="ScheduleGettingStarted"/> class
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ScheduleGettingStarted()
        {
            schedule = new SFSchedule();
            label.Text = "Schedule View";
            label.TextColor = UIColor.Black;
            this.AddSubview(label);

            textButton.SetTitle("WeekView", UIControlState.Normal);
            textButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            textButton.BackgroundColor = UIColor.Clear;
            textButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            textButton.Hidden = false;
            textButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            textButton.Layer.BorderWidth = 4;
            textButton.Layer.CornerRadius = 8;
            textButton.TouchUpInside += ShowPicker;
            this.AddSubview(textButton);

            button.SetTitle("Done\t", UIControlState.Normal);
            button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            button.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            button.SetTitleColor(UIColor.Black, UIControlState.Normal);
            button.Hidden = true;
            button.TouchUpInside += HidePicker;

            appointmentCollection = new AppointmentCollection();
            schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
            schedule.MonthViewSettings.ShowAppointmentsInline = true;

            // Custom appointment mapping
            AppointmentMapping mapping = new AppointmentMapping();
            mapping.Subject = "EventName";
            mapping.StartTime = "From";
            mapping.EndTime = "To";
			mapping.AppointmentBackground = "Color";
            mapping.Location = "Organizer";
			mapping.IsAllDay = "IsAllDay";
            mapping.MinHeight = "MinimumHeight";
            schedule.AppointmentMapping = mapping;

            schedule.ItemsSource = appointmentCollection.GetAppointments();

            this.AddSubview(schedule);

            this.scheduleViews.Add((NSString)"Week View");
            this.scheduleViews.Add((NSString)"Day View");
            this.scheduleViews.Add((NSString)"Work Week View");
            this.scheduleViews.Add((NSString)"Month View");

            SchedulePickerModel model = new SchedulePickerModel(this.scheduleViews);

            // Event occurs when the item picked in the picker
            model.PickerChanged += (sender, e) =>
            {
                this.selectedView = e.SelectedValue;
                textButton.SetTitle(selectedView, UIControlState.Normal);
                if (selectedView == "Day View")
                {
                    schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
                }
                else if (selectedView == "Week View")
                {
                    schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
                }
                else if (selectedView == "Work Week View")
                {
                    schedule.ScheduleView = SFScheduleView.SFScheduleViewWorkWeek;
                }
                else if (selectedView == "Month View")
                {
                    schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
                }
            };

            scheduleViewPicker.ShowSelectionIndicator = true;
            scheduleViewPicker.Hidden = true;
            scheduleViewPicker.Model = model;
            scheduleViewPicker.BackgroundColor = UIColor.White;

            this.OptionView = new UIView();
        }

        /// <summary>
        /// Event to hide the picker when an required item selected
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Arguments of the event</param>
        private void HidePicker(object sender, EventArgs e)
        {
            button.Hidden = true;
            scheduleViewPicker.Hidden = true;
            this.BecomeFirstResponder();
        }

        /// <summary>
        /// Event to show the picker when it needs
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Arguments of the event</param>
        private void ShowPicker(object sender, EventArgs e)
        {
            button.Hidden = false;
            scheduleViewPicker.Hidden = false;
            this.BecomeFirstResponder();
        }

        /// <summary>
        /// Updates the frame to child
        /// </summary>
        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                if (view is SFSchedule)
                {
                    view.Frame = new CGRect(this.Frame.X, 0, Frame.Size.Width, Frame.Size.Height);
                    string deviceType = UIDevice.CurrentDevice.Model;
                    if (deviceType == "iPhone" || deviceType == "iPod touch")
                    {
                        label.Frame = new CGRect(15, 10, this.Frame.Size.Width - 20, 40);
                        textButton.Frame = new CGRect(10, label.Frame.Size.Height + label.Frame.Y, this.Frame.Size.Width - 20, 40);
                        button.Frame = new CGRect(this.Frame.X + 10, textButton.Frame.Y + textButton.Frame.Size.Height, this.Frame.Size.Width - 20, 30);
                        scheduleViewPicker.Frame = new CGRect(0, button.Frame.Y + button.Frame.Size.Height, this.Frame.Size.Width, 100);
                    }
                    else
                    {
                        schedule.WeekViewSettings.WorkStartHour = 7;
                        schedule.WeekViewSettings.WorkEndHour = 18;
                        label.Frame = new CGRect(15, 10, this.Frame.Size.Width - 20, 30);
                        textButton.Frame = new CGRect(10, 40, this.Frame.Size.Width / 2.5, 30);
                        button.Frame = new CGRect(this.Frame.X + 10, 80, this.Frame.Size.Width / 2.5, 30);
                        scheduleViewPicker.Frame = new CGRect(0, 100, this.Frame.Size.Width / 2.5, 200);
                    }
                }
            }

            base.LayoutSubviews();
            this.CreateOptionView();
        }

        /// <summary>
        /// Creates option view to show the picker 
        /// </summary>
        private void CreateOptionView()
        {
            this.OptionView.AddSubview(label);
            this.OptionView.AddSubview(textButton);
            this.OptionView.AddSubview(scheduleViewPicker);
            this.OptionView.AddSubview(button);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.appointmentCollection != null)
            {
                this.appointmentCollection = null;
            }

            if (this.scheduleViews != null)
            {
                this.scheduleViews.Clear();
            }

            if (this.scheduleViewPicker != null)
            {
                this.scheduleViewPicker.Dispose();
                this.scheduleViewPicker = null;
            }

            if (this.label != null)
            {
                this.label.Dispose();
                this.label = null;
            }

            if (this.button != null)
            {
                this.button.Dispose();
                this.button = null;
            }

            if (this.textButton != null)
            {
                this.textButton.Dispose();
                this.textButton = null;
            }

            if (this.schedule != null)
            {
                this.schedule.Dispose();
                this.schedule = null;
            }

            base.Dispose(disposing);
        }
    }
}