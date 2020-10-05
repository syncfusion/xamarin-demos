#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Java.Util;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class AutoScrolling : SamplePage
    {
        private readonly ObservableCollection<DataPoint> data = new ObservableCollection<DataPoint>();

        private int count;

        private System.Random random;

        private SfChart chart;

        public override View GetSampleContent(Context context)
        {
            random = new System.Random();
            LoadData();

            chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new DateTimeAxis { AutoScrollingDelta = 5, AutoScrollingDeltaType = DateTimeDeltaType.Seconds };
            chart.PrimaryAxis.LabelStyle.LabelFormat = "HH:mm:ss";
            
            var axis = new NumericalAxis {Minimum = 0, Maximum = 100};
            chart.SecondaryAxis = axis;

            var columnSeries = new ColumnSeries { ItemsSource = data };
			columnSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
			columnSeries.XBindingPath = "Date";
			columnSeries.YBindingPath = "YValue";
            chart.Series.Add(columnSeries);

            chart.Behaviors.Add(new ChartZoomPanBehavior {ScrollingEnabled = true, ZoomingEnabled = false});
            
            UpdateData();

            var label = new TextView(context);
            label.SetPadding(5, 5, 5, 5);
            label.Text = "In this demo, a data point is being added every 500 milliseconds." +
                         " The Chart is then automatically scrolled to display the fixed range of data points at the end." +
                         " You can also pan to view previous data points. In this sample the delta value is 5 seconds.";

            var layout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };

            var layoutLabel = new LinearLayout(context)
            {
                Orientation = Android.Widget.Orientation.Horizontal,
                LayoutParameters =
                    new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            layoutLabel.SetHorizontalGravity(GravityFlags.CenterHorizontal);
            layoutLabel.AddView(label);

            layout.AddView(layoutLabel);
            layout.AddView(chart);
            return layout;
        }

       DateTime dateTime = DateTime.Now;

        private void LoadData()
        {
            for (var i = 0; i < 2; i++)
            {
                data.Add(new DataPoint(dateTime, random.Next(0, 100)));
                dateTime = dateTime.AddMilliseconds(500);
                count++;
            }
            count = data.Count;
        }

        private async void UpdateData()
        {
            while (true)
            {
                await Task.Delay(500);
              
                data.Add(new DataPoint(dateTime, random.Next(0, 100)));
                dateTime = dateTime.AddMilliseconds(500);
                count++;
            }
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }
    }
}