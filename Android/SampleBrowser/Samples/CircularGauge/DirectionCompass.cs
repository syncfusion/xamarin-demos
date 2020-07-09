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

namespace SampleBrowser
{
    public class DirectionCompass : SamplePage
    {
        List<String> adapter;
        NeedlePointer pointer;

        public override View GetSampleContent (Context con)
		{
            SfCircularGauge sfCircularGauge = new SfCircularGauge(con);

            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            CircularScale scale = new CircularScale();
            scale.StartAngle = 270;
            scale.StartValue = 0;
            scale.EndValue = 16;
            scale.Interval = 2;
            scale.LabelOffset = 0.75;
            scale.SweepAngle = 360;
            scale.MinorTicksPerInterval = 1;
            scale.ShowLastLabel = false;
            scale.ScaleStartOffset = 0.99;
            scale.ScaleEndOffset = 0.9;
            scale.LabelCreated += Scale_LabelCreated;
            scale.RimColor = Color.ParseColor("#E0E0E0");
            scale.LabelColor = Color.ParseColor("#4B4B4B");
            scale.MajorTickSettings.StartOffset = 0.9;
            scale.MajorTickSettings.EndOffset = 0.83;
            scale.MajorTickSettings.Width = 2;
            scale.MajorTickSettings.Color = Color.ParseColor("#9E9E9E");
            scale.MinorTickSettings.StartOffset = 0.9;
            scale.MinorTickSettings.EndOffset = 0.85;
            scale.MinorTickSettings.Width = 2;
            scale.MinorTickSettings.Color = Color.ParseColor("#9E9E9E");

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();
            pointer = new NeedlePointer();
            pointer.Value = 14;
            pointer.Color = Color.ParseColor("#f03e3e");
            pointer.Type = Com.Syncfusion.Gauges.SfCircularGauge.Enums.NeedleType.Triangle;
            pointer.LengthFactor = 0.65;
            pointer.Width = 20;
            pointer.KnobRadiusFactor = 0;
            pointer.KnobColor = Color.White;
            pointer.KnobStrokeWidth = 3;
            pointer.KnobStrokeColor = Color.White;
            pointer.EnableAnimation = false;
            pointers.Add(pointer);

            NeedlePointer needlePointer = new NeedlePointer();
            needlePointer.Value = 6;
            needlePointer.Type = Com.Syncfusion.Gauges.SfCircularGauge.Enums.NeedleType.Triangle;
            needlePointer.LengthFactor = 0.65;
            needlePointer.Width = 20;
            needlePointer.Color = Color.ParseColor("#9E9E9E");
            needlePointer.KnobRadiusFactor = 0.11;
            needlePointer.KnobColor = Color.White;
            needlePointer.KnobStrokeWidth = 3;
            needlePointer.KnobStrokeColor = Color.White;
            needlePointer.EnableAnimation = false;
            pointers.Add(needlePointer);

            scale.CircularPointers = pointers;
            circularScales.Add(scale);
            sfCircularGauge.CircularScales = circularScales;

            sfCircularGauge.SetBackgroundColor(Color.White);

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.AddView(sfCircularGauge);
            linearLayout.SetPadding(30, 30, 30, 30);
            linearLayout.SetBackgroundColor(Color.White);
            return linearLayout;
		}

        private void Scale_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            switch ((string)e.LabelContent)
            {

                case "0":
                    e.LabelContent = "N";
                    break;
                case "2":
                    e.LabelContent = "NE";
                    break;
                case "4":
                    e.LabelContent = "E";
                    break;
                case "6":
                    e.LabelContent = "SE";
                    break;
                case "8":
                    e.LabelContent = "S";
                    break;
                case "10":
                    e.LabelContent = "SW";
                    break;
                case "12":
                    e.LabelContent = "W";
                    break;
                case "14":
                    e.LabelContent = "NW";
                    break;
            }
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView pointervalue1 = new TextView(context);
            pointervalue1.Text = "RangePointer Color";
            pointervalue1.Typeface = Typeface.DefaultBold;
            pointervalue1.SetTextColor(Color.ParseColor("#262626"));
            pointervalue1.TextSize = 20;

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            adapter = new List<String>() { "Red", "Blue", "Orange" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;

            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            LinearLayout optionsPage = new LinearLayout(context);

            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(pointervalue1);
            optionsPage.AddView(selectLabelMode);

            optionsPage.SetPadding(10, 10, 10, 10);
            optionsPage.SetBackgroundColor(Color.White);
            return optionsPage;
        }

        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter[e.Position];
            if (selectedItem.Equals("Red"))
            {
                pointer.Color = Color.Red;
                
            }
            else if (selectedItem.Equals("Blue"))
            {
                pointer.Color = Color.Blue;
                
            }
            else if (selectedItem.Equals("Orange"))
            {
                pointer.Color = Color.Orange;
               
            }
        }
    }

}

