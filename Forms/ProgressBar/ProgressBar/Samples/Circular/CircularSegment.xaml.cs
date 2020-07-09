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

    public partial class CircularSegment : SampleView
    {
        private bool isDisposed;
        public CircularSegment()
        {
            InitializeComponent();
            this.SegmentedPaddingCircularProgressBar.AnimationDuration = 2000;
            this.SegmentedCircularProgressBar.AnimationDuration = 2000;
            this.SegmentedFillingStyle.AnimationDuration = 0;
#pragma warning disable CS4014
            this.SetSegmentedFillingStyleProgress();
#pragma warning restore CS4014
        }

        public void Dispose(bool disposing)
        {
            SegmentedCircularProgressBar?.Dispose(disposing);
            SegmentedPaddingCircularProgressBar?.Dispose(disposing);
            SegmentedFillingStyle?.Dispose(disposing);
        }

        public override void OnDisappearing()
        {
            isDisposed = true;
            this.Dispose(true);
        }

        private void SegmentedCircularProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(75))
            {
                this.SegmentedCircularProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.SegmentedCircularProgressBar.Progress = 75;
            }
        }

        private void SegmentedPaddingCircularProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(75))
            {
                this.SegmentedPaddingCircularProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.SegmentedPaddingCircularProgressBar.Progress = 75;
            }
        }

        private async Task SetSegmentedFillingStyleProgress()
        {
            double progress = 0;
            this.SegmentedFillingStyle.Progress = 0;
            await Task.Delay(300);
            while (progress < 100)
            {
                if (isDisposed)
                {
                    break;
                }

                this.SegmentedFillingStyle.Progress = progress += 5;
                await Task.Delay(300);
            }

            if (!this.isDisposed)
            {
                await SetSegmentedFillingStyleProgress();
            }
        }
    }
}