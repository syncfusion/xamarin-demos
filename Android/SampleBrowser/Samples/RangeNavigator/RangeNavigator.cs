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
using Com.Syncfusion.Charts.Enums;
using Com.Syncfusion.Rangenavigator;
using Java.Util;


namespace SampleBrowser
{
    public class RangeNavigator : SamplePage
    {
        SfChart chartTop;

        public override View GetSampleContent(Context context)
        {
            LayoutInflater layoutInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View view = layoutInflater.Inflate(Resource.Layout.range_navigator_getting_Started, null);

            chartTop = view.FindViewById<SfChart>(Resource.Id.TopChart);
            UpdateChart(chartTop, Visibility.Visible);

            SfDateTimeRangeNavigator sfRangeNavigator = view.FindViewById<SfDateTimeRangeNavigator>(Resource.Id.RangeNavigator);

            Calendar min = new GregorianCalendar(2015, 0, 1);
            Calendar max = new GregorianCalendar(2015, 11, 31);

            sfRangeNavigator.Minimum = min.Time;
            sfRangeNavigator.Maximum = max.Time;

            Calendar visibleMinimum = new GregorianCalendar(2015, 4, 1);
            Calendar visibleMaximum = new GregorianCalendar(2015, 7, 1);

            sfRangeNavigator.ViewRangeStart = visibleMinimum.Time;
            sfRangeNavigator.ViewRangeEnd = visibleMaximum.Time;

            View contentView = sfRangeNavigator.Content;

            SfChart sfchart = new SfChart(context) { PrimaryAxis = new DateTimeAxis() { Visibility = Visibility.Gone, ShowMajorGridLines = false }, SecondaryAxis = new NumericalAxis() { Visibility = Visibility.Gone, ShowMajorGridLines = false } };

            sfchart.Series.Add(new SplineAreaSeries()
            {
                ItemsSource = MainPage.GetDateTimeValue(),
                XBindingPath = "Date",
                YBindingPath = "YValue",
                Alpha = 0.5f
            });

            sfRangeNavigator.Content = sfchart;

            sfRangeNavigator.RangeChanged += sfRangeNavigator_RangeChanged;

            return view;
        }

        void sfRangeNavigator_RangeChanged(object sender, SfDateTimeRangeNavigator.RangeChangedEventArgs e)
        {
            ((DateTimeAxis)chartTop.PrimaryAxis).Minimum = e.ViewRangeStart;
            ((DateTimeAxis)chartTop.PrimaryAxis).Maximum = e.ViewRangeEnd;
        }

        SfChart UpdateChart(SfChart chart, Visibility axisVisibility)
        {
            DateTimeAxis dateTimeAxis = new DateTimeAxis();
            dateTimeAxis.Visibility = axisVisibility;
            dateTimeAxis.LabelStyle.LabelFormat = "dd/MMM";
            dateTimeAxis.ShowMajorGridLines = axisVisibility == Visibility.Visible ? true : false;
            chart.PrimaryAxis = dateTimeAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Visibility = axisVisibility;
            numericalAxis.ShowMajorGridLines = axisVisibility == Visibility.Visible ? true : false;
            chart.SecondaryAxis = numericalAxis;

            chart.Series.Add(new SplineAreaSeries()
            {
                ItemsSource = MainPage.GetDateTimeValue(),
                XBindingPath = "Date",
                YBindingPath = "YValue",
                Alpha = 0.5f
            });

            return chart;
        }
    }
}