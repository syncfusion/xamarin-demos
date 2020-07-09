#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class Annotations : SampleView
	{
		public Annotations()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
            {
                if (Device.Idiom != TargetIdiom.Phone)
                {
                    ChartAnnotationLabelStyle verticalAnnotationLabelStyle = new ChartAnnotationLabelStyle();
                    verticalAnnotationLabelStyle.Margin = new Thickness(0, 0, 5, 20);
                    verticalAnnotationLabelStyle.VerticalTextAlignment = ChartAnnotationAlignment.Start;
                    verticalAnnotationLabelStyle.HorizontalTextAlignment = ChartAnnotationAlignment.Start;
                    verticalLineAnnotation.LabelStyle = verticalAnnotationLabelStyle;
                    verticalLineAnnotation.AxisLabelStyle = new ChartLabelStyle()
                    {
                        Margin = Device.RuntimePlatform == Device.UWP ? new Thickness(5) : new Thickness(10),
                        BackgroundColor = Color.FromRgb(37, 143, 251),
                        TextColor = Color.White,
                    };

                    ChartAnnotationLabelStyle horizontalAnnotationLabelStyle = new ChartAnnotationLabelStyle();
                    horizontalAnnotationLabelStyle.Margin = new Thickness(0, 0, 0, 20);
                    horizontalAnnotationLabelStyle.VerticalTextAlignment = ChartAnnotationAlignment.Start;
                    horizontalAnnotationLabelStyle.HorizontalTextAlignment = ChartAnnotationAlignment.End;
                    horizontalLineAnnotation.LabelStyle = horizontalAnnotationLabelStyle;
                    horizontalLineAnnotation.AxisLabelStyle = new ChartLabelStyle()
                    {
                        Margin = Device.RuntimePlatform == Device.UWP ? new Thickness(5) : new Thickness(10),
                        BackgroundColor = Color.FromRgb(37, 143, 251),
                        TextColor = Color.White,
                    };

                    ChartAnnotationLabelStyle labelStyle = new ChartAnnotationLabelStyle();
                    rectangleAnnotation.LabelStyle = labelStyle;
                    ellipseAnnotation.LabelStyle = labelStyle;
                    textAnnotation.LabelStyle = labelStyle;

                    if (Device.RuntimePlatform == Device.WPF)
                    {
                        chart.ChartPadding = new Thickness(0, 0, 5, 0);
                    }
                }
            }
        }
	}
}
