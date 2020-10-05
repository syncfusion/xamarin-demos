#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Sample View
    /// </summary>
	[Preserve(AllMembers = true)]
	public partial class Localization : SampleView
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="Localization" /> class.
        /// </summary>
		public Localization()
		{
			this.InitializeComponent();
            if (Device.RuntimePlatform == "UWP" || Device.RuntimePlatform == "WPF")
            {
                this.PropertyView.IsVisible = false;
                this.PropertyView = null;
            }
        }
    }
}