#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
    public class GradientChartViewModel
    {
        public ObservableCollection<OxygenRate> OxygenHighDate { get; set; }

        public GradientChartViewModel()
        {
            DateTime date = new DateTime(2017, 5, 1);

            OxygenHighDate = new ObservableCollection<OxygenRate>();
            OxygenHighDate.Add(new OxygenRate { High = 29, Low= 80, Date= date});
            OxygenHighDate.Add(new OxygenRate { High = 33,Low = 80, Date = date.AddDays(6) });
            OxygenHighDate.Add(new OxygenRate { High = 24,Low = 80, Date = date.AddDays(15) });
            OxygenHighDate.Add(new OxygenRate { High = 28,Low = 80, Date = date.AddDays(23) });
            OxygenHighDate.Add(new OxygenRate { High = 26,Low = 80, Date = date.AddDays(30) });
            OxygenHighDate.Add(new OxygenRate { High = 38,Low = 80, Date = date.AddDays(39) });
             OxygenHighDate.Add(new OxygenRate { High = 32,Low = 80, Date = date.AddDays(50) });
        }
    }

    public class OxygenRate
    {
        public double High
        {
            get;
            set;
        }

        public double Low 
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
    }
}
