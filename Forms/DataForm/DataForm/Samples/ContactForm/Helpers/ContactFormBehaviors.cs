#region Copyright
// <copyright file="ContactFormBehaviors.cs" company="Syncfusion"> 
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
    using SampleBrowser.Core;
    using Xamarin.Forms;

    /// <summary>
    /// User defined behaviour to respond arbitrary conditions and events of ContactForm.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ContactFormBehaviors : Behavior<SampleView>
    {
        /// <summary>
        /// A layout used to display image in the contact form list to tap the view to add and edit the contact list.
        /// </summary>
        private Grid myGrid;

        /// <summary>
        /// A layout used to display illustration view in the contact form list to tap the view to add and edit the contact list.
        /// </summary>
        private Grid transparent;

        /// <summary>
        /// A layout used to display contact form list with contact image, contact name and phone number.
        /// </summary>
        private Grid customView;

        /// <summary>
        /// Attaches to the superclass and then calls the OnAttachTo method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected async override void OnAttachedTo(SampleView bindable)
        {
            await Task.Delay(200);
            this.customView = bindable.FindByName<Grid>("gridLayout");
            this.transparent = bindable.FindByName<Grid>("Illustrationgrid");
            this.myGrid = new Grid();
            this.myGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(1.1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            };
            this.myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            this.myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.8, GridUnitType.Star) });
            this.myGrid.Children.Add(new Image() { Opacity = 1.0, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Source = "TapEditIllustration.png" }, 1, 1);
            this.myGrid.BackgroundColor = Color.Transparent;
            this.myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Collapse) });
            this.customView.Children.Add(this.myGrid);

            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Calls the OnDetachingFrom method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            this.myGrid = null;
            this.transparent = null;
            this.customView = null;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Collapse the views in the contact form.
        /// </summary>
        private void Collapse()
        {
            this.myGrid.IsEnabled = false;
            this.myGrid.IsVisible = false;
            this.transparent.IsVisible = false;
            this.customView.Children.Remove(this.myGrid);
            this.customView.Children.Remove(this.transparent);
        }
    }
}
