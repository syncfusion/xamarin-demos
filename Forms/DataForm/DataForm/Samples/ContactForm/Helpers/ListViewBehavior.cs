#region Copyright
// <copyright file="ListViewBehavior.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.ListView.XForms;
    using Xamarin.Forms;

    /// <summary>
    /// User defined behaviour to respond arbitrary conditions and events of ListView.
    /// </summary>
    public class ListViewBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        /// <summary>
        /// A layout which represents the list view of the contact form.
        /// </summary>
        private Syncfusion.ListView.XForms.SfListView listView;

        /// <summary>
        /// Attaches to the superclass and then calls the OnAttachedTo method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            this.listView = bindable;
            this.listView.ItemTapped += this.OnItemTapped;
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Calls the OnDetachingFrom method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            this.listView.ItemTapped -= this.OnItemTapped;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Determines when an item is tapped in the list view
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Item tapped event arguments.</param>
        private void OnItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            (this.listView.BindingContext as ContactListViewModel).SelectedItem = e.ItemData as ContactInfo;
            this.listView.Navigation.PushAsync(new DataFormPage() { BindingContext = this.listView.BindingContext, Title = "Contact Form" });
        }
    }
}
