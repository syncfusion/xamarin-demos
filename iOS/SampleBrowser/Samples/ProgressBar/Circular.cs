#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoreGraphics;
using Syncfusion.iOS.ProgressBar;
using UIKit;

namespace SampleBrowser
{
    public class Circular : SampleView
    {
        UIScrollView scrollView;
        SfCircularProgressBar CircularDeterminate;
        SfCircularProgressBar CircularInDeterminate;
        SfCircularProgressBar CircularCustomContent;
        SfCircularProgressBar CircularVideoPlayer;
        SfCircularProgressBar CircularTrackOutside;
        SfCircularProgressBar CircularFilledIndicator;
        SfCircularProgressBar CircularTrackInside;
        SfCircularProgressBar CircularThinTrackStyle;
        SfCircularProgressBar CircularSegment;
        SfCircularProgressBar CircularSegmentPadding;
        SfCircularProgressBar CircularSegmentFillStyle;
        SfCircularProgressBar CircularAngleCustomization;
        SfCircularProgressBar CircularRangeColors;

        UILabel CircularDeterminateLabel;
        UILabel CircularCustomContentLabel;
        UILabel CircularRadiusCustomizationLabel;
        UILabel CircularSegmentLabel;
        UILabel CircularAngleCustomizationLabel;
        UILabel CircularRangeColorsLabel;
        UIView CustContentLayout;
        UIButton pauseButton, playButton;
        bool isDispose = false;

        private UILabel GetLabel(string text)
        {
            return new UILabel()
            {
                Text = text,
                Font = UIFont.FromName("HelveticaNeue", 11f),
                TextAlignment = UITextAlignment.Left
            };
        }

        private UILabel GetLabel(double content)
        {
            string custContent = content + "%";
            return new UILabel()
            {
                Frame = new CGRect(0, 0, 40, 20),
                Text = custContent,
                Font = UIFont.FromName("HelveticaNeue", 11f),
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.FromRGB(0, 124, 238)
            };
        }

