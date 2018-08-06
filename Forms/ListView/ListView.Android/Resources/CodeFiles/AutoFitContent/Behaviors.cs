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
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    #region AutoFitContentBehavior

    public class SfListViewAutoFitContentBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        #region Fields

        private ListViewAutoFitContentViewModel autofitViewModel;
        private Syncfusion.ListView.XForms.SfListView ListView;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = bindable;
            autofitViewModel = new ListViewAutoFitContentViewModel();
            ListView.BindingContext = autofitViewModel;
            ListView.ItemsSource = autofitViewModel.BookInfo;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Syncfusion.ListView.XForms.SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        #endregion

    }

    #endregion
}
