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
    public class MultipleScale : SamplePage
    {
        double value;
        double value1;
        double value2;
        double value3;
        CircularScale scale;
        CircularScale circularScale2;
        public override View GetSampleContent (Context con)
		{
            SfCircularGauge sfCircularGauge = new SfCircularGauge(con);

            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            scale  = new CircularScale();
            scale.StartValue = 0;
            scale.EndValue = 240;
            scale.Interval = 20;
            scale.StartAngle = 135;
            scale.SweepAngle = 270;
            scale.RimColor = Color.ParseColor("#C62E0A");
            scale.LabelColor = Color.ParseColor("#C62E0A");
            scale.LabelOffset = 0.88;
            scale.ScaleStartOffset = 0.7;
            scale.ScaleEndOffset = 0.69;
            scale.MinorTicksPerInterval = 1;
            scale.MajorTickSettings.StartOffset = 0.7;
            scale.MajorTickSettings.EndOffset = 0.77;
            scale.MajorTickSettings.Width = 2;
            scale.MajorTickSettings.Color = Color.ParseColor("#C62E0A");
            scale.MinorTickSettings.StartOffset = 0.7;
            scale.MinorTickSettings.EndOffset = 0.75;
            scale.MinorTickSettings.Width = 2;
            scale.MinorTickSettings.Color = Color.ParseColor("#C62E0A");

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();
            MarkerPointer markerPointer = new MarkerPointer();
            markerPointer.Value = 120;
            markerPointer.Color = Color.ParseColor("#C62E0A");
            markerPointer.Offset = 0.69;
            markerPointer.MarkerShape = Com.Syncfusion.Gauges.SfCircularGauge.Enums.MarkerShape.InvertedTriangle;
            markerPointer.EnableAnimation = false;
            pointers.Add(markerPointer);

            scale.CircularPointers = pointers;
            circularScales.Add(scale);

            circularScale2 = new CircularScale();
            circularScale2.StartAngle = 135;
            circularScale2.SweepAngle = 270;
            circularScale2.StartValue = 0;
            circularScale2.EndValue = 160;
            circularScale2.Interval = 40;
            circularScale2.MinorTicksPerInterval = 1;
            circularScale2.RimColor = Color.ParseColor("#333333");
            circularScale2.LabelOffset = 0.45;
            circularScale2.LabelColor = Color.ParseColor("#333333");
            circularScale2.ScaleStartOffset = 0.65;
            circularScale2.ScaleEndOffset = 0.64;
            circularScale2.MajorTickSettings.StartOffset = 0.64;
            circularScale2.MajorTickSettings.EndOffset = 0.57;
            circularScale2.MajorTickSettings.Width = 2;
            circularScale2.MajorTickSettings.Color = Color.ParseColor("#333333");
            circularScale2.MinorTickSettings.StartOffset = 0.64;
            circularScale2.MinorTickSettings.EndOffset = 0.59;
            circularScale2.MinorTickSettings.Width = 2;
            circularScale2.MinorTickSettings.Color = Color.ParseColor("#333333");

            ObservableCollection<CircularPointer> circularPointers = new ObservableCollection<CircularPointer>();
            MarkerPointer markerPointer1 = new MarkerPointer();
            markerPointer1.Value = 80;
            markerPointer1.Color = Color.ParseColor("#333333");
            markerPointer1.Offset = 0.65;
            markerPointer1.MarkerShape = Com.Syncfusion.Gauges.SfCircularGauge.Enums.MarkerShape.Triangle;
            markerPointer1.EnableAnimation = false;
            circularPointers.Add(markerPointer1);

            circularScale2.CircularPointers = circularPointers;
            circularScales.Add(circularScale2);

            sfCircularGauge.CircularScales = circularScales;

            sfCircularGauge.SetBackgroundColor(Color.White);

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.AddView(sfCircularGauge);
            linearLayout.SetPadding(30, 30, 30, 30);
            linearLayout.SetBackgroundColor(Color.White);
            return linearLayout;
		}

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView startAngle = new TextView(context);
            startAngle.Text = "Change StartAngle";
            startAngle.Typeface = Typeface.DefaultBold;
            startAngle.SetTextColor(Color.ParseColor("#262626"));
            startAngle.TextSize = 20;

            TextView sweepAngle = new TextView(context);
            sweepAngle.Text = "Change SweepAngle";
            sweepAngle.Typeface = Typeface.DefaultBold;
            sweepAngle.SetTextColor(Color.ParseColor("#262626"));
            sweepAngle.TextSize = 20;

            TextView startAngle1 = new TextView(context);
            startAngle1.Text = "Change StartAngle";
            startAngle1.Typeface = Typeface.DefaultBold;
            startAngle1.SetTextColor(Color.ParseColor("#262626"));
            startAngle1.TextSize = 20;

            TextView sweepAngle1 = new TextView(context);
            sweepAngle1.Text = "Change SweepAngle";
            sweepAngle1.Typeface = Typeface.DefaultBold;
            sweepAngle1.SetTextColor(Color.ParseColor("#262626"));
            sweepAngle1.TextSize = 20;

            SeekBar pointerSeek = new SeekBar(context);
            pointerSeek.Max = 350;
            pointerSeek.Progress = 135;
            pointerSeek.ProgressChanged += pointerSeek_ProgressChanged;

            SeekBar pointerSeek1 = new SeekBar(context);
            pointerSeek1.Max = 350;
            pointerSeek1.Progress = 270;
            pointerSeek1.ProgressChanged += pointerSeek_ProgressChanged1;

            SeekBar pointerSeek2 = new SeekBar(context);
            pointerSeek2.Max = 350;
            pointerSeek2.Progress = 135;
            pointerSeek2.ProgressChanged += pointerSeek_ProgressChanged2;

            SeekBar pointerSeek3 = new SeekBar(context);
            pointerSeek3.Max = 350;
            pointerSeek3.Progress = 270;
            pointerSeek3.ProgressChanged += pointerSeek_ProgressChanged3;

            LinearLayout optionsPage = new LinearLayout(context);

            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(startAngle);
            optionsPage.AddView(pointerSeek);
            optionsPage.AddView(sweepAngle);
            optionsPage.AddView(pointerSeek1);
            optionsPage.AddView(startAngle1);
            optionsPage.AddView(pointerSeek2);
            optionsPage.AddView(sweepAngle1);
            optionsPage.AddView(pointerSeek3);

            optionsPage.SetPadding(10, 10, 10, 10);
            optionsPage.SetBackgroundColor(Color.White);
            return optionsPage;
        }

        void pointerSeek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            value = e.Progress;
            scale.StartAngle = value;
        }

        void pointerSeek_ProgressChanged1(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            value1 = e.Progress;
            scale.SweepAngle = value1;
        }

        void pointerSeek_ProgressChanged2(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            value2 = e.Progress;
            circularScale2.StartAngle = value2;
        }

        void pointerSeek_ProgressChanged3(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            value3 = e.Progress;
            circularScale2.SweepAngle = value3;
        }

        //public override void OnApplyChanges()
        //{
        //    base.OnApplyChanges();
        //    scale.StartAngle = value;
        //    scale.SweepAngle = value1;
        //    circularScale2.StartAngle = value2;
        //    circularScale2.SweepAngle = value3;
        //}
    }
}
