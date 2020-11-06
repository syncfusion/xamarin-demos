#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SampleBrowser.SfProgressBar
{
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.XForms.ProgressBar;
    using Xamarin.Forms;

    public partial class CircularRadiusCustomization : SampleView
    {
        private bool isDisposed;
        public CircularRadiusCustomization()
        {
            InitializeComponent();
            this.TrackOutsideProgressBar.AnimationDuration = 2000;
            this.FilledIndicatorProgressBar.AnimationDuration = 2000;
            this.ThinTrackStyle.AnimationDuration = 2000;
            this.TrackInsideProgressBar.AnimationDuration = 0;
#pragma warning disable CS4014
            this.SetTrackInsideProgress();
#pragma warning restore CS4014
        }

        public void Dispose(bool disposing)
        {
            TrackOutsideProgressBar?.Dispose(disposing);
            FilledIndicatorProgressBar?.Dispose(disposing);
            TrackInsideProgressBar?.Dispose(disposing);
            ThinTrackStyle?.Dispose(disposing);
        }

        public override void OnDisappearing()
        {
            isDisposed = true;
            this.Dispose(true);
        }

        private void TrackOutsideProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.TrackOutsideProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.TrackOutsideProgressBar.Progress = 100;
            }
        }

        private void FilledIndicatorProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.FilledIndicatorProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.FilledIndicatorProgressBar.Progress = 100;
            }
        }

        private void ThinTrackStyle_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.ThinTrackStyle.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.ThinTrackStyle.Progress = 100;
            }
        }

        private async Task SetTrackInsideProgress()
        {
            double progress = 0;
            while (progress < 100)
            {
                if (isDisposed)
                {
                    break;
                }

                this.TrackInsideProgressBar.Progress = progress += 0.25;
                this.TrackInsideProgressBarProgressLabel.Text = (int)progress + "%";
                await Task.Delay(50);
            }

            this.TrackInsideProgressBar.SetProgress(0, 0, Easing.Linear);

            if (!this.isDisposed)
            {
                await SetTrackInsideProgress();
            }
        }
    }
}