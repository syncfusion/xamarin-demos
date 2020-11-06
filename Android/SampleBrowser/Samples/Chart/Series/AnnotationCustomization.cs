#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;

namespace SampleBrowser
{
    class AnnotationCustomization:SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.AreaBackgroundColor = Color.Rgb(245, 245, 245);

            NumericalAxis categoryaxis = new NumericalAxis();
			categoryaxis.ShowMajorGridLines = false;
            categoryaxis.Minimum = 0;
            categoryaxis.Maximum = 4;
            categoryaxis.LineStyle.StrokeColor = Color.White;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
			numericalaxis.ShowMajorGridLines = false;
            numericalaxis.Minimum = 20;
            numericalaxis.Maximum = 70;
            numericalaxis.LineStyle.StrokeColor = Color.White;
            chart.SecondaryAxis = numericalaxis;

            LineAnnotation lineAnnotation = new LineAnnotation();
            lineAnnotation.Text = "Line";
            lineAnnotation.X1 = 2.5;
            lineAnnotation.X2 = 3.5;
            lineAnnotation.Y1 = 52;
            lineAnnotation.Y2 = 63;
            lineAnnotation.LabelStyle.MarginTop = 5;
            lineAnnotation.LabelStyle.MarginRight = 5;
            lineAnnotation.LabelStyle.MarginLeft = 5;
            lineAnnotation.LabelStyle.MarginBottom = 5;
            lineAnnotation.LineCap = ChartLineCap.Arrow;

            HorizontalLineAnnotation horizontalAnnotation = new HorizontalLineAnnotation();
            horizontalAnnotation.Y1 = 45;
            horizontalAnnotation.Text = "Horizontal Line";
            horizontalAnnotation.LineCap = ChartLineCap.Arrow;
            horizontalAnnotation.ShowAxisLabel = true;

            VerticalLineAnnotation verticalAnnotation = new VerticalLineAnnotation();
            verticalAnnotation.X1 = 2;
            verticalAnnotation.Text = "Vertical Line";
            verticalAnnotation.LineCap = ChartLineCap.Arrow;
            verticalAnnotation.ShowAxisLabel = true;

            RectangleAnnotation RectAnnotation = new RectangleAnnotation();
            RectAnnotation.X1 = 0.5;
            RectAnnotation.X2 = 1.5;
            RectAnnotation.Y1 = 25;
            RectAnnotation.Y2 = 35;
            RectAnnotation.Text = "Rectangle";

            EllipseAnnotation eleAnnotation = new EllipseAnnotation();
            eleAnnotation.X1 = 2.5;
            eleAnnotation.X2 = 3.5;
            eleAnnotation.Y1 = 25;
            eleAnnotation.Y2 = 35;
            eleAnnotation.Text = "Ellipse";

            TextAnnotation textAnnotation = new TextAnnotation();

            textAnnotation.X1 = 1;
            textAnnotation.Y1 = 57.5;
            textAnnotation.Text = "Text Annotation";

            chart.Annotations.Add(textAnnotation);
            chart.Annotations.Add(eleAnnotation);
            chart.Annotations.Add(RectAnnotation);
            chart.Annotations.Add(verticalAnnotation);
            chart.Annotations.Add(horizontalAnnotation);
            chart.Annotations.Add(lineAnnotation);
            return chart;
        }
    }
}