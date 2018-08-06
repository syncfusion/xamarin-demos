#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    class SfListViewAccordionBehavior : Behavior<SampleView>
    {
        #region Fields

        private Contact tappedItem;
        private Syncfusion.ListView.XForms.SfListView listview;
        private AccordionViewModel AccordionViewModel;

        #endregion

        #region Properties
        public SfListViewAccordionBehavior()
        {
            AccordionViewModel = new AccordionViewModel();
        }

        #endregion

        #region Override Methods

        protected override void OnAttachedTo(SampleView bindable)
        {
            listview = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            listview.ItemsSource = AccordionViewModel.ContactsInfo;
            listview.ItemTapped += ListView_ItemTapped;
        }

        #endregion

        #region Private Methods

        private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (tappedItem == null)
            {
                (e.ItemData as Contact).IsVisible = true;
                tappedItem = e.ItemData as Contact;
            }
            else
            {
                if (AccordionViewModel.ContactsInfo.Contains(tappedItem) && tappedItem.IsVisible)
                {
                    AccordionViewModel.ContactsInfo.FirstOrDefault(x => x.ContactName == tappedItem.ContactName).IsVisible = false;
                }
                if (e.ItemData as Contact != tappedItem)
                {
                    tappedItem = e.ItemData as Contact;
                    AccordionViewModel.ContactsInfo.FirstOrDefault(x => x.ContactName == tappedItem.ContactName).IsVisible = true;
                    tappedItem = e.ItemData as Contact;
                }
                else
                    tappedItem = null;
            }

            listview.ForceUpdateItemSize();
        }

        #endregion
    }
}

