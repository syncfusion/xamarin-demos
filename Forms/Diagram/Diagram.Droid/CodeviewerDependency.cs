#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleBrowser;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Xamarin.Forms;
using System;

[assembly: Dependency(typeof(SampleBrowser.SfDiagram.Droid.Text))]
namespace SampleBrowser.SfDiagram.Droid
{
    class Text : IText
    {
        public object GetTextView(string name , float width)
        {
            TextView labelAnnotation = new TextView(Android.App.Application.Context);
            labelAnnotation.Text = name;
            labelAnnotation.SetTextSize(Android.Util.ComplexUnitType.Px, 14 * DiagramUtility.factor);
            labelAnnotation.Gravity = Android.Views.GravityFlags.Center;
            labelAnnotation.SetTextColor(Android.Graphics.Color.White);
            labelAnnotation.Typeface = Android.Graphics.Typeface.Create(".SF UI Text", Android.Graphics.TypefaceStyle.Normal);
            int widthMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(
                (int)width, Android.Views.MeasureSpecMode.AtMost);
            int heightMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(
            0, Android.Views.MeasureSpecMode.Unspecified);

            labelAnnotation.Measure(widthMeasureSpec, heightMeasureSpec);
            labelAnnotation.Left = labelAnnotation.Top = 0;
            labelAnnotation.Bottom = labelAnnotation.MeasuredHeight;
            labelAnnotation.Right = labelAnnotation.MeasuredWidth;

            return labelAnnotation;
        }

        public void GenerateFactor()
        {
            DiagramUtility.currentDensity = Android.App.Application.Context.Resources.DisplayMetrics.Density;
        }
    }
}