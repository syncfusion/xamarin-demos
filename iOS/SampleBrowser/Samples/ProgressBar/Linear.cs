#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using CoreGraphics;
using Syncfusion.iOS.ProgressBar;
using UIKit;

namespace SampleBrowser
{
    public class Linear : SampleView
    {
		SfLinearProgressBar linearDeterminate;
		SfLinearProgressBar linearSegment;
		SfLinearProgressBar linearRangeColors;
        SfLinearProgressBar linearRangeColorsWithGradient;
		SfLinearProgressBar linearCornerRadius;
		SfLinearProgressBar linearBuffer;
		SfLinearProgressBar linearPadding;
		SfLinearProgressBar linearSegmentedCornerRadius;
		SfLinearProgressBar linearIndeterminate;

		UILabel linearDeterminateLable;
		UILabel linearSegmentLable;
		UILabel linearRangeColorsLabel;
        UILabel linearRangeColorsWithGradientLabel;
		UILabel linearCornerRadiusLabel;
		UILabel linearBufferLabel;
		UILabel linearPaddingLabel;
		UILabel linearSegmentedCornerRadiusLabel;
		UILabel linearIndeterminateLabel;
        bool isDispose = false;

        private UILabel GetLabel(string text)
        {
            return new UILabel()
            {
                Text = text,
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.FromName("HelveticaNeue", 13f)
            };
        }

        public Linear()
        {
            this.linearDeterminateLable = this.GetLabel("Determinate");
			this.linearIndeterminateLabel = this.GetLabel("Indeterminate");
			this.linearCornerRadiusLabel = this.GetLabel("Corner radius");
			this.linearRangeColorsLabel = this.GetLabel("Range color");
            this.linearRangeColorsWithGradientLabel = this.GetLabel("Gradient");
			this.linearPaddingLabel = this.GetLabel("Padding");
			this.linearBufferLabel = this.GetLabel("Buffer");
			this.linearSegmentLable =  this.GetLabel("Segment");
            this.linearSegmentedCornerRadiusLabel = this.GetLabel("Segment with corner radius");

			// Determinate progress bar.
			this.linearDeterminate = new SfLinearProgressBar
            {
                Progress = 75,
            };

			// Indeterminate progress bar.
			linearIndeterminate = new SfLinearProgressBar
			{
				IsIndeterminate = true
			};

			// Progres bar with corner radius.
			this.linearCornerRadius = new SfLinearProgressBar
			{
				Progress = 100,
                AnimationDuration=2000,
				CornerRadius = 10,
			};
            this.linearCornerRadius.ValueChanged += this.ProgressBar_ValueChanged;
              

			// Progress bar with padding.
			this.linearPadding = new SfLinearProgressBar
			{
				Progress = 100,
                AnimationDuration=2000,
				IndicatorPadding = new UIEdgeInsets(1, 1, 1, 1),
				CornerRadius = 10,
			};
            this.linearPadding.ValueChanged += this.ProgressBar_ValueChanged;

			var rangeColorCollection = new RangeColorCollection
			{
				new RangeColor{ Color = UIColor.FromRGB(54,187,225), Start = 0, End = 25 },
				new RangeColor{ Color = UIColor.FromRGB(154,237,225), Start = 25, End = 50 },
				new RangeColor{ Color = UIColor.FromRGB(225,220,40), Start = 50, End = 75 },
				new RangeColor{ Color = UIColor.FromRGB(225,94,13), Start = 75, End = 100 }
			};

			// Progress bar with range colors customization.
			this.linearRangeColors = new SfLinearProgressBar
			{
				Progress = 100,
                AnimationDuration=2000,
				RangeColors = rangeColorCollection,
			};
            this.linearRangeColors.ValueChanged += this.ProgressBar_ValueChanged;

            var gradianRangeColorCollection = new RangeColorCollection
            {
                new RangeColor{ IsGradient = true, Color = UIColor.FromRGB(233, 236, 247), Start = 0, End = 20 },
                new RangeColor{ IsGradient = true, Color = UIColor.FromRGB(160, 217, 239), Start = 20, End = 40 },
                new RangeColor{ IsGradient = true, Color = UIColor.FromRGB(98, 193, 229), Start = 40, End = 60 },
                new RangeColor{ IsGradient = true, Color = UIColor.FromRGB(32, 167, 219), Start = 60, End = 80 },
                new RangeColor{ IsGradient = true, Color = UIColor.FromRGB(8, 150, 197), Start = 80, End = 100 }
            };

            // Progress bar with gradient range colors.
            this.linearRangeColorsWithGradient = new SfLinearProgressBar
            {
                Progress = 100,
                AnimationDuration=2000,
                RangeColors = gradianRangeColorCollection,
            };
            this.linearRangeColorsWithGradient.ValueChanged += this.ProgressBar_ValueChanged;

			// Progress bar with secondary progress.
			this.linearBuffer = new SfLinearProgressBar
			{
				AnimationDuration = 2000,
                SecondaryAnimationDuration = 1000,
                Progress = 100,
                SecondaryProgress = 100,

			};

			// Progress bar with segments.
			this.linearSegment = new SfLinearProgressBar
            {
                Progress = 75,
                SegmentCount = 4
            };

            // Segmented progress bar with corner radius.
            this.linearSegmentedCornerRadius = new SfLinearProgressBar
            {
                Progress = 100,
                CornerRadius = 10,
                SegmentCount = 4,
                GapWidth = 7,
                AnimationDuration=2000,
            };
            this.linearSegmentedCornerRadius.ValueChanged += this.ProgressBar_ValueChanged;

			AddSubview(this.linearDeterminate);
			AddSubview(this.linearIndeterminate);
			AddSubview(this.linearCornerRadius);
			AddSubview(this.linearRangeColors);
            AddSubview(this.linearRangeColorsWithGradient);
			AddSubview(this.linearPadding);
			AddSubview(this.linearBuffer);
			AddSubview(this.linearSegment);
			AddSubview(this.linearSegmentedCornerRadius);

			AddSubview(this.linearDeterminateLable);
			AddSubview(this.linearIndeterminateLabel);
			AddSubview(this.linearCornerRadiusLabel);
			AddSubview(this.linearRangeColorsLabel);
            AddSubview(this.linearRangeColorsWithGradientLabel);
			AddSubview(this.linearPaddingLabel);
			AddSubview(this.linearBufferLabel);
			AddSubview(this.linearSegmentLable);
			AddSubview(this.linearSegmentedCornerRadiusLabel);
		}

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            this.linearPadding.Frame = new CGRect(20, 10, this.Frame.Size.Width - 40, this.Frame.Size.Height - 20);

