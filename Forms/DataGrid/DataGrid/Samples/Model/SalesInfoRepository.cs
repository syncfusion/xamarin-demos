#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataGrid
{
    [Preserve(AllMembers = true)]
    public class SalesInfoRepository
    {
        private readonly List<string> _salesParsonNames = new List<string>()
            {
                "Gary",
                "Maciej",
                "Shelley",
                "Linda",
                "Carla",
                "Carol",
                "Shannon",
                "Jauna",
                "Michael",
                "Terry",
                "John",
                "Gail",
                "Mark",
                "Martha",
                "Julie",
                "Janeth",
                "Twanna"
            };

		public ObservableCollection<SalesByDate> GetSalesDetailsByDay(int days)
		{
			var collection = new ObservableCollection<SalesByDate>();
			var r = new Random();
			for (var i = 0; i < days; i++) {
				var dt = DateTime.Now;
				var s = new SalesByDate {
					Name = _salesParsonNames [r.Next (5)],
					QS1 = i,
                    QS2 = (i < 30 ? 100 : 900 - i) * (i + 1) + r.NextDouble(),
                    QS3 = r.Next(20, 50),
                    QS4 = r.Next(40, 75),
				};
				s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4;
				s.Date = dt.AddDays(-1*i);
				collection.Add(s);
			}
			return collection;
		}
    }

    [Preserve(AllMembers = true)]
    public class SalesRepository
	{
		private readonly List<string> _salesParsonNames = new List<string>()
		{
			"Gary",
			"Maciej",
			"Shelley",
			"Linda",
			"Carla",
			"Carol",
			"Shannon",
			"Jauna",
			"Michael",
			"Terry",
			"John",
			"Gail",
			"Mark",
			"Martha",
			"Julie",
			"Janeth",
			"Twanna"
		};

		public ObservableCollection<SalesByDate> GetSalesDetailsByDay(int days)
		{
			var collection = new ObservableCollection<SalesByDate>();
			var r = new Random();
			for (var i = 0; i < days; i++) {
				var dt = DateTime.Now;
				foreach (var person in _salesParsonNames) {
					if (r.Next(0, 3) == 0) continue;
					var s = new SalesByDate {
						Name = person,
						QS1 = r.Next(100000, 1000000) * 0.01,
						QS2 = r.Next(100000, 1000000) * 0.01,
						QS3 = r.Next(100000, 1000000) * 0.01,
						QS4 = r.Next(100000, 1000000) * 0.01,
					};
					s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4;
					s.Date = dt.AddDays(-1*i);
					collection.Add(s);
				}
			}
			return collection;
		}
	}

    [Preserve(AllMembers = true)]
    public class SalesByDate : NotificationObject
    {
        private string _name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private double _qS1;

        /// <summary>
        /// Gets or sets the Q s1.
        /// </summary>
        /// <value>The Q s1.</value>
        public double QS1
        {
            get
            {
                return _qS1;
            }
            set
            {
                _qS1 = value;
                RaisePropertyChanged("QS1");
            }
        }

        private double _qS2;

        /// <summary>
        /// Gets or sets the Q s2.
        /// </summary>
        /// <value>The Q s2.</value>
        public double QS2
        {
            get
            {
                return _qS2;
            }
            set
            {
                _qS2 = value;
                RaisePropertyChanged("QS2");
            }
        }

        private double _qS3;

        /// <summary>
        /// Gets or sets the Q s3.
        /// </summary>
        /// <value>The Q s3.</value>
        public double QS3
        {
            get
            {
                return _qS3;
            }
            set
            {
                _qS3 = value;
                RaisePropertyChanged("QS3");
            }
        }

        private double _qS4;

        /// <summary>
        /// Gets or sets the Q s4.
        /// </summary>
        /// <value>The Q s4.</value>
        public double QS4
        {
            get
            {
                return _qS4;
            }
            set
            {
                _qS4 = value;
                RaisePropertyChanged("QS4");
            }
        }

        private double _total;

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
            }
        }

        private DateTime _year;

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public DateTime Date
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                RaisePropertyChanged("Date");
            }
        }
    }   
}
