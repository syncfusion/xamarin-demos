#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Cards;
using System;
using System.Collections.Generic;
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
        public CardView()
        {
            InitializeComponent();
        }

        private void CornerRadiusChanged(object sender, ValueChangedEventArgs e)
        {
            CornerRadiusValue.Text = "Corner radius : " + Math.Round(e.NewValue).ToString();
        }

        private void RefreshButtonClicked(object sender, EventArgs e)
        {
            var viewModel = grid.BindingContext as CardViewModel;
            if (viewModel.IsCardAlreadySwiped)
            {
                grid.Children.RemoveAt(0);
                grid.Children.Insert(0, new CardViewTemplate());
                viewModel.IsCardAlreadySwiped = false;
            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            (grid.BindingContext as CardViewModel).IndicatorThickness = (sender as Switch).IsToggled ? 10 : 0;
        }
    }
}