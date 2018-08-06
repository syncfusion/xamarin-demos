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
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataGrid
{
    [Preserve(AllMembers = true)]
    public class DealerRepository
	{

		#region private variables

		private Random random = new Random ();
        private List<DateTime> shippedDate;

		#endregion

        #region GetDealerDetails

        public ObservableCollection<DealerInfo> GetDealerDetails (int count)
		{
			ObservableCollection<DealerInfo> dealerDetails = new ObservableCollection<DealerInfo> ();
            var assembly = Assembly.GetAssembly(this.GetType());
            this.shippedDate = GetDateBetween(2001, 2016, count);
			for (int i = 1; i <= count; i++) {
                var ord = new DealerInfo() {
                    ProductID = 1100 + i,
                    ProductNo = ProductNo[random.Next(15)],
                    DealerName = Customers[random.Next(15)],
                    ProductPrice = random.Next(2000, 10000),
                    IsOnline = ((i % random.Next(1, 10) > 2) ? true : false),
#if COMMONSB
                    DealerImage = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Image" + (i % 10) + ".png",assembly),
#else
                    DealerImage = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.Image" + (i % 10) + ".png", assembly),
#endif
                    ShippedDate = this.shippedDate[i-1],
				};
				dealerDetails.Add (ord);
			}

			return dealerDetails;
		}

#endregion

		int[] ProductNo = new int[] {
			1803,
			1345,
			4523,
			4932,
			9475,
			5243,
			4263,
			2435,
			3527,
			3634,
			2523,
			3652,
			3524,
			6532,
			2123
		};

		public string[] Customers = new string[] {
			"Adams",
			"Crowley",
			"Ellis",
			"Gable",
			"Irvine",
			"Keefe",
			"Mendoza",
			"Owens",
			"Rooney",
			"Waddell",
			"Thomas",
			"Betts",
			"Doran",
			"Fitzgerald",
			"Holmes",
			"Jefferson",
			"Landry",
			"Newberry",
			"Perez",
			"Spencer",
			"Vargas",
			"Grimes",
			"Edwards",
			"Stark",
			"Cruise",
			"Fitz",
			"Chief",
			"Blanc",
			"Perry",
			"Stone",
			"Williams",
			"Lane",
			"Jobs"
		};

        private List<DateTime> GetDateBetween(int startYear, int endYear, int count)
        {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < count; i++)
            {
                int year = y.Next(startYear, endYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }
            return date;
        }

    }
}

