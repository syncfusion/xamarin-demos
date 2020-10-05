#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Android.Views;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using Android.Graphics;
using Java.Util;

namespace SampleBrowser
{
	public class Localization : SamplePage, IDisposable
	{
		public Localization()
		{
		}

		private SfSchedule sfSchedule;
		private Spinner spinner;
		private LinearLayout propertylayout;

		public override View GetSampleContent(Context context)
		{
			LinearLayout linearLayout = new LinearLayout(context);
			linearLayout.Orientation = Orientation.Vertical;
			propertylayout = new LinearLayout(context);
			propertylayout = SetOptionPage(context);
			
            //creating instance for Schedule
			sfSchedule = new SfSchedule(context);

			sfSchedule.ScheduleView = ScheduleView.WeekView;
			sfSchedule.Locale = new Locale("fr");
			SetFrenchCollectionSubjects();
			SetChineseCollectionSubjects();
			SetEnglishCollectionSubjects();
			SetSpanishCollectionSubjects();
			SetColors();
			RandomNumbers();
			SetStartTime();
			SetEndTime();
			sfSchedule.LayoutParameters = new FrameLayout.LayoutParams(
	LinearLayout.LayoutParams.MatchParent,
LinearLayout.LayoutParams.MatchParent);
			sfSchedule.ItemsSource = GetFrenchAppointments();
			linearLayout.AddView(sfSchedule);

			return linearLayout;
		}

		private LinearLayout SetOptionPage(Context context)
		{
			TextView scheduleType_txtBlock = new TextView(context);
			scheduleType_txtBlock.Text = "Select the Locale";
			scheduleType_txtBlock.TextSize = 20;
            scheduleType_txtBlock.SetPadding(0, 0, 0, 10);
			scheduleType_txtBlock.SetTextColor(Color.Black);
			LinearLayout layout = new LinearLayout(context);
			layout.SetPadding(15, 15, 15, 20);
			layout.Orientation = Android.Widget.Orientation.Vertical;
			layout.SetBackgroundColor(Color.White);

			spinner = new Spinner(context, SpinnerMode.Dialog);
			spinner.SetMinimumHeight(60);
			spinner.SetBackgroundColor(Color.Gray);
			spinner.DropDownWidth = 500;
			layout.AddView(scheduleType_txtBlock);
			layout.AddView(spinner);

			List<string> list = new List<string>();
			list.Add("French");
			list.Add("Spanish");
			list.Add("English");
			list.Add("Chinese");

			ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = dataAdapter;
			spinner.ItemSelected += Spinner_ItemSelected;

			return layout;
		}

		private List<string> colorCollection;
		private List<Calendar> startTimeCollection;
		private List<Calendar> endTimeCollection;

		//Creating appointments for ScheduleAppointmentCollection
		private ScheduleAppointmentCollection GetFrenchAppointments()
		{
			ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();
			for (int i = 0; i < 10; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
				scheduleAppointment.Subject = frenchCollection[i];
				scheduleAppointment.StartTime = startTimeCollection[i];
				scheduleAppointment.EndTime = endTimeCollection[i];
				appointmentCollection.Add(scheduleAppointment);
			}

			return appointmentCollection;
		}

		//Creating appointments for ScheduleAppointmentCollection
		private ScheduleAppointmentCollection GetSpanishAppointments()
		{
			ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();
			for (int i = 0; i < 10; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
				scheduleAppointment.Subject = spanishCollection[i];
				scheduleAppointment.StartTime = startTimeCollection[i];
				scheduleAppointment.EndTime = endTimeCollection[i];
				appointmentCollection.Add(scheduleAppointment);
			}

			return appointmentCollection;
		}

		//Creating appointments for ScheduleAppointmentCollection
		private ScheduleAppointmentCollection GetEnglishAppointments()
		{
			ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();
			for (int i = 0; i < 10; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
				scheduleAppointment.Subject = englishCollection[i];
				scheduleAppointment.StartTime = startTimeCollection[i];
				scheduleAppointment.EndTime = endTimeCollection[i];
				appointmentCollection.Add(scheduleAppointment);
			}

			return appointmentCollection;
		}

		//Creating appointments for ScheduleAppointmentCollection
		private ScheduleAppointmentCollection GetChineseAppointments()
		{
			ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();
			for (int i = 0; i < 10; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
				scheduleAppointment.Subject = chineseCollection[i];
				scheduleAppointment.StartTime = startTimeCollection[i];
				scheduleAppointment.EndTime = endTimeCollection[i];
				appointmentCollection.Add(scheduleAppointment);
			}

			return appointmentCollection;
		}

		private List<string> englishCollection;

		private void SetEnglishCollectionSubjects()
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

		private List<string> frenchCollection;

		private void SetFrenchCollectionSubjects()
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

		private List<string> spanishCollection;

		private void SetSpanishCollectionSubjects()
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

		private List<string> chineseCollection;

		private void SetChineseCollectionSubjects()
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
		private void SetColors()
		{
			colorCollection = new List<string>();
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
		}

		private List<int> randomNums;

		private void RandomNumbers()
		{
			randomNums = new List<int>();
			Java.Util.Random rand = new Java.Util.Random();
			for (int i = 0; i < 30; i++)
			{
				int randomNum = rand.NextInt((15 - 9) + 1) + 9;
				randomNums.Add(randomNum);
			}
		}
		
        // adding StartTime collection
		private void SetStartTime()
		{
			startTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				Calendar startTime = (Calendar)currentDate.Clone();
				startTime.Set(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[count],
					0,
					0);
				startTimeCollection.Add(startTime);
				count++;
			}
		}

		// adding EndTime collection
		private void SetEndTime()
		{
			endTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				Calendar endTime = (Calendar)currentDate.Clone();
				endTime.Set(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[count] + 1,
					0,
					0);
				endTimeCollection.Add(endTime);
				count++;
			}
		}

		//Creating Spinner
		public override View GetPropertyWindowLayout(Context context)
		{
			return propertylayout;
		}

		private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			if (e.Position == 0)
			{
				sfSchedule.Locale = new Locale("fr");
				sfSchedule.ItemsSource = GetFrenchAppointments();
			}
			else if (e.Position == 1)
			{
				sfSchedule.Locale = new Locale("es");
				sfSchedule.ItemsSource = GetSpanishAppointments();
			}
			else if (e.Position == 2)
			{
				sfSchedule.Locale = new Locale("en-US");
				sfSchedule.ItemsSource = GetEnglishAppointments();
			}
			else if (e.Position == 3)
			{
				sfSchedule.Locale = new Locale("zh");
				sfSchedule.ItemsSource = GetChineseAppointments();
			}
		}

		public override void OnApplyChanges()
		{
			base.OnApplyChanges();
		}

        public void Dispose()
        {
            if (sfSchedule != null)
            {
                sfSchedule.Dispose();
                sfSchedule = null;
            }

            if (spinner != null)
            {
                spinner.ItemSelected -= Spinner_ItemSelected;
                spinner.Dispose();
                spinner = null;
            }

            if (propertylayout != null)
            {
                propertylayout.Dispose();
                propertylayout = null;
            }
        }
    }
}