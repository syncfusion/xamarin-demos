#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SampleBrowser.SfProgressBar
{
    using SampleBrowser.Core;
    using Syncfusion.XForms.ProgressBar;
    using Xamarin.Forms;

    public partial class LinearRangeColors : SampleView
    {
        public LinearRangeColors()
        {
            InitializeComponent();
            this.RangeColorProgressBar.AnimationDuration = 2000;
            this.RangeColorWithGradientProgressBar.AnimationDuration = 2000;
        }

        public void Dispose()
        {
            RangeColorProgressBar?.Dispose(true);
            RangeColorWithGradientProgressBar?.Dispose(true);
        }

        public override void OnDisappearing()
        {
            this.Dispose();
        }

        private void RangeColorProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.RangeColorProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.RangeColorProgressBar.Progress = 100;
            }
        }

        private void RangeColorWithGradiantProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.RangeColorWithGradientProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.RangeColorWithGradientProgressBar.Progress = 100;
            }
        }
    }
}