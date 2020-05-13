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

namespace SampleBrowser.SfSunburstChart
{
    [Preserve(AllMembers = true)]
    public partial class Drilldown : SampleView
    {
        public Drilldown()
        {
            InitializeComponent();           
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {                
                title.FontSize = 20;
                legendStyle.FontSize = 16;
            }
            else
            {
                legendStyle.FontSize = 14;
                dataLabel.FontSize = 10;
            }
        }
    }
}