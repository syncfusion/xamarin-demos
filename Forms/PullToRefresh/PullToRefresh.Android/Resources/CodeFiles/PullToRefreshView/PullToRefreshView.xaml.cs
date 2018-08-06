#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfPullToRefresh.XForms;
using System.Threading;
using SampleBrowser.Core;

namespace SampleBrowser.SfPullToRefresh
{
   [Xamarin.Forms.Internals.Preserve(AllMembers =true)]
    public partial class PullToRefreshView : SampleView
    {
        public PullToRefreshView()
        {
            InitializeComponent();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                height -= 100;
            }
            base.OnSizeAllocated(width, height);
        }
    }
}

