#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.ComponentModel;

namespace SampleBrowser.SfSchedule
{
    [Preserve(AllMembers = true)]
    public class CustomizationViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ScheduleAppointmentCollection Appointments { get; set; }
        public static ScheduleAppointment ScheduleAppointment { get; set; }
        public static MonthCellItem MonthCellItem { get; set; }

        private ScheduleAppointment conference, medical, systemTroubleShoot, birthday, medical2, conference2, systemTroubleShoot2, birthday2, medical3, systemTroubleShoot3, conference4, medical4, systemTroubleShoot4, birthday4, conference5, medical5, systemTroubleShoot5, birthday5;

        #region HeaderLabelValue
        private string headerLabelValue = DateTime.Today.Date.ToString("dd, MMMM yyyy");

        public string HeaderLabelValue
        {
            get { return headerLabelValue; }
            set
            {
                headerLabelValue = value;
                RaiseOnPropertyChanged("HeaderLabelValue");
            }
        }
        #endregion

        #endregion Properties

        #region Constructor

        public CustomizationViewModel()
        {
            Appointments = new ScheduleAppointmentCollection();
            conference = new ScheduleAppointment();
            conference.Subject = "Conference";
            conference.StartTime = DateTime.Now.Date.AddHours(10);
            conference.EndTime = DateTime.Now.Date.AddHours(12);
            conference.Color = (Color.FromHex("#FFD80073"));

            systemTroubleShoot = new ScheduleAppointment();
            systemTroubleShoot.Subject = "System Troubleshoot";
            systemTroubleShoot.StartTime = DateTime.Now.Date.AddDays(1).AddHours(9);
            systemTroubleShoot.EndTime = DateTime.Now.Date.AddDays(1).AddHours(11);
            systemTroubleShoot.Color = Color.FromHex("#FF00ABA9");
            systemTroubleShoot.IsAllDay = true;

            medical = new ScheduleAppointment();
            medical.Subject = "Checkup";
            medical.StartTime = DateTime.Now.Date.AddDays(2).AddHours(10);
            medical.EndTime = DateTime.Now.Date.AddDays(2).AddHours(12);
            medical.Color = Color.FromHex("#FFA2C139");

            birthday = new ScheduleAppointment();
            birthday.Subject = "Jeni's Birthday";
            birthday.StartTime = DateTime.Now.Date.AddDays(3).AddHours(9);
            birthday.EndTime = DateTime.Now.Date.AddDays(3).AddHours(11);
            birthday.Color = Color.FromHex("#FF1BA1E2");
            birthday.IsAllDay = true;


            conference2 = new ScheduleAppointment();
            conference2.Subject = "Conference";
            conference2.StartTime = DateTime.Now.Date.AddDays(11).AddHours(10);
            conference2.EndTime = DateTime.Now.Date.AddDays(11).AddHours(12);
            conference2.Color = (Color.FromHex("#FFD80073"));

            systemTroubleShoot2 = new ScheduleAppointment();
            systemTroubleShoot2.Subject = "System Troubleshoot";
            systemTroubleShoot2.StartTime = DateTime.Now.Date.AddDays(15).AddHours(9);
            systemTroubleShoot2.EndTime = DateTime.Now.Date.AddDays(15).AddHours(11);
            systemTroubleShoot2.Color = Color.FromHex("#FF00ABA9");
            systemTroubleShoot2.IsAllDay = true;

            medical2 = new ScheduleAppointment();
            medical2.Subject = "Checkup";
            medical2.StartTime = DateTime.Now.Date.AddDays(18).AddHours(10);
            medical2.EndTime = DateTime.Now.Date.AddDays(18).AddHours(12);
            medical2.Color = Color.FromHex("#FFA2C139");

            birthday2 = new ScheduleAppointment();
            birthday2.Subject = "Jeni's Birthday";
            birthday2.StartTime = DateTime.Now.Date.AddDays(20).AddHours(9);
            birthday2.EndTime = DateTime.Now.Date.AddDays(20).AddHours(11);
            birthday2.Color = Color.FromHex("#FF1BA1E2");
            birthday2.IsAllDay = true;

            systemTroubleShoot3 = new ScheduleAppointment();
            systemTroubleShoot3.Subject = "System Troubleshoot";
            systemTroubleShoot3.StartTime = DateTime.Now.Date.AddDays(24).AddHours(9);
            systemTroubleShoot3.EndTime = DateTime.Now.Date.AddDays(24).AddHours(11);
            systemTroubleShoot3.Color = Color.FromHex("#FF00ABA9");
            systemTroubleShoot3.IsAllDay = true;

            medical3 = new ScheduleAppointment();
            medical3.Subject = "Checkup";
            medical3.StartTime = DateTime.Now.Date.AddDays(27).AddHours(10);
            medical3.EndTime = DateTime.Now.Date.AddDays(27).AddHours(12);
            medical3.Color = Color.FromHex("#FFA2C139");

            conference4 = new ScheduleAppointment();
            conference4.Subject = "Conference";
            conference4.StartTime = DateTime.Now.Date.AddMonths(1).AddHours(10);
            conference4.EndTime = DateTime.Now.Date.AddMonths(1).AddHours(12);
            conference4.Color = (Color.FromHex("#FFD80073"));

            systemTroubleShoot4 = new ScheduleAppointment();
            systemTroubleShoot4.Subject = "System Troubleshoot";
            systemTroubleShoot4.StartTime = DateTime.Now.Date.AddMonths(1).AddDays(4).AddHours(9);
            systemTroubleShoot4.EndTime = DateTime.Now.Date.AddMonths(1).AddDays(4).AddHours(11);
            systemTroubleShoot4.Color = Color.FromHex("#FF00ABA9");
            systemTroubleShoot4.IsAllDay = true;

            medical4 = new ScheduleAppointment();
            medical4.Subject = "Checkup";
            medical4.StartTime = DateTime.Now.Date.AddMonths(1).AddDays(7).AddHours(10);
            medical4.EndTime = DateTime.Now.Date.AddMonths(1).AddDays(7).AddHours(12);
            medical4.Color = Color.FromHex("#FFA2C139");

            birthday4 = new ScheduleAppointment();
            birthday4.Subject = "Jeni's Birthday";
            birthday4.StartTime = DateTime.Now.Date.AddMonths(1).AddDays(11).AddHours(9);
            birthday4.EndTime = DateTime.Now.Date.AddMonths(1).AddDays(11).AddHours(11);
            birthday4.Color = Color.FromHex("#FF1BA1E2");
            birthday4.IsAllDay = true;

            conference5 = new ScheduleAppointment();
            conference5.Subject = "Conference";
            conference5.StartTime = DateTime.Now.Date.AddMonths(-1).AddHours(10);
            conference5.EndTime = DateTime.Now.Date.AddMonths(-1).AddHours(12);
            conference5.Color = (Color.FromHex("#FFD80073"));

            systemTroubleShoot5 = new ScheduleAppointment();
            systemTroubleShoot5.Subject = "System Troubleshoot";
            systemTroubleShoot5.StartTime = DateTime.Now.Date.AddMonths(-1).AddDays(3).AddHours(9);
            systemTroubleShoot5.EndTime = DateTime.Now.Date.AddMonths(-1).AddDays(3).AddHours(11);
            systemTroubleShoot5.Color = Color.FromHex("#FF00ABA9");
            systemTroubleShoot5.IsAllDay = true;

            medical5 = new ScheduleAppointment();
            medical5.Subject = "Checkup";//
            medical5.StartTime = DateTime.Now.Date.AddMonths(-1).AddDays(6).AddHours(10);
            medical5.EndTime = DateTime.Now.Date.AddMonths(-1).AddDays(6).AddHours(12);
            medical5.Color = Color.FromHex("#FFA2C139");

            birthday5 = new ScheduleAppointment();
            birthday5.Subject = "Jeni's Birthday";
            birthday5.StartTime = DateTime.Now.Date.AddMonths(-1).AddDays(9).AddHours(9);
            birthday5.EndTime = DateTime.Now.Date.AddMonths(-1).AddDays(9).AddHours(11);
            birthday5.Color = Color.FromHex("#FF1BA1E2");
            birthday5.IsAllDay = true;

            Appointments.Add(conference);
            Appointments.Add(systemTroubleShoot);
            Appointments.Add(medical);
            Appointments.Add(birthday);
            Appointments.Add(conference2);
            Appointments.Add(systemTroubleShoot2);
            Appointments.Add(medical2);
            Appointments.Add(birthday2);
            Appointments.Add(medical3);
            Appointments.Add(systemTroubleShoot3);
            Appointments.Add(conference4);
            Appointments.Add(systemTroubleShoot4);
            Appointments.Add(medical4);
            Appointments.Add(birthday4);
            Appointments.Add(conference5);
            Appointments.Add(systemTroubleShoot5);
            Appointments.Add(medical5);
            Appointments.Add(birthday5);
        }

        #endregion Constructor

        #region Property Changed Event

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

