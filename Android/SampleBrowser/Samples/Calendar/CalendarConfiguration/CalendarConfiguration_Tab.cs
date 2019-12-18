#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Calendar;
using Com.Syncfusion.Calendar.Enums;
using Android.Graphics;
using Java.Util;
using Android.Text.Format;
using Java.Text;

namespace SampleBrowser
{
	public class CalendarConfiguration_Tab : SamplePage, IDisposable
	{
        /*********************************
         **Local Variable Inizialisation**
         *********************************/

        private int minYear = 2012, minMonth = 0, minDay = 1;
        private int maxYear = 2018, maxMonth = 11, maxDay = 1;
        private String minTextDate = "1/1/2012", maxTextDate = "1/12/2018";
        private Button minDateButton, maxDateButton;
        private DatePickerDialog minDatePicker, maxDatePicker;
        private LinearLayout proprtyOptionsLayout;
		private FrameLayout mainLayout;
        private Calendar minPick, maxPick;
        private const int DATEDIALOGID = 0;
        private ArrayAdapter<String> dataAdapter;
        private Spinner modeSpinner;
        private SfCalendar calendar;
        private Context context;	

        public override View GetSampleContent(Context context1)
		{
            context = context1;

            //calendar
            mainLayout = new FrameLayout(context);
            calendar = new SfCalendar(context);
			calendar.ShowEventsInline = false;
			calendar.ViewMode = ViewMode.MonthView;
			calendar.HeaderHeight = 100;
            MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
			labelSettings.DateLabelSize = 14;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.MonthViewLabelSetting = labelSettings;
            monthViewSettings.TodayTextColor = Color.ParseColor("#1B79D6");
            monthViewSettings.SelectedDayTextColor = Color.Black;
            monthViewSettings.InlineBackgroundColor = Color.ParseColor("#E4E8ED");
            monthViewSettings.CurrentMonthTextColor = Color.ParseColor("#F7F7F7");
            monthViewSettings.WeekDayBackgroundColor = Color.ParseColor("#464646");
            monthViewSettings.WeekDayTextColor = Color.ParseColor("#F9F9F9");
            monthViewSettings.PreviousMonthTextColor = Color.ParseColor("#BFBFBF");
            monthViewSettings.PreviousMonthBackgroundColor = Color.ParseColor("#F9F9F9");
            calendar.MonthViewSettings = monthViewSettings;
            calendar.DrawMonthCell += Calendar_DrawMonthCell;

            mainLayout.AddView(calendar);

            return mainLayout;
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.SetPadding(40, 40, 40, 0);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            SelectionModeLayout();
            MinimumDateLayout();
            MaximumDateLayout();

            return proprtyOptionsLayout; 
        }
       
        private void SelectionModeLayout()
        {
            //ViewMode
            TextView viewModeLabel = new TextView(context);
            viewModeLabel.SetPadding(0, 0, 0, 30);
            viewModeLabel.TextSize = 20;
            viewModeLabel.Text = "Selection Mode";
            modeSpinner = new Spinner(context, SpinnerMode.Dialog);

            //Selection List
            List<String> selectionList = new List<String>();
            selectionList.Add("Single Selection");
            selectionList.Add("Multiple Selection");
           
            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, selectionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //ModeSpinner
            modeSpinner.Adapter = dataAdapter;
            modeSpinner.SetSelection(0);
            
            //Mode Spinner Item Changed Listener
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Single Selection"))
                {
                    calendar.SelectionMode = SelectionMode.SingleSelection;
                }

                if (selectedItem.Equals("Multiple Selection"))
                {
                    calendar.SelectionMode = SelectionMode.MultiSelection;
                }     
            };
            LinearLayout viewModeLayout = new LinearLayout(context);
            viewModeLayout.Orientation = Android.Widget.Orientation.Vertical;
            viewModeLayout.SetPadding(0, 0, 0, 50);
            viewModeLayout.AddView(viewModeLabel);
            viewModeLayout.AddView(modeSpinner);
            proprtyOptionsLayout.AddView(viewModeLayout);
        }
            
        private void MinimumDateLayout()
        {
            minPick = Calendar.Instance;
            minPick.Set(2012, 0, 1);
            maxPick = Calendar.Instance;
            maxPick.Set(2018, 11, 1);

            //Minimum Date Text
            TextView minDate = new TextView(context);
            minDate.SetPadding(0, 0, 0, 30);
            minDate.Text = "Min Date";
            minDate.TextSize = 20;
            minDate.Gravity = GravityFlags.Left;

            //minDateButton
            minDateButton = new Button(context);
            minDateButton.SetBackgroundColor(Color.ParseColor("#8CD4CF"));
            minDateButton.Text = minTextDate;
            minDateButton.TextSize = 16;
            minDatePicker = new DatePickerDialog(context, MinDateSetting, minYear, minMonth, minDay);
            minDateButton.Click += (object sender, EventArgs e) => 
            {
                minDatePicker.Show();
            };

            //minDateLayout
            LinearLayout minDateLayout = new LinearLayout(context);
            minDateLayout.Orientation = Android.Widget.Orientation.Vertical;
            minDateLayout.SetPadding(0, 0, 0, 50);
            minDateLayout.AddView(minDate);
            minDateLayout.AddView(minDateButton);

            proprtyOptionsLayout.AddView(minDateLayout);
        }
        
