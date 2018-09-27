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

namespace SampleBrowser.SfSchedule
{
	[Preserve(AllMembers = true)]
	public class LocalizationViewModel
	{
		#region Properties
        public ScheduleAppointmentCollection JapaneseAppointments { get; set; }
        public ScheduleAppointmentCollection EnglishAppointments { get; set; }
        public ScheduleAppointmentCollection FrenchAppointments { get; set; }
        public ScheduleAppointmentCollection SpanishAppointments { get; set; }

        List<string> JapaneseCollection;
        List<string> EnglishCollection;
        List<string> FrenchCollection;
        List<string> SpanishCollection;
		
        List<Color> color_collection;
		List<DateTime> start_time_collection;
		List<DateTime> end_time_collection;

		#endregion Properties

		#region Constructor
		public LocalizationViewModel()
		{
			JapaneseAppointments = new ScheduleAppointmentCollection();
            EnglishAppointments = new ScheduleAppointmentCollection();
            FrenchAppointments = new ScheduleAppointmentCollection();
            SpanishAppointments = new ScheduleAppointmentCollection();

			CreateRandomNumbersCollection();
			CreateStartTimeCollection();
			CreateEndTimeCollection();
            CreateColorCollection();

            AddJapaneseLanguageString();
            AddEnglishLanguageString();
            AddFrenchLanguageString();
            AddSpanishLanguageString();

            GetJapaneseAppoitments(10);
            GetFrenchAppoitments(10);
            GetEnglishAppoitments(10);
            GetSpanishAppoitments(10);
		}

        #endregion Constructor

        #region Methods

        #region Appointments collection

        /// <summary>
        /// Gets the japanese appoitments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetJapaneseAppoitments(int count)
		{
			for (int i = 0; i < count; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = color_collection[i];
				scheduleAppointment.Subject = JapaneseCollection[i];
				scheduleAppointment.StartTime = start_time_collection[i];
				scheduleAppointment.EndTime = end_time_collection[i];
				JapaneseAppointments.Add(scheduleAppointment);
			}

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "ジェニーの誕生日";
            allDayAppointment.StartTime = start_time_collection[5];
            allDayAppointment.EndTime = end_time_collection[5];
            allDayAppointment.IsAllDay = true;
            JapaneseAppointments.Add(allDayAppointment);
		}

