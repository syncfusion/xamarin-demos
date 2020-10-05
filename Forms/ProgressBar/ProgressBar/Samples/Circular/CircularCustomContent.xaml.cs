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

    public partial class CircularCustomContent : SampleView
    {

        public CircularCustomContent()
        {
            InitializeComponent();
            this.CustomContentCircularProgressBar.AnimationDuration = 0;
            this.VideoPlayerProgressBar.AnimationDuration = 2000;
            this.SetCustomContentProgress();
        }

        public void Dispose(bool disposing)
        {
            CustomContentCircularProgressBar?.Dispose(disposing);
            VideoPlayerProgressBar?.Dispose(disposing);
        }

        public override void OnDisappearing()
        {
            this.Dispose(true);
        }

        private async void SetCustomContentProgress()

        {
            double progress = 0;
            while (progress < 75)
            {
                this.CustomContentCircularProgressBar.Progress = progress += 1;
                this.CustomContentProgressBarLabel.Text = progress + "%";
                await Task.Delay(50);
            }
        }
        
        private void PlayButton_Clicked(object sender, System.EventArgs e)
        {
            this.VideoPlayerProgressBar.Progress = 100;
            this.PauseButton.IsVisible = true;
            this.PlayButton.IsVisible = false;
        }

        private void PauseButton_Clicked(object sender, System.EventArgs e)
        {
            this.VideoPlayerProgressBar.SetProgress(
                (double)this.VideoPlayerProgressBar.GetValue(SfCircularProgressBar.ActualProgressValueProperty), 0, Easing.Linear);
            this.PlayButton.IsVisible = true;
            this.PauseButton.IsVisible = false;
        }

        private void VideoPlayerProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.VideoPlayerProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.VideoPlayerProgressBar.Progress = 100;
            }
        }
    }
}