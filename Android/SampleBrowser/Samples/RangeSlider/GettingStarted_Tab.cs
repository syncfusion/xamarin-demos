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
using Android.Util;

namespace SampleBrowser
{
    //[con(Label = "Getting Started")]
    public class GettingStarted_Tab : SamplePage
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
        Button propertyButton;
        LinearLayout propertylayout, linearLayout;
        FrameLayout propertyFrameLayout, buttomButtonLayout;
        double actionBarHeight, navigationBarHeight, totalHeight;
        TextView arrivalLabel;
        Context con,context;
        Spinner tickSpinner, labelSpinner;
        ArrayAdapter<String> labelAdapter, dataAdapter;
        int tickPosition = 0, labelPosition = 0;
        bool showLabelPosition = true, snaptsToPosition = false;
        int  totalWidth;

        public override View GetSampleContent(Context con1)
        {
            con = con1;
            InitialMethod();          
            DepatureLayout();

            //rangeSlider
            range = new SfRangeSlider(con);
            range.Minimum = 0;
            range.Maximum = 12;
            range.TickFrequency = 2;
            range.ShowValueLabel = true;
            range.StepFrequency = 6;
            range.DirectionReversed = false;
            range.ValuePlacement = Com.Syncfusion.Sfrangeslider.ValuePlacement.BottomRight;
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
            FinalLayout();

            return frame;
        }

        FrameLayout frame;
        private void InitialMethod()
        {
            frame = new FrameLayout(con);
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;

            TypedValue tv = new TypedValue();
            if (con.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, con.Resources.DisplayMetrics);
            }
           
            navigationBarHeight = getNavigationBarHeight(con);
            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;

