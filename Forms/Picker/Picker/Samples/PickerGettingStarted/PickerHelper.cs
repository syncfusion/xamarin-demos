#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfPicker
{
	public static class PickerHelper
	{
		static  Dictionary<string, Color> colors = new Dictionary<string, Color>();

		public static Color GetColor(object color)
		{
			colors.Clear();
			colors.Add("Yellow", Color.Yellow);
			colors.Add("Green", Color.Green);
			colors.Add("Orange", Color.Orange);
			colors.Add("Lime", Color.Lime);
			colors.Add("Purple", Color.Purple);
			colors.Add("Pink", Color.Pink);
			colors.Add("Black", Color.Black);
			colors.Add("Navy", Color.Navy);
			colors.Add("Red", Color.Red);
			colors.Add("Gray", Color.Gray);
			return colors[color.ToString()];
		}
	}
}
