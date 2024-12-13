#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class EmployeeDetails
	{
		public EmployeeDetails ()
		{

		}

		#region private variables

		private List<string> EmployeeDates;
		private Random random = new Random ();

		#endregion

		#region GetEmployeeDetails

		public List<EmployeeInfo> GetEmployeeDetails (int count)
		{
			this.EmployeeDates = GetDateBetween (2000, 2014, count);
			List<EmployeeInfo> employeeDetails = new List<EmployeeInfo> ();

			for (int i = 1; i <= count; i++) {
				var ord = new EmployeeInfo () {
					EmployeeID = EmployeeID [random.Next (15)],
					Name = Customers [random.Next (15)],
					Age = Age [random.Next (10)],
					Company = Company [random.Next (10)],
					Title = Title [random.Next (10)],
					Salary = Salary [random.Next (13)],
					Bonus = Bonus [random.Next (7)],
					IsAvailable = ((i % random.Next (1, 10) > 5) ? true : false),
					DOJ = this.EmployeeDates [i - 1],
					ImageName = getImageName (random.Next (0, 2)),
				};
				employeeDetails.Add (ord);
			}
			return employeeDetails;
		}

		#endregion

		private string getImageName (int index)
		{
			if (index == 0)
				return ("GIRL" + random.Next (1, 24) + ".png");
			else
				return ("GUY" + random.Next (1, 24) + ".png");
		}

		private List<string> GetDateBetween (int startYear, int endYear, int count)
		{
			List<string> date = new List<string> ();
			Random d = new Random (1);
			Random m = new Random (2);
			Random y = new Random (startYear);
			for (int i = 0; i < count; i++) {
				int year = y.Next (startYear, endYear);
				int month = m.Next (3, 13);
				int day = d.Next (1, 31);

				date.Add ((new DateTime (year, month, day)).ToString ());
			}
			return date;
		}

		int[] EmployeeID = new int[] {
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

		int[] Salary = new int[] {
			256787,
			34455,
			445545,
			234567,
			78434555,
			93455,
			3456674,
			34567457,
			23424,
			655676,
			2252459,
			34368,
			125436,
			90558,
			648489,
			5537383

		};

		string[] Company = new string[] {

			"ABC",
			"XYZ",
			"XXX",
			"YYY",
			"ZZZ",
			"ZXY",
			"KKK",
			"BCD",
			"XZY",
			"FDG",
			"BCA",
			"UTS",
			"KFI",
			"XXX",
		};

		string[] Title = new string[] {
			"Manager ",
			"Recruiter",
			"Security",
			"Supervisor",
			"Admin",
			"Admin",
			"Assistant",
			"President",
			"Designer",
			"Manager",
			"Marketing",
			"Stocker",
			"Clerk"
		};

		string[] Customers = new string[] {
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

		int[] Age = new int[] {

			21,
			34,
			45,
			21,
			23,
			25,
			43,
			32,
			22,
			44,
			25,
			47,
			35,
			37,
			41
		};

		double[] Bonus = new double[] {

			0.2,
			0.3,
			0.4,
			0.1,
			0.12,
			0.13,
			0.15,
			0.18,
			0.14,
			0.6,
			0.7
		};
	}
}

