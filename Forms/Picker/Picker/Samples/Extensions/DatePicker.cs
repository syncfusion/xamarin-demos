#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SelectionChangedEventArgs = Syncfusion.SfPicker.XForms.SelectionChangedEventArgs;
using Syncfusion.SfPicker.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPicker
{
	public class CustomDatePicker : Syncfusion.SfPicker.XForms.SfPicker
    {
        public Dictionary<string, string> months;
		public ObservableCollection<object> Date { get; set; }

		public ObservableCollection<object> Day;
		public ObservableCollection<object> Month;
		public ObservableCollection<object> Year;

		public ObservableCollection<object> Time { get; set; }
		public ObservableCollection<object> Minute;
		public ObservableCollection<object> Hour;
		public ObservableCollection<object> Format;

		public ObservableCollection<string> Headers { get; set; }
		public CustomDatePicker()
		{
            months = new Dictionary<string, string>();
            
			Date = new ObservableCollection<object>();
			Day = new ObservableCollection<object>();
			Month = new ObservableCollection<object>();
			Year = new ObservableCollection<object>();
			Headers = new ObservableCollection<string>();
			if (Device.RuntimePlatform == Device.Android)
			{
				Headers.Add("MONTH");
				Headers.Add("DAY");
				Headers.Add("YEAR");
			}
			else
			{
				Headers.Add("Month");
				Headers.Add("Day");
				Headers.Add("Year");
			}
			PopulateDateCollection();
			this.ItemsSource = Date;
			this.ColumnHeaderText = Headers;

            this.SelectionChanged += CustomDatePicker_SelectionChanged;
        }

        private void CustomDatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           UpdateDays(Date, e);
        }
        public void UpdateDays(ObservableCollection<object> Date, SelectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (Date.Count == 3)
                    {
                        bool isupdate = false;
                        if (e.OldValue != null && e.NewValue != null)
                        {
                            if (!object.Equals((e.OldValue as IList)[0], (e.NewValue as IList)[0]))
                            {
                                isupdate = true;
                            }
                            if (!object.Equals((e.OldValue as IList)[2], (e.NewValue as IList)[2]))
                            {
                                isupdate = true;
                            }
                        }

                        if (isupdate)
                        {

                            ObservableCollection<object> days = new ObservableCollection<object>();
                            int month = DateTime.ParseExact(months[(e.NewValue as IList)[0].ToString()], "MMMM", CultureInfo.InvariantCulture).Month;
                            int year = int.Parse((e.NewValue as IList)[2].ToString());
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
                                Date.RemoveAt(1);
                                Date.Insert(1, days);
                            }

                            if ((Date[1] as IList).Contains(oldvalue[1]))
                            {
                                this.SelectedItem = oldvalue;
                            }
                            else
                            {
                                oldvalue[1] = (Date[1] as IList)[(Date[1] as IList).Count - 1];
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

        private void PopulateDateCollection()
		{

            //populate months

            for (int i = 1; i < 13; i++)
            {
                if(!months.ContainsKey(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3)))
                months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
                Month.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3));
            }

            //populate year
            for (int i = 1990; i < 2050; i++)
            {
                Year.Add(i.ToString());
            }

            //populate Days
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
			{
				if (i < 10)
				{
					Day.Add("0" + i);
				}
				else
					Day.Add(i.ToString());
			}

			Date.Add(Month);
            Date.Add(Day);
			Date.Add(Year);
        }

	}
}
