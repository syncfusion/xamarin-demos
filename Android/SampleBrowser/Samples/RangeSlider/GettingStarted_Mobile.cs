#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using Android.Content;
using Com.Syncfusion.Sfrangeslider;
using Android.Widget;
using Android.Views;
using Android.Graphics;

using SampleBrowser;

using droid = Android.Widget.Orientation;

using System.Collections.Generic;
using System;


namespace SampleBrowser
{
    //[con(Label = "Getting Started")]
    public class GettingStarted_Mobile
    {
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        SfRangeSlider range, range2;
        public static TickPlacement tickplacement = TickPlacement.BottomRight;
        public static ValuePlacement valueplacement = ValuePlacement.BottomRight;
        public static bool showlabel = true;
        public static SnapsTo snapsto = SnapsTo.None;
        string fromvalue, toValue, fromValue1, toValue1;
        public static int rangeHeight;
        LinearLayout linearLayout;
        TextView departureLabel;
        Context con,context;
        TextView arrivalLabel, snapsToLabel;
        Spinner tickSpinner, labelSpinner;
        LinearLayout propertylayout, stackView3, stackView4;
        ArrayAdapter<String> labelAdapter, dataAdapter;
        int width;
        public View GetSampleContent(Context con1)
        {
            con = con1;
            linearLayout = new LinearLayout(con);
            linearLayout.SetPadding(20, 20, 20, 30);
            linearLayout.SetBackgroundColor(Color.Rgb(236, 235, 242));
            linearLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;
            rangeHeight = getDimensionPixelSize(con, Resource.Dimension.range_ht);

            DepatureLayout();

            //RangeSlider
            range = new SfRangeSlider(con);
            range.Minimum = 0;
            range.Maximum = 12;
            range.TickFrequency = 2;
            range.ShowValueLabel = true;
            range.StepFrequency = 6;
            range.DirectionReversed = false;
            range.ValuePlacement =Com.Syncfusion.Sfrangeslider.ValuePlacement.BottomRight;
            range.RangeEnd = 12;
            range.RangeStart = 0;
            range.TickPlacement = Com.Syncfusion.Sfrangeslider.TickPlacement.BottomRight;
            range.ShowRange = true;
            range.SnapsTo = Com.Syncfusion.Sfrangeslider.SnapsTo.None;
            range.Orientation = Com.Syncfusion.Sfrangeslider.Orientation.Horizontal;
            range.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, rangeHeight);

            TimeLabelLayout();
            linearLayout.AddView(range);
            ArrivalLabelLayout();

            //rangeSlider
            range2 = new SfRangeSlider(con);
            range2.Minimum = 0;
            range2.Maximum = 12;
            range2.TickFrequency = 2;
            range2.ShowValueLabel = true;
            range2.StepFrequency = 6;
            range2.DirectionReversed = false;
            range2.ValuePlacement = Com.Syncfusion.Sfrangeslider.ValuePlacement.BottomRight;
            range2.RangeEnd = 12;
            range2.RangeStart = 0;
            range2.TickPlacement = Com.Syncfusion.Sfrangeslider.TickPlacement.BottomRight;
            range2.ShowRange = true;
            range2.SnapsTo = Com.Syncfusion.Sfrangeslider.SnapsTo.None;
            range2.Orientation = Com.Syncfusion.Sfrangeslider.Orientation.Horizontal;
            range2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, rangeHeight);

            TimeLableLayout2();

