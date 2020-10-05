#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfButton
{
    public partial class ToggleButtonSample : SampleView
    {
        public ToggleButtonSample()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.WPF)
            {
                centerAlignButton.ImageSource = "button_alignCenter.png";
                rightAlignButton.ImageSource = "button_alignRight.png";
                leftAlignButton.ImageSource = "button_alignLeft.png";
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                layout.HeightRequest = 40;
            }
        }

        private void FontButton_Clicked(object sender, System.EventArgs e)
        {
            Syncfusion.XForms.Buttons.SfButton button = (sender as Syncfusion.XForms.Buttons.SfButton);
            if (button == boldButton || button == italicButton)
            {
                if (boldButton.IsChecked && italicButton.IsChecked)
                {
                    hellowWorld.FontAttributes = FontAttributes.Bold | FontAttributes.Italic;
                }
                else if (boldButton.IsChecked)
                {
                    hellowWorld.FontAttributes = FontAttributes.Bold;
                }
                else if (italicButton.IsChecked)
                {
                    hellowWorld.FontAttributes = FontAttributes.Italic;
                }
                else
                {
                    hellowWorld.FontAttributes = FontAttributes.None;
                }
            }
            else if (button == underlineButton)
            {
                underlineBoxView.IsVisible = underlineButton.IsChecked;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Syncfusion.XForms.Buttons.SfButton button = (sender as Syncfusion.XForms.Buttons.SfButton);
            if (button == centerAlignButton)
            {
                textStack.HorizontalOptions = LayoutOptions.Center;
                hellowWorld.HorizontalTextAlignment = TextAlignment.Center;
                centerAlignButton.BackgroundColor = Color.LightGray;
                leftAlignButton.BackgroundColor = Color.Transparent;
                rightAlignButton.BackgroundColor = Color.Transparent;
            }
            else if (button == leftAlignButton)
            {
                textStack.HorizontalOptions = LayoutOptions.Start;
                hellowWorld.HorizontalTextAlignment = TextAlignment.Start;
                centerAlignButton.BackgroundColor = Color.Transparent;
                leftAlignButton.BackgroundColor = Color.LightGray;
                rightAlignButton.BackgroundColor = Color.Transparent;
            }
            else if (button == rightAlignButton)
            {
                textStack.HorizontalOptions = LayoutOptions.End;
                hellowWorld.HorizontalTextAlignment = TextAlignment.End;
                centerAlignButton.BackgroundColor = Color.Transparent;
                leftAlignButton.BackgroundColor = Color.Transparent;
                rightAlignButton.BackgroundColor = Color.LightGray;
            }
        }
    }
}