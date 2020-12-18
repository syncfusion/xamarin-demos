#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DetailsViewBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using Core;
    using Syncfusion.ListView.XForms;
    using Syncfusion.ListView.XForms.Control.Helpers;
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms;
    using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  DetailsView samples
    /// </summary>
    public class DetailsViewBehaviors : Behavior<SampleView>
    {
        /// <summary>
        /// Holds the instance of the ListView.
        /// </summary>
        private SfListView listview;

        /// <summary>
        /// Holds the instance of the PopupLayout.
        /// </summary>
        private SfPopupLayout popupLayout;

        /// <summary>
        /// Initializes a new instance of the DetailsViewBehaviors class.
        /// </summary>
        public DetailsViewBehaviors()
        {
        }

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            (bindAble.Resources["NotificationPopUp"] as SfPopupLayout).Show();

            this.listview = bindAble.FindByName<SfListView>("listView");
            this.listview.ItemTapped += this.ListView_ItemTapped;
            this.popupLayout = bindAble.FindByName<SfPopupLayout>("popUp");
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            base.OnDetachingFrom(bindAble);
            this.listview.ItemTapped -= this.ListView_ItemTapped;
            this.popupLayout = null;
        }

        /// <summary>
        /// Fired when listView item is tapped.
        /// </summary>
        /// <param name="sender">ItemTapped Event sender</param>
        /// <param name="e">ItemTappedEventArgs event args e</param>
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.ItemType != ItemType.Record)
            {
                return;
            }

            var itemIndex = (this.listview.BindingContext as ContactsViewModel).Contactsinfo.IndexOf(e.ItemData as ContactInfo);
            var visibleLine = this.listview.GetVisualContainer().ScrollRows.GetVisibleLineAtLineIndex(itemIndex);
            var point = this.listview.Y + visibleLine.ClippedOrigin + visibleLine.Size;

            if (point + 140 <= this.listview.Height + 25)
            {
                this.popupLayout.Show(
                    this.listview.X,
                    this.listview.Y + visibleLine.ClippedOrigin + visibleLine.ClippedSize + this.GetRelativeYPoint("top"));
            }
            else
            {
                this.popupLayout.Show(this.listview.X, point - this.GetRelativeYPoint("bottom"));
            }
        }

        /// <summary>
        /// Used to gets the relative point depends on the platform
        /// </summary>
        /// <param name="position">string type of desired position</param>
        /// <returns>returns desired position</returns>
        private double GetRelativeYPoint(string position)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                return position == "top" ? 40 : 200;
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                return position == "top" ? 35 : 207;
            }
            
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                return position == "top" ? 85 : 155;
            }

            return position == "top" ? 0 : 240;
        }
    }
}