#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class MusiqInfoRepository
    {
        #region Constructor

        public MusiqInfoRepository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<Musiqnfo> GetMusiqInfo()
        {
            var random = new Random();
            var musiqInfo = new ObservableCollection<Musiqnfo>();
            for (int i = 0; i < SongsNames.Count(); i++)
            {
                var info = new Musiqnfo()
                {
                    SongTitle = SongsNames[i],
                    SongAuther = SongAuthers[i],
                    SongSize = random.Next(50, 600).ToString() + "." + random.Next(1, 10) / 2 + "KB",
                };
                musiqInfo.Add(info);
            }
            return musiqInfo;
        }

        #endregion

        #region SongInfo

        string[] SongsNames = new string[]
        {
            "Adventure of a lifetime",
            "Blue moon of Kentucky",
            "I don't care if tomorrow never comes",
            "You are the first, my last, my everything",
            "Words don't come easy to me",
            "Everybody's free to wear sunscreen",
            "Before the next teardrop falls",
            "You've lost that lovin' feeling",
            "Underneath your clothes",
            "Try to remember",
            "The hanging tree",
            "Somewhere over the rainbow",
            "Return to innocence",
            "I say a little prayer for you",
            "I believe I can fly",
            "House every weekend",
            "Heal the world",
            "Green green grass of home",
            "God only knows",
            "Five hundred miles",
            "Earth song",
            "Down to the river to pray",
            "Come away with me",
            "Boulevard of broken dreams",
            "Heart is a drum",
            "I'm so lonesome I could cry",
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
