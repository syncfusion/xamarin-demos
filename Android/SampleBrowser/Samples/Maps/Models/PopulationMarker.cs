#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Maps;
using Android.Graphics;

namespace SampleBrowser
{
	public class PopulationMarker : MapMarker
	{
		public PopulationMarker (Android.Content.Context con)
		{
			context = con;
		}

		Android.Content.Context context;

		public string Name
        {
			get;
			set;
		}

		public string Population
        {
			get;
			set;
		}
	}
}
