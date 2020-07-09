#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System;
namespace SampleBrowser.SfChart
{
	public class DateTimeAxisViewModel
	{
		public ObservableCollection<Production> DateTimeData { get; set; }

		public DateTimeAxisViewModel()
		{
            DateTimeData = new ObservableCollection<Production>();

            Random rand = new Random();
            double value = 100;
            DateTime date = new DateTime(2017, 1, 1);

            for (int i = 0; i < 365; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();


                DateTimeData.Add(new Production { Growth = value, Date = date });
                date = date.AddDays(1);

            }
        }
	}

    public class Production
    {
        public double Growth
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