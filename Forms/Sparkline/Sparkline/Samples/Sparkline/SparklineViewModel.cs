#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSparkline
{
    [Preserve(AllMembers = true)]
    public class SparkViewModel
	{
		public ObservableCollection<SparklineModel> Datas
		{
			get;
			set;
		}

		public ObservableCollection<SparklineModel> ColumnDatas
		{
			get;
			set;
		}
		public SparkViewModel()
		{
			Datas = new ObservableCollection<SparklineModel>();

			ColumnDatas = new ObservableCollection<SparklineModel>();

			Datas.Add(new SparklineModel { Performance = 10 });
			Datas.Add(new SparklineModel { Performance = 30 });
			Datas.Add(new SparklineModel { Performance = 25 });
			Datas.Add(new SparklineModel { Performance = 95 });
			Datas.Add(new SparklineModel { Performance = 190 });
			Datas.Add(new SparklineModel { Performance = 40 });
			Datas.Add(new SparklineModel { Performance = 60 });
			Datas.Add(new SparklineModel { Performance = 50 });
			Datas.Add(new SparklineModel { Performance = 35 });
			Datas.Add(new SparklineModel { Performance = 20 });

			ColumnDatas.Add(new SparklineModel { YearPerformance = 20 });
			ColumnDatas.Add(new SparklineModel { YearPerformance = 10 });
			ColumnDatas.Add(new SparklineModel { YearPerformance = -30 });
			ColumnDatas.Add(new SparklineModel { YearPerformance = 60 });
			ColumnDatas.Add(new SparklineModel { YearPerformance = 10 });
			ColumnDatas.Add(new SparklineModel { YearPerformance = 20 });
		}
	}
}