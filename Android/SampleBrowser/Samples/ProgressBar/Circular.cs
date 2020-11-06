#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SampleBrowser
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Android.Content;
    using Android.Graphics;
    using Android.Views;
    using Android.Widget;
    using Syncfusion.Android.ProgressBar;

    public class Circular : SamplePage
    {
        private Context context;
        private LinearLayout.LayoutParams layoutParams;
        private SfCircularProgressBar segmentedFillingStyle;
        private SfCircularProgressBar circularCustomContentProgressBar;
        private SfCircularProgressBar trackInsideStyle;
        private SfCircularProgressBar videoPlayerProgressBar;
        private ImageButton playButton, pauseButton;

        public override View GetSampleContent(Context ctx)
        {
            this.context = ctx;
            this.layoutParams = new LinearLayout.LayoutParams(
                this.context.Resources.DisplayMetrics.WidthPixels / 3,
                this.context.Resources.DisplayMetrics.HeightPixels / 5);

            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };

            LinearLayout row1 = new LinearLayout(this.context);
            LinearLayout row2 = new LinearLayout(this.context);
            LinearLayout row3 = new LinearLayout(this.context);
            LinearLayout row4 = new LinearLayout(this.context);
            LinearLayout row5 = new LinearLayout(this.context);
            LinearLayout row6 = new LinearLayout(this.context);
            LinearLayout row7 = new LinearLayout(this.context);

            linearLayout.AddView(this.GetTextView("Determinate and indeterminate"));
            linearLayout.AddView(row1);
            linearLayout.AddView(this.GetTextView("Custom content"));
            linearLayout.AddView(row2);
            linearLayout.AddView(this.GetTextView("Radius customization"));
            linearLayout.AddView(row3);
            linearLayout.AddView(row4);
            linearLayout.AddView(this.GetTextView("Segment"));
            linearLayout.AddView(row5);
            linearLayout.AddView(this.GetTextView("Custom angle"));
            linearLayout.AddView(row6);
            linearLayout.AddView(this.GetTextView("Range colors"));
            linearLayout.AddView(row7);

            row1.AddView(this.GetCircularDeterminate());
            row1.AddView(this.GetCircularIndeterminate());

            row2.AddView(this.GetCircularCustomContent());
            row2.AddView(this.GetCircularVideoPlayer());

            row3.AddView(this.GetCircularTrackOutside());
            row3.AddView(this.GetCircularFilledIndicator());
            row3.AddView(this.GetCircularTrackInside());
            row4.AddView(this.GetCircularThinTrackStyle());

            row5.AddView(this.GetCircularSegment());
            row5.AddView(this.GetCircularSegmentPadding());
            row5.AddView(this.GetCircularSegmentFillStyle());

            row6.AddView(this.GetCircularAngleCustomization());

            row7.AddView(this.GetCircularRangeColors());

            ScrollView scrollView = new ScrollView(this.context);
            scrollView.AddView(linearLayout);
            return scrollView;
        }

        private View GetTextView(string content)
        {
            TextView textView = new TextView(this.context) { Text = content };
            textView.SetPadding(15, 30, 0, 0);
            textView.TextSize = 15;
            return textView;
        }

        private View GetCustomContentTextView(double content)
        {
            string custContent = content + "%";
            TextView textView = new TextView(this.context)
            {
                Text = custContent,
                TextSize = 20,
                TextAlignment = TextAlignment.Center,
                Gravity = GravityFlags.Center,
            };

            textView.SetTextColor(Color.ParseColor("#007cee"));
            return textView;
        }

        private View GetCircularDeterminate()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };

            linearLayout.AddView(new SfCircularProgressBar(this.context)
            {
                Progress = 75,
                ShowProgressValue = false,
                LayoutParameters = this.layoutParams
            });

            return linearLayout;
        }

        private View GetCircularIndeterminate()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            linearLayout.AddView(new SfCircularProgressBar(this.context)
            {
                IsIndeterminate = true,
                LayoutParameters = this.layoutParams
            });

            return linearLayout;
        }

        private View GetCircularCustomContent()
        {
#pragma warning disable CS4014
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            this.circularCustomContentProgressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 75,
                AnimationDuration = 0,
                LayoutParameters = this.layoutParams
            };

            this.SetCustomContentProgress();
            linearLayout.AddView(this.circularCustomContentProgressBar);
            return linearLayout;
