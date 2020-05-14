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
using System.Linq;
using System.Text;

using Foundation;
using Syncfusion.SfSchedule.iOS;
using UIKit;

namespace SampleBrowser
{
    public class ScheduleViewModel
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
                if (i == 2 || i == 4)
                {
                    appointment.IsAllDay = true;
                }

                appCollection.Add(appointment);
            }

            NSDateComponents startDateComponents = calendar.Components(
               NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents.Minute = 0;
            startDateComponents.Second = 0;

            // Minimum Height Appointments
            for (int i = 0; i < 5; i++)
            {
                startDateComponents.Hour = randomNumber.Next(9, 18);
                NSDate startDate = calendar.DateFromComponents(startDateComponents);
                ScheduleAppointment appointment = new ScheduleAppointment();
                appointment.StartTime = startDate;
                appointment.EndTime = startDate;
                startDateComponents.Day = startDateComponents.Day + 1;
                appointment.Subject = (NSString)minTimeSubjectCollection[i];
                appointment.AppointmentBackground = colorCollection[randomNumber.Next(0, 14)];
              
                // Setting Mininmum Appointment Height for Schedule Appointments
                appointment.MinHeight = 25;
                appCollection.Add(appointment);
            }

            return appCollection;
        }

        private List<String> subjectCollection;
        private List<String> minTimeSubjectCollection;
        private List<UIColor> colorCollection;

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

            // MinimumHeight Appointment Subjects
            minTimeSubjectCollection = new List<string>();
            minTimeSubjectCollection.Add("Work log alert");
            minTimeSubjectCollection.Add("Birthday wish alert");
            minTimeSubjectCollection.Add("Task due date");
            minTimeSubjectCollection.Add("Status mail");
            minTimeSubjectCollection.Add("Start sprint alert");
        }

        // adding colors collection
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

    public static class TimeZoneCollection
    {
        public static IList<string> TimeZoneList { get; set; } = new List<string>()
        {
                "Default",
                "AUS Central Standard Time",
                "AUS Eastern Standard Time",
                "Afghanistan Standard Time",
                "Alaskan Standard Time",
                "Arab Standard Time",
                "Arabian Standard Time",
                "Arabic Standard Time",
                "Argentina Standard Time",
                "Atlantic Standard Time",
                "Azerbaijan Standard Time",
                "Azores Standard Time",
                "Bahia Standard Time",
                "Bangladesh Standard Time",
                "Belarus Standard Time",
                "Canada Central Standard Time",
                "Cape Verde Standard Time",
                "Caucasus Standard Time",
                "Cen. Australia Standard Time",
                "Central America Standard Time",
                "Central Asia Standard Time",
                "Central Brazilian Standard Time",
                "Central Europe Standard Time",
                "Central European Standard Time",
                "Central Pacific Standard Time",
                "Central Standard Time",
                "China Standard Time",
                "Dateline Standard Time",
                "E. Africa Standard Time",
                "E. Australia Standard Time",
                "E. South America Standard Time",
                "Eastern Standard Time",
                "Egypt Standard Time",
                "Ekaterinburg Standard Time",
                "FLE Standard Time",
                "Fiji Standard Time",
                "GMT Standard Time",
                "GTB Standard Time",
                "Georgian Standard Time",
                "Greenland Standard Time",
                "Greenwich Standard Time",
                "Hawaiian Standard Time",
                "India Standard Time",
                "Iran Standard Time",
                "Israel Standard Time",
                "Jordan Standard Time",
                "Kaliningrad Standard Time",
                "Korea Standard Time",
                "Libya Standard Time",
                "Line Islands Standard Time",
                "Magadan Standard Time",
                "Mauritius Standard Time",
                "Middle East Standard Time",
                "Montevideo Standard Time",
                "Morocco Standard Time",
                "Mountain Standard Time",
                "Mountain Standard Time (Mexico)",
                "Myanmar Standard Time",
                "N. Central Asia Standard Time",
                "Namibia Standard Time",
                "Nepal Standard Time",
                "New Zealand Standard Time",
                "Newfoundland Standard Time",
                "North Asia East Standard Time",
                "North Asia Standard Time",
                "Pacific SA Standard Time",
                "Pacific Standard Time",
                "Pacific Standard Time (Mexico)",
                "Pakistan Standard Time",
                "Paraguay Standard Time",
                "Romance Standard Time",
                "Russia Time Zone 10",
                "Russia Time Zone 11",
                "Russia Time Zone 3",
                "Russian Standard Time",
                "SA Eastern Standard Time",
                "SA Pacific Standard Time",
                "SA Western Standard Time",
                "SE Asia Standard Time",
                "Samoa Standard Time",
                "Singapore Standard Time",
                "South Africa Standard Time",
                "Sri Lanka Standard Time",
                "Syria Standard Time",
                "Taipei Standard Time",
                "Tasmania Standard Time",
                "Tokyo Standard Time",
                "Tonga Standard Time",
                "Turkey Standard Time",
                "US Eastern Standard Time",
                "US Mountain Standard Time",
                "UTC",
                "UTC+12",
                "UTC-02",
                "UTC-11",
                "Ulaanbaatar Standard Time",
                "Venezuela Standard Time",
                "Vladivostok Standard Time",
                "W. Australia Standard Time",
                "W. Central Africa Standard Time",
                "W. Europe Standard Time",
                "West Asia Standard Time",
                "West Pacific Standard Time",
                 "Yakutsk Standard Time"
        };
    }

    public class SchedulePickerModel : UIPickerViewModel
    {
        private readonly IList<string> values;

        public event EventHandler<SchedulePickerChangedEventArgs> PickerChanged;

        public SchedulePickerModel(IList<string> values)
        {
            this.values = values;
        }
#if __UNIFIED__
        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return values.Count;
        }

        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return values[(int)row];
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 30f;
        }

        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            if (this.PickerChanged != null)
            {
                this.PickerChanged(this, new SchedulePickerChangedEventArgs { SelectedValue = values[(int)row] });
            }
        }
#else
		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return values.Count;
		}

		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			return values[(int)row];
		}

		public override nfloat GetRowHeight(UIPickerView picker, int component)
		{
			return 30f;
		}

		public override void Selected(UIPickerView picker, int row, int component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new SchedulePickerChangedEventArgs { SelectedValue = values[(int)row] });
			}
		}
#endif
    }

    public class SchedulePickerChangedEventArgs : EventArgs
    {
        public string SelectedValue { get; set; }
    }

    public class ScheduleTableSource : UITableViewSource
    {
       private string[] tableItems;
       private string cellIdentifier = "TableCell";

        public ScheduleTableSource(string[] items)
        {
            tableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            int i = tableItems.Length;
            return (nint)i;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (indexPath.Row)
            {
                case 0:
                    ScheduleViews.Schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
                    ScheduleViews.TableView.Hidden = true;
                    break;
                case 1:
                    ScheduleViews.Schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
                    ScheduleViews.TableView.Hidden = true;
                    break;
                case 2:
                    ScheduleViews.Schedule.ScheduleView = SFScheduleView.SFScheduleViewWorkWeek;
                    ScheduleViews.TableView.Hidden = true;
                    break;
                case 3:
                    ScheduleViews.Schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
                    ScheduleViews.TableView.Hidden = true;
                    break;
            }
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 60.0f;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

            string item = tableItems[indexPath.Row];
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            }

            cell.TextLabel.Text = item;
            return cell;
        }
    }
}