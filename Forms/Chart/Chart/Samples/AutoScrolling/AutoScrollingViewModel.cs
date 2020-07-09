#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public class AutoScrollingViewModel
	{
		DateTime time = new DateTime(2017, 01, 01);

		Random random = new Random();

		private int count;

		internal bool IsDisappear { get; set; }

		public ObservableCollection<ChartDataModel> data { get; set; }

		public AutoScrollingViewModel()
		{
			data = new ObservableCollection<ChartDataModel>();
			IsDisappear = false;
		}

		public void LoadData()
		{
			for (var i = 0; i < 2; i++)
			{
				data.Add(new ChartDataModel(time, random.Next(0, 100)));
				time = time.AddMilliseconds(500);
				count++;
			}
			count = data.Count;

		}

        public bool UpdateData()
        {
            if (IsDisappear) return false;

            data.Add(new ChartDataModel(time, random.Next(0, 100)));
            time = time.AddMilliseconds(500);
            count++;

            return true;
        }

	}
}
