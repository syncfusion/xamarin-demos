#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfBorder
{
    public partial class Customization : SampleView
    {
        double oldHeight = 0;
        double oldWidth = 0;
        public Customization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the orientation changed.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if ((Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS) && Device.Idiom == TargetIdiom.Phone)
            {
                if (width > height && oldWidth != width && oldHeight != height)
                {
                    innserPart.IsVisible = false;
                    labelPart.IsVisible = false;
                    innerRow.Height = 50;
                    topRow.Height = 60;
                    topBorder.HeightRequest = 60;
                    topBorder.WidthRequest = 60;
                    topBorder.CornerRadius = 30;
                    topBorder.Margin = new Thickness(0, 35, 0, 0);
                    topLabel.FontSize = 15;
                    numberPart.FontSize = 15;
                    followLabel.FontSize = 8;
                    number_part.FontSize = 15;
                    followersLabel.FontSize = 8;
                }
                else
                {
                    innserPart.IsVisible = true;
                    labelPart.IsVisible = true;
                    innerRow.Height = 170;
                    topRow.Height = 120;
                    topBorder.HeightRequest = 100;
                    topBorder.WidthRequest = 100;
                    topBorder.CornerRadius = 50;
                    topBorder.Margin = new Thickness(0, 70, 0, 0);
                    topLabel.FontSize = 20;
                    numberPart.FontSize = 18;
                    followLabel.FontSize = 11;
                    number_part.FontSize = 18;
                    followersLabel.FontSize = 11;
                }
                    oldHeight = height;
                    oldWidth = width;
            }
        }
    }
}
