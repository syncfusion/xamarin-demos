#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleBrowser.SfRating
{
	public partial class Rating : SampleView
	{

		public Rating()
		{
			InitializeComponent();
            if (Device.Idiom == TargetIdiom.Phone || Device.RuntimePlatform == Device.UWP)
			{
				Rating_Default busy = new Rating_Default();
				this.Content = busy.getContent();
				this.PropertyView = busy.getPropertyView();


			}
			else if (Device.Idiom == TargetIdiom.Tablet)
			{
				Rating_Tablet busyTab = new Rating_Tablet();
				this.Content = busyTab.getContent();
                this.PropertyView = busyTab.getPropertyContent();
			}
		}
	}
}
