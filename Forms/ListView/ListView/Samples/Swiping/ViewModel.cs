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

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewSwipingViewModel
    {
        #region Fields

        private ObservableCollection<ListViewInboxInfo> inboxInfo;
        private Command favoritesImageCommand;
        private Command deleteImageCommand;
        internal Syncfusion.ListView.XForms.SfListView sfListView;

        #endregion

        #region Constructor

        public ListViewSwipingViewModel()
        {
            GenerateSource();

        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewInboxInfo> InboxInfo
        {
            get { return inboxInfo; }
            set { this.inboxInfo = value; }
        }

        internal int ItemIndex
        {
            get;
            set;
        }

        public Command FavoritesImageCommand
        {
            get { return favoritesImageCommand; }
            protected set { favoritesImageCommand = value; }
        }

        public Command DeleteImageCommand
        {
            get { return deleteImageCommand; }
            protected set { deleteImageCommand = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ListViewInboxInfoRepository inboxinfo = new ListViewInboxInfoRepository();
            inboxInfo = inboxinfo.GetInboxInfo();
            deleteImageCommand = new Command(Delete);
            favoritesImageCommand = new Command(SetFavorites);
        }

        private void Delete()
        {
            Application.Current.MainPage.DisplayAlert("Deleted!", "Item successfully deleted", "OK");
            if (ItemIndex >= 0)
                InboxInfo.RemoveAt(ItemIndex);
            sfListView.ResetSwipe();
        }

        private void SetFavorites()
        {
            if (ItemIndex >= 0)
            {
                var item = InboxInfo[ItemIndex];
                item.IsFavorite = !item.IsFavorite;
            }
            sfListView.ResetSwipe();
        }

        #endregion
    }
}
