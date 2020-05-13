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

using Java.Util;
using Com.Syncfusion.Calendar;
using Com.Syncfusion.Calendar.Enums;
using Android.Graphics;

namespace SampleBrowser
{
    public class CalendarLocalization_Tab : SamplePage, IDisposable
    {
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        private FrameLayout mainLayout;
        private SfCalendar calendar;
        private LinearLayout proprtyOptionsLayout;
        private ArrayAdapter<String> dataAdapter;
        private Spinner cultureSpinner;
      
        public override View GetSampleContent(Context context)
        {
            //mainLayout
            mainLayout = new FrameLayout(context);
            calendar = new SfCalendar(context);
            calendar.ViewMode = ViewMode.MonthView;
			calendar.HeaderHeight = 100;
            calendar.ShowEventsInline = false;
            calendar.Locale = new Java.Util.Locale("zh", "CN");
            MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
			labelSettings.DateLabelSize = 14;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.MonthViewLabelSetting = labelSettings;
            monthViewSettings.SelectedDayTextColor = Color.Black;
            monthViewSettings.TodayTextColor = Color.ParseColor("#1B79D6");
            monthViewSettings.InlineBackgroundColor = Color.ParseColor("#E4E8ED");
            monthViewSettings.WeekDayBackgroundColor = Color.ParseColor("#F7F7F7");
            calendar.MonthViewSettings = monthViewSettings;

            mainLayout.AddView(calendar);

            return mainLayout;
        }
     
       public override View GetPropertyWindowLayout(Context context)
        {
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.SetPadding(40, 40, 40, 0);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;
            CultureLayout(context);
            return proprtyOptionsLayout;
        }
      
        private void CultureLayout(Context context)
        {
            //Culture Text
            TextView cultureLabel = new TextView(context);
            cultureLabel.TextSize = 20;
            cultureLabel.SetPadding(0, 0, 0, 50);
            cultureLabel.Text = "Culture";
            cultureSpinner = new Spinner(context, SpinnerMode.Dialog);

            //Culture List
            List<String> cultureList = new List<String>();
            cultureList.Add("Chinese");
            cultureList.Add("Spanish");
            cultureList.Add("English");
            cultureList.Add("French");
            
            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, cultureList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //cultureSpinner
            cultureSpinner.Adapter = dataAdapter;
            cultureSpinner.SetSelection(0);
           
            //Culture Item Selected Listener
            cultureSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Chinese"))
                {
                    calendar.Locale = Java.Util.Locale.China; //new Java.Util.Locale("en","US");
                }

                if (selectedItem.Equals("Spanish"))
                {
                    calendar.Locale = new Java.Util.Locale("es", "AR");
                }

                if (selectedItem.Equals("English"))
                {
                    calendar.Locale = Java.Util.Locale.Us;
                }

                if (selectedItem.Equals("French"))
                {
                    calendar.Locale = Java.Util.Locale.France;
                }              
            };

            //cultureLayout
            LinearLayout cultureLayout = new LinearLayout(context);
            cultureLayout.Orientation = Android.Widget.Orientation.Vertical;
            cultureLayout.AddView(cultureLabel);
            cultureLayout.AddView(cultureSpinner);
            proprtyOptionsLayout.AddView(cultureLayout);
        }

        public void Dispose()
        {
            if (calendar != null)
            {
                calendar.Dispose();
                calendar = null;
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

            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
                dataAdapter = null;
            }

            if (cultureSpinner != null)
            {
                cultureSpinner.Dispose();
                cultureSpinner = null;
            }
        }
    }
}