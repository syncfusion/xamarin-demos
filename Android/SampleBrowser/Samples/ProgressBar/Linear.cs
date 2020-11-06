#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SampleBrowser
{
    using System.Threading.Tasks;
    using Android.Content;
    using Android.Graphics;
    using Android.Views;
    using Android.Widget;
    using Syncfusion.Android.ProgressBar;

    public class Linear : SamplePage
    {
        private Context context;
        private LinearLayout.LayoutParams layoutParams;

        public override View GetSampleContent(Context ctx)
        {
            this.context = ctx;
            this.layoutParams = new LinearLayout.LayoutParams(
                this.context.Resources.DisplayMetrics.WidthPixels - 120,
                this.context.Resources.DisplayMetrics.HeightPixels / 18);

            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.SetPadding(60, 20, 0, 0);
            linearLayout.AddView(this.GetLinearDeterminate());
            linearLayout.AddView(this.GetLinearIndeterminate());
            linearLayout.AddView(this.GetLinearCornerRadius());
            linearLayout.AddView(this.GetLinearPadding());
            linearLayout.AddView(this.GetLinearRangeColors());
            linearLayout.AddView(this.GetLinearRangeColorsWithGradient());
            linearLayout.AddView(this.GetLinearBuffer());
            linearLayout.AddView(this.GetLinearSegment());
            linearLayout.AddView(this.GetLinearSegmentedCornerRadius());

            ScrollView scrollView = new ScrollView(this.context);
            scrollView.AddView(linearLayout);
            return scrollView;
        }

        private View GetTextView(string content)
        {
            TextView textView = new TextView(this.context) { Text = content };
            textView.TextSize = 15;
            return textView;
        }

        private View GetLinearDeterminate()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Determinate"));

            linearLayout.AddView(new SfLinearProgressBar(this.context)
            {
                Progress = 75,
                LayoutParameters = this.layoutParams
            });

            return linearLayout;
        }

        private View GetLinearSegment()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Segment"));

            linearLayout.AddView(new SfLinearProgressBar(this.context)
            {
                Progress = 75,
                SegmentCount = 4,
                LayoutParameters = this.layoutParams
            });

            return linearLayout;
        }

        private View GetLinearRangeColors()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Range colors"));

            RangeColorCollection rangeColorCollection = new RangeColorCollection
            {
                new RangeColor { Color = Color.ParseColor("#36BBE1"), Start = 0, End = 25 },
                new RangeColor { Color = Color.ParseColor("#9AEDE1"), Start = 25, End = 50 },
                new RangeColor { Color = Color.ParseColor("#FFDC28"), Start = 50, End = 75 },
                new RangeColor { Color = Color.ParseColor("#E15E0D"), Start = 75, End = 100 }
            };

            SfLinearProgressBar progressBar = new SfLinearProgressBar(this.context)
            {
                AnimationDuration = 10000,
                Progress = 100,
                LayoutParameters = this.layoutParams,
                RangeColors = rangeColorCollection
            };

            linearLayout.AddView(progressBar);
            progressBar.ValueChanged += this.ProgressBar_ValueChanged;
            return linearLayout;
        }

        private View GetLinearRangeColorsWithGradient()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Gradient"));

            RangeColorCollection rangeColorCollection = new RangeColorCollection
            {
                new RangeColor { IsGradient = true, Color = Color.ParseColor("#E9ECF7"), Start = 0, End = 20 },
                new RangeColor { IsGradient = true, Color = Color.ParseColor("#A0D9EF"), Start = 20, End = 40 },
                new RangeColor { IsGradient = true, Color = Color.ParseColor("#62C1E5"), Start = 40, End = 60 },
                new RangeColor { IsGradient = true, Color = Color.ParseColor("#20A7DB"), Start = 60, End = 80 },
                new RangeColor { IsGradient = true, Color = Color.ParseColor("#1C96C5"), Start = 80, End = 100 }
            };

            SfLinearProgressBar progressBar = new SfLinearProgressBar(this.context)
            {
                AnimationDuration = 10000,
                Progress = 100,
                LayoutParameters = this.layoutParams,
                RangeColors = rangeColorCollection
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetLinearCornerRadius()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Corner radius"));

            SfLinearProgressBar progressBar = new SfLinearProgressBar(this.context)
            {
                AnimationDuration = 10000,
                Progress = 100,
                CornerRadius = 10,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetLinearBuffer()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Buffer"));

            SfLinearProgressBar progressBar = new SfLinearProgressBar(this.context)
            {
                AnimationDuration = 20000,
                SecondaryAnimationDuration = 10000,
                Progress = 100,
                SecondaryProgress = 100,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged1;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetLinearPadding()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Padding"));

            SfLinearProgressBar progressBar = new SfLinearProgressBar(this.context)
            {
                AnimationDuration = 10000,
                Progress = 100,
                CornerRadius = 10,
                IndicatorPadding = new Thickness(2),
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetLinearSegmentedCornerRadius()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Segment with corner radius"));

            SfLinearProgressBar progressBar = new SfLinearProgressBar(this.context)
            {
                AnimationDuration = 10000,
                SegmentCount = 4,
                Progress = 100,
                CornerRadius = 10,
                GapWidth = 7,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetLinearIndeterminate()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(this.GetTextView("Indeterminate"));

            linearLayout.AddView(new SfLinearProgressBar(this.context)
            {
                IsIndeterminate = true,
                LayoutParameters = this.layoutParams
            });
            
            return linearLayout;
        }

        private async void ProgressBar_ValueChanged1(object sender, ProgressValueEventArgs e)
        {
            SfLinearProgressBar progressbar = sender as SfLinearProgressBar;
            if (e.Progress.Equals(100))
            {
                progressbar.AnimationDuration = 0;
                progressbar.Progress = 0;
                progressbar.SecondaryAnimationDuration = 0;
                progressbar.SecondaryProgress = 0;
            }

            if (e.Progress.Equals(0))
            {
                progressbar.AnimationDuration = 20000;
                await Task.Delay(100);
                progressbar.Progress = 100;
                progressbar.SecondaryAnimationDuration = 10000;
                await Task.Delay(100);
                progressbar.SecondaryProgress = 100;
            }
        }

        private async void ProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            SfLinearProgressBar progressbar = sender as SfLinearProgressBar;
            if (e.Progress.Equals(100))
            {
                progressbar.AnimationDuration = 0;
                progressbar.Progress = 0;
            }

            if (e.Progress.Equals(0))
            {
                progressbar.AnimationDuration = 10000;
                await Task.Delay(100);
                progressbar.Progress = 100;
            }
        }
    }
}