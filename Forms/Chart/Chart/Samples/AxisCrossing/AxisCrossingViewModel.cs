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
    public class SalesModel
    {
        public double YValue { get; set; }

        public double Size { get; set; }

        public string XValue { get; set; }
        
    }

    public class AxisCrossingViewModel
    {
        public ObservableCollection<SalesModel> Data { get; set; }

        public AxisCrossingViewModel()
        {
            Data = new ObservableCollection<SalesModel>()
            {
                new SalesModel { XValue = "2000", YValue = 70 },
                new SalesModel { XValue = "2001", YValue = 50 },
                new SalesModel { XValue = "2002", YValue = -30},
                new SalesModel { XValue = "2003", YValue = -70},
                new SalesModel { XValue = "2004", YValue = 40 },
                new SalesModel { XValue = "2005", YValue = 80 },
                new SalesModel { XValue = "2006", YValue = -70},
                new SalesModel { XValue = "2007", YValue = 30 },
                new SalesModel { XValue = "2008", YValue = 80 },
                new SalesModel { XValue = "2009", YValue = -30},
                new SalesModel { XValue = "2010", YValue = -80},
                new SalesModel { XValue = "2011", YValue = 40 },
                new SalesModel { XValue = "2012", YValue = -50},
                new SalesModel { XValue = "2013", YValue = -10},
                new SalesModel { XValue = "2014", YValue = -80},
                new SalesModel { XValue = "2015", YValue = 40 },
                new SalesModel { XValue = "2016", YValue = -50}

            };            
        }
    }
}
