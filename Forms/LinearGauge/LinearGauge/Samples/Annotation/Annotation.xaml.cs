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
    public partial class Annotation : SampleView
    {
        public Annotation()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                if (i >2 && i <6)
                {
                    gauge.Annotations[i].ViewMargin = new Point(0, 80);
                }
                else if(i==6)
                    gauge.Annotations[i].ViewMargin = new Point(0, -80);

                else
                {
                    gauge.Annotations[i].ViewMargin = new Point(0, 30);
                }
            }
       
        }
    }
}