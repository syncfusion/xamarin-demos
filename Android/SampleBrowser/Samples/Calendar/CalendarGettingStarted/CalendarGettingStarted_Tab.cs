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

namespace SampleBrowser
{
    public class CalendarGettingStarted_Tab : SamplePage, IDisposable
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        private SfCalendar calendar;
        private ArrayAdapter<String> dataAdapter;
        private Spinner modeSpinner;
        private Context context;
        private FrameLayout mainView;
        private LinearLayout proprtyOptionsLayout;
      
        public CalendarGettingStarted_Tab()
        {
        }

        public override View GetSampleContent(Context context1)
        {
            context = context1;
            calendar = new SfCalendar(context);
            calendar.ShowEventsInline = false;
            calendar.HeaderHeight = 100;
            MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
            labelSettings.DateLabelSize = 14;
            MonthViewSettings monthViewSettings = new MonthViewSettings();
            monthViewSettings.MonthViewLabelSetting = labelSettings;
            monthViewSettings.SelectedDayTextColor = Color.Black;
            monthViewSettings.TodayTextColor = Color.ParseColor("#1B79D6");
            monthViewSettings.InlineBackgroundColor = Color.ParseColor("#E4E8ED");
            monthViewSettings.WeekDayBackgroundColor = Color.ParseColor("#F7F7F7");
            calendar.MonthViewSettings = monthViewSettings;

            mainView = new FrameLayout(context);
            mainView.AddView(calendar);
            return mainView;
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.SetPadding(40, 40, 40, 0);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            ViewModeLayout();

            return proprtyOptionsLayout;
        }

        private void ViewModeLayout()
        {
            //ViewMode
            TextView viewModeLabel = new TextView(context);
            viewModeLabel.SetPadding(0, 0, 0, 50);
            viewModeLabel.TextSize = 20;
            viewModeLabel.Text = "ViewMode";

            modeSpinner = new Spinner(context, SpinnerMode.Dialog);
            
            //Vie Mode List
            List<String> viewModeList = new List<String>();
            viewModeList.Add("Month View");
            viewModeList.Add("Year View");
            
            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, viewModeList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            modeSpinner.Adapter = dataAdapter;
            modeSpinner.SetSelection(0);
            
            //Mode Spinner Item Selected Listener
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => 
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Month View"))
                {
                    calendar.ViewMode = ViewMode.MonthView;
                }

                if (selectedItem.Equals("Year View"))
                {
                    calendar.ViewMode = ViewMode.YearView;
                }   
            };

            //viewModeLayout
            LinearLayout viewModeLayout = new LinearLayout(context);
            viewModeLayout.Orientation = Android.Widget.Orientation.Vertical;
            viewModeLayout.AddView(viewModeLabel);
            viewModeLayout.AddView(modeSpinner);
            proprtyOptionsLayout.AddView(viewModeLayout);
        }

        public void Dispose()
        {
            if (calendar != null)
            {
                calendar.Dispose();
                calendar = null;
            }

            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
                dataAdapter = null;
            }

            if (modeSpinner != null)
            {
                modeSpinner.Dispose();
                modeSpinner = null;
            }

            if (mainView != null)
            {
                mainView.Dispose();
                mainView = null;
            }

            if (proprtyOptionsLayout != null)
            {
                proprtyOptionsLayout.Dispose();
                proprtyOptionsLayout = null;
            }
        }
    }
}