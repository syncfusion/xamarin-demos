#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
    public class BookRepository
	{
		public BookRepository ()
		{
		}

		#region private variables

		private Random random = new Random ();

		#endregion

		#region GetBookDetails

		public List<BookInfo> GetBookDetails (int count)
		{
			List<BookInfo> bookDetails = new List<BookInfo> ();

			for (int i = 1; i <= count; i++) {
				var ord = new BookInfo () {
					CustomerID = i, 
					BookID = BookID [random.Next (15)],
					BookName = BookNames [random.Next (15)],
					Country = Country [random.Next (15)],
					Price = random.Next (30, 200),
					FirstName = Customers [random.Next (15)],
					LastName = LastNames [random.Next (15)],
				};
				bookDetails.Add (ord);
			}
			return bookDetails;
		}

		#endregion

		#region DataSource

		string[] BookNames = new string[] {
			"Lucky Jim",
			"Money",
			"The Information",
			"The BottleFactory",
			"Flauberts Parrot",
			"Molloy",
			"Queen Lucia",
			"A Good Man",
			"The History Man",
			"The Horse",
			"Chocolate",
			"Just Willams",
			"Tom jones",
			"Caprice",
			"Towards the End ",
			"Polygots",
			"Death Soul",
			"Charade",
			"Changing places",
			"Under the Net",
			"Fire Flies",

		};

		int[] BookID = new int[] {
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

		string[] Country = new string[] {
			"India",
			"Europe",
			"America",
			"Europe",
			"Pakistan",
			"England",
			"France",
			"Bangladesh",
			"Argentina",
			"Austria",
			"Belgium",
			"Brazil",            
			"Canada",
			"Denmark",
			"Finland",
			"France",
			"Germany",
			"Ireland",
			"Italy",
			"Mexico",
			"Norway",
			"Poland",
			"Portugal",
			"Spain",
			"Sweden",
			"Switzerland",
			"UK",
			"USA",
			"Venezuela"
		};

		string[] Customers = new string[] {
			"Kyle",
			"Gina",
			"Irene",
			"Katie",
			"Michael",
			"Oscar",
			"Ralph",
			"Torrey",
			"William",
			"Bill",
			"Daniel",
			"Frank",
			"Brenda",
			"Danielle",
			"Fiona",
			"Howard",
			"Jack",
			"Larry",
			"Holly",
			"Jennifer",
			"Liz",
			"Pete",
			"Steve",
			"Vince",
			"Zeke"
		};

		string[] LastNames = new string[] {
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

		#endregion
	}
}

