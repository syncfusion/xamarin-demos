#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System; using Syncfusion.SfGauge.iOS; using System.Collections.ObjectModel; using System.Threading.Tasks;

#if __UNIFIED__ using Foundation; using UIKit; using CoreGraphics; using System.Drawing;
#else using MonoTouch.Foundation; using MonoTouch.UIKit; using MonoTouch.CoreGraphics; using CGRect = System.Drawing.RectangleF; using CGPoint = System.Drawing.PointF; using CGSize = System.Drawing.SizeF; using nfloat = System.Single; using System.Drawing; 
#endif namespace SampleBrowser {
    public class CircularGaugeAnnotation : SampleView
    {

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public SFCircularGauge Gauge { get; set; }

        public SFCircularGauge Annotation1 { get; set; }

        public SFCircularGauge Annotation2 { get; set; }

        public UILabel LabelAnnotation1 { get; set; }

        public UILabel LabelAnnotation2 { get; set; }

        public UILabel LabelAnnotation3 { get; set; }

        bool isDispose = false;

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }

            if (Utility.IsIPad)
            {
                Gauge.Frame = new CGRect(50, 50, (float)this.Frame.Width - 100, (float)this.Frame.Height - 100);
            }
            else
            {
                Gauge.Frame = new CGRect(10, 10, (float)this.Frame.Width - 20, (float)this.Frame.Height - 20);

            }
            base.LayoutSubviews();
        }
        public CircularGaugeAnnotation()
        {

            Gauge = new SFCircularGauge();

            SFCircularScale scale = new SFCircularScale();

            scale.StartValue = 0;
            scale.EndValue = 12;
            scale.Interval = 1;
            scale.Interval = 1;
            scale.MinorTicksPerInterval = 4;
            scale.RimColor = UIColor.FromRGB(237, 238, 239);
            scale.LabelColor = UIColor.Gray;
            scale.LabelOffset = 0.8f;
            scale.ScaleEndOffSet = 0.925f;
            scale.StartAngle = -180;
            scale.SweepAngle = 180;
            scale.LabelFont = UIFont.SystemFontOfSize(14);
            scale.ShowFirstLabel = false;
            scale.MinorTickSettings = new SFTickSettings { Color = UIColor.Black, StartOffset = 1, EndOffset = .95f, Width = 1 };
            scale.MajorTickSettings = new SFTickSettings { Color = UIColor.Black, StartOffset = 1, EndOffset = .9f, Width = 3 };
            scale.Ranges = new ObservableCollection<SFCircularRange>
            {
                new SFCircularRange {StartValue = 0, EndValue = 3, Color= UIColor.Gray, InnerStartOffset = 0.925f, OuterStartOffset = 1, InnerEndOffset = 0.925f, OuterEndOffset = 1}
            };
            scale.Pointers = new ObservableCollection<SFCircularPointer>
            {
                new SFNeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .75f, KnobColor = UIColor.White, Color = UIColor.Black, Width = 3.5f, KnobStrokeColor = UIColor.Black,
                    KnobStrokeWidth = 5 , TailLengthFactor = 0.25f, TailColor = UIColor.Black},
                new SFNeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .4f, KnobColor = UIColor.White, Color = UIColor.Black, Width = 5, PointerType= SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle },
                new SFNeedlePointer { EnableAnimation = false, KnobRadius = 6, LengthFactor = .65f, KnobColor = UIColor.White, Color =UIColor.Black, Width = 5, PointerType= SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle},
            };

            SFGaugeAnnotation anno = new SFGaugeAnnotation();


            LabelAnnotation1 = new UILabel { Text = "", Font = UIFont.FromName("Helvetica", 12f), TextColor = UIColor.Black }; LabelAnnotation1.Frame = new CGRect(0, 0, 50, 50);
            anno.View = LabelAnnotation1;
            anno.Angle = 00;
            anno.Offset = 0.5f;

            SFGaugeAnnotation anno1 = new SFGaugeAnnotation();
            LabelAnnotation2 = new UILabel { Text = "", Font = UIFont.FromName("Helvetica", 12f), TextColor = UIColor.Black };
            LabelAnnotation2.Frame = new CGRect(0, 0, 50, 50);
            anno1.View = LabelAnnotation2;
            anno1.Angle = 300;
            anno1.Offset = 0.6f;


            Annotation1 = new SFCircularGauge()
            {
                Scales = new ObservableCollection<SFCircularScale>
                {
                    new SFCircularScale()
                    {
                        StartAngle = -180,
                        SweepAngle = 180,
                        ShowLabels = false,
                        StartValue = 0,
                        EndValue = 60,
                        Interval = 5,
                        RimColor = UIColor.FromRGB(237, 238, 239),
                        Ranges = new ObservableCollection<SFCircularRange>
                        {
                            new SFCircularRange() {StartValue = 0, EndValue = 30, Color = UIColor.Gray,
                                InnerStartOffset = 0.925f, OuterStartOffset = 1,
                                InnerEndOffset = 0.925f, OuterEndOffset = 1} ,
                        },
                        MajorTickSettings = new SFTickSettings { Color = UIColor.Black, StartOffset = 1, EndOffset = .85f, Width = 2f },
                        MinorTickSettings = new SFTickSettings { Color = UIColor.Black, StartOffset = 1, EndOffset = .90f, Width = 0.5f },
                        Pointers = new ObservableCollection<SFCircularPointer>
                        {
                            new SFNeedlePointer
                            {
                                PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle, KnobRadius = 4, Width = 3, EnableAnimation = false, KnobColor = UIColor.Black, Color = UIColor.Black
                            }
                        }
                    }
                }
            };

            Annotation1.Annotations.Add(anno1);

            Annotation1.Frame = new CGRect(0, 0, 70, 70);

            SFGaugeAnnotation anno2 = new SFGaugeAnnotation();

            anno2.View = Annotation1;
            anno2.Angle = 90;
            anno2.Offset = 0.5f;

            SFGaugeAnnotation anno3 = new SFGaugeAnnotation();
            LabelAnnotation3 = new UILabel { Text = "", Font = UIFont.FromName("Helvetica", 12f), TextColor = UIColor.Black };
            LabelAnnotation3.Frame = new CGRect(10, 10, 50, 50);
            anno3.View = LabelAnnotation3;
            anno3.Angle = 300;
            anno3.Offset = 0.55f;

            Annotation2 = new SFCircularGauge
            {
                Scales = new ObservableCollection<SFCircularScale>
                {
                    new SFCircularScale()
                    {
                        StartAngle = -180,
                        SweepAngle = 180,
                        StartValue = 0,
                        EndValue = 60,
                        Interval = 5,
                        ShowLabels = false,
                        RimColor = UIColor.FromRGB(237, 238, 239),
                        Ranges = new ObservableCollection<SFCircularRange>
                        {
                            new SFCircularRange() {StartValue = 0, EndValue = 30, Color = UIColor.Gray,
                                InnerStartOffset = 0.925f, OuterStartOffset = 1, InnerEndOffset = 0.925f, OuterEndOffset = 1} ,
                        },
                        MajorTickSettings = new SFTickSettings { Color = UIColor.Black, StartOffset = 1, EndOffset = .85f, Width = 2 },
                        MinorTickSettings = new SFTickSettings { Color = UIColor.Black, StartOffset = 1, EndOffset = .90f, Width = 0.5f },
                        Pointers = new ObservableCollection<SFCircularPointer>
                        {
                            new SFNeedlePointer
                            {
                                PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeTriangle, KnobRadius = 4, Width = 3, EnableAnimation = false, KnobColor = UIColor.Black, Color = UIColor.Black
                            }
                        }
                    }
                }
            };

            Annotation2.Annotations.Add(anno3);

            Annotation2.Frame = new CGRect(0, 0, 70, 70);

            SFGaugeAnnotation anno4 = new SFGaugeAnnotation();

            anno4.View = Annotation2;
            anno4.Angle = 180;
            anno4.Offset = 0.5f;

            Gauge.Scales.Add(scale);
            Gauge.Annotations.Add(anno);
            Gauge.Annotations.Add(anno2);
            Gauge.Annotations.Add(anno4);
            DynamicUpdate();

            this.AddSubview(Gauge);
        }

        private async void DynamicUpdate()
        {
            while (!isDispose)
            {
                var dataTime = DateTime.Now;
                var hour = (double)dataTime.Hour;
                hour = hour > 12 ? hour % 12 : hour;

                var min = (double)dataTime.Minute;
                var sec = (double)dataTime.Second;
                if (Gauge.Scales.Count > 0)
                {


                    Gauge.Scales[0].Pointers[0].Value = (nfloat)sec / 5;

                    Gauge.Scales[0].Pointers[1].Value = (nfloat)(hour + min / 60);

                    Gauge.Scales[0].Pointers[2].Value = (nfloat)(min / 5 + (sec / 60 * .2));

                    Annotation1.Scales[0].Pointers[0].Value = (nfloat)sec;

                    Annotation2.Scales[0].Pointers[0].Value = (nfloat)(min + sec / 60);

                    var meridiem = dataTime.Hour > 12 ? "PM" : "AM";
                    LabelAnnotation1.Text = hour.ToString() + " : " + min.ToString() + " " + meridiem;

                    LabelAnnotation2.Text = sec.ToString() + " S";

                    LabelAnnotation3.Text = min.ToString() + " M";

                    await Task.Delay(1000);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            isDispose = disposing;
            base.Dispose(disposing);
        }
    } }  