            return linearLayout;
        }


        private void DepatureLayout()
        {
            //departureLabel
            departureLabel = new TextView(con);
            departureLabel.TextSize = 20;
            departureLabel.Text = " " + "Departure";
            departureLabel.SetTextColor(Color.Black);
        }

        private void TimeLabelLayout()
        {
            //depstack
            LinearLayout depstack = new LinearLayout(con);
            depstack.Orientation = Android.Widget.Orientation.Horizontal;
            depstack.AddView(departureLabel);
            TextView timeLabel = new TextView(con);
            timeLabel.TextSize = 13;
            timeLabel.Text = "  " + "(in Hours)";
            timeLabel.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);
            timeLabel.SetTextColor(Color.ParseColor("#939394"));
            timeLabel.Gravity = GravityFlags.Center;
            depstack.AddView(timeLabel);

            //snapsToLabel
            TextView snapsToLabel = new TextView(con);
            snapsToLabel.SetHeight(50);
            //linearLayout.AddView(snapsToLabel);
            linearLayout.AddView(depstack);
            TextView timeLabel1 = new TextView(con);
            TextView textView12 = new TextView(con);
            linearLayout.AddView(textView12);
            linearLayout.AddView(timeLabel1);

            //timeLabel1
            timeLabel1.TextSize = 13;
            fromValue1 = "12";
            toValue1 = Math.Round(range.RangeEnd).ToString();
            timeLabel1.SetTextColor(Color.ParseColor("#939394"));
            timeLabel1.Text = "  " + "Time:  " + fromValue1 + "AM " + " - " + toValue1 + " PM";
            timeLabel1.Gravity = GravityFlags.Left;
            range.RangeChanged += (object sender, RangeChangedEventArgs e) => {
                String pMeridian = "AM", pMeridian1 = "AM";
				if (Math.Round(e.RangeStart).ToString() == "0")
                {
                    fromValue1 = "12";
                    pMeridian1 = "AM";
                }
                else
					fromValue1 = Convert.ToString(Math.Round(e.RangeStart));

				if (e.RangeEnd <= 12)
					toValue1 = Convert.ToString(Math.Round(e.RangeEnd));

				if (Math.Round(e.RangeEnd).ToString() == "12")
                    pMeridian = "PM";

				if (Math.Round(e.RangeEnd).ToString() == "12")
                    pMeridian = "PM";
				if (Convert.ToString(Math.Round(e.RangeStart)).Equals(Convert.ToString(Math.Round(e.RangeEnd))))
                {
					if (Math.Round(e.RangeStart).ToString() == "0")
                        timeLabel1.Text = "  " + "Time: " + fromValue1 + " " + pMeridian1;
					else if (Math.Round(e.RangeEnd).ToString() == "12")
                        timeLabel1.Text = "  " + "Time: " + toValue1 + " " + pMeridian;
                    else
                        timeLabel1.Text = "  " + "Time: " + fromValue1 + " " + pMeridian1;
                }
                else
                    timeLabel1.Text = "  " + "Time: " + fromValue1 + " " + pMeridian1 + " - " + toValue1 + " " + pMeridian;
            };
        }


        private void ArrivalLabelLayout()
        {
            //showLabel
            TextView showLabel = new TextView(con);
           // showLabel.SetHeight(30);
            linearLayout.AddView(showLabel);
            arrivalLabel = new TextView(con);
            arrivalLabel.TextSize = 20;
            arrivalLabel.Text = " " + "Arrival";
            arrivalLabel.SetTextColor(Color.Black);
        }

        private void TimeLableLayout2()
        {
            //timeLabel
            TextView timeLabel2 = new TextView(con);
            timeLabel2.TextSize = 13;
            timeLabel2.Text = "  " + "(in Hours)";
            timeLabel2.Gravity = GravityFlags.Center;
            timeLabel2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);
            timeLabel2.SetTextColor(Color.ParseColor("#939394"));

            //AdjLabel
            TextView adjLabel8 = new TextView(con);
            adjLabel8.SetHeight(50);
            LinearLayout arrivestack = new LinearLayout(con);
            arrivestack.Orientation = Android.Widget.Orientation.Horizontal;
            arrivestack.AddView(arrivalLabel);
            arrivestack.AddView(timeLabel2);

            //linearLayout
            linearLayout.AddView(adjLabel8);
            linearLayout.AddView(arrivestack);
            TextView adjLabel9 = new TextView(con);
            linearLayout.AddView(adjLabel9);
            TextView timeLabel3 = new TextView(con);
            linearLayout.AddView(timeLabel3);
            linearLayout.AddView(range2);

            //timeLabel
            timeLabel3.TextSize = 13;
            timeLabel3.SetTextColor(Color.ParseColor("#939394"));
            fromvalue = "12";
            toValue = Math.Round(range2.RangeEnd).ToString();
            timeLabel3.Text = "  " + "Time:  " + fromvalue + "AM " + " - " + toValue + " PM";
            timeLabel3.Gravity = GravityFlags.Left;
            range2.RangeChanged += (object sender, RangeChangedEventArgs e) => {
                String pMeridian = "AM", pMeridian1 = "AM";
				if (Math.Round(e.RangeStart).ToString() == "0")
                {
                    fromvalue = "12";
                    pMeridian1 = "AM";
                }
                else
					fromvalue = Convert.ToString(Math.Round(e.RangeStart));

				if (e.RangeEnd <= 12)
					toValue = Convert.ToString(Math.Round(e.RangeEnd));

				if (Math.Round(e.RangeEnd).ToString() == "12")
                    pMeridian = "PM";
				if (Convert.ToString(Math.Round(e.RangeStart)).Equals(Convert.ToString(Math.Round(e.RangeEnd))))
                {
					if (Math.Round(e.RangeStart).ToString() == "0")
                        timeLabel3.Text = "  " + "Time: " + fromvalue + " " + pMeridian1;
					else if (Math.Round(e.RangeEnd).ToString() == "12")
                        timeLabel3.Text = "  " + "Time: " + toValue + " " + pMeridian;
                    else
                        timeLabel3.Text = "  " + "Time: " + fromvalue + " " + pMeridian1;
                }
                else
                    timeLabel3.Text = "  " + "Time: " + fromvalue + " " + pMeridian1 + " - " + toValue + " " + pMeridian;
            };
        }      

        public View GetPropertyWindowLayout(Android.Content.Context context1)
        {
            context = context1;
            width = context.Resources.DisplayMetrics.WidthPixels / 2;        
         
            TickPlacementLayout();
            LabelPlacementLayout();
            ShowLabelLayout();
            SnapsToLayout();

            return propertylayout;
        }

        private void TickPlacementLayout()
        {
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = droid.Vertical;
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            layoutParams.SetMargins(0, 5, 0, 0);

            //TICK PLACEMENT
            TextView placementLabel = new TextView(context);
            placementLabel.Text = "  " + "Tick Placement";
            placementLabel.TextSize = 20;
            placementLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
            placementLabel.SetTextColor(Color.Black);
            placementLabel.Gravity = GravityFlags.Left;
            TextView adjLabel2 = new TextView(context);
            adjLabel2.SetHeight(14);
            propertylayout.AddView(adjLabel2);

            //tickSpinner
            tickSpinner = new Spinner(context,SpinnerMode.Dialog);
            tickSpinner.SetPadding(0, 0, 0, 0);
            propertylayout.AddView(placementLabel);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            //propertylayout.AddView(separate, layoutParams);
            TextView adjLabel3 = new TextView(context);
            adjLabel3.SetHeight(20);
            //propertylayout.AddView(adjLabel3);
            propertylayout.AddView(tickSpinner);
            TextView adjLabel4 = new TextView(context);
            propertylayout.AddView(adjLabel4);

            //positionList
            List<String> positionList = new List<String>();
            positionList.Add("BottomRight");
            positionList.Add("TopLeft");
            positionList.Add("Outside");
            positionList.Add("Inline");
            positionList.Add("None");

            //dataAdapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, positionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //tickSpinner
            tickSpinner.Adapter = dataAdapter;
            tickSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("BottomRight"))
                {
                    tickplacement = TickPlacement.BottomRight;

                }
                else if (selectedItem.Equals("TopLeft"))
                {
                    tickplacement = TickPlacement.TopLeft;

                }
                else if (selectedItem.Equals("Inline"))
                {
                    tickplacement = TickPlacement.Inline;

                }
                else if (selectedItem.Equals("Outside"))
                {
                    tickplacement = TickPlacement.Outside;

                }
                else if (selectedItem.Equals("None"))
                {
                    tickplacement = TickPlacement.None;

                }
            };
        }

        private void LabelPlacementLayout()
        {
            //LABEL PLACEMENT
            TextView departureLabel = new TextView(context);
            departureLabel.Text = "  " + "Label Placement";
            departureLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
            departureLabel.Gravity = GravityFlags.Left;
            departureLabel.TextSize = 20;
            departureLabel.SetTextColor(Color.Black);
            List<String> labelList = new List<String>();
            labelList.Add("BottomRight");
            labelList.Add("TopLeft");

            //labelSpinner
            labelSpinner = new Spinner(context,SpinnerMode.Dialog);
            labelSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("TopLeft"))
                {
                    valueplacement = ValuePlacement.TopLeft;
                }
                else if (selectedItem.Equals("BottomRight"))
                {
                    valueplacement = ValuePlacement.BottomRight;
                }
            };

            //labelAdapter
            labelAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, labelList);
            labelAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            labelSpinner.Adapter = labelAdapter;
            labelSpinner.SetPadding(0, 0, 0, 0);
            LinearLayout.LayoutParams layoutParams2 = new LinearLayout.LayoutParams(width * 2, 7);
            layoutParams2.SetMargins(0, 5, 0, 0);
            propertylayout.AddView(departureLabel);

            //separate2
            SeparatorView separate2 = new SeparatorView(context, width * 2);
            separate2.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 7);
           // propertylayout.AddView(separate2, layoutParams2);

            //snapsToLabel
            snapsToLabel = new TextView(context);
            snapsToLabel.SetHeight(20);
            //propertylayout.AddView(snapsToLabel);
            propertylayout.AddView(labelSpinner);
            propertylayout.SetPadding(15, 0, 15, 0);
            TextView adjLabel12 = new TextView(context);
            adjLabel12.SetHeight(20);
            propertylayout.AddView(adjLabel12);
        }

        private void ShowLabelLayout()
        {
            //showLabel
            TextView showLabel = new TextView(context);
            showLabel.Text = "  " + "Show Label";
            showLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
            showLabel.Gravity = GravityFlags.Center;
            showLabel.TextSize = 20;

            //checkBox
            Switch checkBox = new Switch(context);
            checkBox.Checked = true;
            checkBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
                if (e.IsChecked)
                    showlabel = true;
                else
                    showlabel = false;
            };

            //layoutParams
            LinearLayout.LayoutParams layoutParams3 = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            layoutParams3.SetMargins(0, 10, 0, 0);
            LinearLayout.LayoutParams layoutParams4 = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, 55);
            layoutParams4.SetMargins(0, 10, 0, 0);

			TextView textSpacing1 = new TextView(context);
			propertylayout.AddView(textSpacing1);
            //stackView
            stackView3 = new LinearLayout(context);
            stackView3.AddView(showLabel);
            stackView3.AddView(checkBox, layoutParams3);
            stackView3.Orientation = droid.Horizontal;
            propertylayout.AddView(stackView3);
            SeparatorView separate3 = new SeparatorView(context, width * 2);
            separate3.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams layoutParams7 = new LinearLayout.LayoutParams(width * 2, 5);
            layoutParams7.SetMargins(0, 30, 0, 0);
            //propertylayout.AddView(separate3, layoutParams7);
        }

        private void SnapsToLayout()
        {
            //SnapsToTicks
            snapsToLabel = new TextView(context);
            snapsToLabel.Text = "  " + "Snaps To Tick";
            snapsToLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
            snapsToLabel.Gravity = GravityFlags.Center;
            snapsToLabel.TextSize = 20;

            //SnapsToTicks CheckBox
            Switch checkBox2 = new Switch(context);
            checkBox2.Checked = false;
            checkBox2.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
                if (e.IsChecked)
                    snapsto = SnapsTo.Ticks;
                else
                    snapsto = SnapsTo.None;
            };

            //layoutParams
            LinearLayout.LayoutParams layoutParams5 = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            layoutParams5.SetMargins(0, 20, 0, 0);
            LinearLayout.LayoutParams layoutParams6 = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, 55);
            layoutParams6.SetMargins(0, 20, 0, 0);

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);
            //stackView
            stackView4 = new LinearLayout(context);
            stackView4.AddView(snapsToLabel);
            stackView4.AddView(checkBox2, layoutParams5);
            stackView4.Orientation = droid.Horizontal;
            propertylayout.AddView(stackView4);
            SeparatorView separate4 = new SeparatorView(context, width * 2);
            separate4.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams layoutParams8 = new LinearLayout.LayoutParams(width * 2, 5);
            layoutParams8.SetMargins(0, 30, 0, 0);
			// propertylayout.AddView(separate4, layoutParams8);
			TextView textSpacing1 = new TextView(context);
			propertylayout.AddView(textSpacing1);
        }
        public static int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
        public void OnApplyChanges()
        {
            range2.TickPlacement = tickplacement;
            range.TickPlacement = tickplacement;

            range2.ValuePlacement = valueplacement;
            range.ValuePlacement = valueplacement;

            range2.ShowValueLabel = showlabel;
            range.ShowValueLabel = showlabel;

            range2.SnapsTo = snapsto;
            range.SnapsTo = snapsto;
        }
    }
}