#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfNumericUpDown.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser.SfNumericUpDown
{
    public partial class NumericUpDown_Default : SampleView
    {

        void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            if (e.Value.ToString() == "0" || e.Value.ToString() == "0.0")
                appleAddButton.IsEnabled = false;
            else
                appleAddButton.IsEnabled = true;
            this.AppleCost.Text = "$" + Convert.ToDouble(e.Value) * 0.49;
        }
        void Handle_ValueChanged2(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            if (e.Value.ToString() == "0" || e.Value.ToString() == "0.0")
                pomegranateAddButton.IsEnabled = false;
            else
                pomegranateAddButton.IsEnabled = true;
            this.PomegranateCost.Text = "$" + Convert.ToDouble(e.Value) * 0.99;
        }

        void Handle_ValueChanged3(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            if (e.Value.ToString() == "0" || e.Value.ToString() == "0.0")
                orangeAddButton.IsEnabled = false;
            else
                orangeAddButton.IsEnabled = true;
            this.OrangeCost.Text = "$" + Convert.ToDouble(e.Value) * 0.19;
        }

        void Handle_ValueChanged4(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            if (e.Value.ToString() == "0" || e.Value.ToString() == "0.0")
                bananaAddButton.IsEnabled = false;
            else
                bananaAddButton.IsEnabled = true;
            this.BananaCost.Text = "$" + Convert.ToDouble(e.Value) * 0.09;
        }


        int totalCart = 0;

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            totalCart++;
            TotalCart.Text = "(" + totalCart.ToString() + ")";
        }


        public NumericUpDown_Default()
        {
            InitializeComponent();

            optionView();

            AppleCount.Minimum = PomegranateCount.Minimum = OrangeCount.Minimum = BananaCount.Minimum = 0;

            AppleCount.Maximum = PomegranateCount.Maximum = OrangeCount.Maximum = BananaCount.Maximum = 25;


        }
        public void optionView()
        {
            double height = Bounds.Height;
            double width = Core.SampleBrowser.ScreenWidth;
            double density = Core.SampleBrowser.Density;

            minimumValueText.TextChanged += MinimumValueChanged;

            maximumValueText.TextChanged += MaximumValueChanged;
            maximumValueText.Unfocused += MaximumValueText_Focused;
            FontSizeText.TextChanged += FontSizeText_TextChanged;
            //Auto Reversee
            autoReverseToggle.Toggled += (object sender, ToggledEventArgs e) =>
            {
                AppleCount.AutoReverse = PomegranateCount.AutoReverse = OrangeCount.AutoReverse = BananaCount.AutoReverse = e.Value;
            };
            selectallonfocusToggle.Toggled += (object sender, ToggledEventArgs e) => 
            {
                AppleCount.SelectAllOnFocus = PomegranateCount.SelectAllOnFocus = OrangeCount.SelectAllOnFocus = BananaCount.SelectAllOnFocus = e.Value;
            };
            localePicker.Items.Add("Both");
            localePicker.Items.Add("Left");
            localePicker.Items.Add("Right");

            localePicker.SelectedIndex = 0;
            localePicker.SelectedIndexChanged += localePickerChanged;

            if (Device.RuntimePlatform == Device.Android)
            {

                fruitHeadingLabel.FontSize = 18;
                checkoutLabel.FontSize = 16;
                TotalCart.FontSize = 16;
                AppleCount.HeightRequest = 45;
                appleAddButton.HeightRequest = 45;
                bananaAddButton.HeightRequest = 45;
                BananaCount.HeightRequest = 45;
                orangeAddButton.HeightRequest = 45;
                OrangeCount.HeightRequest = 45;
                pomegranateAddButton.HeightRequest = 45;
                PomegranateCount.HeightRequest = 45;
				appleAddButton.Font = Font.SystemFontOfSize(14);
                orangeAddButton.Font = Font.SystemFontOfSize(14);
                bananaAddButton.Font = Font.SystemFontOfSize(14);
                pomegranateAddButton.Font = Font.SystemFontOfSize(14);
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                fruitHeadingLabel.FontSize = 18;
                checkoutLabel.FontSize = 18;
                checkoutLabel.Margin = new Thickness(0, 8, 0, 0);
                TotalCart.Margin = new Thickness(5, 8, 0, 5);
                TotalCart.FontSize = 18;
                AppleCost.FontSize = 15;
                appleAddButton.FontSize = 14;
                appleAddButton.WidthRequest = 100;
                AppleCost.VerticalTextAlignment = TextAlignment.Center;
                appleAddButton.VerticalOptions = LayoutOptions.Center;
                AppleCount.HeightRequest = 35;

                BananaCost.FontSize = 15;
                bananaAddButton.FontSize = 14;
                bananaAddButton.WidthRequest = 100;
                BananaCost.VerticalTextAlignment = TextAlignment.Center;
                bananaAddButton.VerticalOptions = LayoutOptions.Center;
                BananaCount.HeightRequest = 35;

                OrangeCost.FontSize = 15;
                orangeAddButton.FontSize = 14;
                orangeAddButton.WidthRequest = 100;
                OrangeCost.VerticalTextAlignment = TextAlignment.Center;
                orangeAddButton.VerticalOptions = LayoutOptions.Center;
                OrangeCount.HeightRequest = 35;

                PomegranateCost.FontSize = 15;
                pomegranateAddButton.FontSize = 14;
                pomegranateAddButton.WidthRequest = 100;
                PomegranateCost.VerticalTextAlignment = TextAlignment.Center;
                pomegranateAddButton.VerticalOptions = LayoutOptions.Center;
                PomegranateCount.HeightRequest = 35;


                cartInfoStack.Padding = new Thickness(-20, 0, 0, 0);
                checkoutLabel.HorizontalTextAlignment = TextAlignment.Center;
                TotalCart.HorizontalTextAlignment = TextAlignment.Center;
                optionLayout.Padding = new Thickness(0, 0, 10, 0);
                optionLayout.Spacing = 0;
            }
            else if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                sampleLayout.Padding = new Thickness(10, 0, 0, 0);
                optionLayout.Padding = new Thickness(10, 0, 10, 0);
                localePicker.HeightRequest = 90;
                autoReverseToggle.WidthRequest = width / 2;
                autoReverseToggle.HorizontalOptions = LayoutOptions.End;
                selectallonfocusToggle.WidthRequest = width / 2;
                selectallonfocusToggle.HorizontalOptions = LayoutOptions.End;
            }
            if (Device.RuntimePlatform == Device.UWP)
            {
                minimumValueLabel.TextColor = Color.Gray;
                maximumValueLabel.TextColor = Color.Gray;
                autoReverseLabel.TextColor = Color.Gray;
                selectallonfocuslabel.TextColor = Color.Gray;
                spinButtonAlignmentLabel.TextColor = Color.Gray;
                aheader.Height = 25;
                pheader.Height = 25;
                bheader.Height = 25;
                oheader.Height = 25;
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    sampleLayout.HorizontalOptions = LayoutOptions.Center;
                    sampleLayout.WidthRequest = 500;
                    minColumn1.Width = new GridLength(200.0, GridUnitType.Absolute);
                    maxColumn1.Width = new GridLength(200.0, GridUnitType.Absolute);
                    reverseColumn1.Width = new GridLength(200.0, GridUnitType.Absolute);
                    selectallonfocusColumn.Width = new GridLength(200.0, GridUnitType.Absolute);
                    FontSizeColumn.Width = new GridLength(200.0, GridUnitType.Absolute);
                    minimumValueText.HorizontalOptions = LayoutOptions.Start;
                    maximumValueText.HorizontalOptions = LayoutOptions.Start;
                    FontSizeText.HorizontalOptions = LayoutOptions.Start;
                    autoReverseToggle.HorizontalOptions = LayoutOptions.Start;
                    selectallonfocusToggle.HorizontalOptions = LayoutOptions.Start;
                    localePicker.HorizontalOptions = LayoutOptions.Start;
                    localePicker.WidthRequest = 300.0;
                    appleAddButton.FontSize = 12;
                    pomegranateAddButton.FontSize = 12;
                    orangeAddButton.FontSize = 12;
                    bananaAddButton.FontSize = 12;
                }

                if (Device.Idiom == TargetIdiom.Phone)
                {
                    AppleCost.VerticalTextAlignment = TextAlignment.Center;
                    appleAddButton.FontSize = 10;
                    appleAddButton.WidthRequest = 90;
                    pomegranateAddButton.FontSize = 10;
                    pomegranateAddButton.WidthRequest = 90;
                    orangeAddButton.FontSize = 10;
                    orangeAddButton.WidthRequest = 90;
                    bananaAddButton.FontSize = 10;
                    bananaAddButton.WidthRequest = 90;
                }
            }
        }

        void MinimumValueChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                double minimum;
                if (double.TryParse(e.NewTextValue, out minimum) && minimum != AppleCount.Minimum)
                {
                    if (minimum < AppleCount.Maximum)
                    {
                        AppleCount.Minimum = PomegranateCount.Minimum = OrangeCount.Minimum = BananaCount.Minimum = minimum;
                    }
                    else
                    {
                        AppleCount.Minimum = PomegranateCount.Minimum = OrangeCount.Minimum = BananaCount.Minimum = AppleCount.Maximum;

                        minimumValueText.Text = AppleCount.Maximum.ToString();
                    }
                }
            }
            else
            {
                AppleCount.Minimum = PomegranateCount.Minimum = OrangeCount.Minimum = BananaCount.Minimum = 1;

            }
        }
        void MaximumValueChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                double maximum;
                if (double.TryParse(e.NewTextValue, out maximum) && maximum != AppleCount.Maximum)
                {
                   AppleCount.Maximum = PomegranateCount.Maximum = OrangeCount.Maximum = BananaCount.Maximum = maximum;
                }
            }
            else
            {
                AppleCount.Maximum = PomegranateCount.Maximum = OrangeCount.Maximum = BananaCount.Maximum = 25;
            }
        }

        void FontSizeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                double fontsize;
                if (double.TryParse(e.NewTextValue, out fontsize) && fontsize != AppleCount.FontSize)
                {
                    AppleCount.FontSize = PomegranateCount.FontSize = OrangeCount.FontSize = BananaCount.FontSize = fontsize;
                }
            }
            else
            {
                AppleCount.FontSize = PomegranateCount.FontSize = OrangeCount.FontSize = BananaCount.FontSize = 18;
            }
        }

        void MaximumValueText_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if(!e.IsFocused)
            {
				double maximum;
                if (double.TryParse(maximumValueText.Text.ToString(), out maximum))
				{
                    if (!(maximum > AppleCount.Minimum))
					{
                        AppleCount.Maximum = PomegranateCount.Maximum = OrangeCount.Maximum = BananaCount.Maximum  = AppleCount.Minimum;
                        maximumValueText.Text = AppleCount.Minimum.ToString();
					}
				} 
            }
        }

        void localePickerChanged(object sender, EventArgs e)
        {
            switch (localePicker.SelectedIndex)
            {
                case 0:
                    {
                        AppleCount.SpinButtonAlignment = PomegranateCount.SpinButtonAlignment = OrangeCount.SpinButtonAlignment = BananaCount.SpinButtonAlignment = SpinButtonAlignment.Both;
                        AppleCount.TextAlignment = PomegranateCount.TextAlignment = OrangeCount.TextAlignment = BananaCount.TextAlignment = TextAlignment.Center;
                    }
                    break;
                case 1:
                    {
                        AppleCount.SpinButtonAlignment = PomegranateCount.SpinButtonAlignment = OrangeCount.SpinButtonAlignment = BananaCount.SpinButtonAlignment = SpinButtonAlignment.Left;
                        AppleCount.TextAlignment = PomegranateCount.TextAlignment = OrangeCount.TextAlignment = BananaCount.TextAlignment = TextAlignment.End;
                    }
                    break;
                case 2:
                    {
                        AppleCount.SpinButtonAlignment = PomegranateCount.SpinButtonAlignment = OrangeCount.SpinButtonAlignment = BananaCount.SpinButtonAlignment = SpinButtonAlignment.Right;
                        AppleCount.TextAlignment = PomegranateCount.TextAlignment = OrangeCount.TextAlignment = BananaCount.TextAlignment = TextAlignment.Start;
                    }
                    break;
            }
        }

        public View getContent()
        {
            return this.Content;
        }

        public View getPropertyView()
        {
            return this.PropertyView;
        }
    }



}



