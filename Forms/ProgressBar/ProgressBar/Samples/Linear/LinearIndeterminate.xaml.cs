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

    public partial class LinearIndeterminate : SampleView
    {
        public LinearIndeterminate()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            IndeterminateProgressBar?.Dispose(true);
        }

        public override void OnDisappearing()
        {
            this.Dispose();
        }

    }
}