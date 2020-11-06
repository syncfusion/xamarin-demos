#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfCircularGauge;
using System.Collections.ObjectModel;
using Android.Graphics;
using Com.Syncfusion.Gauges.SfCircularGauge.Enums;
using Android.Renderscripts;
using static Android.App.ActionBar;
using Android.Util;

namespace SampleBrowser
{
    public class CustomizationSample : SamplePage
    {
        double value;
        NeedlePointer needlePointer;
        RangePointer rangePointer1;
        RangePointer rangePointer;
        List<String> adapter;
        List<String> adapter1;
        List<String> adapter2;
        CircularRange circularRange;
        CircularRange circularRange1;
        Header header;
        Header header1;
        LinearLayout optionsPage;
        public override View GetSampleContent (Context con)
		{
            DisplayMetrics displayMetrics = con.Resources.DisplayMetrics;
            float screenHeight = displayMetrics.HeightPixels;

            SfCircularGauge sfCircularGauge = new SfCircularGauge(con);

            ObservableCollection<Header> headers = new ObservableCollection<Header>();
            header = new Header();
            header.Text = Math.Round((double)800, 2) + " GB";
            header.TextSize = 24;
            header.TextColor = Color.Black;
            header.Position = new PointF((float)0.5, (float)0.1);
            headers.Add(header);
            sfCircularGauge.Headers = headers;

            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            CircularScale scale = new CircularScale();
            scale.StartAngle = 210;
            scale.SweepAngle = 120;
            scale.StartValue = 0;
            scale.EndValue = 1000;
            scale.Interval = 500;
            scale.ShowLabels = false;
            scale.ShowTicks = false;
            scale.ShowRim = false;
            scale.MinorTicksPerInterval = 0;

            ObservableCollection<CircularRange> ranges = new ObservableCollection<CircularRange>();
            circularRange = new CircularRange();
            circularRange.StartValue = 0;
            circularRange.EndValue = 1000;
            circularRange.Color = Color.ParseColor("#E0E0E0");
            circularRange.Offset = 0.7;
            circularRange.Width = 30;
            ranges.Add(circularRange);
            scale.CircularRanges = ranges;

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();
            rangePointer = new RangePointer();
            rangePointer.Value = 800;
            rangePointer.Color = Color.ParseColor("#FFDD00");
            rangePointer.Width = 30;
            rangePointer.Offset = 0.7;
            rangePointer.EnableAnimation = false;
            pointers.Add(rangePointer);

            needlePointer = new NeedlePointer();
            needlePointer.Value = 800;
            needlePointer.Color = Color.ParseColor("#424242");
            needlePointer.Type = Com.Syncfusion.Gauges.SfCircularGauge.Enums.NeedleType.Triangle;
            needlePointer.LengthFactor = 0.7;
            needlePointer.Width = 10;
            needlePointer.KnobRadiusFactor = 0.1;
            needlePointer.KnobColor = Color.ParseColor("#424242");
            pointers.Add(needlePointer);

            scale.CircularPointers = pointers;
            circularScales.Add(scale);
            sfCircularGauge.CircularScales = circularScales;

            sfCircularGauge.SetBackgroundColor(Color.White);

            SfCircularGauge circularGauge = new SfCircularGauge(con);

            ObservableCollection<Header> headers1 = new ObservableCollection<Header>();            
            header1 = new Header();
            header1.Text = Math.Round((double)800, 2) + " GB";
            header1.TextSize = 24;
            header1.TextColor = Color.Black;
            header1.Position = new PointF((float)0.5, (float)0.5);
            headers1.Add(header1);

            Header header2 = new Header();
            header2.Text = "Used";
            header2.TextSize = 18;
            header2.TextColor = Color.Gray;
            header2.Position = new PointF((float)0.5, (float)0.6);
            headers1.Add(header2);

            circularGauge.Headers = headers1;

            ObservableCollection<CircularScale> circularScales1 = new ObservableCollection<CircularScale>();
            CircularScale scale1 = new CircularScale();
            scale1.StartAngle = 90;
            scale1.SweepAngle = 360;
            scale1.StartValue = 0;
            scale1.EndValue = 1000;
            scale1.Interval = 500;
            scale1.ShowLabels = false;
            scale1.ShowTicks = false;
            scale1.ShowRim = false;
            scale1.MinorTicksPerInterval = 0;

            ObservableCollection<CircularRange> ranges1 = new ObservableCollection<CircularRange>();
            circularRange1 = new CircularRange();
            circularRange1.StartValue = 0;
            circularRange1.EndValue = 999.9;
            circularRange1.Color = Color.ParseColor("#E0E0E0");
            circularRange1.Offset = 0.8;
            circularRange1.Width = 30;
            ranges1.Add(circularRange1);
            scale1.CircularRanges = ranges1;

            ObservableCollection<CircularPointer> pointers1 = new ObservableCollection<CircularPointer>();
            rangePointer1 = new RangePointer();
            rangePointer1.Value = 800;
            rangePointer1.Color = Color.ParseColor("#FFDD00");
            rangePointer1.Width = 30;
            rangePointer1.Offset = 0.8;
            rangePointer1.EnableAnimation = false;
            pointers1.Add(rangePointer1);

            scale1.CircularPointers = pointers1;

            circularScales1.Add(scale1);
            circularGauge.CircularScales = circularScales1;

            circularGauge.SetBackgroundColor(Color.White);

            LinearLayout outerLinearLayout = (LinearLayout)sfCircularGauge.FindViewById(Resource.Id.linearLayout);

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            linearLayout.AddView(sfCircularGauge, LayoutParams.WrapContent, (int)(screenHeight / 2.7));
            linearLayout.AddView(circularGauge, LayoutParams.WrapContent, (int)(screenHeight / 2.7));
            linearLayout.SetBackgroundColor(Color.White);
            linearLayout.SetPadding(30, 30, 30, 30);
            ScrollView mainView = new ScrollView(con);
            mainView.AddView(linearLayout);

            
            return mainView;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
                TextView pointervalue = new TextView(context);
                pointervalue.Text = "Change Pointer Value";
                pointervalue.Typeface = Typeface.DefaultBold;
                pointervalue.SetTextColor(Color.ParseColor("#262626"));
                pointervalue.TextSize = 20;

                SeekBar pointerSeek = new SeekBar(context);
                pointerSeek.Max = 1000;
                pointerSeek.Progress = 800;
                pointerSeek.ProgressChanged += pointerSeek_ProgressChanged;

                TextView pointervalue1 = new TextView(context);
                pointervalue1.Text = "RangePointer Color";
                pointervalue1.Typeface = Typeface.DefaultBold;
                pointervalue1.SetTextColor(Color.ParseColor("#262626"));
                pointervalue1.TextSize = 20;

                Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
                adapter = new List<String>() { "Yellow", "Green", "Pink" };

                ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                    (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
                dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
                selectLabelMode.Adapter = dataAdapter;
                selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

                TextView pointervalue2 = new TextView(context);
                pointervalue2.Text = "NeedlePointer Color";
                pointervalue2.Typeface = Typeface.DefaultBold;
                pointervalue2.SetTextColor(Color.ParseColor("#262626"));
                pointervalue2.TextSize = 20;

                Spinner selectLabelModel1 = new Spinner(context, SpinnerMode.Dialog);
                adapter1 = new List<String>() { "Black", "Violet", "Brown" };

                ArrayAdapter<String> dataAdapter1 = new ArrayAdapter<String>
                    (context, Android.Resource.Layout.SimpleSpinnerItem, adapter1);
                dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
                selectLabelModel1.Adapter = dataAdapter1;
                selectLabelModel1.ItemSelected += SelectLabelMode_ItemSelected1;

                TextView pointervalue3 = new TextView(context);
                pointervalue3.Text = "Range Color";
                pointervalue3.Typeface = Typeface.DefaultBold;
                pointervalue3.SetTextColor(Color.ParseColor("#262626"));
                pointervalue3.TextSize = 20;

                Spinner selectLabelModel2 = new Spinner(context, SpinnerMode.Dialog);
                adapter2 = new List<String>() { "LightGray", "Blue", "Orange" };

                ArrayAdapter<String> dataAdapter2 = new ArrayAdapter<String>
                    (context, Android.Resource.Layout.SimpleSpinnerItem, adapter2);
                dataAdapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
                selectLabelModel2.Adapter = dataAdapter2;
                selectLabelModel2.ItemSelected += SelectLabelMode_ItemSelected2;

                optionsPage = new LinearLayout(context);

                optionsPage.Orientation = Orientation.Vertical;
                optionsPage.AddView(pointervalue);
                optionsPage.AddView(pointerSeek);
                optionsPage.AddView(pointervalue1);
                optionsPage.AddView(selectLabelMode);
                optionsPage.AddView(pointervalue2);
                optionsPage.AddView(selectLabelModel1);
                optionsPage.AddView(pointervalue3);
                optionsPage.AddView(selectLabelModel2);

                optionsPage.SetPadding(10, 10, 10, 10);
                optionsPage.SetBackgroundColor(Color.White);
              
                return optionsPage;
        }

        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter[e.Position];
            if (selectedItem.Equals("Yellow"))
            {
                rangePointer.Color = Color.Yellow;
                rangePointer1.Color = Color.Yellow;
            }
            else if (selectedItem.Equals("Green"))
            {
                rangePointer.Color = Color.Green;
                rangePointer1.Color = Color.Green;
            }
            else if (selectedItem.Equals("Pink"))
            {
                rangePointer.Color = Color.Pink;
                rangePointer1.Color = Color.Pink;
            }
        }

