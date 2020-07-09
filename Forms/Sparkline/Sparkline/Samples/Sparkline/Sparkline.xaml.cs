#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSparkline
{
    [Preserve(AllMembers = true)]
    public partial class Sparkline : SampleBrowser.Core.SampleView
    {
		public Sparkline()
		{
			InitializeComponent();

			if (Device.Idiom == TargetIdiom.Phone)
			{
				var sparkline_phone = new Sparkline_Phone();
				Content = sparkline_phone.getContent();
				PropertyView = sparkline_phone.getPropertyView();
			}
			else if (Device.RuntimePlatform == Device.UWP || Device.Idiom == TargetIdiom.Tablet)
			{
				var sparkline_windows = new Spark_Windows();
				Content = sparkline_windows.getContent();
				PropertyView = sparkline_windows.getPropertyView();
			}
		}
	}
}