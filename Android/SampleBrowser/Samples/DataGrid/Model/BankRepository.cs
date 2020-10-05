#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfDataGrid;
using System.IO;
using System.Reflection;

namespace SampleBrowser
{
	public class BankRepository
	{
		public BankRepository ()
		{
		}

		#region private variables

		private Random random = new Random ();

		#endregion

		#region GetBankDetails

		public List<BankInfo> GetBankDetails (int count)
		{
			List<BankInfo> bankDetails = new List<BankInfo> ();

			for (int i = 1; i <= count; i++) {
				var ord = new BankInfo () {
					CustomerID = i,
					BranchNo = BranchNo [random.Next (15)],
					Current = CurrentBalance [random.Next (15)],
					Savings = Savings [random.Next (15)],
					CustomerName = Customers [random.Next (15)],
					BalanceScale = random.Next (1, 100),
					IsOpen = ((i % random.Next (1, 10) > 2) ? true : false),
					CustomerImage = ImageHelper.ToUIImage (new ImageMapStream (LoadResource ("Image" + (i % 29) + ".png").ToArray ())),
				};
				bankDetails.Add (ord);
			}
			return bankDetails;
		}

		#endregion

		public MemoryStream LoadResource (String name)
		{
			MemoryStream aMem = new MemoryStream ();

			var assm = Assembly.GetExecutingAssembly ();

			var path = String.Format ("SampleBrowser.Resources.drawable.{0}", name);

			var aStream = assm.GetManifestResourceStream (path);

			 aStream.CopyTo (aMem);

			return aMem;
		}

		int[] BranchNo = new int[] {
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

		int[] CurrentBalance = new int[] {
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

		int[] Savings = new int[] {
			466787,
			34455,
			5545,
			6734567,
			28348755,
			73455,
			34574,
			367457,
			23424,
			551676,
			2252459,
			34368,
			156436,
			256558,
			6878489,
			986383,

		};

		string[] Customers = new string[] {
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
	}

}

