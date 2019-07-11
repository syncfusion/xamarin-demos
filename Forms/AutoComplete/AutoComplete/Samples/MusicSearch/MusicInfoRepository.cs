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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfAutoComplete
{
	[Preserve(AllMembers = true)]
	public class MusicInfoRepository
	{
		#region Constructor
		List<Color> Colors = new List<Color>();
		public MusicInfoRepository()
		{
			Colors.Add(Color.LightGray);
			Colors.Add(Color.SkyBlue);
			Colors.Add(Color.Green);
			Colors.Add(Color.RosyBrown);
			Colors.Add(Color.Lime);
			Colors.Add(Color.Pink);
			Colors.Add(Color.Gold);
			Colors.Add(Color.BlueViolet);
			Colors.Add(Color.LawnGreen);
			Colors.Add(Color.Violet);
			Colors.Add(Color.Tomato);
			Colors.Add(Color.Orange);
			Colors.Add(Color.MediumVioletRed);
			Colors.Add(Color.Plum);
			Colors.Add(Color.Purple);
			Colors.Add(Color.CornflowerBlue);
			Colors.Add(Color.RosyBrown);
			Colors.Add(Color.RoyalBlue);
			Colors.Add(Color.OrangeRed);
			Colors.Add(Color.Orchid);
			Colors.Add(Color.ForestGreen);
			Colors.Add(Color.Gray);
			Colors.Add(Color.Red);
			Colors.Add(Color.Brown);
			Colors.Add(Color.Purple);
			Colors.Add(Color.CornflowerBlue);
			Colors.Add(Color.GreenYellow);
			Colors.Add(Color.RoyalBlue);
			Colors.Add(Color.OrangeRed);
			Colors.Add(Color.Orchid);
			Colors.Add(Color.ForestGreen);
			Colors.Add(Color.Gray);
			Colors.Add(Color.DeepPink);
			Colors.Add(Color.Brown);

		}

		#endregion

		#region Properties

		internal ObservableCollection<MusicInfo> GetMusicInfo()
		{
			var random = new Random();
			var musiqInfo = new ObservableCollection<MusicInfo>();

			for (int i = 0; i < SongsNames.Count(); i++)
			{
				var info = new MusicInfo()
				{
					SongTitle = SongsNames[i],
					SongAuther = SongAuthers[i],
					SongSize = random.Next(50, 600).ToString() + "." + random.Next(1, 10) / 2 + "KB",
					SongLength = "5.55",
					SongTheme = Colors[i],
					SongThumbnail = (i % 2 == 0) ? "I" : "T",
				};
				musiqInfo.Add(info);
			}
			return musiqInfo;
		}

		#endregion

		#region SongInfo

		string[] SongsNames = new string[]
		{
"Whât is thé wéâthér tódây?",
"Hów tó bóók my flight?",
"Whéré is my lócâtión?",
"Is bânk ópén tódây?",
"Why sky is blué?",
"Gét mé sóméthing",
"List óf hólidâys",
"Diréct mé tó hómé",
"Hów tó gâin wéight?",
"Hów tó drâw ân éléphânt?",
"Whéré cân I buy â câmérâ?",
"Guidé mé âll thé wây",
"Hów tó mâké â câké?",
"Sây, Hélló Wórld!",
"Hów tó mâké â róbót?",
"Cónnéct Móbilé tó TV?",
"Whât timé nów in Indiâ?",
"Whó is whó in thé wórld?",
"Hów tó drâw â rósé?",
"Hów cân I léârn Tâmil?",
"Hów cân I léârn Jâpânésé?",
"Hów tó réâch néârést âirpórt?",

		};

		string[] SongAuthers = new string[]
		{
			"Coldplay",
			"Bill Monroe",
			"Hank Williams & George Jones",
			"Barry White",
			"F. R. David",
			"Baz Luhrmann",
			"Freddy Fender",
			"Righteous Brothers",
			"Shakira",
			"Andy Williams",
			"James Newton Howard ft. Jennifer Lawrence",
			"I. Kamakawiwo'ole",
			"Enigma",
			"Dionne Warwick",
			"R. Kelly",
			"David Zowie",
			"Michael Jackson",
			"Tom Jones",
			"The Beach Boys",
			"The Brothers Four",
			"Michael Jackson",
			"Alison Krauss",
			"Norah Jones",
			"Green Day",
			"Beck",
			"Hank Williams",
		};

		#endregion
	}
}

