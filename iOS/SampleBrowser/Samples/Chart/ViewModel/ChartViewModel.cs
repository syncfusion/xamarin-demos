#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

		public ObservableCollection<ChartDataModel> DataMarkerData1 { get; set; }

		public ObservableCollection<ChartDataModel> DataMarkerData2 { get; set; }

		public ObservableCollection<ChartDataModel> PolarData2 { get; set; }

		public ObservableCollection<ChartDataModel> PolarData3 { get; set; }

		public ObservableCollection<ChartDataModel> AreaData { get; set; }

		public ObservableCollection<ChartDataModel> AreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> AreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> StepAreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> StepAreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> LineData { get; set; }

		public ObservableCollection<ChartDataModel> LineData1 { get; set; }

		public ObservableCollection<ChartDataModel> LineData2 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData1 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData2 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData3 { get; set; }

        public ObservableCollection<ChartDataModel> HistogramData { get; set; }

		public ObservableCollection<ChartDataModel> BarData1 { get; set; }

		public ObservableCollection<ChartDataModel> BarData2 { get; set; }

		public ObservableCollection<ChartDataModel> SplineData1 { get; set; }

		public ObservableCollection<ChartDataModel> SplineData2 { get; set; }

		public ObservableCollection<ChartDataModel> SplineData3 { get; set; }

		public ObservableCollection<ChartDataModel> SplineAreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> SplineAreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> SplineAreaData3 { get; set; }

		public ObservableCollection<ChartDataModel> RangeColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> RangeColumnData2 { get; set; }

        public ObservableCollection<ChartDataModel> RangeBarData { get; set; }

        public ObservableCollection<ChartDataModel> RangeAreaData { get; set; }

		public ObservableCollection<ChartDataModel> RangeAreaData1 { get; set; }

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

		public ObservableCollection<ChartDataModel> StackedColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData4 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumn100Data1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumn100Data2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumn100Data3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumn100Data4 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLineData1 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLineData2 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLineData3 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLineData4 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLine100Data1 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLine100Data2 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLine100Data3 { get; set; }

        public ObservableCollection<ChartDataModel> StackedLine100Data4 { get; set; }

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

		public ObservableCollection<ChartDataModel> ScatterMaleData { get; set; }

		public ObservableCollection<ChartDataModel> ScatterFemaleData { get; set; }

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

		public ObservableCollection<ChartDataModel> NumericData1 { get; set; }

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

        public ObservableCollection<ChartDataModel> SelectionData1 { get; set; }

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

				date = new DateTime(2011, 3, 11, 14, 46, 0);

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

		public ObservableCollection<ChartDataModel> StackedDoughnutData { get; set; }



		public ChartViewModel()
		{
			DateTime calendar = new DateTime(2000, 1, 1);

			DateTime dt = new DateTime(2000, 1, 1);

			StackedDoughnutData = new ObservableCollection<ChartDataModel>();
			StackedDoughnutData.Add(new ChartDataModel("Vehicle", 62.7, "Images/Car.png"));
			StackedDoughnutData.Add(new ChartDataModel("Education", 29.5, "Images/Chart_Book.png"));
			StackedDoughnutData.Add(new ChartDataModel("Home", 85.2, "Images/House.png"));
			StackedDoughnutData.Add(new ChartDataModel("Personal", 45.6, "Images/Personal.png"));

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
				new ChartDataModel("2000", 4),
				new ChartDataModel("2001", 3.0),
				new ChartDataModel("2002", 3.8),
				new ChartDataModel("2003", 3.4),
				new ChartDataModel("2004", 3.2),
				new ChartDataModel("2005", 3.9),

			};

			PolarData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 2.6),
				new ChartDataModel("2001", 2.8),
				new ChartDataModel("2002", 2.6),
				new ChartDataModel("2003", 3),
				new ChartDataModel("2004", 3.6),
				new ChartDataModel("2005", 3),
			};

			PolarData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 2.8),
				new ChartDataModel("2001", 2.5),
				new ChartDataModel("2002", 2.8),
				new ChartDataModel("2003", 3.2),
				new ChartDataModel("2004", 2.9),
				new ChartDataModel("2005", 2),
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
				new ChartDataModel("2005", 21),
				new ChartDataModel("2006", 24),
				new ChartDataModel("2007", 36),
				new ChartDataModel("2008", 38),
				new ChartDataModel("2009", 54),
				new ChartDataModel("2010", 57),
				new ChartDataModel("2011", 70)
			};

			LineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2005", 28),
				new ChartDataModel("2006", 44),
				new ChartDataModel("2007", 48),
				new ChartDataModel("2008", 50),
				new ChartDataModel("2009", 66),
				new ChartDataModel("2010", 78),
				new ChartDataModel("2011", 84)
			};

			StepLineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(1975, 16),
				new ChartDataModel(1980, 12.5),
				new ChartDataModel(1985, 19),
				new ChartDataModel(1990, 14.4),
				new ChartDataModel(1995, 11.5),
				new ChartDataModel(2000, 14),
				new ChartDataModel(2005, 10),
				new ChartDataModel(2010, 16),
			};
			StepLineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(1975, 10),
				new ChartDataModel(1980, 7.5),
				new ChartDataModel(1985, 11),
				new ChartDataModel(1990, 7),
				new ChartDataModel(1995, 8),
				new ChartDataModel(2000, 6),
				new ChartDataModel(2005, 3.5),
				new ChartDataModel(2010, 7),
			};

			StepAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2000, 416),
				new ChartDataModel(2001, 490),
				new ChartDataModel(2002, 470),
				new ChartDataModel(2003, 500),
				new ChartDataModel(2004, 449),
				new ChartDataModel(2005, 470),
				new ChartDataModel(2006, 437),
				new ChartDataModel(2007, 458),
				new ChartDataModel(2008, 500),
				new ChartDataModel(2009, 473),
				new ChartDataModel(2010, 520),
				new ChartDataModel(2011, 509),
			};

			StepAreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2000, 180),
				new ChartDataModel(2001, 240),
				new ChartDataModel(2002, 370),
				new ChartDataModel(2003, 200),
				new ChartDataModel(2004, 229),
				new ChartDataModel(2005, 210),
				new ChartDataModel(2006, 337),
				new ChartDataModel(2007, 258),
				new ChartDataModel(2008, 300),
				new ChartDataModel(2009, 173),
				new ChartDataModel(2010, 220),
				new ChartDataModel(2011, 309),
			};

			ColumnData1 = new ObservableCollection<ChartDataModel>
			 {
				new ChartDataModel("USA", 46),
				new ChartDataModel("GBR", 27),
				new ChartDataModel("CHN", 26),
			};
			ColumnData2 = new ObservableCollection<ChartDataModel>
			 {
				new ChartDataModel("USA", 37),
				new ChartDataModel("GBR", 23),
				new ChartDataModel("CHN", 18),
			 };
			ColumnData3 = new ObservableCollection<ChartDataModel>
			 {
				new ChartDataModel("USA", 38),
				new ChartDataModel("GBR", 17),
				new ChartDataModel("CHN", 26),
			 };
            HistogramData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(0, 5.250),
                new ChartDataModel(0, 7.750),
                new ChartDataModel(0, 0),
                new ChartDataModel(0, 8.275),
                new ChartDataModel(0, 9.750),
                new ChartDataModel(0, 7.750),
                new ChartDataModel(0, 8.275),
                new ChartDataModel(0, 6.250),
                new ChartDataModel(0, 5.750),
                new ChartDataModel(0, 5.250),
                new ChartDataModel(0, 23.000),
                new ChartDataModel(0, 26.500),
                new ChartDataModel(0, 27.750),
                new ChartDataModel(0, 25.025),
                new ChartDataModel(0, 26.500),
                new ChartDataModel(0, 26.500),
                new ChartDataModel(0, 28.025),
                new ChartDataModel(0, 29.250),
                new ChartDataModel(0, 26.750),
                new ChartDataModel(0, 27.250),
                new ChartDataModel(0, 26.250),
                new ChartDataModel(0, 25.250),
                new ChartDataModel(0, 34.500),
                new ChartDataModel(0, 25.625),
                new ChartDataModel(0, 25.500),
                new ChartDataModel(0, 26.625),
                new ChartDataModel(0, 36.275),
                new ChartDataModel(0, 36.250),
                new ChartDataModel(0, 26.875),
                new ChartDataModel(0, 45.000),
                new ChartDataModel(0, 43.000),
                new ChartDataModel(0, 46.500),
                new ChartDataModel(0, 47.750),
                new ChartDataModel(0, 45.025),
                new ChartDataModel(0, 56.500),
                new ChartDataModel(0, 56.500),
                new ChartDataModel(0, 58.025),
                new ChartDataModel(0, 59.250),
                new ChartDataModel(0, 56.750),
                new ChartDataModel(0, 57.250),
                new ChartDataModel(0, 46.250),
                new ChartDataModel(0, 55.250),
                new ChartDataModel(0, 44.500),
                new ChartDataModel(0, 45.500),
                new ChartDataModel(0, 55.500),
                new ChartDataModel(0, 45.625),
                new ChartDataModel(0, 55.500),
                new ChartDataModel(0, 56.250),
                new ChartDataModel(0, 46.875),
                new ChartDataModel(0, 43.000),
                new ChartDataModel(0, 46.250),
                new ChartDataModel(0, 55.250),
                new ChartDataModel(0, 44.500),
                new ChartDataModel(0, 45.425),
                new ChartDataModel(0, 56.625),
                new ChartDataModel(0, 46.275),
                new ChartDataModel(0, 56.250),
                new ChartDataModel(0, 46.875),
                new ChartDataModel(0, 43.000),
                new ChartDataModel(0, 46.250),
                new ChartDataModel(0, 55.250),
                new ChartDataModel(0, 44.500),
                new ChartDataModel(0, 45.425),
                new ChartDataModel(0, 55.500),
                new ChartDataModel(0, 46.625),
                new ChartDataModel(0, 56.275),
                new ChartDataModel(0, 46.250),
                new ChartDataModel(0, 56.250),
                new ChartDataModel(0, 42.000),
                new ChartDataModel(0, 41.000),
                new ChartDataModel(0, 63.000),
                new ChartDataModel(0, 66.500),
                new ChartDataModel(0, 67.750),
                new ChartDataModel(0, 65.025),
                new ChartDataModel(0, 66.500),
                new ChartDataModel(0, 76.500),
                new ChartDataModel(0, 78.025),
                new ChartDataModel(0, 79.250),
                new ChartDataModel(0, 76.750),
                new ChartDataModel(0, 77.250),
                new ChartDataModel(0, 66.250),
                new ChartDataModel(0, 75.250),
                new ChartDataModel(0, 74.500),
                new ChartDataModel(0, 65.625),
                new ChartDataModel(0, 75.500),
                new ChartDataModel(0, 76.625),
                new ChartDataModel(0, 76.275),
                new ChartDataModel(0, 66.250),
                new ChartDataModel(0, 66.875),
                new ChartDataModel(0, 82.000),
                new ChartDataModel(0, 85.250),
                new ChartDataModel(0, 87.750),
                new ChartDataModel(0, 92.000),
                new ChartDataModel(0, 85.250),
                new ChartDataModel(0, 87.750),
                new ChartDataModel(0, 89.000),
                new ChartDataModel(0, 88.275),
                new ChartDataModel(0, 89.750),
                new ChartDataModel(0, 95.750),
                new ChartDataModel(0, 95.250),
            };

			BarData1 = new ObservableCollection<ChartDataModel>
			 {
				new ChartDataModel("Egg", 2.2),
				new ChartDataModel("Fish", 2.4),
				new ChartDataModel("Misc", 3),
				new ChartDataModel("Tea", 3.1),
			 };
			BarData2 = new ObservableCollection<ChartDataModel>
			 {
				new ChartDataModel("Egg", 1.2),
				new ChartDataModel("Fish", 1.3),
				new ChartDataModel("Misc", 1.5),
				new ChartDataModel("Tea", 2.2),
			 };
			AreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2000, 4),
				new ChartDataModel(2001, 3.0),
				new ChartDataModel(2002, 3.8),
				new ChartDataModel(2003, 4.4),
				new ChartDataModel(2004, 3.2),
				new ChartDataModel(2005, 3.9),
			};
			AreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2000, 2.6),
				new ChartDataModel(2001, 2.8),
				new ChartDataModel(2002, 2.6),
				new ChartDataModel(2003, 3),
				new ChartDataModel(2004, 3.6),
				new ChartDataModel(2005, 3),
			};

			SplineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Sun", 15),
				new ChartDataModel("Mon", 22),
				new ChartDataModel("Tue", 32),
				new ChartDataModel("Wed", 31),
				new ChartDataModel("Thu", 29),
				new ChartDataModel("Fri", 26),
				new ChartDataModel("Sat", 18),
			};

			SplineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Sun", 10),
				new ChartDataModel("Mon", 18),
				new ChartDataModel("Tue", 28),
				new ChartDataModel("Wed", 28),
				new ChartDataModel("Thu", 26),
				new ChartDataModel("Fri", 20),
				new ChartDataModel("Sat", 15),
			};
			SplineData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Sun", 2),
				new ChartDataModel("Mon", 12),
				new ChartDataModel("Tue", 22),
				new ChartDataModel("Wed", 23),
				new ChartDataModel("Thu", 19),
				new ChartDataModel("Fri", 13),
				new ChartDataModel("Sat", 8),
			};
			SplineAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2002, 2.2),
				new ChartDataModel(2003, 3.4),
				new ChartDataModel(2004, 2.8),
				new ChartDataModel(2005, 1.6),
				new ChartDataModel(2006, 2.3),
				new ChartDataModel(2007, 2.5),
				new ChartDataModel(2008, 2.9),
				new ChartDataModel(2009, 3.8),
				new ChartDataModel(2010, 1.4),
				new ChartDataModel(2011, 3.1),
			};
			SplineAreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2002, 2.0),
				new ChartDataModel(2003, 1.7),
				new ChartDataModel(2004, 1.8),
				new ChartDataModel(2005, 2.1),
				new ChartDataModel(2006, 2.3),
				new ChartDataModel(2007, 1.7),
				new ChartDataModel(2008, 1.5),
				new ChartDataModel(2009, 2.8),
				new ChartDataModel(2010, 1.5),
				new ChartDataModel(2011, 2.3),
			};
			SplineAreaData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2002, 0.8),
				new ChartDataModel(2003, 1.3),
				new ChartDataModel(2004, 1.1),
				new ChartDataModel(2005, 1.6),
				new ChartDataModel(2006, 2.0),
				new ChartDataModel(2007, 1.7),
				new ChartDataModel(2008, 2.3),
				new ChartDataModel(2009, 2.7),
				new ChartDataModel(2010, 1.1),
				new ChartDataModel(2011, 2.3),
			};
			RangeColumnData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Sun", 10.8, 3.1),
				new ChartDataModel("Mon", 14.4, 5.7),
				new ChartDataModel("Tue", 16.9, 8.4),
				new ChartDataModel("Wed", 19.2, 10.6),
				new ChartDataModel("Thu", 16.1, 8.5),
				new ChartDataModel("Fri", 12.5, 6.0),
				new ChartDataModel("Sat", 6.9, 1.5)
			};
			RangeColumnData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Sun", 9.8, 2.5),
				new ChartDataModel("Mon", 11.4, 4.7),
				new ChartDataModel("Tue", 14.4, 6.4),
				new ChartDataModel("Wed", 17.2, 9.6),
				new ChartDataModel("Thu", 15.1, 7.5),
				new ChartDataModel("Fri", 10.5, 3.0),
				new ChartDataModel("Sat", 7.9, 1.2)
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

            RangeAreaData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 45, 32),
				new ChartDataModel("Feb", 48, 34),
				new ChartDataModel("Mar", 46, 32),
				new ChartDataModel("Apr", 48, 36),
				new ChartDataModel("May", 46, 32),
				new ChartDataModel("Jun", 49, 34)
			};

			RangeAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 30, 18),
				new ChartDataModel("Feb", 24, 12),
				new ChartDataModel("Mar", 29, 15),
				new ChartDataModel("Apr", 24, 10),
				new ChartDataModel("May", 30, 18),
				new ChartDataModel("Jun", 24, 10)
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
				new ChartDataModel("David", 30),
				new ChartDataModel("Steve", 35),
				new ChartDataModel("Micheal", 24),
				new ChartDataModel("John", 11),
				new ChartDataModel("Regev", 25),
				new ChartDataModel("Jack", 39),
				new ChartDataModel("Stephen", 15),
			};
			DoughnutSeriesData = new ObservableCollection<ChartDataModel>
				 {
				new ChartDataModel("Labour", 10),
				new ChartDataModel("Legal", 8),
				new ChartDataModel("Production", 7),
				new ChartDataModel("License", 5),
				new ChartDataModel("Facilities", 10),
				new ChartDataModel("Taxes", 6),
				new ChartDataModel("Insurance", 18)
				};
			PyramidData = new ObservableCollection<ChartDataModel>
			 {
				new ChartDataModel("Sweet Treats", 120),
				new ChartDataModel("Milk, Youghnut, Cheese", 435),
				new ChartDataModel("Vegetables", 470),
				new ChartDataModel("Meat, Poultry, Fish", 475),
				new ChartDataModel("Fruits", 520),
				new ChartDataModel("Bread, Rice, Pasta", 930),
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
				};
			StackedBarData2 = new ObservableCollection<ChartDataModel>
				 {
				new ChartDataModel("Jan", 6),
				new ChartDataModel("Feb", 8),
				new ChartDataModel("Mar", 11),
				new ChartDataModel("Apr", 16),
				new ChartDataModel("May", 21),
				new ChartDataModel("Jun", 25),
				 };
			StackedBarData3 = new ObservableCollection<ChartDataModel>
				 {
				new ChartDataModel("Jan", -1),
				new ChartDataModel("Feb", -1.5),
				new ChartDataModel("Mar", -2),
				new ChartDataModel("Apr", -2.5),
				new ChartDataModel("May", -3),
				new ChartDataModel("Jun", -3.5),
				 };
			StackedBar100Data1 = new ObservableCollection<ChartDataModel>
				 {
				new ChartDataModel("Jan", 6),
				new ChartDataModel("Feb", 8),
				new ChartDataModel("Mar", 12),
				new ChartDataModel("Apr", 15),
				new ChartDataModel("May", 20),
				new ChartDataModel("Jun", 24),
				 };
			StackedBar100Data2 = new ObservableCollection<ChartDataModel>
				 {
				new ChartDataModel("Jan", 6),
				new ChartDataModel("Feb", 8),
				new ChartDataModel("Mar", 11),
				new ChartDataModel("Apr", 16),
				new ChartDataModel("May", 21),
				new ChartDataModel("Jun", 25),
				 };
			StackedBar100Data3 = new ObservableCollection<ChartDataModel>
				 {
				new ChartDataModel("Jan", 1),
				new ChartDataModel("Feb", 1.5),
				new ChartDataModel("Mar", 2),
				new ChartDataModel("Apr", 2.5),
				new ChartDataModel("May", 3),
				new ChartDataModel("Jun", 3.5),
				 };

			StackedColumnData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2014", 111.1),
				new ChartDataModel("2015", 127.3),
				new ChartDataModel("2016", 143.4),
				new ChartDataModel("2017", 159.9)
			};
			StackedColumnData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2014", 76.9),
				new ChartDataModel("2015", 99.5),
				new ChartDataModel("2016", 121.7),
				new ChartDataModel("2017", 142.5)
			};
			StackedColumnData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2014", 66.1),
				new ChartDataModel("2015", 79.3),
				new ChartDataModel("2016", 91.3),
				new ChartDataModel("2017", 102.4)
			};
			StackedColumnData4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2014", 34.1),
				new ChartDataModel("2015", 38.2),
				new ChartDataModel("2016", 44.0),
				new ChartDataModel("2017", 51.6)
			};

			StackedColumn100Data1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 900),
				new ChartDataModel("2007", 544),
				new ChartDataModel("2008", 880),
				new ChartDataModel("2009", 675)
			};
			StackedColumn100Data2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 190),
				new ChartDataModel("2007", 226),
				new ChartDataModel("2008", 194),
				new ChartDataModel("2009", 250)
			};
			StackedColumn100Data3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 250),
				new ChartDataModel("2007", 145),
				new ChartDataModel("2008", 190),
				new ChartDataModel("2009", 220)
			};
			StackedColumn100Data4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 150),
				new ChartDataModel("2007", 120),
				new ChartDataModel("2008", 115),
				new ChartDataModel("2009", 125)
			};

            StackedLineData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Food", 55),
                new ChartDataModel("Transport", 33),
                new ChartDataModel("Medical", 43),
                new ChartDataModel("Clothes", 32),
                new ChartDataModel("Books", 56),
                new ChartDataModel("Others", 23)
            };
            StackedLineData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Food", 40),
                new ChartDataModel("Transport", 45),
                new ChartDataModel("Medical", 23),
                new ChartDataModel("Clothes", 54),
                new ChartDataModel("Books", 18),
                new ChartDataModel("Others", 54)
            };
            StackedLineData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Food", 45),
                new ChartDataModel("Transport", 54),
                new ChartDataModel("Medical", 20),
                new ChartDataModel("Clothes", 23),
                new ChartDataModel("Books", 43),
                new ChartDataModel("Others", 33)
            };
            StackedLineData4 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Food", 48),
                new ChartDataModel("Transport", 28),
                new ChartDataModel("Medical", 34),
                new ChartDataModel("Clothes", 84),
                new ChartDataModel("Books", 55),
                new ChartDataModel("Others", 56)
            };

            StackedLine100Data1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Food", 36),
                new ChartDataModel("Transport", 18),
                new ChartDataModel("Medical", 43),
                new ChartDataModel("Clothes", 32),
                new ChartDataModel("Books", 56),
                new ChartDataModel("Others", 23)
            };
            StackedLine100Data2 = new ObservableCollection<ChartDataModel>
            {
               new ChartDataModel("Food", 40),
                new ChartDataModel("Transport", 45),
                new ChartDataModel("Medical", 23),
                new ChartDataModel("Clothes", 54),
                new ChartDataModel("Books", 48),
                new ChartDataModel("Others", 54)
            };
            StackedLine100Data3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Food", 45),
                new ChartDataModel("Transport", 54),
                new ChartDataModel("Medical", 20),
                new ChartDataModel("Clothes", 73),
                new ChartDataModel("Books", 93),
                new ChartDataModel("Others", 54)
            };
            StackedLine100Data4 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Food", 48),
                new ChartDataModel("Transport", 28),
                new ChartDataModel("Medical", 34),
                new ChartDataModel("Clothes", 84),
                new ChartDataModel("Books", 55),
                new ChartDataModel("Others", 56)
            };

            StackedAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.61),
				new ChartDataModel("2001", 0.81),
				new ChartDataModel("2002", 0.91),
				new ChartDataModel("2003", 1),
				new ChartDataModel("2004", 1.19),
				new ChartDataModel("2005", 1.47),
				new ChartDataModel("2006", 1.74),
				new ChartDataModel("2007", 1.98),
				new ChartDataModel("2008", 1.99),
				new ChartDataModel("2009", 1.70),
				new ChartDataModel("2010", 1.48),
				new ChartDataModel("2011", 1.38),
				new ChartDataModel("2012", 1.66),
				new ChartDataModel("2013", 1.66),
				new ChartDataModel("2014", 1.67),
			};
			StackedAreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.03),
				new ChartDataModel("2001", 0.05),
				new ChartDataModel("2002", 0.06),
				new ChartDataModel("2003", 0.09),
				new ChartDataModel("2004", 0.14),
				new ChartDataModel("2005", 0.20),
				new ChartDataModel("2006", 0.29),
				new ChartDataModel("2007", 0.46),
				new ChartDataModel("2008", 0.64),
				new ChartDataModel("2009", 0.75),
				new ChartDataModel("2010", 1.06),
				new ChartDataModel("2011", 1.25),
				new ChartDataModel("2012", 1.55),
				new ChartDataModel("2013", 1.55),
				new ChartDataModel("2014", 1.65),
			};
			StackedAreaData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.48),
				new ChartDataModel("2001", 0.53),
				new ChartDataModel("2002", 0.57),
				new ChartDataModel("2003", 0.61),
				new ChartDataModel("2004", 0.63),
				new ChartDataModel("2005", 0.64),
				new ChartDataModel("2006", 0.66),
				new ChartDataModel("2007", 0.76),
				new ChartDataModel("2008", 0.77),
				new ChartDataModel("2009", 0.55),
				new ChartDataModel("2010", 0.54),
				new ChartDataModel("2011", 0.57),
				new ChartDataModel("2012", 0.61),
				new ChartDataModel("2013", 0.67),
				new ChartDataModel("2014", 0.67),
			};
			StackedAreaData4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.23),
				new ChartDataModel("2001", 0.17),
				new ChartDataModel("2002", 0.17),
				new ChartDataModel("2003", 0.20),
				new ChartDataModel("2004", 0.23),
				new ChartDataModel("2005", 0.36),
				new ChartDataModel("2006", 0.43),
				new ChartDataModel("2007", 0.52),
				new ChartDataModel("2008", 0.72),
				new ChartDataModel("2009", 1.29),
				new ChartDataModel("2010", 1.38),
				new ChartDataModel("2011", 1.82),
				new ChartDataModel("2012", 2.16),
				new ChartDataModel("2013", 2.51),
				new ChartDataModel("2014", 2.61),
			};
			StackedArea100Data1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.61),
				new ChartDataModel("2001", 0.81),
				new ChartDataModel("2002", 0.91),
				new ChartDataModel("2003", 1),
				new ChartDataModel("2004", 1.19),
				new ChartDataModel("2005", 1.47),
				new ChartDataModel("2006", 1.74),
				new ChartDataModel("2007", 1.98),
				new ChartDataModel("2008", 1.99),
				new ChartDataModel("2009", 1.70),
				new ChartDataModel("2010", 1.48),
				new ChartDataModel("2011", 1.38),
				new ChartDataModel("2012", 1.66),
				new ChartDataModel("2013", 1.66),
				new ChartDataModel("2014", 1.67),
			};
			StackedArea100Data2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.03),
				new ChartDataModel("2001", 0.05),
				new ChartDataModel("2002", 0.06),
				new ChartDataModel("2003", 0.09),
				new ChartDataModel("2004", 0.14),
				new ChartDataModel("2005", 0.20),
				new ChartDataModel("2006", 0.29),
				new ChartDataModel("2007", 0.46),
				new ChartDataModel("2008", 0.64),
				new ChartDataModel("2009", 0.75),
				new ChartDataModel("2010", 1.06),
				new ChartDataModel("2011", 1.25),
				new ChartDataModel("2012", 1.55),
				new ChartDataModel("2013", 1.55),
				new ChartDataModel("2014", 1.65),
			};
			StackedArea100Data3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.48),
				new ChartDataModel("2001", 0.53),
				new ChartDataModel("2002", 0.57),
				new ChartDataModel("2003", 0.61),
				new ChartDataModel("2004", 0.63),
				new ChartDataModel("2005", 0.64),
				new ChartDataModel("2006", 0.66),
				new ChartDataModel("2007", 0.76),
				new ChartDataModel("2008", 0.77),
				new ChartDataModel("2009", 0.55),
				new ChartDataModel("2010", 0.54),
				new ChartDataModel("2011", 0.57),
				new ChartDataModel("2012", 0.61),
				new ChartDataModel("2013", 0.67),
				new ChartDataModel("2014", 0.67),
			};
			StackedArea100Data4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2000", 0.23),
				new ChartDataModel("2001", 0.17),
				new ChartDataModel("2002", 0.17),
				new ChartDataModel("2003", 0.20),
				new ChartDataModel("2004", 0.23),
				new ChartDataModel("2005", 0.36),
				new ChartDataModel("2006", 0.43),
				new ChartDataModel("2007", 0.52),
				new ChartDataModel("2008", 0.72),
				new ChartDataModel("2009", 1.29),
				new ChartDataModel("2010", 1.38),
				new ChartDataModel("2011", 1.82),
				new ChartDataModel("2012", 2.16),
				new ChartDataModel("2013", 2.51),
				new ChartDataModel("2014", 2.61),
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
				new ChartDataModel("Sun", 35 ),
				new ChartDataModel("Mon", 40 ),
				new ChartDataModel("Tue", 80 ),
				new ChartDataModel("Wed", 70 ),
				new ChartDataModel("Thu", 65 ),
				new ChartDataModel("Fri", 55 ),
				new ChartDataModel("Sat", 50 )
			};
			MultipleAxisData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Sun", 30 ),
				new ChartDataModel("Mon", 28 ),
				new ChartDataModel("Tue", 29 ),
				new ChartDataModel("Wed", 30 ),
				new ChartDataModel("Thu", 33 ),
				new ChartDataModel("Fri", 32 ),
				new ChartDataModel("Sat", 34 )
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
				new ChartDataModel(92.2, 7.8, 1.347, "China"),
				new ChartDataModel(74, 6.5, 1.241, "India"),
				new ChartDataModel(90.4, 6.0, 0.238, "Indonesia"),
				new ChartDataModel(99.4, 2.2, 0.312, "US"),
				new ChartDataModel(88.6, 1.3, 0.197, "Brazil"),
				new ChartDataModel(99, 0.7, 0.0818, "Germany"),
				new ChartDataModel(72, 2.0, 0.0826, "Egypt"),
				new ChartDataModel(99.6, 3.4, 0.143, "Russia"),
				new ChartDataModel(99, 0.2, 0.128, "Japan"),
				new ChartDataModel(86.1, 4.0, 0.115, "Mexico"),
				new ChartDataModel(92.6, 6.6, 0.096, "Philippines"),
				new ChartDataModel(61.3, 1.45, 0.162, "Nigeria"),
				new ChartDataModel(82.2, 3.97, 0.7, "Hong Kong"),
				new ChartDataModel(79.2, 3.9,0.162, "Netherland"),
				new ChartDataModel(72.5, 4.5,0.7, "Jordan"),
				new ChartDataModel(81, 3.5, 0.21, "Australia"),
				new ChartDataModel(66.8, 3.9, 0.028, "Mongolia"),
				new ChartDataModel(79.2, 2.9, 0.231, "Taiwan"),

			};

			ScatterMaleData = new ObservableCollection<ChartDataModel>()
			{
				new ChartDataModel(161, 65), new ChartDataModel(150, 65), new ChartDataModel(155, 65), new ChartDataModel(160, 65),
				new ChartDataModel(148, 66), new ChartDataModel(145, 66), new ChartDataModel(137, 66), new ChartDataModel(138, 66),
				new ChartDataModel(162, 66), new ChartDataModel(166, 66), new ChartDataModel(159, 66), new ChartDataModel(151, 66),
				new ChartDataModel(180, 66), new ChartDataModel(181, 66), new ChartDataModel(174, 66), new ChartDataModel(159, 66),
				new ChartDataModel(151, 67), new ChartDataModel(148, 67), new ChartDataModel(141, 67), new ChartDataModel(145, 67),
				new ChartDataModel(165, 67), new ChartDataModel(168, 67), new ChartDataModel(159, 67), new ChartDataModel(183, 67),
				new ChartDataModel(188, 67), new ChartDataModel(187, 67), new ChartDataModel(172, 67), new ChartDataModel(193, 67),
				new ChartDataModel(153, 68), new ChartDataModel(153, 68), new ChartDataModel(147, 68), new ChartDataModel(163, 68),
				new ChartDataModel(174, 68), new ChartDataModel(173, 68), new ChartDataModel(160, 68), new ChartDataModel(191, 68),
				new ChartDataModel(131, 62), new ChartDataModel(140, 62), new ChartDataModel(149, 62), new ChartDataModel(115, 62),
				new ChartDataModel(164, 63), new ChartDataModel(162, 63), new ChartDataModel(167, 63), new ChartDataModel(146, 63),
				new ChartDataModel(150, 64), new ChartDataModel(141, 64), new ChartDataModel(142, 64), new ChartDataModel(129, 64),
				new ChartDataModel(159, 64), new ChartDataModel(158, 64), new ChartDataModel(162, 64), new ChartDataModel(136, 64),
				new ChartDataModel(176, 64), new ChartDataModel(170, 64), new ChartDataModel(167, 64), new ChartDataModel(144, 64),
				new ChartDataModel(143, 65), new ChartDataModel(137, 65), new ChartDataModel(137, 65), new ChartDataModel(140, 65),
				new ChartDataModel(182, 65), new ChartDataModel(168, 65), new ChartDataModel(181, 65), new ChartDataModel(165, 65),
				new ChartDataModel(214, 74), new ChartDataModel(211, 74), new ChartDataModel(166, 74), new ChartDataModel(185, 74),
				new ChartDataModel(189, 68), new ChartDataModel(182, 68), new ChartDataModel(181, 68), new ChartDataModel(196, 68),
				new ChartDataModel(152, 69), new ChartDataModel(173, 69), new ChartDataModel(190, 69), new ChartDataModel(161, 69),
				new ChartDataModel(173, 69), new ChartDataModel(185, 69), new ChartDataModel(141, 69), new ChartDataModel(149, 69),
				new ChartDataModel(134, 62), new ChartDataModel(183, 62), new ChartDataModel(155, 62), new ChartDataModel(164, 62),
				new ChartDataModel(169, 62), new ChartDataModel(122, 62), new ChartDataModel(161, 62), new ChartDataModel(166, 62),
				new ChartDataModel(137, 63), new ChartDataModel(140, 63), new ChartDataModel(140, 63), new ChartDataModel(126, 63),
				new ChartDataModel(150, 63), new ChartDataModel(153, 63), new ChartDataModel(154, 63), new ChartDataModel(139, 63),
				new ChartDataModel(186, 69), new ChartDataModel(188, 69), new ChartDataModel(148, 69), new ChartDataModel(174, 69),
				new ChartDataModel(164, 70), new ChartDataModel(182, 70), new ChartDataModel(200, 70), new ChartDataModel(151, 70),
				new ChartDataModel(204, 74), new ChartDataModel(177, 74), new ChartDataModel(194, 74), new ChartDataModel(212, 74),
				new ChartDataModel(162, 70), new ChartDataModel(200, 70), new ChartDataModel(166, 70), new ChartDataModel(177, 70),
				new ChartDataModel(188, 70), new ChartDataModel(156, 70), new ChartDataModel(175, 70), new ChartDataModel(191, 70),
				new ChartDataModel(174, 71), new ChartDataModel(187, 71), new ChartDataModel(208, 71), new ChartDataModel(166, 71),
				new ChartDataModel(150, 71), new ChartDataModel(194, 71), new ChartDataModel(157, 71), new ChartDataModel(183, 71),
				new ChartDataModel(204, 71), new ChartDataModel(162, 71), new ChartDataModel(179, 71), new ChartDataModel(196, 71),
				new ChartDataModel(170, 72), new ChartDataModel(184, 72), new ChartDataModel(197, 72), new ChartDataModel(162, 72),
				new ChartDataModel(177, 72), new ChartDataModel(203, 72), new ChartDataModel(159, 72), new ChartDataModel(178, 72),
				new ChartDataModel(198, 72), new ChartDataModel(167, 72), new ChartDataModel(184, 72), new ChartDataModel(201, 72),
				new ChartDataModel(167, 73), new ChartDataModel(178, 73), new ChartDataModel(215, 73), new ChartDataModel(207, 73),
				new ChartDataModel(172, 73), new ChartDataModel(204, 73), new ChartDataModel(162, 73), new ChartDataModel(182, 73),
				new ChartDataModel(201, 73), new ChartDataModel(172, 73), new ChartDataModel(189, 73), new ChartDataModel(206, 73),
				new ChartDataModel(150, 74), new ChartDataModel(187, 74), new ChartDataModel(153, 74), new ChartDataModel(171, 74),
			};

			ScatterFemaleData = new ObservableCollection<ChartDataModel>()
			{
				new ChartDataModel(115, 57 ), new ChartDataModel(138, 57 ), new ChartDataModel(166, 57 ), new ChartDataModel(122,  57 ),
				new ChartDataModel(126, 57 ), new ChartDataModel(130, 57 ), new ChartDataModel(125, 57 ), new ChartDataModel(144,  57 ),
				new ChartDataModel(150, 57 ), new ChartDataModel(120, 57 ), new ChartDataModel(125, 57 ), new ChartDataModel(130,  57 ),
				new ChartDataModel(103, 58 ), new ChartDataModel(116, 58 ), new ChartDataModel(130, 58 ), new ChartDataModel(126,  58 ),
				new ChartDataModel(136, 58 ), new ChartDataModel(148, 58 ), new ChartDataModel(119, 58 ), new ChartDataModel(141,  58 ),
				new ChartDataModel(159, 58 ), new ChartDataModel(120, 58 ), new ChartDataModel(135, 58 ), new ChartDataModel(163,  58 ),
				new ChartDataModel(119, 59 ), new ChartDataModel(131, 59 ), new ChartDataModel(148, 59 ), new ChartDataModel(123,  59 ),
				new ChartDataModel(137, 59 ), new ChartDataModel(149, 59 ), new ChartDataModel(121, 59 ), new ChartDataModel(142,  59 ),
				new ChartDataModel(160, 59 ), new ChartDataModel(118, 59 ), new ChartDataModel(130, 59 ), new ChartDataModel(146,  59 ),
				new ChartDataModel(119, 60 ), new ChartDataModel(133, 60 ), new ChartDataModel(150, 60 ), new ChartDataModel(133,  60 ),
				new ChartDataModel(149, 60 ), new ChartDataModel(165, 60 ), new ChartDataModel(130, 60 ), new ChartDataModel(139,  60 ),
				new ChartDataModel(154, 60 ), new ChartDataModel(118, 60 ), new ChartDataModel(152, 60 ), new ChartDataModel(154,  60 ),
				new ChartDataModel(130, 61 ), new ChartDataModel(145, 61 ), new ChartDataModel(166, 61 ), new ChartDataModel(131,  61 ),
				new ChartDataModel(143, 61 ), new ChartDataModel(162, 61 ), new ChartDataModel(131, 61 ), new ChartDataModel(145,  61 ),
				new ChartDataModel(162, 61 ), new ChartDataModel(115, 61 ), new ChartDataModel(149, 61 ), new ChartDataModel(183,  61 ),
				new ChartDataModel(121, 62 ), new ChartDataModel(139, 62 ), new ChartDataModel(159, 62 ), new ChartDataModel(135,  62 ),
				new ChartDataModel(152, 62 ), new ChartDataModel(178, 62 ), new ChartDataModel(130, 62 ), new ChartDataModel(153,  62 ),
				new ChartDataModel(172, 62 ), new ChartDataModel(114, 62 ), new ChartDataModel(135, 62 ), new ChartDataModel(154,  62 ),
				new ChartDataModel(126, 63 ), new ChartDataModel(141, 63 ), new ChartDataModel(160, 63 ), new ChartDataModel(135,  63 ),
				new ChartDataModel(149, 63 ), new ChartDataModel(180, 63 ), new ChartDataModel(132, 63 ), new ChartDataModel(144,  63 ),
				new ChartDataModel(163, 63 ), new ChartDataModel(122, 63 ), new ChartDataModel(146, 63 ), new ChartDataModel(156,  63 ),
				new ChartDataModel(133, 64 ), new ChartDataModel(150, 64 ), new ChartDataModel(176, 64 ), new ChartDataModel(133,  64 ),
				new ChartDataModel(149, 64 ), new ChartDataModel(176, 64 ), new ChartDataModel(136, 64 ), new ChartDataModel(157,  64 ),
				new ChartDataModel(174, 64 ), new ChartDataModel(131, 64 ), new ChartDataModel(155, 64 ), new ChartDataModel(191,  64 ),
				new ChartDataModel(136, 65 ), new ChartDataModel(149, 65 ), new ChartDataModel(177, 65 ), new ChartDataModel(143,  65 ),
				new ChartDataModel(149, 65 ), new ChartDataModel(184, 65 ), new ChartDataModel(128, 65 ), new ChartDataModel(146,  65 ),
				new ChartDataModel(157, 65 ), new ChartDataModel(133, 65 ), new ChartDataModel(153, 65 ), new ChartDataModel(173,  65 ),
				new ChartDataModel(141, 66 ), new ChartDataModel(156, 66 ), new ChartDataModel(175, 66 ), new ChartDataModel(125,  66 ),
				new ChartDataModel(138, 66 ), new ChartDataModel(165, 66 ), new ChartDataModel(122, 66 ), new ChartDataModel(164,  66 ),
				new ChartDataModel(182, 66 ), new ChartDataModel(137, 66 ), new ChartDataModel(157, 66 ), new ChartDataModel(176,  66 ),
				new ChartDataModel(149, 67 ), new ChartDataModel(159, 67 ), new ChartDataModel(179, 67 ), new ChartDataModel(156,  67 ),
				new ChartDataModel(179, 67 ), new ChartDataModel(186, 67 ), new ChartDataModel(147, 67 ), new ChartDataModel(166,  67 ),
				new ChartDataModel(185, 67 ), new ChartDataModel(140, 67 ), new ChartDataModel(160, 67 ), new ChartDataModel(180,  67 ),
				new ChartDataModel(145, 68 ), new ChartDataModel(155, 68 ), new ChartDataModel(170, 68 ), new ChartDataModel(129,  68 ),
				new ChartDataModel(164, 68 ), new ChartDataModel(189, 68 ), new ChartDataModel(150, 68 ), new ChartDataModel(157,  68 ),
				new ChartDataModel(183, 68 ), new ChartDataModel(144, 68 ), new ChartDataModel(170, 68 ), new ChartDataModel(180,  68 )
			};

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
                new ChartDataModel("South Korea", 39),
                new ChartDataModel("India", 20),
                new ChartDataModel("South Africa", 61),
                new ChartDataModel("China", 65),
                new ChartDataModel("France", 45),
                new ChartDataModel("Saudi Arabia", 10),
                new ChartDataModel("Japan", 16),
                new ChartDataModel("Mexico", 31)
			 };

			LogarithmicData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("1995", 80   ),
				new ChartDataModel("1996", 200  ),
				new ChartDataModel("1997", 400  ),
				new ChartDataModel("1998", 600  ),
				new ChartDataModel("1999", 700  ),
				new ChartDataModel("2000", 1400 ),
				new ChartDataModel("2001", 2000 ),
				new ChartDataModel("2002", 4000 ),
				new ChartDataModel("2003", 6000 ),
				new ChartDataModel("2004", 8000 ),
				new ChartDataModel("2005", 11000)
			};

			NumericData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(16, 2 ),
				new ChartDataModel(17, 14),
				new ChartDataModel(18, 7 ),
				new ChartDataModel(19, 7 ),
				new ChartDataModel(20, 10),
			};

			NumericData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(16, 7 ),
				new ChartDataModel(17, 7 ),
				new ChartDataModel(18, 11),
				new ChartDataModel(19, 8 ),
				new ChartDataModel(20, 24),
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


			DataMarkerData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2013", 1110),
				new ChartDataModel("2014", 1130),
				new ChartDataModel("2015", 1153),
				new ChartDataModel("2016", 1175),
			};

			DataMarkerData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2013", 1070),
				new ChartDataModel("2014", 1105),
				new ChartDataModel("2015", 1138),
				new ChartDataModel("2016", 1155),
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

            SelectionData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Jan", 38),
                new ChartDataModel("Feb", 40),
                new ChartDataModel("Mar", 60),
                new ChartDataModel("Apr", 60),
                new ChartDataModel("May", 80),
                new ChartDataModel("Jun", 77)
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

			LineSeries1 = new ObservableCollection<ChartDataModel>()
			{
				new ChartDataModel(new DateTime(2000, 2, 11), 15),
				new ChartDataModel(new DateTime(2000, 9, 14), 20),
				new ChartDataModel(new DateTime(2001, 2, 11), 25),
				new ChartDataModel(new DateTime(2001, 9, 16), 21),
				new ChartDataModel(new DateTime(2002, 2, 07), 13),
				new ChartDataModel(new DateTime(2002, 9, 07), 18),
				new ChartDataModel(new DateTime(2003, 2, 11), 24),
				new ChartDataModel(new DateTime(2003, 9, 14), 23),
				new ChartDataModel(new DateTime(2004, 2, 06), 19),
				new ChartDataModel(new DateTime(2004, 9, 06), 31),
				new ChartDataModel(new DateTime(2005, 2, 11), 39),
				new ChartDataModel(new DateTime(2005, 9, 11), 50),
				new ChartDataModel(new DateTime(2006, 2, 11), 24)
			};

			LineSeries2 = new ObservableCollection<ChartDataModel>()
			{
				new ChartDataModel(new DateTime(2000, 2, 11), 39),
				new ChartDataModel(new DateTime(2000, 9, 14), 30),
				new ChartDataModel(new DateTime(2001, 2, 11), 28),
				new ChartDataModel(new DateTime(2001, 9, 16), 35),
				new ChartDataModel(new DateTime(2002, 2, 07), 39),
				new ChartDataModel(new DateTime(2002, 9, 07), 41),
				new ChartDataModel(new DateTime(2003, 2, 11), 45),
				new ChartDataModel(new DateTime(2003, 9, 14), 48),
				new ChartDataModel(new DateTime(2004, 2, 06), 54),
				new ChartDataModel(new DateTime(2004, 9, 06), 55),
				new ChartDataModel(new DateTime(2005, 2, 11), 57),
				new ChartDataModel(new DateTime(2005, 9, 11), 60),
				new ChartDataModel(new DateTime(2006, 2, 11), 60)
			};

			LineSeries3 = new ObservableCollection<ChartDataModel>()
			{
				new ChartDataModel(new DateTime(2000, 2, 11), 60),
				new ChartDataModel(new DateTime(2000, 9, 14), 55),
				new ChartDataModel(new DateTime(2001, 2, 11), 48),
				new ChartDataModel(new DateTime(2001, 9, 16), 57),
				new ChartDataModel(new DateTime(2002, 2, 07), 62),
				new ChartDataModel(new DateTime(2002, 9, 07), 64),
				new ChartDataModel(new DateTime(2003, 2, 11), 57),
				new ChartDataModel(new DateTime(2003, 9, 14), 53),
				new ChartDataModel(new DateTime(2004, 2, 06), 63),
				new ChartDataModel(new DateTime(2004, 9, 06), 50),
				new ChartDataModel(new DateTime(2005, 2, 11), 66),
				new ChartDataModel(new DateTime(2005, 9, 11), 65),
				new ChartDataModel(new DateTime(2006, 2, 11), 79)
			};

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


        public static ObservableCollection<ChartDataModel> GetTrendlineDataSource1(string type)
        {
            var date = new DateTime(2019, 03, 01);
            int x = 20;
            if (type == "Linear")
            {

                var linearDataCollection = new ObservableCollection<ChartDataModel>();

                for (int i = 0; i < 8; i++)
                {
                    linearDataCollection.Add(new ChartDataModel(date, x));
                    x += 5;
                    date = date.AddMonths(1);
                }

                return linearDataCollection;
            }
            else if (type == "Exponential")
            {
                var exponentialDataCollection = new ObservableCollection<ChartDataModel>();
                date = new DateTime(2019, 03, 01);
                x = 250;
                for (int i = 0; i < 8; i++)
                {
                    exponentialDataCollection.Add(new ChartDataModel(date, x));
                    x += 50;
                    date = date.AddMonths(1);
                }
                return exponentialDataCollection;
            }
            else if (type == "Logarithmic")
            {
                date = new DateTime(2019, 03, 30);
                var logarithmicDataCollection = new ObservableCollection<ChartDataModel>()
                {
                new ChartDataModel(date, 98),
                new ChartDataModel(date.AddMonths(1),110),
                new ChartDataModel(date.AddMonths(2),200),
                new ChartDataModel(date.AddMonths(3),250),
                new ChartDataModel(date.AddMonths(4),289),
                new ChartDataModel(date.AddMonths(5),300),
                new ChartDataModel(date.AddMonths(6),310),
                new ChartDataModel(date.AddMonths(7),330),
                };
                return logarithmicDataCollection;
            }

            date = new DateTime(2019, 3, 01);
            var polynomialDataCollection = new ObservableCollection<ChartDataModel>()
            {
                new ChartDataModel(date, 55),
                new ChartDataModel(date.AddMonths(1), 135),
                new ChartDataModel(date.AddMonths(2),128),
                new ChartDataModel(date.AddMonths(3),120),
                new ChartDataModel(date.AddMonths(4),135),
                new ChartDataModel(date.AddMonths(5),98),
                new ChartDataModel(date.AddMonths(6),120),
                new ChartDataModel(date.AddMonths(7),85),
            };

            return polynomialDataCollection;

        }

        public static ObservableCollection<ChartDataModel> GetTrendlineDataSource2()
        {
            var PowerDataCollection = new ObservableCollection<ChartDataModel>();
            PowerDataCollection.Add(new ChartDataModel(1, 10));
            PowerDataCollection.Add(new ChartDataModel(2, 50));
            PowerDataCollection.Add(new ChartDataModel(3, 80));
            PowerDataCollection.Add(new ChartDataModel(4, 110));
            PowerDataCollection.Add(new ChartDataModel(5, 180));
            PowerDataCollection.Add(new ChartDataModel(6, 220));
            PowerDataCollection.Add(new ChartDataModel(7, 300));
            PowerDataCollection.Add(new ChartDataModel(8, 370));

            return PowerDataCollection;
        }
    }
}