        public Circular()
        {
            scrollView = new UIScrollView();
            this.AddSubview(scrollView);

            CircularDeterminateLabel = this.GetLabel("Detminate and indeterminate");
            CircularDeterminate = new SfCircularProgressBar
            {
                Progress = 75
            };

            CircularInDeterminate = new SfCircularProgressBar
            {
                IsIndeterminate = true
            };

            scrollView.AddSubview(CircularDeterminateLabel);
            scrollView.AddSubview(CircularDeterminate);
            scrollView.AddSubview(CircularInDeterminate);

            CircularCustomContentLabel = this.GetLabel("Custom content");
            CircularCustomContent = new SfCircularProgressBar()
            {
                Progress = 75,
                AnimationDuration = 1,
            };
            this.SetCustomContentProgress();

            this.CircularVideoPlayer = new SfCircularProgressBar()
            {
                Progress = 100,
                TrackInnerRadius = 0f,
                IndicatorOuterRadius = 0.7f,
                IndicatorInnerRadius = 0.65f,
                AnimationDuration = 2000,
            };
            this.CircularVideoPlayer.ValueChanged += this.ProgressBar_ValueChanged100;


            scrollView.AddSubview(this.CircularCustomContentLabel);
            scrollView.AddSubview(this.CircularCustomContent);
            scrollView.AddSubview(this.CircularVideoPlayer);

            UIView customView = new UIView();
            customView.Frame = new CGRect(0, 40, 100, 80);
            playButton = new UIButton();
            playButton.Hidden = true;
            playButton.SetImage(UIImage.FromFile("SfProgressPlay.png"), UIControlState.Normal);
            playButton.BackgroundColor = UIColor.Clear;
            pauseButton = new UIButton();
            pauseButton.BackgroundColor = UIColor.Clear;
            pauseButton.SetImage(UIImage.FromFile("SfProgressPause.png"), UIControlState.Normal);
            string deviceType = UIDevice.CurrentDevice.Model;
            if (deviceType == "iPhone" || deviceType == "iPod touch")
            {
                playButton.Frame = new CGRect(18, 25, 65, 30);
                pauseButton.Frame = new CGRect(18, 25, 65, 30);
            }
            else
            {
                playButton.Frame = new CGRect(0, 23, 100, 33);
                pauseButton.Frame = new CGRect(0, 23, 100, 33);
            }
            customView.AddSubview(playButton);
            customView.AddSubview(pauseButton);
            playButton.TouchUpInside += (sender, e) =>
            {
                this.CircularVideoPlayer.Progress = 100;
                this.pauseButton.Hidden = false;
                this.playButton.Hidden = true;
            };
            pauseButton.TouchUpInside += (sender, e) =>
            {
                this.CircularVideoPlayer.Progress =
                        (double)GetInternalPropertyValue(typeof(ProgressBarBase), this.CircularVideoPlayer, "ActualProgress");
                this.playButton.Hidden = false;
                this.pauseButton.Hidden = true;

            };
            this.CircularVideoPlayer.Content = customView;

            this.CircularRadiusCustomizationLabel = this.GetLabel("Radius customization");
            this.CircularTrackOutside = new SfCircularProgressBar()
            {
                Progress = 100,
                IndicatorOuterRadius = 0.7f,
                IndicatorInnerRadius = 0.65f,
                ShowProgressValue = false,
                AnimationDuration = 2000,
            };
            this.CircularTrackOutside.ValueChanged += this.ProgressBar_ValueChanged100;

            this.CircularFilledIndicator = new SfCircularProgressBar()
            {
                Progress = 100,
                IndicatorOuterRadius = 0.7f,
                IndicatorInnerRadius = 0f,
                ShowProgressValue = false,
                AnimationDuration = 2000,
            };
            this.CircularFilledIndicator.ValueChanged += this.ProgressBar_ValueChanged100;

            CircularTrackInside = new SfCircularProgressBar()
            {
                TrackOuterRadius = 0.7f,
                TrackInnerRadius = 0f,
                ShowProgressValue = true,
                AnimationDuration = 1,
            };

            this.SetTrackInsideStyleProgress();

            this.CircularThinTrackStyle = new SfCircularProgressBar()
            {
                Progress = 100,
                IndicatorOuterRadius = 0.75f,
                IndicatorInnerRadius = 0.6f,
                TrackOuterRadius = 0.7f,
                TrackInnerRadius = 0.65f,
                AnimationDuration = 2000,
                ShowProgressValue = false,
            };
            this.CircularThinTrackStyle.ValueChanged += this.ProgressBar_ValueChanged100;

            scrollView.AddSubview(CircularRadiusCustomizationLabel);
            scrollView.AddSubview(CircularTrackOutside);
            scrollView.AddSubview(CircularFilledIndicator);
            scrollView.AddSubview(CircularTrackInside);
            scrollView.AddSubview(CircularThinTrackStyle);

            this.CircularSegmentLabel = this.GetLabel("Segment");
            this.CircularSegment = new SfCircularProgressBar()
            {
                Progress = 75,
                ShowProgressValue = false,
                SegmentCount = 4,
                AnimationDuration = 2000,
            };
            this.CircularSegment.ValueChanged += this.ProgressBar_ValueChanged75;

            this.CircularSegmentPadding = new SfCircularProgressBar()
            {
                Progress = 75,
                ShowProgressValue = false,
                TrackInnerRadius = 0.6f,
                IndicatorInnerRadius = 0.65f,
                IndicatorOuterRadius = 0.7f,
                AnimationDuration = 2000,
                SegmentCount = 4
            };
            this.CircularSegmentPadding.ValueChanged += this.ProgressBar_ValueChanged75;

            CircularSegmentFillStyle = new SfCircularProgressBar()
            {
                ShowProgressValue = false,
                SegmentCount = 20,
                AnimationDuration = 1,
            };
            this.SetSegmentedFillingStyleProgress();

            scrollView.AddSubview(CircularSegmentLabel);
            scrollView.AddSubview(CircularSegment);
            scrollView.AddSubview(CircularSegmentPadding);
            scrollView.AddSubview(CircularSegmentFillStyle);

            this.CircularAngleCustomizationLabel = this.GetLabel("Angle customization");
            this.CircularAngleCustomization = new SfCircularProgressBar()
            {
                Progress = 100,
                StartAngle = 130,
                EndAngle = 410,
                AnimationDuration = 2000,
                ShowProgressValue = false
            };
            this.CircularAngleCustomization.ValueChanged += this.ProgressBar_ValueChanged100;

            scrollView.AddSubview(CircularAngleCustomizationLabel);
            scrollView.AddSubview(CircularAngleCustomization);

            this.CircularRangeColorsLabel = this.GetLabel("Range colors");
            var rangeColorCollection = new RangeColorCollection
            {
                new RangeColor{ Color = UIColor.FromRGB(54,187,225), Start = 0, End = 25 },
                new RangeColor{ Color = UIColor.FromRGB(154,237,225), Start = 25, End = 50 },
                new RangeColor{ Color = UIColor.FromRGB(225,220,40), Start = 50, End = 75 },
                new RangeColor{ Color = UIColor.FromRGB(225,94,13), Start = 75, End = 100 }
            };
            this.CircularRangeColors = new SfCircularProgressBar()
            {
                Progress = 100,
                AnimationDuration = 2000,
                ShowProgressValue = false,
                RangeColors = rangeColorCollection
            };
            this.CircularRangeColors.ValueChanged += ProgressBar_ValueChanged100;

            scrollView.AddSubview(CircularRangeColorsLabel);
            scrollView.AddSubview(CircularRangeColors);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            nfloat X = 20;
            nfloat Y = 40;
            nfloat margin = 10;
            nfloat height = this.scrollView.Frame.Size.Height / 6;
            nfloat width = this.scrollView.Frame.Size.Width - 40;
            nfloat columnWidth = (this.scrollView.Frame.Size.Width - 40) / 3;

            scrollView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);

