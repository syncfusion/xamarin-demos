#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.Cards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardView : SampleView
    {
        private bool isToggled;
        private bool isRefreshed;
        CardViewTemplate firstCardView;
        CardViewTemplate secondCardView;
        CardViewTemplate thirdCardView;

        CardViewModel viewModel = new CardViewModel();
        public CardView()
        {
            InitializeComponent();

            grid.BindingContext = viewModel;
            propertyView.BindingContext = viewModel;

            var childCount = grid.Children.Count;
            for (int i = 0; i < childCount; i++)
            {
                grid.Children[i].BindingContext = viewModel.Data[i];
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                mainGrid.HorizontalOptions = LayoutOptions.Center;
                mainGrid.WidthRequest = 500;
            }
        }

        private void CornerRadiusChanged(object sender, ValueChangedEventArgs e)
        {
            CornerRadiusValue.Text = "Corner radius : " + Math.Round(e.NewValue).ToString();
        }

        private void RefreshButtonClicked(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.Children.Count; i++)
            {
                grid.RowDefinitions[i].Height = GridLength.Auto;
            }
            var viewModel = grid.BindingContext as CardViewModel;
            if (viewModel.IsCardAlreadySwiped)
            {
                isRefreshed = true;

                firstCardView = new CardViewTemplate() { VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
                firstCardView.IndicatorThickness = isToggled ? 5 : 0;
                firstCardView.IndicatorColor = Color.FromHex("#b1793b");
                firstCardView.SetBinding(CardViewTemplate.FadeOutOnSwipingProperty, new Binding("IsToggled", source: fadeOutOnSwipingSwitch));
                firstCardView.SetBinding(CardViewTemplate.SwipeToDismissProperty, new Binding("IsToggled", source: swipeToDismissSwitch));
                firstCardView.SetBinding(CardViewTemplate.CornerRadiusProperty, new Binding("Value", source:slider));
                firstCardView.BindingContext = viewModel.Data[0];

                secondCardView = new CardViewTemplate() { VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
                secondCardView.IndicatorThickness = isToggled ? 5 : 0;
                secondCardView.IndicatorColor = Color.FromHex("#606472");
                secondCardView.SetBinding(CardViewTemplate.FadeOutOnSwipingProperty, new Binding("IsToggled", source: fadeOutOnSwipingSwitch));
                secondCardView.SetBinding(CardViewTemplate.SwipeToDismissProperty, new Binding("IsToggled", source: swipeToDismissSwitch));
                secondCardView.SetBinding(CardViewTemplate.CornerRadiusProperty, new Binding("Value", source: slider));
                secondCardView.BindingContext = viewModel.Data[1];

                thirdCardView = new CardViewTemplate() { VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
                thirdCardView.IndicatorThickness = isToggled ? 5 : 0;
                thirdCardView.IndicatorColor = Color.FromHex("#23221d");
                thirdCardView.SetBinding(CardViewTemplate.FadeOutOnSwipingProperty, new Binding("IsToggled", source: fadeOutOnSwipingSwitch));
                thirdCardView.SetBinding(CardViewTemplate.SwipeToDismissProperty, new Binding("IsToggled", source: swipeToDismissSwitch));
                thirdCardView.SetBinding(CardViewTemplate.CornerRadiusProperty, new Binding("Value", source: slider));
                thirdCardView.BindingContext = viewModel.Data[2];

                grid.Children.Clear();

                grid.Children.Add(firstCardView, 0, 0);
                grid.Children.Add(secondCardView, 0, 1);
                grid.Children.Add(thirdCardView, 0, 2);

                viewModel.IsCardAlreadySwiped = false;
            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            isToggled = (sender as Switch).IsToggled;
            var indicatorThickness = isToggled ? 5 : 0;

            if (isRefreshed)
            {
                firstCardView.IndicatorThickness = indicatorThickness;
                secondCardView.IndicatorThickness = indicatorThickness;
                thirdCardView.IndicatorThickness = indicatorThickness;

            }
            else
            {
                cardViewOne.IndicatorThickness = indicatorThickness;
                cardViewTwo.IndicatorThickness = indicatorThickness;
                cardViewThree.IndicatorThickness = indicatorThickness;
            }
        }

        private void FadeOutOnSwipingSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value && !swipeToDismissSwitch.IsToggled)
            {
                swipeToDismissSwitch.IsToggled = e.Value;
            }
        }

        private void SwipeToDismissSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (!e.Value)
            {
                fadeOutOnSwipingSwitch.IsToggled = e.Value;
            }
        }

    }
}