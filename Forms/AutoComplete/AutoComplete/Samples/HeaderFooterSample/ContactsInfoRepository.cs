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

namespace HeaderFooter
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

			for (int i = 0; i < CustomerNames2.Count(); i++)
			{
				var details = new ContactsInfo()
				{
					Message = contactType[(i % 19)],
                    ContactReadType = (i < 5),
					ContactName = CustomerNames2[i],
					ContactNumber = "@" + CustomerNames2[i].Replace(" ", ".").ToLower() + random.Next(1000).ToString(),

					ContactImage = "b" + (i % 14) + ".png",
				};

				customerDetails.Add(details);
				if (i < 23)
				{
					details = new ContactsInfo()
					{
						Message = contactType[(i % 19)],
						ContactReadType = (i < 5),
						ContactName = CustomerNames1[i],
						ContactNumber = "@" + CustomerNames1[i].Replace(" ", ".").ToLower() + random.Next(1000).ToString(),

						ContactImage = "a" + (i % 6) + ".png",
					};
					customerDetails.Add(details);
				}
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
			"You: I am waiting",
			"That's Great!",
			"You: Okay",
			"ok sure",
			 "I'm in meeting",
			"where is the book?",
			"You: need to do it now",
			"share me the file",
			"Cool?",
			 ":) that's right,",
			"Thanks :)",
			"You: On the way",
			"Yes, But need to check",
			"It's possible?"
		};

		string[] CustomerNames1 = new string[]
		{
			"Kyle",
			"Gina",
			"Michael",
			"Oscar",
			"William",
			"Bill",
			"Daniel",
			"Frank",
			"Howard",
			"Jack",
			"Holly",
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
			"Alexander",
			"Sebastian",
		};

		string[] CustomerNames2 = new string[]
		{
			"Clara",
            "Victoriya",
            "Ellie",
            "Gabriella",
            "Nora",
            "Lucy",
            "Arianna",
            "Sarah",
            "Kaylee",
            "Adriana",
            "Finley",
            "Daleyza",
            "Leila",
            "Mckenna",
            "Jacqueline",
            "Brynn",
            "Sawyer",
            "Rosalie",
            "Maci",
            "Miranda",
            "Talia",
            "Shelby",
            "Haven",
            "Yaretzi",
            "Zariah",
            "Karla",
            "Cassandra",
            "Pearl",
            "Irene",
            "Zelda",
            "Wren",
            "Yamileth",
            "Belen",
            "Briley",
            "Jada",
            "Jaden"
		};

		#endregion
	}
}
