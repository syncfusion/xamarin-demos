#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncXForms = Syncfusion.SfGauge.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfCircularGauge
{
   [Preserve(AllMembers = true)]
   public partial class CircularGaugeAnnotation : SampleView
    {
        private SyncXForms.SfCircularGauge annotation1 { get; set; }

        private SyncXForms.SfCircularGauge annotation2 { get; set; }

        private Label labelAnnotation1 { get; set; }

        private Label labelAnnotation2 { get; set; }

        private Label labelAnnotation3 { get; set; }

        private bool isUpdate = false;
        public CircularGaugeAnnotation()
        {
            InitializeComponent();
            this.SizeChanged += AnnotationSample_SizeChanged;
        }
        private void AnnotationSample_SizeChanged(object sender, EventArgs e)
        {
            Padding = 15;

            labelAnnotation1 = new Label { Text = "", FontSize = 14, HeightRequest = 25, WidthRequest = 75, TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };

            labelAnnotation2 = new Label { Text = "", FontSize = 12, HeightRequest = 20, WidthRequest = 35, TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };

            labelAnnotation3 = new Label { Text = "", FontSize = 12, HeightRequest = 20, WidthRequest = 35, TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };

            Grid grid1 = new Grid();

            Grid grid2 = new Grid();

            Grid grid3 = new Grid();

            grid1.Children.Add(labelAnnotation1);

            grid2.Children.Add(labelAnnotation2);

            grid3.Children.Add(labelAnnotation3);

            var minSize = Math.Min(Gauge.Bounds.Height, Gauge.Bounds.Width);
            var annotationSize = minSize / 5.0;

            annotation1 = new SyncXForms.SfCircularGauge
            {
                HeightRequest = annotationSize,
                WidthRequest = annotationSize,

                Annotations = new SyncXForms.CircularGaugeAnnotationCollection
                {
                    new SyncXForms.GaugeAnnotation { View =  grid2, Angle = 270, Offset = .5 }
                },
                Scales = new ObservableCollection<SyncXForms.Scale>
                {
                    new SyncXForms.Scale
                    {
                        StartAngle = 270,
                        SweepAngle = 360,
                        ShowLabels = false,
                        StartValue = 0,
                        EndValue = 60,
                        Interval = 5,
                        RimColor = Color.FromRgb(237, 238, 239),
                        Ranges = new ObservableCollection<Syncfusion.SfGauge.XForms.Range>
                        {
                            new Syncfusion.SfGauge.XForms.Range {StartValue = 0, EndValue = 30, Color = Color.Gray, InnerStartOffset = 0.925, OuterStartOffset = 1, InnerEndOffset = 0.925, OuterEndOffset = 1},
                        },
                        MajorTickSettings = new SyncXForms.TickSettings { Color = Color.Black, StartOffset = 1, EndOffset = .85, Thickness = 2 },
                        MinorTickSettings = new SyncXForms.TickSettings { Color = Color.Black, StartOffset = 1, EndOffset = .90, Thickness = 0.5 },
                        Pointers = new ObservableCollection<SyncXForms.Pointer>
                        {
                            new SyncXForms.NeedlePointer
                            {
                                Type = SyncXForms.PointerType.Triangle, KnobRadius = 4, Thickness = 3, EnableAnimation = false, KnobColor = Color.Black, Color = Color.Black
                            }
                        }
                    }
                }
            };

            annotation1.Parent = this;

            annotation2 = new SyncXForms.SfCircularGauge
            {
                HeightRequest = annotationSize,
                WidthRequest = annotationSize,

                Annotations = new SyncXForms.CircularGaugeAnnotationCollection
                {
                    new SyncXForms.GaugeAnnotation { View = grid3, Angle = 270, Offset = .5 }
                },
                Scales = new ObservableCollection<SyncXForms.Scale>
                {
                    new SyncXForms.Scale
                    {
                        StartAngle = 270,
                        SweepAngle = 360,
                        StartValue = 0,
                        EndValue = 60,
                        Interval = 5,
                        ShowLabels = false,
                        RimColor = Color.FromRgb(237, 238, 239),
                        Ranges = new ObservableCollection<Syncfusion.SfGauge.XForms.Range>
                        {
                            new Syncfusion.SfGauge.XForms.Range {StartValue = 0, EndValue = 30, Color = Color.Gray, InnerStartOffset = 0.925, OuterStartOffset = 1, InnerEndOffset = 0.925, OuterEndOffset = 1},
                        },
                        MajorTickSettings = new SyncXForms.TickSettings { Color = Color.Black, StartOffset = 1, EndOffset = .85, Thickness = 2 },
                        MinorTickSettings = new SyncXForms.TickSettings { Color = Color.Black, StartOffset = 1, EndOffset = .90, Thickness = 0.5 },
                        Pointers = new ObservableCollection<SyncXForms.Pointer>
                        {
                            new SyncXForms.NeedlePointer
                            {
                                Type = SyncXForms.PointerType.Triangle, KnobRadius = 4, Thickness = 3, EnableAnimation = false, KnobColor = Color.Black, Color = Color.Black
                            }
                        }
                    }
                }
            };

            annotation2.Parent = this;
            Gauge = new SyncXForms.SfCircularGauge()
            {
                Annotations = new SyncXForms.CircularGaugeAnnotationCollection
            {
                new SyncXForms.GaugeAnnotation { View = annotation1, Angle = 90, Offset = GetOffsetValue(.5,.5,.6) },
                new SyncXForms.GaugeAnnotation { View = grid1, Angle = 00, Offset = 0.45 },
                new SyncXForms.GaugeAnnotation { View = annotation2, Angle = 180, Offset = GetOffsetValue(.5, .5, .6) },
            },
                Scales = new ObservableCollection<SyncXForms.Scale>
                {
                    new SyncXForms.Scale
                    {
                        StartValue = 0,
                        EndValue = 12,
                        Interval = 1,
                        MinorTicksPerInterval = 4,
                        RimColor = Color.FromRgb(237, 238, 239),
                        LabelColor = Color.Gray,
                        LabelOffset = GetOffsetValue(.8, .8, .875),
                        ScaleEndOffset = .925,
                        StartAngle = 270,
                        SweepAngle = 360,
                        LabelFontSize = 14,
                        ShowFirstLabel = false,
                        MinorTickSettings = new SyncXForms.TickSettings { Color = Color.Black, StartOffset = 1, EndOffset = .95, Thickness = 1 },
                        MajorTickSettings = new SyncXForms.TickSettings { Color = Color.Black, StartOffset = 1, EndOffset = .9, Thickness = 3 },
                        Ranges = new ObservableCollection<Syncfusion.SfGauge.XForms.Range>
                        {
                            new SyncXForms.Range {StartValue = 0, EndValue = 3, Color= Color.Gray, InnerStartOffset = 0.925, OuterStartOffset = 1, InnerEndOffset = 0.925, OuterEndOffset = 1},
                        },
                        Pointers = new ObservableCollection<SyncXForms.Pointer>
                        {
                            new SyncXForms.NeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .75, KnobColor = Color.White, Color = Color.Black, Thickness = 3.5, KnobStrokeColor = Color.Black, KnobStrokeWidth = 5 , TailLengthFactor = 0.25, TailColor = Color.Black},
                            new SyncXForms.NeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .4, KnobColor = Color.White, Color = Color.Black, Thickness = 5, Type = SyncXForms.PointerType.Triangle },
                            new SyncXForms.NeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .65, KnobColor = Color.White, Color =Color.Black, Thickness = 5, Type = SyncXForms.PointerType.Triangle },
                        }
                    }
               }
            };
            isUpdate = true;
            DynamicUpdate();
            this.Content = Gauge;
        }

        private double GetOffsetValue(double ios, double android, double uwp)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return ios;
                case Device.Android:
                    return android;
                default:
                    return uwp;
            }
        }

        private async void DynamicUpdate()
        {
            while (isUpdate && Gauge != null && Gauge.Scales.Count > 0)
            {
                var dataTime = DateTime.Now;
                var hour = (double)dataTime.Hour;
                hour = hour > 12 ? hour % 12 : hour;

                var min = (double)dataTime.Minute;
                var sec = (double)dataTime.Second;

                Gauge.Scales[0].Pointers[0].Value = sec / 5;

                Gauge.Scales[0].Pointers[1].Value = hour + min / 60;

                Gauge.Scales[0].Pointers[2].Value = min / 5 + (sec / 60 * .2);

                annotation1.Scales[0].Pointers[0].Value = sec;

                annotation2.Scales[0].Pointers[0].Value = min + sec / 60;

                var meridiem = dataTime.Hour > 12 ? "PM" : "AM";
                labelAnnotation1.Text = hour.ToString() + " : " + min.ToString() + " " + meridiem;

                labelAnnotation2.Text = sec.ToString() + " S";

                labelAnnotation3.Text = min.ToString() + " M";

                await Task.Delay(1000);
            }
        }
        public override void OnDisappearing()
        {
            base.OnDisappearing();
            this.SizeChanged -= AnnotationSample_SizeChanged;
            isUpdate = false;
            if (annotation1 != null && annotation1.Parent != null)
            {
                annotation1.Parent = null;
                annotation1 = null;
            }
            if (annotation1 != null && annotation2.Parent != null)
            {
                annotation2.Parent = null;
                annotation2 = null;
            }
            if (Gauge != null)
                this.Gauge = null;
            if (this.Content != null)
                this.Content = null;
        }
    }
}
