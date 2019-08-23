#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfCalendar.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using nfloat = System.Single;
using System.Drawing;
#endif


namespace SampleBrowser
{
	public class CalendarInlineEvents:SampleView
	{
		SFCalendar calendar;
		public static UITableView appView;
		UIView calendarView = new UIView ();

		public CalendarInlineEvents ()
		{

			//Calendar
			calendar= new SFCalendar ();		
			calendar.Appointments = getEnglishAppointments ();
			calendar.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			calendar.HeaderHeight = 40;
			this.AddSubview (calendar);
			if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				calendarView.AddSubview (calendar);
				this.AddSubview (calendarView);

			}
		}

		NSMutableArray getEnglishAppointments()
		{
			NSDate today = new NSDate ();
			setColors ();
			setEnglishCollectionSubjects ();
			NSMutableArray appCollection = new NSMutableArray ();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components (
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			// Set the hour, minute, second
			components.Hour = 10;
			components.Minute = 0;
			components.Second = 0;

			// Get the year, month, day from the date
			NSDateComponents endDateComponents = calendar.Components (NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			// Set the hour, minute, second
			endDateComponents.Hour = 12;
			endDateComponents.Minute = 0;
			endDateComponents.Second = 0;
			Random randomNumber = new Random ();

			for (int i = 0; i < 10; i++) {
				components.Hour = randomNumber.Next (10, 16);
				endDateComponents.Hour = components.Hour+ randomNumber.Next(1,3);
				NSDate startDate = calendar.DateFromComponents (components);
				NSDate endDate = calendar.DateFromComponents (endDateComponents);
				SFAppointment appointment = new SFAppointment ();
				appointment.StartTime = startDate;
				appointment.EndTime = endDate;
				components.Day = components.Day + 1;
				endDateComponents.Day = endDateComponents.Day + 1;
				appointment.Subject = (NSString)englishCollection[i];
				appointment.AppointmentBackground =  colorCollection[i];
				appCollection.Add (appointment);
			}
			return appCollection;
		}



		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view is SFCalendar) {
					view.Frame = new CGRect (this.Frame.X, -2, Frame.Size.Width, (Frame.Size.Height));
				}
				calendarView.Frame = new CGRect (0, 0,this.Frame.Size.Width,   this.Frame.Size.Height );
				calendar.Frame = new CGRect (0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
			}
			base.LayoutSubviews ();
		}

		List<string> englishCollection;
		private void setEnglishCollectionSubjects() {
			englishCollection = new List<string>();
			englishCollection.Add("GoToMeeting");
			englishCollection.Add("Business Meeting");
			englishCollection.Add("Conference");
			englishCollection.Add("Project Status Discussion");
			englishCollection.Add("Auditing");
			englishCollection.Add("Client Meeting");
			englishCollection.Add("Generate Report");
			englishCollection.Add("Target Meeting");
			englishCollection.Add("General Meeting");
			englishCollection.Add("Pay House Rent");
			englishCollection.Add("Car Service");
			englishCollection.Add("Medical Check Up");
			englishCollection.Add("Wedding Anniversary");
			englishCollection.Add("Sam's Birthday");
			englishCollection.Add("Jenny's Birthday");
			englishCollection.Add("Master Checkup");
			englishCollection.Add("Hospital");
			englishCollection.Add("Phone Bill Payment");
			englishCollection.Add("Project Plan");
			englishCollection.Add("Auditing");
			englishCollection.Add("Client Meeting");
			englishCollection.Add("Generate Report");
			englishCollection.Add("Target Meeting");
			englishCollection.Add("General Meeting");
			englishCollection.Add("Play Golf");
			englishCollection.Add("Car Service");
			englishCollection.Add("Medical Check Up");
			englishCollection.Add("Mary's Birthday");
			englishCollection.Add("John's Birthday");
			englishCollection.Add("Micheal's Birthday");
		}

		// adding colors collection
		List<UIColor> colorCollection;
		private void setColors() {
			colorCollection = new List<UIColor>();
			colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
			colorCollection.Add(UIColor.FromRGB(0xD8,0x00,0x73));
			colorCollection.Add(UIColor.FromRGB(0x1B,0xA1,0xE2));
			colorCollection.Add(UIColor.FromRGB(0xE6,0x71,0xB8));
			colorCollection.Add(UIColor.FromRGB(0xF0,0x96,0x09));
			colorCollection.Add(UIColor.FromRGB(0x33,0x99,0x33));
			colorCollection.Add(UIColor.FromRGB(0x00,0xAB,0xA9));
			colorCollection.Add(UIColor.FromRGB(0xE6,0x71,0xB8));
			colorCollection.Add(UIColor.FromRGB(0x1B,0xA1,0xE2));
			colorCollection.Add(UIColor.FromRGB(0xD8,0x00,0x73));
			colorCollection.Add(UIColor.FromRGB(0xA2,0xC1,0x39));
			colorCollection.Add(UIColor.FromRGB(0xD8,0x00,0x73));
			colorCollection.Add(UIColor.FromRGB(0x33,0x99,0x33));
			colorCollection.Add(UIColor.FromRGB(0xE6,0x71,0xB8));
			colorCollection.Add(UIColor.FromRGB(0x00,0xAB,0xA9));
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
			public override nint GetComponentCount (UIPickerView picker)
			{
				return 1;
			}

			public override nint GetRowsInComponent (UIPickerView picker, nint component)
			{
				return values.Count;
			}

			public override string GetTitle (UIPickerView picker, nint row, nint component)
			{
				return values[(int)row];
			}

			public override nfloat GetRowHeight (UIPickerView picker, nint component)
			{
				return 30f;
			}

			public override void Selected (UIPickerView picker, nint row, nint component)
			{
				if (this.PickerChanged != null)
				{
					this.PickerChanged(this, new SchedulePickerChangedEventArgs{SelectedValue = values[(int)row]});
				}
			}
			#else
			public override int GetComponentCount (UIPickerView picker)
			{
			return 1;
			}

			public override int GetRowsInComponent (UIPickerView picker, int component)
			{
			return values.Count;
			}

			public override string GetTitle (UIPickerView picker, int row, int component)
			{
			return values[(int)row];
			}

			public override nfloat GetRowHeight (UIPickerView picker, int component)
			{
			return 30f;
			}

			public override void Selected (UIPickerView picker, int row, int component)
			{
			if (this.PickerChanged != null)
			{
			this.PickerChanged(this, new SchedulePickerChangedEventArgs{SelectedValue = values[(int)row]});
			}
			}
			#endif
		}

		public class SchedulePickerChangedEventArgs : EventArgs
		{
			public string SelectedValue {get; set;}
		}


	}
}

