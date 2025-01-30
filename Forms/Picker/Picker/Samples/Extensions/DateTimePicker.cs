#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SelectionChangedEventArgs = Syncfusion.SfPicker.XForms.SelectionChangedEventArgs;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Syncfusion.SfPicker.XForms;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;

namespace SampleBrowser.SfPicker
{
	public class CustomDateTimePicker : Syncfusion.SfPicker.XForms.SfPicker
	{
        public Dictionary<string, string> months;
        public ObservableCollection<object> Date { get; set; }
		public ObservableCollection<object> Day;
		public ObservableCollection<object> Month;
        public ObservableCollection<object> Year;
        public ObservableCollection<object> Minute;
		public ObservableCollection<object> Hour;

		public ObservableCollection<string> Headers { get; set; }
		public CustomDateTimePicker()
		{
            months = new Dictionary<string, string>();
			Date = new ObservableCollection<object>();
			Day = new ObservableCollection<object>();
			Month = new ObservableCollection<object>();
			Headers = new ObservableCollection<string>();
            Year = new ObservableCollection<object>();
			Hour = new ObservableCollection<object>();
			Minute = new ObservableCollection<object>();
			if (Device.RuntimePlatform == Device.Android)
			{
				Headers.Add("YEAR");
				Headers.Add("MONTH");
				Headers.Add("DAY");
				Headers.Add("HOUR");
				Headers.Add("MINUTE");
			}
			else
			{
				Headers.Add("Year");
				Headers.Add("Month");
				Headers.Add("Day");
             	Headers.Add("Hrs");
				Headers.Add("Min");
			}
			PopulateDateCollection();
			this.ItemsSource = Date;
			this.ColumnHeaderText = Headers;
            this.SelectionChanged += CustomDateTimePicker_SelectionChanged;
		}

        private void CustomDateTimePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDays(Date, e);
        }

        private void PopulateDateCollection()
		{
			//populate Days
			for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month); i++)
			{
				if (i < 10)
				{
					Day.Add("0" + i);
				}
				else
					Day.Add(i.ToString());
			}

            //populate year
            for (int i = 1990; i < 2050; i++)
            {
                Year.Add(i.ToString());
            }


            //populate months

            for (int i = 1; i < 13; i++)
			{
                if (!months.ContainsKey(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3)))
                    months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
                Month.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0,3));
			}
			Date.Add(Year);
			Date.Add(Month);
			Date.Add(Day);
            
			for (int i = 1; i <= 24; i++)
			{
				if (i < 10)
				{
					Hour.Add("0"+i.ToString());
				}
				else
					Hour.Add(i.ToString());
			}
			for (int j = 0; j < 60; j++)
			{
				if (j < 10)
				{
					Minute.Add("0" + j);
				}
				else
					Minute.Add(j.ToString());
			}



			Date.Add(Hour);
			Date.Add(Minute);
		}
       
        public void UpdateDays(ObservableCollection<object> Date, SelectionChangedEventArgs e)
        {

            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (Date.Count == 5)
                    {
                        bool isupdate = false;
                        if (e.OldValue != null && e.NewValue != null)
                        {
                            if (!object.Equals((e.OldValue as IList)[1], (e.NewValue as IList)[1]))
                            {
                                isupdate = true;
                            }

                            if (!object.Equals((e.OldValue as IList)[0], (e.NewValue as IList)[0]))
                            {
                                isupdate = true;
                            }
                        }

                        if (isupdate)
                        {
                            ObservableCollection<object> days = new ObservableCollection<object>();
                            int month = DateTime.ParseExact(months[(e.NewValue as IList)[1].ToString()], "MMMM", CultureInfo.InvariantCulture).Month;
                            int year = int.Parse((e.NewValue as IList)[0].ToString());
                            for (int j = 1; j <= DateTime.DaysInMonth(year, month); j++)
                            {
                                if (j < 10)
                                {
                                    days.Add("0" + j);
                                }
                                else
                                    days.Add(j.ToString());
                            }

                            ObservableCollection<object> oldvalue = new ObservableCollection<object>();

                            foreach (var item in e.NewValue as IList)
                            {
                                oldvalue.Add(item);
                            }

                            if (days.Count > 0)
                            {
                                Date.RemoveAt(2);
                                Date.Insert(2, days);
                            }

                            if ((Date[2] as IList).Contains(oldvalue[2]))
                            {
                                this.SelectedItem = oldvalue;
                            }
                            else
                            {
                                oldvalue[2] = (Date[2] as IList)[(Date[2] as IList).Count - 1];
                                this.SelectedItem = oldvalue;
                            }
                        }
                    }

                }
                catch
                {

                }

            });
        }
    }

}
