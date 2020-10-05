#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Customization View Model class.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CustomizationViewModel : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// schedule appointments
        /// </summary>
        private ScheduleAppointment conference, medical, systemTroubleShoot, birthday, medical2, conference2, systemTroubleShoot2, birthday2, medical3, systemTroubleShoot3, conference4, medical4, systemTroubleShoot4, birthday4, conference5, medical5, systemTroubleShoot5, birthday5;

        #region HeaderLabelValue
        /// <summary>
        /// header label value
        /// </summary>
        private string headerLabelValue = DateTime.Today.Date.ToString("dd, MMMM yyyy");

        #endregion

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationViewModel" /> class
        /// </summary>
        public CustomizationViewModel()
        {
            this.Appointments = new ScheduleAppointmentCollection();
            this.conference = new ScheduleAppointment();
            this.conference.Subject = "Conference";
            this.conference.StartTime = DateTime.Now.Date.AddHours(10);
            this.conference.EndTime = DateTime.Now.Date.AddHours(12);
            this.conference.Color = Color.FromHex("#FFD80073");

            this.systemTroubleShoot = new ScheduleAppointment();
            this.systemTroubleShoot.Subject = "System Troubleshoot";
            this.systemTroubleShoot.StartTime = DateTime.Now.Date.AddDays(1).AddHours(9);
            this.systemTroubleShoot.EndTime = DateTime.Now.Date.AddDays(1).AddHours(11);
            this.systemTroubleShoot.Color = Color.FromHex("#FF00ABA9");
            this.systemTroubleShoot.IsAllDay = true;

            this.medical = new ScheduleAppointment();
            this.medical.Subject = "Checkup";
            this.medical.StartTime = DateTime.Now.Date.AddDays(2).AddHours(10);
            this.medical.EndTime = DateTime.Now.Date.AddDays(2).AddHours(12);
            this.medical.Color = Color.FromHex("#FFA2C139");

            this.birthday = new ScheduleAppointment();
            this.birthday.Subject = "Jeni's Birthday";
            this.birthday.StartTime = DateTime.Now.Date.AddDays(3).AddHours(9);
            this.birthday.EndTime = DateTime.Now.Date.AddDays(3).AddHours(11);
            this.birthday.Color = Color.FromHex("#FF1BA1E2");
            this.birthday.IsAllDay = true;

            this.conference2 = new ScheduleAppointment();
            this.conference2.Subject = "Conference";
            this.conference2.StartTime = DateTime.Now.Date.AddDays(11).AddHours(10);
            this.conference2.EndTime = DateTime.Now.Date.AddDays(11).AddHours(12);
            this.conference2.Color = Color.FromHex("#FFD80073");

            this.systemTroubleShoot2 = new ScheduleAppointment();
            this.systemTroubleShoot2.Subject = "System Troubleshoot";
            this.systemTroubleShoot2.StartTime = DateTime.Now.Date.AddDays(15).AddHours(9);
            this.systemTroubleShoot2.EndTime = DateTime.Now.Date.AddDays(15).AddHours(11);
            this.systemTroubleShoot2.Color = Color.FromHex("#FF00ABA9");
            this.systemTroubleShoot2.IsAllDay = true;

            this.medical2 = new ScheduleAppointment();
            this.medical2.Subject = "Checkup";
            this.medical2.StartTime = DateTime.Now.Date.AddDays(18).AddHours(10);
            this.medical2.EndTime = DateTime.Now.Date.AddDays(18).AddHours(12);
            this.medical2.Color = Color.FromHex("#FFA2C139");

            this.birthday2 = new ScheduleAppointment();
            this.birthday2.Subject = "Jeni's Birthday";
            this.birthday2.StartTime = DateTime.Now.Date.AddDays(20).AddHours(9);
            this.birthday2.EndTime = DateTime.Now.Date.AddDays(20).AddHours(11);
            this.birthday2.Color = Color.FromHex("#FF1BA1E2");
            this.birthday2.IsAllDay = true;

            this.systemTroubleShoot3 = new ScheduleAppointment();
            this.systemTroubleShoot3.Subject = "System Troubleshoot";
            this.systemTroubleShoot3.StartTime = DateTime.Now.Date.AddDays(24).AddHours(9);
            this.systemTroubleShoot3.EndTime = DateTime.Now.Date.AddDays(24).AddHours(11);
            this.systemTroubleShoot3.Color = Color.FromHex("#FF00ABA9");
            this.systemTroubleShoot3.IsAllDay = true;

            this.medical3 = new ScheduleAppointment();
            this.medical3.Subject = "Checkup";
            this.medical3.StartTime = DateTime.Now.Date.AddDays(27).AddHours(10);
            this.medical3.EndTime = DateTime.Now.Date.AddDays(27).AddHours(12);
            this.medical3.Color = Color.FromHex("#FFA2C139");

            this.conference4 = new ScheduleAppointment();
            this.conference4.Subject = "Conference";
            this.conference4.StartTime = DateTime.Now.Date.AddMonths(1).AddHours(10);
            this.conference4.EndTime = DateTime.Now.Date.AddMonths(1).AddHours(12);
            this.conference4.Color = Color.FromHex("#FFD80073");

            this.systemTroubleShoot4 = new ScheduleAppointment();
            this.systemTroubleShoot4.Subject = "System Troubleshoot";
            this.systemTroubleShoot4.StartTime = DateTime.Now.Date.AddMonths(1).AddDays(4).AddHours(9);
            this.systemTroubleShoot4.EndTime = DateTime.Now.Date.AddMonths(1).AddDays(4).AddHours(11);
            this.systemTroubleShoot4.Color = Color.FromHex("#FF00ABA9");
            this.systemTroubleShoot4.IsAllDay = true;

            this.medical4 = new ScheduleAppointment();
            this.medical4.Subject = "Checkup";
            this.medical4.StartTime = DateTime.Now.Date.AddMonths(1).AddDays(7).AddHours(10);
            this.medical4.EndTime = DateTime.Now.Date.AddMonths(1).AddDays(7).AddHours(12);
            this.medical4.Color = Color.FromHex("#FFA2C139");

            this.birthday4 = new ScheduleAppointment();
            this.birthday4.Subject = "Jeni's Birthday";
            this.birthday4.StartTime = DateTime.Now.Date.AddMonths(1).AddDays(11).AddHours(9);
            this.birthday4.EndTime = DateTime.Now.Date.AddMonths(1).AddDays(11).AddHours(11);
            this.birthday4.Color = Color.FromHex("#FF1BA1E2");
            this.birthday4.IsAllDay = true;

            this.conference5 = new ScheduleAppointment();
            this.conference5.Subject = "Conference";
            this.conference5.StartTime = DateTime.Now.Date.AddMonths(-1).AddHours(10);
            this.conference5.EndTime = DateTime.Now.Date.AddMonths(-1).AddHours(12);
            this.conference5.Color = Color.FromHex("#FFD80073");

            this.systemTroubleShoot5 = new ScheduleAppointment();
            this.systemTroubleShoot5.Subject = "System Troubleshoot";
            this.systemTroubleShoot5.StartTime = DateTime.Now.Date.AddMonths(-1).AddDays(3).AddHours(9);
            this.systemTroubleShoot5.EndTime = DateTime.Now.Date.AddMonths(-1).AddDays(3).AddHours(11);
            this.systemTroubleShoot5.Color = Color.FromHex("#FF00ABA9");
            this.systemTroubleShoot5.IsAllDay = true;

            this.medical5 = new ScheduleAppointment();
            this.medical5.Subject = "Checkup";
            this.medical5.StartTime = DateTime.Now.Date.AddMonths(-1).AddDays(6).AddHours(10);
            this.medical5.EndTime = DateTime.Now.Date.AddMonths(-1).AddDays(6).AddHours(12);
            this.medical5.Color = Color.FromHex("#FFA2C139");

            this.birthday5 = new ScheduleAppointment();
            this.birthday5.Subject = "Jeni's Birthday";
            this.birthday5.StartTime = DateTime.Now.Date.AddMonths(-1).AddDays(9).AddHours(9);
            this.birthday5.EndTime = DateTime.Now.Date.AddMonths(-1).AddDays(9).AddHours(11);
            this.birthday5.Color = Color.FromHex("#FF1BA1E2");
            this.birthday5.IsAllDay = true;

            this.Appointments.Add(this.conference);
            this.Appointments.Add(this.systemTroubleShoot);
            this.Appointments.Add(this.medical);
            this.Appointments.Add(this.birthday);
            this.Appointments.Add(this.conference2);
            this.Appointments.Add(this.systemTroubleShoot2);
            this.Appointments.Add(this.medical2);
            this.Appointments.Add(this.birthday2);
            this.Appointments.Add(this.medical3);
            this.Appointments.Add(this.systemTroubleShoot3);
            this.Appointments.Add(this.conference4);
            this.Appointments.Add(this.systemTroubleShoot4);
            this.Appointments.Add(this.medical4);
            this.Appointments.Add(this.birthday4);
            this.Appointments.Add(this.conference5);
            this.Appointments.Add(this.systemTroubleShoot5);
            this.Appointments.Add(this.medical5);
            this.Appointments.Add(this.birthday5);
        }

        #endregion Constructor

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets schedule appointment
        /// </summary>
        public static ScheduleAppointment ScheduleAppointment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets month cell item
        /// </summary>
        public static MonthCellItem MonthCellItem
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets appointments
        /// </summary>
        public ScheduleAppointmentCollection Appointments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Header label value
        /// </summary>
        public string HeaderLabelValue
        {
            get
            {
                return this.headerLabelValue;
            }

            set
            {
                this.headerLabelValue = value;
                this.RaiseOnPropertyChanged("HeaderLabelValue");
            }
        }
        #region Property Changed Event

        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}