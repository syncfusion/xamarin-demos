#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace SampleBrowser
{
    internal class TabViewGettingStarted : SamplePage
    {
        Spinner DisplayModeSpinner, TabPositionSpinner, SelectionIndicatorSpinner;
        Context context1;
        TextView ModeText, PositionText, SelectionIndicatorText;
        ArrayAdapter<String> dataAdapter,dataAdapter1;
        private TabControl tabControl;
        public override View GetSampleContent(Context context)
        {
            tabControl = new TabControl(context);
            
            return tabControl;
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            context1 = context;
            DisplayModeLayout();
            TabPositionLayout();
            SelectionIndicatorLayout();
            LinearLayout propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            //if(IsTabletDevice(context))
            //{
                ModeText.SetPadding(0,0,0,40);
                DisplayModeSpinner.SetPadding(0,0,0,50);

                PositionText.SetPadding(0, 40, 0, 40);
                TabPositionSpinner.SetPadding(0, 0, 0, 50);

                SelectionIndicatorText.SetPadding(0, 40, 0, 40);
                SelectionIndicatorSpinner.SetPadding(0, 0, 0, 50);
           // }
            propertylayout.AddView(ModeText);
            propertylayout.AddView(DisplayModeSpinner);

            propertylayout.SetPadding(10, 10, 10, 40);
            propertylayout.AddView(PositionText);
            propertylayout.AddView(TabPositionSpinner);
            propertylayout.SetPadding(10, 10, 10, 40);
            propertylayout.AddView(SelectionIndicatorText);
            propertylayout.AddView(SelectionIndicatorSpinner);
            return propertylayout;
        }
        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }
        private void TabPositionLayout()
        {
            PositionText = new TextView(context1);
            PositionText.TextSize = 20;
            PositionText.Text = "Tab Position";
            TabPositionSpinner = new Spinner(context1, SpinnerMode.Dialog);

            List<String> TabPostionList = new List<String>();
            TabPostionList.Add("Top");
            TabPostionList.Add("Bottom");

            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context1, Android.Resource.Layout.SimpleSpinnerItem, TabPostionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            TabPositionSpinner.Adapter = dataAdapter;

            //Mode Spinner Item Selected Listener
            TabPositionSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Top"))
                {
                    tabControl.TabHeaderPosition = Syncfusion.Android.TabView.TabHeaderPosition.Top;
                }
                if (selectedItem.Equals("Bottom"))
                {
                    tabControl.TabHeaderPosition = Syncfusion.Android.TabView.TabHeaderPosition.Bottom;
                }
            };
        }

        private void SelectionIndicatorLayout()
        {
            SelectionIndicatorText = new TextView(context1);
            SelectionIndicatorText.TextSize = 20;
            SelectionIndicatorText.Text = "SelectionIndicator Position";
            SelectionIndicatorSpinner = new Spinner(context1, SpinnerMode.Dialog);

            List<String> SelectionIndicatorList = new List<String>();
            SelectionIndicatorList.Add("Top");
            SelectionIndicatorList.Add("Bottom");

            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context1, Android.Resource.Layout.SimpleSpinnerItem, SelectionIndicatorList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            SelectionIndicatorSpinner.Adapter = dataAdapter;

            //Mode Spinner Item Selected Listener
            SelectionIndicatorSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Top"))
                {
                    tabControl.SelectionIndicatorSettings.Position = Syncfusion.Android.TabView.SelectionIndicatorPosition.Top;
                }
                if (selectedItem.Equals("Bottom"))
                {
                    tabControl.SelectionIndicatorSettings.Position = Syncfusion.Android.TabView.SelectionIndicatorPosition.Bottom;
                }
            };
        }

        private void DisplayModeLayout()
        {
            ModeText = new TextView(context1);
            ModeText.TextSize = 20;
            ModeText.Text = "Display Mode";
            DisplayModeSpinner = new Spinner(context1, SpinnerMode.Dialog);

            //View Mode List
            List<String> DisplayModeList = new List<String>();
            DisplayModeList.Add("Text");
            DisplayModeList.Add("Image");
            DisplayModeList.Add("NoHeader");
            DisplayModeList.Add("ImageWithText");


            //Data Adapter
            dataAdapter1 = new ArrayAdapter<String>(context1, Android.Resource.Layout.SimpleSpinnerItem, DisplayModeList);
            dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            DisplayModeSpinner.Adapter = dataAdapter1;

            //Mode Spinner Item Selected Listener
            DisplayModeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter1.GetItem(e.Position);
                if (selectedItem.Equals("Text"))
                {
                    tabControl.DisplayMode = Syncfusion.Android.TabView.TabDisplayMode.Text;
                }
                if (selectedItem.Equals("Image"))
                {
                    tabControl.DisplayMode = Syncfusion.Android.TabView.TabDisplayMode.Image;
                }
                if (selectedItem.Equals("NoHeader"))
                {
                    tabControl.DisplayMode = Syncfusion.Android.TabView.TabDisplayMode.NoHeader;
                }
                if (selectedItem.Equals("ImageWithText"))
                {
                    tabControl.DisplayMode = Syncfusion.Android.TabView.TabDisplayMode.ImageWithText;
                }
            };
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
            tabControl.ApplyChanges();

        }
    }
}