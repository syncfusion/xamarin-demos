#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Carousel;
using static Android.App.ActionBar;

namespace SampleBrowser
{
    public class CarouselAdapter : ICarouselAdapter
    {
        Context myComtext;

        ObservableCollection<CarouselPropertyClass> myList = new ObservableCollection<CarouselPropertyClass>();

        public CarouselAdapter(Context context, ObservableCollection<CarouselPropertyClass> k)
        {
            myComtext = context;

            myList = k;
        }
        public View GetItemView(SfCarousel carousel, int index)
        {
            double density1;
            int width1, height1;
            List<int> imageID = new List<int>();
            width1 = myComtext.Resources.DisplayMetrics.WidthPixels;
            height1 = myComtext.Resources.DisplayMetrics.HeightPixels;
            density1 = myComtext.Resources.DisplayMetrics.Density;

            FrameLayout linear = new FrameLayout(myComtext);
            linear.SetBackgroundColor(Color.White);
            linear.LayoutParameters = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, (int)(110 * density1));

            var item = myList[index];

            TextView Srcimage = new TextView(myComtext);
            Srcimage.Text = (myList[index] as CarouselPropertyClass).Unicode;
            Srcimage.Typeface = Typeface.CreateFromAsset(myComtext.Assets, "CarouselIcon.ttf");
            Srcimage.SetTextColor((myList[index] as CarouselPropertyClass).ItemColor);
            Srcimage.TextSize = 40;
            Srcimage.SetWidth((int)(110 * density1));
            Srcimage.SetHeight((int)(110 * density1));
            Srcimage.TextAlignment = TextAlignment.Center;
            Srcimage.Gravity = GravityFlags.Center;

