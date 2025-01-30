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

