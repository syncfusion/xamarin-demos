#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfMaps
{
    [Preserve(AllMembers = true)]
    public partial class Sublayer : SampleView
    {
        public Sublayer()
        {
            InitializeComponent();
            Uri uri = new Uri("http://www.samsung.com/semiconductor/about-us/location/");
            this.Link.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Device.OpenUri(uri))
            });
        }
    }
}