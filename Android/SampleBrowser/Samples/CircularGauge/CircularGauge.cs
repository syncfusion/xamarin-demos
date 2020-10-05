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
    public class CircularGauge: SamplePage
    {

        NeedlePointer pointer;
        double value;

        public override View GetSampleContent (Context con)
		{
            SfCircularGauge sfCircularGauge = new SfCircularGauge(con);

            ObservableCollection<CircularScale> circularScales = new ObservableCollection<CircularScale>();
            CircularScale scale = new CircularScale();
            scale.StartValue = 0;
            scale.EndValue = 100;
            scale.Interval = 10;
            scale.StartAngle = 135;
            scale.SweepAngle = 270;
            scale.RimWidth = 10;
            scale.RimColor = Color.ParseColor("#E0E0E0");
            scale.LabelColor = Color.Black;
            scale.LabelOffset = 0.8;
            scale.ShowTicks = false;
            scale.MinorTicksPerInterval = 0;

            ObservableCollection<CircularPointer> pointers = new ObservableCollection<CircularPointer>();
            pointer = new NeedlePointer();
            pointer.Value = 60;
            pointer.KnobRadius = 10;
            pointer.Color = Color.ParseColor("#757575");
            pointer.KnobColor = Color.ParseColor("#757575");
            pointer.LengthFactor = 0.6;
            pointer.Type = Com.Syncfusion.Gauges.SfCircularGauge.Enums.NeedleType.Triangle;
            pointers.Add(pointer);

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

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView pointervalue = new TextView(context);
            pointervalue.Text = "Change Pointer Value";
            pointervalue.Typeface = Typeface.DefaultBold;
            pointervalue.SetTextColor(Color.ParseColor("#262626"));
            pointervalue.TextSize = 20;

            SeekBar pointerSeek = new SeekBar(context);
            pointerSeek.Max = 100;
            pointerSeek.Progress = 60;
            pointerSeek.ProgressChanged += pointerSeek_ProgressChanged;

            LinearLayout optionsPage = new LinearLayout(context);

            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(pointervalue); 
            optionsPage.AddView(pointerSeek);
            
            optionsPage.SetPadding(10,10,10,10);
            optionsPage.SetBackgroundColor(Color.White);
            return optionsPage;
        }

        void pointerSeek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
			value = e.Progress;
            pointer.Value = value;
		}

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
		}
	}
}
