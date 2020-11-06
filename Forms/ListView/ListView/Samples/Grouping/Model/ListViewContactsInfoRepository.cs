#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    class ListViewContactsInfoRepository
    {
        #region Fields

        private Random random = new Random();

        #endregion

        #region Constructor

        public ListViewContactsInfoRepository()
        {

        }

        #endregion

        #region Get Contacts Details

        public ObservableCollection<ListViewContactsInfo> GetContactDetails(int count)
        {
            ObservableCollection<ListViewContactsInfo> customerDetails = new ObservableCollection<ListViewContactsInfo>();
            int girlsCount = 0, boysCount = 0;
            for (int i = 0; i < count; i++)
            {
                var details = new ListViewContactsInfo()
                {
                    ContactType = contactType[random.Next(0, 5)],
                    ContactNumber = random.Next(100, 400).ToString() + "-" + random.Next(500, 800).ToString() + "-" + random.Next(1000, 2000).ToString(),
                    ContactImage = "People_Circle" + (i % 19) + ".png",
                };

                if (imagePosition.Contains(i % 19))
                    details.ContactName = CustomerNames_Boys[boysCount++ % 32];
                else
                    details.ContactName = CustomerNames_Girls[girlsCount++ % 93];

                customerDetails.Add(details);
            }
            return customerDetails;
        }

        #endregion

        #region Contacts Information

        int[] imagePosition = new int[]
        {
            5,
            8,
            12,
            14,
            18
        };

        string[] contactType = new string[]
        {
            "HOME",
            "WORK",
            "MOBILE",
            "OTHER",
            "BUSINESS"
        };

        string[] CustomerNames_Girls = new string[]
        {
            "Kyle",
            "Gina",
            "Brenda",
            "Danielle",
            "Fiona",
            "Lila",
            "Jennifer",
            "Liz",
            "Pete",
            "Katie",
            "Vince",
            "Fiona",
            "Liam   ",
            "Georgia",
            "Elijah ",
            "Alivia",
            "Evan   ",
            "Ariel",
            "Vanessa",
            "Gabriel",
            "Angelina",
            "Eli    ",
            "Remi",
            "Levi",
            "Alina",
            "Layla",
            "Ella",
            "Mia",
            "Emily",
            "Clara",
            "Lily",
            "Melanie",
            "Rose",
            "Brianna",
            "Bailey",
            "Juliana",
            "Valerie",
            "Hailey",
            "Daisy",
            "Sara",
            "Victoria",
            "Grace",
            "Layla",
            "Josephine",
            "Jade",
            "Evelyn",
            "Mila",
            "Camila",
            "Chloe",
            "Zoey",
            "Nora",
            "Ava",
            "Natalia",
            "Eden",
            "Cecilia",
            "Finley",
            "Trinity",
            "Sienna",
            "Rachel",
            "Sawyer",
            "Amy",
            "Ember",
            "Rebecca",
            "Gemma",
            "Catalina",
            "Tessa",
            "Juliet",
            "Zara",
            "Malia",
            "Samara",
            "Hayden",
            "Ruth",
            "Kamila",
            "Freya",
            "Kali",
            "Leiza",
            "Myla",
            "Daleyza",
            "Maggie",
            "Zuri",
            "Millie",
            "Lilliana",
            "Kaia",
            "Nina",
            "Paislee",
            "Raelyn",
            "Talia",
            "Cassidy",
            "Rylie",
            "Laura",
            "Gracelynn",
            "Heidi",
            "Kenzie",
        };

        string[] CustomerNames_Boys = new string[]
        {
            "Irene",
            "Watson",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Howard",
            "Daniel",
            "Frank",
            "Jack",
            "Oscar",
            "Larry",
            "Holly",
            "Steve",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason",
            "Jacob  ",
            "Jayden ",
            "Ethan  ",
            "Noah   ",
            "Lucas  ",
            "Brayden",
            "Logan  ",
            "Caleb  ",
            "Caden  ",
            "Benjamin",
            "Xaviour",
            "Ryan   ",
            "Connor ",
            "Michael",           
        };

        #endregion
    }
}