            //linearLayout
            linearLayout = new LinearLayout(con);
            linearLayout.SetPadding(20, 20, 20, 30);
            linearLayout.SetBackgroundColor(Color.White);
            linearLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.6), GravityFlags.Top | GravityFlags.CenterHorizontal);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;

            rangeHeight = getDimensionPixelSize(con, Resource.Dimension.range_ht);
        }

        TextView departureLabel;
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
            linearLayout.AddView(snapsToLabel);
            linearLayout.AddView(depstack);
            TextView timeLabel1 = new TextView(con);
            TextView textView12 = new TextView(con);
            linearLayout.AddView(textView12);
            linearLayout.AddView(timeLabel1);

            //timeLabel
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
            showLabel.SetHeight(70);
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
        private void FinalLayout()
        {
            //frame
            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.White);
            frame.SetPadding(10, 10, 10, 10);

            //scrollView1
            ScrollView scrollView1 = new ScrollView(con);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.7), GravityFlags.Top | GravityFlags.CenterHorizontal);
            scrollView1.AddView(linearLayout);
            frame.AddView(scrollView1);

            //buttomButtonLayout
            buttomButtonLayout = new FrameLayout(con);
            buttomButtonLayout.SetBackgroundColor(Color.Transparent);
            buttomButtonLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);

            //propertyButton
            propertyButton = new Button(con);
            propertyButton.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            propertyButton.Text = "OPTIONS";
            propertyButton.Gravity = GravityFlags.Start;

            //propertyFrameLayout
            propertyFrameLayout = new FrameLayout(con);
            propertyFrameLayout.SetBackgroundColor(Color.Rgb(240, 240, 240));
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(con));
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propertyFrameLayout.AddView(GetPropertyLayout(con));
            };

            //scrollView
            ScrollView scrollView = new ScrollView(con);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;
        }

       
        public View GetPropertyLayout(Android.Content.Context context1)
        {
            context = context1;
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);           

            OptionLayout();
            TickPlacementLayout();
            LabelPlacementLayout();
            ShowLabelLayout();
            SnapsToTicksLayout();

            return propertylayout;
        }

        FrameLayout topProperty;
        LinearLayout proprtyOptionsLayout;
        private void OptionLayout()
        {
            //propertylayout
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;
            showlabel = showLabelPosition;
            snapsto = SnapsTo.None;

            //propertyLabel
            TextView propertyLabel = new TextView(context);
            propertyLabel.SetTextColor(Color.ParseColor("#282828"));
            propertyLabel.Gravity = GravityFlags.CenterVertical;
            propertyLabel.TextSize = 18;
            propertyLabel.SetPadding(0, 10, 0, 10);
            propertyLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Left | GravityFlags.CenterHorizontal);
            propertyLabel.Text = "  " + "OPTIONS";

            //closeLabel
            TextView closeLabel = new TextView(context);
            closeLabel.SetBackgroundColor(Color.Transparent);
            closeLabel.Gravity = GravityFlags.CenterVertical;
            closeLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLabel.SetBackgroundResource(Resource.Drawable.sfclosebutton);

            //closeLayout
            FrameLayout closeLayout = new FrameLayout(context);
            closeLayout.SetBackgroundColor(Color.Transparent);
            closeLayout.SetPadding(0, 10, 0, 10);
            closeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLayout.AddView(closeLabel);

            //topProperty
            topProperty = new FrameLayout(context);
            topProperty.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            topProperty.SetBackgroundColor(Color.Rgb(230, 230, 230));
            topProperty.AddView(propertyLabel);
            topProperty.AddView(closeLayout);
            topProperty.Touch += (object sendar, View.TouchEventArgs e) =>
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            };
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //spaceText
            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void TickPlacementLayout()
        {
            //TickPlacement
            TextView placementLabel = new TextView(context);
            placementLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            placementLabel.Text = "Tick Placement";
            placementLabel.TextSize = 15;
            placementLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
            placementLabel.SetTextColor(Color.Black);
            placementLabel.Gravity = GravityFlags.Left;
         
            //positionList
            List<String> positionList = new List<String>();
            positionList.Add("BottomRight");
            positionList.Add("TopLeft");
            positionList.Add("Outside");
            positionList.Add("Inline");
            positionList.Add("None");
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, positionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //tickSpinner
            tickSpinner = new Spinner(context,SpinnerMode.Dialog);
            tickSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            tickSpinner.SetPadding(0, 0, 0, 0);
            tickSpinner.Adapter = dataAdapter;
            tickSpinner.SetSelection(tickPosition);
            tickSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                tickPosition = e.Position;
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
                ApplyChanges();
            };

            //tickPlacementLayout
            LinearLayout tickPlacementLayout = new LinearLayout(context);
            tickPlacementLayout.Orientation = Android.Widget.Orientation.Horizontal;
            tickPlacementLayout.AddView(placementLabel);
            tickPlacementLayout.AddView(tickSpinner);
            proprtyOptionsLayout.AddView(tickPlacementLayout);

            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }


        private void LabelPlacementLayout()
        {
            //Label Placement
            TextView departureLabel = new TextView(context);
            departureLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            departureLabel.Text = "Label Placement";
            departureLabel.TextSize = 15;
            departureLabel.SetTextColor(Color.Black);

            //labelList
            List<String> labelList = new List<String>();
            labelList.Add("BottomRight");
            labelList.Add("TopLeft");

            //labelSpinner
            labelSpinner = new Spinner(context,SpinnerMode.Dialog);
            labelSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            labelSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                labelPosition = e.Position;
                if (selectedItem.Equals("TopLeft"))
                {
                    valueplacement = ValuePlacement.TopLeft;

                }
                else if (selectedItem.Equals("BottomRight"))
                {
                    valueplacement = ValuePlacement.BottomRight;
                }
                ApplyChanges();
            };

            //labelAdapter
            labelAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, labelList);
            labelAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            labelSpinner.Adapter = labelAdapter;
            labelSpinner.SetSelection(labelPosition);
            labelSpinner.SetPadding(0, 0, 0, 0);

            //labelPlacementLayout
            LinearLayout labelPlacementLayout = new LinearLayout(context);
            labelPlacementLayout.Orientation = Android.Widget.Orientation.Horizontal;
            labelPlacementLayout.AddView(departureLabel);
            labelPlacementLayout.AddView(labelSpinner);
            proprtyOptionsLayout.AddView(labelPlacementLayout);

            //spaceText
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);
        }

        private void ShowLabelLayout()
        {
            //Show Label
            TextView showLabel = new TextView(context);
            showLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            showLabel.Text = "Show Label";
            showLabel.TextSize = 15;

            //checkBox
            Switch checkBox = new Switch(context);
            checkBox.Checked = showLabelPosition;
            checkBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
                if (e.IsChecked)
                    showlabel = true;
                else
                    showlabel = false;

                showLabelPosition = showlabel;
                ApplyChanges();
            };

            //spaceText
            TextView spaceText8 = new TextView(context);
            spaceText8.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            //showLabelLayout
            LinearLayout showLabelLayout = new LinearLayout(context);
            showLabelLayout.Orientation = Android.Widget.Orientation.Horizontal;
            showLabelLayout.AddView(showLabel);
            showLabelLayout.AddView(checkBox);
            showLabelLayout.AddView(spaceText8);
            proprtyOptionsLayout.AddView(showLabelLayout);

            //spaceText
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText4);
        }

        private void SnapsToTicksLayout()
        {
            //snapsToTicks
            TextView snapsToLabel = new TextView(context);
            snapsToLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            snapsToLabel.Text = "Snaps To Tick";
            snapsToLabel.TextSize = 15;

            //checkBox
            Switch checkBox2 = new Switch(context);
            checkBox2.Checked = snaptsToPosition;
            checkBox2.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
                if (e.IsChecked)
                    snapsto = SnapsTo.Ticks;
                else
                    snapsto = SnapsTo.None;

                snaptsToPosition = e.IsChecked;
                ApplyChanges();
            };

            //spaceText
            TextView spaceText7 = new TextView(context);
            spaceText7.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            //snapsToLabelLayout
            LinearLayout snapsToLabelLayout = new LinearLayout(context);
            snapsToLabelLayout.Orientation = Android.Widget.Orientation.Horizontal;
            snapsToLabelLayout.AddView(snapsToLabel);
            snapsToLabelLayout.AddView(checkBox2);
            snapsToLabelLayout.AddView(spaceText7);
            proprtyOptionsLayout.AddView(snapsToLabelLayout);

            //spaceText
            TextView spaceText5 = new TextView(context);
            spaceText5.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            //proprtyOptionsLayout.AddView(spaceText5);
            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            //layout1
            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);

            //propertylayout
            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);
        }

        public static int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }

        public void ApplyChanges()
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
        private int getStatusBarHeight(Android.Content.Context con)
        {
            int barHeight = 0;
            int resourceId = con.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                barHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return barHeight;
        }

        private int getNavigationBarHeight(Android.Content.Context con)
        {
            int navBarHeight = 0;
            int resourceId = con.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                navBarHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return navBarHeight;
        }
    }
}