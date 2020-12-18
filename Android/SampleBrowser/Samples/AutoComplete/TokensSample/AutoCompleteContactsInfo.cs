#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleBrowser
{
	public class AutoCompleteContactsInfo
	{
		public string ContactName { get; set; }
		public string ContactNumber { get; set; }
		public string ContactType { get; set; }
		public string ContactImage { get; set; }
	}

	public class AutoCompleteContactsInfoRepository
	{
		#region Fields

		private Random random = new Random();

		#endregion

		#region Constructor

		public AutoCompleteContactsInfoRepository()
		{

		}

		#endregion

		#region Get Contacts Details

		public ObservableCollection<AutoCompleteContactsInfo> GetContactDetails()
		{
			ObservableCollection<AutoCompleteContactsInfo> customerDetails = new ObservableCollection<AutoCompleteContactsInfo>();

			for (int i = 0; i < CustomerNames2.Count(); i++)
			{
				var details = new AutoCompleteContactsInfo()
				{
					ContactType = contactType[random.Next(0, 5)],
					ContactName = CustomerNames2[i],
					ContactNumber = CustomerNames2[i].Replace(" ", "") + "@outlook.com",

					ContactImage = "b" + (i % 14) + ".png",
				};
				customerDetails.Add(details);
				if (i < 23)
				{
					details = new AutoCompleteContactsInfo()
					{
						ContactType = contactType[random.Next(0, 5)],
						ContactName = CustomerNames1[i],
						ContactNumber = CustomerNames1[i].Replace(" ", "") + "@outlook.com",

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
			"Available.png",
			"Offline.png",
			"Away.png",
			"Busy.png",
			"DND.png"
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
			"Irene",
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
