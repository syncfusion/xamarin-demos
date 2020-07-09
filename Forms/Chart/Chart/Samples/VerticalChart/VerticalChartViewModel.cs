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
	public class VerticalChartViewModel
	{
		public ObservableCollection<ChartDataModel> verticalChart { get; set; }

		private int count;
        private int index;

        public VerticalChartViewModel()
		{
			verticalChart = new ObservableCollection<ChartDataModel>();			
		}

        public void LoadVerticalData()
		{
			Random rand = new Random();
			for (int j = 11; j < 50; j++)
			{
				verticalChart.Add(new ChartDataModel(j, rand.Next(-3, 3)));
			}

			index = (int)verticalChart[verticalChart.Count - 1].Value + 1;
		}

        private bool UpdateData()
        {
            count = count + 1;

            Random random = new Random();
            if (count > 350)
            {
                return false;
            }
            else if (count > 300)
            {
                verticalChart.Add(new ChartDataModel(index, random.Next(0, 0)));
            }
            else if (count > 250)
            {
                verticalChart.Add(new ChartDataModel(index, random.Next(-2, 1)));
            }
            else if (count > 180)
            {
                verticalChart.Add(new ChartDataModel(index, random.Next(-3, 2)));
            }
            else if (count > 100)
            {
                verticalChart.Add(new ChartDataModel(index, random.Next(-7, 6)));
            }
            else
            {
                verticalChart.Add(new ChartDataModel(index, random.Next(-9, 9)));
            }
            index++;
            return true;
        }

        public async void StartTimer()
        {
            await Task.Delay(500);
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 10), UpdateData);
        }

    }
}
