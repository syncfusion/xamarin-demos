#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
	public partial class Configuration : SampleView
	{
		public Configuration()
		{
			InitializeComponent();
			if (Device.Idiom == TargetIdiom.Phone || Device.RuntimePlatform == "UWP")
			{
				Configuration_Default autocomplete = new Configuration_Default();
				this.Content = autocomplete.getContent();
				this.PropertyView = autocomplete.getPropertyView();

			}
			else if (Device.Idiom == TargetIdiom.Tablet)
			{
				Configuration_Tablet autocompleteTab = new Configuration_Tablet();
				this.Content = autocompleteTab.getContent();
                this.PropertyView = autocompleteTab.getPropertiesView();

			}
		}
	}
}

