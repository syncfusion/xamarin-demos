#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "BookRepository.cs" company="Syncfusion.com">
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
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    ///  Used to Store the Item values 
    /// </summary>
    public class BookRepository
    {
        #region private variables

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random random = new Random();

        #endregion

        #region DataSource

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] bookNames = new string[] 
        {
            "Lucky Jim",
            "Money",
            "Information",
            "Bottle Factory",
            "Parrot",
            "Molloy",
            "Queen Lucia",
            "A Good Man",
            "The Man",
            "The Horse",
            "Chocolate",
            "Just Willams",
            "Tom jones",
            "Caprice",
            "The End ",
            "Polygots",
            "Death Soul",
            "Charade",
            "Changing",
            "The Net",
            "Fire Flies",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] bookID = new int[] 
        {
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] country = new string[] 
        {
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] firstNames = new string[] 
        {
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] lastNames = new string[] 
        {
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

        /// <summary>
        /// Initializes a new instance of the BookRepository class.
        /// </summary>
        public BookRepository()
        {
        }

        #region GetBookDetails

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generated row count</param>
        /// <returns>added book details</returns>
        public List<BookInfo> GetBookDetails(int count)
        {
            List<BookInfo> bookDetails = new List<BookInfo>();

            for (int i = 1101; i <= 1101 + count; i++)
            {
                var ord = new BookInfo()
                {
                    CustomerID = i,
                    BookID = this.bookID[this.random.Next(8)],
                    BookName = this.bookNames[this.random.Next(5)],
                    Country = this.country[this.random.Next(8)],
                    Price = this.random.Next(30, 200),
                    FirstName = this.firstNames[this.random.Next(7)],
                    LastName = this.lastNames[this.random.Next(9)],
                    IsAvailable = (i % this.random.Next(1, 10) > 2) ? true : false,
                };
                bookDetails.Add(ord);
            }

            return bookDetails;
        }

        #endregion
    }
}