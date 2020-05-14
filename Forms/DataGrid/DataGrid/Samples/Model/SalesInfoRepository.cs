#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SalesInfoRepository.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class used to store the item values 
    /// </summary>
    public class SalesInfoRepository
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private readonly List<string> salesParsonNames = new List<string>()
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

        /// <summary>
        /// Generates days with given count
        /// </summary>
        /// <param name="days">generates row count</param>
        /// <returns>SalesByDate collection values</returns>
        public ObservableCollection<SalesByDate> GetSalesDetailsByDay(int days)
        {
            var collection = new ObservableCollection<SalesByDate>();
            var r = new Random();
            for (var i = 0; i < days; i++)
            {
                var dt = DateTime.Now;
                var s = new SalesByDate
                {
                    Name = this.salesParsonNames[r.Next(5)],
                    QS1 = i,
                    QS2 = ((i < 30 ? 100 : 900 - i) * (i + 1)) + r.NextDouble(),
                    QS3 = r.Next(20, 50),
                    QS4 = r.Next(40, 75),
                };
                s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4;
                s.Date = dt.AddDays(-1 * i);
                collection.Add(s);
            }

            return collection;
        }
    }
}
