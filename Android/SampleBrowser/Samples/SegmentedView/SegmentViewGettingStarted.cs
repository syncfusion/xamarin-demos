#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Util;
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using Android.Graphics;
using Syncfusion.Android.Buttons;

namespace SampleBrowser
{
    public class SegmentViewGettingStarted : SamplePage
    {
        SfSegmentedControl segmentedView, colorSegmentView, sizeSegmentView;
        SelectionIndicatorSettings segmentedIndicatorSettings, colorIndicatorSettings, sizeIndicatorSettings;
        SegementViewViewModel ViewModel;
        TextView ClothView;
        private string fontIconText = String.Empty;
        LinearLayout mainLayout;

        public SegmentViewGettingStarted()
        {
        }
        public override View GetSampleContent(Context con)
        {
            mainLayout = new LinearLayout(con);
            mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            mainLayout.Orientation = Android.Widget.Orientation.Vertical;

            segmentedIndicatorSettings = new SelectionIndicatorSettings();
            colorIndicatorSettings = new SelectionIndicatorSettings();
            sizeIndicatorSettings = new SelectionIndicatorSettings();

            segmentedView = new SfSegmentedControl(con);
            colorSegmentView = new SfSegmentedControl(con);
            sizeSegmentView = new SfSegmentedControl(con);
            ViewModel = new SegementViewViewModel(con);

            LinearLayout segementLayout = new LinearLayout(con);
            segementLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 120);
            segementLayout.Orientation = Android.Widget.Orientation.Vertical;
            segementLayout.SetPadding(20, 0, 20, 0);

            segmentedView.ItemsSource = ViewModel.ClothTypeCollection;
            segmentedView.SegmentHeight = 100;
            segmentedView.CornerRadius = 50;
            segmentedView.SegmentHeight = 35;
            segmentedView.VisibleSegmentsCount = 3;
            segmentedView.SelectedIndex = 0;
            segmentedView.BorderColor = Color.Rgb(63, 63, 63);
            segmentedView.SelectionTextColor = Color.Rgb(2, 160, 174);
            segmentedView.FontColor = Color.DarkGray;
            segmentedView.SelectionIndicatorSettings = new SelectionIndicatorSettings { Color = Color.Transparent };
            segmentedView.SelectionChanged += SegmentedView_SelectionChanged;
            segementLayout.AddView(segmentedView);

            Typeface tf = Typeface.CreateFromAsset(con.Assets, "Segmented.ttf");
            ClothView = new TextView(con);
            ClothView.Text = "A";
            ClothView.TextSize = 115;
            ClothView.TextAlignment = TextAlignment.Center;
            ClothView.Gravity = GravityFlags.Center;
            ClothView.Typeface = tf;
            ClothView.SetTextColor(Color.ParseColor("#32318E"));

            ///PriceSegment
            LinearLayout priceLAyout = new LinearLayout(con);
            priceLAyout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 150);
            priceLAyout.Orientation = Android.Widget.Orientation.Vertical;

            TextView clothText = new TextView(con);
            clothText.Text = "Best trendy outfits for men.";
            clothText.TextSize = 12;
            clothText.SetTextColor(Color.ParseColor("#3F3F3F"));
            clothText.TextAlignment = TextAlignment.TextStart;
            clothText.Gravity = GravityFlags.Start;

            TextView priceText = new TextView(con);
            priceText.Text = "$300";
            priceText.Typeface = Typeface.DefaultBold;
            priceText.SetTextColor(Color.ParseColor("#3F3F3F"));
            priceText.TextAlignment = TextAlignment.TextStart;
            priceText.Gravity = GravityFlags.Start;
            priceText.TextSize = 12;

            priceLAyout.SetPadding(20, 0, 0, 0);
            priceLAyout.AddView(clothText);
            priceLAyout.AddView(priceText);

