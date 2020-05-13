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
    using Xamarin.Forms;

    public partial class Linear : SampleView
    {
        public Linear()
        {
            InitializeComponent();
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Grid panel = this.Content as Grid;
            if (panel != null)
            {
                foreach (SampleView view in panel.Children)
                {
                    view?.OnDisappearing();
                }
            }
        }

    }
}