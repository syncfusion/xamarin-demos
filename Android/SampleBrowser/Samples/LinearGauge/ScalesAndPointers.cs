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
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfLinearGauge;

namespace SampleBrowser
{
    public class ScalesAndPointers : SamplePage
    {
        public static int pointervalue = 30;
        public static int barvalue=75;
        List<String> adapter, adapter1, adapter2;
        LinearScale outerScale;
        SymbolPointer outerScale_needlePointer;
        LinearLayout optionsPage;
        BarPointer rangePointer;

        public override View GetSampleContent(Android.Content.Context con)
        {
            /****************
           **Linear Gauge**
           ****************/
            SfLinearGauge linearGauge = new SfLinearGauge(con);
            ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale>();
            ObservableCollection<LinearPointer> pointers = new ObservableCollection<LinearPointer>();
 
            linearGauge.SetX(0);
            linearGauge.SetY(0);
            linearGauge.SetBackgroundColor(Color.Rgb(255, 255, 255));
            linearGauge.SetOrientation(SfLinearGauge.Orientation.Horizontal);


            //OuterScale
            outerScale = new LinearScale();
            outerScale.Minimum = 0;
            outerScale.Maximum = 100;
            outerScale.ScaleBarSize = 40;
            outerScale.Interval = 10;
            outerScale.ScaleBarColor = Color.ParseColor("#e0e9f9");
            outerScale.MinorTicksPerInterval = 0;
            outerScale.LabelFontSize = 14;
            outerScale.LabelColor = Color.ParseColor("#424242");
            outerScale.CornerRadius = 20;
            outerScale.CornerRadiusType = CornerRadiusType.End;

            //OuterScale MajorTicksSettings
            LinearTickSettings outerScale_majorTicksSettings = new LinearTickSettings();
            outerScale_majorTicksSettings.Color = Color.ParseColor("#9E9E9E");//
            outerScale_majorTicksSettings.Length = 10;
            outerScale_majorTicksSettings.StrokeWidth = 1;
            outerScale.MajorTickSettings = outerScale_majorTicksSettings;

            //Symbol Pointer
            outerScale_needlePointer = new SymbolPointer();
            outerScale_needlePointer.SymbolPosition = SymbolPointerPosition.Away;
            outerScale_needlePointer.Value = pointervalue;
            outerScale_needlePointer.StrokeWidth = 12;
            outerScale_needlePointer.Color = Color.ParseColor("#5b86e5");
            outerScale_needlePointer.MarkerShape = MarkerShape.Triangle;
            outerScale_needlePointer.EnableAnimation = false;
            pointers.Add(outerScale_needlePointer);

            //Bar Pointer
            rangePointer = new BarPointer();
            rangePointer.Value = barvalue;
            rangePointer.StrokeWidth = 30;
            rangePointer.EnableAnimation = false;
            rangePointer.CornerRadius = 15;
            rangePointer.CornerRadiusType = CornerRadiusType.End;
            rangePointer.GradientStops = new ObservableCollection<GaugeGradientStop>()
            {
                new GaugeGradientStop() { Value = 0, Color = Color.ParseColor("#36d1dc") },
                new GaugeGradientStop() { Value = 75, Color = Color.ParseColor("#5b86e5") }
            };
            pointers.Add(rangePointer);
            outerScale.Pointers = pointers;

            scales.Add(outerScale);
            linearGauge.Scales = scales;

            //Linear Gauge Layout
            LinearLayout linearGaugeLayout = new LinearLayout(con);
            linearGaugeLayout.SetBackgroundColor(Color.Rgb(255, 255, 255));
            linearGaugeLayout.AddView(linearGauge);

            return linearGaugeLayout;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView pointervalue1 = new TextView(context);
            pointervalue1.Text = "Opposite Position";
            pointervalue1.Typeface = Typeface.DefaultBold;
            pointervalue1.SetTextColor(Color.ParseColor("#262626"));
            pointervalue1.TextSize = 20;

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            adapter = new List<String>() { "False", "True" };
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;
            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            TextView pointervalue2 = new TextView(context);
            pointervalue2.Text = "Corner Radius Type";
            pointervalue2.Typeface = Typeface.DefaultBold;
            pointervalue2.SetTextColor(Color.ParseColor("#262626"));
            pointervalue2.TextSize = 20;

            Spinner selectLabelModel1 = new Spinner(context, SpinnerMode.Dialog);
            adapter1 = new List<String>() { "End", "Start", "Both", "None" };
            ArrayAdapter<String> dataAdapter1 = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter1);
            dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelModel1.Adapter = dataAdapter1;
            selectLabelModel1.ItemSelected += SelectLabelModel1_ItemSelected;

            TextView pointervalue3 = new TextView(context);
            pointervalue3.Text = "Marker Shapes";
            pointervalue3.Typeface = Typeface.DefaultBold;
            pointervalue3.SetTextColor(Color.ParseColor("#262626"));
            pointervalue3.TextSize = 20;

            Spinner selectLabelModel2 = new Spinner(context, SpinnerMode.Dialog);
            adapter2 = new List<String>() { "Triangle", "Inverted Triangle", "Circle", "Diamond", "Rectangle", "Image" };
            ArrayAdapter<String> dataAdapter2 = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter2);
            dataAdapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelModel2.Adapter = dataAdapter2;
            selectLabelModel2.ItemSelected += SelectLabelModel2_ItemSelected;


            optionsPage = new LinearLayout(context);
            optionsPage.Orientation = Orientation.Vertical;
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

        private void SelectLabelModel2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter2[e.Position];
            if (selectedItem.Equals("Triangle"))
            {
                outerScale_needlePointer.MarkerShape = MarkerShape.Triangle;
            }
            else if (selectedItem.Equals("Inverted Triangle"))
            {
                outerScale_needlePointer.MarkerShape = MarkerShape.InvertedTriangle;
            }
            else if (selectedItem.Equals("Circle"))
            {
                outerScale_needlePointer.MarkerShape = MarkerShape.Circle;
            }
            else if (selectedItem.Equals("Diamond"))
            {
                outerScale_needlePointer.MarkerShape = MarkerShape.Diamond;
            }
            else if (selectedItem.Equals("Rectangle"))
            {
                outerScale_needlePointer.MarkerShape = MarkerShape.Rectangle;
            }
            else if (selectedItem.Equals("Image"))
            {
                outerScale_needlePointer.MarkerShape = MarkerShape.Image;
                outerScale_needlePointer.ImageSource = "location.png";
            }
        }

        private void SelectLabelModel1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter1[e.Position];
            if (selectedItem.Equals("Start"))
            {
                outerScale.CornerRadiusType = CornerRadiusType.Start;
                rangePointer.CornerRadiusType = CornerRadiusType.Start;
            }
            else if (selectedItem.Equals("End"))
            {
                outerScale.CornerRadiusType = CornerRadiusType.End;
                rangePointer.CornerRadiusType = CornerRadiusType.End;
            }
            else if (selectedItem.Equals("Both"))
            {
                outerScale.CornerRadiusType = CornerRadiusType.Both;
                rangePointer.CornerRadiusType = CornerRadiusType.Both;
            }
            else if (selectedItem.Equals("None"))
            {
                outerScale.CornerRadiusType = CornerRadiusType.None;
                rangePointer.CornerRadiusType = CornerRadiusType.None;
            }
        }

        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter[e.Position];
            if (selectedItem.Equals("True"))
            {
                outerScale.OpposedPosition = true;
            }
            else if (selectedItem.Equals("False"))
            {
                outerScale.OpposedPosition = false;
            }
        }
    }
}