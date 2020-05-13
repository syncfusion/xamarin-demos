#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UIKit;

namespace SampleBrowser
{
    /// <summary>
    /// Creates the appointment collection for custom appointments
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AppointmentCollection
    {
        /// <summary>
        /// Custom appointment color collection
        /// </summary>
        private List<UIColor> colorCollection;

        /// <summary>
        /// Custom appointment subject name collection
        /// </summary>
        private List<string> eventCollection;

        /// <summary>
        /// Custom appointment start time collection
        /// </summary>
        private List<NSDate> fromCollection;

        /// <summary>
        /// Custom appointment end time collection
        /// </summary>
        private List<NSDate> toCollection;

        /// <summary>
        /// Random numbers collection to get the start and end time values
        /// </summary>
        private List<int> randomNumbers;

        /// <summary>
        /// Custom appointment variables
        /// </summary>
        private Meeting meeting;

        /// <summary>
        /// Collection for custom appointment
        /// </summary>
        private ObservableCollection<Meeting> appointmentCollection;

        /// <summary>
        /// Gets the appointment collection
        /// </summary>
        /// <returns>Appointment collection</returns>
        internal ObservableCollection<Meeting> GetAppointments()
        {
            NSDate today = new NSDate();
            NSCalendar calendar = NSCalendar.CurrentCalendar;
            appointmentCollection = new ObservableCollection<Meeting>();
            SetEventCollection();
            RandomNumbers();
            SetFromCollection();
            SetToCollection();
            SetColorCollection();

            for (int i = 0; i < 15; i++)
            {
                meeting = new Meeting();
                meeting.Color = colorCollection[i];
                meeting.EventName = (NSString)eventCollection[i];
                meeting.From = fromCollection[i];

                // To create all day appointments
                if (i % 6 == 0 && i != 0)
                {
                    meeting.IsAllDay = true;
                }

                // To create two days span appointment
                if (i % 5 == 0 && i != 0)
                {
                    toCollection[i] = fromCollection[i];
                    var dateComponent = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, toCollection[i]);
                    dateComponent.Day = dateComponent.Day + 2;
                    toCollection[i] = calendar.DateFromComponents(dateComponent);
                }

                // To create 24 hour span appointments
                if (i % 7 == 0)
                {
                    toCollection[i] = fromCollection[i];
                    var dateComponent = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, toCollection[i]);
                    dateComponent.Hour = dateComponent.Hour + 23;
                    dateComponent.Minute = dateComponent.Minute + 59;
                    toCollection[i] = calendar.DateFromComponents(dateComponent);
                }

                // To create minimum height appointments
                if (eventCollection[i].Contains("alert"))
                {
                    toCollection[i] = fromCollection[i];
                    meeting.MinimumHeight = 20;
                }

                meeting.To = toCollection[i];
                appointmentCollection.Add(meeting);
            }

            return appointmentCollection;
        }

        /// <summary>
        /// Creates the random numbers to get start time and end time
        /// </summary>
        private void RandomNumbers()
        {
            randomNumbers = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int randomNum = rand.Next((15 - 9) + 1) + 9;
                randomNumbers.Add(randomNum);
            }
        }

        /// <summary>
        /// Sets the end time collection for custom appointment
        /// </summary>
        private void SetToCollection()
        {
            toCollection = new List<NSDate>();
            int count = 0;
            for (int i = -10; i < 10; i++)
            {
                var today = new NSDate();
                NSCalendar calendar = NSCalendar.CurrentCalendar;
                NSDateComponents components = calendar.Components(
                    NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, today);
                components.Day = components.Day + i;
                components.Hour = randomNumbers[count] + 2;
                components.Minute = 0;
                components.Second = 0;

                var to = calendar.DateFromComponents(components);
                toCollection.Add(to);
                count++;
            }
        }

        /// <summary>
        /// Sets the start time collection for custom appointments
        /// </summary>
        private void SetFromCollection()
        {
            fromCollection = new List<NSDate>();
            int count = 0;
            for (int i = -10; i < 10; i++)
            {
                var today = new NSDate();
                NSCalendar calendar = NSCalendar.CurrentCalendar;
                NSDateComponents components = calendar.Components(
                    NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second, today);
                components.Day = components.Day + i;
                components.Hour = randomNumbers[count];
                components.Minute = 0;
                components.Second = 0;

                var from = calendar.DateFromComponents(components);
                fromCollection.Add(from);
                count++;
            }
        }

        /// <summary>
        /// Sets the subject name collection for custom appointments
        /// </summary>
        private void SetEventCollection()
        {
            eventCollection = new List<String>();
            eventCollection.Add("General Meeting");
            eventCollection.Add("Plan Execution");
            eventCollection.Add("Project Plan");
            eventCollection.Add("Consulting");
            eventCollection.Add("Performance Check");
            eventCollection.Add("Yoga Therapy");
            eventCollection.Add("Plan Execution");
            eventCollection.Add("Project Plan");
            eventCollection.Add("Consulting");
            eventCollection.Add("Performance Check");
            eventCollection.Add("Work log alert");
            eventCollection.Add("Birthday wish alert");
            eventCollection.Add("Task due date");
            eventCollection.Add("Status mail");
            eventCollection.Add("Start sprint alert");
        }

        /// <summary>
        /// Sets the color collection for custom appointments
        /// </summary>
        private void SetColorCollection()
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
