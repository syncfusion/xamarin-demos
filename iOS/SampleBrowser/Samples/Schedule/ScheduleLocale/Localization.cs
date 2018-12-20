#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.iOS;
using System.Collections.ObjectModel;
using Foundation;
using UIKit;
using CoreGraphics;

namespace SampleBrowser
{
	public class Localization : SampleView
	{
		private SFSchedule schedule;

        public static UITableView AppView
        {
            get;
            set;
        }

		private readonly IList<string> languages = new List<string>();
		private string localisationLanguages;
		private UIPickerView scheduleTypePicker = new UIPickerView();
		private UILabel label = new UILabel();
		private UIButton button = new UIButton(), textbutton = new UIButton();
        private ScheduleLocalViewModel viewModel;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Localization()
		{
			schedule = new SFSchedule();
            viewModel = new ScheduleLocalViewModel();
            label.Text = "Select the Locale";
			label.TextColor = UIColor.Black;
			this.AddSubview(label); 
			textbutton.SetTitle("French", UIControlState.Normal);
			textbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton.BackgroundColor = UIColor.Clear;
			textbutton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			textbutton.Hidden = false;
			textbutton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			textbutton.Layer.BorderWidth = 4;
			textbutton.Layer.CornerRadius = 8;
			textbutton.TouchUpInside += ShowPicker;
			this.AddSubview(textbutton);

			button.SetTitle("Done\t", UIControlState.Normal);
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			button.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			button.SetTitleColor(UIColor.Black, UIControlState.Normal);
			button.Hidden = true;
			button.TouchUpInside += HidePicker;

			schedule.Locale = new NSLocale("fr-FR");
			schedule.ItemsSource = GetFrenchAppointments();
			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			this.AddSubview(schedule);

			AppView = new UITableView();
			AppView.RegisterClassForCellReuse(typeof(UITableViewCell), "Cell"); 
			this.AddSubview(AppView);

			this.languages.Add((NSString)"French");
			this.languages.Add((NSString)"Spanish");
			this.languages.Add((NSString)"English");
			this.languages.Add((NSString)"Chinese");

			SchedulePickerModel model = new SchedulePickerModel(this.languages);
			model.PickerChanged += (sender, e) =>
			{
				this.localisationLanguages = e.SelectedValue;
				textbutton.SetTitle(localisationLanguages, UIControlState.Normal);
				if (localisationLanguages == "French")
				{
					schedule.Locale = new NSLocale("fr-FR");
					schedule.ItemsSource = GetFrenchAppointments();
				}
				else if (localisationLanguages == "Spanish")
				{
					schedule.Locale = new NSLocale("es-AR");
					schedule.ItemsSource = GetSpanishAppointments();
				}
				else if (localisationLanguages == "English")
				{
					schedule.Locale = new NSLocale("en-US");
					schedule.ItemsSource = GetEnglishAppointments();
				}
				else if (localisationLanguages == "Chinese")
				{
					schedule.Locale = new NSLocale("zh-CN");
					schedule.ItemsSource = GetChineseAppointments();
				}
			};
			scheduleTypePicker.ShowSelectionIndicator = true;
			scheduleTypePicker.Hidden = true;
			scheduleTypePicker.Model = model;
			scheduleTypePicker.BackgroundColor = UIColor.White; 
			this.OptionView = new UIView();
		} 

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (schedule != null)
				{
					this.schedule.Dispose();
					this.schedule = null;
				}

				if (textbutton != null)
				{
					textbutton.TouchUpInside -= ShowPicker;
					textbutton.Dispose();
					textbutton = null;
				}

				if (button != null)
				{
					button.TouchUpInside -= HidePicker;
					button.Dispose();
					button = null;
				}

                if(scheduleTypePicker != null)
                {
                    scheduleTypePicker.Dispose();
                    scheduleTypePicker = null;
                }

                if (label != null)
                {
                    label.Dispose();
                    label = null;
                }
            }

