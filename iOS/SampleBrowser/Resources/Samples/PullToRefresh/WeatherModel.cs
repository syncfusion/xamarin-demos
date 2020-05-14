#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;

namespace SampleBrowser
{
	public class WeatherModel 
	{
		public WeatherModel(NSString date,NSString type, NSString temp,NSString day)
		{
			Date = date;
			Day = day;
			Type = type;
			Temp = temp;
		}

		internal NSString Date;

       internal  NSString Day;

        internal NSString Type;

       internal  NSString Temp;

	}
}