        private void MaximumDateLayout()
        {
            //Maximum Date Text
            TextView maxDate = new TextView(context);
            maxDate.SetPadding(0, 0, 0, 50);
            maxDate.Text = "Max Date";
            maxDate.TextSize = 20;
            maxDate.Gravity = GravityFlags.Left;

            //maxDateButton
            maxDateButton = new Button(context);
            maxDateButton.Text = maxTextDate;
            maxDateButton.TextSize = 16;
            maxDateButton.SetBackgroundColor(Color.ParseColor("#8CD4CF"));
            maxDatePicker = new DatePickerDialog(context, MaxDateSetting, maxYear, maxMonth, maxDay);
            maxDateButton.Click += (object sender, EventArgs e) => 
            {
                maxDatePicker.Show();
            };

            //maxDateLayout
            LinearLayout maxDateLayout = new LinearLayout(context);
            maxDateLayout.Orientation = Android.Widget.Orientation.Vertical;
            maxDateLayout.SetPadding(0, 0, 0, 50);
            maxDateLayout.AddView(maxDate);
            maxDateLayout.AddView(maxDateButton);
            proprtyOptionsLayout.AddView(maxDateLayout);
        }   
       
        //Minimum DateSelected Method      
        private void MinDateSetting(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			DateTime newMinDate = e.Date;
            minYear = newMinDate.Year;
            minMonth = newMinDate.Month;
            minDay = newMinDate.Day;
            minTextDate = minDay.ToString() + "/" + minMonth.ToString() + "/" + minYear.ToString();
            Calendar minCal = Calendar.Instance;
			minCal.Set(newMinDate.Year, newMinDate.Month - 1, newMinDate.Day);

			if (calendar.MaxDate == null || (calendar.MaxDate != null && minCal.Before(calendar.MaxDate)))
            {
				calendar.MinDate = minCal;
				StringBuilder stringBuilder = new StringBuilder().Append(newMinDate.Day).Append("/").Append(newMinDate.Month).Append("/").Append(newMinDate.Year);
				minDateButton.Text = stringBuilder.ToString();
			}
		}
             
        //Maximum DateSelected Method     
       private void MaxDateSetting(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			DateTime newMaxDate = e.Date;
            maxYear = newMaxDate.Year;
            maxMonth = newMaxDate.Month;
            maxDay = newMaxDate.Day;
            maxTextDate = maxDay.ToString() + "/" + maxMonth.ToString() + "/" + maxYear.ToString();

            Calendar maxCal = Calendar.Instance;
			maxCal.Set(newMaxDate.Year, newMaxDate.Month - 1, newMaxDate.Day);
			if (calendar.MinDate == null || (calendar.MinDate != null && maxCal.After(calendar.MinDate)))
            {				
				calendar.MaxDate = maxCal;
				StringBuilder stringBuilder = new StringBuilder().Append(newMaxDate.Day).Append("/").Append(newMaxDate.Month).Append("/").Append(newMaxDate.Year);
				maxDateButton.Text = stringBuilder.ToString();
			}
		}

       private void Calendar_DrawMonthCell(object sender, DrawMonthCellEventArgs e)
        {
			SimpleDateFormat compareString = new SimpleDateFormat("dd/MM/yyyy");
			String temp = new SimpleDateFormat("dd/MM/yyyy").Format(e.MonthCell.Date.Time);
			Java.Util.Date date = compareString.Parse(temp);
			string dayString = new SimpleDateFormat("EEEE").Format(date);
			if (dayString.ToLower().Equals("sunday") || dayString.ToLower().Equals("saturday"))
			{
				e.MonthCell.TextColor = Color.ParseColor("#0990e9");
                e.MonthCell.FontAttribute = Typeface.Create(" ", TypefaceStyle.Bold);
			}
			else
			{
				e.MonthCell.TextColor = Color.ParseColor("#7F7F7F");
                e.MonthCell.FontAttribute = Typeface.Create(" ", TypefaceStyle.Italic);
			}
        }

        public void Dispose()
        {
            if(calendar != null)
            {
                calendar.DrawMonthCell -= Calendar_DrawMonthCell;
                calendar.Dispose();
                calendar = null;
            }

            if (modeSpinner != null)
            {
                modeSpinner.Dispose();
                modeSpinner = null;
            }

            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
                dataAdapter = null;
            }

            if (minPick != null)
            {
                minPick.Dispose();
                minPick = null;
            }

            if (maxPick != null)
            {
                maxPick.Dispose();
                maxPick = null;
            }

            if (mainLayout != null)
            {
                mainLayout.Dispose();
                mainLayout = null;
            }

            if (proprtyOptionsLayout != null)
            {
                proprtyOptionsLayout.Dispose();
                proprtyOptionsLayout = null;
            }

            if (minDatePicker != null)
            {
                minDatePicker.Dispose();
                minDatePicker = null;
            }

            if (maxDatePicker != null)
            {
                maxDatePicker.Dispose();
                maxDatePicker = null;
            }

            if (minDateButton != null)
            {
                minDateButton.Dispose();
                minDateButton = null;
            }

            if (maxDateButton != null)
            {
                maxDateButton.Dispose();
                maxDateButton = null;
            }
        }
    }
}