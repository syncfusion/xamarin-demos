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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfCircularGauge
{
	[Preserve(AllMembers = true)]
    public partial class MultipleScales : SampleView
    {
        public MultipleScales()
        {
            InitializeComponent();

            scale1_StartAngle_slider.BindingContext = viewModel;
            scale1_SweepAngle_slider.BindingContext = viewModel;
            scale2_StartAngle_slider.BindingContext = viewModel;
            scale2_SweepAngle_slider.BindingContext = viewModel;

            //directionPicker.SelectedIndex = 0;
            //directionPicker.SelectedIndexChanged += DirectionPicker_SelectedIndexChanged;
        }

        //private void DirectionPicker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (directionPicker.SelectedIndex)
        //    {
        //        case 0:
        //            scale1.Direction = ScaleDirection.Clockwise;
        //            scale2.Direction = ScaleDirection.Clockwise;
        //            break;

        //        case 1:
        //            scale1.Direction = ScaleDirection.AntiClockwise;
        //            scale2.Direction = ScaleDirection.AntiClockwise;
        //            break;
        //    }
        //}
    }
}