            CircularDeterminateLabel.Frame = new CGRect(X, Y, width, 15);
            Y = Y + CircularDeterminateLabel.Frame.Size.Height + margin;

            CircularDeterminate.Frame = new CGRect(X, Y, columnWidth, height);
            CircularInDeterminate.Frame = new CGRect(X + columnWidth + margin, Y, columnWidth, height);
            Y = Y + CircularDeterminate.Frame.Size.Height + margin;

            CircularCustomContentLabel.Frame = new CGRect(X, Y, width, 15);
            Y = Y + CircularCustomContentLabel.Frame.Size.Height + margin;

            CircularCustomContent.Frame = new CGRect(X, Y, columnWidth, height);
            CircularVideoPlayer.Frame = new CGRect(X + columnWidth + margin, Y, columnWidth, height);
            Y = Y + CircularCustomContent.Frame.Size.Height + margin;

            CircularRadiusCustomizationLabel.Frame = new CGRect(X, Y, width, 15);
            Y = Y + CircularRadiusCustomizationLabel.Frame.Size.Height + margin;

            CircularTrackOutside.Frame = new CGRect(X, Y, columnWidth, height);
            CircularFilledIndicator.Frame = new CGRect(X + columnWidth + margin, Y, columnWidth, height);
            CircularTrackInside.Frame = new CGRect(X + columnWidth * 2 + margin, Y, columnWidth, height);
            Y = Y + CircularTrackOutside.Frame.Size.Height + margin;

            CircularThinTrackStyle.Frame = new CGRect(X, Y, columnWidth, height);
            Y = Y + CircularThinTrackStyle.Frame.Size.Height + margin;

            CircularSegmentLabel.Frame = new CGRect(X, Y, width, 15);
            Y = Y + CircularSegmentLabel.Frame.Size.Height + margin;

            CircularSegment.Frame = new CGRect(X, Y, columnWidth, height);
            CircularSegmentPadding.Frame = new CGRect(X + columnWidth + margin, Y, columnWidth, height);
            CircularSegmentFillStyle.Frame = new CGRect(X + columnWidth * 2 + margin, Y, columnWidth, height);
            Y = Y + CircularSegment.Frame.Size.Height + margin;

            CircularAngleCustomizationLabel.Frame = new CGRect(X, Y, width, 15);
            Y = Y + CircularAngleCustomizationLabel.Frame.Size.Height + margin;
            CircularAngleCustomization.Frame = new CGRect(X, Y, columnWidth, height);
            Y = Y + CircularAngleCustomization.Frame.Size.Height + margin;

