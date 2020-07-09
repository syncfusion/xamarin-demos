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
    public class ListViewGettingStartedViewModel
    {
        #region Fields

        private ObservableCollection<ListViewShoppingCategoryInfo> categoryInfo;

        #endregion

        #region Constructor

        public ListViewGettingStartedViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewShoppingCategoryInfo> CategoryInfo
        {
            get { return categoryInfo; }
            set { this.categoryInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ShoppingCategoryInfoRepository categoryinfo = new ShoppingCategoryInfoRepository();
            categoryInfo = categoryinfo.GetCategoryInfo();
        }

        #endregion
    }
}
