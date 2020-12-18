#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public partial class MusicSearch
	{
		public MusicSearch()
		{
			InitializeComponent();

			this.BindingContext = new MusicViewModel();

            if (Device.RuntimePlatform == Device.iOS)
            {
                MusicICon_B.VerticalTextAlignment = TextAlignment.Center;
                SearchedItem.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_F.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_M.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_R.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_E.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_V.VerticalTextAlignment = TextAlignment.Center;

            }

		}

		protected override void OnSizeAllocated(double width, double height)
        {
            if (height < width && Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Phone)
            {
                playerLabel.FontSize = 50;
            }
            else
            {
                playerLabel.FontSize = 80;
            }
            base.OnSizeAllocated(width, height);
        }
	}
}
