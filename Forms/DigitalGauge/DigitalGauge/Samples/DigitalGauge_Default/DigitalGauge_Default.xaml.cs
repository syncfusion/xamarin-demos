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
    public partial class DigitalGauge_Default : SampleView
    {

        DateTime dateTime = new DateTime();

        public void EnableTimer()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }


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
        public DigitalGauge_Default()
        {
            InitializeComponent();

            string dateTimeValue = DateTime.Now.ToString("HH mm ss");

            //segmentSevenGaugee
            segmentSevenGauge.Value = dateTimeValue;
            segmentSevenGauge.BackgroundColor = Color.Transparent;
            segmentSevenGauge.CharacterStrokeColor = Color.FromRgb(20, 108, 237);
            segmentSevenGauge.DisabledSegmentColor = Color.FromRgb(20, 60, 106);
            segmentSevenGauge.HeightRequest = 50;

            //segmentFourteenGaugee
            segmentFourteenGauge.Value = dateTimeValue;
            segmentFourteenGauge.BackgroundColor = Color.Transparent;
            segmentFourteenGauge.CharacterStrokeColor = Color.FromRgb(2, 186, 94);
            segmentFourteenGauge.DisabledSegmentColor = Color.FromRgb(2, 186, 94);
            segmentFourteenGauge.HeightRequest = 50;

            //segmentSixteenGaugee
            segmentSixteenGauge.Value = dateTimeValue;
            segmentSixteenGauge.BackgroundColor = Color.Transparent;
            segmentSixteenGauge.CharacterStrokeColor = Color.FromRgb(219, 153, 7);
            segmentSixteenGauge.DisabledSegmentColor = Color.FromRgb(219, 153, 7);
            segmentSixteenGauge.HeightRequest = 50;

            //segmentMatrixGaugee
            segmentMatrixGauge.Value = dateTimeValue;
            segmentMatrixGauge.BackgroundColor = Color.Transparent;
            segmentMatrixGauge.CharacterStrokeColor = Color.FromRgb(249, 66, 53);
            segmentMatrixGauge.DisabledSegmentColor = Color.FromRgb(249, 66, 53);
            segmentMatrixGauge.HeightRequest = 50;

            valueSettings();
        }

        public void valueSettings()
        {
           
            if (Device.RuntimePlatform == Device.iOS)
            {
                segmentSevenGauge.WidthRequest = (8 * segmentSevenGauge.CharacterWidth) + (8 * segmentSevenGauge.CharacterSpacing);
                segmentFourteenGauge.WidthRequest = (8 * segmentFourteenGauge.CharacterWidth) + (8 * segmentFourteenGauge.CharacterSpacing);
                segmentSixteenGauge.WidthRequest = (8 * segmentSixteenGauge.CharacterWidth) + (8 * segmentSixteenGauge.CharacterSpacing);
                segmentMatrixGauge.WidthRequest = (9 * segmentMatrixGauge.CharacterWidth) + (8 * segmentMatrixGauge.CharacterSpacing);
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
                //segmentSevenGauge
                segmentSevenGauge.HeightRequest = 65;
                segmentSevenGauge.CharacterHeight = 65;
                segmentSevenGauge.CharacterWidth = 20;
                segmentSevenGauge.SegmentStrokeWidth = 3;
                segmentSevenGauge.WidthRequest = 350;

                //segmentFourteenGauge
                segmentFourteenGauge.HeightRequest = 65;
                segmentFourteenGauge.CharacterHeight = 65;
                segmentFourteenGauge.CharacterWidth = 20;
                segmentFourteenGauge.SegmentStrokeWidth = 3;
                segmentFourteenGauge.WidthRequest = 350;

                //segmentSixteenGauge
                segmentSixteenGauge.HeightRequest = 65;
                segmentSixteenGauge.CharacterHeight = 65;
                segmentSixteenGauge.CharacterWidth = 20;
                segmentSixteenGauge.SegmentStrokeWidth = 3;
                segmentSixteenGauge.WidthRequest = 350;

                //segmentMatrixGauge
                segmentMatrixGauge.HeightRequest = 65;
                segmentMatrixGauge.CharacterHeight = 65;
                segmentMatrixGauge.CharacterWidth = 20;
                segmentMatrixGauge.SegmentStrokeWidth = 3;
                segmentMatrixGauge.WidthRequest = 350;

                sevenSegment.WidthRequest = 350;
                fourteenSegment.WidthRequest = 350;
                sixteenSegment.WidthRequest = 350;
                matrixSegment.WidthRequest = 350;

                //Center alignment
                segmentSevenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentFourteenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentSixteenGauge.HorizontalOptions = LayoutOptions.Center;
                segmentMatrixGauge.HorizontalOptions = LayoutOptions.Center;

                //Text Alignment
                sevenSegment.HorizontalTextAlignment = TextAlignment.Center;
                fourteenSegment.HorizontalTextAlignment = TextAlignment.Center;
                sixteenSegment.HorizontalTextAlignment = TextAlignment.Center;
                matrixSegment.HorizontalTextAlignment = TextAlignment.Center;

                MainGrid.BackgroundColor = Color.White;
                sevenSegment.TextColor = Color.Black;
                fourteenSegment.TextColor = Color.Black;
                sixteenSegment.TextColor = Color.Black;
                matrixSegment.TextColor = Color.Black;
            }
        }

        public View getContent()
        {
            return this.Content;
        }

    }
}
