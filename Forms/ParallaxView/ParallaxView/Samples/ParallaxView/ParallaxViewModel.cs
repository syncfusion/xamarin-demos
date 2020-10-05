#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfParallaxView
{
    [Preserve(AllMembers = true)]

    public class ParallaxViewModel
    {
        public string Name
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public string Tracks
        {
            get;
            set;
        }
        public ImageSource Image
        {
            get;
            set;
        }
    }
}
