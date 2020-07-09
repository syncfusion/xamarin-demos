#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ListView.XForms;
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

    #region DataTemplateSelectorBehavior

    public class DataTemplateSelectorBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        #region Fields

        private ViewModel DataTemplateSelectorViewModel;
        private Syncfusion.ListView.XForms.SfListView ListView;
        private ScrollView scrollView;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = bindable;
            base.OnAttachedTo(bindable);
            DataTemplateSelectorViewModel = (ViewModel)ListView.BindingContext;
            ListView.Loaded += ListView_Loaded;
        }

        private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            scrollView = ListView.Parent as ScrollView;
            ListView.HeightRequest = scrollView.Height;

            if (Device.RuntimePlatform == Device.macOS)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ListView.ScrollTo(2500);
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    (ListView.LayoutManager as LinearLayout).ScrollToRowIndex(DataTemplateSelectorViewModel.MessageInfo.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.Start);
                });
            }
        }

        protected override void OnDetachingFrom(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

    }

    #endregion
}
