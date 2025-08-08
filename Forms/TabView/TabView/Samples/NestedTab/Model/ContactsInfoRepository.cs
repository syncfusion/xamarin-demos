#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTabView
{
    [Preserve(AllMembers = true)]
    public class ContactsInfoRepository
    {
        #region Fields

        private Random random = new Random();

        #endregion

        #region Constructor

        public ContactsInfoRepository()
        {

        }

        #endregion

        #region Get Contacts Details

        public ObservableCollection<ContactsInfo> GetContactDetails(int incValue)
        {
            ObservableCollection<ContactsInfo> customerDetails = new ObservableCollection<ContactsInfo>();

            for (int i = incValue; i < CustomerNames.Count(); i = i+ incValue)
            {
                var   dateTime = DateTime.Now.AddHours(-10 * i);
                dateTime = DateTime.Now.AddSeconds(-45 * (i + i));
                dateTime = DateTime.Now.AddSeconds(-2*i);
                var details = new ContactsInfo()
                {
                    Message = contactType[(i % 19)],
                    ContactReadType = CustomerNames[i][0].ToString(),
                    ContactName = CustomerNames[i],
                    ContactNumber = "123-456-789",

                    ContactImage = imageColor[(i % 5)],
                    Date = dateTime.ToString(),
                    DateMonth = dateTime.Minute.ToString() + ":" + dateTime.Second.ToString(),
                    MessageCount = dateTime.DayOfWeek.ToString()
                    
                };
                customerDetails.Add(details);
            }
            return customerDetails;
        }

        #endregion

        #region Contacts Information

        string[] contactType = new string[]
        {
            "Hi,",
            "Sent a file",
            "Welcome",
            "Can you join the meeting?",
             ":),",
            "Thank you :)",
            "I am waiting",
            "That's Great!",
            "Okay",
            "ok sure",
             "I'm in meeting",
            "where is the book?",
            "need to do it now",
            "share me the file",
            "Cool?",
             ":) that's right,",
            "Thanks :)",
            "On the way",
            "Yes, But need to check",
            "It's possible?"
        };

        string[] imageColor = new string[]
{
            "#FFFFAEC9",
            "#FFFF7F27",
            "#FF00A2E8",
            "#FFA349A4",
             "#FFB5E61D"

};

        string[] CustomerNames = new string[] 
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
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason",
            "Liam",
            "Jacob",
            "Jayden",
            "Ethan",
            "Noah",
            "Lucas",
            "Logan",
            "Caleb",
            "Caden",
            "Jack",
            "Ryan",
            "Connor",
            "Michael",
            "Elijah",
            "Brayden",
            "Benjamin",
            "Nicholas",
            "Alexander",
            "William",
            "Matthew",
            "James",
            "Landon",
            "Nathan",
            "Dylan",
            "Evan",
            "Luke",
            "Andrew",
            "Gabriel",
            "Gavin",
            "Joshua",
            "Owen",
            "Daniel",
            "Carter",
            "Tyler",
            "Cameron",
            "Christian",
            "Wyatt",
            "Henry",
            "Eli",
            "Joseph",
            "Max",
            "Isaac",
            "Samuel",
            "Anthony",
            "Grayson",
            "Zachary",
            "David",
            "Christopher",
            "John",
            "Isaiah",
            "Levi",
            "Jonathan",
            "Oliver",
            "Chase",
            "Cooper",
            "Tristan",
            "Colton",
            "Austin",
            "Colin",
            "Charlie",
            "Dominic",
            "Parker",
            "Hunter",
            "Thomas",
            "Alex",
            "Ian",
            "Jordan",
            "Cole",
            "Julian",
            "Aaron",
            "Carson",
            "Miles",
            "Blake",
            "Brody",
            "Adam",
            "Sebastian",
            "Adrian",
            "Nolan",
            "Sean",
            "Riley",
            "Bentley",
            "Xavier",
            "Hayden",
            "Jeremiah",
            "Jason",
            "Jake",
            "Asher",
            "Micah",
            "Jace",
            "Brandon",
            "Josiah",
            "Hudson",
            "Nathaniel",
            "Bryson",
            "Ryder",
            "Justin",
            "Bryce",
        };

        #endregion
    }
}
