#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using Syncfusion.XForms.MaskedEdit;
using Syncfusion.XForms.Buttons;
using Border = Syncfusion.XForms.Border.SfBorder;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfTextInputLayout
{
    /// <summary>
    /// Payment view.
    /// </summary>
    public partial class PaymentView : SampleView
    {
        private ObservableCollection<View> viewCollection = new ObservableCollection<View>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfTextInputLayout.PaymentView"/> class.
        /// </summary>
        public PaymentView()
        {
            InitializeComponent();

            amount.Culture = new System.Globalization.CultureInfo("es-US");

            // picker.SelectedIndex = 1;

            if (Device.RuntimePlatform == Device.UWP)
            {
                grid.IsVisible = false;
            }

            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                var colors = paymentViewModel.Colors;
                foreach (Color color in colors)
                {
                    Grid grid = new Grid();
                    Border border = new Border
                    {
                        Margin = new Thickness(2),
                        HorizontalOptions = LayoutOptions.Center,
                        CornerRadius = 25,
                        BorderWidth = 0,
                        Content = new BoxView { Color = color }
                    };
                    grid.Children.Add(border);
                    viewCollection.Add(grid);
                }

                colorsView.ItemsSource = viewCollection;
            }
        }

        private void CornerRadiusChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            nameLayout.OutlineCornerRadius = e.NewValue;
            cornerRadiusValue.Text = "Corner radius : " + Math.Round(e.NewValue).ToString();
        }

        private void Color_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            if (colorsView.SelectedIndex >= 0)
            {
                PrimaryColorChanged(colorsView.SelectedIndex);
            }
        }

        private void PrimaryColorChanged(int index)
        {
            switch (index)
            {

                case 1:
                    paymentViewModel.BackgroundColor = Color.FromHex("#EAF1FC");
                    paymentViewModel.FocusedColor = Color.FromHex("#0074C4");
                    break;

                case 2:
                    paymentViewModel.BackgroundColor = Color.FromHex("#f4edf2");
                    paymentViewModel.FocusedColor = Color.FromHex("#5C1349");
                    break;

                default:
                    paymentViewModel.BackgroundColor = Color.FromUint(0x0A000000);
                    paymentViewModel.FocusedColor = Color.FromHex("#0074C4");
                    break;

            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            if (Device.RuntimePlatform == Device.Android)
            {          
                if (picker.SelectedIndex == 0)
                {
                    expiredMonth.HeightRequest = 60;
                    expiredYear.HeightRequest = 60;
                }
                else 
                {
                    expiredMonth.HeightRequest = 52;
                    expiredYear.HeightRequest = 52;
                }
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                if (picker.SelectedIndex == 0)
                {
                    expiredMonth.HeightRequest = 60;
                    expiredYear.HeightRequest = 60;
                }
                else if (picker.SelectedIndex == 1)
                {
                    expiredMonth.HeightRequest = 45;
                    expiredYear.HeightRequest = 45;
                }
                else if (picker.SelectedIndex == 2)
                {
                    expiredMonth.HeightRequest = 50;
                    expiredYear.HeightRequest = 50;
                }
            }
        }
    }
}