#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataForm
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ContactFormBehaviors : Behavior<SampleView>
    {

        private Grid myGrid;
        private Grid transparent;
        private Grid customView;

        protected async override void OnAttachedTo(SampleView bindable)
        {
            await Task.Delay(200);
            customView = bindable.FindByName<Grid>("gridLayout");
            transparent = bindable.FindByName<Grid>("Illustrationgrid");
            myGrid = new Grid();
            myGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            myGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            myGrid.RowDefinitions = new RowDefinitionCollection
            {
            new RowDefinition {Height = new GridLength(1.1,GridUnitType.Star)},
            new RowDefinition {Height = new GridLength(1,GridUnitType.Star)},
            };
            myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.8, GridUnitType.Star) });
            myGrid.Children.Add(new Image()
            {
                Opacity = 1.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.TapEditIllustration.png")
            }, 1, 1);
            myGrid.BackgroundColor = Color.Transparent;
            myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Collapse) });
            customView.Children.Add(myGrid);

            base.OnAttachedTo(bindable);
        }
        private void Collapse()
        {
            myGrid.IsEnabled = false;
            myGrid.IsVisible = false;
            transparent.IsVisible = false;
            customView.Children.Remove(myGrid);
            customView.Children.Remove(transparent);
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            myGrid = null;
            transparent = null;
            customView = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
