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
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfLinearGauge
{
    [Preserve(AllMembers = true)]
    public partial class Ranges : SampleView
    {
       
        public Ranges()
        {
            InitializeComponent();
            this.BackgroundColor = Color.White;
            if(gauge1!= null)
            {
                if (Device.RuntimePlatform == Device.UWP)
                    gauge1.Scales[0].LabelOffset = 27;
                else
                    gauge1.Scales[0].LabelOffset = 20;
            }

            var height = (int)Core.SampleBrowser.ScreenHeight/4;
            if(Device.RuntimePlatform != Device.UWP && height > 0)
            {
                if (gauge1 != null)
                    gauge1.HeightRequest = height ;
                if (gauge != null)
                    gauge.HeightRequest = height;
                if (gauge2 != null)
                    gauge2.HeightRequest = height;
            }
          

        }   
    }
}