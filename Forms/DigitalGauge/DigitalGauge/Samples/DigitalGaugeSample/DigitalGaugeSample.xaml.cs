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
    public partial class DigitalGaugeSample : SampleView
    {
        public DigitalGaugeSample()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Phone)
            {
                DigitalGauge_Default digital = new DigitalGauge_Default();
                this.Content = digital.getContent();
            }
            else if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                DigitalGauge_Tablet digital = new DigitalGauge_Tablet();
                this.Content = digital.getContent();
            }
        }
    }
}
