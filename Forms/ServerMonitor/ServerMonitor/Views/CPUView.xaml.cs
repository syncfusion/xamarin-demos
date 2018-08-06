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
    #region CPUView

    public partial class CPUView
    {

        # region Properties and Fields

        int i = 40;

        Random rand = new Random();

        # endregion

        # region Methods

        public CPUView()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.iOS)
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
            pointer.LengthFactor = Device.OnPlatform(1, 1, 1);
            pointer.Color = Color.FromRgb(226, 226, 226);
            pointer.KnobColor = Color.FromRgb(226, 226, 226);
            RangePointer rPointer = new RangePointer();
            rPointer.Value = 70;
            if (Device.OS == TargetPlatform.Windows)
                rPointer.Offset = 1;
            rPointer.Color = Color.FromHex("#FFF47F30");
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
            ObservableCollection<ChartDataPoint>  datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 34));
            datas.Add(new ChartDataPoint(2, 24));
            datas.Add(new ChartDataPoint(3, 19));
            datas.Add(new ChartDataPoint(4, 21));
            datas.Add(new ChartDataPoint(5, 25));
            datas.Add(new ChartDataPoint(6, 15));
            datas.Add(new ChartDataPoint(7, 34));
            datas.Add(new ChartDataPoint(8, 24));
            datas.Add(new ChartDataPoint(9, 19));
            datas.Add(new ChartDataPoint(10, 21));
            datas.Add(new ChartDataPoint(11, 25));
            datas.Add(new ChartDataPoint(12, 76));
            datas.Add(new ChartDataPoint(13, 34));
            datas.Add(new ChartDataPoint(14, 24));
            datas.Add(new ChartDataPoint(15, 19));
            datas.Add(new ChartDataPoint(16, 21));
            datas.Add(new ChartDataPoint(17, 25));
            datas.Add(new ChartDataPoint(18, 32));
            datas.Add(new ChartDataPoint(19, 15));
            datas.Add(new ChartDataPoint(20, 32));
            datas.Add(new ChartDataPoint(21, 25));
            datas.Add(new ChartDataPoint(22, 32));
            datas.Add(new ChartDataPoint(23, 34));
            datas.Add(new ChartDataPoint(24, 24));
            datas.Add(new ChartDataPoint(25, 19));
            datas.Add(new ChartDataPoint(26, 21));
            datas.Add(new ChartDataPoint(27, 25));
            datas.Add(new ChartDataPoint(28, 32));
            datas.Add(new ChartDataPoint(29, 25));
            datas.Add(new ChartDataPoint(30, 32));
            datas.Add(new ChartDataPoint(31, 74));
            datas.Add(new ChartDataPoint(32, 32));
            datas.Add(new ChartDataPoint(33, 34));
            datas.Add(new ChartDataPoint(34, 24));
            datas.Add(new ChartDataPoint(35, 19));
            datas.Add(new ChartDataPoint(36, 21));
            datas.Add(new ChartDataPoint(37, 25));
            datas.Add(new ChartDataPoint(38, 32));
            datas.Add(new ChartDataPoint(39, 25));
            datas.Add(new ChartDataPoint(40, 32));
            return datas;
        }

		//Gauge Rendering Issue fixed. Timer will be activated after view loaded
		protected override void OnAppearing()
		{      
			Device.StartTimer(new TimeSpan(0, 0, 0, 0, 300), AddData);
		}

        private bool AddData()
        {    
            i+= 2;
            circularGauge.Scales[0].Pointers[0].Value = DataGenerator.CPUUnits;
            circularGauge.Scales[0].Pointers[1].Value = DataGenerator.CPUUnits;
            (Chart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            (Chart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, DataGenerator.CPUUnits));
            return true;
        }

        #endregion

    }
    #endregion
}
