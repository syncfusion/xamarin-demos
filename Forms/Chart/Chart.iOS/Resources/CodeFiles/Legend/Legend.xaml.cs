#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public partial class Legend : SampleBrowser.Core.SampleView
	{
		public Legend()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP )
            {
                if (Device.RuntimePlatform != Device.WinPhone)
                {
                    chart.Legend.DockPosition = LegendPlacement.Right;

                    chart.Margin = new Thickness(200, 0, 200, 0);
                    chart.Legend.MaxWidth = 200;
                }
            }

            if(Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP)
            {
                chart.Legend.DockPosition = LegendPlacement.Right;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS))
            {
                if (height > 0 && width > 0)
                {
                    if (height > width)
                    {
                        stack.Padding = new Thickness(0);
                        chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
                        chart.Legend.DockPosition = LegendPlacement.Bottom;
                    }
                    else
                    {
                        double padding = (stack.Width - stack.Height) / 2;
                        stack.Padding = new Thickness(padding / 3, 0, padding / 3, 0);
                        chart.Title.Margin = new Thickness(0);
                        chart.Legend.DockPosition = LegendPlacement.Right;
                        chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
                    }
                }
            }
        }
    }

	public class BoolToFontAttributesConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
				return FontAttributes.Bold;
			return FontAttributes.None;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
            return null;
		}
	}

}