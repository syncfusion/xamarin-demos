#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    #region SwipingBehavior
    public class SfListViewSwipingBehavior:Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        #region Fields

        private ListViewSwipingViewModel SwipingViewModel;
        private Syncfusion.ListView.XForms.SfListView ListView;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = bindable;
            ListView.SwipeStarted += ListView_SwipeStarted;
            ListView.SwipeEnded += ListView_SwipeEnded;

            SwipingViewModel = new ListViewSwipingViewModel();
            SwipingViewModel.sfListView = ListView;
            bindable.BindingContext = SwipingViewModel;
            ListView.ItemsSource = SwipingViewModel.InboxInfo;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView.SwipeStarted -= ListView_SwipeStarted;
            ListView.SwipeEnded -= ListView_SwipeEnded;
            ListView = null;
            SwipingViewModel = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Events
        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            SwipingViewModel.ItemIndex = e.ItemIndex;
        }
        
        private void ListView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            SwipingViewModel.ItemIndex = -1;
        }
        #endregion
    }
    #endregion
}
