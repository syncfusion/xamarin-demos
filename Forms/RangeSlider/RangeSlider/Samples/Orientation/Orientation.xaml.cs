#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfRangeSlider.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfRangeSlider
{
    public partial class Orientation : SampleView
    {
        public Orientation()
        {
            InitializeComponent();
            sfRangeSlider1.LabelFormat = "{0:N0}db";
            sfRangeSlider2.LabelFormat = "{0:N0}db";
            sfRangeSlider3.LabelFormat = "{0:N0}db";
            hertzLabel.HorizontalTextAlignment = TextAlignment.Center;
            //decibelLabel.HorizontalTextAlignment = TextAlignment.Center;
            //hertzLabel1.HorizontalTextAlignment = TextAlignment.Center;
            //decibelLabel1.HorizontalTextAlignment = TextAlignment.Center;
            //hertzLabel2.HorizontalTextAlignment = TextAlignment.Center;
            //decibelLabel2.HorizontalTextAlignment = TextAlignment.Center;
            DeviceChanges();
            if (App.Current.MainPage != null && App.Current.MainPage.Visual == VisualMarker.Material)
            {
                this.SetMaterialValues(sfRangeSlider1);
                this.SetMaterialValues(sfRangeSlider2);
                this.SetMaterialValues(sfRangeSlider3);
            }
        }

        void DeviceChanges()
        {
            if ((Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone))
            {
                sfRangeSlider1.KnobColor = sfRangeSlider2.KnobColor = sfRangeSlider3.KnobColor = Color.Black;
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    EqualizerLabel.HeightRequest = 40;
                    sfRangeSlider1.WidthRequest = 140;
                    sfRangeSlider2.WidthRequest = 140;
                    sfRangeSlider3.WidthRequest = 140;
                    SecondSlider.Margin = new Thickness(-80, 0, 0, 0);
                    ThirdSlider.Margin = new Thickness(-90, 0, 0, 0);
                    MainRangeSlider.Margin = new Thickness(0, -50, 0, 0);
                }
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    sfRangeSlider1.WidthRequest = 130;
                    sfRangeSlider2.WidthRequest = 130;
                    sfRangeSlider3.WidthRequest = 130;
                }
            }
            else
            {
                hertzLabel.FontSize = 20;
                hertzLabel.Text = "60 Hz";
               // hertzLabel.HeightRequest = 24;
                hertzLabel.VerticalTextAlignment = TextAlignment.Center;
                hertzLabel.TextColor = Color.FromRgb(109, 109, 114);
                hertzLabel.HorizontalTextAlignment = TextAlignment.Center;

                hertzLabel1.FontSize = 20;
                hertzLabel1.Text = "170 Hz";
              //  hertzLabel1.HeightRequest = 24;
                hertzLabel1.VerticalTextAlignment = TextAlignment.Center;
                hertzLabel1.TextColor = Color.FromRgb(109, 109, 114);
                hertzLabel1.HorizontalTextAlignment = TextAlignment.Center;

                hertzLabel2.FontSize = 20;
                hertzLabel2.Text = "310 Hz";
             //   hertzLabel2.HeightRequest = 24;
                hertzLabel2.VerticalTextAlignment = TextAlignment.Center;
                hertzLabel2.TextColor = Color.FromRgb(109, 109, 114);
                hertzLabel2.HorizontalTextAlignment = TextAlignment.Center;



            }

            if (Device.RuntimePlatform == Device.Android)
            {
                SecondSlider.Margin = new Thickness(-30, 0, 0, 0);
                ThirdSlider.Margin = new Thickness(-30, 0, 0, 0);
                sfRangeSlider1.HorizontalOptions = LayoutOptions.Center;
                sfRangeSlider2.HorizontalOptions = LayoutOptions.Center;
                sfRangeSlider3.HorizontalOptions = LayoutOptions.Center;
                sfRangeSlider1.WidthRequest = 110;
                sfRangeSlider2.WidthRequest = 110;
                sfRangeSlider3.WidthRequest = 110;
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                sfRangeSlider1.TrackSelectionColor = Color.Transparent;
                sfRangeSlider2.TrackSelectionColor = Color.Transparent;
                sfRangeSlider3.TrackSelectionColor = Color.Transparent;
                sfRangeSlider1.TrackThickness = 2;
                sfRangeSlider2.TrackThickness = 2;
                sfRangeSlider3.TrackThickness = 2;
                sfRangeSlider1.ShowValueLabel = true;
                sfRangeSlider2.ShowValueLabel = true;
                sfRangeSlider3.ShowValueLabel = true;
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    sfRangeSlider1.WidthRequest = 90;
                    sfRangeSlider2.WidthRequest = 90;
                    sfRangeSlider3.WidthRequest = 90;
                    sfRangeSlider1.Margin = new Thickness(5, 0, 0, 0);
                    sfRangeSlider2.Margin = new Thickness(5, 0, 0, 0);
                    sfRangeSlider3.Margin = new Thickness(5, 0, 0, 0);
                    sfRangeSlider1.HeightRequest = 300;
                    sfRangeSlider2.HeightRequest = 300;
                    sfRangeSlider3.HeightRequest = 300;
                    if (App.Current.MainPage != null)
                    {
                        if (App.Current.MainPage.Visual != VisualMarker.Material)
                        {
                            sfRangeSlider1.KnobColor = Color.White;
                            sfRangeSlider2.KnobColor = Color.White;
                            sfRangeSlider3.KnobColor = Color.White;
                        }
                    }
                    else
                    {
                        sfRangeSlider1.KnobColor = Color.White;
                        sfRangeSlider2.KnobColor = Color.White;
                        sfRangeSlider3.KnobColor = Color.White;
                    }

                    MainRangeSlider.VerticalOptions = LayoutOptions.FillAndExpand;
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    sfRangeSlider1.WidthRequest = 90;
                    sfRangeSlider2.WidthRequest = 90;
                    sfRangeSlider3.WidthRequest = 90;
                    sfRangeSlider1.HeightRequest = 600;
                    sfRangeSlider2.HeightRequest = 600;
                    sfRangeSlider3.HeightRequest = 600;
                    if (App.Current.MainPage != null)
                    {
                        if (App.Current.MainPage.Visual != VisualMarker.Material)
                        {
                            sfRangeSlider1.KnobColor = Color.White;
                            sfRangeSlider2.KnobColor = Color.White;
                            sfRangeSlider3.KnobColor = Color.White;
                        }
                    }
                    else
                    {
                        sfRangeSlider1.KnobColor = Color.White;
                        sfRangeSlider2.KnobColor = Color.White;
                        sfRangeSlider3.KnobColor = Color.White;
                    }

                    MainRangeSlider.VerticalOptions = LayoutOptions.FillAndExpand;
                }
            }
            else if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                sfRangeSlider1.WidthRequest = 120;
                sfRangeSlider2.WidthRequest = 120;
                sfRangeSlider3.WidthRequest = 120;
                sfRangeSlider1.HeightRequest = 600;
                sfRangeSlider2.HeightRequest = 600;
                sfRangeSlider3.HeightRequest = 600;
                sfRangeSlider1.KnobColor = Color.Gray;
                sfRangeSlider2.KnobColor = Color.Gray;
                sfRangeSlider3.KnobColor = Color.Gray;
                sfRangeSlider1.TrackSelectionColor = Color.Gray;
                sfRangeSlider2.TrackSelectionColor = Color.Gray;
                sfRangeSlider3.TrackSelectionColor = Color.Gray;
            }
            else if (Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Tablet)
            {
                MainRangeSlider.HeightRequest = 450;
                sfRangeSlider1.ShowValueLabel = false;
                sfRangeSlider2.ShowValueLabel = false;
                sfRangeSlider3.ShowValueLabel = false;
                sfRangeSlider1.TrackSelectionColor = sfRangeSlider2.TrackSelectionColor = sfRangeSlider3.TrackSelectionColor = Color.Gray;
                sfRangeSlider1.TrackColor = sfRangeSlider2.TrackColor = sfRangeSlider3.TrackColor = Color.Gray;
            }

            sfRangeSlider1.ValueChanging += (object sender, ValueEventArgs e) =>
            {
                double f = Math.Round(e.Value, 1);


                hertzLabel.Text = (f + 12) * 100 + " Hz";
            };
            sfRangeSlider2.ValueChanging += (object sender, ValueEventArgs e) =>
            {
                double f = Math.Round(e.Value, 1);

                hertzLabel1.Text = (f + 12) * 100 + " Hz";
            };
            sfRangeSlider3.ValueChanging += (object sender, ValueEventArgs e) =>
            {
                double f = Math.Round(e.Value, 1);

                hertzLabel2.Text = (f + 12) * 100 + "Hz";
            };
            if ((Device.Idiom == TargetIdiom.Tablet) && (Device.RuntimePlatform != Device.iOS))
            {
                MainRangeSlider.HorizontalOptions = LayoutOptions.Center;
                MainRangeSlider.Padding = new Thickness(10, 40, 0, 0);
                FirstSlider.Padding = new Thickness(10, 40, 40, 0);
                SecondSlider.Padding = new Thickness(10, 40, 40, 0);
                ThirdSlider.Padding = new Thickness(10, 40, 40, 0);

            }
            else if (Device.RuntimePlatform != Device.iOS)
            {
                MainRangeSlider.HorizontalOptions = LayoutOptions.Center;
                MainRangeSlider.Padding = new Thickness(0, 20, 0, 0);
                FirstSlider.Padding = new Thickness(0, 20, 40, 0);
                SecondSlider.Padding = new Thickness(0, 20, 40, 0);
                ThirdSlider.Padding = new Thickness(0, 20, 40, 0);

            }
        }
        public View getContent()
        {
            return this.Content;
        }

        /// <summary>
        /// Set the color values for material
        /// </summary>
        /// <param name="rangeSlider"></param>
        private void SetMaterialValues(Syncfusion.SfRangeSlider.XForms.SfRangeSlider rangeSlider)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                rangeSlider.LabelColor = Color.FromRgba(0, 0, 0, 200);
            }
        }
    }
}
