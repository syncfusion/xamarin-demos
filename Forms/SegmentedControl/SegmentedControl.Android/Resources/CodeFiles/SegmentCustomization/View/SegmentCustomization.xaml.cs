#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfSegmentedControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentCustomization : SampleView
    {
        #region Memebers

        /// <summary>
        /// customization view model initialization
        /// </summary>
        private CustomizationViewModel viewModel = new CustomizationViewModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Custom view constructor
        /// </summary>
        public SegmentCustomization()
        {
            InitializeComponent();
            this.Backlight.ItemsSource = viewModel.BackLightCollection;
            this.IconSegment.ItemsSource = viewModel.IconCollection;
            this.PrimaryColorSegment.ItemsSource = viewModel.PrimaryColors;
            this.Image_Text.ItemsSource = viewModel.Image_textCollection;
            if(Device.OS==TargetPlatform.iOS)
            {
                Backlight.CornerRadius = 15;
                Backlight.SelectionIndicatorSettings.CornerRadius = 15;
            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                BackgroundGrid.HeightRequest = width;
            }
            else
                BackgroundGrid.HeightRequest = height;
        }

        #endregion

        #region Events

        /// <summary>
        /// Raised when change the color from segmented control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Handle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PrimaryColorSegment.SelectionTextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Backlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Index == 1)
            {
                if (Device.RuntimePlatform == Device.UWP)
                {
                    this.MainGrid.FadeTo(0.75, 250, Easing.Linear);
                }
                else   
                    this.MainGrid.FadeTo(0.5, 250, Easing.Linear);
            }
            else
            {
                this.MainGrid.FadeTo(1, 500, Easing.Linear);
            }
        }
        #endregion

        #region Dispose

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }


}