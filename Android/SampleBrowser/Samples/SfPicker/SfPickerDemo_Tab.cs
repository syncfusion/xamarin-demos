#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.SfPicker;

namespace SampleBrowser
{
    public class SfPickerDemo_Tab: SamplePage
    {

        SfPicker sfpicker;
        TextView eventLog;
        Spinner showHeaderSpinner, showColumnHeaderSpinner;
        int width;
        Context context1;
        TextView showHeaderText, showColumnHeaderText, headerText;
        EditText headerTextView;
        ArrayAdapter<String> dataAdapter;
        LinearLayout propertylayout;

        public SfPickerDemo_Tab()
        {
            
        }

      
        public override View GetSampleContent(Context con)
        {
            float height = con.Resources.DisplayMetrics.HeightPixels; ;
            LinearLayout layout = new LinearLayout(con);
            Typeface tf = Typeface.CreateFromAsset(con.Assets, "Segoe_MDL2_Assets.ttf");
            layout.Orientation = Android.Widget.Orientation.Vertical;
            sfpicker = new SfPicker(con);
            sfpicker.ShowHeader = true;
            List<String> source = new List<string>();
            source.Add("Yellow");
            source.Add("Green");
            source.Add("Orange");
            source.Add("Lime");
            source.Add("LightBlue");
            source.Add("Pink");
            source.Add("SkyBlue");
            source.Add("White");
            source.Add("Red");
            source.Add("Aqua");
            sfpicker.ItemsSource = source;
            sfpicker.LayoutParameters = new ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, (int)(height * 0.60));
            sfpicker.PickerMode = PickerMode.Default;
            sfpicker.ShowFooter = false;

            sfpicker.SelectedItemTextSize = 20*con.Resources.DisplayMetrics.Density;
            sfpicker.UnSelectedItemTextSize= 20 * con.Resources.DisplayMetrics.Density;
            sfpicker.HeaderHeight = 40 * con.Resources.DisplayMetrics.Density;
            sfpicker.ShowColumnHeader = false;
            sfpicker.UnSelectedItemTextColor = Color.Black;
            sfpicker.SelectedIndex = 7;
            float density = con.Resources.DisplayMetrics.Density;
            eventLog = new TextView(con);
            eventLog.LayoutParameters = new ViewGroup.LayoutParams(800, 400);
            layout.SetGravity(GravityFlags.CenterHorizontal);
            layout.AddView(sfpicker);
            string headerText1 = "PICK A COLOR";
            sfpicker.ShowHeader = true;
            sfpicker.HeaderText = headerText1;
            sfpicker.BorderColor = Color.Red;
            TextView textview = new TextView(con);
            textview.Text = "Event Log";
            textview.Typeface = tf;
            textview.SetTextColor(Color.Black);

            textview.TextSize = 20;
            if (density > 2)
                textview.SetPadding(20, 0, 0, 20);
            else
                textview.SetPadding(10, 0, 0, 10);
            layout.AddView(textview);
            var scrollviewer = new ScrollView(con);
            var textFrame = new LinearLayout(con);
            textFrame.Orientation = Android.Widget.Orientation.Vertical;
            scrollviewer.AddView(textFrame);
            scrollviewer.VerticalScrollBarEnabled = true;
            FrameLayout bottomFrame = new FrameLayout(con);
            bottomFrame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height));
            bottomFrame.SetBackgroundColor(Color.Silver);
            bottomFrame.AddView(scrollviewer);
            bottomFrame.SetPadding(10, 30, 10, 0);
            layout.AddView(bottomFrame);
            sfpicker.ColumnHeaderText = "COLOR";


            sfpicker.OnSelectionChanged += (sender, e) =>
            {

                eventLog = new TextView(con);
                eventLog.SetTextColor(Color.Black);
                if (textFrame.ChildCount == 6)
                    textFrame.RemoveViewAt(0);

                textFrame.AddView(eventLog);
                eventLog.Text = (e.NewValue).ToString() + " " + "has been Selected";
                Color color = PickerHelper.GetColor(e.NewValue.ToString());
                sfpicker.SetBackgroundColor(color);
                sfpicker.Alpha = 0.4f;
               // scrollviewer.ScrollTo(0, textFrame.Bottom);

            };

            return layout;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            context1 = context;
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.SetPadding(0,30,0,0);
            propertylayout.Orientation = Orientation.Vertical;
            showHeaderLayout();
            showColumnHeaderLayout();
            HeaderTextLayout();
          
            return propertylayout;
        }


        private void showHeaderLayout()
        {

            showHeaderText = new TextView(context1);
            showHeaderText.TextSize = 20;
            showHeaderText.SetPadding(0, 0, 0, 10);
            showHeaderText.Text = "Show Header";
            showHeaderSpinner = new Spinner(context1, SpinnerMode.Dialog);

             //View Mode List
            List<String> showHeaderList = new List<String>();
            showHeaderList.Add("False");
            showHeaderList.Add("True");


            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context1, Android.Resource.Layout.SimpleSpinnerItem, showHeaderList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            showHeaderSpinner.Adapter = dataAdapter;

            //Mode Spinner Item Selected Listener
            showHeaderSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("True"))
                {
                    sfpicker.ShowHeader = true;
                }
                if (selectedItem.Equals("False"))
                {
                    sfpicker.ShowHeader = false;
                }
            };

            LinearLayout linearLayout = new LinearLayout(context1);
            linearLayout.SetPadding(20, 40, 0, 40);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout.AddView(showHeaderText);
            linearLayout.AddView(showHeaderSpinner);

            propertylayout.AddView(linearLayout);


        }

        private void showColumnHeaderLayout()
        {

            showColumnHeaderText = new TextView(context1);
            showColumnHeaderText.TextSize = 20;
            showColumnHeaderText.SetPadding(0, 0, 0, 10);
            showColumnHeaderText.Text = "Show Column Header";
            showColumnHeaderSpinner = new Spinner(context1, SpinnerMode.Dialog);

            //View Mode List
            List<String> showColumnHeaderList = new List<String>();

            showColumnHeaderList.Add("False");
            showColumnHeaderList.Add("True");

            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context1, Android.Resource.Layout.SimpleSpinnerItem, showColumnHeaderList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            showColumnHeaderSpinner.Adapter = dataAdapter;

            //Mode Spinner Item Selected Listener
            showColumnHeaderSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("True"))
                {
                    sfpicker.ShowColumnHeader = true;
                }
                if (selectedItem.Equals("False"))
                {
                    sfpicker.ShowColumnHeader = false;
                }
            };

            LinearLayout linearLayout = new LinearLayout(context1);
            linearLayout.SetPadding(20, 40, 0, 40);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout.AddView(showColumnHeaderText);
            linearLayout.AddView(showColumnHeaderSpinner);

            propertylayout.AddView(linearLayout);

        }
        private void HeaderTextLayout()
        {

            headerText = new TextView(context1);
            headerText.TextSize = 20;
            headerText.SetPadding(0,0,0,10);
            headerText.Text = "Header Text";

            headerTextView = new EditText(context1);
            headerTextView.TextSize = 18;
            headerTextView.Text = "PICK A COLOR";
            headerTextView.TextChanged += (sender, e) => { sfpicker.HeaderText = e.Text.ToString(); };


            LinearLayout linearLayout = new LinearLayout(context1);
            linearLayout.SetPadding(20, 40, 0, 40);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout.AddView(headerText);
            linearLayout.AddView(headerTextView);

            propertylayout.AddView(linearLayout);


        }

    }
  
}