            ///ColorSegment
            LinearLayout colorSegementLayout = new LinearLayout(con);
            colorSegementLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 210);
            colorSegementLayout.Orientation = Android.Widget.Orientation.Vertical;
            colorSegementLayout.SetPadding(20, 0, 20, 0);

            TextView colorText = new TextView(con);
            colorText.Text = "Color";
            colorText.Typeface = Typeface.DefaultBold;
            colorText.TextSize = 12;
            colorText.TextAlignment = TextAlignment.TextStart;
            colorText.Gravity = GravityFlags.Start;

            TextView colorspaceText = new TextView(con);
            colorspaceText.SetHeight(10);

            colorSegmentView.ItemsSource = ViewModel.PrimaryColors;
            colorSegmentView.CornerRadius = 50;
            colorSegmentView.SegmentHeight = 50;
            colorSegmentView.SegmentWidth = 70;
            colorSegmentView.SetBackgroundColor(Color.Transparent);
            colorSegmentView.BorderColor = Color.ParseColor("#EEEEEE");
            colorSegmentView.FontIconFontColor = Color.Black;
            colorSegmentView.SelectedIndex = 0;
            colorSegmentView.FontSize = 12;
            colorSegmentView.VisibleSegmentsCount = 7;
            colorSegmentView.SegmentCornerRadius = 15;
            colorSegmentView.SelectionTextColor = Color.ParseColor("#32318E");
            colorSegmentView.DisplayMode = SegmentDisplayMode.Image;
            colorIndicatorSettings.Color = Color.ParseColor("#EEEEEE");
            colorIndicatorSettings.Position = SelectionIndicatorPosition.Fill;
            colorSegmentView.SelectionIndicatorSettings = colorIndicatorSettings;
            colorSegmentView.SelectionChanged += ColorSegmentView_SelectionChanged;
            colorSegmentView.SetGravity(GravityFlags.Center);

            colorSegementLayout.AddView(colorText);
            colorSegementLayout.AddView(colorspaceText);
            colorSegementLayout.AddView(colorSegmentView);

            ///SizeSegment
            LinearLayout sizeSegementLayout = new LinearLayout(con);
            sizeSegementLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 240);
            sizeSegementLayout.Orientation = Android.Widget.Orientation.Vertical;
            sizeSegementLayout.SetPadding(20, 0, 20, 0);

            TextView sizeText = new TextView(con);
            sizeText.Text = "Size";
            sizeText.Typeface = Typeface.DefaultBold;
            sizeText.TextSize = 12;
            sizeText.TextAlignment = TextAlignment.TextStart;
            sizeText.Gravity = GravityFlags.Start;

            TextView sizespaceText = new TextView(con);
            sizespaceText.SetHeight(10);

            sizeSegmentView.ItemsSource = ViewModel.SizeCollection;
            sizeSegmentView.SegmentHeight = 100;
            sizeSegmentView.CornerRadius = 50;
            sizeSegmentView.BorderColor = Color.ParseColor("#2C7BBC");
            sizeSegmentView.SelectionTextColor = Color.White;
            sizeSegmentView.DisplayMode = SegmentDisplayMode.Text;
            sizeSegmentView.VisibleSegmentsCount = 5;
            sizeSegmentView.SegmentHeight = 40;
            sizeSegmentView.FontSize = 16;
            sizeSegmentView.SegmentWidth = 40;
            sizeSegmentView.FontColor = Color.Black;
            sizeIndicatorSettings.Color = Color.ParseColor("#2C7BBC");
            sizeSegmentView.FontIconFontColor = Color.Black;
            //sizeIndicatorSettings.CornerRadius = 20;
            sizeIndicatorSettings.Position = SelectionIndicatorPosition.Fill;
            sizeSegmentView.SelectionIndicatorSettings = sizeIndicatorSettings;

            sizeSegementLayout.AddView(sizeText);
            sizeSegementLayout.AddView(sizespaceText);
            sizeSegementLayout.AddView(sizeSegmentView);


            ///DesCription
            LinearLayout desCriptionLayout = new LinearLayout(con);
            desCriptionLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 250);
            desCriptionLayout.Orientation = Android.Widget.Orientation.Vertical;
            desCriptionLayout.SetPadding(20, 0, 0, 0);

            TextView descriptionText = new TextView(con);
            descriptionText.Text = "Description";
            descriptionText.Typeface = Typeface.DefaultBold;
            descriptionText.TextSize = 12;
            descriptionText.TextAlignment = TextAlignment.TextStart;
            descriptionText.Gravity = GravityFlags.Start;

            TextView spaceText = new TextView(con);
            spaceText.SetHeight(5);

            TextView detailDescription = new TextView(con);
            detailDescription.Text = "95 % Polyester, 5 % Spandex, imported, machine wash, casual wear.This outfit keeps you cool and comfortable in quick - dry fabric that wicks away moisture.";
            detailDescription.TextSize = 12;
            detailDescription.TextAlignment = TextAlignment.TextStart;
            detailDescription.Gravity = GravityFlags.Start;

            desCriptionLayout.AddView(descriptionText);
            desCriptionLayout.AddView(spaceText);
            desCriptionLayout.AddView(detailDescription);

            TextView space = new TextView(con);

            if (IsTabletDevice(con) == true)
            {
                mainLayout.SetPadding(50, 0, 50, 0);
                descriptionText.TextSize = 16;
                detailDescription.TextSize = 16;
                sizeText.TextSize = 16;
                clothText.TextSize = 16;
                colorText.TextSize = 16;
                priceText.TextSize = 16;
            }
            if (con.Resources.DisplayMetrics.Density > 3)
            {
                segementLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 120*2);
                priceLAyout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 150 * 2);
                colorSegementLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 210 *2);
                sizeSegementLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 240 * 2);
                desCriptionLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 250 *2);
            }
            mainLayout.AddView(space);
            mainLayout.AddView(segementLayout);
            mainLayout.AddView(ClothView);
            mainLayout.AddView(priceLAyout);
            mainLayout.AddView(colorSegementLayout);
            mainLayout.AddView(sizeSegementLayout);
            mainLayout.AddView(desCriptionLayout);

            return mainLayout;
        }


        public static bool IsTabletDevice(Android.Content.Context context)
        {
            DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
            float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
            float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
            double size = Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
            return size >= 6;
        }
   

        void SegmentedView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = e.Index;
            if (index == 0)
            {
                fontIconText = "A";
            }
            else if (index == 1)
            {
                fontIconText = "B";
            }
            else
            {
                fontIconText = "C";
            }

            this.ClothView.Text = fontIconText;
        }

        void ColorSegmentView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.colorSegmentView.SelectionTextColor = ViewModel.PrimaryColors[e.Index].FontIconFontColor;
            this.ClothView.SetTextColor(ViewModel.PrimaryColors[e.Index].FontIconFontColor);
        }

    }
}
