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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    internal class TimetableBehavior : Behavior<Syncfusion.SfSchedule.XForms.SfSchedule>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule AssociatedObject { get; set; }
        protected override void OnAttachedTo(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.VisibleDatesChangedEvent += BindableVisibleDatesChangedEvent;

            // Schedule TimeInterval Height 
            if (Device.RuntimePlatform == "iOS")
            {
                if (Device.Idiom == TargetIdiom.Phone)
                    bindable.TimeIntervalHeight = 100;
                else
                    bindable.TimeIntervalHeight = 130;
            }
            else
            {
                if (Device.Idiom == TargetIdiom.Phone)
                    bindable.TimeIntervalHeight = 130;
                else
                {
                    bindable.TimeIntervalHeight = 175;
                }
            }
        }

        protected override void OnDetachingFrom(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.VisibleDatesChangedEvent -= BindableVisibleDatesChangedEvent;
            AssociatedObject = null;
        }

        private void BindableVisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            var viewModel = (this.AssociatedObject.BindingContext as TimetableViewModel);
            var sfschedule = AssociatedObject;
            viewModel.Appointments = new ScheduleAppointmentCollection();
            var visibleDates = e.visibleDates;
            var rand = new Random();
            var endCalendar = DateTime.Now.Date;
            var startCalendar = DateTime.Now.Date;
            var breakStartValue = DateTime.Now.Date;
            var breakEndValue = DateTime.Now.Date;
            var break1StartValue = DateTime.Now.Date;
            var break2StartValue = DateTime.Now.Date;

            for (int i = 0; i < visibleDates.Count; i++)
            {
                if (visibleDates[i].DayOfWeek == DayOfWeek.Sunday || visibleDates[i].DayOfWeek == DayOfWeek.Saturday)
                {
                    sfschedule.DayViewSettings.NonAccessibleBlocks = null;
                }
                else
                {
                    sfschedule.DayViewSettings.NonAccessibleBlocks = viewModel.nonAccessibleBlocks;
                }
                if (visibleDates[i].DayOfWeek == DayOfWeek.Sunday || visibleDates[i].DayOfWeek == DayOfWeek.Saturday)
                    continue;
                // Periods Appointments
                for (int j = 0; j < viewModel.startTimeCollection.Count; j++)
                {
                    startCalendar = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, viewModel.startTimeCollection[j].Hour, viewModel.startTimeCollection[j].Minute, viewModel.startTimeCollection[j].Second);
                    endCalendar = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, viewModel.endTimeCollection[j].Hour, viewModel.endTimeCollection[j].Minute, viewModel.endTimeCollection[j].Second);
                    var subject = viewModel.subjectCollection[rand.Next(viewModel.subjectCollection.Count)];
                    viewModel.Appointments.Add(new ScheduleAppointment()
                    {
                        StartTime = startCalendar,
                        EndTime = endCalendar,
                        Subject = subject + " (" + (viewModel.startTimeCollection[j].Hour.ToString()) + ":00 -" + (viewModel.endTimeCollection[j].Hour.ToString()) + ":00" + ")\n\n" + (viewModel.GetStaff(subject)),
                        Color = viewModel.GetColors(subject),
                    });
                }

                // Break Timings
                breakStartValue = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, 11, 01, 0);
                breakEndValue = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, 11, 10, 0);
                viewModel.Appointments.Add(new ScheduleAppointment()
                {
                    StartTime = breakStartValue,
                    EndTime = breakEndValue,
                    Color = Color.LightGray
                });

                break1StartValue = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, 15, 01, 0);
                break2StartValue = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, 15, 10, 0);
                viewModel.Appointments.Add(new ScheduleAppointment()
                {
                    StartTime = break1StartValue,
                    EndTime = break2StartValue,
                    Color = Color.LightGray
                });
            }
            sfschedule.DataSource = viewModel.Appointments;
        }
    }
}
