#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Graphics;
using Com.Syncfusion.Charts;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class DataPoint
    {
        public DataPoint(object xVal, double yVal)
        {
            XValue = xVal;
            YValue = yVal;
        }

        public DataPoint(DateTime xVal, double yVal)
        {
            Date = xVal;
            YValue = yVal;
        }

        public DataPoint(object xVal, double high, double low)
        {
            XValue = xVal;
            YValue = High = high;
            Size = Low = low;
        }

        public DataPoint(object xVal, double high, double low, string label)
        {
            XValue = xVal;
            YValue = High = high;
            Size = Low = low;
            Label = label;
        }

        public DataPoint(double high, double low, DateTime dateTime)
        {
            High = high;
            Low = low;
            Date = dateTime;
        }

        public DataPoint(object xVal, double open, double high, double low, double close)
        {
            XValue = xVal;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public DataPoint(object xVal, double open, double high, double low, double close, double volume)
        {
            XValue = xVal;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

        public object XValue { get; set; }

        public double YValue { get; set; }

        public double Size { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public double Close { get; set; }

        public double Volume { get; set; }

        public DateTime Date { get; set; }

        public string Label { get; set; }
    }

    public class MainPage
    {
        public static List<DataPoint> GetAreaData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 45));
            datas.Add(new DataPoint("2011", 56));
            datas.Add(new DataPoint("2012", 23));
            datas.Add(new DataPoint("2013", 43));
            datas.Add(new DataPoint("2014", Double.NaN));
            datas.Add(new DataPoint("2015", 54));
            datas.Add(new DataPoint("2016", 43));
            datas.Add(new DataPoint("2017", 23));
            datas.Add(new DataPoint("2018", 34));
            return datas;
        }

        public static List<DataPoint> GetDataMarkerData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2013", 1110));
            datas.Add(new DataPoint("2014", 1130));
            datas.Add(new DataPoint("2015", 1153));
            datas.Add(new DataPoint("2016", 1175));
            return datas;
        }

        public static List<DataPoint> GetDataMarkerData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2013", 1070));
            datas.Add(new DataPoint("2014", 1105));
            datas.Add(new DataPoint("2015", 1138));
            datas.Add(new DataPoint("2016", 1155));
            return datas;
        }
        public static List<DataPoint> GetStepAreaData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2000, 416));
            datas.Add(new DataPoint(2001, 490));
            datas.Add(new DataPoint(2002, 470));
            datas.Add(new DataPoint(2003, 500));
            datas.Add(new DataPoint(2004, 449));
            datas.Add(new DataPoint(2005, 470));
            datas.Add(new DataPoint(2006, 437));
            datas.Add(new DataPoint(2007, 458));
            datas.Add(new DataPoint(2008, 500));
            datas.Add(new DataPoint(2009, 473));
            datas.Add(new DataPoint(2010, 520));
            datas.Add(new DataPoint(2011, 509));
            return datas;
        }

        public static List<DataPoint> GetStepAreaData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2000, 180));
            datas.Add(new DataPoint(2001, 240));
            datas.Add(new DataPoint(2002, 370));
            datas.Add(new DataPoint(2003, 200));
            datas.Add(new DataPoint(2004, 229));
            datas.Add(new DataPoint(2005, 210));
            datas.Add(new DataPoint(2006, 337));
            datas.Add(new DataPoint(2007, 258));
            datas.Add(new DataPoint(2008, 300));
            datas.Add(new DataPoint(2009, 173));
            datas.Add(new DataPoint(2010, 220));
            datas.Add(new DataPoint(2011, 309));
            return datas;
        }

        public static List<DataPoint> GetStepAreaData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2006, 463));
            datas.Add(new DataPoint(2007, 449));
            datas.Add(new DataPoint(2008, 458));
            datas.Add(new DataPoint(2009, 450));
            datas.Add(new DataPoint(2010, 435));
            datas.Add(new DataPoint(2011, 420));
            return datas;
        }

        public static List<DataPoint> GetStripLineData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sun", 26));
            datas.Add(new DataPoint("Mon", 24));
            datas.Add(new DataPoint("Tue", 31));
            datas.Add(new DataPoint("Wed", 28));
            datas.Add(new DataPoint("Thu", 30));
            datas.Add(new DataPoint("Fri", 26));
            datas.Add(new DataPoint("Sat", 30));

            return datas;
        }

        public static List<DataPoint> GetData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 45));
            datas.Add(new DataPoint("2011", 89));
            datas.Add(new DataPoint("2012", 23));
            datas.Add(new DataPoint("2013", 43));
            datas.Add(new DataPoint("2014", 54));
            return datas;
        }
        public static List<DataPoint> GetLogarithmicData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("1995", 80));
            datas.Add(new DataPoint("1996", 200));
            datas.Add(new DataPoint("1997", 400));
            datas.Add(new DataPoint("1998", 600));
            datas.Add(new DataPoint("1999", 700));
            datas.Add(new DataPoint("2000", 1400));
            datas.Add(new DataPoint("2001", 2000));
            datas.Add(new DataPoint("2002", 4000));
            datas.Add(new DataPoint("2003", 6000));
            datas.Add(new DataPoint("2004", 8000));
            datas.Add(new DataPoint("2005", 11000));
            return datas;
        }
        public static List<DataPoint> GetLineData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2005", 21));
            datas.Add(new DataPoint("2006", 24));
            datas.Add(new DataPoint("2007", 36));
            datas.Add(new DataPoint("2008", 38));
            datas.Add(new DataPoint("2009", 54));
            datas.Add(new DataPoint("2010", 57));
            datas.Add(new DataPoint("2011", 70));
            return datas;
        }
        public static List<DataPoint> GetLineData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2005", 28));
            datas.Add(new DataPoint("2006", 44));
            datas.Add(new DataPoint("2007", 48));
            datas.Add(new DataPoint("2008", 50));
            datas.Add(new DataPoint("2009", 66));
            datas.Add(new DataPoint("2010", 78));
            datas.Add(new DataPoint("2011", 84));
            return datas;
        }

        public static List<DataPoint> GetStackingLineData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 55));
            datas.Add(new DataPoint("Transport", 33));
            datas.Add(new DataPoint("Medical", 43));
            datas.Add(new DataPoint("Clothes", 32));
            datas.Add(new DataPoint("Books", 56));
            datas.Add(new DataPoint("Others", 23));
            return datas;
        }
        public static List<DataPoint> GetStackingLineData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 40));
            datas.Add(new DataPoint("Transport", 45));
            datas.Add(new DataPoint("Medical", 23));
            datas.Add(new DataPoint("Clothes", 54));
            datas.Add(new DataPoint("Books", 18));
            datas.Add(new DataPoint("Others", 54));
            return datas;
        }
        public static List<DataPoint> GetStackingLineData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 45));
            datas.Add(new DataPoint("Transport", 54));
            datas.Add(new DataPoint("Medical", 20));
            datas.Add(new DataPoint("Clothes", 23));
            datas.Add(new DataPoint("Books", 43));
            datas.Add(new DataPoint("Others", 33));
            return datas;
        }
        public static List<DataPoint> GetStackingLineData4()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 48));
            datas.Add(new DataPoint("Transport", 28));
            datas.Add(new DataPoint("Medical", 34));
            datas.Add(new DataPoint("Clothes", 84));
            datas.Add(new DataPoint("Books", 55));
            datas.Add(new DataPoint("Others", 56));
            return datas;
        }

        public static List<DataPoint> GetColumnData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("USA", 46));
            datas.Add(new DataPoint("GBR", 27));
            datas.Add(new DataPoint("CHN", 26));
            return datas;
        }

        public static ObservableCollection<DataPoint> GetTrendlineDataSource(string type)
        {
            var date = new DateTime(2019, 03, 01);
            int x = 20;
            if (type == "Linear")
            {
                var linearDataCollection = new ObservableCollection<DataPoint>();

                for (int i = 0; i < 8; i++)
                {
                    linearDataCollection.Add(new DataPoint(date, x));
                    x += 5;
                    date = date.AddMonths(1);
                }

                return linearDataCollection;
            }
            else if (type == "Exponential")
            {
                var exponentialDataCollection = new ObservableCollection<DataPoint>();
                date = new DateTime(2019, 03, 01);
                x = 250;
                for (int i = 0; i < 8; i++)
                {
                    exponentialDataCollection.Add(new DataPoint(date, x));
                    x += 50;
                    date = date.AddMonths(1);
                }
                return exponentialDataCollection;
            }
            else if (type == "Logarithmic")
            {
                date = new DateTime(2019, 03, 30);
                var logarithmicDataCollection = new ObservableCollection<DataPoint>()
                {
                new DataPoint(date, 98),
                new DataPoint(date.AddMonths(1),110),
                new DataPoint(date.AddMonths(2),200),
                new DataPoint(date.AddMonths(3),250),
                new DataPoint(date.AddMonths(4),289),
                new DataPoint(date.AddMonths(5),300),
                new DataPoint(date.AddMonths(6),310),
                new DataPoint(date.AddMonths(7),330),
                };
                return logarithmicDataCollection;
            }

            date = new DateTime(2019, 3, 01);
            var polynomialDataCollection = new ObservableCollection<DataPoint>()
            {
                new DataPoint(date, 55),
                new DataPoint(date.AddMonths(1), 135),
                new DataPoint(date.AddMonths(2),128),
                new DataPoint(date.AddMonths(3),120),
                new DataPoint(date.AddMonths(4),135),
                new DataPoint(date.AddMonths(5),98),
                new DataPoint(date.AddMonths(6),120),
                new DataPoint(date.AddMonths(7),85),
            };

            return polynomialDataCollection;
        }

        public static ObservableCollection<DataPoint> GetPowerTrendlineDataSource()
        {
            var PowerDataCollection = new ObservableCollection<DataPoint>();
            PowerDataCollection.Add(new DataPoint(1, 10));
            PowerDataCollection.Add(new DataPoint(2, 50));
            PowerDataCollection.Add(new DataPoint(3, 80));
            PowerDataCollection.Add(new DataPoint(4, 110));
            PowerDataCollection.Add(new DataPoint(5, 180));
            PowerDataCollection.Add(new DataPoint(6, 220));
            PowerDataCollection.Add(new DataPoint(7, 300));
            PowerDataCollection.Add(new DataPoint(8, 370));

            return PowerDataCollection;
        }

        public static List<DataPoint> GetColumnData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("USA", 37));
            datas.Add(new DataPoint("GBR", 23));
            datas.Add(new DataPoint("CHN", 18));
            return datas;
        }
        public static List<DataPoint> GetColumnData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("USA", 38));
            datas.Add(new DataPoint("GBR", 17));
            datas.Add(new DataPoint("CHN", 26));
            return datas;
        }

        public static List<DataPoint> GetHistogramData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(0, 5.250));
            datas.Add(new DataPoint(0, 7.750));
            datas.Add(new DataPoint(0, 0));
            datas.Add(new DataPoint(0, 8.275));
            datas.Add(new DataPoint(0, 9.750));
            datas.Add(new DataPoint(0, 7.750));
            datas.Add(new DataPoint(0, 8.275));
            datas.Add(new DataPoint(0, 6.250));
            datas.Add(new DataPoint(0, 5.750));
            datas.Add(new DataPoint(0, 5.250));
            datas.Add(new DataPoint(0, 23.000));
            datas.Add(new DataPoint(0, 26.500));
            datas.Add(new DataPoint(0, 27.750));
            datas.Add(new DataPoint(0, 25.025));
            datas.Add(new DataPoint(0, 26.500));
            datas.Add(new DataPoint(0, 26.500));
            datas.Add(new DataPoint(0, 28.025));
            datas.Add(new DataPoint(0, 29.250));
            datas.Add(new DataPoint(0, 26.750));
            datas.Add(new DataPoint(0, 27.250));
            datas.Add(new DataPoint(0, 26.250));
            datas.Add(new DataPoint(0, 25.250));
            datas.Add(new DataPoint(0, 34.500));
            datas.Add(new DataPoint(0, 25.625));
            datas.Add(new DataPoint(0, 25.500));
            datas.Add(new DataPoint(0, 26.625));
            datas.Add(new DataPoint(0, 36.275));
            datas.Add(new DataPoint(0, 36.250));
            datas.Add(new DataPoint(0, 26.875));
            datas.Add(new DataPoint(0, 45.000));
            datas.Add(new DataPoint(0, 43.000));
            datas.Add(new DataPoint(0, 46.500));
            datas.Add(new DataPoint(0, 47.750));
            datas.Add(new DataPoint(0, 45.025));
            datas.Add(new DataPoint(0, 56.500));
            datas.Add(new DataPoint(0, 56.500));
            datas.Add(new DataPoint(0, 58.025));
            datas.Add(new DataPoint(0, 59.250));
            datas.Add(new DataPoint(0, 56.750));
            datas.Add(new DataPoint(0, 57.250));
            datas.Add(new DataPoint(0, 46.250));
            datas.Add(new DataPoint(0, 55.250));
            datas.Add(new DataPoint(0, 44.500));
            datas.Add(new DataPoint(0, 45.500));
            datas.Add(new DataPoint(0, 55.500));
            datas.Add(new DataPoint(0, 45.625));
            datas.Add(new DataPoint(0, 55.500));
            datas.Add(new DataPoint(0, 56.250));
            datas.Add(new DataPoint(0, 46.875));
            datas.Add(new DataPoint(0, 43.000));
            datas.Add(new DataPoint(0, 46.250));
            datas.Add(new DataPoint(0, 55.250));
            datas.Add(new DataPoint(0, 44.500));
            datas.Add(new DataPoint(0, 45.425));
            datas.Add(new DataPoint(0, 56.625));
            datas.Add(new DataPoint(0, 46.275));
            datas.Add(new DataPoint(0, 56.250));
            datas.Add(new DataPoint(0, 46.875));
            datas.Add(new DataPoint(0, 43.000));
            datas.Add(new DataPoint(0, 46.250));
            datas.Add(new DataPoint(0, 55.250));
            datas.Add(new DataPoint(0, 44.500));
            datas.Add(new DataPoint(0, 45.425));
            datas.Add(new DataPoint(0, 55.500));
            datas.Add(new DataPoint(0, 46.625));
            datas.Add(new DataPoint(0, 56.275));
            datas.Add(new DataPoint(0, 46.250));
            datas.Add(new DataPoint(0, 56.250));
            datas.Add(new DataPoint(0, 42.000));
            datas.Add(new DataPoint(0, 41.000));
            datas.Add(new DataPoint(0, 63.000));
            datas.Add(new DataPoint(0, 66.500));
            datas.Add(new DataPoint(0, 67.750));
            datas.Add(new DataPoint(0, 65.025));
            datas.Add(new DataPoint(0, 66.500));
            datas.Add(new DataPoint(0, 76.500));
            datas.Add(new DataPoint(0, 78.025));
            datas.Add(new DataPoint(0, 79.250));
            datas.Add(new DataPoint(0, 76.750));
            datas.Add(new DataPoint(0, 77.250));
            datas.Add(new DataPoint(0, 66.250));
            datas.Add(new DataPoint(0, 75.250));
            datas.Add(new DataPoint(0, 74.500));
            datas.Add(new DataPoint(0, 65.625));
            datas.Add(new DataPoint(0, 75.500));
            datas.Add(new DataPoint(0, 76.625));
            datas.Add(new DataPoint(0, 76.275));
            datas.Add(new DataPoint(0, 66.250));
            datas.Add(new DataPoint(0, 66.875));
            datas.Add(new DataPoint(0, 82.000));
            datas.Add(new DataPoint(0, 85.250));
            datas.Add(new DataPoint(0, 87.750));
            datas.Add(new DataPoint(0, 92.000));
            datas.Add(new DataPoint(0, 85.250));
            datas.Add(new DataPoint(0, 87.750));
            datas.Add(new DataPoint(0, 89.000));
            datas.Add(new DataPoint(0, 88.275));
            datas.Add(new DataPoint(0, 89.750));
            datas.Add(new DataPoint(0, 95.750));
            datas.Add(new DataPoint(0, 95.250));
            return datas;
        }

        public static List<DataPoint> GetBarData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Egg", 2.2));
            datas.Add(new DataPoint("Fish", 2.4));
            datas.Add(new DataPoint("Misc", 3));
            datas.Add(new DataPoint("Tea", 3.1));
            return datas;
        }
        public static List<DataPoint> GetBarData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Egg", 1.2));
            datas.Add(new DataPoint("Fish", 1.3));
            datas.Add(new DataPoint("Misc", 1.5));
            datas.Add(new DataPoint("Tea", 2.2));
            return datas;
        }
        public static List<DataPoint> GetAreaData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2000, 4));
            datas.Add(new DataPoint(2001, 3.0));
            datas.Add(new DataPoint(2002, 3.8));
            datas.Add(new DataPoint(2003, 4.4));
            datas.Add(new DataPoint(2004, 3.2));
            datas.Add(new DataPoint(2005, 3.9));
            return datas;
        }

        public static List<DataPoint> GetAreaData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2000, 2.6));
            datas.Add(new DataPoint(2001, 2.8));
            datas.Add(new DataPoint(2002, 2.6));
            datas.Add(new DataPoint(2003, 3));
            datas.Add(new DataPoint(2004, 3.6));
            datas.Add(new DataPoint(2005, 3));
            return datas;
        }

        public static List<DataPoint> GetAreaData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(1900, 2.8));
            datas.Add(new DataPoint(1920, 2.5));
            datas.Add(new DataPoint(1940, 2.8));
            datas.Add(new DataPoint(1960, 3.0));
            datas.Add(new DataPoint(1980, 2.9));
            datas.Add(new DataPoint(2000, 2.0));
            return datas;
        }
        public static List<DataPoint> GetSplineAreaData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2002, 2.2));
            datas.Add(new DataPoint(2003, 3.4));
            datas.Add(new DataPoint(2004, 2.8));
            datas.Add(new DataPoint(2005, 1.6));
            datas.Add(new DataPoint(2006, 2.3));
            datas.Add(new DataPoint(2007, 2.5));
            datas.Add(new DataPoint(2008, 2.9));
            datas.Add(new DataPoint(2009, 3.8));
            datas.Add(new DataPoint(2010, 1.4));
            datas.Add(new DataPoint(2011, 3.1));
            return datas;
        }

        public static List<DataPoint> GetSplineAreaData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2002, 2.0));
            datas.Add(new DataPoint(2003, 1.7));
            datas.Add(new DataPoint(2004, 1.8));
            datas.Add(new DataPoint(2005, 2.1));
            datas.Add(new DataPoint(2006, 2.3));
            datas.Add(new DataPoint(2007, 1.7));
            datas.Add(new DataPoint(2008, 1.5));
            datas.Add(new DataPoint(2009, 2.8));
            datas.Add(new DataPoint(2010, 1.5));
            datas.Add(new DataPoint(2011, 2.3));
            return datas;
        }

        public static List<DataPoint> GetSplineAreaData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2002, 0.8));
            datas.Add(new DataPoint(2003, 1.3));
            datas.Add(new DataPoint(2004, 1.1));
            datas.Add(new DataPoint(2005, 1.6));
            datas.Add(new DataPoint(2006, 2.0));
            datas.Add(new DataPoint(2007, 1.7));
            datas.Add(new DataPoint(2008, 2.3));
            datas.Add(new DataPoint(2009, 2.7));
            datas.Add(new DataPoint(2010, 1.1));
            datas.Add(new DataPoint(2011, 2.3));
            return datas;
        }
        public static List<DataPoint> GetSplineData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sun", 15));
            datas.Add(new DataPoint("Mon", 22));
            datas.Add(new DataPoint("Tue", 32));
            datas.Add(new DataPoint("Wed", 31));
            datas.Add(new DataPoint("Thu", 29));
            datas.Add(new DataPoint("Fri", 26));
            datas.Add(new DataPoint("Sat", 18));
            return datas;
        }
        public static List<DataPoint> GetSplineData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sun", 10));
            datas.Add(new DataPoint("Mon", 18));
            datas.Add(new DataPoint("Tue", 28));
            datas.Add(new DataPoint("Wed", 28));
            datas.Add(new DataPoint("Thu", 26));
            datas.Add(new DataPoint("Fri", 20));
            datas.Add(new DataPoint("Sat", 15));
            return datas;
        }

        public static List<DataPoint> GetSplineData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sun", 2));
            datas.Add(new DataPoint("Mon", 12));
            datas.Add(new DataPoint("Tue", 22));
            datas.Add(new DataPoint("Wed", 23));
            datas.Add(new DataPoint("Thu", 19));
            datas.Add(new DataPoint("Fri", 13));
            datas.Add(new DataPoint("Sat", 8));
            return datas;
        }
        public static List<DataPoint> GetRangeColumnData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sun", 10.8, 3.1));
            datas.Add(new DataPoint("Mon", 14.4, 5.7));
            datas.Add(new DataPoint("Tue", 16.9, 8.4));
            datas.Add(new DataPoint("Wed", 19.2, 10.6));
            datas.Add(new DataPoint("Thu", 16.1, 8.5));
            datas.Add(new DataPoint("Fri", 12.5, 6.0));
            datas.Add(new DataPoint("Sat", 6.9, 1.5));
            return datas;
        }
        public static List<DataPoint> GetRangeColumnData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sun", 9.8, 2.5));
            datas.Add(new DataPoint("Mon", 11.4, 4.7));
            datas.Add(new DataPoint("Tue", 14.4, 6.4));
            datas.Add(new DataPoint("Wed", 17.2, 9.6));
            datas.Add(new DataPoint("Thu", 15.1, 7.5));
            datas.Add(new DataPoint("Fri", 10.5, 3.0));
            datas.Add(new DataPoint("Sat", 7.9, 1.2));
            return datas;
        }

        public static List<DataPoint> GetRangeBarData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jumbo", 70238));
            datas.Add(new DataPoint("FHA", 99595));
            datas.Add(new DataPoint("VA", 156398));
            datas.Add(new DataPoint("USDA", 256396));
            datas.Add(new DataPoint("Const", 356398));
            datas.Add(new DataPoint("Total", 459937));
            return datas;
        }

        public static List<DataPoint> GetRangeArea()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan/10", 45, 32));
            datas.Add(new DataPoint("Feb/10", 48, 34));
            datas.Add(new DataPoint("Mar/10", 46, 32));
            datas.Add(new DataPoint("Apr/10", 48, 36));
            datas.Add(new DataPoint("May/10", 46, 32));
            datas.Add(new DataPoint("Jun/10", 49, 34));
            return datas;
        }

        public static List<DataPoint> GetRangeArea1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan/10", 30, 18));
            datas.Add(new DataPoint("Feb/10", 24, 12));
            datas.Add(new DataPoint("Mar/10", 29, 15));
            datas.Add(new DataPoint("Apr/10", 24, 10));
            datas.Add(new DataPoint("May/10", 30, 18));
            datas.Add(new DataPoint("Jun/10", 24, 10));
            return datas;
        }

        public static List<DataPoint> GetSplineRangeArea1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 45, 32));
            datas.Add(new DataPoint("Feb", 48, 34));
            datas.Add(new DataPoint("Mar", 46, 32));
            datas.Add(new DataPoint("Apr", 48, 36));
            datas.Add(new DataPoint("May", 46, 32));
            datas.Add(new DataPoint("Jun", 49, 34));
            return datas;
        }


        public static List<DataPoint> GetSplineRangeArea2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 30, 18));
            datas.Add(new DataPoint("Feb", 24, 12));
            datas.Add(new DataPoint("Mar", 29, 15));
            datas.Add(new DataPoint("Apr", 24, 10));
            datas.Add(new DataPoint("May", 30, 18));
            datas.Add(new DataPoint("Jun", 24, 10));
            return datas;
        }

        public static List<DataPoint> GetStepLineData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(1975, 16));
            datas.Add(new DataPoint(1980, 12.5));
            datas.Add(new DataPoint(1985, 19));
            datas.Add(new DataPoint(1990, 14.4));
            datas.Add(new DataPoint(1995, 11.5));
            datas.Add(new DataPoint(2000, 14));
            datas.Add(new DataPoint(2005, 10));
            datas.Add(new DataPoint(2010, 16));
            return datas;
        }

        public static List<DataPoint> GetStepLineData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(1975, 10));
            datas.Add(new DataPoint(1980, 7.5));
            datas.Add(new DataPoint(1985, 11));
            datas.Add(new DataPoint(1990, 7));
            datas.Add(new DataPoint(1995, 8));
            datas.Add(new DataPoint(2000, 6));
            datas.Add(new DataPoint(2005, 3.5));
            datas.Add(new DataPoint(2010, 7));
            return datas;
        }

        public static List<DataPoint> GetStepLineData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2006, 570));
            datas.Add(new DataPoint(2007, 579));
            datas.Add(new DataPoint(2008, 563));
            datas.Add(new DataPoint(2009, 550));
            datas.Add(new DataPoint(2010, 545));
            datas.Add(new DataPoint(2011, 525));
            return datas;
        }

        public static List<DataPoint> GetStepLineData4()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(2006, 570));
            datas.Add(new DataPoint(2007, 579));
            datas.Add(new DataPoint(2008, 563));
            datas.Add(new DataPoint(2009, 550));
            datas.Add(new DataPoint(2010, 545));
            datas.Add(new DataPoint(2011, 525));
            return datas;
        }

        public static List<DataPoint> GetPieData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("David", 30));
            datas.Add(new DataPoint("Steve", 35));
            datas.Add(new DataPoint("Micheal", 24));
            datas.Add(new DataPoint("John", 11));
            datas.Add(new DataPoint("Regev", 25));
            datas.Add(new DataPoint("Jack", 39));
            datas.Add(new DataPoint("Stephen", 15));
            return datas;
        }
        public static List<DataPoint> GetDoughnutData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Labour", 10));
            datas.Add(new DataPoint("Legal", 8));
            datas.Add(new DataPoint("Production", 7));
            datas.Add(new DataPoint("License", 5));
            datas.Add(new DataPoint("Facilities", 10));
            datas.Add(new DataPoint("Taxes", 6));
            datas.Add(new DataPoint("Insurance", 18));
            return datas;
        }

        public static List<MultipleCircleModel> GetStackedDoughnutData()
        {
            var datas = new List<MultipleCircleModel>();
			datas.Add(new MultipleCircleModel("Vehicle", 62.7, Resource.Drawable.Car));
			datas.Add(new MultipleCircleModel("Education", 29.5, Resource.Drawable.Chart_Book));
			datas.Add(new MultipleCircleModel("Home", 85.2, Resource.Drawable.House));
			datas.Add(new MultipleCircleModel("Personal", 45.6, Resource.Drawable.Personal));
            return datas;
        }

        public static List<DataPoint> GetPyramidData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Sweet Treats", 120));
            datas.Add(new DataPoint("Milk, Youghnut, Cheese", 435));
            datas.Add(new DataPoint("Vegetables", 470));
            datas.Add(new DataPoint("Meat, Poultry, Fish", 475));
            datas.Add(new DataPoint("Fruits", 520));
            datas.Add(new DataPoint("Bread, Rice, Pasta", 930));
            return datas;
        }

        public static List<DataPoint> GetFunnelData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Renewed", 18.2));
            datas.Add(new DataPoint("Subscribe", 27.3));
            datas.Add(new DataPoint("Support", 55.9));
            datas.Add(new DataPoint("Downloaded", 76.8));
            datas.Add(new DataPoint("Visited", 100));
            return datas;
        }
        public static List<DataPoint> GetBubbleData()
        {
            var data = new List<DataPoint>();
            data.Add(new DataPoint(92.2, 7.8, 1.347, "China"));
            data.Add(new DataPoint(74, 6.5, 1.241, "India"));
            data.Add(new DataPoint(90.4, 6.0, 0.238, "Indonesia"));
            data.Add(new DataPoint(99.4, 2.2, 0.312, "US"));
            data.Add(new DataPoint(88.6, 1.3, 0.197, "Brazil"));
            data.Add(new DataPoint(99, 0.7, 0.0818, "Germany"));
            data.Add(new DataPoint(72, 2.0, 0.0826, "Egypt"));
            data.Add(new DataPoint(99.6, 3.4, 0.143, "Russia"));
            data.Add(new DataPoint(99, 0.2, 0.128, "Japan"));
            data.Add(new DataPoint(86.1, 4.0, 0.115, "Mexico"));
            data.Add(new DataPoint(92.6, 6.6, 0.096, "Philippines"));
            data.Add(new DataPoint(61.3, 1.45, 0.162, "Nigeria"));
            data.Add(new DataPoint(82.2, 3.97, 0.7, "Hong Kong"));
            data.Add(new DataPoint(79.2, 3.9, 0.162, "Netherland"));
            data.Add(new DataPoint(72.5, 4.5, 0.7, "Jordan"));
            data.Add(new DataPoint(81, 3.5, 0.21, "Australia"));
            data.Add(new DataPoint(66.8, 3.9, 0.028, "Mongolia"));
            data.Add(new DataPoint(79.2, 2.9, 0.231, "Taiwan"));
            return data;
        }
        public static List<DataPoint> GetCandleData()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(dateTime, 90, 125, 70, 115));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 120, 150, 60, 70));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 190, 200, 140, 160));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 110, 160, 90, 140));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 120, 200, 100, 180));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 70, 100, 45, 50));
            return datas;
        }
        public static List<DataPoint> GetOhlcData()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(dateTime, 115, 125, 70, 90));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 120, 150, 60, 70));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 160, 200, 140, 190));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 140, 160, 90, 110));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 180, 200, 100, 120));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 70, 100, 45, 50));
            return datas;
        }

        public static List<DataPoint> GetStackedAreaData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.61));
            datas.Add(new DataPoint("2001", 0.81));
            datas.Add(new DataPoint("2002", 0.91));
            datas.Add(new DataPoint("2003", 1));
            datas.Add(new DataPoint("2004", 1.19));
            datas.Add(new DataPoint("2005", 1.47));
            datas.Add(new DataPoint("2006", 1.74));
            datas.Add(new DataPoint("2007", 1.98));
            datas.Add(new DataPoint("2008", 1.99));
            datas.Add(new DataPoint("2009", 1.70));
            datas.Add(new DataPoint("2010", 1.48));
            datas.Add(new DataPoint("2011", 1.38));
            datas.Add(new DataPoint("2012", 1.66));
            datas.Add(new DataPoint("2013", 1.66));
            datas.Add(new DataPoint("2014", 1.67));
            return datas;
        }

        public static List<DataPoint> GetStackedAreaData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.03));
            datas.Add(new DataPoint("2001", 0.05));
            datas.Add(new DataPoint("2002", 0.06));
            datas.Add(new DataPoint("2003", 0.09));
            datas.Add(new DataPoint("2004", 0.14));
            datas.Add(new DataPoint("2005", 0.20));
            datas.Add(new DataPoint("2006", 0.29));
            datas.Add(new DataPoint("2007", 0.46));
            datas.Add(new DataPoint("2008", 0.64));
            datas.Add(new DataPoint("2009", 0.75));
            datas.Add(new DataPoint("2010", 1.06));
            datas.Add(new DataPoint("2011", 1.25));
            datas.Add(new DataPoint("2012", 1.55));
            datas.Add(new DataPoint("2013", 1.55));
            datas.Add(new DataPoint("2014", 1.65));
            return datas;
        }

        public static List<DataPoint> GetStackedAreaData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.48));
            datas.Add(new DataPoint("2001", 0.53));
            datas.Add(new DataPoint("2002", 0.57));
            datas.Add(new DataPoint("2003", 0.61));
            datas.Add(new DataPoint("2004", 0.63));
            datas.Add(new DataPoint("2005", 0.64));
            datas.Add(new DataPoint("2006", 0.66));
            datas.Add(new DataPoint("2007", 0.76));
            datas.Add(new DataPoint("2008", 0.77));
            datas.Add(new DataPoint("2009", 0.55));
            datas.Add(new DataPoint("2010", 0.54));
            datas.Add(new DataPoint("2011", 0.57));
            datas.Add(new DataPoint("2012", 0.61));
            datas.Add(new DataPoint("2013", 0.67));
            datas.Add(new DataPoint("2014", 0.67));
            return datas;
        }

        public static List<DataPoint> GetStackedAreaData4()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.23));
            datas.Add(new DataPoint("2001", 0.17));
            datas.Add(new DataPoint("2002", 0.17));
            datas.Add(new DataPoint("2003", 0.20));
            datas.Add(new DataPoint("2004", 0.23));
            datas.Add(new DataPoint("2005", 0.36));
            datas.Add(new DataPoint("2006", 0.43));
            datas.Add(new DataPoint("2007", 0.52));
            datas.Add(new DataPoint("2008", 0.72));
            datas.Add(new DataPoint("2009", 1.29));
            datas.Add(new DataPoint("2010", 1.38));
            datas.Add(new DataPoint("2011", 1.82));
            datas.Add(new DataPoint("2012", 2.16));
            datas.Add(new DataPoint("2013", 2.51));
            datas.Add(new DataPoint("2014", 2.61));
            return datas;
        }

        public static List<DataPoint> GetStackedArea100Data1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.61));
            datas.Add(new DataPoint("2001", 0.81));
            datas.Add(new DataPoint("2002", 0.91));
            datas.Add(new DataPoint("2003", 1));
            datas.Add(new DataPoint("2004", 1.19));
            datas.Add(new DataPoint("2005", 1.47));
            datas.Add(new DataPoint("2006", 1.74));
            datas.Add(new DataPoint("2007", 1.98));
            datas.Add(new DataPoint("2008", 1.99));
            datas.Add(new DataPoint("2009", 1.70));
            datas.Add(new DataPoint("2010", 1.48));
            datas.Add(new DataPoint("2011", 1.38));
            datas.Add(new DataPoint("2012", 1.66));
            datas.Add(new DataPoint("2013", 1.66));
            datas.Add(new DataPoint("2014", 1.67));
            return datas;
        }
        public static List<DataPoint> GetStackedArea100Data2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.03));
            datas.Add(new DataPoint("2001", 0.05));
            datas.Add(new DataPoint("2002", 0.06));
            datas.Add(new DataPoint("2003", 0.09));
            datas.Add(new DataPoint("2004", 0.14));
            datas.Add(new DataPoint("2005", 0.20));
            datas.Add(new DataPoint("2006", 0.29));
            datas.Add(new DataPoint("2007", 0.46));
            datas.Add(new DataPoint("2008", 0.64));
            datas.Add(new DataPoint("2009", 0.75));
            datas.Add(new DataPoint("2010", 1.06));
            datas.Add(new DataPoint("2011", 1.25));
            datas.Add(new DataPoint("2012", 1.55));
            datas.Add(new DataPoint("2013", 1.55));
            datas.Add(new DataPoint("2014", 1.65));
            return datas;
        }
        public static List<DataPoint> GetStackedArea100Data3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.48));
            datas.Add(new DataPoint("2001", 0.53));
            datas.Add(new DataPoint("2002", 0.57));
            datas.Add(new DataPoint("2003", 0.61));
            datas.Add(new DataPoint("2004", 0.63));
            datas.Add(new DataPoint("2005", 0.64));
            datas.Add(new DataPoint("2006", 0.66));
            datas.Add(new DataPoint("2007", 0.76));
            datas.Add(new DataPoint("2008", 0.77));
            datas.Add(new DataPoint("2009", 0.55));
            datas.Add(new DataPoint("2010", 0.54));
            datas.Add(new DataPoint("2011", 0.57));
            datas.Add(new DataPoint("2012", 0.61));
            datas.Add(new DataPoint("2013", 0.67));
            datas.Add(new DataPoint("2014", 0.67));
            return datas;
        }
        public static List<DataPoint> GetStackedArea100Data4()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 0.23));
            datas.Add(new DataPoint("2001", 0.17));
            datas.Add(new DataPoint("2002", 0.17));
            datas.Add(new DataPoint("2003", 0.20));
            datas.Add(new DataPoint("2004", 0.23));
            datas.Add(new DataPoint("2005", 0.36));
            datas.Add(new DataPoint("2006", 0.43));
            datas.Add(new DataPoint("2007", 0.52));
            datas.Add(new DataPoint("2008", 0.72));
            datas.Add(new DataPoint("2009", 1.29));
            datas.Add(new DataPoint("2010", 1.38));
            datas.Add(new DataPoint("2011", 1.82));
            datas.Add(new DataPoint("2012", 2.16));
            datas.Add(new DataPoint("2013", 2.51));
            datas.Add(new DataPoint("2014", 2.61));
            return datas;
        }
        public static List<DataPoint> GetStackedBarData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 6));
            datas.Add(new DataPoint("Feb", 8));
            datas.Add(new DataPoint("Mar", 12));
            datas.Add(new DataPoint("Apr", 15.5));
            datas.Add(new DataPoint("May", 20));
            datas.Add(new DataPoint("Jun", 24));
            return datas;
        }

        public static List<DataPoint> GetStackedBarData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 6));
            datas.Add(new DataPoint("Feb", 8));
            datas.Add(new DataPoint("Mar", 11));
            datas.Add(new DataPoint("Apr", 16));
            datas.Add(new DataPoint("May", 21));
            datas.Add(new DataPoint("Jun", 25));
            return datas;
        }

        public static List<DataPoint> GetStackedBarData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", -1));
            datas.Add(new DataPoint("Feb", -1.5));
            datas.Add(new DataPoint("Mar", -2));
            datas.Add(new DataPoint("Apr", -2.5));
            datas.Add(new DataPoint("May", -3));
            datas.Add(new DataPoint("Jun", -3.5));
            return datas;
        }
        public static List<DataPoint> GetStackedBar100Data1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 6));
            datas.Add(new DataPoint("Feb", 8));
            datas.Add(new DataPoint("Mar", 12));
            datas.Add(new DataPoint("Apr", 15));
            datas.Add(new DataPoint("May", 20));
            datas.Add(new DataPoint("Jun", 24));
            return datas;
        }
        public static List<DataPoint> GetStackedBar100Data2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 6));
            datas.Add(new DataPoint("Feb", 8));
            datas.Add(new DataPoint("Mar", 11));
            datas.Add(new DataPoint("Apr", 16));
            datas.Add(new DataPoint("May", 21));
            datas.Add(new DataPoint("Jun", 25));
            return datas;
        }
        public static List<DataPoint> GetStackedBar100Data3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 1));
            datas.Add(new DataPoint("Feb", 1.5));
            datas.Add(new DataPoint("Mar", 2));
            datas.Add(new DataPoint("Apr", 2.5));
            datas.Add(new DataPoint("May", 3));
            datas.Add(new DataPoint("Jun", 3.5));
            return datas;
        }

        public static List<DataPoint> GetStackedColumnData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2014", 111.1));
            datas.Add(new DataPoint("2015", 127.3));
            datas.Add(new DataPoint("2016", 143.4));
            datas.Add(new DataPoint("2017", 159.9));
            return datas;
        }

        public static List<DataPoint> GetStackedColumnData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2014", 76.9));
            datas.Add(new DataPoint("2015", 99.5));
            datas.Add(new DataPoint("2016", 121.7));
            datas.Add(new DataPoint("2017", 142.5));
            return datas;
        }

        public static List<DataPoint> GetStackedColumnData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2014", 66.1));
            datas.Add(new DataPoint("2015", 79.3));
            datas.Add(new DataPoint("2016", 91.3));
            datas.Add(new DataPoint("2017", 102.4));
            return datas;
        }

        public static List<DataPoint> GetStackedColumnData4()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2014", 34.1));
            datas.Add(new DataPoint("2015", 38.2));
            datas.Add(new DataPoint("2016", 44.0));
            datas.Add(new DataPoint("2017", 51.6));
            return datas;
        }

        public static List<DataPoint> GetStackedColumn100Data1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2006", 900));
            datas.Add(new DataPoint("2007", 544));
            datas.Add(new DataPoint("2008", 880));
            datas.Add(new DataPoint("2009", 675));
            return datas;
        }

        public static List<DataPoint> GetStackedColumn100Data2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2006", 190));
            datas.Add(new DataPoint("2007", 226));
            datas.Add(new DataPoint("2008", 194));
            datas.Add(new DataPoint("2009", 250));
            return datas;
        }

        public static List<DataPoint> GetStackedColumn100Data3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2006", 250));
            datas.Add(new DataPoint("2007", 145));
            datas.Add(new DataPoint("2008", 190));
            datas.Add(new DataPoint("2009", 220));
            return datas;
        }

        public static List<DataPoint> GetStackedColumn100Data4()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2006", 150));
            datas.Add(new DataPoint("2007", 120));
            datas.Add(new DataPoint("2008", 115));
            datas.Add(new DataPoint("2009", 125));
            return datas;
        }

        public static List<DataPoint> GetStackedLine100Data1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 36));
            datas.Add(new DataPoint("Transport", 18));
            datas.Add(new DataPoint("Medical", 43));
            datas.Add(new DataPoint("Clothes", 32));
            datas.Add(new DataPoint("Books", 56));
            datas.Add(new DataPoint("Others", 23));
            return datas;
        }

        public static List<DataPoint> GetStackedLine100Data2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 40));
            datas.Add(new DataPoint("Transport", 45));
            datas.Add(new DataPoint("Medical", 23));
            datas.Add(new DataPoint("Clothes", 54));
            datas.Add(new DataPoint("Books", 48));
            datas.Add(new DataPoint("Others", 54));
            return datas;
        }

        public static List<DataPoint> GetStackedLine100Data3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 45));
            datas.Add(new DataPoint("Transport", 54));
            datas.Add(new DataPoint("Medical", 20));
            datas.Add(new DataPoint("Clothes", 73));
            datas.Add(new DataPoint("Books", 93));
            datas.Add(new DataPoint("Others", 54));
            return datas;
        }

        public static List<DataPoint> GetStackedLine100Data4()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Food", 48));
            datas.Add(new DataPoint("Transport", 28));
            datas.Add(new DataPoint("Medical", 34));
            datas.Add(new DataPoint("Clothes", 84));
            datas.Add(new DataPoint("Books", 55));
            datas.Add(new DataPoint("Others", 56));
            return datas;
        }

        public static List<DataPoint> GetScatterMaleData()
        {
            var datas = new List<DataPoint>()
            {
                new DataPoint( 161, 65 ), new DataPoint( 150,  65 ), new DataPoint(155,  65 ), new DataPoint(160, 65 ),
                new DataPoint( 148, 66 ), new DataPoint( 145,  66 ), new DataPoint(137,  66 ), new DataPoint(138, 66 ),
                new DataPoint( 162, 66 ), new DataPoint( 166,  66 ), new DataPoint(159,  66 ), new DataPoint(151, 66 ),
                new DataPoint( 180, 66 ), new DataPoint( 181,  66 ), new DataPoint(174,  66 ), new DataPoint(159, 66 ),
                new DataPoint( 151, 67 ), new DataPoint( 148,  67 ), new DataPoint(141,  67 ), new DataPoint(145, 67 ),
                new DataPoint( 165, 67 ), new DataPoint( 168,  67 ), new DataPoint(159,  67 ), new DataPoint(183, 67 ),
                new DataPoint( 188, 67 ), new DataPoint( 187,  67 ), new DataPoint(172,  67 ), new DataPoint(193, 67 ),
                new DataPoint( 153, 68 ), new DataPoint( 153,  68 ), new DataPoint(147,  68 ), new DataPoint(163, 68 ),
                new DataPoint( 174, 68 ), new DataPoint( 173,  68 ), new DataPoint(160,  68 ), new DataPoint(191, 68 ),
                new DataPoint( 131, 62 ), new DataPoint( 140,  62 ), new DataPoint(149,  62 ), new DataPoint(115, 62 ),
                new DataPoint( 164, 63 ), new DataPoint( 162,  63 ), new DataPoint(167,  63 ), new DataPoint(146, 63 ),
                new DataPoint( 150, 64 ), new DataPoint( 141,  64 ), new DataPoint(142,  64 ), new DataPoint(129, 64 ),
                new DataPoint( 159, 64 ), new DataPoint( 158,  64 ), new DataPoint(162,  64 ), new DataPoint(136, 64 ),
                new DataPoint( 176, 64 ), new DataPoint( 170,  64 ), new DataPoint(167,  64 ), new DataPoint(144, 64 ),
                new DataPoint( 143, 65 ), new DataPoint( 137,  65 ), new DataPoint(137,  65 ), new DataPoint(140, 65 ),
                new DataPoint( 182, 65 ), new DataPoint( 168,  65 ), new DataPoint(181,  65 ), new DataPoint(165, 65 ),
                new DataPoint( 214, 74 ), new DataPoint( 211,  74 ), new DataPoint(166,  74 ), new DataPoint(185, 74 ),
                new DataPoint( 189, 68 ), new DataPoint( 182,  68 ), new DataPoint(181,  68 ), new DataPoint(196, 68 ),
                new DataPoint( 152, 69 ), new DataPoint( 173,  69 ), new DataPoint(190,  69 ), new DataPoint(161, 69 ),
                new DataPoint( 173, 69 ), new DataPoint( 185,  69 ), new DataPoint(141,  69 ), new DataPoint(149, 69 ),
                new DataPoint( 134, 62 ), new DataPoint( 183,  62 ), new DataPoint(155,  62 ), new DataPoint(164, 62 ),
                new DataPoint( 169, 62 ), new DataPoint( 122,  62 ), new DataPoint(161,  62 ), new DataPoint(166, 62 ),
                new DataPoint( 137, 63 ), new DataPoint( 140,  63 ), new DataPoint(140,  63 ), new DataPoint(126, 63 ),
                new DataPoint( 150, 63 ), new DataPoint( 153,  63 ), new DataPoint(154,  63 ), new DataPoint(139, 63 ),
                new DataPoint( 186, 69 ), new DataPoint( 188,  69 ), new DataPoint(148,  69 ), new DataPoint(174, 69 ),
                new DataPoint( 164, 70 ), new DataPoint( 182,  70 ), new DataPoint(200,  70 ), new DataPoint(151, 70 ),
                new DataPoint( 204, 74 ), new DataPoint( 177,  74 ), new DataPoint(194,  74 ), new DataPoint(212, 74 ),
                new DataPoint( 162, 70 ), new DataPoint( 200,  70 ), new DataPoint(166,  70 ), new DataPoint(177, 70 ),
                new DataPoint( 188, 70 ), new DataPoint( 156,  70 ), new DataPoint(175,  70 ), new DataPoint(191, 70 ),
                new DataPoint( 174, 71 ), new DataPoint( 187,  71 ), new DataPoint(208,  71 ), new DataPoint(166, 71 ),
                new DataPoint( 150, 71 ), new DataPoint( 194,  71 ), new DataPoint(157,  71 ), new DataPoint(183, 71 ),
                new DataPoint( 204, 71 ), new DataPoint( 162,  71 ), new DataPoint(179,  71 ), new DataPoint(196, 71 ),
                new DataPoint( 170, 72 ), new DataPoint( 184,  72 ), new DataPoint(197,  72 ), new DataPoint(162, 72 ),
                new DataPoint( 177, 72 ), new DataPoint( 203,  72 ), new DataPoint(159,  72 ), new DataPoint(178, 72 ),
                new DataPoint( 198, 72 ), new DataPoint( 167,  72 ), new DataPoint(184,  72 ), new DataPoint(201, 72 ),
                new DataPoint( 167, 73 ), new DataPoint( 178,  73 ), new DataPoint(215,  73 ), new DataPoint(207, 73 ),
                new DataPoint( 172, 73 ), new DataPoint( 204,  73 ), new DataPoint(162,  73 ), new DataPoint(182, 73 ),
                new DataPoint( 201, 73 ), new DataPoint( 172,  73 ), new DataPoint(189,  73 ), new DataPoint(206, 73 ),
                new DataPoint( 150, 74 ), new DataPoint( 187,  74 ), new DataPoint(153,  74 ), new DataPoint(171, 74 ),
            };

            return datas;
        }

        public static List<DataPoint> GetScatterFemaleData()
        {
            var datas = new List<DataPoint>()
            {
                new DataPoint(115, 57 ), new DataPoint(138, 57 ), new DataPoint(166, 57 ), new DataPoint(122,  57 ),
                new DataPoint(126, 57 ), new DataPoint(130, 57 ), new DataPoint(125, 57 ), new DataPoint(144,  57 ),
                new DataPoint(150, 57 ), new DataPoint(120, 57 ), new DataPoint(125, 57 ), new DataPoint(130,  57 ),
                new DataPoint(103, 58 ), new DataPoint(116, 58 ), new DataPoint(130, 58 ), new DataPoint(126,  58 ),
                new DataPoint(136, 58 ), new DataPoint(148, 58 ), new DataPoint(119, 58 ), new DataPoint(141,  58 ),
                new DataPoint(159, 58 ), new DataPoint(120, 58 ), new DataPoint(135, 58 ), new DataPoint(163,  58 ),
                new DataPoint(119, 59 ), new DataPoint(131, 59 ), new DataPoint(148, 59 ), new DataPoint(123,  59 ),
                new DataPoint(137, 59 ), new DataPoint(149, 59 ), new DataPoint(121, 59 ), new DataPoint(142,  59 ),
                new DataPoint(160, 59 ), new DataPoint(118, 59 ), new DataPoint(130, 59 ), new DataPoint(146,  59 ),
                new DataPoint(119, 60 ), new DataPoint(133, 60 ), new DataPoint(150, 60 ), new DataPoint(133,  60 ),
                new DataPoint(149, 60 ), new DataPoint(165, 60 ), new DataPoint(130, 60 ), new DataPoint(139,  60 ),
                new DataPoint(154, 60 ), new DataPoint(118, 60 ), new DataPoint(152, 60 ), new DataPoint(154,  60 ),
                new DataPoint(130, 61 ), new DataPoint(145, 61 ), new DataPoint(166, 61 ), new DataPoint(131,  61 ),
                new DataPoint(143, 61 ), new DataPoint(162, 61 ), new DataPoint(131, 61 ), new DataPoint(145,  61 ),
                new DataPoint(162, 61 ), new DataPoint(115, 61 ), new DataPoint(149, 61 ), new DataPoint(183,  61 ),
                new DataPoint(121, 62 ), new DataPoint(139, 62 ), new DataPoint(159, 62 ), new DataPoint(135,  62 ),
                new DataPoint(152, 62 ), new DataPoint(178, 62 ), new DataPoint(130, 62 ), new DataPoint(153,  62 ),
                new DataPoint(172, 62 ), new DataPoint(114, 62 ), new DataPoint(135, 62 ), new DataPoint(154,  62 ),
                new DataPoint(126, 63 ), new DataPoint(141, 63 ), new DataPoint(160, 63 ), new DataPoint(135,  63 ),
                new DataPoint(149, 63 ), new DataPoint(180, 63 ), new DataPoint(132, 63 ), new DataPoint(144,  63 ),
                new DataPoint(163, 63 ), new DataPoint(122, 63 ), new DataPoint(146, 63 ), new DataPoint(156,  63 ),
                new DataPoint(133, 64 ), new DataPoint(150, 64 ), new DataPoint(176, 64 ), new DataPoint(133,  64 ),
                new DataPoint(149, 64 ), new DataPoint(176, 64 ), new DataPoint(136, 64 ), new DataPoint(157,  64 ),
                new DataPoint(174, 64 ), new DataPoint(131, 64 ), new DataPoint(155, 64 ), new DataPoint(191,  64 ),
                new DataPoint(136, 65 ), new DataPoint(149, 65 ), new DataPoint(177, 65 ), new DataPoint(143,  65 ),
                new DataPoint(149, 65 ), new DataPoint(184, 65 ), new DataPoint(128, 65 ), new DataPoint(146,  65 ),
                new DataPoint(157, 65 ), new DataPoint(133, 65 ), new DataPoint(153, 65 ), new DataPoint(173,  65 ),
                new DataPoint(141, 66 ), new DataPoint(156, 66 ), new DataPoint(175, 66 ), new DataPoint(125,  66 ),
                new DataPoint(138, 66 ), new DataPoint(165, 66 ), new DataPoint(122, 66 ), new DataPoint(164,  66 ),
                new DataPoint(182, 66 ), new DataPoint(137, 66 ), new DataPoint(157, 66 ), new DataPoint(176,  66 ),
                new DataPoint(149, 67 ), new DataPoint(159, 67 ), new DataPoint(179, 67 ), new DataPoint(156,  67 ),
                new DataPoint(179, 67 ), new DataPoint(186, 67 ), new DataPoint(147, 67 ), new DataPoint(166,  67 ),
                new DataPoint(185, 67 ), new DataPoint(140, 67 ), new DataPoint(160, 67 ), new DataPoint(180,  67 ),
                new DataPoint(145, 68 ), new DataPoint(155, 68 ), new DataPoint(170, 68 ), new DataPoint(129,  68 ),
                new DataPoint(164, 68 ), new DataPoint(189, 68 ), new DataPoint(150, 68 ), new DataPoint(157,  68 ),
                new DataPoint(183, 68 ), new DataPoint(144, 68 ), new DataPoint(170, 68 ), new DataPoint(180,  68 )
            };

            return datas;
        }

        public static List<DataPoint> GetScatterDataForZoomPan()
        {
            var datas = new List<DataPoint>();
            Java.Util.Random random = new Java.Util.Random();
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
                datas.Add(new DataPoint(300 + (x * (random.NextDouble() + 0.12)),
                        100 + (y * (random.NextDouble() + 0.12))));
            }
            return datas;
        }

        public static List<DataPoint> GetLineData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 45.68));
            datas.Add(new DataPoint("2011", 89.25));
            datas.Add(new DataPoint("2012", 23.73));
            datas.Add(new DataPoint("2013", 43.5));
            datas.Add(new DataPoint("2014", 54.92));
            return datas;
        }
        public static List<DataPoint> GetStepLineData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2002", 36));
            datas.Add(new DataPoint("2003", 40));
            datas.Add(new DataPoint("2004", 34));
            datas.Add(new DataPoint("2005", 40));
            datas.Add(new DataPoint("2006", 44));
            datas.Add(new DataPoint("2007", 38));
            datas.Add(new DataPoint("2008", 30));
            return datas;
        }

        public static List<DataPoint> GetCategoryData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Bentley", 54));
            datas.Add(new DataPoint("Audi", 24));
            datas.Add(new DataPoint("BMW", 53));
            datas.Add(new DataPoint("Jaguar", 63));
            datas.Add(new DataPoint("Skoda", 35));
            return datas;
        }

        public static List<DataPoint> GetNumericalData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(16, 2));
            datas.Add(new DataPoint(17, 14));
            datas.Add(new DataPoint(18, 7));
            datas.Add(new DataPoint(19, 7));
            datas.Add(new DataPoint(20, 10));
            return datas;
        }

        public static List<DataPoint> GetNumericalData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(16, 7));
            datas.Add(new DataPoint(17, 7));
            datas.Add(new DataPoint(18, 11));
            datas.Add(new DataPoint(19, 8));
            datas.Add(new DataPoint(20, 24));
            return datas;
        }
        public static List<DataPoint> GetData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 54));
            datas.Add(new DataPoint("2011", 24));
            datas.Add(new DataPoint("2012", 53));
            datas.Add(new DataPoint("2013", 63));
            datas.Add(new DataPoint("2014", 35));
            return datas;
        }

        public static List<DataPoint> GetData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 14));
            datas.Add(new DataPoint("2011", 54));
            datas.Add(new DataPoint("2012", 23));
            datas.Add(new DataPoint("2013", 53));
            datas.Add(new DataPoint("2014", 25));
            return datas;
        }

        public static List<DataPoint> GetFinancialData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 873.8, 878.85, 855.5, 860.5));
            datas.Add(new DataPoint("2011", 861, 868.4, 835.2, 843.45));
            datas.Add(new DataPoint("2012", 846.15, 853, 838.5, 847.5));
            datas.Add(new DataPoint("2013", 846, 860.75, 841, 855));
            datas.Add(new DataPoint("2014", 841, 845, 827.85, 838.65));
            return datas;
        }

        public static List<DataPoint> GetSelectionData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 42));
            datas.Add(new DataPoint("Feb", 44));
            datas.Add(new DataPoint("Mar", 53));
            datas.Add(new DataPoint("Apr", 64));
            datas.Add(new DataPoint("May", 75));
            datas.Add(new DataPoint("Jun", 83));
            return datas;
        }

        public static List<DataPoint> GetSelectionData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Jan", 38));
            datas.Add(new DataPoint("Feb", 50));
            datas.Add(new DataPoint("Mar", 56));
            datas.Add(new DataPoint("Apr", 60));
            datas.Add(new DataPoint("May", 80));
            datas.Add(new DataPoint("Jun", 90));
            return datas;
        }

        public static List<DataPoint> GetTooltipData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2007", 1.61));
            datas.Add(new DataPoint("2008", 2.34));
            datas.Add(new DataPoint("2009", 2.16));
            datas.Add(new DataPoint("2010", 2.1));
            datas.Add(new DataPoint("2011", 1.61));
            datas.Add(new DataPoint("2012", 2.05));
            datas.Add(new DataPoint("2013", 2.5));
            datas.Add(new DataPoint("2014", 2.21));
            datas.Add(new DataPoint("2015", 2.34));
            return datas;
        }

        public static List<DataPoint> GetDateTimeValue()
        {
            var dateTime = new DateTime(2015, 1, 1);
            List<DataPoint> datas = new List<DataPoint>();
            datas.Add(new DataPoint(dateTime, 10d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 31d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 28d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 45d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 10d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 23d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 35d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 56d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 10d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 39d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 26d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 21d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 31d));
            return datas;
        }

        public static List<DataPoint> GetDateTimValue()
        {
            var dateTime = new DateTime(2014, 1, 1);
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(dateTime, 10d));
            dateTime = dateTime.AddDays(1);
            datas.Add(new DataPoint(dateTime, 23d));
            dateTime = dateTime.AddDays(1);
            datas.Add(new DataPoint(dateTime, 22d));
            dateTime = dateTime.AddDays(1);
            datas.Add(new DataPoint(dateTime, 32d));
            dateTime = dateTime.AddDays(1);
            datas.Add(new DataPoint(dateTime, 31d));
            dateTime = dateTime.AddDays(1);
            datas.Add(new DataPoint(dateTime, 12d));
            dateTime = dateTime.AddDays(1);
            datas.Add(new DataPoint(dateTime, 26d));

            return datas;
        }

        public static List<DataPoint> GetSeriesData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(new DateTime(2000, 2, 11), 15));
            datas.Add(new DataPoint(new DateTime(2000, 9, 14), 20));
            datas.Add(new DataPoint(new DateTime(2001, 2, 11), 25));
            datas.Add(new DataPoint(new DateTime(2001, 9, 16), 21));
            datas.Add(new DataPoint(new DateTime(2002, 2, 07), 13));
            datas.Add(new DataPoint(new DateTime(2002, 9, 07), 18));
            datas.Add(new DataPoint(new DateTime(2003, 2, 11), 24));
            datas.Add(new DataPoint(new DateTime(2003, 9, 14), 23));
            datas.Add(new DataPoint(new DateTime(2004, 2, 06), 19));
            datas.Add(new DataPoint(new DateTime(2004, 9, 06), 31));
            datas.Add(new DataPoint(new DateTime(2005, 2, 11), 39));
            datas.Add(new DataPoint(new DateTime(2005, 9, 11), 50));
            datas.Add(new DataPoint(new DateTime(2006, 2, 11), 24));
            return datas;
        }

        public static List<DataPoint> GetSeriesData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(new DateTime(2000, 2, 11), 39));
            datas.Add(new DataPoint(new DateTime(2000, 9, 14), 30));
            datas.Add(new DataPoint(new DateTime(2001, 2, 11), 28));
            datas.Add(new DataPoint(new DateTime(2001, 9, 16), 35));
            datas.Add(new DataPoint(new DateTime(2002, 2, 07), 39));
            datas.Add(new DataPoint(new DateTime(2002, 9, 07), 41));
            datas.Add(new DataPoint(new DateTime(2003, 2, 11), 45));
            datas.Add(new DataPoint(new DateTime(2003, 9, 14), 48));
            datas.Add(new DataPoint(new DateTime(2004, 2, 06), 54));
            datas.Add(new DataPoint(new DateTime(2004, 9, 06), 55));
            datas.Add(new DataPoint(new DateTime(2005, 2, 11), 57));
            datas.Add(new DataPoint(new DateTime(2005, 9, 11), 60));
            datas.Add(new DataPoint(new DateTime(2006, 2, 11), 60));
            return datas;
        }

        public static List<DataPoint> GetSeriesData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(new DateTime(2000, 2, 11), 60));
            datas.Add(new DataPoint(new DateTime(2000, 9, 14), 55));
            datas.Add(new DataPoint(new DateTime(2001, 2, 11), 48));
            datas.Add(new DataPoint(new DateTime(2001, 9, 16), 57));
            datas.Add(new DataPoint(new DateTime(2002, 2, 07), 62));
            datas.Add(new DataPoint(new DateTime(2002, 9, 07), 64));
            datas.Add(new DataPoint(new DateTime(2003, 2, 11), 57));
            datas.Add(new DataPoint(new DateTime(2003, 9, 14), 53));
            datas.Add(new DataPoint(new DateTime(2004, 2, 06), 63));
            datas.Add(new DataPoint(new DateTime(2004, 9, 06), 50));
            datas.Add(new DataPoint(new DateTime(2005, 2, 11), 66));
            datas.Add(new DataPoint(new DateTime(2005, 9, 11), 65));
            datas.Add(new DataPoint(new DateTime(2006, 2, 11), 79));
            return datas;
        }

        public static List<DataPoint> GetTriangularData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("Bentley", 800));
            datas.Add(new DataPoint("Audi", 810));
            datas.Add(new DataPoint("BMW", 825));
            datas.Add(new DataPoint("Jaguar", 860));
            datas.Add(new DataPoint("Skoda", 875));
            return datas;
        }

        public static Color ConvertHexaToColor(uint hex)
        {
            var alpha = (hex & 0xFF000000) >> 24;
            var red = (hex & 0xFF0000) >> 16;
            var green = (hex & 0xFF00) >> 8;
            var blue = (hex & 0xFF);
            return Color.Argb((int)alpha, (int)red, (int)green, (int)blue);
        }

        public static List<DataPoint> GetPolarData1()
        {
            List<DataPoint> datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 4));
            datas.Add(new DataPoint("2001", 3.0));
            datas.Add(new DataPoint("2002", 3.8));
            datas.Add(new DataPoint("2003", 3.4));
            datas.Add(new DataPoint("2004", 3.2));
            datas.Add(new DataPoint("2005", 3.9));
            return datas;
        }

        public static List<DataPoint> GetPolarData2()
        {
            List<DataPoint> datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 2.6));
            datas.Add(new DataPoint("2001", 2.8));
            datas.Add(new DataPoint("2002", 2.6));
            datas.Add(new DataPoint("2003", 3));
            datas.Add(new DataPoint("2004", 3.6));
            datas.Add(new DataPoint("2005", 3));
            return datas;
        }

        public static List<DataPoint> GetPolarData3()
        {
            List<DataPoint> datas = new List<DataPoint>();
            datas.Add(new DataPoint("2000", 2.8));
            datas.Add(new DataPoint("2001", 2.5));
            datas.Add(new DataPoint("2002", 2.8));
            datas.Add(new DataPoint("2003", 3.2));
            datas.Add(new DataPoint("2004", 2.9));
            datas.Add(new DataPoint("2005", 2));
            return datas;
        }

        public static List<DataPoint> GetTechnicalIndicatorData()
        {
            var dateTime = new DateTime(1990, 1, 1);
            var datas1 = new List<DataPoint>();
            datas1.Add(new DataPoint(dateTime, 65.75, 67.27, 65.75, 65.98, 7938200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.98, 65.70, 65.04, 65.11, 10185300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.11, 65.05, 64.26, 64.97, 10835800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.97, 65.16, 64.09, 64.29, 9613400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.29, 62.73, 61.85, 62.44, 17175000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.44, 62.02, 61.29, 61.47, 18040600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.47, 62.75, 61.55, 61.59, 13456300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.59, 64.78, 62.22, 64.64, 8045100));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.64, 64.50, 63.03, 63.28, 8608900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.28, 63.70, 62.70, 63.59, 15025500));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.59, 64.45, 63.26, 63.61, 10065800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.61, 64.56, 63.81, 64.52, 6178200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.52, 64.84, 63.66, 63.91, 5478500));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.91, 65.30, 64.50, 65.22, 7964300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.22, 65.36, 64.46, 65.06, 5679300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.06, 64.54, 63.56, 63.65, 10758300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.65, 64.03, 63.33, 63.73, 5665900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.73, 63.40, 62.80, 62.83, 5833000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.83, 63.75, 62.96, 63.60, 3500800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.6, 63.64, 62.51, 63.51, 5044700));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.51, 64.03, 63.53, 63.76, 4871300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.76, 63.77, 63.01, 63.65, 7040400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.65, 63.95, 63.58, 63.79, 4727800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.79, 63.47, 62.92, 63.25, 6334900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.25, 63.96, 63.21, 63.48, 6823200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.48, 63.63, 62.55, 63.50, 9718400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.5, 63.25, 62.82, 62.90, 2827000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.9, 62.34, 62.05, 62.18, 4942700));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.18, 62.86, 61.94, 62.81, 4582800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.81, 63.06, 62.44, 62.83, 12423900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.83, 63.16, 62.66, 63.09, 4940500));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.09, 62.89, 62.43, 62.66, 6132300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.66, 62.39, 61.90, 62.25, 6263800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.25, 61.69, 60.97, 61.50, 5008300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.5, 61.87, 61.18, 61.79, 6662500));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.79, 63.41, 62.72, 63.16, 5254000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.16, 64.40, 63.65, 63.89, 5356600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.89, 63.45, 61.60, 61.87, 5052600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.87, 62.35, 61.30, 61.54, 6266700));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.54, 61.49, 60.33, 61.06, 6190800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.06, 60.78, 59.84, 60.09, 6452300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 60.09, 59.62, 58.62, 58.80, 5954000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 58.8, 59.60, 58.89, 59.53, 6250000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 59.53, 60.96, 59.42, 60.68, 5307300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 60.68, 61.12, 60.65, 60.73, 6192900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 60.73, 61.19, 60.62, 61.19, 6355600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.19, 61.07, 60.54, 60.97, 2946300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 60.97, 61.05, 59.65, 59.75, 2257600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 59.75, 60.58, 55.99, 59.93, 2872000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 59.93, 60.12, 59.26, 59.73, 2737500));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 59.73, 60.11, 59.35, 59.57, 2589700));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 59.57, 60.40, 59.60, 60.10, 7315800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 60.1, 60.31, 59.76, 60.28, 6883900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 60.28, 61.68, 60.50, 61.50, 5570700));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 61.5, 62.72, 61.64, 62.26, 5976000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 62.26, 64.08, 63.10, 63.70, 3641400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 63.7, 64.60, 63.99, 64.39, 6711600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.39, 64.45, 63.92, 64.25, 6427000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.25, 65.40, 64.66, 64.70, 5863200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.7, 65.86, 65.32, 65.75, 4711400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.75, 65.22, 64.63, 64.75, 5930600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.75, 65.39, 64.76, 65.04, 5602700));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.04, 65.30, 64.78, 65.18, 7487300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.18, 65.09, 64.42, 65.09, 9085400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.09, 65.64, 65.20, 65.25, 6455300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.25, 65.59, 64.74, 64.84, 6135500));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 64.84, 65.84, 65.42, 65.82, 5846400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 65.82, 66.75, 65.85, 66.00, 6681200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 66, 67.41, 66.17, 67.41, 8780000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.41, 68.61, 68.06, 68.41, 10780900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.41, 68.91, 68.42, 68.76, 2336450));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.76, 69.58, 68.86, 69.01, 11902000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 69.01, 69.14, 68.74, 68.94, 7513300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.94, 68.73, 68.06, 68.65, 12074800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.65, 68.79, 68.19, 68.67, 8785400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.67, 69.75, 68.68, 68.74, 11373200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.74, 68.82, 67.71, 67.76, 12378300));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.76, 69.05, 68.43, 69.00, 8458700));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 69, 68.39, 67.77, 68.02, 10779200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.02, 67.94, 67.22, 67.72, 9665400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.72, 68.15, 67.32, 67.32, 12258400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.32, 67.95, 67.13, 67.32, 7563600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.32, 68.00, 67.16, 67.96, 5509900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.96, 68.89, 68.34, 68.61, 12135500));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.61, 69.47, 68.30, 68.51, 8462000));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.51, 68.69, 68.21, 68.62, 2011950));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.62, 68.39, 65.80, 68.37, 8536800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.37, 67.75, 65.00, 62.00, 7624900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.62, 67.04, 65.04, 67.00, 13694600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 66, 66.83, 65.02, 67.60, 8911200));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 66.6, 66.98, 65.44, 66.73, 6679600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 66.73, 66.84, 65.10, 66.11, 6451900));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 66.11, 66.59, 65.69, 66.38, 6739100));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 66.38, 67.98, 66.51, 67.67, 2103260));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.67, 69.21, 68.59, 68.90, 10551800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.9, 69.96, 69.27, 69.44, 5261100));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 69.44, 69.01, 68.14, 68.18, 5905400));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.18, 68.93, 68.08, 68.14, 10283600));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 68.14, 68.60, 66.92, 67.25, 5006800));
            dateTime = dateTime.AddMonths(1);
            datas1.Add(new DataPoint(dateTime, 67.25, 67.77, 67.23, 67.77, 4110000));
            return datas1;
        }

        public static List<DataPoint> BubbleSeries()
        {
            DateTime dt = new DateTime(2000, 1, 1);

            var Datas = new List<DataPoint>()
            {
                new DataPoint ( dt.AddMonths(4),  70 , 5),
                new DataPoint ( dt.AddMonths(8),  50 , 8),
                new DataPoint ( dt.AddMonths(12),  -30 , 30),
                new DataPoint ( dt.AddMonths(16),  -70 , 10),
                new DataPoint ( dt.AddMonths(20),  40 , 12),
                new DataPoint ( dt.AddMonths(24),  80 , 13),
                new DataPoint ( dt.AddMonths(28),  -70 , 6),
                new DataPoint ( dt.AddMonths(32),  30 , 8),
                new DataPoint ( dt.AddMonths(36),  80 , 3),
                new DataPoint ( dt.AddMonths(40),  -30 , 5),
                new DataPoint ( dt.AddMonths(44),  -80 , 7),
                new DataPoint ( dt.AddMonths(48),  40 , 3),
                new DataPoint ( dt.AddMonths(52),  -50 , 8),
                new DataPoint ( dt.AddMonths(56),  -10 , 4),
                 new DataPoint ( dt.AddMonths(60),  -80 , 9),
                new DataPoint ( dt.AddMonths(64),  40 , 10),
                new DataPoint ( dt.AddMonths(68),  -50 , 6)
            };
            return Datas;
        }
        public static List<DataPoint> GetGradientData()
        {
            DateTime date = new DateTime(2017, 5, 1);

            List<DataPoint> gradientData = new List<DataPoint>();

            gradientData.Add(new DataPoint(29, 80, date));
            gradientData.Add(new DataPoint(33, 80, date.AddDays(6)));
            gradientData.Add(new DataPoint(24, 80, date.AddDays(15)));
            gradientData.Add(new DataPoint(28, 80, date.AddDays(23)));
            gradientData.Add(new DataPoint(26, 80, date.AddDays(30)));
            gradientData.Add(new DataPoint(38, 80, date.AddDays(39)));
            gradientData.Add(new DataPoint(32, 80, date.AddDays(50)));

            return gradientData;
        }

    }

    public class Data
    {
        public static List<DataPoint> GetDateTimeValue()
        {
            var dateTime = new DateTime(2017, 1, 1);

            var datas = new List<DataPoint>();

            System.Random random = new System.Random();
            double value = 100;

            for (int i = 0; i < 365; i++)
            {
                if (random.NextDouble() > 0.5)

                    value += random.NextDouble();
                else
                    value -= random.NextDouble();
                datas.Add(new DataPoint(dateTime, value));
                dateTime = dateTime.AddDays(1);
            }

            return datas;
        }

        public static List<DataPoint> GetAreaData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 45));
            datas.Add(new DataPoint("2011", 56));
            datas.Add(new DataPoint("2012", 23));
            datas.Add(new DataPoint("2013", 43));
            datas.Add(new DataPoint("2014", Double.NaN));
            datas.Add(new DataPoint("2015", 54));
            datas.Add(new DataPoint("2016", 43));
            datas.Add(new DataPoint("2017", 23));
            datas.Add(new DataPoint("2018", 34));
            return datas;
        }

        public static List<DataPoint> GetData1()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 45));
            datas.Add(new DataPoint("2011", 86));
            datas.Add(new DataPoint("2012", 23));
            datas.Add(new DataPoint("2013", 43));
            datas.Add(new DataPoint("2014", 54));
            return datas;
        }
        public static List<DataPoint> GetCategoryData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("South Korea", 39));
            datas.Add(new DataPoint("India", 20));
            datas.Add(new DataPoint("South Africa", 61));
            datas.Add(new DataPoint("China", 65));
            datas.Add(new DataPoint("France", 45));
            datas.Add(new DataPoint("Saudi Arabia", 10));
            datas.Add(new DataPoint("Japan", 16));
            datas.Add(new DataPoint("Mexico", 31));
            return datas;
        }

        public static List<DataPoint> GetNumericalData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint(1, 54));
            datas.Add(new DataPoint(2, 24));
            datas.Add(new DataPoint(3, 53));
            datas.Add(new DataPoint(4, 63));
            datas.Add(new DataPoint(5, 35));
            return datas;
        }

        public static List<DataPoint> GetData2()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 54));
            datas.Add(new DataPoint("2011", 24));
            datas.Add(new DataPoint("2012", 53));
            datas.Add(new DataPoint("2013", 63));
            datas.Add(new DataPoint("2014", 35));
            return datas;
        }

        public static List<DataPoint> GetData3()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 14));
            datas.Add(new DataPoint("2011", 54));
            datas.Add(new DataPoint("2012", 23));
            datas.Add(new DataPoint("2013", 53));
            datas.Add(new DataPoint("2014", 25));
            return datas;
        }

        public static List<DataPoint> GetFinancialData()
        {
            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 873.8, 878.85, 855.5, 860.5));
            datas.Add(new DataPoint("2011", 861, 868.4, 835.2, 843.45));
            datas.Add(new DataPoint("2012", 846.15, 853, 838.5, 847.5));
            datas.Add(new DataPoint("2013", 846, 860.75, 841, 855));
            datas.Add(new DataPoint("2014", 841, 845, 827.85, 838.65));
            return datas;
        }

        public static List<DataPoint> CrossingData()
        {
            var axisCrossingData = new List<DataPoint>();

            axisCrossingData.Add(new DataPoint("2000", 70, 5));
            axisCrossingData.Add(new DataPoint("2001", 50, 8));
            axisCrossingData.Add(new DataPoint("2002", -30, 30));
            axisCrossingData.Add(new DataPoint("2003", -70, 10));
            axisCrossingData.Add(new DataPoint("2004", 40, 12));
            axisCrossingData.Add(new DataPoint("2005", 80, 13));
            axisCrossingData.Add(new DataPoint("2006", -70, 6));
            axisCrossingData.Add(new DataPoint("2007", 30, 8));
            axisCrossingData.Add(new DataPoint("2008", 80, 3));
            axisCrossingData.Add(new DataPoint("2009", -30, 5));
            axisCrossingData.Add(new DataPoint("2010", -80, 7));
            axisCrossingData.Add(new DataPoint("2011", 40, 3));
            axisCrossingData.Add(new DataPoint("2012", -50, 8));
            axisCrossingData.Add(new DataPoint("2013", -10, 4));
            axisCrossingData.Add(new DataPoint("2014", -80, 9));
            axisCrossingData.Add(new DataPoint("2015", 40, 10));
            axisCrossingData.Add(new DataPoint("2016", -50, 6));

            return axisCrossingData;
        }
    }
}