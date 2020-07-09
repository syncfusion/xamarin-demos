#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using UIKit;

namespace SampleBrowser
{
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

            for (int i = 1; i <= count; i++)
            {
                var image = LoadResource("Image" + (i % 23) + ".png").ToArray();
                var imageData = NSData.FromArray(image);
                var customerImage = UIImage.LoadFromData(imageData, UIScreen.MainScreen.Scale);
                var ord = new BookDetails()
                {
                    BookID = BookID[random.Next(8)],
                    BookName = BookNames[random.Next(5)],
                    Price = random.Next(30, 200),
                    CustomerName = CustomerNames[random.Next(7)],
                    CustomerImage = customerImage
                };
                bookDetails.Add(ord);
            }
            return bookDetails;
        }

        public MemoryStream LoadResource(String Name)
        {
            MemoryStream aMem = new MemoryStream();

            var assm = Assembly.GetExecutingAssembly();

            var path = String.Format("SampleBrowser.Resources.Images.{0}", Name);

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