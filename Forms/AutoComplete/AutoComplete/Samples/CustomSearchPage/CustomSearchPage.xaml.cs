#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public partial class CustomSearchPage : SampleView
	{
		public CustomSearchPage()
		{
			InitializeComponent();
			this.BindingContext = new CustomViewModel();
			this.autoComplete.Filter = (this.BindingContext as CustomViewModel).CustomSearchLogic;
            if (Device.RuntimePlatform == Device.UWP)
                FirstColumn.Padding = new Thickness(0, 0, 0, 0);
 
			if (Device.Idiom == TargetIdiom.Tablet)
            {
                GridLayout gridLayout = new GridLayout();
                gridLayout.SpanCount = 8;
                listView.LayoutManager = gridLayout;
                listView.WidthRequest = 600;
            }
		}
	}
}