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
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeMap
{
   [Preserve(AllMembers = true)]
    public class CountrySale
    {
        public string Name { get; set; }
        private double _sales = 0;
        public double Sales
        {
            get { return _sales; }
            set
            {
                if (_sales != value)
                {
                    _sales = value;

                }
            }
        }

        private double _expense = 0;
        public double Expense
        {
            get { return _expense; }
            set
            {
                if (_expense != value)
                {
                    _expense = value;

                }
            }
        }

        public ObservableCollection<RegionSale> RegionalSales { get; set; }

        public CountrySale()
        {
            this.RegionalSales = new ObservableCollection<RegionSale>();
        }


    }

    public class RegionSale
    {
        public string Name { get; set; }

        public string Country { get; set; }

        private double _sales = 0;
        public double Sales
        {
            get { return _sales; }
            set
            {
                if (_sales != value)
                {
                    _sales = value;

                }
            }
        }
        public double Expense { get; set; }


    }
}
