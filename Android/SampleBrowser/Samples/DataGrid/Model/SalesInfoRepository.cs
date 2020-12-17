#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class SalesInfoRepository
    {
        private readonly List<string> _salesParsonNames = new List<string>()
        {
            "Gary Drury",
            "Maciej Dusza",
            "Shelley Dyck",
            "Linda Ecoffey",
            "Carla Eldridge",
            "Carol Elliott",
            "Shannon Elliott",
            "Jauna Elson",
            "Michael Emanuel",
            "Terry Eminhizer",
            "John Emory",
            "Gail Erickson",
            "Mark Erickson",
            "Martha Espinoza",
            "Julie Estes",
            "Janeth Esteves",
            "Twanna Evans"
        };

        public ObservableCollection<SalesByDate> GetSalesDetailsByDay(int days)
        {
            var collection = new ObservableCollection<SalesByDate>();
            var r = new Random();
            for (var i = 0; i < days; i++) {
                var dt = DateTime.Now;
                var s = new SalesByDate {
                    Name = _salesParsonNames[r.Next(5)],
                    QS1 = ((1000 - i) * (i + 1)) / 10,
                    QS2 = ((1000 - i) * (i + 1)) / 20,
                    QS3 = ((1000 - i) * (i + 1)) / 30,
                    QS4 = ((1000 - i) * (i + 1)) / 10,
				};
                    s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4;
                    s.Date = dt.AddDays(-1*i);
                    collection.Add(s);
                }
			return collection;
        }
    }
}