#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    /// <summary>
    /// Localization View Model class
    /// </summary>
	[Preserve(AllMembers = true)]
	public class LocalizationViewModel
	{
		#region Properties

        /// <summary>
        /// japanese collection
        /// </summary>
        private List<string> japaneseCollection;

        /// <summary>
        /// english collection
        /// </summary>
        private List<string> englishCollection;

        /// <summary>
        /// french collection
        /// </summary>
        private List<string> frenchCollection;

        /// <summary>
        /// spanish collection
        /// </summary>
        private List<string> spanishCollection;
		
        /// <summary>
        /// color collection
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// start time collection
        /// </summary>
		private List<DateTime> startTimeCollection;

        /// <summary>
        /// end time collection
        /// </summary>
		private List<DateTime> endTimeCollection;

        /// <summary>
        /// random numbers
        /// </summary>
        private List<int> randomNums = new List<int>();

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationViewModel" /> class.
        /// </summary>
        public LocalizationViewModel()
		{
			this.JapaneseAppointments = new ScheduleAppointmentCollection();
            this.EnglishAppointments = new ScheduleAppointmentCollection();
            this.FrenchAppointments = new ScheduleAppointmentCollection();
            this.SpanishAppointments = new ScheduleAppointmentCollection();

            this.CreateRandomNumbersCollection();
            this.CreateStartTimeCollection();
            this.CreateEndTimeCollection();
            this.CreateColorCollection();

            this.AddJapaneseLanguageString();
            this.AddEnglishLanguageString();
            this.AddFrenchLanguageString();
            this.AddSpanishLanguageString();

            this.GetJapaneseAppoitments(10);
            this.GetFrenchAppoitments(10);
            this.GetEnglishAppoitments(10);
            this.GetSpanishAppoitments(10);
		}

        #endregion Constructor

        /// <summary>
        /// Gets or sets japanese appointments
        /// </summary>
        public ScheduleAppointmentCollection JapaneseAppointments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets english appointment
        /// </summary>
        public ScheduleAppointmentCollection EnglishAppointments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets french appointments
        /// </summary>
        public ScheduleAppointmentCollection FrenchAppointments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets spanish appointments
        /// </summary>
        public ScheduleAppointmentCollection SpanishAppointments
        {
            get;
            set;
        }

        #region Methods

        #region Appointments collection

        /// <summary>
        /// Gets the japanese appointments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetJapaneseAppoitments(int count)
		{
			for (int i = 0; i < count; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = this.colorCollection[i];
				scheduleAppointment.Subject = this.japaneseCollection[i];
				scheduleAppointment.StartTime = this.startTimeCollection[i];
				scheduleAppointment.EndTime = this.endTimeCollection[i];
                this.JapaneseAppointments.Add(scheduleAppointment);
			}

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "ジェニーの誕生日";
            allDayAppointment.StartTime = this.startTimeCollection[5];
            allDayAppointment.EndTime = this.endTimeCollection[5];
            allDayAppointment.IsAllDay = true;
            this.JapaneseAppointments.Add(allDayAppointment);
		}

        /// <summary>
        /// Gets the english appointments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetEnglishAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = this.colorCollection[i];
                scheduleAppointment.Subject = this.englishCollection[i];
                scheduleAppointment.StartTime = this.startTimeCollection[i];
                scheduleAppointment.EndTime = this.endTimeCollection[i];
                this.EnglishAppointments.Add(scheduleAppointment);
            }

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "Jeni's Birthday";
            allDayAppointment.StartTime = this.startTimeCollection[5];
            allDayAppointment.EndTime = this.endTimeCollection[5];
            allDayAppointment.IsAllDay = true;
            this.EnglishAppointments.Add(allDayAppointment);
        }

        /// <summary>
        /// Gets the french appointments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetFrenchAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = this.colorCollection[i];
                scheduleAppointment.Subject = this.frenchCollection[i];
                scheduleAppointment.StartTime = this.startTimeCollection[i];
                scheduleAppointment.EndTime = this.endTimeCollection[i];
                this.FrenchAppointments.Add(scheduleAppointment);
            }

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "L'anniversaire de Jeni";
            allDayAppointment.StartTime = this.startTimeCollection[5];
            allDayAppointment.EndTime = this.endTimeCollection[5];
            allDayAppointment.IsAllDay = true;
            this.FrenchAppointments.Add(allDayAppointment);
        }

        /// <summary>
        /// Gets the spanish appointments.
        /// </summary>
        /// <param name="count">Count value.</param>
        private void GetSpanishAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = this.colorCollection[i];
                scheduleAppointment.Subject = this.spanishCollection[i];
                scheduleAppointment.StartTime = this.startTimeCollection[i];
                scheduleAppointment.EndTime = this.endTimeCollection[i];
                this.SpanishAppointments.Add(scheduleAppointment);
            }

            // AllDay Appointment in current day
            ScheduleAppointment allDayAppointment = new ScheduleAppointment();
            allDayAppointment.Color = Color.FromHex("#FFD80073");
            allDayAppointment.Subject = "Cumpleaños de Jeni";
            allDayAppointment.StartTime = this.startTimeCollection[5];
            allDayAppointment.EndTime = this.endTimeCollection[5];
            allDayAppointment.IsAllDay = true;
            this.SpanishAppointments.Add(allDayAppointment);
        }

        #endregion Appointments collection

        #region Language String

        /// <summary>
        /// Japanese appointment collection
        /// </summary>
        private void AddJapaneseLanguageString()
		{
            this.japaneseCollection = new List<string>();
            this.japaneseCollection.Add("会議に行く");
            this.japaneseCollection.Add("ビジネスミーティング");
            this.japaneseCollection.Add("会議");
            this.japaneseCollection.Add("議論ドラフト法");
            this.japaneseCollection.Add("監査");
            this.japaneseCollection.Add("顧客会議");
            this.japaneseCollection.Add("レポートを生成する");
            this.japaneseCollection.Add("対象会議");
            this.japaneseCollection.Add("総会");
            this.japaneseCollection.Add("ステータスの更新");
            this.japaneseCollection.Add("プロジェクト計画");
		}

        /// <summary>
        /// English appointment collection
        /// </summary>
        private void AddEnglishLanguageString()
        {
            this.englishCollection = new List<string>();
            this.englishCollection.Add("GoToMeeting");
            this.englishCollection.Add("Business Meeting");
            this.englishCollection.Add("Conference");
            this.englishCollection.Add("Project Status Discussion");
            this.englishCollection.Add("Auditing");
            this.englishCollection.Add("Client Meeting");
            this.englishCollection.Add("Generate Report");
            this.englishCollection.Add("Target Meeting");
            this.englishCollection.Add("General Meeting");
            this.englishCollection.Add("Pay House Rent");
            this.englishCollection.Add("Car Service");
        }

        /// <summary>
        /// french appointment collection
        /// </summary>
        private void AddFrenchLanguageString()
        {
            this.frenchCollection = new List<string>();
            this.frenchCollection.Add("aller ‡ la rÈunion");
            this.frenchCollection.Add("Un rendez-vous d'affaire");
            this.frenchCollection.Add("ConfÈrence");
            this.frenchCollection.Add("Discussion Projet de Statut");
            this.frenchCollection.Add("audit");
            this.frenchCollection.Add("RÈunion du client");
            this.frenchCollection.Add("gÈnÈrer un rapport");
            this.frenchCollection.Add("RÈunion cible");
            this.frenchCollection.Add("AssemblÈe gÈnÈrale");
            this.frenchCollection.Add("Pay Maison Louer");
            this.frenchCollection.Add("Service automobile");
        }

        /// <summary>
        /// spanish appointment collection
        /// </summary>
        private void AddSpanishLanguageString()
        {
            this.spanishCollection = new List<string>();
            this.spanishCollection.Add("Ir a la reuniÛn");
            this.spanishCollection.Add("ReuniÛn de negocios");
            this.spanishCollection.Add("Conferencia");
            this.spanishCollection.Add("SituaciÛn del proyecto DiscusiÛn");
            this.spanishCollection.Add("AuditorÌa");
            this.spanishCollection.Add("ReuniÛn Cliente");
            this.spanishCollection.Add("Generar informe");
            this.spanishCollection.Add("ReuniÛn Target");
            this.spanishCollection.Add("ReuniÛn general");
            this.spanishCollection.Add("Pago Casa Alquilar");
            this.spanishCollection.Add("Servicio de auto");
        }

        #endregion 

        #region creating color collection

        /// <summary>
        /// color collection
        /// </summary>
        ////creating color collection
        private void CreateColorCollection()
		{
            this.colorCollection = new List<Color>();
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FFF09609"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
		}

		#endregion creating color collection

		#region CreateRandomNumbersCollection

        /// <summary>
        /// random number collection
        /// </summary>
        ////creating random number collection
        private void CreateRandomNumbersCollection()
		{
            this.randomNums = new List<int>();

			Random rand = new Random();

			for (int i = 0; i < 10; i++)
			{
				int random = rand.Next(9, 15);
                this.randomNums.Add(random);
			}
		}

		#endregion CreateRandomNumbersCollection

		#region CreateStartTimeCollection
        /// <summary>
        /// start time collection
        /// </summary>
		//// creating StartTime collection
		private void CreateStartTimeCollection()
		{
            this.startTimeCollection = new List<DateTime>();
			DateTime currentDate = DateTime.Now;

			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count], 0, 0);
				DateTime startDateTime = startTime.AddDays(i);
                this.startTimeCollection.Add(startDateTime);
				count++;
			}
		}

		#endregion CreateStartTimeCollection

		#region CreateEndTimeCollection

        /// <summary>
        /// end time collection
        /// </summary>
		////  creating EndTime collection
		private void CreateEndTimeCollection()
		{
            this.endTimeCollection = new List<DateTime>();
			DateTime currentDate = DateTime.Now;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count] + 1, 0, 0);
				DateTime endDateTime = endTime.AddDays(i);
                this.endTimeCollection.Add(endDateTime);
				count++;
			}
		}

		#endregion CreateEndTimeCollection

		#endregion Methods
	}
}