        private void SelectLabelMode_ItemSelected1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter1[e.Position];
            if (selectedItem.Equals("Black"))
            {
                needlePointer.Color = Color.ParseColor("#424242");
                needlePointer.KnobColor = Color.ParseColor("#424242");
            }
            else if (selectedItem.Equals("Violet"))
            {
                needlePointer.Color = Color.Violet;
                needlePointer.KnobColor = Color.Violet;
            }
            else if (selectedItem.Equals("Brown"))
            {
                needlePointer.Color = Color.Brown;
                needlePointer.KnobColor = Color.Brown;
            }
        }

        private void SelectLabelMode_ItemSelected2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter2[e.Position];
            if (selectedItem.Equals("LightGray"))
            {
                circularRange.Color = Color.LightGray;
                circularRange1.Color = Color.LightGray;
            }
            else if (selectedItem.Equals("Blue"))
            {
                circularRange.Color = Color.Blue;
                circularRange1.Color = Color.Blue;
            }
            else if (selectedItem.Equals("Orange"))
            {
                circularRange.Color = Color.Orange;
                circularRange1.Color = Color.Orange;
            }
        }

        void pointerSeek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            value = e.Progress;
            header.Text = Math.Round(value, 2) + " GB";
            header1.Text = Math.Round(value, 2) + " GB";
            needlePointer.Value = value;
            rangePointer.Value = value;
            rangePointer1.Value = value;
        }
    }
}
