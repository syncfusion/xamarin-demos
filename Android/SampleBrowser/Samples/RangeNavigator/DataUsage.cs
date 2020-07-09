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
using Com.Syncfusion.Rangenavigator;
using Android.Graphics;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Java.Util;
using Android.Util;
using Java.Text;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class DataUsage : SamplePage
    {
        List<DataPoint> dataPoints;

        TextView dataRangeText;

        TextView dataUsageText;

        public override View GetSampleContent(Context context)
        {
            LayoutInflater layoutInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View view = layoutInflater.Inflate(Resource.Layout.range_navigator_data_usage, null);

            CustomRangeNavigator sfRangeNavigator = view.FindViewById<CustomRangeNavigator>(Resource.Id.range_navigator_datausage);

            dataRangeText = view.FindViewById<TextView>(Resource.Id.date_time_range_text);

            dataUsageText = view.FindViewById<TextView>(Resource.Id.date_time_usage_mb);

            sfRangeNavigator.SetMinimumHeight(100);
            SfChart rangeNavigatorContent = new SfChart(context);

            sfRangeNavigator.Intervals = Com.Syncfusion.Rangenavigator.DateTimeIntervalType.Month | Com.Syncfusion.Rangenavigator.DateTimeIntervalType.Week;

            Calendar min = new GregorianCalendar(2015, 0, 1);
            Calendar max = new GregorianCalendar(2015, 4, 1);

            Calendar rangeStart = new GregorianCalendar(2015, 1, 13);
            Calendar rangeEnd = new GregorianCalendar(2015, 2, 13);

            sfRangeNavigator.Minimum = min.Time;
            sfRangeNavigator.Maximum = max.Time;

            sfRangeNavigator.ViewRangeStart = rangeStart.Time;
            sfRangeNavigator.ViewRangeEnd = rangeEnd.Time;

            sfRangeNavigator.TooltipEnabled = false;

            UpdateChart(rangeNavigatorContent, Visibility.Gone);

            sfRangeNavigator.Content = rangeNavigatorContent;

            sfRangeNavigator.SetClipChildren(false);

            dataRangeText.SetPadding(5, 20, 5, 5);
            dataUsageText.SetPadding(5, 5, 5, 5);

            sfRangeNavigator.RangeChanged += SfRangeNavigator_RangeChanged;
            sfRangeNavigator.MinorScaleLabelsCreate += SfRangeNavigator_LabelsGenerated;
            sfRangeNavigator.MinorScaleStyle.ShowGridLines = false;

            sfRangeNavigator.MajorScaleStyle.SelectedLabelTextColor = Color.ParseColor("#1cb2d5");
            sfRangeNavigator.MajorScaleStyle.LabelTextColor = Color.ParseColor("#5f6872");

            return view;
        }

        void SfRangeNavigator_LabelsGenerated(object sender, SfDateTimeRangeNavigator.MinorScaleLabelsCreateEventArgs e)
        {
            e.MinorScaleLabels.Clear();
        }

        void SfRangeNavigator_RangeChanged(object sender, SfDateTimeRangeNavigator.RangeChangedEventArgs e)
        {
            dataRangeText.Text = "Data usage cycle " + new SimpleDateFormat("MMM dd").Format(e.ViewRangeStart) + " - " + new SimpleDateFormat("MMM dd").Format(e.ViewRangeEnd);

            DateTime minimum = ConvertToDateTime(e.ViewRangeStart);
            DateTime maximum = ConvertToDateTime(e.ViewRangeEnd);

            double dataUsage = 0;

            for (int i = 0; i < dataPoints.Count; i++)
            {
                DataPoint chartDataPoint = (DataPoint)dataPoints[i];

				DateTime ChartDate = (DateTime)chartDataPoint.Date;

                if (ChartDate > minimum && ChartDate < maximum)
                {
                    dataUsage = dataUsage + (Double)chartDataPoint.YValue;
                }
            }
            dataUsageText.Text = "Date Usage " + (int)dataUsage + " MB";
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
                ItemsSource = GetDateTimeValue(),
                XBindingPath = "Date",
                YBindingPath = "YValue",
                Alpha = 0.5f,
                Color = Color.ParseColor("#7ce6c7"),
                StrokeColor = Color.ParseColor("#1cb2d5")
            });

            return chart;
        }

        public List<DataPoint> GetDateTimeValue()
        {
            var dateTime = new DateTime(2015, 1, 1);
            dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint(dateTime, 10d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 31d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 28d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 45d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 10d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 23d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 35d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 56d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 10d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 39d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 26d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 21d));
            dateTime = dateTime.AddMonths(1);
            dataPoints.Add(new DataPoint(dateTime, 31d));
            return dataPoints;
        }

        public static DateTime ConvertToDateTime(object date)
        {
            if (date == null) return DateTime.Now;
            var nativeDate = (Java.Util.Date)date;
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddMilliseconds(((Java.Util.Date)date).Time).ToLocalTime();
        }
    }
}