			nfloat X = 20;
			nfloat Y = 40;
			nfloat height = this.Frame.Size.Height / 18;
			nfloat width = this.Frame.Size.Width - 40;

            this.linearDeterminateLable.Frame = new CGRect(X, Y, width, 15);
            this.linearDeterminate.Frame = new CGRect(X, Y + this.linearDeterminateLable.Frame.Size.Height + 10, width, height);
            Y = Y + this.linearDeterminate.Frame.Size.Height + 20;

            this.linearBufferLabel.Frame = new CGRect(X, Y, width, 15);
            this.linearBuffer.Frame = new CGRect(X, Y + this.linearBufferLabel.Frame.Size.Height + 10, width, height);
            Y = Y + this.linearBuffer.Frame.Size.Height + 20;

			this.linearIndeterminateLabel.Frame = new CGRect(X, Y, width, 15);
			this.linearIndeterminate.Frame = new CGRect(X, Y + this.linearIndeterminateLabel.Frame.Size.Height + 10, width, height);
			Y = Y + this.linearSegment.Frame.Size.Height + 20;

			this.linearCornerRadiusLabel.Frame = new CGRect(X, Y, width, 15);
			this.linearCornerRadius.Frame = new CGRect(X, Y + this.linearCornerRadiusLabel.Frame.Size.Height + 10, width, height);
			Y = Y + this.linearCornerRadius.Frame.Size.Height + 20;

            this.linearPaddingLabel.Frame = new CGRect(X, Y, width, 15);
            this.linearPadding.Frame = new CGRect(X, Y + this.linearPaddingLabel.Frame.Size.Height + 10, width, height);
            Y = Y + this.linearPadding.Frame.Size.Height + 20;

			this.linearRangeColorsLabel.Frame = new CGRect(X, Y, width, 15);
			this.linearRangeColors.Frame = new CGRect(X, Y + this.linearRangeColorsLabel.Frame.Size.Height + 10, width, height);
			Y = Y + this.linearRangeColors.Frame.Size.Height + 20;

            this.linearRangeColorsWithGradientLabel.Frame = new CGRect(X, Y, width, 15);
            this.linearRangeColorsWithGradient.Frame = new CGRect(X, Y + this.linearRangeColorsWithGradientLabel.Frame.Size.Height + 10, width, height);
            Y = Y + this.linearRangeColorsWithGradient.Frame.Size.Height + 20;

			this.linearSegmentLable.Frame = new CGRect(X, Y, width, 15);
            this.linearSegment.Frame = new CGRect(X, Y + this.linearSegmentLable.Frame.Size.Height + 10, width, height);
            Y = Y + this.linearSegment.Frame.Size.Height + 20;

			this.linearSegmentedCornerRadiusLabel.Frame = new CGRect(X, Y, width, 15);
            this.linearSegmentedCornerRadius.Frame = new CGRect(X, Y + this.linearSegmentedCornerRadiusLabel.Frame.Size.Height + 10, width, height);
			Y = Y + this.linearSegmentedCornerRadius.Frame.Size.Height + 20;
        }

        private void ProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            SfLinearProgressBar progressbar = sender as SfLinearProgressBar;
            if (e.Progress.Equals(100))
            {
                progressbar.Progress = 0;
                progressbar.AnimationDuration = 1;
            }

            if (e.Progress.Equals(0))
            {
                progressbar.AnimationDuration = 2000;
                progressbar.Progress = 100;
            }
        }

        protected override void Dispose(bool disposing)
        {
            isDispose = disposing;
            base.Dispose(disposing);
        }
    }
}