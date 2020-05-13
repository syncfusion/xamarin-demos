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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.Cards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardLayout : SampleView
    {
        CardLayoutViewModel viewModel = new CardLayoutViewModel();

        public CardLayout()
        {
            InitializeComponent();

            var childCount = cardLayout.Children.Count;
            for (int i = 0; i < childCount; i++)
            {
                cardLayout.Children[i].BindingContext = viewModel.Data[i];
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                stackLayout.Padding = 15;
            }
        }

        private void OnPaddingChanged(object sender, ValueChangedEventArgs e)
        {
            var horizontalPadding = e.NewValue;
            cardLayout.Padding = new Thickness(horizontalPadding, 5, horizontalPadding, 5);
            paddingLabel.Text = "Padding : " + Math.Round(e.NewValue).ToString();
        }

        private void OnSelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            var direction = e.Index == 0 ? CardSwipeDirection.Left : CardSwipeDirection.Right;
            if (cardLayout.SwipeDirection != direction)
            {
                cardLayout.SwipeDirection = direction;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            if (Device.RuntimePlatform == Device.UWP || Device.Idiom == TargetIdiom.Tablet)
            {
                var padding = width / 4;
                cardLayout.Padding = new Thickness(padding, 5, padding, 5);

                Slider.IsVisible = false;
                paddingLabel.IsVisible = false;
            }

            base.OnSizeAllocated(width, height);
        }
    }
}