#pragma warning restore CS4014
        }

        private View GetCircularVideoPlayer()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            this.videoPlayerProgressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 100,
                ShowProgressValue = true,
                TrackInnerRadius = 0f,
                IndicatorOuterRadius = 0.7f,
                IndicatorInnerRadius = 0.65f,
                AnimationDuration = 10000,
                LayoutParameters = this.layoutParams
            };

            GridLayout.LayoutParams gridLayoutParams = new GridLayout.LayoutParams
            {
                RowSpec = GridLayout.InvokeSpec(0),
                ColumnSpec = GridLayout.InvokeSpec(0)
            };

            GridLayout custContentLayout = new GridLayout(this.context);
            this.playButton = new ImageButton(this.context) { Visibility = ViewStates.Invisible };
            this.playButton.SetImageResource(Resource.Drawable.SfProgressPlay);
            this.playButton.SetBackgroundColor(Color.ParseColor("#00FFFFFF"));
            this.playButton.Click += this.PlayButton_Click;
            custContentLayout.AddView(this.playButton, gridLayoutParams);

            this.pauseButton = new ImageButton(this.context);
            this.pauseButton.SetImageResource(Resource.Drawable.SfProgressPause);
            this.pauseButton.SetBackgroundColor(Color.ParseColor("#00FFFFFF"));
            this.pauseButton.Click += this.PauseButton_Click;
            custContentLayout.AddView(this.pauseButton, gridLayoutParams);

            this.videoPlayerProgressBar.Content = custContentLayout;
            this.videoPlayerProgressBar.ValueChanged += this.ProgressBar_ValueChanged100;
            linearLayout.AddView(this.videoPlayerProgressBar);
            
            return linearLayout;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            this.videoPlayerProgressBar.Progress =
                (double)GetInternalPropertyValue(typeof(ProgressBarBase), this.videoPlayerProgressBar, "ActualProgress");
            this.playButton.Visibility = ViewStates.Visible;
            this.pauseButton.Visibility = ViewStates.Invisible;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            this.videoPlayerProgressBar.Progress = 100;
            this.pauseButton.Visibility = ViewStates.Visible;
            this.playButton.Visibility = ViewStates.Invisible;
        }

        public static object GetInternalPropertyValue(Type type, object obj, string name)
        {
            var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            return
                properties.Where(propertyInfo => propertyInfo.Name.Equals(name))
                    .Select(propertyInfo => propertyInfo.GetValue(obj))
                    .FirstOrDefault();
        }

        private View GetCircularTrackOutside()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            SfCircularProgressBar progressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 100,
                IndicatorOuterRadius = 0.7f,
                IndicatorInnerRadius = 0.65f,
                ShowProgressValue = false,
                AnimationDuration = 10000,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged100;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetCircularFilledIndicator()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            SfCircularProgressBar progressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 100,
                IndicatorOuterRadius = 0.7f,
                IndicatorInnerRadius = 0f,
                ShowProgressValue = false,
                AnimationDuration = 10000,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged100;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetCircularTrackInside()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            this.trackInsideStyle = new SfCircularProgressBar(this.context)
            {
                TrackOuterRadius = 0.7f,
                TrackInnerRadius = 0f,
                ShowProgressValue = true,
                AnimationDuration = 0,
                LayoutParameters = this.layoutParams
            };

            this.SetTrackInsideStyleProgress();
            linearLayout.AddView(this.trackInsideStyle);
            return linearLayout;
        }

        private async void SetTrackInsideStyleProgress()
        {
            double progress = 0;
            while (progress < 100)
            {
                this.trackInsideStyle.Progress = progress += 0.25;
                LinearLayout custContentLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
                custContentLayout.AddView(this.GetCustomContentTextView((int)progress));
                this.trackInsideStyle.Content = custContentLayout;
                await Task.Delay(50);
            }
            
            this.trackInsideStyle.Progress = 0;
            this.SetTrackInsideStyleProgress();
        }

        private View GetCircularThinTrackStyle()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            SfCircularProgressBar progressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 100,
                IndicatorOuterRadius = 0.75f,
                IndicatorInnerRadius = 0.6f,
                TrackOuterRadius = 0.7f,
                TrackInnerRadius = 0.65f,
                ShowProgressValue = false,
                AnimationDuration = 10000,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged100;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetCircularSegment()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            SfCircularProgressBar progressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 75,
                ShowProgressValue = false,
                SegmentCount = 4,
                AnimationDuration = 10000,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged75;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetCircularSegmentPadding()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            SfCircularProgressBar progressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 75,
                ShowProgressValue = false,
                TrackInnerRadius = 0.6f,
                IndicatorInnerRadius = 0.65f,
                IndicatorOuterRadius = 0.7f,
                SegmentCount = 4,
                AnimationDuration = 10000,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged75;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetCircularSegmentFillStyle()
        {
#pragma warning disable CS4014
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            this.segmentedFillingStyle = new SfCircularProgressBar(this.context)
            {
                ShowProgressValue = false,
                SegmentCount = 20,
                AnimationDuration = 0,
                LayoutParameters = this.layoutParams
            };

            this.SetSegmentedFillingStyleProgress();
            linearLayout.AddView(this.segmentedFillingStyle);
            return linearLayout;
#pragma warning restore CS4014
        }

        private View GetCircularAngleCustomization()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            SfCircularProgressBar progressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 100,
                StartAngle = 130,
                EndAngle = 410,
                ShowProgressValue = false,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged100;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private View GetCircularRangeColors()
        {
            LinearLayout linearLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
            RangeColorCollection rangeColorCollection = new RangeColorCollection
            {
                new RangeColor { Color = Color.ParseColor("#36BBE1"), Start = 0, End = 25 },
                new RangeColor { Color = Color.ParseColor("#9AEDE1"), Start = 25, End = 50 },
                new RangeColor { Color = Color.ParseColor("#FFDC28"), Start = 50, End = 75 },
                new RangeColor { Color = Color.ParseColor("#E15E0D"), Start = 75, End = 100 }
            };
            SfCircularProgressBar progressBar = new SfCircularProgressBar(this.context)
            {
                Progress = 100,
                ShowProgressValue = false,
                RangeColors = rangeColorCollection,
                LayoutParameters = this.layoutParams
            };

            progressBar.ValueChanged += this.ProgressBar_ValueChanged100;
            linearLayout.AddView(progressBar);
            return linearLayout;
        }

        private async void ProgressBar_ValueChanged100(object sender, ProgressValueEventArgs e)
        {
            SfCircularProgressBar progressbar = sender as SfCircularProgressBar;
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

        private async void ProgressBar_ValueChanged75(object sender, ProgressValueEventArgs e)
        {
            SfCircularProgressBar progressbar = sender as SfCircularProgressBar;
            if (e.Progress.Equals(75))
            {
                progressbar.AnimationDuration = 0;
                await Task.Delay(50);
                progressbar.Progress = 0;
            }

            if (e.Progress.Equals(0))
            {
                progressbar.AnimationDuration = 10000;
                await Task.Delay(100);
                progressbar.Progress = 75;
            }
        }
        
        private async Task SetSegmentedFillingStyleProgress()
        {
            double progress = 0;
            this.segmentedFillingStyle.Progress = 0;
            await Task.Delay(300);
            while (progress < 100)
            {
                this.segmentedFillingStyle.Progress = progress += 5;
                await Task.Delay(300);
            }

            await this.SetSegmentedFillingStyleProgress();
        }

        private async Task SetCustomContentProgress()
        {
            double progress = 0;
            while (progress < 75)
            {
                this.circularCustomContentProgressBar.Progress = progress += 1;
                LinearLayout custContentLayout = new LinearLayout(this.context) { Orientation = Orientation.Vertical };
                custContentLayout.AddView(this.GetCustomContentTextView(progress));
                TextView textView = new TextView(this.context)
                {
                    Text = "used",
                    TextAlignment = TextAlignment.Center,
                    Gravity = GravityFlags.Center,
                    TextSize = 10
                };

                textView.SetTextColor(Color.ParseColor("#007cee"));
                custContentLayout.AddView(textView);
                this.circularCustomContentProgressBar.Content = custContentLayout;
                await Task.Delay(50);
            }
        }
    }
}