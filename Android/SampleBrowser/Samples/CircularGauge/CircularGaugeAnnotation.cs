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
using System.Threading.Tasks;
using static Android.App.ActionBar;

namespace SampleBrowser
{
    public class CircularGaugeAnnotation : SamplePage
    {
        public SfCircularGauge Gauge { get; set; }

        public SfCircularGauge Annotation1 { get; set; }

        public SfCircularGauge Annotation2 { get; set; }

        public TextView LabelAnnotation1 { get; set; }

        public TextView LabelAnnotation2 { get; set; }

        public TextView LabelAnnotation3 { get; set; }

        public override View GetSampleContent (Context con)
		{
            var density = con.Resources.DisplayMetrics.Density;
            LabelAnnotation1 = new TextView(con);
            LabelAnnotation1.Text = "4:55PM";
            LabelAnnotation1.TextSize = 14;
            LabelAnnotation1.SetHeight(25);
            LabelAnnotation1.SetWidth(75);
            LabelAnnotation1.SetTextColor(Color.Black);
            LabelAnnotation1.TextAlignment = TextAlignment.Center;

            LabelAnnotation2 = new TextView(con);
            LabelAnnotation2.Text = "10s";
            LabelAnnotation2.TextSize = 12;
            LabelAnnotation2.SetHeight(20);
            LabelAnnotation2.SetWidth(35);
            LabelAnnotation2.SetTextColor(Color.Black);
            LabelAnnotation2.TextAlignment = TextAlignment.Center;

            LabelAnnotation3 = new TextView(con);
            LabelAnnotation3.Text = "55M";
            LabelAnnotation3.TextSize = 12;
            LabelAnnotation3.SetHeight(20);
            LabelAnnotation3.SetWidth(35);
            LabelAnnotation3.SetTextColor(Color.Black);
            LabelAnnotation3.TextAlignment = TextAlignment.Center;
           

            Annotation1 = new SfCircularGauge(con)
            {
            Annotations = new CircularGaugeAnnotationCollection
                {
                    new GaugeAnnotation { View =  LabelAnnotation2, Angle = 250, Offset = 0.7f }
                },
                CircularScales = new ObservableCollection<CircularScale>
                {
                    new CircularScale
                    {
                        StartAngle = 270,
                        SweepAngle = 360,
                        ShowLabels = false,
                        StartValue = 0,
                        EndValue = 60,
                        Interval = 5,
                        RimColor = Color.Rgb(237, 238, 239),
                        CircularRanges = new ObservableCollection<CircularRange>
                        {
                            new CircularRange {StartValue = 0, EndValue = 30, Color = Color.Gray, InnerStartOffset = 0.925, OuterStartOffset = 1, InnerEndOffset = 0.925, OuterEndOffset = 1},
                        },
                        MajorTickSettings = new TickSetting { Color = Color.Black, StartOffset = 1, EndOffset = .85, Width = 2 },
                        MinorTickSettings = new TickSetting { Color = Color.Black, StartOffset = 1, EndOffset = .90, Width = 0.5 },
                        CircularPointers = new ObservableCollection<CircularPointer>
                        {
                            new NeedlePointer
                            {
                                Type = NeedleType.Triangle, KnobRadius = 4, Width = 3, EnableAnimation = false, KnobColor = Color.Black, Color = Color.Black
                            }
                        }
                    }
                }
            };
         
            LinearLayout layout1 = new LinearLayout(con);
            layout1.LayoutParameters = new LinearLayout.LayoutParams((int)(80 * density), (int)(80 * density));
            layout1.AddView(Annotation1);

            Annotation2 = new SfCircularGauge(con)
            {
                Annotations = new CircularGaugeAnnotationCollection
                {
                    new GaugeAnnotation { View = LabelAnnotation3, Angle = 245, Offset = 0.7f }
                },
                CircularScales = new ObservableCollection<CircularScale>
                {
                    new CircularScale
                    {
                        StartAngle = 270,
                        SweepAngle = 360,
                        StartValue = 0,
                        EndValue = 60,
                        Interval = 5,
                        ShowLabels = false,
                        RimColor = Color.Rgb(237, 238, 239),
                        CircularRanges = new ObservableCollection<CircularRange>
                        {
                            new CircularRange {StartValue = 0, EndValue = 30, Color = Color.Gray, InnerStartOffset = 0.925, OuterStartOffset = 1, InnerEndOffset = 0.925, OuterEndOffset = 1},
                        },
                        MajorTickSettings = new TickSetting { Color = Color.Black, StartOffset = 1, EndOffset = .85, Width = 2 },
                        MinorTickSettings = new TickSetting { Color = Color.Black, StartOffset = 1, EndOffset = .90, Width = 0.5 },
                        CircularPointers = new ObservableCollection<CircularPointer>
                        {
                            new NeedlePointer
                            {
                                Type = NeedleType.Triangle, KnobRadius = 4, Width = 3, EnableAnimation = false, KnobColor = Color.Black, Color = Color.Black
                            }
                        }
                    }
                }
            };
           
            LinearLayout layout2 = new LinearLayout(con);
            layout2.LayoutParameters = new LinearLayout.LayoutParams((int)(80 * density),(int)(80 * density));
            layout2.AddView(Annotation2);

            Gauge = new SfCircularGauge(con)
            {
                Annotations = new CircularGaugeAnnotationCollection
                {
                    new GaugeAnnotation { View = layout1, Angle = 90, Offset = .5f },
                    new GaugeAnnotation { View = LabelAnnotation1, Angle = 00, Offset = .3f },
                    new GaugeAnnotation { View = layout2, Angle = 180, Offset = .5f },
                },
                CircularScales = new ObservableCollection<CircularScale>
                {
                    new CircularScale
                    {
                        StartValue = 0,
                        EndValue = 12,
                        Interval = 1,
                        MinorTicksPerInterval = 4,
                        RimColor = Color.Rgb(237, 238, 239),
                        LabelColor = Color.Gray,
                        LabelOffset = .8,
                        ScaleEndOffset = .925,
                        StartAngle = 270,
                        SweepAngle = 360,
                        LabelTextSize = 14,
                        ShowFirstLabel = false,
                        MinorTickSettings = new TickSetting { Color = Color.Black, StartOffset = 1, EndOffset = .95, Width = 1 },
                        MajorTickSettings = new TickSetting { Color = Color.Black, StartOffset = 1, EndOffset = .9, Width = 3 },
                        CircularRanges = new ObservableCollection<CircularRange>
                        {
                            new CircularRange {StartValue = 0, EndValue = 3, Color= Color.Gray, InnerStartOffset = 0.925, OuterStartOffset = 1, InnerEndOffset = 0.925, OuterEndOffset = 1},
                        },
                        CircularPointers = new ObservableCollection<CircularPointer>
                        {
                            new NeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .75, KnobColor = Color.White, Color = Color.Black, Width = 3.5, KnobStrokeColor = Color.Black, KnobStrokeWidth = 5 , TailLengthFactor = 0.25, TailColor = Color.Black},
                            new NeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .4, KnobColor = Color.White, Color = Color.Black, Width = 5, Type = NeedleType.Triangle },
                            new NeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .65, KnobColor = Color.White, Color =Color.Black, Width = 5, Type = NeedleType.Triangle },
                        }
                    }
               }
            };

            DynamicUpdate();

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.AddView(Gauge);
            linearLayout.SetPadding(30, 30, 30, 30);
            linearLayout.SetBackgroundColor(Color.White);
            return linearLayout;
		}

        private async void DynamicUpdate()
        {
            while (true)
            {
                var dataTime = DateTime.Now;
                var hour = (double)dataTime.Hour;
                hour = hour > 12 ? hour % 12 : hour;

                var min = (double)dataTime.Minute;
                var sec = (double)dataTime.Second;

                Gauge.CircularScales[0].CircularPointers[0].Value = sec / 5;

                Gauge.CircularScales[0].CircularPointers[1].Value = hour + min / 60;

                Gauge.CircularScales[0].CircularPointers[2].Value = min / 5 + (sec / 60 * .2);

                Annotation1.CircularScales[0].CircularPointers[0].Value = sec;

                Annotation2.CircularScales[0].CircularPointers[0].Value = min + sec / 60;

                var meridiem = dataTime.Hour > 12 ? "PM" : "AM";
                LabelAnnotation1.Text = hour.ToString() + " : " + min.ToString() + " " + meridiem;

                LabelAnnotation2.Text = sec.ToString() + " S";

                LabelAnnotation3.Text = min.ToString() + " M";
                
                await Task.Delay(1000);
            }
        }
    }
}
