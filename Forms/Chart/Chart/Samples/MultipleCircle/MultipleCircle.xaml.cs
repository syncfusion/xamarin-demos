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
using System.Globalization;
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public partial class MultipleCircle : SampleView
	{
        public MultipleCircle()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                if (Device.Idiom != TargetIdiom.Phone)
                {
                    legend.DockPosition = LegendPlacement.Right;
                    Chart.Margin = new Thickness(200, 0, 200, 0);
                    doughnutSeries.Spacing = 0.5;
                    legend.OverflowMode = ChartLegendOverflowMode.Scroll;
                }
            }
            else if (Device.RuntimePlatform == Device.macOS)
            {
                legend.OverflowMode = ChartLegendOverflowMode.Scroll;
            }

            List<Color> colors = new List<Color>()
            {
                Color.FromHex("47ba9f"),
                Color.FromHex("e58870"),
                Color.FromHex("9686c9"),
                Color.FromHex("e56590")
            };

            colorModel.CustomBrushes = colors;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                if (height > 0 && width > 0)
                {
                    if (height > width)
                    {
                        Chart.Legend.DockPosition = LegendPlacement.Bottom;
                        legend.OverflowMode = ChartLegendOverflowMode.Wrap;
                        stack.Orientation = StackOrientation.Horizontal;
                    }
                    else
                    {
                        stack.Orientation = StackOrientation.Vertical;
                        Chart.Title.Margin = new Thickness(0);
                        Chart.Legend.DockPosition = LegendPlacement.Right;
                        legend.OverflowMode = ChartLegendOverflowMode.Scroll;
                    }
                }
            }
        }
    }

    public class IndexToItemSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            return new ObservableCollection<object>() { (value as ChartLegendItem).DataPoint };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}