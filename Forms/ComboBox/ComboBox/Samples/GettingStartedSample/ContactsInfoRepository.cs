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

namespace SampleBrowser.SfComboBox
{
	[Preserve(AllMembers = true)]
	public class ContactsInfoRepository
	{
		#region Constructor

		public ContactsInfoRepository()
		{

		}

		#endregion

		#region Get Size Details

		public ObservableCollection<string> GetSizeDetails()
		{
			ObservableCollection<string> SizeDetails = new ObservableCollection<string>();

			for (int i = 0; i < Size.Count(); i++)
			{

				SizeDetails.Add(Size[i]);

			}
			return SizeDetails;
		}

		#endregion

		#region Get Resolution Details

		public ObservableCollection<string> GetResolutionDetails()
		{
			ObservableCollection<string> ResolutionDetails = new ObservableCollection<string>();

			for (int i = 0; i < Resolution.Count(); i++)
			{
				ResolutionDetails.Add(Resolution[i] );

			}
			return ResolutionDetails;
		}

		#endregion

		#region Get Orientation Details

		public ObservableCollection<string> GetOrientationDetails()
		{
			ObservableCollection<string> OrinetationDetails = new ObservableCollection<string>();

			for (int i = 0; i < Orientation.Count(); i++)
			{

				OrinetationDetails.Add(Orientation[i]);

			}
			return OrinetationDetails;
		}

		#endregion


		#region Contacts Information

		string[] Size = new string[]
		{
			"100%",
			"125%",
			"150% (Recommended)",
			"175%",
		};

		string[] Resolution = new string[]
		{
			"1920 x 1080 (Recommended)",
			"1680 x 1050",
			"1600 x 900",
		    "1440 x 900",
			"1400 x 1050",
			"1366 x 768",
			"1360 x 768",
		    "1280 x 1024",
			"1280 x 960",
            "1280 x 720",
            "854 x 480",
            "800 x 480",
            "480 X 640",
            "480 x 320",
            "432 x 240",
            "360 X 640",
            "320 x 240",
		};

		string[] Orientation = new string[]
		{
			"Landscape",
			"Portrait",
			"Landscape (flipped)",
			"Portrait (flipped)",
		};

		#endregion
	}
}
