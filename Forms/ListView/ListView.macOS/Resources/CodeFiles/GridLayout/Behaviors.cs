#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    #region GridLayoutBehavior
    public class SfListViewGridLayoutBehavior : Behavior<SampleView>
    {
        #region Fields

        private Syncfusion.ListView.XForms.GridLayout gridLayout;
        private Syncfusion.ListView.XForms.SfListView ListView;
        private ListViewGridLayoutViewModel gridLayoutViewModel;
        private Grid deleteImageParent;
        private Grid headerGrid;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(SampleView bindable)
        {
            ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            ListView.SelectionChanged += ListView_SelectionChanged;

            gridLayoutViewModel = new ListViewGridLayoutViewModel();
            ListView.BindingContext = gridLayoutViewModel;
            ListView.ItemsSource = gridLayoutViewModel.Gallerynfo;

            headerGrid = bindable.FindByName<Grid>("headerGrid");
            headerGrid.BindingContext = gridLayoutViewModel;

            deleteImageParent = bindable.FindByName<Grid>("deleteImageParent");
            var deleteImageTapped = new TapGestureRecognizer() { Command = new Command(DeleteImageTapped_tapped) };
            deleteImageParent.GestureRecognizers.Add(deleteImageTapped);

            gridLayout = new Syncfusion.ListView.XForms.GridLayout();

            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                gridLayout.SpanCount = Device.Idiom == TargetIdiom.Phone ? 2 : 4;
                ListView.ItemSize = Device.Idiom == TargetIdiom.Phone || Device.Idiom == TargetIdiom.Tablet ? 150 : 170;
            }
            else if(Device.RuntimePlatform == Device.macOS)
            {
                gridLayout.SpanCount = 4;
                ListView.ItemSize = 300;
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                gridLayout.SpanCount = Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet ? 4 : 2;
                ListView.ItemSize = Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet ? 300 : 140;
            }

            ListView.LayoutManager = gridLayout;
            ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor() { PropertyName = "CreatedDate" });

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            ListView.SelectionChanged -= ListView_SelectionChanged;
            ListView = null;
            gridLayout = null;
            deleteImageParent = null;
            headerGrid = null;
            gridLayoutViewModel = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Events
        private void DeleteImageTapped_tapped(object obj)
        {
            var galleryInfo = ListView.SelectedItems.ToList();

            foreach (ListViewGalleryInfo item in galleryInfo)
            {
                if (gridLayoutViewModel.Gallerynfo.Contains(item))
                    gridLayoutViewModel.Gallerynfo.Remove(item);
            }
            RefreshSelection();
        }

        private void ListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            for (int i = 0; i < e.AddedItems.Count; i++)
            {
                var item = e.AddedItems[i];
                (item as ListViewGalleryInfo).IsSelected = true;
            }
            for (int i = 0; i < e.RemovedItems.Count; i++)
            {
                var item = e.RemovedItems[i];
                (item as ListViewGalleryInfo).IsSelected = false;
            }
            RefreshSelection();
        }
        #endregion

        #region Methods
        private void RefreshSelection()
        {
            if (ListView.SelectedItems.Count > 0)
            {
                gridLayoutViewModel.TitleInfo = "";
                gridLayoutViewModel.HeaderInfo = ListView.SelectedItems.Count == 1 ? ListView.SelectedItems.Count + " photo selected" : ListView.SelectedItems.Count + " photos selected";
                gridLayoutViewModel.IsVisible = true;
                gridLayoutViewModel.IsSelectionEnabled = true;
            }
            else
            {
                gridLayoutViewModel.TitleInfo = "Select Photos";
                gridLayoutViewModel.HeaderInfo = "";
                gridLayoutViewModel.IsVisible = false;
                gridLayoutViewModel.IsSelectionEnabled = false;
            }
        }
        #endregion
    }
    #endregion
	
	[Preserve(AllMembers = true)]
    public class GridExt:Grid
    {
    }
}
