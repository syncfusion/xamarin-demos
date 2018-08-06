#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    public class ListViewGridLayoutViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ListViewGalleryInfo> galleryinfo;
        private ImageSource delete;
        private string headerInfo;
        private string titleInfo;
        private bool isVisible;
        private bool isSelectionEnabled;
        private Command favoriteImageCommand;
        private Assembly assembly;

        #endregion

        #region Constructor

        public ListViewGridLayoutViewModel()
        {
            assembly = typeof(AutoFitContent).GetTypeInfo().Assembly;
#if COMMONSB
            delete = ImageSource.FromResource("SampleBrowser.Icons.Delete1.png", assembly);
#else
            delete = ImageSource.FromResource("SampleBrowser.SfListView.Icons.Delete1.png", assembly);
#endif
            titleInfo = "Select Photos";
            headerInfo = "";
            FavoriteImageCommand = new Command(SetFavorite);
            GenerateSource();
        }

        #endregion

        #region Properties

        public Command FavoriteImageCommand
        {
            get { return favoriteImageCommand; }
            protected set { favoriteImageCommand = value; }
        }

        public ObservableCollection<ListViewGalleryInfo> Gallerynfo
        {
            get { return galleryinfo; }
            set { this.galleryinfo = value; }
        }

        public ImageSource Delete
        {
            get
            {
                return delete;
            }
            set
            {
                if (delete != value)
                {
                    delete = value;
                    OnPropertyChanged("Delete");
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

        public bool IsSelectionEnabled
        {
            get { return isSelectionEnabled; }
            set
            {
                if (isSelectionEnabled != value)
                {
                    isSelectionEnabled = value;
                    OnPropertyChanged("IsSelectionEnabled");
                }
            }
        }

        #endregion

        #region ItemSource

        public void GenerateSource()
        {
            ListViewGalleryInfoRepository bookRepository = new ListViewGalleryInfoRepository();
            galleryinfo = bookRepository.GetGalleryInfo();
        }

        #endregion

        private void SetFavorite(object obj)
        {
            var item = obj as ListViewGalleryInfo;
#if COMMONSB
            if (item.IsFavoriteSelected)
                item.FavoritesImage = ImageSource.FromResource("SampleBrowser.Icons.GridLayout.Favorite2.png", assembly);
            else
                item.FavoritesImage = ImageSource.FromResource("SampleBrowser.Icons.GridLayout.Favorite1.png", assembly);
#else
            if (item.IsFavoriteSelected)
                item.FavoritesImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.GridLayout.Favorite2.png", assembly);
            else
                item.FavoritesImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.GridLayout.Favorite1.png", assembly);
#endif
            item.IsFavoriteSelected = !item.IsFavoriteSelected;
        }

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
