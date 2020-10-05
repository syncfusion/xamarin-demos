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
using Com.Syncfusion.Navigationdrawer;
using Android.Graphics;

namespace SampleBrowser
{
    public class CalendarLocalization_Mobile : IDisposable
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        private Java.Util.Locale localinfo = new Java.Util.Locale("zn", "CH");
        private ArrayAdapter<String> dataAdapter;
        private LinearLayout propertylayout;
        private SeparatorView separate;
        private LinearLayout.LayoutParams layoutParams1;
        private Spinner cultureSpinner;
        private TextView culturetxt;
        private FrameLayout mainView;
        private SfCalendar calendar;
        private Context context;
        private int width;

        public View GetSampleContent(Context context)
        {
           /************
            **Calendar**
            ************/        
            calendar = new SfCalendar(context);
            calendar.ViewMode = ViewMode.MonthView;
            calendar.ShowEventsInline = false;
			calendar.HeaderHeight = 100;
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

            //main View
            mainView = new FrameLayout(context);
            mainView.AddView(calendar);
            return mainView;
        }

        public View GetPropertyWindowLayout(Context context1)
        {
            context = context1;
            width = context.Resources.DisplayMetrics.WidthPixels / 2;

            CultureLayout();

            /******************
             **propertylayout**
             ******************/
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
            propertylayout.AddView(culturetxt);
            propertylayout.AddView(cultureSpinner);
           
            // propertylayout.AddView(separate, layoutParams1);
            propertylayout.SetPadding(20, 10, 10, 10);

            return propertylayout;
        }
       
        private void CultureLayout()
        {
            /***********
            **Culture**
            ***********/
            culturetxt = new TextView(context);
            culturetxt.TextSize = 20;
            culturetxt.Text = "Culture";

            //Culture List
            List<String> cultureList = new List<String>();
            cultureList.Add("Chinese");
            cultureList.Add("Spanish");
            cultureList.Add("English");
            cultureList.Add("French");

            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, cultureList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //Culture Spinner
            cultureSpinner = new Spinner(context, SpinnerMode.Dialog);
            cultureSpinner.Adapter = dataAdapter;

            //Culture Item Selected Listener
            cultureSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Chinese"))
                {
                    localinfo = Java.Util.Locale.China; //new Java.Util.Locale("en","US");
                }

                if (selectedItem.Equals("Spanish"))
                {
                    localinfo = new Java.Util.Locale("es", "AR");
                }

                if (selectedItem.Equals("English"))
                {
                    localinfo = Java.Util.Locale.Us;
                }

                if (selectedItem.Equals("French"))
                {
                    localinfo = Java.Util.Locale.France;
                }
            };

            //separate
            separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);

            //Layout Params
            layoutParams1 = new LinearLayout.LayoutParams(width * 2, 5);
            layoutParams1.SetMargins(0, 20, 0, 0);
        }
        
       /************************
        **Apply Changes Method**
        ************************/
        public void OnApplyChanges()
        {
            calendar.Locale = localinfo;
        }

        public void Dispose()
        {
            if (calendar != null)
            {
                calendar.Dispose();
                calendar = null;
            }

            if (mainView != null)
            {
                mainView.Dispose();
                mainView = null;
            }

            if (culturetxt != null)
            {
                culturetxt.Dispose();
                culturetxt = null;
            }

            if (cultureSpinner != null)
            {
                cultureSpinner.Dispose();
                cultureSpinner = null;
            }

            if (layoutParams1 != null)
            {
                layoutParams1.Dispose();
                layoutParams1 = null;
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

            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
                dataAdapter = null;
            }

            if (localinfo != null)
            {
                localinfo.Dispose();
                localinfo = null;
            }
        }
    }
}