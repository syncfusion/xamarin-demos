#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfListView
{
   public class ListViewSwipingBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        Syncfusion.ListView.XForms.SfListView ListView;
        ListViewSwipingViewModel viewModel;
        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = bindable;
            viewModel = new ListViewSwipingViewModel();
            ListView.BindingContext = viewModel;
            (ListView.BindingContext as ListViewSwipingViewModel).ResetSwipeView += Behavior_ResetSwipeView;
            base.OnAttachedTo(bindable);
        }

        private void Behavior_ResetSwipeView(object sender, ResetEventArgs e)
        {
            ListView.ResetSwipe();
        }
    }
}