            CircularRangeColorsLabel.Frame = new CGRect(X, Y, width, 15);
            Y = Y + CircularRangeColorsLabel.Frame.Size.Height + margin;
            CircularRangeColors.Frame = new CGRect(X, Y, columnWidth, height);

            scrollView.ContentSize = new CGSize(this.Frame.Size.Width, Y + CircularRangeColors.Frame.Size.Height);
        }


        private void ProgressBar_ValueChanged100(object sender, ProgressValueEventArgs e)
        {
            SfCircularProgressBar progressbar = sender as SfCircularProgressBar;
            if (e.Progress.Equals(100))
            {
                progressbar.AnimationDuration = 1;
                progressbar.Progress = 0;
            }

            if (e.Progress.Equals(0))
            {
                progressbar.AnimationDuration = 2000;
                progressbar.Progress = 100;
            }
        }

        private void ProgressBar_ValueChanged75(object sender, ProgressValueEventArgs e)
        {
            SfCircularProgressBar progressbar = sender as SfCircularProgressBar;
            if (e.Progress.Equals(75))
            {
                progressbar.AnimationDuration = 1;
                progressbar.Progress = 0;
            }

            if (e.Progress.Equals(0))
            {
                progressbar.AnimationDuration = 2000;
                progressbar.Progress = 75;
            }
        }

        private async void SetCustomContentProgress()
        {
            if (!isDispose)
            {
                double progress = 0;
                while (progress < 75)
                {
                    if (isDispose)
                        break;
                    this.CircularCustomContent.Progress = progress += 1;
                    this.CustContentLayout = new UIView();
                    this.CustContentLayout.Frame = new CGRect(0, 0, 100, 80);
                    string custContent = progress + "%";

                    UILabel progressLabel = new UILabel()
                    {
                        Frame = new CGRect(this.CustContentLayout.Center.X - 20, 25, 40, 20),
                        Text = custContent,
                        Font = UIFont.FromName("HelveticaNeue", 11f),
                        TextAlignment = UITextAlignment.Center,
                        TextColor = UIColor.FromRGB(0, 124, 238)
                    };

                    this.CustContentLayout.AddSubview(progressLabel);

                    UILabel textView = new UILabel()
                    {
                        Frame = new CGRect(this.CustContentLayout.Center.X - 20, this.CustContentLayout.Center.Y, 40, 20),
                        Text = "used",
                        TextAlignment = UITextAlignment.Center,
                        Font = UIFont.FromName("HelveticaNeue", 10f),
                        TextColor = UIColor.FromRGB(0, 124, 238),
                    };

                    this.CustContentLayout.Center = this.CircularCustomContent.Center;
                    this.CustContentLayout.AddSubview(textView);
                    this.CircularCustomContent.Content = this.CustContentLayout;
                    await Task.Delay(50);
                }
            }
        }

        private async void SetSegmentedFillingStyleProgress()
        {
            if (!isDispose)
            {
                double progress = 0;
                this.CircularSegmentFillStyle.Progress = 0;
                await Task.Delay(1000);
                while (progress < 100)
                {
                    if (isDispose)
                        break;
                    this.CircularSegmentFillStyle.Progress = progress += 5;
                    await Task.Delay(1000);
                }

                this.SetSegmentedFillingStyleProgress();
            }
        }

        private async void SetTrackInsideStyleProgress()
        {
            if (!isDispose)
            {
                double progress = 0;
                while (progress < 100)
                {
                    this.CircularTrackInside.Progress = progress += 1;
                    this.CircularTrackInside.Content = this.GetLabel((int)progress);
                    if (this.Handle != System.IntPtr.Zero)
                        CircularTrackInside.AddSubview(this.CircularTrackInside.Content);
                    await Task.Delay(500);
                }


                this.CircularTrackInside.Progress = 0;
                this.SetTrackInsideStyleProgress();
            }
        }

        protected override void Dispose(bool disposing)
        {
            isDispose = disposing;
            base.Dispose(disposing);
        }

        public static object GetInternalPropertyValue(Type type, object obj, string name)
        {
            var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            return
                properties.Where(propertyInfo => propertyInfo.Name.Equals(name))
                    .Select(propertyInfo => propertyInfo.GetValue(obj))
                    .FirstOrDefault();
        }
    }
}