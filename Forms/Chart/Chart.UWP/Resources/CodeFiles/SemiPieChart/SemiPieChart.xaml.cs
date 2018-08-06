#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class SemiPieChart : SampleView
	{
		public SemiPieChart()
		{
			InitializeComponent();
			series.ItemsSource = model.SemiCircularData;

            if (Device.RuntimePlatform == Device.macOS || Device.RuntimePlatform == Device.UWP)
            {
                Chart.Legend.OverflowMode = ChartLegendOverflowMode.Scroll;
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
                        layout.Padding = new Thickness(0);
                        Chart.Legend.DockPosition = LegendPlacement.Bottom;
                    }
                    else
                    {
                        double padding = (layout.Width - layout.Height) / 2;
                        layout.Padding = new Thickness(padding / 2, 0, padding / 2, 0);
                        Chart.Legend.DockPosition = LegendPlacement.Right;
                    }
                }
            }
        }
    }
}