        /// <summary>
        /// Gets the english appoitments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetEnglishAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = color_collection[i];
                scheduleAppointment.Subject = EnglishCollection[i];
                scheduleAppointment.StartTime = start_time_collection[i];
                scheduleAppointment.EndTime = end_time_collection[i];
                EnglishAppointments.Add(scheduleAppointment);
            }

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "Jeni's Birthday";
            allDayAppointment.StartTime = start_time_collection[5];
            allDayAppointment.EndTime = end_time_collection[5];
            allDayAppointment.IsAllDay = true;
            EnglishAppointments.Add(allDayAppointment);
        }

        /// <summary>
        /// Gets the french appoitments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetFrenchAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = color_collection[i];
                scheduleAppointment.Subject = FrenchCollection[i];
                scheduleAppointment.StartTime = start_time_collection[i];
                scheduleAppointment.EndTime = end_time_collection[i];
                FrenchAppointments.Add(scheduleAppointment);
            }

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "L'anniversaire de Jeni";
            allDayAppointment.StartTime = start_time_collection[5];
            allDayAppointment.EndTime = end_time_collection[5];
            allDayAppointment.IsAllDay = true;
            FrenchAppointments.Add(allDayAppointment);
        }

        /// <summary>
        /// Gets the spanish appoitments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetSpanishAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = color_collection[i];
                scheduleAppointment.Subject = SpanishCollection[i];
                scheduleAppointment.StartTime = start_time_collection[i];
                scheduleAppointment.EndTime = end_time_collection[i];
                SpanishAppointments.Add(scheduleAppointment);
            }

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "Cumpleaños de Jeni";
            allDayAppointment.StartTime = start_time_collection[5];
            allDayAppointment.EndTime = end_time_collection[5];
            allDayAppointment.IsAllDay = true;
            SpanishAppointments.Add(allDayAppointment);
        }

        #endregion Appointments collection

        #region Language String

        private void AddJapaneseLanguageString()
		{
			JapaneseCollection = new List<string>();
			JapaneseCollection.Add("会議に行く");
			JapaneseCollection.Add("ビジネスミーティング");
			JapaneseCollection.Add("会議");
			JapaneseCollection.Add("議論ドラフト法");
			JapaneseCollection.Add("監査");
			JapaneseCollection.Add("顧客会議");
			JapaneseCollection.Add("レポートを生成する");
			JapaneseCollection.Add("対象会議");
			JapaneseCollection.Add("総会");
			JapaneseCollection.Add("ステータスの更新");
			JapaneseCollection.Add("プロジェクト計画");
		}

        private void AddEnglishLanguageString()
        {
            EnglishCollection = new List<string>();
            EnglishCollection.Add("GoToMeeting");
            EnglishCollection.Add("Business Meeting");
            EnglishCollection.Add("Conference");
            EnglishCollection.Add("Project Status Discussion");
            EnglishCollection.Add("Auditing");
            EnglishCollection.Add("Client Meeting");
            EnglishCollection.Add("Generate Report");
            EnglishCollection.Add("Target Meeting");
            EnglishCollection.Add("General Meeting");
            EnglishCollection.Add("Pay House Rent");
            EnglishCollection.Add("Car Service");
        }

        private void AddFrenchLanguageString()
        {
            FrenchCollection = new List<string>();
            FrenchCollection.Add("aller ‡ la rÈunion");
            FrenchCollection.Add("Un rendez-vous d'affaire");
            FrenchCollection.Add("ConfÈrence");
            FrenchCollection.Add("Discussion Projet de Statut");
            FrenchCollection.Add("audit");
            FrenchCollection.Add("RÈunion du client");
            FrenchCollection.Add("gÈnÈrer un rapport");
            FrenchCollection.Add("RÈunion cible");
            FrenchCollection.Add("AssemblÈe gÈnÈrale");
            FrenchCollection.Add("Pay Maison Louer");
            FrenchCollection.Add("Service automobile");
        }

        private void AddSpanishLanguageString()
        {
            SpanishCollection = new List<string>();
            SpanishCollection.Add("Ir a la reuniÛn");
            SpanishCollection.Add("ReuniÛn de negocios");
            SpanishCollection.Add("Conferencia");
            SpanishCollection.Add("SituaciÛn del proyecto DiscusiÛn");
            SpanishCollection.Add("AuditorÌa");
            SpanishCollection.Add("ReuniÛn Cliente");
            SpanishCollection.Add("Generar informe");
            SpanishCollection.Add("ReuniÛn Target");
            SpanishCollection.Add("ReuniÛn general");
            SpanishCollection.Add("Pago Casa Alquilar");
            SpanishCollection.Add("Servicio de auto");
        }

        #endregion 

        #region creating color collection

        //creating color collection
        private void CreateColorCollection()
		{
			color_collection = new List<Color>();
			color_collection.Add(Color.FromHex("#FFA2C139"));
			color_collection.Add(Color.FromHex("#FFD80073"));
			color_collection.Add(Color.FromHex("#FF1BA1E2"));
			color_collection.Add(Color.FromHex("#FFE671B8"));
			color_collection.Add(Color.FromHex("#FFF09609"));
			color_collection.Add(Color.FromHex("#FF339933"));
			color_collection.Add(Color.FromHex("#FF00ABA9"));
			color_collection.Add(Color.FromHex("#FFE671B8"));
			color_collection.Add(Color.FromHex("#FF1BA1E2"));
			color_collection.Add(Color.FromHex("#FFD80073"));
			color_collection.Add(Color.FromHex("#FFA2C139"));
			color_collection.Add(Color.FromHex("#FFA2C139"));
			color_collection.Add(Color.FromHex("#FFD80073"));
			color_collection.Add(Color.FromHex("#FF339933"));
			color_collection.Add(Color.FromHex("#FFE671B8"));
			color_collection.Add(Color.FromHex("#FF00ABA9"));
		}

		#endregion creating color collection

		#region CreateRandomNumbersCollection

		//creating random number collection
		List<int> randomNums = new List<int>();
		private void CreateRandomNumbersCollection()
		{
			randomNums = new List<int>();

			Random rand = new Random();

			for (int i = 0; i < 10; i++)
			{
				int random = rand.Next(9, 15);
				randomNums.Add(random);
			}
		}

		#endregion CreateRandomNumbersCollection

		#region CreateStartTimeCollection

		// creating StartTime collection
		private void CreateStartTimeCollection()
		{
			start_time_collection = new List<DateTime>();
			DateTime currentDate = DateTime.Now;

			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, randomNums[count], 0, 0);
				DateTime startDateTime = startTime.AddDays(i);
				start_time_collection.Add(startDateTime);
				count++;
			}
		}

		#endregion CreateStartTimeCollection

		#region CreateEndTimeCollection

		//  creating EndTime collection
		private void CreateEndTimeCollection()
		{
			end_time_collection = new List<DateTime>();
			DateTime currentDate = DateTime.Now;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, randomNums[count] + 1, 0, 0);
				DateTime endDateTime = endTime.AddDays(i);
				end_time_collection.Add(endDateTime);
				count++;
			}
		}

		#endregion CreateEndTimeCollection

		#endregion Methods

	}
}


