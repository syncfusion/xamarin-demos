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

namespace SampleBrowser.SfAutoComplete
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

		public ObservableCollection<ContactsInfo> GetContactDetails()
		{
			ObservableCollection<ContactsInfo> customerDetails = new ObservableCollection<ContactsInfo>();

			for (int i = 0; i < CustomerNames.Count(); i++)
			{
                    var details = new ContactsInfo()
                    {
                        ContactType = contactType[random.Next(0, 5)],
                        ContactName = CustomerNames[i],
                        ContactNumber = CustomerNames[i].Replace(" ", "") + "@outlook.com",
                        ContactImage = "People_Circle" + (i % 30) + ".png",
                    };
                    customerDetails.Add(details);
			}

			return customerDetails;
		}

		#endregion

		#region Contacts Information

		string[] contactType = new string[]
		{
			"Green.jpg",
			"Gray.jpg",
			"Yellow.jpg",
			"Red.jpg",
			"Orange_Shape.jpg"
		};

		string[] CustomerNames = new string[]
		{
            "Kyle",
            "Victoriya",
            "Clara",
            "Ellie",
			"Gabriella",
            "Alexander",
            "Nora",
			"Lucy",
            "Sebastian",
            "Arianna",
			"Sarah",
			"Kaylee",
            "Jacob",
            "Adriana",
            "Ethan",
            "Finley",
			"Daleyza",
			"Leila",
            "Jayden",
            "Mckenna",
			"Jacqueline",
			"Brynn",
			"Sawyer",
            "Liam",
            "Rosalie",
			"Maci",
            "Mason",
            "Jackson",
            "Miranda",
			"Talia",
			"Shelby",
			"Haven",
			"Yaretzi",
			"Zariah",
			"Karla",
            "Zeke",
            "Cassandra",
			"Pearl",
            "Aiden",
            "Irene",
			"Zelda",
			"Wren",
            "Vince",
            "Yamileth",
            "Steve",
            "Belen",
			"Briley",
			"Jada",
            "Holly",
            "Jaden"
        };

		#endregion
	}
}
