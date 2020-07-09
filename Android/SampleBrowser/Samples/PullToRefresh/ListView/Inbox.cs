#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace SampleBrowser
{
    public class Mail
    {
        #region Properties

        public string Sender
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public Color BackgroundColor
        {
            get;
            set;
        }

        #endregion
    }
}