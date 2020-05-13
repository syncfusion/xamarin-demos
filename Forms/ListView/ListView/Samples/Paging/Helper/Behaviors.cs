#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms.DataPager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class SfListViewPagingBehavior : Behavior<SampleView>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView listView;
        private PagingViewModel PagingViewModel;
        private SfDataPager dataPager;

        #endregion

        #region Methods
        protected override void OnAttachedTo(SampleView bindable)
        {
            listView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            dataPager = bindable.FindByName<SfDataPager>("dataPager");
            PagingViewModel = new PagingViewModel();
            listView.BindingContext = PagingViewModel;
            dataPager.Source = PagingViewModel.pagingProducts;
            dataPager.OnDemandLoading += DataPager_OnDemandLoading;
            base.OnAttachedTo(bindable);
        }

        private void DataPager_OnDemandLoading(object sender, OnDemandLoadingEventArgs e)
        {
            var source = PagingViewModel.pagingProducts.Skip(e.StartIndex).Take(e.PageSize);
            listView.ItemsSource = source.ToList<PagingProduct>().ToList();
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            listView = null;
            PagingViewModel = null;
            dataPager = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion
    }
}
