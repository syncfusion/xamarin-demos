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

    public partial class LinearPadding : SampleView
    {
        public LinearPadding()
        {
            InitializeComponent();
            this.PaddingProgressBar.AnimationDuration = 2000;
        }

        public void Dispose()
        {
            PaddingProgressBar?.Dispose(true);
        }

        public override void OnDisappearing()
        {
            this.Dispose();
        }

        private void PaddingProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.PaddingProgressBar.SetProgress(0, 0, Easing.Linear);
            }
            
            if (e.Progress.Equals(0))
            {
                this.PaddingProgressBar.Progress = 100;
            }
        }
    }
}