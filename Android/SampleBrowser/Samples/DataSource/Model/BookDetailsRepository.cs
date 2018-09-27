#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Graphics;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SampleBrowser
{
	public class BookDetailsRepository
	{

        public BookDetailsRepository(Context context)
		{
            appContext = context;

        }

		#region private variables

		private Random r = new Random ();
        private Context appContext;

		#endregion

		#region GetBookDetails

		public ObservableCollection<BookDetails> GetBookDetails (int count)
		{
            ObservableCollection<BookDetails> bookDetails = new ObservableCollection<BookDetails>();

			for (int i = 1; i <= count; i++) {
                var imageData = LoadResource("Image" + (i % 23) + ".png").ToArray();
                var ord = new BookDetails()
                {
                    BookID = BookID[r.Next(8)],
                    BookName = BookNames[r.Next(5)],
                    Price = r.Next(30, 200),
                    CustomerName = CustomerNames[i % 23],
                    CustomerImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length),
                };
				bookDetails.Add (ord);
            }
			return bookDetails;
		}

        public MemoryStream LoadResource(String name)
        {
            MemoryStream aMem = new MemoryStream();

            var assm = Assembly.GetExecutingAssembly();

            var path = String.Format("SampleBrowser.Resources.drawable.{0}", name);

            var aStream = assm.GetManifestResourceStream(path);

            aStream.CopyTo(aMem);

            return aMem;
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

		string[] CustomerNames = new string[] {
			"Kyle",
			"Gina",
            "Oscar",
            "Irene",
			"Katie",
			"Michael",
            "Torrey",
            "Ralph",
			"William",
            "Brenda",
            "Fiona",
            "Bill",
			"Daniel",
			"Frank",
            "Larry",
            "Danielle",
			"Howard",
			"Jack",
			"Holly",
			"Jennifer",
			"Pete",
			"Steve",
			"Vince",
			"Zeke"
		};

		#endregion
	}
}

