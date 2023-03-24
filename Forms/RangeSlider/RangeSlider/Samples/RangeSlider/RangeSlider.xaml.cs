#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfRangeSlider
{
    public partial class RangeSlider : SampleView
    {
        public RangeSlider()
        {
            InitializeComponent();
            RangeSlider_Default linear = new RangeSlider_Default();
            this.Content = linear.getContent();

        }
    }
}

