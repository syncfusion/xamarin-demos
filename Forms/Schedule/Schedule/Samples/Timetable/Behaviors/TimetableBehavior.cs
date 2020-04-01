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
using System.Windows.Input;
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Time table Behavior class
    /// </summary>
    internal class TimetableBehavior : Behavior<Syncfusion.SfSchedule.XForms.SfSchedule>
    {
        /// <summary>
        /// Gets or sets associated object
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule AssociatedObject
        {
            get;
            set;
        }

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnAttachedTo(bindable);
            this.AssociatedObject = bindable;
            if (Device.RuntimePlatform == Device.Android)
            {
                this.AssociatedObject.ViewHeaderStyle.DateFontSize = 24;
            }

            bindable.VisibleDatesChangedEvent += this.BindableVisibleDatesChangedEvent;           
        }

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.VisibleDatesChangedEvent -= this.BindableVisibleDatesChangedEvent;
            this.AssociatedObject = null;
        }

        /// <summary>
        /// visible dates changed event
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Visible Dates Changed Event Args</param>
        private void BindableVisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            var viewModel = this.AssociatedObject.BindingContext as TimetableViewModel;
            var sfschedule = this.AssociatedObject;
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
                    sfschedule.DayViewSettings.NonAccessibleBlocks = viewModel.NonAccessibleBlocks;
                }

                if (visibleDates[i].DayOfWeek == DayOfWeek.Sunday || visibleDates[i].DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }

                // Periods Appointments
                for (int j = 0; j < viewModel.StartTimeCollection.Count; j++)
                {
                    startCalendar = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, viewModel.StartTimeCollection[j].Hour, viewModel.StartTimeCollection[j].Minute, viewModel.StartTimeCollection[j].Second);
                    endCalendar = new DateTime(visibleDates[i].Year, visibleDates[i].Month, visibleDates[i].Day, viewModel.EndTimeCollection[j].Hour, viewModel.EndTimeCollection[j].Minute, viewModel.EndTimeCollection[j].Second);
                    var subject = viewModel.SubjectCollection[rand.Next(viewModel.SubjectCollection.Count)];
                    viewModel.Appointments.Add(new ScheduleAppointment()
                    {
                        StartTime = startCalendar,
                        EndTime = endCalendar,
                        Subject = subject + " (" + viewModel.StartTimeCollection[j].Hour.ToString() + ":00 -" + viewModel.EndTimeCollection[j].Hour.ToString() + ":00" + ")\n\n" + viewModel.GetStaff(subject),
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
