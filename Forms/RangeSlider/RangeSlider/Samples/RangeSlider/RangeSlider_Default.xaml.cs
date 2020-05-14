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
using SampleBrowser.Core;
using Syncfusion.SfRangeSlider.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfRangeSlider
{
    public partial class RangeSlider_Default : SampleView
    {
        public RangeSlider_Default()
        {
            InitializeComponent();
            RangeChangeEvent();
            OptionView();
            if (App.Current.MainPage!= null && App.Current.MainPage.Visual == VisualMarker.Material)
            {
                this.SetMaterialValues(sfRangeSlider1);
                this.SetMaterialValues(sfRangeSlider2);
            }
        }
        void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (positionPicker2.SelectedIndex)
            {
                case 0:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.TopLeft;
                        sfRangeSlider2.TickPlacement = TickPlacement.TopLeft;

                        break;
                    }
                case 1:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.BottomRight;
                        sfRangeSlider2.TickPlacement = TickPlacement.BottomRight;
                        break;
                    }
                case 2:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.Inline;
                        sfRangeSlider2.TickPlacement = TickPlacement.Inline;
                        break;
                    }
                case 3:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.Outside;
                        sfRangeSlider2.TickPlacement = TickPlacement.Outside;
                        break;
                    }
                case 4:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.None;
                        sfRangeSlider2.TickPlacement = TickPlacement.None;
                        break;
                    }
            }
        }
        void picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (positionPicker1.SelectedIndex)
            {
                case 0:
                    {
                        sfRangeSlider1.ValuePlacement = ValuePlacement.TopLeft;
                        sfRangeSlider2.ValuePlacement = ValuePlacement.TopLeft;
                        break;
                    }
                case 1:
                    {
                        sfRangeSlider1.ValuePlacement = ValuePlacement.BottomRight;
                        sfRangeSlider2.ValuePlacement = ValuePlacement.BottomRight;
                        break;
                    }
            }
        }
        void toggleStateChanged(object sender, ToggledEventArgs e)
        {
            sfRangeSlider1.ShowValueLabel = e.Value;
            sfRangeSlider2.ShowValueLabel = e.Value;
        }
        void toggleStateChanged1(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                sfRangeSlider1.SnapsTo = SnapsTo.Ticks;
                sfRangeSlider2.SnapsTo = SnapsTo.Ticks;
            }
            else
            {
                sfRangeSlider1.SnapsTo = SnapsTo.None;
                sfRangeSlider2.SnapsTo = SnapsTo.None;
            }
        }

        void RangeChangeEvent()
        {
            sfRangeSlider1.RangeChanging += (object sender, RangeEventArgs e) =>
            {
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    if (Math.Round(e.Start) < 1)
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel3.Text = "12 AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel3.Text = "12 AM - " + Math.Round(e.End) + " AM";
                    }
                    else
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel3.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel3.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " AM";
                    }
                    if (Math.Round(e.Start) == Math.Round(e.End))
                    {
                        if (Math.Round(e.Start) < 1)
                            timeLabel3.Text = "12 AM";
                        else if (Math.Round(e.Start) == 12)
                            timeLabel3.Text = "12 PM";
                        else
                            timeLabel3.Text = Math.Round(e.Start) + " AM";
                    }
                }
                if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
                {
                    if (Math.Round(sfRangeSlider1.RangeStart) < 1)
                    {
                        if (Math.Round(sfRangeSlider1.RangeEnd) == 12)
                            timeLabel3.Text = "12 AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " PM";
                        else
                            timeLabel3.Text = "12 AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " AM";
                    }
                    else
                    {
                        if (Math.Round(sfRangeSlider1.RangeEnd) == 12)
                            timeLabel3.Text = Math.Round(sfRangeSlider1.RangeStart) + " AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " PM";
                        else
                            timeLabel3.Text = Math.Round(sfRangeSlider1.RangeStart) + " AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " AM";
                    }
                    if (Math.Round(sfRangeSlider1.RangeStart) == Math.Round(sfRangeSlider1.RangeEnd))
                    {
                        if (Math.Round(sfRangeSlider1.RangeStart) < 1)
                            timeLabel3.Text = "12 AM";
                        else if (Math.Round(sfRangeSlider1.RangeStart) == 12)
                            timeLabel3.Text = "12 PM";
                        else
                            timeLabel3.Text = Math.Round(sfRangeSlider1.RangeStart) + " AM";
                    }
                }
            };
            sfRangeSlider2.RangeChanging += (object sender, RangeEventArgs e) =>
            {
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    if (Math.Round(e.Start) < 1)
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel4.Text = "12 AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel4.Text = "12 AM - " + Math.Round(e.End) + " AM";
                    }
                    else
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel4.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel4.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " AM";
                    }
                    if (Math.Round(e.Start) == Math.Round(e.End))
                    {
                        if (Math.Round(e.Start) < 1)
                            timeLabel4.Text = "12 AM";
                        else if (Math.Round(e.Start) == 12)
                            timeLabel4.Text = "12 PM";
                        else
                            timeLabel4.Text = Math.Round(e.Start) + " AM";
                    }
                }
                if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
                {
                    if (Math.Round(sfRangeSlider2.RangeStart) < 1)
                    {
                        if (Math.Round(sfRangeSlider2.RangeEnd) == 12)
                            timeLabel4.Text = "12 AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " PM";
                        else
                            timeLabel4.Text = "12 AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " AM";
                    }
                    else
                    {
                        if (Math.Round(sfRangeSlider2.RangeEnd) == 12)
                            timeLabel4.Text = Math.Round(sfRangeSlider2.RangeStart) + " AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " PM";
                        else
                            timeLabel4.Text = Math.Round(sfRangeSlider2.RangeStart) + " AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " AM";
                    }
                    if (Math.Round(sfRangeSlider2.RangeStart) == Math.Round(sfRangeSlider2.RangeEnd))
                    {
                        if (Math.Round(sfRangeSlider2.RangeStart) < 1)
                            timeLabel4.Text = "12 AM";
                        else if (Math.Round(sfRangeSlider2.RangeStart) == 12)
                            timeLabel4.Text = "12 PM";
                        else
                            timeLabel4.Text = Math.Round(sfRangeSlider2.RangeStart) + " AM";
                    }
                }
            };
        }

        void OptionView()
        {
            toggleButton.Toggled += toggleStateChanged;
            toggleButton2.Toggled += toggleStateChanged1;

            positionPicker2.Items.Add("TopLeft");
            positionPicker2.Items.Add("BottomRight");
            positionPicker2.Items.Add("Inline");
            positionPicker2.Items.Add("Outside");
            positionPicker2.Items.Add("None");
            positionPicker2.SelectedIndex = 1;

            positionPicker2.SelectedIndexChanged += picker1_SelectedIndexChanged;
            positionPicker1.Items.Add("TopLeft");
            positionPicker1.Items.Add("BottomRight");
            positionPicker1.SelectedIndex = 1;

            positionPicker1.SelectedIndexChanged += picker2_SelectedIndexChanged;

            timeLabel3.TextColor = Color.FromHex("#939394");
            timeLabel4.TextColor = Color.FromHex("#939394");

            if (Device.RuntimePlatform == Device.Android)
            {
                timeLabel5.FontSize = 12;
                timeLabel5.Text = "   Time: ";
                timeLabel5.HeightRequest = 20;

                timeLabel5.TextColor = Color.FromHex("#939394");
                timeLabel6.FontSize = 12;
                timeLabel6.Text = "   Time: ";
                timeLabel6.HeightRequest = 20;
                departureLabel.Text = "  Departure";
                departureLabel.HeightRequest = 20;
                arrivalLabel.Text = "  Arrival";
                arrivalLabel.HeightRequest = 20;
                pickerLayout1.Padding = new Thickness(-2, 0, 0, 0);
                pickerLayout2.Padding = new Thickness(-2, 0, 0, 0);

            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                page4.Padding = new Thickness(0, 0, 10, 0);
                emptyLabel.WidthRequest = 200;
                snapsToLabel.WidthRequest = 200;
                if (App.Current.MainPage != null)
                {
                    if (App.Current.MainPage.Visual != VisualMarker.Material)
                    {
                        sfRangeSlider1.KnobColor = Color.White;
                        sfRangeSlider2.KnobColor = Color.White;
                    }
                }
                else
                {
                    sfRangeSlider1.KnobColor = Color.White;
                    sfRangeSlider2.KnobColor = Color.White;
                }

                timeLabel5.FontSize = 12;
                timeLabel5.Text = "   Time: ";
                timeLabel5.HeightRequest = 20;
                timeLabel5.TextColor = Color.FromHex("#939394");
                timeLabel6.FontSize = 12;
                timeLabel6.Text = "   Time: ";
                timeLabel6.HeightRequest = 20;
                timeLabel6.TextColor = Color.FromHex("#939394");
                departureLabel.Text = "  Departure";
                departureLabel.HeightRequest = 20;
                departureLabel.TextColor = Color.Black;
                arrivalLabel.Text = "  Arrival";
                arrivalLabel.HeightRequest = 20;

                arrivalLabel.TextColor = Color.Black;
            }
            else
            {
                if(Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
                {
                    sfRangeSlider1.KnobColor = Color.Black;
                    sfRangeSlider2.KnobColor = Color.Black;
                    if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
                    {
                        sfRangeSlider1.HeightRequest = 90.0;
                        sfRangeSlider2.HeightRequest = 90.0;
                        sfRangeSlider1.Margin = new Thickness(0, -25, 0, 0);
                        sfRangeSlider2.Margin = new Thickness(0, -25, 0, 0);
                    }
                    if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
                    {
                        labelColumn1.Width = new GridLength(200, GridUnitType.Absolute);
                        snapsToColumn1.Width = new GridLength(200, GridUnitType.Absolute);
                        toggleButton.HorizontalOptions = LayoutOptions.Start;
                        toggleButton2.HorizontalOptions = LayoutOptions.Start;
                        positionPicker1.HorizontalOptions = LayoutOptions.Start;
                        positionPicker2.HorizontalOptions = LayoutOptions.Start;
                        positionPicker1.WidthRequest = 300.0;
                        positionPicker2.WidthRequest = 300.0;
                    }
                }
                timeLabel6.FontSize = 12;
                timeLabel6.Text = "Time: ";
                timeLabel6.HeightRequest = 20;
                timeLabel5.FontSize = 12;
                timeLabel5.Text = "Time: ";
                timeLabel5.HeightRequest = 20;
                departureLabel.Text = "Departure";
                departureLabel.HeightRequest = 20;
                arrivalLabel.Text = "Arrival";
                arrivalLabel.HeightRequest = 20;

            }
            if (Device.RuntimePlatform == Device.Android)
            {
                placementLabel.FontSize = 16;
                emptyLabel.FontSize = 16;
                snapsToLabel.FontSize = 16;
            }
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                //sampleLayout.Padding = new Thickness(10, 0, 10, 0);
                //sampleLayout1.Padding = new Thickness(0, 0, 10, 0);
                //sampleLayout2.Padding = new Thickness(0, 0, 10, 0);
                page4.Padding = new Thickness(10, 0, 10, 0);
                sfRangeSlider1.HeightRequest = 110;
                sfRangeSlider2.HeightRequest = 110;
                emptyLabel.WidthRequest = 150;
                snapsToLabel.WidthRequest = 150;

                positionPicker1.HeightRequest = 90;
                positionPicker2.HeightRequest = 90;

                //.TextColor = Color.White;



                placementLabel.Text = "  " + "Tick Placement";
                placementLabel.HeightRequest = 22;
                placementLabel.Text = "  " + "Label Placement";
                placementLabel.HeightRequest = 22;
                emptyLabel.Text = "  " + "Label";
                emptyLabel.HeightRequest = 22;
                timeLabel1.FontSize = 20;
                timeLabel2.FontSize = 20;
                timeLabel3.FontSize = 20;
                timeLabel4.FontSize = 20;
                timeLabel5.FontSize = 20;
                timeLabel6.FontSize = 20;
            }


            //timeLabel3.WidthRequest = 100;
            //timeLabel4.WidthRequest = sfRangeSlider1.Width;
            //emptyLabel.WidthRequest = snapsToLabel.Width;
            timeLabel3.WidthRequest = 100;
            timeLabel4.WidthRequest = 100;
        }
        public View getContent()
        {
            return this.Content;
        }
        public View getPropertyView()
        {
            return this.PropertyView;
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
                rangeSlider.TickPlacement = TickPlacement.Inline;
                positionPicker2.SelectedIndex = 2;
            }
        }
    }
}


