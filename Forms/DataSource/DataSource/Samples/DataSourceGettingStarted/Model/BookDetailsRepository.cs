#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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

namespace SampleBrowser.DataSource
{
    [Preserve(AllMembers = true)]
    public class BookDetailsRepository
    {
        public BookDetailsRepository()
        {
        }

        #region private variables

        private Random random = new Random();

        #endregion

        #region GetBookDetails

        public ObservableCollection<BookDetails> GetBookDetails(int count)
        {
            ObservableCollection<BookDetails> bookDetails = new ObservableCollection<BookDetails>();

            Assembly assembly = typeof(DataSourceGettingStarted).GetTypeInfo().Assembly;
            for (int i = 1; i <= count; i++)
            {
                var ord = new BookDetails()
                {
                    BookID = "Book ID : " + BookID[random.Next(8)].ToString(),
                    BookName = "Book name : " + BookNames[random.Next(5)],
                    Price = "Price : " + "$" + random.Next(30, 200).ToString(),
                    CustomerName = "Name : " + CustomerNames[(i % 23)],
                    CustomerImage = "People_Circle" + (i % 19) + ".png",
                };
                bookDetails.Add(ord);
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

        string[] CustomerNames = new string[] {
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

        #endregion
    }
}

