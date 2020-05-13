#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser.Core;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    #region SortingFilteringBehavior

    public class SfListViewSortingFilteringBehavior:Behavior<SampleView>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView ListView;
        private SortingFilteringViewModel sortingFilteringViewModel;
        private Grid sortImageParent;
        private SearchBar searchBar = null;
        private Grid headerGrid;
        private Grid seachbar_Grid;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(SampleView bindable)
        {
            ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            sortingFilteringViewModel = new SortingFilteringViewModel();
            ListView.BindingContext = sortingFilteringViewModel;
            ListView.ItemsSource = sortingFilteringViewModel.Items;

            headerGrid = bindable.FindByName<Grid>("headerGrid");
            headerGrid.BindingContext = sortingFilteringViewModel;

            seachbar_Grid = bindable.FindByName<Grid>("seachbar_Grid");
            if (Device.RuntimePlatform == Device.UWP)
                seachbar_Grid.Padding = new Thickness(5, 5, 0, 5);

            sortImageParent = bindable.FindByName<Grid>("sortImageParent");
            var SortImageTapped = new TapGestureRecognizer() { Command = new Command(SortImageTapped_Tapped) };
            sortImageParent.GestureRecognizers.Add(SortImageTapped);

            if (Device.RuntimePlatform == Device.iOS)
                sortImageParent.BackgroundColor = Color.FromHex("#C9C8CE");
            else if(Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.UWP)
                sortImageParent.BackgroundColor = Color.FromHex("#E4E4E4");

            searchBar = bindable.FindByName<SearchBar>("filterText");
            if (Device.RuntimePlatform == Device.macOS)
                searchBar.PlaceholderColor = Color.Transparent;

            searchBar.WidthRequest = Core.SampleBrowser.ScreenWidth - sortImageParent.Width;
            searchBar.TextChanged += SearchBar_TextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            ListView = null;
            sortImageParent = null;
            searchBar = null;
            searchBar.TextChanged -= SearchBar_TextChanged;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Events
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (ListView.DataSource != null)
            {
                ListView.DataSource.Filter = FilterContacts;
                ListView.DataSource.RefreshFilter();
            }
            ListView.RefreshView();
        }

        private void SortImageTapped_Tapped()
        {
            if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Descending)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.None;
            else if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.None)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Ascending;
            else if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Ascending)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Descending;

            ListView.DataSource.SortDescriptors.Clear();
            if (sortingFilteringViewModel.SortingOptions != ListViewSortOptions.None)
            {
                ListView.DataSource.SortDescriptors.Add(new SortDescriptor()
                {
                    PropertyName = "Title",
                    Direction = sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending
                });
            }
            ListView.RefreshView();
        }

        #endregion

        #region Methods
        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var taskInfo = obj as TaskInfo;
            return (taskInfo.Title.ToLower().Contains(searchBar.Text.ToLower())
                || taskInfo.Description.ToLower().Contains(searchBar.Text.ToLower()));
        }

        #endregion
    }

    #endregion
}
