#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
    public class EmployeeDetails
	{
		public EmployeeDetails ()
		{

		}

		#region private variables

		private Random random = new Random ();

		#endregion

		#region GetEmployeeDetails

		public List<EmployeeInfo> GetEmployeeDetails (int count)
		{
			List<EmployeeInfo> employeeDetails = new List<EmployeeInfo> ();

			for (int i = 1; i <= count; i++) {
				var ord = new EmployeeInfo () {
					EmployeeID = EmployeeID [random.Next (15)],
					Name = Customers [random.Next (15)],
					Age=Age[random.Next(10)],
					Company = Company [random.Next(10)],
					Title = Title [random.Next (10)],
					Salary = Salary[random.Next (13)],
					Bonus=Bonus[random.Next(7)]
				};
				employeeDetails.Add (ord);
			}
			return employeeDetails;
		}

		#endregion

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

			"CTS",
			"TCS",
			"Infosys",
			"Amazon",
			"Aspire",
			"HP",
			"HCL",
			"DELL",
			"Mphasis",
			"Accenture",
			"Syncfusion",
			"Bally",
			"Google",
			"Microsoft",
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

		int[] Bonus = new int[] {

			2,
			3,
			4,
			1,
			12,
			13,
			15,
			18,
			14,
			6,
			7


		};
	}
}

