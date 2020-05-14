#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using Syncfusion.SfSchedule.iOS;
using UIKit;

namespace SampleBrowser
{
    internal class ScheduleConfigurationViewModel
    {
        internal ObservableCollection<ScheduleAppointment> CreateAppointments()
        {
            NSDate today = new NSDate();
            SetColors();
            SetSubjects();
            ObservableCollection<ScheduleAppointment> appCollection = new ObservableCollection<ScheduleAppointment>();
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            
            // Get the year, month, day from the date
            NSDateComponents components = calendar.Components(
            NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
           
            // Set the hour, minute, second
            components.Hour = 10;
            components.Minute = 0;
            components.Second = 0;

            // Get the year, month, day from the date
            NSDateComponents endDateComponents = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
           
            // Set the hour, minute, second
            endDateComponents.Hour = 12;
            endDateComponents.Minute = 0;
            endDateComponents.Second = 0;
            Random randomNumber = new Random();

            for (int i = 0; i < 10; i++)
            {
                components.Hour = randomNumber.Next(10, 16);
                endDateComponents.Hour = components.Hour + randomNumber.Next(1, 3);
                NSDate startDate = calendar.DateFromComponents(components);
                NSDate endDate = calendar.DateFromComponents(endDateComponents);
                ScheduleAppointment appointment = new ScheduleAppointment();
                appointment.StartTime = startDate;
                appointment.EndTime = endDate;
                components.Day = components.Day + 1;
                endDateComponents.Day = endDateComponents.Day + 1;
                appointment.Subject = (NSString)subjectCollection[i];
                appointment.AppointmentBackground = colorCollection[i];

                appCollection.Add(appointment);
            }

            return appCollection;
        }

        private List<String> subjectCollection;

        private void SetSubjects()
        {
            subjectCollection = new List<String>();
            subjectCollection.Add("GoToMeeting");
            subjectCollection.Add("Business Meeting");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Project Status Discussion");
            subjectCollection.Add("Auditing");
            subjectCollection.Add("Client Meeting");
            subjectCollection.Add("Generate Report");
            subjectCollection.Add("Target Meeting");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Pay House Rent");
            subjectCollection.Add("Car Service");
            subjectCollection.Add("Medical Check Up");
            subjectCollection.Add("Wedding Anniversary");
            subjectCollection.Add("Sam's Birthday");
            subjectCollection.Add("Jenny's Birthday");
        }

        // adding colors collection
        private List<UIColor> colorCollection;

        private void SetColors()
        {
            colorCollection = new List<UIColor>();
            colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
            colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            colorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
            colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            colorCollection.Add(UIColor.FromRGB(0xF0, 0x96, 0x09));
            colorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
            colorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
            colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            colorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
            colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
            colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            colorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
            colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            colorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
        }
    }
}