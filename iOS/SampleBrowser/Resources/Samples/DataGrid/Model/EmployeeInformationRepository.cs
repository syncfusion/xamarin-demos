#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class EmployeeInformationRepository
	{
		public EmployeeInformationRepository ()
		{
		}

		#region private variables

		private ObservableCollection<DateTime> BirthDates;
		private ObservableCollection<DateTime> HireDates;
		private Random random = new Random ();

		#endregion

		#region GetOrderDetails

		public ObservableCollection<EmployeeInformation> GetEmployeeDetails (int count)
		{
			setCity ();
			this.BirthDates = GetDateBetween (1980, 1992, count);
			this.HireDates = GetDateBetween (2005, 2014, count);
			ObservableCollection<EmployeeInformation> employeeDetails = new ObservableCollection<EmployeeInformation> ();

			for (int i = 0; i < count; i++) {
				var country = Countries [random.Next (1)];
				var city = Cities [country];

				var emp = new EmployeeInformation () {
					EmployeeID = i + 1,
					FirstName = FirstNames [i % FirstNames.Length],
					LastName = LastNames [i % LastNames.Length],
					Designation = Titles [random.Next (5)],
					DateOfBirth = BirthDates [i],
					DateOfJoining = HireDates [i],
					Address = Addresses [random.Next (6)],
					Country = Countries [random.Next (2)],
					City = city [random.Next (city.Length - 1)],
					Telephone = HomePhones [random.Next (8)],
					Qualification = Notes [i % Notes.Length],
				};
				employeeDetails.Add (emp);
			}
			return employeeDetails;
		}

		#endregion

		#region MainGrid DataSource

		private ObservableCollection<DateTime> GetDateBetween (int startYear, int endYear, int count)
		{
			ObservableCollection<DateTime> date = new ObservableCollection<DateTime> ();
			Random d = new Random (1);
			Random m = new Random (2);
			Random y = new Random (startYear);
			for (int i = 0; i < count; i++) {
				int year = y.Next (startYear, endYear);
				int month = m.Next (3, 13);
				int day = d.Next (1, 31);

				date.Add (new DateTime (year, month, day));
			}
			return date;
		}

		string[] Titles = new string[] {
			"Sales Representative",
			"Vice President, Sales",
			"Sales Representative",
			"Sales Manager",
			"Inside Sales Coordinator",
			"Business Manager",
			"Mail Clerk",
			"Receptionist",
			"Marketing Director",
			"Marketing Associate",
			"Advertising Specialist"
		};

		string[] FirstNames = new string[] {
			"Nancy",
			"Andrew",
			"Janet",
			"Margaret",
			"Steven",
			"Michael",
			"Robert",
			"Laura",
			"Anne",
			"Albert",
			"Caroline",
			"Xavier",
		};

		string[] LastNames = new string[] {
			"Davolio",
			"Fuller",
			"Leverling",
			"Peacock",
			"Buchanan",
			"Suyama",
			"King",
			"Callahan",
			"Dodsworth",
			"Hellstern",
			"Patterson",
			"Martin",
		};

		string[] HomePhones = new string[] {
			"(206) 555-9857",
			"(206) 555-9482",
			"(206) 555-3412",
			"(206) 555-8122",
			"(71) 555-4848",
			"(71) 555-7773",
			"(71) 555-5598",
			"(206) 555-1189",
			"(71) 555-4444",
			"(206) 555-4869",
			"(206) 555-3857",
			"(206) 555-3487",
			"88 83 83 16",
			"88 62 43 53",
			"88 01 01 68",
		};

		string[] Addresses = new string[] {
			"507 - 20th Ave. E. Apt. 2A",
			"908 W. Capital Way",
			"722 Moss Bay Blvd.",
			"4110 Old Redmond Rd.",
			"14 Garrett Hill",
			"Coventry House Miner Rd.",
			"Edgeham Hollow Winchester Way",
			"4726 - 11th Ave. N.E.",
			"7 Houndstooth Rd.",
			"13920 S.E. 40th Street",
			"30301 - 166th Ave. N.E.",
			"16 Maple Lane",
			"2 impasse du Soleil",
			"9 place de la Liberté",
			"7 rue Nationale"
		};

		string[] Notes = new string[] {
			"Education includes a BA in Psychology from The Colorado State University in 1970.",
			"Andrew received his BTS commercial in 1964 and an MBA in International Marketing from the University of Dallas in 1971.",
			"Janet has a BS degree in Chemistry from The Boston College (1984). She has also completed a certification in Food Retailing Management.",
			"Margaret holds a BA in English literature from Concordia College (1958) and an MA from the American Institute of Culinary Arts (1966).",
			"Steven Buchanan graduated from St. Andrews University, Scotland, with a BSC degree in 1976.",
			"Michael is a graduate of Sussex University (MA, economics, 1983) and the University of California at Los Angeles (MBA, marketing, 1986).",
			"Robert King served in Peace Corps and traveled extensively before completing his English degree at the University of Michigan in 1992, the year he joined in the company.",
			"Laura received a BA in psychology from the University of Washington.  She has also completed a course in business French.",
			"Anne has a BA degree in English from St. Lawrence College. She is fluent in French and German languages.",
			"Albert Hellstern is a graduate of Harvard University, where he earned a Bachelor of Science degree in 1981.",
			"Caroline Patterson is a graduate from The Tahoma High School and she also has an AA degree from the Bellevue Community College in Bellevue.",
			"Xavier Martin is a graduate of the University of Chicago. Mr. Martin is completely fluent in German, French and English and understands Polish."
		};

		string[] Countries = new string[] {
			"USA",
			"UK",
			"France",
		};

		Dictionary<string, string[]> Cities = new Dictionary<string, string[]> ();

		private void setCity ()
		{
			string[] france = new string[] {
				"Haguenau",
				"Schiltigheim",
				"Strasbourg"
			};

			string[] uk = new string[] { "Colchester", "Hedge End", "London" };

			string[] usa = new string[] {
				"Seattle",
				"Tacoma",
				"Kirkland",
				"Redmond",
				"Bellevue",
				"Kent",
				"Auburn",
			};

			Cities.Add ("France", france);	
			Cities.Add ("UK", uk);
			Cities.Add ("USA", usa);
		}

		#endregion

	}
}

