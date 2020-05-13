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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using System.Reflection;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewSelectionViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Musiqnfo> musicInfo;
        private string headerInfo;
        private string titleInfo;
        private bool isVisible;

        #endregion

        #region Constructor

        public ListViewSelectionViewModel()
        {
            GenerateSource();
            titleInfo = "Music Library";
            headerInfo = "";
        }

        #endregion

        #region Properties

        public ObservableCollection<Musiqnfo> MusicInfo
        {
            get { return musicInfo; }
            set { this.musicInfo = value; }
        }

        public string TitleInfo
        {
            get { return titleInfo; }
            set
            {
                if (titleInfo != value)
                {
                    titleInfo = value;
                    OnPropertyChanged("TitleInfo");
                }
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
        }

        public string HeaderInfo
        {
            get { return headerInfo; }
            set
            {
                if (headerInfo != value)
                {
                    headerInfo = value;
                    OnPropertyChanged("HeaderInfo");
                }
            }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            MusiqInfoRepository musiqinfo = new MusiqInfoRepository();
            musicInfo = musiqinfo.GetMusiqInfo();
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
