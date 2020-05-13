#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Reflection;
namespace SampleBrowser.SfParallaxView
{
    [Preserve(AllMembers = true)]

    public class ParallaxViewViewModel : INotifyPropertyChanged
    {
        #region Properties

        internal List<ParallaxViewModel> Items { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        #region Speed


        private double speed;

        public double Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                                    new PropertyChangedEventArgs("Speed"));
                }
            }
        }

        #endregion Speed


        #endregion Properties

        #region Methods


        internal List<ParallaxViewModel> GetItemSource()
        {
            Items = new List<ParallaxViewModel>()
            {
                new ParallaxViewModel() { Name = "Thriller", Author = "Michael Jackson - 10 Tracks",Tracks="10 Tracks" },
                new ParallaxViewModel() { Name = "Like a Prayer", Author = "Madonna - 1 Tracks" ,Tracks="1 Tracks" },
                new ParallaxViewModel() { Name = "When Doves Cry", Author = "Prince - 60 Tracks",Tracks="60 Tracks" },
                new ParallaxViewModel() { Name = "I Wanna Dance", Author = "Whitney Houston - 70 Tracks",Tracks="70 Tracks" },
                new ParallaxViewModel() { Name = "It’s Gonna Be Me", Author = "N Sync - 10 Tracks",Tracks="10 Tracks" },
                new ParallaxViewModel() { Name = "Everybody", Author = "Backstreet Boys - 4 Tracks",Tracks="4 Tracks" },
                new ParallaxViewModel() { Name = "Rolling in the Deep", Author = "Adele - 25 Tracks" ,Tracks="25 Tracks" },
                new ParallaxViewModel() { Name = "Don’t Stop Believing", Author = "Journey - 10 Tracks" ,Tracks="10 Tracks" },
                new ParallaxViewModel() { Name = "Billie Jean", Author = "Michael Jackson - 5 Tracks",Tracks="5 Tracks" },
                new ParallaxViewModel() { Name = "Sorry", Author = "Justin Bieber - 1 Tracks",Tracks="1 Tracks" },
                new ParallaxViewModel() { Name = "Firework", Author = "Katy Perry - 6 Tracks",Tracks="6 Tracks" },
                new ParallaxViewModel() { Name = "The A Team", Author = "Ed Sheeran - 8 Tracks" ,Tracks="8 Tracks"},
                new ParallaxViewModel() { Name = "Thriller", Author = "Michael Jackson - 3 Tracks" ,Tracks="3 Tracks"},
                new ParallaxViewModel() { Name = "Like a Prayer", Author = "Madonna - 40 Tracks" ,Tracks="40 Tracks"},
                new ParallaxViewModel() { Name = "When Doves Cry", Author = "Prince - 10 Tracks",Tracks="10 Tracks" },
                new ParallaxViewModel() { Name = "I Wanna Dance", Author = "Whitney Houston - 2 Tracks",Tracks="2 Tracks" },
                new ParallaxViewModel() { Name = "It’s Gonna Be Me", Author = "N Sync - 11 Tracks" ,Tracks="11 Tracks"},
                new ParallaxViewModel() { Name = "Everybody", Author = "Backstreet Boys - 15 Tracks",Tracks="15 Tracks" },
                new ParallaxViewModel() { Name = "Rolling in the Deep", Author = "Adele - 18 Tracks" ,Tracks="18 Tracks"},
                new ParallaxViewModel() { Name = "Don’t Stop Believing", Author = "Journey - 35 Tracks",Tracks="35 Tracks" },
            };
            Assembly assembly = typeof(ParallaxViewViewModel).GetTypeInfo().Assembly;
            Items[0].Image = ImageSource.FromFile("Singing_round.png");
            Items[1].Image = ImageSource.FromFile("Dancing_round.png");
            Items[2].Image = ImageSource.FromFile("Drum_round.png");
            Items[3].Image = ImageSource.FromFile("Microphone_round.png");
            Items[4].Image = ImageSource.FromFile("CassetteTape_round.png");
            Items[5].Image = ImageSource.FromFile("ElectronicDrum_round.png");
            Items[6].Image = ImageSource.FromFile("PlayingViolin_round.png");
            Items[7].Image = ImageSource.FromFile("MusicSheet_round.png");
            Items[8].Image = ImageSource.FromFile("Radio_round.png");
            Items[9].Image = ImageSource.FromFile("Headset_round.png");
            Items[10].Image = ImageSource.FromFile("Listeningmusic_round.png");
            Items[11].Image = ImageSource.FromFile("Mic_round.png");
            Items[12].Image = ImageSource.FromFile("Singing_round.png");
            Items[13].Image = ImageSource.FromFile("Dancing_round.png");
            Items[14].Image = ImageSource.FromFile("Drum_round.png");
            Items[15].Image = ImageSource.FromFile("Microphone_round.png");
            Items[16].Image = ImageSource.FromFile("CassetteTape_round.png");
            Items[17].Image = ImageSource.FromFile("ElectronicDrum_round.png");
            Items[18].Image = ImageSource.FromFile("PlayingViolin_round.png");
            Items[19].Image = ImageSource.FromFile("MusicSheet_round.png");
            return Items;
        }

        #endregion Methods

    }
}
