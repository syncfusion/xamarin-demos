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
    public partial class RangeSlider_Tablet : SampleView
    {
        StackLayout view;
        Button closeButton;
        Label placementLabel, emptyLabel, tickLabel;
        Picker positionPicker1, positionPicker2;
        Switch toggleButton;
        bool tooltip = true;
        int label = 1, tick = 1;

        public RangeSlider_Tablet()
        {
            InitializeComponent();
            getPropertiesWindow();

            RangeChangeEvent();

            DeviceChanges();

            if (App.Current.MainPage != null && App.Current.MainPage.Visual == VisualMarker.Material)
            {
                this.SetMaterialValues(sfRangeSlider1);
                this.SetMaterialValues(sfRangeSlider2);
            }
        }
        public void getPropertiesWindow()
        {
            view = new StackLayout();
            view.HeightRequest = Property_Windows.HeightRequest;
            view.BackgroundColor = Color.FromRgb(250, 250, 250);

            StackLayout propertyLayout = new StackLayout();
            propertyLayout.Orientation = StackOrientation.Horizontal;
            propertyLayout.BackgroundColor = Color.FromRgb(230, 230, 230);
            propertyLayout.Padding = new Thickness(10, 0, 0, 0);
            TapGestureRecognizer tab = new TapGestureRecognizer();
            tab.Tapped += tab_Tapped;
            propertyLayout.GestureRecognizers.Add(tab);
            Label propertyLabel = new Label();
            propertyLabel.Text = "OPTIONS";
            propertyLabel.WidthRequest = 150;
            propertyLabel.VerticalOptions = LayoutOptions.Center;
            propertyLabel.HorizontalOptions = LayoutOptions.Start;
            propertyLabel.FontFamily = "Helvetica";
            propertyLabel.FontSize = 18;
            closeButton = new Button();
            if (Device.RuntimePlatform == Device.iOS)
            {
                closeButton.Text = "X";
                closeButton.TextColor = Color.FromRgb(51, 153, 255);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                closeButton.Image = "cancelsearch.png";
            }else{
                closeButton.Image = "sfclosebutton.png";
            }
            closeButton.Clicked += Close_Button;

            closeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
            propertyLayout.Children.Add(propertyLabel);
            propertyLayout.Children.Add(closeButton);
            temp.BackgroundColor = Color.FromRgb(230, 230, 230);
            closeButton.BackgroundColor = Color.FromRgb(230, 230, 230);
            Property_Button.BackgroundColor = Color.FromRgb(230, 230, 230);


            StackLayout placementLayout = new StackLayout();
            placementLayout.Orientation = StackOrientation.Horizontal;
            placementLayout.Padding = new Thickness(40, 0, 0, 20);
            placementLabel = new Label();
            placementLabel.Text = "Tick Placement";
            placementLabel.WidthRequest = 250;
            placementLabel.VerticalOptions = LayoutOptions.Center;
            placementLabel.HorizontalOptions = LayoutOptions.End;
            placementLabel.FontFamily = "Helvetica";
            placementLabel.FontSize = 16;
            positionPicker1 = new Picker();
            positionPicker1.WidthRequest = 150;
            positionPicker1.VerticalOptions = LayoutOptions.Center;
            positionPicker1.HorizontalOptions = LayoutOptions.Start;
            positionPicker1.Items.Add("TopLeft");
            positionPicker1.Items.Add("BottomRight");
            positionPicker1.Items.Add("Inline");
            positionPicker1.Items.Add("Outside");
            positionPicker1.Items.Add("None");
            positionPicker1.SelectedIndex = tick;

            positionPicker1.SelectedIndexChanged += picker1_SelectedIndexChanged;
            placementLayout.Children.Add(placementLabel);
            placementLayout.Children.Add(positionPicker1);

            StackLayout labelLayout = new StackLayout();
            labelLayout.Orientation = StackOrientation.Horizontal;
            labelLayout.Padding = new Thickness(40, 0, 0, 20);
            tickLabel = new Label();
            tickLabel.Text = "Label Placement";
            tickLabel.WidthRequest = 250;
            tickLabel.VerticalOptions = LayoutOptions.Center;
            tickLabel.HorizontalOptions = LayoutOptions.End;
            tickLabel.FontFamily = "Helvetica";
            tickLabel.FontSize = 16;
            positionPicker2 = new Picker();
            positionPicker2.Items.Add("TopLeft");
            positionPicker2.Items.Add("BottomRight");
            positionPicker2.SelectedIndex = label;
            positionPicker2.WidthRequest = 150;
            positionPicker2.VerticalOptions = LayoutOptions.Center;
            positionPicker2.HorizontalOptions = LayoutOptions.Start;

            positionPicker2.SelectedIndexChanged += picker2_SelectedIndexChanged;

            labelLayout.Children.Add(tickLabel);
            labelLayout.Children.Add(positionPicker2);


            StackLayout layoutLabel = new StackLayout();
            layoutLabel.Orientation = StackOrientation.Horizontal;
            layoutLabel.Padding = new Thickness(40, 0, 0, 20);
            emptyLabel = new Label();
            emptyLabel.Text = "Show Label";
            emptyLabel.WidthRequest = 250;
            emptyLabel.HorizontalOptions = LayoutOptions.End;
            emptyLabel.VerticalOptions = LayoutOptions.Center;
            emptyLabel.FontFamily = "Helvetica";
            emptyLabel.FontSize = 16;
            toggleButton = new Switch();
            toggleButton.Toggled += toggleStateChanged;
            toggleButton.IsToggled = tooltip;
            toggleButton.HorizontalOptions = LayoutOptions.Start;
            toggleButton.VerticalOptions = LayoutOptions.Center;
            layoutLabel.Children.Add(emptyLabel);
            layoutLabel.Children.Add(toggleButton);

            StackLayout emptyLayout = new StackLayout();
            emptyLayout.Orientation = StackOrientation.Vertical;
            emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
            emptyLayout.Padding = new Thickness(40, 20, 40, 40);
            if (Device.RuntimePlatform == Device.iOS)
                emptyLayout.Padding = new Thickness(170, 20, 40, 40);

            emptyLayout.Children.Add(placementLayout);
            emptyLayout.Children.Add(labelLayout);
            emptyLayout.Children.Add(layoutLabel);

            view.Children.Add(propertyLayout);
            view.Children.Add(emptyLayout);

            Property_Windows.Children.Remove(temp);
            //Property_Windows.Children.Insert(0, view);
        }

        void RangeChangeEvent()
        {
            TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
            tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
            temp.GestureRecognizers.Add(tap_Gestue_Prob);

            sfRangeSlider1.RangeChanging += (object sender, RangeEventArgs e) =>
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
            };
            sfRangeSlider2.RangeChanging += (object sender, RangeEventArgs e) =>
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
            };
        }
        public void Property_Button_Click(object c, EventArgs e)
        {
            getPropertiesWindow();
        }
        void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (positionPicker1.SelectedIndex)
            {
                case 0:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.TopLeft;
                        sfRangeSlider2.TickPlacement = TickPlacement.TopLeft;
                        tick = 0;
                        break;
                    }
                case 1:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.BottomRight;
                        sfRangeSlider2.TickPlacement = TickPlacement.BottomRight;
                        tick = 1;
                        break;
                    }
                case 2:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.Inline;
                        sfRangeSlider2.TickPlacement = TickPlacement.Inline;
                        tick = 2;
                        break;
                    }
                case 3:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.Outside;
                        sfRangeSlider2.TickPlacement = TickPlacement.Outside;
                        tick = 3;
                        break;
                    }
                case 4:
                    {
                        sfRangeSlider1.TickPlacement = TickPlacement.None;
                        sfRangeSlider2.TickPlacement = TickPlacement.None;
                        tick = 4;
                        break;
                    }
            }
        }
        void picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (positionPicker2.SelectedIndex)
            {
                case 0:
                    {
                        sfRangeSlider1.ValuePlacement = ValuePlacement.TopLeft;
                        sfRangeSlider2.ValuePlacement = ValuePlacement.TopLeft;
                        label = 0;
                        break;
                    }
                case 1:
                    {
                        sfRangeSlider1.ValuePlacement = ValuePlacement.BottomRight;
                        sfRangeSlider2.ValuePlacement = ValuePlacement.BottomRight;
                        label = 1;
                        break;
                    }
            }
        }

        void DeviceChanges()
        {
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
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
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
                
                sfRangeSlider1.TrackThickness = 2;
                sfRangeSlider2.TrackThickness = 2;
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
                if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
                {
                    sfRangeSlider1.KnobColor = Color.Black;
                    sfRangeSlider2.KnobColor = Color.Black;
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
                arrivalLabel.HeightRequest = 2;

            }
            if (Device.RuntimePlatform == Device.Android)
            {
                if (positionPicker1 != null && positionPicker2 != null && placementLabel != null && emptyLabel != null)
                {
                    positionPicker1.BackgroundColor = Color.FromRgb(239, 239, 239);
                    positionPicker2.BackgroundColor = Color.FromRgb(239, 239, 239);

                }
            }
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                sampleLayout.Padding = new Thickness(10, 0, 10, 0);
                sampleLayout1.Padding = new Thickness(0, 0, 10, 0);
                sampleLayout2.Padding = new Thickness(0, 0, 10, 0);

            }
            Property_Button.Clicked += Property_Button_Click;
        }
        void toggleStateChanged(object sender, ToggledEventArgs e)
        {
            sfRangeSlider1.ShowValueLabel = e.Value;
            sfRangeSlider2.ShowValueLabel = e.Value;
            tooltip = e.Value;
        }
        void tab_Tapped(object sender, EventArgs e)
        {
            closeAction();

        }
        public void closeAction()
        {
            view.BackgroundColor = Color.White;
            Property_Windows.Children.Add(temp);
            Property_Windows.Children.Remove(view);
        }
        void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
        {
            getPropertiesWindow();
        }
        public View getContent()
        {
            return this.Content;
        }
        public void Close_Button(object c, EventArgs e)
        {
            closeAction();

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
            }
        }
    }
}




