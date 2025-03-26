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
	public class CalendarBlackoutDates:SampleView
	{
		SFCalendar calendar1;
		public static UITableView appView;
		UIView calendarView = new UIView ();

		public CalendarBlackoutDates ()
		{
			//Calendar
			calendar1 = new SFCalendar ();
			calendar1.ViewMode = SFCalendarViewMode.SFCalendarViewModeMonth;
			calendar1.HeaderHeight = 40;
			this.AddSubview (calendar1);

			//Setting BlackOutDates
			NSDate today = new NSDate ();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components (
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			// Set the hour, minute, second

			calendar1.BlackoutDates = new NSMutableArray ();
		
				for (int i = 0; i < 5; i++) 
				{
					NSDate startDate = calendar.DateFromComponents (components);
					components.Day += 1;
					calendar1.BlackoutDates.Add (startDate);
				}

			appView = new UITableView ();
			appView.RegisterClassForCellReuse (typeof(UITableViewCell), "Cell");
			if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				calendarView.AddSubview (calendar1);
				this.AddSubview (calendarView);

			}
			this.AddSubview (appView);
		}


		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) 
			{
				if (view is SFCalendar) {
					view.Frame = new CGRect (this.Frame.X, -2, Frame.Size.Width, (Frame.Size.Height));
				}
				calendarView.Frame = new CGRect (0, 0,this.Frame.Size.Width, this.Frame.Size.Height);
				calendar1.Frame = new CGRect (0, 0, this.Frame.Size.Width, this.Frame.Size.Height);

			}
			base.LayoutSubviews ();
		}


		public class CalendarPickerModel : UIPickerViewModel
		{
			private readonly IList<string> values;

			public event EventHandler<CalendarPickerChangedEventArgs> PickerChanged;

			public CalendarPickerModel(IList<string> values)
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
					this.PickerChanged(this, new CalendarPickerChangedEventArgs{SelectedValue = values[(int)row]});
				}
			}
			#else
			#endif
		}

		public class CalendarPickerChangedEventArgs : EventArgs
		{
			public string SelectedValue {get; set;}
		}
			
	}
}

