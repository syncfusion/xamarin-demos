#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace SampleBrowser.SfDataForm
{ 
    public class ListViewBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        private Syncfusion.ListView.XForms.SfListView listView;

        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            listView = bindable;
            listView.ItemTapped += OnItemTapped;
            base.OnAttachedTo(bindable);
        }

        private void OnItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            (listView.BindingContext as ListViewGroupingViewModel).SelectedItem = e.ItemData as ContactInfo;
            listView.Navigation.PushAsync(new DataFormPage() { BindingContext = listView.BindingContext , Title = "Contact Form" });
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            listView.ItemTapped -= OnItemTapped;
            base.OnDetachingFrom(bindable);
        }
    }
}
