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

namespace SampleBrowser.SfRotator
{
	public partial class Rotator : SampleView
	{
		public Rotator()
		{
			InitializeComponent();

           if (Device.Idiom == TargetIdiom.Phone || Device.RuntimePlatform == Device.UWP)
            {
                Rotator_Default rotator = new Rotator_Default();
                this.Content = rotator.getContent();
                this.PropertyView = rotator.getPropertyView();
            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                Rotator_TabletView rotator_tab = new Rotator_TabletView();
                this.Content = rotator_tab.getContent();
                this.PropertyView =  rotator_tab.getPropertyView();

            }
                

		}
	}
}

