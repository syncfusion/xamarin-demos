#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfRadialMenu
{
    public class Rotator_Model : INotifyPropertyChanged
    {
        public Rotator_Model(string teamName, Color teamNameColor, string fifaCurrent, string fifaHighest, string fifaLowest, string eloCurrent, string eloHighest, string eloLowest)
        {
            TeamName = teamName;
            TeamColor = teamNameColor;
            FIFACurrent = fifaCurrent;
            FIFAHightest = fifaHighest;
            FIFALowest = fifaLowest;
            EloCurrent = eloCurrent;
            EloHightest = eloHighest;
            EloLowest = eloLowest;

        }
        private String teamName;
        public String TeamName
        {
            get { return teamName; }
            set
            {
                teamName = value;
            }
        }

        private Color color;
        public Color TeamColor
        {
            get { return color; }
            set
            {
                color = value;
                RaisepropertyChanged("TeamColor");
            }
        }

        private String fifaCurrent;
        public String FIFACurrent
        {
            get { return fifaCurrent; }
            set { fifaCurrent = value; }
        }

        private String fifaHightest;
        public String FIFAHightest
        {
            get { return fifaHightest; }
            set { fifaHightest = value; }
        }

        private String fifaLowest;
        public String FIFALowest
        {
            get { return fifaLowest; }
            set { fifaLowest = value; }
        }

        private String eloCurrent;
        public String EloCurrent
        {
            get { return eloCurrent; }
            set { eloCurrent = value; }
        }

        private String eloHightest;
        public String EloHightest
        {
            get { return eloHightest; }
            set { eloHightest = value; }
        }

        private String eloLowest;
        public String EloLowest
        {
            get { return eloLowest; }
            set { eloLowest = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

