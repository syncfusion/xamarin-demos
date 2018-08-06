#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServerMonitor.Views
{
    #region NetworkView

    public partial class NetworkView
    {
        #region Properties and fields

        SfChart chart;
        int i = 40;
        Random rand = new Random();

        #endregion

        #region Methods

        public NetworkView()
        {
            InitializeComponent();
            
            ObservableCollection<ChartDataPoint> pieDatas = new ObservableCollection<ChartDataPoint>();
            pieDatas.Add(new ChartDataPoint("54% Used", 54));
            pieDatas.Add(new ChartDataPoint("46% Free", 46));
            pieSeries.ItemsSource = pieDatas;

            if (Device.OS != TargetPlatform.iOS)
            {
                PieChart.Legend.LabelStyle.Font = Font.OfSize(null, 12);
            }

            if (Device.OS != TargetPlatform.iOS)
                series.Color = Color.FromHex("#FFB37300");
            series.ItemsSource = getData();
         }

        private ObservableCollection<ChartDataPoint> getData()
        {
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 18));
            datas.Add(new ChartDataPoint(2, 18));
            datas.Add(new ChartDataPoint(3, 46));
            datas.Add(new ChartDataPoint(4, 46));
            datas.Add(new ChartDataPoint(5, 36));
            datas.Add(new ChartDataPoint(6, 18));
            datas.Add(new ChartDataPoint(7, 18));
            datas.Add(new ChartDataPoint(8, 64));
            datas.Add(new ChartDataPoint(9, 56));
            datas.Add(new ChartDataPoint(10, 18));
            datas.Add(new ChartDataPoint(11, 18));
            datas.Add(new ChartDataPoint(12, 18));
            datas.Add(new ChartDataPoint(13, 46));
            datas.Add(new ChartDataPoint(14, 46));
            datas.Add(new ChartDataPoint(15, 56));
            datas.Add(new ChartDataPoint(16, 20));
            datas.Add(new ChartDataPoint(17, 20));
            datas.Add(new ChartDataPoint(18, 46));
            datas.Add(new ChartDataPoint(19, 56));
            datas.Add(new ChartDataPoint(20, 18));
            datas.Add(new ChartDataPoint(21, 18));
            datas.Add(new ChartDataPoint(22, 18));
            datas.Add(new ChartDataPoint(23, 34));
            datas.Add(new ChartDataPoint(24, 42));
            datas.Add(new ChartDataPoint(25, 56));
            datas.Add(new ChartDataPoint(26, 18));
            datas.Add(new ChartDataPoint(27, 18));
            datas.Add(new ChartDataPoint(28, 64));
            datas.Add(new ChartDataPoint(29, 56));
            datas.Add(new ChartDataPoint(30, 18));
            datas.Add(new ChartDataPoint(31, 15));
            datas.Add(new ChartDataPoint(32, 25));
            datas.Add(new ChartDataPoint(33, 42));
            datas.Add(new ChartDataPoint(34, 32));
            datas.Add(new ChartDataPoint(35, 56));
            datas.Add(new ChartDataPoint(36, 30));
            datas.Add(new ChartDataPoint(37, 20));
            datas.Add(new ChartDataPoint(38, 42));
            datas.Add(new ChartDataPoint(39, 36));
            datas.Add(new ChartDataPoint(40, 18));
            if (Device.OS ==TargetPlatform.WinPhone)
                StartUpdate();
            else
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 30), AddData);
            return datas;
        }
        async private void StartUpdate()
        {
            await Task.Delay(1500);
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 30), AddData);
        }
        private bool AddData()
        {
            i = i + 1;
            (Chart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            (Chart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i,DataGenerator.DownLoadRate));
            return true;
        }

        #endregion

    }

    #endregion
}