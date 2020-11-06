#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DragAndDropBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
 
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the DragAndDrop samples
    /// </summary>
    public class DragAndDropBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid myGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid customView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid transparent;

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A SampleView type of parameter bindAble</param>
        protected async override void OnAttachedTo(SampleView bindAble)
        {        
            var assembly = Assembly.GetAssembly(Application.Current.GetType());
            await Task.Delay(200);
            this.customView = bindAble.FindByName<Grid>("customLayout");
            this.transparent = bindAble.FindByName<Grid>("transparent");
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
            this.myGrid.Children.Add(
                new Image()
            {
                Opacity = 1.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = "DragDropIllustration.png",
            }, 
            1, 
            1);
            this.myGrid.BackgroundColor = Color.Transparent;
            this.myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Collapse) });
            this.customView.Children.Add(this.myGrid);
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.myGrid = null;
            this.customView = null;
            this.transparent = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Used this method for removing the child element of CustomView 
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
