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

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewAutoFitContentViewModel
    {
        #region Fields

        private ObservableCollection<ListViewBookInfo> bookInfo;

        #endregion

        #region Constructor

        public ListViewAutoFitContentViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewBookInfo> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ListViewBookInfoRepository bookInfoRepository = new ListViewBookInfoRepository();
            bookInfo = bookInfoRepository.GetBookInfo();
        }

        #endregion
    }
}
