#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfDigitalGauge
{
    [Preserve(AllMembers = true)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DigitalGauge_Tablet : SampleView
    {

        public void EnableTimer()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }
        DateTime dateTime = new DateTime();
        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    string dateTimeValue = DateTime.Now.ToString("HH mm ss");
                    segmentSevenGauge.Value = dateTimeValue;
                    segmentFourteenGauge.Value = dateTimeValue;
                    segmentSixteenGauge.Value = dateTimeValue;
                    segmentMatrixGauge.Value = dateTimeValue;
                }
            }
            get
            {
                return dateTime;
            }
        }
        public DigitalGauge_Tablet()
        {
            InitializeComponent();

            string dateTimeValue = DateTime.Now.ToString("HH mm ss");

            //Setting value
            segmentSevenGauge.Value = dateTimeValue;
            segmentFourteenGauge.Value = dateTimeValue;
            segmentSixteenGauge.Value = dateTimeValue;
            segmentMatrixGauge.Value = dateTimeValue;

            //Background color
            segmentSevenGauge.BackgroundColor = Color.FromRgb(235, 235, 235);
            segmentFourteenGauge.BackgroundColor = Color.FromRgb(235, 235, 235);
            segmentSixteenGauge.BackgroundColor = Color.FromRgb(235, 235, 235);
            segmentMatrixGauge.BackgroundColor = Color.FromRgb(235, 235, 235);

            //Character StrokeColorr
            segmentSevenGauge.CharacterStrokeColor = Color.FromRgb(20, 108, 237);
            segmentSixteenGauge.CharacterStrokeColor = Color.FromRgb(219, 153, 7);
            segmentMatrixGauge.CharacterStrokeColor = Color.FromRgb(249, 66, 53);
            segmentFourteenGauge.CharacterStrokeColor = Color.FromRgb(2, 186, 94);

            //Disabled SegmentColor
            segmentFourteenGauge.DisabledSegmentColor = Color.FromRgb(2, 186, 94);
            segmentSixteenGauge.DisabledSegmentColor = Color.FromRgb(219, 153, 7);
            segmentSevenGauge.DisabledSegmentColor = Color.FromRgb(20, 60, 106);
            segmentMatrixGauge.DisabledSegmentColor = Color.FromRgb(249, 66, 53);

            deviceSetting();
        }

        public void deviceSetting()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                //segmentSevenGauge
                segmentSevenGauge.HeightRequest = 100;
                segmentFourteenGauge.HeightRequest = 100;
                segmentSixteenGauge.HeightRequest = 100;
                segmentMatrixGauge.HeightRequest = 100;

                //segmentSevenGauge
                segmentSevenGauge.CharacterHeight = 100;
                segmentFourteenGauge.CharacterHeight = 100;
                segmentSixteenGauge.CharacterHeight = 100;
                segmentMatrixGauge.CharacterHeight = 100;

                //segmentSevenGaugee
                segmentSevenGauge.CharacterWidth = 50;
                segmentFourteenGauge.CharacterWidth = 50;
                segmentSixteenGauge.CharacterWidth = 50;
                segmentMatrixGauge.CharacterWidth = 50;

                //segmentSevenGaugee
                segmentSevenGauge.WidthRequest = (8 * segmentSevenGauge.CharacterWidth) + (7 * segmentSevenGauge.CharacterSpacing);
                segmentFourteenGauge.WidthRequest = (8 * segmentFourteenGauge.CharacterWidth) + (7 * segmentFourteenGauge.CharacterSpacing);
                segmentSixteenGauge.WidthRequest = (8 * segmentSixteenGauge.CharacterWidth) + (7 * segmentSixteenGauge.CharacterSpacing);
                segmentMatrixGauge.WidthRequest = (9 * segmentMatrixGauge.CharacterWidth) + (7 * segmentMatrixGauge.CharacterSpacing);

                segmentSevenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentFourteenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentSixteenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentMatrixGauge.HorizontalOptions = LayoutOptions.Center;
            }
            EnableTimer();

            if (Device.RuntimePlatform == Device.Android)
            {
                segmentSevenGauge.HeightRequest = segmentSevenGauge.CharacterHeight + segmentSevenGauge.CharacterHeight / 6;
                segmentFourteenGauge.HeightRequest = segmentFourteenGauge.CharacterHeight + segmentFourteenGauge.CharacterHeight / 6;
                segmentSixteenGauge.HeightRequest = segmentSixteenGauge.CharacterHeight + segmentSixteenGauge.CharacterHeight / 6;
                segmentMatrixGauge.HeightRequest = segmentMatrixGauge.CharacterHeight + segmentMatrixGauge.CharacterHeight / 6;
            }
            if (Device.RuntimePlatform == Device.UWP)
            {
                segmentSevenGauge.HeightRequest = 65;
                segmentFourteenGauge.HeightRequest = 65;
                segmentSixteenGauge.HeightRequest = 65;
                segmentMatrixGauge.HeightRequest = 65;

                segmentSevenGauge.CharacterHeight = 65;
                segmentSevenGauge.CharacterWidth = 20;
                segmentSevenGauge.SegmentStrokeWidth = 3;

                segmentFourteenGauge.CharacterHeight = 65;
                segmentFourteenGauge.CharacterWidth = 20;
                segmentFourteenGauge.SegmentStrokeWidth = 3;

                segmentSixteenGauge.CharacterHeight = 65;
                segmentSixteenGauge.CharacterWidth = 20;
                segmentSixteenGauge.SegmentStrokeWidth = 3;

                segmentMatrixGauge.CharacterHeight = 65;
                segmentMatrixGauge.CharacterWidth = 20;
                segmentMatrixGauge.SegmentStrokeWidth = 3;

                segmentSevenGauge.WidthRequest = 350;
                segmentFourteenGauge.WidthRequest = 350;
                segmentSixteenGauge.WidthRequest = 350;
                segmentMatrixGauge.WidthRequest = 350;
                sevenSegment.WidthRequest = 350;
                fourteenSegment.WidthRequest = 350;
                sixteenSegment.WidthRequest = 350;
                matrixSegment.WidthRequest = 350;

                segmentSevenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentFourteenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentSixteenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentMatrixGauge.HorizontalOptions = LayoutOptions.Center;

                sevenSegment.HorizontalTextAlignment = TextAlignment.Center;
                fourteenSegment.HorizontalTextAlignment = TextAlignment.Center;
                sixteenSegment.HorizontalTextAlignment = TextAlignment.Center;
                matrixSegment.HorizontalTextAlignment = TextAlignment.Center;

                sixteenSegment.FontSize = 20;
                matrixSegment.FontSize = 20;
                sevenSegment.FontSize = 20;
                fourteenSegment.FontSize = 20;

            }
        }

        public View getContent()
        {
            return this.Content;
        }

    }
}
