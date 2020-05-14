#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Foundation;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class ChartViewModel
	{
		DateTime time = new DateTime(2015, 01, 01);

		DateTime dataTime = new DateTime(2015, 01, 1);

		Random random = new Random();

		DateTime date = new DateTime();

		public int wave1 = 0;

		public int wave2 = 180;

		public int verticalCount;

		public ObservableCollection<ChartDataModel> PolarData1 { get; set; }

		public ObservableCollection<ChartDataModel> DataMarkerData { get; set; }

		public ObservableCollection<ChartDataModel> PolarData2 { get; set; }

		public ObservableCollection<ChartDataModel> PolarData3 { get; set; }

		public ObservableCollection<ChartDataModel> AreaData { get; set; }

		public ObservableCollection<ChartDataModel> AreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> AreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> AreaData3 { get; set; }

		public ObservableCollection<ChartDataModel> StepAreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> StepAreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> LineData { get; set; }

		public ObservableCollection<ChartDataModel> LineData1 { get; set; }

		public ObservableCollection<ChartDataModel> LineData2 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData1 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData2 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData3 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData3 { get; set; }

		public ObservableCollection<ChartDataModel> BarData1 { get; set; }

		public ObservableCollection<ChartDataModel> BarData2 { get; set; }

		public ObservableCollection<ChartDataModel> SplineData1 { get; set; }

		public ObservableCollection<ChartDataModel> SplineData2 { get; set; }

		public ObservableCollection<ChartDataModel> SplineAreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> SplineAreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> SplineAreaData3 { get; set; }

		public ObservableCollection<ChartDataModel> RangeColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> RangeColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> RangeAreaData { get; set; }

		public ObservableCollection<ChartDataModel> RangeAreaData1 { get; set; }

        public ObservableCollection<ChartDataModel> RangeBarData { get; set; }

        public ObservableCollection<ChartDataModel> PieSeriesData { get; set; }

		public ObservableCollection<ChartDataModel> SemiCircularData { get; set; }

		public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }

		public ObservableCollection<ChartDataModel> PyramidData { get; set; }

		public ObservableCollection<ChartDataModel> FunnelData { get; set; }

		public ObservableCollection<ChartDataModel> StackedBarData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBarData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBarData3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBar100Data1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBar100Data2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBar100Data3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBar100Data4 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData4 { get; set; }

		public ObservableCollection<ChartDataModel> StackedAreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedAreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedAreaData3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedAreaData4 { get; set; }

		public ObservableCollection<ChartDataModel> StackedArea100Data1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedArea100Data2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedArea100Data3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedArea100Data4 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData { get; set; }

		public ObservableCollection<ChartDataModel> CircularData { get; set; }

		public ObservableCollection<ChartDataModel> MultipleAxisData { get; set; }

		public ObservableCollection<ChartDataModel> MultipleAxisData1 { get; set; }

		public ObservableCollection<ChartDataModel> BubbleData { get; set; }

		public ObservableCollection<ChartDataModel> ScatterData { get; set; }

		public ObservableCollection<ChartDataModel> ScatterDataZoomPan
		{
			get
			{
				var items = new ObservableCollection<ChartDataModel>();

				for (int i = 0; i < 300; i++)
				{
					double x = random.NextDouble() * 100;
					double y = random.NextDouble() * 500;
					double randomDouble = random.NextDouble();
					if (randomDouble >= .25 && randomDouble < .5)
					{
						x *= -1;
					}
					else if (randomDouble >= .5 && randomDouble < .75)
					{
						y *= -1;
					}
					else if (randomDouble > .75)
					{
						x *= -1;
						y *= -1;
					}
					items.Add(new ChartDataModel(300 + (x * (random.NextDouble() + 0.12)),
								100 + (y * (random.NextDouble() + 0.12))));
				}
				return items;
			}
		}

		public ObservableCollection<ChartDataModel> Data1 { get; set; }

		public ObservableCollection<ChartDataModel> Data2 { get; set; }

		public ObservableCollection<ChartDataModel> datas1 { get; set; }

		public ObservableCollection<ChartDataModel> Data3 { get; set; }

		public ObservableCollection<ChartDataModel> CategoryData { get; set; }

		public ObservableCollection<ChartDataModel> LogarithmicData { get; set; }

		public ObservableCollection<ChartDataModel> RangeColumnData { get; set; }

		public ObservableCollection<ChartDataModel> FinancialData { get; set; }

		public ObservableCollection<ChartDataModel> NumericData { get; set; }

		public ObservableCollection<ChartDataModel> DateTimeAxisData
		{
			get
			{
				var dateTime = new DateTime(2017, 1, 1);

				var datas = new ObservableCollection<ChartDataModel>();

				System.Random random = new System.Random();
				double value = 100;

				for (int i = 0; i < 365; i++)
				{
					if (random.NextDouble() > 0.5)

						value += random.NextDouble();
					else
						value -= random.NextDouble();
					datas.Add(new ChartDataModel(dateTime, value));
					dateTime = dateTime.AddDays(1);
				}

				return datas;
			}
		}

		public ObservableCollection<ChartDataModel> GradientData
		{
			get
			{
				DateTime date = new DateTime(2017, 5, 1);

				ObservableCollection<ChartDataModel> gradientData = new ObservableCollection<ChartDataModel>();

				gradientData.Add(new ChartDataModel(date, 29));
				gradientData.Add(new ChartDataModel(date.AddDays(6), 33));
				gradientData.Add(new ChartDataModel(date.AddDays(15), 24));
				gradientData.Add(new ChartDataModel(date.AddDays(23), 28));
				gradientData.Add(new ChartDataModel(date.AddDays(30), 26));
				gradientData.Add(new ChartDataModel(date.AddDays(39), 38));
				gradientData.Add(new ChartDataModel(date.AddDays(50), 32));

				return gradientData;
			}
		}

		public ObservableCollection<ChartDataModel> DateTimeData { get; set; }

		public ObservableCollection<ChartDataModel> SelectionData { get; set; }

		public ObservableCollection<ChartDataModel> data { get; set; }

		public ObservableCollection<ChartDataModel> liveData1 
		{
			get
			{
				var items = new ObservableCollection<ChartDataModel>();

				for (var i = 0; i <= 180; i++)
				{
					items.Add(new ChartDataModel(i, Math.Sin(wave1 * (Math.PI / 180.0))));
					wave1++;
				}
				return items;
			}
		}

		public ObservableCollection<ChartDataModel> liveData2 
		{
			get
			{
				var items = new ObservableCollection<ChartDataModel>();

				for (var i = 0; i <= 180; i++)
				{
					items.Add(new ChartDataModel(i, Math.Sin(wave2 * (Math.PI / 180.0))));
					wave2++;
				}
				return items;
			}
		}

		public ObservableCollection<ChartDataModel> verticalData 
		{
			get
			{
				var items = new ObservableCollection<ChartDataModel>();

				date = new DateTime(2011,3,11,14,46,0);

				for (int i = 0; i < 30; i++)
				{
					var verData = dataPointWithTimeInterval(0.15);
					items.Add(new ChartDataModel(verData.XValue, verData.YValue));
					verticalCount = items.Count;
				}

				return items;
			}
		}

		public ObservableCollection<ChartDataModel> PieData { get; set; }

		public ObservableCollection<ChartDataModel> StripLineData { get; set; }

		public ObservableCollection<ChartDataModel> MultipleSeriesData1 { get; set; }

		public ObservableCollection<ChartDataModel> MultipleSeriesData2 { get; set; }

		public ObservableCollection<ChartDataModel> LineSeries1 { get; set; }

		public ObservableCollection<ChartDataModel> LineSeries2 { get; set; }

		public ObservableCollection<ChartDataModel> LineSeries3 { get; set; }

		public ObservableCollection<ChartDataModel> TriangularData { get; set; }

		public ObservableCollection<ChartDataModel> TooltipData { get; set; }

		public ObservableCollection<ChartDataModel> DateTimeRangeData { get; set; }

		public ObservableCollection<ChartDataModel> DateUsageData { get; set; }

		public ObservableCollection<ChartDataModel> TechnicalIndicatorData { get; set; }

        public ObservableCollection<ChartDataModel> AxisCrossingData { get; set; }



		public ChartViewModel()
		{
			DateTime calendar = new DateTime(2000, 1, 1);

			DateTime dt = new DateTime(2000, 1, 1);

            AxisCrossingData = new ObservableCollection<ChartDataModel>()
            {
                new ChartDataModel{XValue = "2000",YValue = 70, Size = 5},
                new ChartDataModel{XValue = "2001",YValue = 50, Size = 8},
                new ChartDataModel{XValue = "2002",YValue = -30, Size = 30},
                new ChartDataModel{XValue = "2003",YValue = -70, Size = 10},
                new ChartDataModel{XValue = "2004",YValue = 40, Size = 12},
                new ChartDataModel{XValue = "2005",YValue = 80, Size = 13},
                new ChartDataModel{XValue = "2006",YValue = -70, Size = 6},
                new ChartDataModel{XValue = "2007",YValue = 30, Size = 8},
                new ChartDataModel{XValue = "2008",YValue = 80, Size = 3},
                new ChartDataModel{XValue = "2009",YValue = -30, Size = 5},
                new ChartDataModel{XValue = "2010",YValue = -80, Size = 7},
                new ChartDataModel{XValue = "2011",YValue = 40, Size = 3},
                new ChartDataModel{XValue = "2012",YValue = -50, Size = 8},
                new ChartDataModel{XValue = "2013",YValue = -10, Size = 4},
                new ChartDataModel{XValue = "2014",YValue = -80, Size = 9},
                new ChartDataModel{XValue = "2015",YValue = 40, Size = 10},
                new ChartDataModel{XValue = "2016",YValue = -50, Size = 6},

            };
 
			TechnicalIndicatorData = new ObservableCollection<ChartDataModel>
		   {
			new ChartDataModel(calendar.AddMonths(1), 65.75, 67.27, 65.75, 65.98, 7938200),
			new ChartDataModel(calendar.AddMonths(2), 65.98, 65.70, 65.04, 65.11, 10185300),
			new ChartDataModel(calendar.AddMonths(3), 65.11, 65.05, 64.26, 64.97, 10835800),
			new ChartDataModel(calendar.AddMonths(4), 64.97, 65.16, 64.09, 64.29, 9613400),
			new ChartDataModel(calendar.AddMonths(5), 64.29, 62.73, 61.85, 62.44, 17175000),
			new ChartDataModel(calendar.AddMonths(6), 62.44, 62.02, 61.29, 61.47, 18040600),
			new ChartDataModel(calendar.AddMonths(7), 61.47, 62.75, 61.55, 61.59, 13456300),
			new ChartDataModel(calendar.AddMonths(8), 61.59, 64.78, 62.22, 64.64, 8045100),
			new ChartDataModel(calendar.AddMonths(9), 64.64, 64.50, 63.03, 63.28, 8608900),
			new ChartDataModel(calendar.AddMonths(10), 63.28, 63.70, 62.70, 63.59, 15025500),
			new ChartDataModel(calendar.AddMonths(11), 63.59, 64.45, 63.26, 63.61, 10065800),
			new ChartDataModel(calendar.AddMonths(12), 63.61, 64.56, 63.81, 64.52, 6178200),
			new ChartDataModel(calendar.AddMonths(13), 64.52, 64.84, 63.66, 63.91, 5478500),
			new ChartDataModel(calendar.AddMonths(14), 63.91, 65.30, 64.50, 65.22, 7964300),
			new ChartDataModel(calendar.AddMonths(15), 65.22, 65.36, 64.46, 65.06, 5679300),
			new ChartDataModel(calendar.AddMonths(16), 65.06, 64.54, 63.56, 63.65, 10758300),
			new ChartDataModel(calendar.AddMonths(17), 63.65, 64.03, 63.33, 63.73, 5665900),
			new ChartDataModel(calendar.AddMonths(18), 63.73, 63.40, 62.80, 62.83, 5833000),
			new ChartDataModel(calendar.AddMonths(19), 62.83, 63.75, 62.96, 63.60, 3500800),
			new ChartDataModel(calendar.AddMonths(20), 63.6, 63.64, 62.51, 63.51, 5044700),
			new ChartDataModel(calendar.AddMonths(21), 63.51, 64.03, 63.53, 63.76, 4871300),
			new ChartDataModel(calendar.AddMonths(22), 63.76, 63.77, 63.01, 63.65, 7040400),
			new ChartDataModel(calendar.AddMonths(23), 63.65, 63.95, 63.58, 63.79, 4727800),
			new ChartDataModel(calendar.AddMonths(24), 63.79, 63.47, 62.92, 63.25, 6334900),
			new ChartDataModel(calendar.AddMonths(25), 63.25, 63.96, 63.21, 63.48, 6823200),
			new ChartDataModel(calendar.AddMonths(26), 63.48, 63.63, 62.55, 63.50, 9718400),
			new ChartDataModel(calendar.AddMonths(27), 63.5, 63.25, 62.82, 62.90, 2827000),
			new ChartDataModel(calendar.AddMonths(28), 62.9, 62.34, 62.05, 62.18, 4942700),
			new ChartDataModel(calendar.AddMonths(29), 62.18, 62.86, 61.94, 62.81, 4582800),
			new ChartDataModel(calendar.AddMonths(30), 62.81, 63.06, 62.44, 62.83, 12423900),
			new ChartDataModel(calendar.AddMonths(31), 62.83, 63.16, 62.66, 63.09, 4940500),
			new ChartDataModel(calendar.AddMonths(32), 63.09, 62.89, 62.43, 62.66, 6132300),
			new ChartDataModel(calendar.AddMonths(33), 62.66, 62.39, 61.90, 62.25, 6263800),
			new ChartDataModel(calendar.AddMonths(34), 62.25, 61.69, 60.97, 61.50, 5008300),
			new ChartDataModel(calendar.AddMonths(35), 61.5, 61.87, 61.18, 61.79, 6662500),
			new ChartDataModel(calendar.AddMonths(36), 61.79, 63.41, 62.72, 63.16, 5254000),
			new ChartDataModel(calendar.AddMonths(37), 63.16, 64.40, 63.65, 63.89, 5356600),
			new ChartDataModel(calendar.AddMonths(38), 63.89, 63.45, 61.60, 61.87, 5052600),
			new ChartDataModel(calendar.AddMonths(39), 61.87, 62.35, 61.30, 61.54, 6266700),
			new ChartDataModel(calendar.AddMonths(40), 61.54, 61.49, 60.33, 61.06, 6190800),
			new ChartDataModel(calendar.AddMonths(41), 61.06, 60.78, 59.84, 60.09, 6452300),
			new ChartDataModel(calendar.AddMonths(42), 60.09, 59.62, 58.62, 58.80, 5954000),
			new ChartDataModel(calendar.AddMonths(43), 58.8, 59.60, 58.89, 59.53, 6250000),
			new ChartDataModel(calendar.AddMonths(44), 59.53, 60.96, 59.42, 60.68, 5307300),
			new ChartDataModel(calendar.AddMonths(45), 60.68, 61.12, 60.65, 60.73, 6192900),
			new ChartDataModel(calendar.AddMonths(46), 60.73, 61.19, 60.62, 61.19, 6355600),
			new ChartDataModel(calendar.AddMonths(47), 61.19, 61.07, 60.54, 60.97, 2946300),
			new ChartDataModel(calendar.AddMonths(48), 60.97, 61.05, 59.65, 59.75, 2257600),
			new ChartDataModel(calendar.AddMonths(49), 59.75, 60.58, 55.99, 59.93, 2872000),
			new ChartDataModel(calendar.AddMonths(50), 59.93, 60.12, 59.26, 59.73, 2737500),
			new ChartDataModel(calendar.AddMonths(51), 59.73, 60.11, 59.35, 59.57, 2589700),
			new ChartDataModel(calendar.AddMonths(52), 59.57, 60.40, 59.60, 60.10, 7315800),
			new ChartDataModel(calendar.AddMonths(53), 60.1, 60.31, 59.76, 60.28, 6883900),
			new ChartDataModel(calendar.AddMonths(54), 60.28, 61.68, 60.50, 61.50, 5570700),
			new ChartDataModel(calendar.AddMonths(55), 61.5, 62.72, 61.64, 62.26, 5976000),
			new ChartDataModel(calendar.AddMonths(56), 62.26, 64.08, 63.10, 63.70, 3641400),
			new ChartDataModel(calendar.AddMonths(57), 63.7, 64.60, 63.99, 64.39, 6711600),
			new ChartDataModel(calendar.AddMonths(58), 64.39, 64.45, 63.92, 64.25, 6427000),
			new ChartDataModel(calendar.AddMonths(59), 64.25, 65.40, 64.66, 64.70, 5863200),
			new ChartDataModel(calendar.AddMonths(60), 64.7, 65.86, 65.32, 65.75, 4711400),
			new ChartDataModel(calendar.AddMonths(61), 65.75, 65.22, 64.63, 64.75, 5930600),
			new ChartDataModel(calendar.AddMonths(62), 64.75, 65.39, 64.76, 65.04, 5602700),
			new ChartDataModel(calendar.AddMonths(63), 65.04, 65.30, 64.78, 65.18, 7487300),
			new ChartDataModel(calendar.AddMonths(64), 65.18, 65.09, 64.42, 65.09, 9085400),
			new ChartDataModel(calendar.AddMonths(65), 65.09, 65.64, 65.20, 65.25, 6455300),
			new ChartDataModel(calendar.AddMonths(66), 65.25, 65.59, 64.74, 64.84, 6135500),
			new ChartDataModel(calendar.AddMonths(67), 64.84, 65.84, 65.42, 65.82, 5846400),
			new ChartDataModel(calendar.AddMonths(68), 65.82, 66.75, 65.85, 66.00, 6681200),
			new ChartDataModel(calendar.AddMonths(69), 66, 67.41, 66.17, 67.41, 8780000),
			new ChartDataModel(calendar.AddMonths(70), 67.41, 68.61, 68.06, 68.41, 10780900),
			new ChartDataModel(calendar.AddMonths(71), 68.41, 68.91, 68.42, 68.76, 2336450),
			new ChartDataModel(calendar.AddMonths(72), 68.76, 69.58, 68.86, 69.01, 11902000),
			new ChartDataModel(calendar.AddMonths(73), 69.01, 69.14, 68.74, 68.94, 7513300),
			new ChartDataModel(calendar.AddMonths(74), 68.94, 68.73, 68.06, 68.65, 12074800),
			new ChartDataModel(calendar.AddMonths(75), 68.65, 68.79, 68.19, 68.67, 8785400),
			new ChartDataModel(calendar.AddMonths(76), 68.67, 69.75, 68.68, 68.74, 11373200),
			new ChartDataModel(calendar.AddMonths(77), 68.74, 68.82, 67.71, 67.76, 12378300),
			new ChartDataModel(calendar.AddMonths(78), 67.76, 69.05, 68.43, 69.00, 8458700),
			new ChartDataModel(calendar.AddMonths(79), 69, 68.39, 67.77, 68.02, 10779200),
			new ChartDataModel(calendar.AddMonths(80), 68.02, 67.94, 67.22, 67.72, 9665400),
			new ChartDataModel(calendar.AddMonths(81), 67.72, 68.15, 67.32, 67.32, 12258400),
			new ChartDataModel(calendar.AddMonths(82), 67.32, 67.95, 67.13, 67.32, 7563600),
			new ChartDataModel(calendar.AddMonths(83), 67.32, 68.00, 67.16, 67.96, 5509900),
			new ChartDataModel(calendar.AddMonths(84), 67.96, 68.89, 68.34, 68.61, 12135500),
			new ChartDataModel(calendar.AddMonths(85), 68.61, 69.47, 68.30, 68.51, 8462000),
			new ChartDataModel(calendar.AddMonths(86), 68.51, 68.69, 68.21, 68.62, 2011950),
			new ChartDataModel(calendar.AddMonths(87), 68.62, 68.39, 65.80, 68.37, 8536800),
			new ChartDataModel(calendar.AddMonths(88), 68.37, 67.75, 65.00, 62.00, 7624900),
			new ChartDataModel(calendar.AddMonths(89), 67.62, 67.04, 65.04, 67.00, 13694600),
			new ChartDataModel(calendar.AddMonths(90), 66, 66.83, 65.02, 67.60, 8911200),
			new ChartDataModel(calendar.AddMonths(91), 66.6, 66.98, 65.44, 66.73, 6679600),
			new ChartDataModel(calendar.AddMonths(92), 66.73, 66.84, 65.10, 66.11, 6451900),
			new ChartDataModel(calendar.AddMonths(93), 66.11, 66.59, 65.69, 66.38, 6739100),
			new ChartDataModel(calendar.AddMonths(94), 66.38, 67.98, 66.51, 67.67, 2103260),
			new ChartDataModel(calendar.AddMonths(95), 67.67, 69.21, 68.59, 68.90, 10551800),
			new ChartDataModel(calendar.AddMonths(96), 68.9, 69.96, 69.27, 69.44, 5261100),
			new ChartDataModel(calendar.AddMonths(97), 69.44, 69.01, 68.14, 68.18, 5905400),
			new ChartDataModel(calendar.AddMonths(98), 68.18, 68.93, 68.08, 68.14, 10283600),
			new ChartDataModel(calendar.AddMonths(99), 68.14, 68.60, 66.92, 67.25, 5006800),
			new ChartDataModel(calendar.AddMonths(100), 67.25, 67.77, 67.23, 67.77, 4110000)
		};

            DateTimeRangeData = new ObservableCollection<ChartDataModel>
			          {
			              new ChartDataModel(new DateTime(2015, 01, 1), 14),
			              new ChartDataModel(new DateTime(2015, 02, 1), 54),
			              new ChartDataModel(new DateTime(2015, 03, 1), 23),
			              new ChartDataModel(new DateTime(2015, 04, 1), 53),
			              new ChartDataModel(new DateTime(2015, 05, 1), 25),
			              new ChartDataModel(new DateTime(2015, 06, 1), 32),
			              new ChartDataModel(new DateTime(2015, 07, 1), 78),
			              new ChartDataModel(new DateTime(2015, 08, 1), 100),
			              new ChartDataModel(new DateTime(2015, 09, 1), 55),
			              new ChartDataModel(new DateTime(2015, 10, 1), 38),
			              new ChartDataModel(new DateTime(2015, 11, 1), 27),
			              new ChartDataModel(new DateTime(2015, 12, 1), 56),
			              new ChartDataModel(new DateTime(2015, 12, 31), 35),
			          };

			DateUsageData = new ObservableCollection<ChartDataModel>();

			DateUsageData.Add(new ChartDataModel(dataTime, 14));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 54));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 23));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 53));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 25));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 32));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 78));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 100));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 55));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 38));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 27));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 56));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 55));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 38));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 27));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 56));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 30));
			addWeek();
			DateUsageData.Add(new ChartDataModel(dataTime, 45));

			PolarData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("N", 80),
				new ChartDataModel("NE", 85),
				new ChartDataModel("E", 78),
				new ChartDataModel("SE", 90),
				new ChartDataModel("S", 78),
				new ChartDataModel("SW", 83),
				new ChartDataModel("W", 79),
				new ChartDataModel("NW", 88)

			};

			PolarData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("N", 63),
				new ChartDataModel("NE", 70),
				new ChartDataModel("E", 45),
				new ChartDataModel("SE", 70),
				new ChartDataModel("S", 47),
				new ChartDataModel("SW", 65),
				new ChartDataModel("W", 58),
				new ChartDataModel("NW", 73)
			};

			PolarData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("N", 42),
				new ChartDataModel("NE", 40),
				new ChartDataModel("E", 25),
				new ChartDataModel("SE", 40),
				new ChartDataModel("S", 20),
				new ChartDataModel("SW", 45),
				new ChartDataModel("W", 40),
				new ChartDataModel("NW", 40)
			};

			AreaData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 45),
				new ChartDataModel("2011", 56),
				new ChartDataModel("2012", 23),
				new ChartDataModel("2013", 43),
				new ChartDataModel("2014", double.NaN),
				new ChartDataModel("2015", 54),
				new ChartDataModel("2016", 43),
				new ChartDataModel("2017", 23),
				new ChartDataModel("2018", 34)
			};

			StripLineData = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel("Sun", 26),
				 new ChartDataModel("Mon", 24),
				 new ChartDataModel("Tue", 31),
				 new ChartDataModel("Wed", 28),
				 new ChartDataModel("Thu", 30),
				 new ChartDataModel("Fri", 26),
				 new ChartDataModel("Sat", 30),
			};

			LineData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2005", 33),
				new ChartDataModel("2006", 28),
				new ChartDataModel("2007", 29),
				new ChartDataModel("2008", 35),
				new ChartDataModel("2009", 32),
				new ChartDataModel("2010", 35),
				new ChartDataModel("2011", 30)
			};

			LineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2005", 31),
				new ChartDataModel("2006", 28),
				new ChartDataModel("2007", 30),
				new ChartDataModel("2008", 36),
				new ChartDataModel("2009", 36),
				new ChartDataModel("2010", 39),
				new ChartDataModel("2011", 37)
			};

			LineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2005", 39),
				new ChartDataModel("2006", 36),
				new ChartDataModel("2007", 40),
				new ChartDataModel("2008", 44),
				new ChartDataModel("2009", 45),
				new ChartDataModel("2010", 48),
				new ChartDataModel("2011", 46)
			};

			StepLineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 463),
				new ChartDataModel(2007, 449),
				new ChartDataModel(2008, 458),
				new ChartDataModel(2009, 450),
				new ChartDataModel(2010, 425),
				new ChartDataModel(2011, 430),
			};
			StepLineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 519),
				new ChartDataModel(2007, 508),
				new ChartDataModel(2008, 502),
				new ChartDataModel(2009, 495),
				new ChartDataModel(2010, 485),
				new ChartDataModel(2011, 470),
			};
			StepLineData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 570),
				new ChartDataModel(2007, 579),
				new ChartDataModel(2008, 563),
				new ChartDataModel(2009, 550),
				new ChartDataModel(2010, 545),
				new ChartDataModel(2011, 525),
			};

			StepAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 40),
				new ChartDataModel(2007, 60),
				new ChartDataModel(2008, 50),
				new ChartDataModel(2009, 55),
				new ChartDataModel(2010, 75),
				new ChartDataModel(2011, 80),
			};

			StepAreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 20),
				new ChartDataModel(2007, 40),
				new ChartDataModel(2008, 30),
				new ChartDataModel(2009, 45),
				new ChartDataModel(2010, 55),
				new ChartDataModel(2011, 60),
			};

			ColumnData1 = new ObservableCollection<ChartDataModel>
			 {
				 new ChartDataModel("USA", 50),
				 new ChartDataModel("China", 40),
				 new ChartDataModel("Japan", 70),
				 new ChartDataModel("Australia", 60),
				 new ChartDataModel("France", 50),
			};
			ColumnData2 = new ObservableCollection<ChartDataModel>
			 {
				  new ChartDataModel("USA", 70),
				 new ChartDataModel("China", 60),
				 new ChartDataModel("Japan", 60),
				 new ChartDataModel("Australia", 56),
				 new ChartDataModel("France", 45),
			 };
			ColumnData3 = new ObservableCollection<ChartDataModel>
			 {
				 new ChartDataModel("USA", 45),
				 new ChartDataModel("China", 55),
				 new ChartDataModel("Japan", 50),
				 new ChartDataModel("Australia", 40),
				 new ChartDataModel("France", 35),
			 };
             BarData1 = new ObservableCollection<ChartDataModel>
             {
                 new ChartDataModel("2006", 7.8),
                 new ChartDataModel("2007", 7.2),
                 new ChartDataModel("2008", 6.8),
                 new ChartDataModel("2009", 10.7),
                 new ChartDataModel("2010", 10.8),
                 new ChartDataModel("2011", 9.8)
             };
             BarData2 = new ObservableCollection<ChartDataModel>
             {
                 new ChartDataModel("2006", 4.8),
                 new ChartDataModel("2007", 4.6),
                 new ChartDataModel("2008", 7.2),
                 new ChartDataModel("2009", 9.3),
                 new ChartDataModel("2010", 9.7),
                 new ChartDataModel("2011", 9)
             };
			AreaData1 = new ObservableCollection<ChartDataModel>
				 {
					 new ChartDataModel("1900", 4.0),
					 new ChartDataModel("1920", 3.0),
					 new ChartDataModel("1940", 3.8),
					 new ChartDataModel("1960", 3.4),
					 new ChartDataModel("1980", 3.2),
					 new ChartDataModel("2000", 3.9),
				 };
			AreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("1900", 2.6),
				new ChartDataModel("1920", 2.8),
				new ChartDataModel("1940", 2.6),
				new ChartDataModel("1960", 3.0),
				new ChartDataModel("1980", 3.6),
				new ChartDataModel("2000", 3.0)
			};
			AreaData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("1900", 2.8),
				new ChartDataModel("1920", 2.5),
				new ChartDataModel("1940", 2.8),
				new ChartDataModel("1960", 3.0),
				new ChartDataModel("1980", 2.9),
				new ChartDataModel("2000", 2.0)
			};
			SplineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", -1),
				new ChartDataModel("Feb", -1),
				new ChartDataModel("Mar", 2),
				new ChartDataModel("Apr", 8),
				new ChartDataModel("May", 13),
				new ChartDataModel("Jun", 18),
				new ChartDataModel("Jul", 21),
				new ChartDataModel("Aug", 20),
				new ChartDataModel("Sep", 16),
				new ChartDataModel("Oct", 10),
				new ChartDataModel("Nov", 4),
				new ChartDataModel("Dec", 0),
			};

			SplineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 7),
				new ChartDataModel("Feb", 8),
				new ChartDataModel("Mar", 12),
				new ChartDataModel("Apr", 19),
				new ChartDataModel("May", 25),
				new ChartDataModel("Jun", 29),
				new ChartDataModel("Jul", 31),
				new ChartDataModel("Aug", 30),
				new ChartDataModel("Sep", 26),
				new ChartDataModel("Oct", 20),
				new ChartDataModel("Nov", 14),
				new ChartDataModel("Dec", 8),
			};
			SplineAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 2.2),
				new ChartDataModel("2003", 3.4),
				new ChartDataModel("2004", 2.8),
				new ChartDataModel("2005", 1.6),
				new ChartDataModel("2006", 2.3),
				new ChartDataModel("2007", 2.5),
				new ChartDataModel("2008", 2.9),
				new ChartDataModel("2009", 3.8),
				new ChartDataModel("2010", 1.4),
				new ChartDataModel("2011", 3.1),
			};
			SplineAreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 2.0),
				new ChartDataModel("2003", 1.7),
				new ChartDataModel("2004", 1.8),
				new ChartDataModel("2005", 2.1),
				new ChartDataModel("2006", 2.3),
				new ChartDataModel("2007", 1.7),
				new ChartDataModel("2008", 1.5),
				new ChartDataModel("2009", 2.8),
				new ChartDataModel("2010", 1.5),
				new ChartDataModel("2011", 2.3),
			};
			SplineAreaData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 0.8),
				new ChartDataModel("2003", 1.3),
				new ChartDataModel("2004", 1.1),
				new ChartDataModel("2005", 1.6),
				new ChartDataModel("2006", 2.0),
				new ChartDataModel("2007", 1.7),
				new ChartDataModel("2008", 2.3),
				new ChartDataModel("2009", 2.7),
				new ChartDataModel("2010", 1.1),
				new ChartDataModel("2011", 2.3),
			};
			RangeColumnData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 6.1, 0.7),
				new ChartDataModel("Mar", 8.5, 1.9),
				new ChartDataModel("May", 14.4, 5.7),
				new ChartDataModel("Jul", 19.2, 10.6),
				new ChartDataModel("Sep", 16.1, 8.5),
				new ChartDataModel("Nov", 6.9, 1.5),
			};
			RangeColumnData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 7.7, 1.7),
				new ChartDataModel("Mar", 7.5, 1.2),
				new ChartDataModel("May", 11.4, 4.7),
				new ChartDataModel("Jul", 17.2, 9.6),
				new ChartDataModel("Sep", 15.1, 7.5),
				new ChartDataModel("Nov", 7.9, 1.2),
			};

			RangeAreaData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 45, 32),
				new ChartDataModel("Feb", 48, 34),
				new ChartDataModel("Mar", 46, 32),
				new ChartDataModel("Apr", 48, 36),
				new ChartDataModel("May", 46, 32),
				new ChartDataModel("Jun", 49, 34),
			};

			RangeAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 30, 18),
				new ChartDataModel("Feb", 24, 12),
				new ChartDataModel("Mar", 29, 15),
				new ChartDataModel("Apr", 24, 10),
				new ChartDataModel("May", 30, 18),
				new ChartDataModel("Jun", 24, 10),
			};

            RangeBarData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Jumbo", 119238),
                new ChartDataModel("FHA", 159595),
                new ChartDataModel("VA", 256398),
                new ChartDataModel("USDA", 356396),
                new ChartDataModel("Const", 456398),
                new ChartDataModel("Total", 559937)

            };

            StepLineData = new ObservableCollection<ChartDataModel>
				{
					new ChartDataModel("2002", 36),
					new ChartDataModel("2003", 40),
					new ChartDataModel("2004", 34),
					new ChartDataModel("2005", 40),
					new ChartDataModel("2006", 44),
					new ChartDataModel("2007", 38),
					new ChartDataModel("2008", 30)

				};
			PieSeriesData = new ObservableCollection<ChartDataModel>
				 {
					 new ChartDataModel("Chrome", 94658),
					 new ChartDataModel("UC Browser", 9090),
					 new ChartDataModel("Opera", 2577),
				};
			DoughnutSeriesData = new ObservableCollection<ChartDataModel>
				 {
					 new ChartDataModel("Labour", 28),
					 new ChartDataModel("Legal", 10),
					 new ChartDataModel("Production", 20),
					 new ChartDataModel("License", 15),
					 new ChartDataModel("Facilities", 23),
					 new ChartDataModel("Taxes", 17),
					 new ChartDataModel("Insurance", 12),
				};
			PyramidData = new ObservableCollection<ChartDataModel>
			 {
				 new ChartDataModel("India", 24),
				 new ChartDataModel("Japan", 25),
				 new ChartDataModel("Australia", 20),
				 new ChartDataModel("USA", 35),
				 new ChartDataModel("China", 23),
				 new ChartDataModel("Germany", 27),
				 new ChartDataModel("France", 22),
			};
			FunnelData = new ObservableCollection<ChartDataModel>
			 {
				new ChartDataModel("Renewed", 18.2),
				new ChartDataModel("Subscribe", 27.3),
				new ChartDataModel("Support", 55.9),
				new ChartDataModel("Downloaded", 76.8),
				new ChartDataModel("Visited", 100),
			};
			StackedBarData1 = new ObservableCollection<ChartDataModel>
				 {
					 new ChartDataModel("Jan", 6),
					 new ChartDataModel("Feb", 8),
					 new ChartDataModel("Mar", 12),
					 new ChartDataModel("Apr", 15.5),
					 new ChartDataModel("May", 20),
					 new ChartDataModel("Jun", 24),
					 new ChartDataModel("Jul", 28),
					 new ChartDataModel("Aug", 32),
					 new ChartDataModel("Sep", 33),
					 new ChartDataModel("Oct", 35),
					 new ChartDataModel("Nov", 40),
					 new ChartDataModel("Dec", 42),
				};
			StackedBarData2 = new ObservableCollection<ChartDataModel>
				 {
					 new ChartDataModel("Jan", 6),
					 new ChartDataModel("Feb", 8),
					 new ChartDataModel("Mar", 12),
					 new ChartDataModel("Apr", 15.5),
					 new ChartDataModel("May", 20),
					 new ChartDataModel("Jun", 24),
					 new ChartDataModel("Jul", 28),
					 new ChartDataModel("Aug", 32),
					 new ChartDataModel("Sep", 33),
					 new ChartDataModel("Oct", 35),
					 new ChartDataModel("Nov", 40),
					 new ChartDataModel("Dec", 42),
				 };
			StackedBarData3 = new ObservableCollection<ChartDataModel>
				 {
					 new ChartDataModel("Jan", -1),
					 new ChartDataModel("Feb", -1.5),
					 new ChartDataModel("Mar", -2),
					 new ChartDataModel("Apr", -2.5),
					 new ChartDataModel("May", -3),
					 new ChartDataModel("Jun", -3.5),
					 new ChartDataModel("Jul", -4),
					 new ChartDataModel("Aug", -4.5),
					 new ChartDataModel("Sep", -5),
					 new ChartDataModel("Oct", -5.5),
					 new ChartDataModel("Nov", -6),
					 new ChartDataModel("Dec", -6.5),
				 };
                 StackedBar100Data1 = new ObservableCollection<ChartDataModel>
                 {
                     new ChartDataModel("2007", 453),
                     new ChartDataModel("2008", 354),
                     new ChartDataModel("2009", 282),
                     new ChartDataModel("2010", 321),
                     new ChartDataModel("2011", 333),
                     new ChartDataModel("2012", 351),
                     new ChartDataModel("2013", 403),
                     new ChartDataModel("2014", 421),
                 };
                 StackedBar100Data2 = new ObservableCollection<ChartDataModel>
                 {
                     new ChartDataModel("2007", 876),
                     new ChartDataModel("2008", 564),
                     new ChartDataModel("2009", 242),
                     new ChartDataModel("2010", 121),
                     new ChartDataModel("2011", 343),
                     new ChartDataModel("2012", 451),
                     new ChartDataModel("2013", 203),
                     new ChartDataModel("2014", 431),
                 };
                 StackedBar100Data3 = new ObservableCollection<ChartDataModel>
                 {
                     new ChartDataModel("2007", 356),
                     new ChartDataModel("2008", 876),
                     new ChartDataModel("2009", 898),
                     new ChartDataModel("2010", 567),
                     new ChartDataModel("2011", 456),
                     new ChartDataModel("2012", 345),
                     new ChartDataModel("2013", 543),
                     new ChartDataModel("2014", 654),
                 };
			StackedBar100Data4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2007", 122),
				new ChartDataModel("2008", 444),
				new ChartDataModel("2009", 222),
				new ChartDataModel("2010", 231),
				new ChartDataModel("2011", 122),
				new ChartDataModel("2012", 333),
				new ChartDataModel("2013", 354),
				new ChartDataModel("2014", 100),
			};
			StackedColumnData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 900),
				new ChartDataModel("Feb", 820),
				new ChartDataModel("Mar", 880),
				new ChartDataModel("Apr", 725),
				new ChartDataModel("May", 765),
				new ChartDataModel("Jun", 679),
			};
			StackedColumnData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 190),
				new ChartDataModel("Feb", 226),
				new ChartDataModel("Mar", 194),
				new ChartDataModel("Apr", 250),
				new ChartDataModel("May", 222),
				new ChartDataModel("Jun", 181),
			};
			StackedColumnData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 250),
				new ChartDataModel("Feb", 145),
				new ChartDataModel("Mar", 190),
				new ChartDataModel("Apr", 220),
				new ChartDataModel("May", 225),
				new ChartDataModel("Jun", 135),
			};
			StackedColumnData4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 150),
				new ChartDataModel("Feb", 120),
				new ChartDataModel("Mar", 115),
				new ChartDataModel("Apr", 125),
				new ChartDataModel("May", 132),
				new ChartDataModel("Jun", 137),
			};

			StackedAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 6),
				new ChartDataModel("2003", 7.5),
				new ChartDataModel("2004", 6),
				new ChartDataModel("2005", 6.5),
				new ChartDataModel("2006", 7.4),
				new ChartDataModel("2007", 7.9),
				new ChartDataModel("2008", 7.5),
				new ChartDataModel("2009", 8.5),
				new ChartDataModel("2010", 4.8),
				new ChartDataModel("2011", 9.3),
			};
			StackedAreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 3.5),
				new ChartDataModel("2003", 4.9),
				new ChartDataModel("2004", 3.7),
				new ChartDataModel("2005", 7.5),
				new ChartDataModel("2006", 4.8),
				new ChartDataModel("2007", 2.6),
				new ChartDataModel("2008", 4.7),
				new ChartDataModel("2009", 3.7),
				new ChartDataModel("2010", 3.5),
				new ChartDataModel("2011", 3.6),
			};
			StackedAreaData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 8.1),
				new ChartDataModel("2003", 8.8),
				new ChartDataModel("2004", 6.7),
				new ChartDataModel("2005", 6.4),
				new ChartDataModel("2006", 4.0),
				new ChartDataModel("2007", 4.8),
				new ChartDataModel("2008", 7.4),
				new ChartDataModel("2009", 3.5),
				new ChartDataModel("2010", 8.3),
				new ChartDataModel("2011", 4.7),
			};
			StackedAreaData4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 2.5),
				new ChartDataModel("2003", 6.1),
				new ChartDataModel("2004", 6.2),
				new ChartDataModel("2005", 1.8),
				new ChartDataModel("2006", 4.0),
				new ChartDataModel("2007", 6.5),
				new ChartDataModel("2008", 6.7),
				new ChartDataModel("2009", 7.2),
				new ChartDataModel("2010", 8.4),
				new ChartDataModel("2011", 6.9),
			};
			StackedArea100Data1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 34),
				new ChartDataModel("2007", 20),
				new ChartDataModel("2008", 40),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 54),
				new ChartDataModel("2013", 44),
				new ChartDataModel("2014", 48),
			};
			StackedArea100Data2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 51),
				new ChartDataModel("2007", 26),
				new ChartDataModel("2008", 37),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 43),
				new ChartDataModel("2013", 23),
				new ChartDataModel("2014", 55),
			};
			StackedArea100Data3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 14),
				new ChartDataModel("2007", 34),
				new ChartDataModel("2008", 73),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 12),
				new ChartDataModel("2013", 16),
				new ChartDataModel("2014", 34),
			};
			StackedArea100Data4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 37),
				new ChartDataModel("2007", 16),
				new ChartDataModel("2008", 53),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 54),
				new ChartDataModel("2013", 44),
				new ChartDataModel("2014", 23),
			};
			CircularData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 8000),
				new ChartDataModel("2011", 8100),
				new ChartDataModel("2012", 8250),
				new ChartDataModel("2013", 8600),
				new ChartDataModel("2014", 8700)
			};
			MultipleAxisData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 20),
				new ChartDataModel("2011", 21),
				new ChartDataModel("2012", 22.5),
				new ChartDataModel("2013", 26),
				new ChartDataModel("2014", 27)
			};
			MultipleAxisData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 6),
				new ChartDataModel("2011", 15),
				new ChartDataModel("2012", 35),
				new ChartDataModel("2013", 65),
				new ChartDataModel("2014", 75)
			};

			SemiCircularData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Product A", 14),
				new ChartDataModel("Product B", 54),
				new ChartDataModel("Product C", 23),
				new ChartDataModel("Product D", 53),
			};

			BubbleData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(92.2, 7.8, 0.47),
				new ChartDataModel(74, 6.5, 0.241),
				new ChartDataModel(90.4, 6.0, 0.238),
				new ChartDataModel(99.4, 2.2, 0.312),
				new ChartDataModel(88.6, 1.3, 0.197),
				new ChartDataModel(54.9, 3.7, 0.177),
				new ChartDataModel(99, 0.7, 0.0818),
				new ChartDataModel(72, 2.0, 0.0826),
				new ChartDataModel(99.6, 3.4, 0.143),
				new ChartDataModel(99, 0.2, 0.128),
				new ChartDataModel(86.1, 4.0, 0.115),
				new ChartDataModel(92.6, 6.6, 0.096),
				new ChartDataModel(61.3, 14.5, 0.162),
				new ChartDataModel(56.8, 6.1, 0.151),

			};

			ScatterData = new ObservableCollection<ChartDataModel>();
			{
				for (int i = 0; i < 300; i++)
				{
					double x = random.NextDouble() * 100;
					double y = random.NextDouble() * 500;
					double randomDouble = random.NextDouble();
					if (randomDouble >= .25 && randomDouble < .5)
					{
						x *= -1;
					}
					else if (randomDouble >= .5 && randomDouble < .75)
					{
						y *= -1;
					}
					else if (randomDouble > .75)
					{
						x *= -1;
						y *= -1;
					}
					ScatterData.Add(new ChartDataModel(300 + (x * (random.NextDouble() + 0.12)),
							100 + (y * (random.NextDouble() + 0.12))));
				}
			}

			RangeColumnData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 35, 17),
				new ChartDataModel("Feb", 42, -11),
				new ChartDataModel("Mar", 25, 5),
				new ChartDataModel("Apr", 32, 10),
				new ChartDataModel("May", 20, 3),
				new ChartDataModel("Jun", 41, 30)
			};

			FinancialData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(new DateTime(2000, 01, 17),  115, 125, 70, 90),
				new ChartDataModel(new DateTime(2000, 02, 17),  120, 150, 60, 70),
				new ChartDataModel(new DateTime(2000, 03, 17),  160, 200, 140, 190),
				new ChartDataModel(new DateTime(2000, 04, 17),  140, 160, 90, 110),
				new ChartDataModel(new DateTime(2000, 05, 17),  180, 200, 100, 120),
				new ChartDataModel(new DateTime(2000, 06, 17),  70, 100, 45, 50)
			};

			Data1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 45),
				new ChartDataModel("2011", 89),
				new ChartDataModel("2012", 23),
				new ChartDataModel("2013", 43),
				new ChartDataModel("2014", 54)
			};

			Data2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 54),
				new ChartDataModel("2011", 24),
				new ChartDataModel("2012", 53),
				new ChartDataModel("2013", 63),
				new ChartDataModel("2014", 35)
			};

			Data3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 14),
				new ChartDataModel("2011", 54),
				new ChartDataModel("2012", 23),
				new ChartDataModel("2013", 53),
				new ChartDataModel("2014", 25)
			};

			CategoryData = new ObservableCollection<ChartDataModel>
			 {
				 new ChartDataModel("BGD", 87),
				 new ChartDataModel("BTN", 70),
				 new ChartDataModel("NPL", 82),
				 new ChartDataModel("THA", 75),
				 new ChartDataModel("MYS", 90),
			 };

			LogarithmicData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("1990", 80),
				new ChartDataModel("1991", 200),
				new ChartDataModel("1992", 400),
				new ChartDataModel("1993", 600),
				new ChartDataModel("1994", 900),
				new ChartDataModel("1995", 1400),
				new ChartDataModel("1996", 2000),
				new ChartDataModel("1997", 4000),
				new ChartDataModel("1998", 6000),
				new ChartDataModel("1999", 8000),
				new ChartDataModel("2000", 9000)
			};

			NumericData = new ObservableCollection<ChartDataModel>
					{
						new ChartDataModel(2001, 75),
						new ChartDataModel(2002, 90),
						new ChartDataModel(2003, 85),
						new ChartDataModel(2004, 70),
						new ChartDataModel(2005, 55),
						new ChartDataModel(2006, 65),
					};

			DateTimeData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(new DateTime(2014, 02, 1), 10),
				new ChartDataModel(new DateTime(2015, 03, 2), 30),
				new ChartDataModel(new DateTime(2016, 04, 3), 15),
				new ChartDataModel(new DateTime(2017, 05, 4), 65),
				new ChartDataModel(new DateTime(2018, 06, 5), 90),
				new ChartDataModel(new DateTime(2019, 07, 5), 85)
			};

			datas1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 6),
				new ChartDataModel("2011", 15),
				new ChartDataModel("2012", 35),
				new ChartDataModel("2013", 65),
				new ChartDataModel("2014", 75)
			};


			DataMarkerData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2001", 59),
				new ChartDataModel("2002", 44),
				new ChartDataModel("2003", 47),
				new ChartDataModel("2004", 61),
				new ChartDataModel("2005", 76),
			};

			SelectionData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 42),
				new ChartDataModel("Feb", 44),
				new ChartDataModel("Mar", 53),
				new ChartDataModel("Apr", 64),
				new ChartDataModel("May", 75),
				new ChartDataModel("Jun", 83)
			};

			MultipleSeriesData1 = new ObservableCollection<ChartDataModel>();

			for (var i = 1; i <= 12; i++)
			{
				MultipleSeriesData1.Add(new ChartDataModel(new DateTime(2014, i, 1), random.Next(10, 100)));
			}

			MultipleSeriesData2 = new ObservableCollection<ChartDataModel>();

			for (var i = 1; i <= 12; i++)
			{
				MultipleSeriesData2.Add(new ChartDataModel(new DateTime(2014, i, 1), random.Next(10, 100)));
			}

			PieData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(new DateTime(2014, 1, 1), 48),
				new ChartDataModel(new DateTime(2014, 2, 1), 38),
				new ChartDataModel(new DateTime(2014, 3, 1), 28),
				new ChartDataModel(new DateTime(2014, 4, 1), 33),
				new ChartDataModel(new DateTime(2014, 5, 1), 25),
				new ChartDataModel(new DateTime(2014, 6, 1), 34)
			};

			TriangularData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Bentley", 800),
				new ChartDataModel("Audi", 810),
				new ChartDataModel("BMW", 825),
				new ChartDataModel("Jaguar", 860),
				new ChartDataModel("Skoda", 875)
			};

			data = new ObservableCollection<ChartDataModel>();

			LineSeries1 = new ObservableCollection<ChartDataModel>();
			LineSeries1.Add(new ChartDataModel("2005", 31));
			LineSeries1.Add(new ChartDataModel("2006", 28));
			LineSeries1.Add(new ChartDataModel("2007", 30));
			LineSeries1.Add(new ChartDataModel("2008", 36));
			LineSeries1.Add(new ChartDataModel("2009", 36));
			LineSeries1.Add(new ChartDataModel("2010", 39));

			LineSeries2 = new ObservableCollection<ChartDataModel>();
			LineSeries2.Add(new ChartDataModel("2005", 36));
			LineSeries2.Add(new ChartDataModel("2006", 32));
			LineSeries2.Add(new ChartDataModel("2007", 34));
			LineSeries2.Add(new ChartDataModel("2008", 41));
			LineSeries2.Add(new ChartDataModel("2009", 42));
			LineSeries2.Add(new ChartDataModel("2010", 42));

			LineSeries3 = new ObservableCollection<ChartDataModel>();
			LineSeries3.Add(new ChartDataModel("2005", 39));
			LineSeries3.Add(new ChartDataModel("2006", 36));
			LineSeries3.Add(new ChartDataModel("2007", 40));
			LineSeries3.Add(new ChartDataModel("2008", 44));
			LineSeries3.Add(new ChartDataModel("2009", 45));
			LineSeries3.Add(new ChartDataModel("2010", 48));

			TooltipData = new ObservableCollection<ChartDataModel>();
			TooltipData.Add(new ChartDataModel("2007", 1.61));
			TooltipData.Add(new ChartDataModel("2008", 2.34));
			TooltipData.Add(new ChartDataModel("2009", 2.16));
			TooltipData.Add(new ChartDataModel("2010", 2.1));
			TooltipData.Add(new ChartDataModel("2011", 1.61));
			TooltipData.Add(new ChartDataModel("2012", 2.05));
			TooltipData.Add(new ChartDataModel("2013", 2.5));
			TooltipData.Add(new ChartDataModel("2014", 2.21));
			TooltipData.Add(new ChartDataModel("2015", 2.34));
		}

		public void LoadData()
		{
			for (int i = 1; i <= 30; i++)
			{
				NSNumber value = new NSNumber(random.Next(0, 9));
				data.Add(new ChartDataModel(i, (double)value));
				wave1++;
			}
		}

		public ChartDataModel dataPointWithTimeInterval(double time)
		{
			int count = verticalCount;
			NSNumber value;

			if (count > 320)
			{
				value = random.Next(0, 0);
			}
			else if (count > 280)
			{
				value = random.Next(-2, 2);
			}
			else if (count > 240)
			{
				value = random.Next(-3, 3);
			}
			else if (count > 200)
			{
				value = random.Next(-5, 5);
			}
			else if (count > 180)
			{
				value = random.Next(-6, 6);
			}
			else if (count > 120)
			{
				value = random.Next(-7, 7);
			}
			else if (count > 30)
			{
				value = random.Next(-9, 9);
			}
			else
			{
				value = random.Next(-3, 3);
			}

			date = date.AddSeconds(time);

			ChartDataModel datapoint = new ChartDataModel();
			datapoint.XValue = date;
			datapoint.YValue = (double)value;
			return datapoint;
		}

		private void addWeek()
		{
			dataTime = dataTime.AddDays(7);
		}

	}
}
