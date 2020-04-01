#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser.SfChart
{
    public class SplineRangeAreaSeriesViewModel
    {
        public ObservableCollection<Person> SplineRangeAreaData { get; set; }

        public ObservableCollection<Person> SplineRangeAreaData1 { get; set; }

        public SplineRangeAreaSeriesViewModel()
        {
            SplineRangeAreaData = new ObservableCollection<Person>
            {
                new Person("Jan", 45, 32),
                new Person("Feb", 48, 34),
                new Person("Mar", 46, 32),
                new Person("Apr", 48, 36),
                new Person("May", 46, 32),
                new Person("Jun", 49, 34)
            };


            SplineRangeAreaData1 = new ObservableCollection<Person>
            {
                new Person("Jan", 30, 18),
                new Person("Feb", 24, 12),
                new Person("Mar", 29, 15),
                new Person("Apr", 24, 10),
                new Person("May", 30, 18),
                new Person("Jun", 24, 10)
            };
        }

        public class Person
        {
            public string Name { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
            public Person(string name, double high, double low)
            {
                Name = name;
                High = high;
                Low = low;
            }
        }
    }
}

