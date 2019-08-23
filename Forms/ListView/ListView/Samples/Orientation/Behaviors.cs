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
using SampleBrowser.Core;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    #region OrientationBehavior

    public class SfListViewOrientationBehavior : Behavior<SampleView>
    {
        #region Fields

        private ListViewOrientationViewModel listViewOrientationViewModel;
        private Syncfusion.ListView.XForms.SfListView ListView1;
        private Syncfusion.ListView.XForms.SfListView ListView2;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(SampleView bindable)
        {
            ListView1 = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            ListView2 = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView1");
            listViewOrientationViewModel = new ListViewOrientationViewModel();
            ListView1.ItemsSource = listViewOrientationViewModel.PizzaInfo;
            ListView2.ItemsSource = listViewOrientationViewModel.PizzaInfo1;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            ListView1 = null;
            ListView2 = null;
            listViewOrientationViewModel = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion
    }

    #endregion
}
