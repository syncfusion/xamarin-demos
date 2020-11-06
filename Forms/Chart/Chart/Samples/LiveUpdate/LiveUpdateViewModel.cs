#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace SampleBrowser.SfChart
{
	public class LiveUpdateViewModel
	{
        private bool canStopTimer;
        private int wave1;
        private int wave2 = 180;
        public ObservableCollection<ChartDataModel> liveData1 { get; set; }
		public ObservableCollection<ChartDataModel> liveData2 { get; set; }

		public LiveUpdateViewModel()
		{
			liveData1 = new ObservableCollection<ChartDataModel>();
			liveData2 = new ObservableCollection<ChartDataModel>();
		}
		

		public async void UpdateLiveData()
		{
			for (var i = 0; i < 180; i++)
			{
				liveData1.Add(new ChartDataModel(i, Math.Sin(wave1 * (Math.PI / 180.0))));
				wave1++;
			}

			for (var i = 0; i < 180; i++)
			{
				liveData2.Add(new ChartDataModel(i, Math.Sin(wave2 * (Math.PI / 180.0))));
				wave2++;
			}

			wave1 = liveData1.Count;

			await Task.Delay(200);

        }

        private bool UpdateData()
        {
            if (canStopTimer) return false;

            liveData1.RemoveAt(0);
            liveData1.Add(new ChartDataModel(wave1, Math.Sin(wave1 * (Math.PI / 180.0))));
           

            liveData2.RemoveAt(0);
            liveData2.Add(new ChartDataModel(wave1, Math.Sin(wave2 * (Math.PI / 180.0))));
            wave1++;
            wave2++;
            return true;
        }

        public void StopTimer()
        {
            canStopTimer = true;
        }

        public async void StartTimer()
        {
            await Task.Delay(500);
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 10), UpdateData);

            canStopTimer = false;
        }

    }
}