            linear.AddView(Srcimage);
            return linear;

        }
    }

    public class LoadMore_Mobile : SamplePage
    {
        Context context;
        SfCarousel carousel;
        SfCarousel carousel1;
        SfCarousel carousel2;
        double density;
        int width, height;
        LinearLayout mainLayout;
        CarouselPropertyClass carouselObj;
        CarouselModel modelObj;

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            return null;
        }

        public override View GetSampleContent(Context context1)
        {
            context = context1;
            width = context1.Resources.DisplayMetrics.WidthPixels;
            height = context1.Resources.DisplayMetrics.HeightPixels;
            density = context1.Resources.DisplayMetrics.Density;

            carousel = new SfCarousel(context);
            carousel1 = new SfCarousel(context);
            carousel2 = new SfCarousel(context);
            carouselObj = new CarouselPropertyClass();
            modelObj = new CarouselModel();

            carousel.AllowLoadMore = true;
            carousel.LoadMoreItemsCount = 2;

            carousel1.AllowLoadMore = true;
            carousel1.LoadMoreItemsCount = 2;

            carousel2.AllowLoadMore = true;
            carousel2.LoadMoreItemsCount = 2;

            TextView text = new TextView(context1) { TextAlignment = TextAlignment.Center, Text = "Load More...", TextSize = 10, Typeface = Typeface.DefaultBold, Gravity = GravityFlags.Center };
            text.SetBackgroundColor(Color.White);

            TextView text1 = new TextView(context1) { TextAlignment = TextAlignment.Center, Text = "Load More...", TextSize = 10, Typeface = Typeface.DefaultBold, Gravity = GravityFlags.Center };
            text1.SetBackgroundColor(Color.White);

            TextView text2 = new TextView(context1) { TextAlignment = TextAlignment.Center, Text = "Load More...", TextSize = 10, Typeface = Typeface.DefaultBold, Gravity = GravityFlags.Center };
            text2.SetBackgroundColor(Color.White);

            carousel.LoadMoreView = text;
            carousel1.LoadMoreView = text1;
            carousel2.LoadMoreView = text2;

            carousel.ItemsSource = modelObj.ApplicationCollection;
            carousel.ItemSpacing = 80;

            carousel1.ItemsSource = modelObj.TransportCollection;
            carousel1.ItemSpacing = 80;

            carousel2.ItemsSource = modelObj.OfficeCollection;
            carousel2.ItemSpacing = 80;

            carousel.ViewMode = ViewMode.Linear;
            carousel1.ViewMode = ViewMode.Linear;
            carousel2.ViewMode = ViewMode.Linear;

            if (context.Resources.DisplayMetrics.Density > 1.5)
            {
                carousel.ItemHeight = Convert.ToInt32(110 * context.Resources.DisplayMetrics.Density);
                carousel.ItemWidth = Convert.ToInt32(110 * context.Resources.DisplayMetrics.Density);
                carousel1.ItemHeight = Convert.ToInt32(110 * context.Resources.DisplayMetrics.Density);
                carousel1.ItemWidth = Convert.ToInt32(110 * context.Resources.DisplayMetrics.Density);
                carousel2.ItemHeight = Convert.ToInt32(110 * context.Resources.DisplayMetrics.Density);
                carousel2.ItemWidth = Convert.ToInt32(110 * context.Resources.DisplayMetrics.Density);
            }
            carousel.LayoutParameters = new LayoutParams(LinearLayout.LayoutParams.MatchParent, (int)(120 * density));
            carousel1.LayoutParameters = new LayoutParams(LinearLayout.LayoutParams.MatchParent, (int)(120 * density));
            carousel2.LayoutParameters = new LayoutParams(LinearLayout.LayoutParams.MatchParent, (int)(120 * density));

            mainLayout = new LinearLayout(context);
            mainLayout.Orientation = Orientation.Vertical;
            mainLayout.SetGravity(GravityFlags.CenterHorizontal);
            mainLayout.SetBackgroundColor(Color.Rgb(249, 249, 249));
            mainLayout.LayoutParameters = new LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            carousel.Adapter = new CarouselAdapter(context1, modelObj.ApplicationCollection);
            carousel1.Adapter = new CarouselAdapter(context1, modelObj.TransportCollection);
            carousel2.Adapter = new CarouselAdapter(context1, modelObj.OfficeCollection);

            HeaderMethod(context);
            mainLayout.AddView(carousel);
            HeaderMethod1(context);
            mainLayout.AddView(carousel1);
            HeaderMethod2(context);
            mainLayout.AddView(carousel2);

            return mainLayout;
        }
        private void HeaderMethod(Android.Content.Context con)
        {
            LinearLayout hearderLayout = new LinearLayout(con);
            hearderLayout.LayoutParameters = new LinearLayout.LayoutParams((int)width, (int)(30 * density));
            hearderLayout.SetBackgroundColor(Color.Rgb(249, 249, 249));
            hearderLayout.SetPadding(30, 12, 270, 5);

            TextView attachText = new TextView(con);
            attachText.Text = "Application";
            attachText.SetTextColor(Color.Rgb(51, 51, 51));
            attachText.SetHeight((int)(24 * density));
            attachText.TextSize = 18;
            attachText.Typeface = Typeface.DefaultBold;
            attachText.TextAlignment = TextAlignment.TextStart;
            attachText.Gravity = GravityFlags.Left;

            hearderLayout.AddView(attachText);

            mainLayout.AddView(hearderLayout);
        }

        private void HeaderMethod1(Android.Content.Context con)
        {
            LinearLayout hearderLayout = new LinearLayout(con);
            hearderLayout.LayoutParameters = new LinearLayout.LayoutParams((int)width, (int)(30 * density));
            hearderLayout.SetBackgroundColor(Color.Rgb(249, 249, 249));
            hearderLayout.SetPadding(30, 12, 270, 5);

            TextView attachText = new TextView(con);
            attachText.Text = "Food";
            attachText.SetTextColor(Color.Rgb(51, 51, 51));
            attachText.SetHeight((int)(24 * density));
            attachText.TextSize = 18;
            attachText.Typeface = Typeface.DefaultBold;
            attachText.TextAlignment = TextAlignment.TextStart;
            attachText.Gravity = GravityFlags.Left;

            hearderLayout.AddView(attachText);

            mainLayout.AddView(hearderLayout);
        }
        private void HeaderMethod2(Android.Content.Context con)
        {
            LinearLayout hearderLayout = new LinearLayout(con);
            hearderLayout.LayoutParameters = new LinearLayout.LayoutParams((int)width, (int)(30 * density));
            hearderLayout.SetBackgroundColor(Color.Rgb(249, 249, 249));
            hearderLayout.SetPadding(30, 12, 270, 5);

            TextView attachText = new TextView(con);
            attachText.Text = "Banking";
            attachText.SetTextColor(Color.Rgb(51, 51, 51));
            attachText.SetHeight((int)(24 * density));
            attachText.TextSize = 18;
            attachText.Typeface = Typeface.DefaultBold;
            attachText.TextAlignment = TextAlignment.TextStart;
            attachText.Gravity = GravityFlags.Left;

            hearderLayout.AddView(attachText);

            mainLayout.AddView(hearderLayout);
        }
    }

}

