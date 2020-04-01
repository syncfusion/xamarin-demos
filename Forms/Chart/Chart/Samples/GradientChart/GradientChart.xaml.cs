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
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace SampleBrowser.SfChart
{
    public partial class GradientChart : SampleView
    {
        public GradientChart()
        {
            InitializeComponent();
			if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                secondaryAxisLabelStyle.LabelFormat = "0'%'";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "#'%'";
            }
        }
    }
}
