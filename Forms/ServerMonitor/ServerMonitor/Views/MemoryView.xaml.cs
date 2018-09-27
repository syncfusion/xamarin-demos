#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServerMonitor.Views
{
    #region MemoryView

    public partial class MemoryView
    {
        #region Properties and Fields

        int i = 40;

        Random rand = new Random();

        #endregion

        #region Methods

        public MemoryView()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                this.circularGauge.HeightRequest = 200;
            }
            else
            {
                circularGauge.VerticalOptions = LayoutOptions.FillAndExpand;
            }

            ObservableCollection<Scale> Scales = new ObservableCollection<Scale>();
            Scale scale = new Scale();
            scale.StartValue = 0;
            scale.EndValue = 100;
            scale.StartAngle = 180;
            scale.SweepAngle = 180;
            scale.RimThickness = 40;
            scale.RimColor = Color.FromRgb(86, 86, 86);
            NeedlePointer pointer = new NeedlePointer();
            pointer.Value = 70;
            pointer.Thickness = 5;
            pointer.KnobRadius = 20;
            pointer.LengthFactor = 1;
            pointer.Color = Color.FromRgb(226, 226, 226);
            pointer.KnobColor = Color.FromHex("#FFE2E2E2");
            RangePointer rPointer = new RangePointer();
            rPointer.Value = 70;
            if (Device.RuntimePlatform == Device.UWP)
                rPointer.Offset = 1;
            rPointer.Color = Color.FromHex("#FF00B2DB");
            rPointer.Thickness = 40;
            ObservableCollection<Pointer> pointers = new ObservableCollection<Pointer>();
            pointers.Add(pointer);
            pointers.Add(rPointer);
            scale.Pointers = pointers;
            scale.ShowTicks = false;
            scale.ShowLabels = false;
            Scales.Add(scale);
            circularGauge.Scales = Scales;
            

            series.ItemsSource = getData();
        }

        private ObservableCollection<ChartDataPoint> getData()
        {
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 59));
            datas.Add(new ChartDataPoint(2, 59));
            datas.Add(new ChartDataPoint(3, 59));
            datas.Add(new ChartDataPoint(4, 59));
            datas.Add(new ChartDataPoint(5, 59));
            datas.Add(new ChartDataPoint(6, 59));
            datas.Add(new ChartDataPoint(7, 60));
            datas.Add(new ChartDataPoint(8, 59));
            datas.Add(new ChartDataPoint(9, 56));
            datas.Add(new ChartDataPoint(10, 56));
            datas.Add(new ChartDataPoint(11, 56));
            datas.Add(new ChartDataPoint(12, 56));
            datas.Add(new ChartDataPoint(13, 56));
            datas.Add(new ChartDataPoint(14, 59));
            datas.Add(new ChartDataPoint(15, 59));
            datas.Add(new ChartDataPoint(16, 59));
            datas.Add(new ChartDataPoint(17, 59));
            datas.Add(new ChartDataPoint(18, 59));
            datas.Add(new ChartDataPoint(19, 59));
            datas.Add(new ChartDataPoint(20, 59));
            datas.Add(new ChartDataPoint(21, 59));
            datas.Add(new ChartDataPoint(22, 59));
            datas.Add(new ChartDataPoint(23, 59));
            datas.Add(new ChartDataPoint(24, 59));
            datas.Add(new ChartDataPoint(25, 58));
            datas.Add(new ChartDataPoint(26, 58));
            datas.Add(new ChartDataPoint(27, 58));
            datas.Add(new ChartDataPoint(28, 58));
            datas.Add(new ChartDataPoint(29, 58));
            datas.Add(new ChartDataPoint(30, 59));
            datas.Add(new ChartDataPoint(31, 59));
            datas.Add(new ChartDataPoint(32, 59));
            datas.Add(new ChartDataPoint(33, 59));
            datas.Add(new ChartDataPoint(34, 55));
            datas.Add(new ChartDataPoint(35, 55));
            datas.Add(new ChartDataPoint(36, 55));
            datas.Add(new ChartDataPoint(37, 55));
            datas.Add(new ChartDataPoint(38, 59));
            datas.Add(new ChartDataPoint(39, 62));
            datas.Add(new ChartDataPoint(40, 62));
            return datas;
        }

		//Gauge Rendering Issue fixed. Timer will be activated after view loaded
		protected override void OnAppearing()
		{             
		    Device.StartTimer(new TimeSpan(0, 0, 0, 0, 300), AddData);
		}
        
        private bool AddData()
        {
            var MemoryValue = DataGenerator.MemoryUnits;
			i+= 2;
            circularGauge.Scales[0].Pointers[0].Value = DataGenerator.CPUUnits;
            circularGauge.Scales[0].Pointers[1].Value = DataGenerator.CPUUnits;
            (Chart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            (Chart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, MemoryValue));
            return true;
        }

        #endregion

    }

    #endregion
}