			base.Dispose(disposing);
		}

		private void ShowPicker(object sender, EventArgs e)
		{
			button.Hidden = false;
			scheduleTypePicker.Hidden = false;
			this.BecomeFirstResponder();
		}

		private void HidePicker(object sender, EventArgs e)
		{
			button.Hidden = true;
			scheduleTypePicker.Hidden = true;
			this.BecomeFirstResponder();
		}

		private ObservableCollection<ScheduleAppointment> GetFrenchAppointments()
		{
			NSDate today = new NSDate();
            viewModel.SetColors();
            viewModel.SetFrenchCollectionSubjects();
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
				appointment.Subject = (NSString)viewModel.FrenchCollection[i];
				appointment.AppointmentBackground = viewModel.ColorCollection[i];

				appCollection.Add(appointment);
			}

			return appCollection;
		}

		private ObservableCollection<ScheduleAppointment> GetSpanishAppointments()
		{
			NSDate today = new NSDate();
            viewModel.SetColors();
            viewModel.SetSpanishCollectionSubjects();
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
				appointment.Subject = (NSString)viewModel.SpanishCollection[i];
				appointment.AppointmentBackground = viewModel.ColorCollection[i];

				appCollection.Add(appointment);
			}

			return appCollection;
		}

		private ObservableCollection<ScheduleAppointment> GetEnglishAppointments()
		{
			NSDate today = new NSDate();
            viewModel.SetColors();
            viewModel.SetEnglishCollectionSubjects();
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
				appointment.Subject = (NSString)viewModel.EnglishCollection[i];
				appointment.AppointmentBackground = viewModel.ColorCollection[i];

				appCollection.Add(appointment);
			}

			return appCollection;
		}

		private ObservableCollection<ScheduleAppointment> GetChineseAppointments()
		{
			NSDate today = new NSDate();
            viewModel.SetColors();
            viewModel.SetChineseCollectionSubjects();
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
				appointment.Subject = (NSString)viewModel.ChineseCollection[i];
				appointment.AppointmentBackground = viewModel.ColorCollection[i];

				appCollection.Add(appointment);
			}

			return appCollection;
		}

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
						textbutton.Frame = new CGRect(10, label.Frame.Size.Height + label.Frame.Y, this.Frame.Size.Width - 20, 40);
						button.Frame = new CGRect(this.Frame.X + 10, textbutton.Frame.Y + textbutton.Frame.Size.Height, this.Frame.Size.Width - 20, 30);
						scheduleTypePicker.Frame = new CGRect(0, button.Frame.Y + button.Frame.Size.Height, this.Frame.Size.Width, 100);
					}
					else
					{
						schedule.WeekViewSettings.WorkStartHour = 7;
						schedule.WeekViewSettings.WorkEndHour = 18;
						label.Frame = new CGRect(15, 10, this.Frame.Size.Width - 20, 30);
						textbutton.Frame = new CGRect(10, 40, this.Frame.Size.Width / 2.5, 30);
						button.Frame = new CGRect(this.Frame.X + 10, 80, this.Frame.Size.Width / 2.5, 30);
						scheduleTypePicker.Frame = new CGRect(0, 100, this.Frame.Size.Width / 2.5, 200);
					}
				}
			}

			base.LayoutSubviews();
			this.CreateOptionView();
		}
        
		public class SchedulePickerModel : UIPickerViewModel
		{
			private readonly IList<string> values;

			public event EventHandler<SchedulePickerChangedEventArgs> PickerChanged;

			public SchedulePickerModel(IList<string> values)
			{
				this.values = values;
			} 

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
		}

		public class SchedulePickerChangedEventArgs : EventArgs
		{
			public string SelectedValue { get; set; }
		}

		private void CreateOptionView()
		{
			this.OptionView.AddSubview(label);
			this.OptionView.AddSubview(textbutton);
			this.OptionView.AddSubview(scheduleTypePicker);
			this.OptionView.AddSubview(button);
		} 
	}
}