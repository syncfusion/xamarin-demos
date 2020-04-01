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

    public partial class LinearCornerRadius : SampleView
    {
        public LinearCornerRadius()
        {
            InitializeComponent();
            this.CornerRadiusProgressBar.AnimationDuration = 2000;
        }

        public void Dispose()
        {
            CornerRadiusProgressBar?.Dispose(true);
        }

        public override void OnDisappearing()
        {
            this.Dispose();
        }

        private void CornerRadiusProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.CornerRadiusProgressBar.SetProgress(0, 0, Easing.Linear);
            }

            if (e.Progress.Equals(0))
            {
                this.CornerRadiusProgressBar.Progress = 100;
            }
        }
    }
}