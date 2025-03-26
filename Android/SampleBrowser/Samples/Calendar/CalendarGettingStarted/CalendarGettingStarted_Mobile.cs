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
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    public class CalendarGettingStarted_Mobile : IDisposable
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        private LinearLayout.LayoutParams separatorLayoutParams;
        private ViewMode viewMode = ViewMode.MonthView;
        private ArrayAdapter<String> dataAdapter;     
        private SeparatorView separate;
        private LinearLayout propertylayout;
        private TextView viewModetxt;
        private FrameLayout mainView;
        private SfCalendar calendar;        
        private Spinner modeSpinner;
        private int width;
        private Context context;

        public View GetSampleContent(Context context)
        {
           /************
            **Calendar**
            ************/
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

            //main View
            mainView = new FrameLayout(context);
            mainView.AddView(calendar);
            return mainView;
        }

        public View GetPropertyWindowLayout(Context context1)
        {
            context = context1;
            width = context.Resources.DisplayMetrics.WidthPixels / 2;
            ViewModeLayout();

            /******************
             **propertylayout**
             ******************/
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
            propertylayout.AddView(viewModetxt);
            propertylayout.AddView(modeSpinner);
         
            //propertylayout.AddView(separate, separatorLayoutParams);
            propertylayout.SetPadding(10, 10, 10, 10);
            return propertylayout;
        }

        private void ViewModeLayout()
        {
            /************
             **ViewMode**
             ************/
            viewModetxt = new TextView(context);
            viewModetxt.TextSize = 20;
            viewModetxt.Text = "ViewMode";
            modeSpinner = new Spinner(context, SpinnerMode.Dialog);

            //View Mode List
            List<String> viewModeList = new List<String>();
            viewModeList.Add("Month View");
            viewModeList.Add("Year View");

            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, viewModeList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            modeSpinner.Adapter = dataAdapter;

            //Mode Spinner Item Selected Listener
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => 
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Month View"))
                {
                    viewMode = ViewMode.MonthView;
                }

                if (selectedItem.Equals("Year View"))
                {
                    viewMode = ViewMode.YearView;
                }
            };

            //Separator
            separatorLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            separatorLayoutParams.SetMargins(0, 20, 0, 0);
            separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
        }

        /************************
         **Apply Changes Method**
         ************************/
        public void OnApplyChanges()
        {
            calendar.ViewMode = viewMode;
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

            if (separatorLayoutParams != null)
            {
                separatorLayoutParams.Dispose();
                separatorLayoutParams = null;
            }

            if (separate != null)
            {
                separate.Dispose();
                separate = null;
            }

            if (propertylayout != null)
            {
                propertylayout.Dispose();
                propertylayout = null;
            }

            if (viewModetxt != null)
            {
                viewModetxt.Dispose();
                viewModetxt = null;
            }
        }
    }
}