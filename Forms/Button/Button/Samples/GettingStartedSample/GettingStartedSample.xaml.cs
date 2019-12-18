#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Graphics;
using Syncfusion.Buttons.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfButton
{
    #region Getting Started Sample Class

    public partial class GettingStartedSample : SampleView
    {
        #region Constructor

        public GettingStartedSample()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.WPF)
            {
                iconButtonLeft.ImageSource = "button_Heart.png";
                iconButtonRight.ImageSource = "button_Heart.png";

                SfLinearGradientBrush linearGradientBrush = new SfLinearGradientBrush();
                linearGradientBrush.GradientStops = new GradientStopCollection()
                {
                    new SfGradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                    new SfGradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
                };

                gradientButton.FontSize = 14;
                gradientButton.BackgroundGradient = linearGradientBrush;
            }

        }

        #endregion

        private void GradientButton_Clicked(object sender, System.EventArgs e)
        {
            if (Device.RuntimePlatform == Device.WPF)
            {
                SfLinearGradientBrush linearGradientBrush = new SfLinearGradientBrush();
                if (gradientButton.IsChecked == true)
                {
                    linearGradientBrush.GradientStops = new GradientStopCollection()
                    {
                        new SfGradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 0 },
                        new SfGradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 1 }
                    };
                }
                else
                {
                    linearGradientBrush.GradientStops = new GradientStopCollection()
                    {
                        new SfGradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                        new SfGradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
                    };
                }

                gradientButton.BackgroundGradient = linearGradientBrush;
            }
        }
    }
    #endregion
}