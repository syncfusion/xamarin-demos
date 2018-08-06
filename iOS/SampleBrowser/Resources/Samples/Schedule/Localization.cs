#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.iOS;

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
	public class Localization : SampleView
	{
		SFSchedule schedule;
		public static UITableView appView;

		private readonly IList<string> languages = new List<string>();
		private string localisation_Languages;
		UIPickerView scheduleTypePicker = new UIPickerView();
		UILabel label = new UILabel();
		UIButton button = new UIButton();
		UIButton textbutton = new UIButton();

		public Localization()
		{
			schedule = new SFSchedule();

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
			schedule.Appointments = getFrenchAppointments();
			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			this.AddSubview(schedule);

			appView = new UITableView();
			appView.RegisterClassForCellReuse(typeof(UITableViewCell), "Cell");

			this.AddSubview(appView);

			this.languages.Add((NSString)"French");
			this.languages.Add((NSString)"Spanish");
			this.languages.Add((NSString)"English");
			this.languages.Add((NSString)"Chinese");

			SchedulePickerModel model = new SchedulePickerModel(this.languages);
			model.PickerChanged += (sender, e) =>
			{
				this.localisation_Languages = e.SelectedValue;
				textbutton.SetTitle(localisation_Languages, UIControlState.Normal);
				if (localisation_Languages == "French")
				{
					schedule.Locale = new NSLocale("fr-FR");
					schedule.Appointments = getFrenchAppointments();
				}
				else if (localisation_Languages == "Spanish")
				{
					schedule.Locale = new NSLocale("es-AR");
					schedule.Appointments = getSpanishAppointments();
				}
				else if (localisation_Languages == "English")
				{
					schedule.Locale = new NSLocale("en-US");
					schedule.Appointments = getEnglishAppointments();
				}
				else if (localisation_Languages == "Chinese")
				{
					schedule.Locale = new NSLocale("zh-CN");
					schedule.Appointments = getChineseAppointments();
				}
			};
			scheduleTypePicker.ShowSelectionIndicator = true;
			scheduleTypePicker.Hidden = true;
			scheduleTypePicker.Model = model;
			scheduleTypePicker.BackgroundColor = UIColor.White;
			//control = this;
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
			}
			base.Dispose(disposing);
		}

		void ShowPicker(object sender, EventArgs e)
		{

			button.Hidden = false;
			scheduleTypePicker.Hidden = false;
			this.BecomeFirstResponder();
		}

		void HidePicker(object sender, EventArgs e)
		{

			button.Hidden = true;
			scheduleTypePicker.Hidden = true;
			this.BecomeFirstResponder();
		}

		NSMutableArray getFrenchAppointments()
		{
			NSDate today = new NSDate();
			setColors();
			setFrenchCollectionSubjects();
			NSMutableArray appCollection = new NSMutableArray();
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
				appointment.Subject = (NSString)frenchCollection[i];
				appointment.AppointmentBackground = colorCollection[i];

				appCollection.Add(appointment);
			}
			return appCollection;
		}

		NSMutableArray getSpanishAppointments()
		{
			NSDate today = new NSDate();
			setColors();
			setSpanishCollectionSubjects();
			NSMutableArray appCollection = new NSMutableArray();
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
				appointment.Subject = (NSString)spanishCollection[i];
				appointment.AppointmentBackground = colorCollection[i];

				appCollection.Add(appointment);
			}
			return appCollection;
		}

		NSMutableArray getEnglishAppointments()
		{
			NSDate today = new NSDate();
			setColors();
			setEnglishCollectionSubjects();
			NSMutableArray appCollection = new NSMutableArray();
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
				appointment.Subject = (NSString)englishCollection[i];
				appointment.AppointmentBackground = colorCollection[i];

				appCollection.Add(appointment);
			}
			return appCollection;
		}

		NSMutableArray getChineseAppointments()
		{
			NSDate today = new NSDate();
			setColors();
			setChineseCollectionSubjects();
			NSMutableArray appCollection = new NSMutableArray();
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
				appointment.Subject = (NSString)chineseCollection[i];
				appointment.AppointmentBackground = colorCollection[i];

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
					view.Frame = new CGRect(this.Frame.X, 0, Frame.Size.Width, (Frame.Size.Height));
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

		List<string> englishCollection;
		private void setEnglishCollectionSubjects()
		{
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

		List<string> frenchCollection;
		private void setFrenchCollectionSubjects()
		{
			frenchCollection = new List<string>();
			frenchCollection.Add("aller ‡ la rÈunion");
			frenchCollection.Add("Un rendez-vous d'affaire");
			frenchCollection.Add("ConfÈrence");
			frenchCollection.Add("Discussion Projet de Statut");
			frenchCollection.Add("audit");
			frenchCollection.Add("RÈunion du client");
			frenchCollection.Add("gÈnÈrer un rapport");
			frenchCollection.Add("RÈunion cible");
			frenchCollection.Add("AssemblÈe gÈnÈrale");
			frenchCollection.Add("Pay Maison Louer");
			frenchCollection.Add("Service automobile");
			frenchCollection.Add("Visite mÈdicale");
			frenchCollection.Add("Anniversaire de mariage");
			frenchCollection.Add("Anniversaire de Sam");
			frenchCollection.Add("Anniversaire de Jenny");
			frenchCollection.Add("Checkup Master");
			frenchCollection.Add("HÙpital");
			frenchCollection.Add("TÈlÈphone paiement de factures");
			frenchCollection.Add("Plan de projet");
			frenchCollection.Add("audit");
			frenchCollection.Add("RÈunion du client");
			frenchCollection.Add("gÈnÈrer un rapport");
			frenchCollection.Add("RÈunion cible");
			frenchCollection.Add("AssemblÈe gÈnÈrale");
			frenchCollection.Add("Jouer au golf");
			frenchCollection.Add("Service automobile");
			frenchCollection.Add("Visite mÈdicale");
			frenchCollection.Add("Anniversaire de Marie");
			frenchCollection.Add("Anniversaire de John");
			frenchCollection.Add("Anniversaire de Micheal");
		}

		List<string> spanishCollection;
		private void setSpanishCollectionSubjects()
		{
			spanishCollection = new List<string>();
			spanishCollection.Add("Ir a la reuniÛn");
			spanishCollection.Add("ReuniÛn de negocios");
			spanishCollection.Add("Conferencia");
			spanishCollection.Add("SituaciÛn del proyecto DiscusiÛn");
			spanishCollection.Add("AuditorÌa");
			spanishCollection.Add("ReuniÛn Cliente");
			spanishCollection.Add("Generar informe");
			spanishCollection.Add("ReuniÛn Target");
			spanishCollection.Add("ReuniÛn general");
			spanishCollection.Add("Pago Casa Alquilar");
			spanishCollection.Add("Servicio de auto");
			spanishCollection.Add("RevisiÛn mÈdica");
			spanishCollection.Add("Aniversario de bodas");
			spanishCollection.Add("CumpleaÒos de Sam");
			spanishCollection.Add("El cumpleaÒos de Jenny");
			spanishCollection.Add("Chequeo Maestro");
			spanishCollection.Add("el Hospital");
			spanishCollection.Add("TelÈfono pago de facturas");
			spanishCollection.Add("Plan de proyecto");
			spanishCollection.Add("AuditorÌa");
			spanishCollection.Add("ReuniÛn Cliente");
			spanishCollection.Add("Generar informe");
			spanishCollection.Add("ReuniÛn Target");
			spanishCollection.Add("ReuniÛn general");
			spanishCollection.Add("Jugar golf");
			spanishCollection.Add("Servicio de auto");
			spanishCollection.Add("RevisiÛn mÈdica");
			spanishCollection.Add("CumpleaÒos de MarÌa");
			spanishCollection.Add("John CumpleaÒos");
			spanishCollection.Add("El cumpleaÒos de Micheal");
		}

		List<string> chineseCollection;
		private void setChineseCollectionSubjects()
		{
			chineseCollection = new List<string>();
			chineseCollection.Add("进入会议");
			chineseCollection.Add("商务会议");
			chineseCollection.Add("会议");
			chineseCollection.Add("项目状态讨论");
			chineseCollection.Add("审计");
			chineseCollection.Add("客户会议");
			chineseCollection.Add("生成报告");
			chineseCollection.Add("目标会议");
			chineseCollection.Add("大会");
			chineseCollection.Add("支付房租");
			chineseCollection.Add("汽车服务");
			chineseCollection.Add("体格检查");
			chineseCollection.Add("结婚纪念日");
			chineseCollection.Add("萨姆的生日");
			chineseCollection.Add("珍妮的生日");
			chineseCollection.Add("主诊");
			chineseCollection.Add("医院");
			chineseCollection.Add("电话缴费");
			chineseCollection.Add("项目计划");
			chineseCollection.Add("审计");
			chineseCollection.Add("客户会议");
			chineseCollection.Add("生成报告");
			chineseCollection.Add("目标会议");
			chineseCollection.Add("大会");
			chineseCollection.Add("打高尔夫球");
			chineseCollection.Add("汽车服务");
			chineseCollection.Add("体格检查");
			chineseCollection.Add("玛丽的生日");
			chineseCollection.Add("约翰的生日");
			chineseCollection.Add("迈克尔的生日");
		}

		// adding colors collection
		List<UIColor> colorCollection;
		private void setColors()
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


		private void CreateOptionView()
		{
			this.OptionView.AddSubview(label);
			this.OptionView.AddSubview(textbutton);
			this.OptionView.AddSubview(scheduleTypePicker);
			this.OptionView.AddSubview(button);
		}


	}
}

