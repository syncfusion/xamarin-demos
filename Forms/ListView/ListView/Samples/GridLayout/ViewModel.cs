#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

        private ObservableCollection<object> _selectedItems = new ObservableCollection<object>();
        private Assembly assembly;

        #endregion

        #region Constructor

        public ListViewGridLayoutViewModel()
        {
            assembly = typeof(GridLayout).GetTypeInfo().Assembly;
#if COMMONSB
            delete = ImageSource.FromResource("SampleBrowser.Icons.GridLayout.Delete1.png", assembly);
#else
            delete = ImageSource.FromResource("SampleBrowser.SfListView.Icons.GridLayout.Delete1.png", assembly);
#endif

            FavoriteImageCommand = new Command(SetFavorite);
            GridImageCommand = new Command(ItemSelection);
            DeleteImageCommand = new Command(DeleteImageTapped_tapped);
            GenerateSource();
            UpdateHeaderStatus();
        }

        private void ItemSelection(object obj)
        {
            var item = obj as ListViewGalleryInfo;
            if (item.IsSelected)
            {
                item.IsSelected = false;
                this.SelectedItems.Remove(item);
            }
            else
            {
                item.IsSelected = true;
                this.SelectedItems.Add(item);
            }
            UpdateHeaderStatus();
        }

        #endregion

        #region Properties
        public ObservableCollection<object> SelectedItems
        {
            get { return _selectedItems; }
            set { _selectedItems = value; }
        }

        public Command FavoriteImageCommand
        {
            get;
        }

        public Command GridImageCommand
        {
            get;
        }

        public Command DeleteImageCommand
        {
            get;
        }


        public ObservableCollection<ListViewGalleryInfo> Gallerynfo
        {
            get { return galleryinfo; }
            set { this.galleryinfo = value; }
        }

        public ImageSource DeleteImage
        {
            get
            {
                return delete;
            }
        }

        public string HeaderStatus
        {
            get { return headerInfo; }
            set
            {
                if (headerInfo != value)
                {
                    headerInfo = value;
                    OnPropertyChanged("HeaderStatus");
                }
            }
        }

        #endregion

        public void GenerateSource()
        {
            ListViewGalleryInfoRepository bookRepository = new ListViewGalleryInfoRepository();
            galleryinfo = bookRepository.GetGalleryInfo();
        }

        private void UpdateHeaderStatus()
        {
            if (SelectedItems.Count > 0)
            {
                this.HeaderStatus = this.SelectedItems.Count == 1 ? this.SelectedItems.Count + " photo selected" : this.SelectedItems.Count + " photos selected";
            }
            else
            {
                this.HeaderStatus = "Select Photos";
            }
        }
        private void DeleteImageTapped_tapped(object obj)
        {
            var galleryInfo = SelectedItems.ToList();

            foreach (ListViewGalleryInfo item in galleryInfo)
            {
                if (this.Gallerynfo.Contains(item))
                    this.Gallerynfo.Remove(item);
            }
            UpdateHeaderStatus();
        }

        private void SetFavorite(object obj)
        {
            var item = obj as ListViewGalleryInfo;
            item.IsFavorite = !item.IsFavorite;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
