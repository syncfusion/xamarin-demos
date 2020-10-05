#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.SfPicker;

namespace SampleBrowser
{
    public class SfPickerDemo : SamplePage
    {
        SfPicker sfpicker;
        TextView eventLog;
        Spinner showHeaderSpinner, showColumnHeaderSpinner;
        int width;
        Context context1;
        TextView showHeaderText, showColumnHeaderText, headerText;
        EditText headerTextView;
        ArrayAdapter<String> dataAdapter;



        public SfPickerDemo()
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
            bottomFrame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height * 0.40));
            bottomFrame.SetBackgroundColor(Color.Silver);
            bottomFrame.AddView(scrollviewer);
            bottomFrame.SetPadding(10, 0, 10, 0);
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
                scrollviewer.ScrollTo(0, textFrame.Bottom);

            };

            return layout;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            context1 = context;
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            showHeaderLayout();
            showColumnHeaderLayout();
            HeaderTextLayout();
            /******************
             **propertylayout**
             ******************/
            //Separator
            LinearLayout.LayoutParams separatorLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            separatorLayoutParams.SetMargins(0, 20, 0, 0);
            SeparatorView separate = new SeparatorView(context1, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);

            LinearLayout propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
            propertylayout.AddView(showHeaderText);
            propertylayout.AddView(showHeaderSpinner);
            propertylayout.SetPadding(10, 10, 10, 40);
            propertylayout.AddView(showColumnHeaderText);
            propertylayout.AddView(showColumnHeaderSpinner);
            propertylayout.AddView(headerText);
            propertylayout.AddView(headerTextView);

            showHeaderText.SetPadding(0, 0, 0, 40);
            showHeaderSpinner.SetPadding(0, 0, 0, 50);

            showColumnHeaderText.SetPadding(0, 40, 0, 40);
            showColumnHeaderSpinner.SetPadding(0, 0, 0, 50);

            headerText.SetPadding(0, 40, 0, 40);
            headerTextView.SetPadding(0, 0, 0, 50);

            return propertylayout;
        }
        private void showHeaderLayout()
        {

            showHeaderText = new TextView(context1);
            showHeaderText.TextSize = 20;
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
        }

        private void showColumnHeaderLayout()
        {

            showColumnHeaderText = new TextView(context1);
            showColumnHeaderText.TextSize = 20;
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

        }
        private void HeaderTextLayout()
        {
            headerText = new TextView(context1);
            headerText.TextSize = 20;
            headerText.Text = "Header Text";

            headerTextView = new EditText(context1);
            headerTextView.TextSize = 18;
            headerTextView.Text = "PICK A COLOR";
            headerTextView.TextChanged += (sender, e) => { sfpicker.HeaderText = e.Text.ToString(); };
        }
    }
	public static class PickerHelper
	{
		static Dictionary<string, Color> colors = new Dictionary<string, Color>();

		public static Color GetColor(object color)
		{
			colors.Clear();
			colors.Add("Yellow", Color.Yellow);
			colors.Add("Green", Color.Green);
			colors.Add("Orange", Color.Orange);
			colors.Add("Lime", Color.Lime);
			colors.Add("LightBlue", Color.LightBlue);
			colors.Add("Pink", Color.Pink);
			colors.Add("SkyBlue", Color.SkyBlue);
			colors.Add("White", Color.White);
			colors.Add("Red", Color.Red);
			colors.Add("Aqua", Color.Aqua);
			return colors[color.ToString()];
		}
	}
}
