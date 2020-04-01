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

    public partial class LinearBuffer : SampleView
    {
        public LinearBuffer()
        {
            InitializeComponent();
            this.SecondaryProgressProgressBar.AnimationDuration = 2000;
            this.SecondaryProgressProgressBar.SecondaryAnimationDuration = 1000;
        }

        public void Dispose()
        {
            SecondaryProgressProgressBar?.Dispose(true);
        }

        public override void OnDisappearing()
        {
            this.Dispose();
        }

        private async void SecondaryProgressProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.SecondaryProgressProgressBar.SecondaryAnimationDuration = 0;
                await Task.Delay(100);
                this.SecondaryProgressProgressBar.SecondaryProgress = 0;
                this.SecondaryProgressProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.SecondaryProgressProgressBar.SecondaryAnimationDuration = 1000;
                await Task.Delay(100);
                this.SecondaryProgressProgressBar.SecondaryProgress = 100;
                this.SecondaryProgressProgressBar.Progress = 100;
            }
        }
    }
}