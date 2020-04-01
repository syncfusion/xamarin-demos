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
using SelectionMode = Syncfusion.ListView.XForms.SelectionMode;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    #region SelectionBehavior

    public class SfListViewSelectionBehavior : Behavior<SampleView>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView ListView;
        private Grid selectionCancelImageParent;
        private Grid selectionEditImageParent;
        private ListViewSelectionViewModel SelectionViewModel;
        private Grid headerGrid;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(SampleView bindable)
        {
            ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            ListView.ItemHolding += ListView_ItemHolding;
            ListView.SelectionChanged += ListView_SelectionChanged;

            if (Device.RuntimePlatform == Device.UWP)
                ListView.FocusBorderThickness = new Thickness(1, 1, 1, 2);

            SelectionViewModel = new ListViewSelectionViewModel();
            ListView.BindingContext = SelectionViewModel;
            ListView.ItemsSource = SelectionViewModel.MusicInfo;

            headerGrid = bindable.FindByName<Grid>("headerGrid");
            headerGrid.BindingContext = SelectionViewModel;

            selectionCancelImageParent = bindable.FindByName<Grid>("cancelImageParent");
            var selectionCancelImageTapped = new TapGestureRecognizer() { Command=new Command(selectionCancelImageTapped_Tapped) } ;
            selectionCancelImageParent.GestureRecognizers.Add(selectionCancelImageTapped);

            selectionEditImageParent = bindable.FindByName<Grid>("editImageParent");
            var selectionEditImageTapped = new TapGestureRecognizer() { Command = new Command(SelectionEditImageTapped_Tapped) };
            selectionEditImageParent.GestureRecognizers.Add(selectionEditImageTapped);
            base.OnAttachedTo(bindable);

        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            ListView.ItemHolding -= ListView_ItemHolding;
            ListView.SelectionChanged -= ListView_SelectionChanged;
            ListView = null;
            selectionCancelImageParent = null;
            selectionEditImageParent = null;
            SelectionViewModel = null;
            headerGrid = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Events
        private void ListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (ListView.SelectionMode == SelectionMode.Multiple)
            {
                SelectionViewModel.HeaderInfo = ListView.SelectedItems.Count + " selected";
                for (int i = 0; i < e.AddedItems.Count; i++)
                {
                    var item = e.AddedItems[i];
                    (item as Musiqnfo).IsSelected = true;
                }
                for (int i = 0; i < e.RemovedItems.Count; i++)
                {
                    var item = e.RemovedItems[i];
                    (item as Musiqnfo).IsSelected = false;
                }
            }
        }

        private void SelectionEditImageTapped_Tapped()
        {
            UpdateSelectionTempate();
        }

        private void selectionCancelImageTapped_Tapped()
        {
            for (int i = 0; i < ListView.SelectedItems.Count; i++)
            {
                var item = ListView.SelectedItems[i] as Musiqnfo;
                item.IsSelected = false;
            }
            this.ListView.SelectedItems.Clear();
            UpdateSelectionTempate();
        }

        private void ListView_ItemHolding(object sender, ItemHoldingEventArgs e)
        {
            if (ListView.SelectionMode != SelectionMode.Multiple)
                UpdateSelectionTempate();
        }

        #endregion

        #region Methods
        public void UpdateSelectionTempate()
        {
            if (ListView.SelectedItems.Count > 0 || selectionEditImageParent.IsVisible)
            {
                ListView.SelectionMode = SelectionMode.Multiple;
                ListView.SelectionBackgroundColor = Color.Transparent;
                ListView.SelectedItems.Clear();
                SelectionViewModel.HeaderInfo = ListView.SelectedItems.Count + " selected";
                SelectionViewModel.TitleInfo = "";
                SelectionViewModel.IsVisible = true;
                selectionEditImageParent.IsVisible = false;
            }
            else
            {
                ListView.SelectionMode = SelectionMode.Single;
                ListView.SelectionBackgroundColor = Color.FromRgb(228, 228, 228);
                SelectionViewModel.HeaderInfo = "";
                SelectionViewModel.TitleInfo = "Music Library";
                SelectionViewModel.IsVisible = false;
                selectionEditImageParent.IsVisible = true;
            }
        }

        #endregion

    }
    #endregion
}
