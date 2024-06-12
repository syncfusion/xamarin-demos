#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Maps;


using Android.Widget;
using Android.OS;
using Android.Graphics;
using Com.Syncfusion.Sfbusyindicator;
using Android.Net;
using Android.Content;
using Android.Views;
using Com.Syncfusion.Carousel;
using System.Collections.Generic;
using Android.Util;

namespace SampleBrowser
{
    public class OSM : SamplePage
    {
        SfMaps maps;
        Handler handler;
        Context sampleContext;
        FrameLayout mainGrid;
        FrameLayout childGrid;
        int rowCount = 0;
        int columnCount = 0;
        double previousWidth;
        double previousHeight;
        float density;
        ImageryLayer layer;

        /// <summary>
        /// Gets or sets the padding value to provide gap between the items from the selected item.
        /// </summary>
        private float carouselGap;
        public OSM()
        {
            carouselGap = 30;
        }

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {

            LinearLayout layout = new LinearLayout(context);
            density = context.Resources.DisplayMetrics.Density;
            sampleContext = context;
            layout.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);
            layout.Orientation = Orientation.Vertical;
            layout.LayoutChange += Layout_LayoutChange1;
            handler = new Handler();
            AddGridView();
            SfBusyIndicator sfBusyIndicator = new SfBusyIndicator(context);
            sfBusyIndicator.IsBusy = true;
            sfBusyIndicator.AnimationType = Com.Syncfusion.Sfbusyindicator.Enums.AnimationTypes.SlicedCircle;
            sfBusyIndicator.ViewBoxWidth = 50;
            sfBusyIndicator.ViewBoxHeight = 50;
            sfBusyIndicator.TextColor = Color.ParseColor("#779772");
            layout.AddView(sfBusyIndicator);
            TextView textView = new TextView(context);
            textView.TextSize = 16;
            textView.SetPadding(10, 20, 10, 0);

            handler = new Handler();
            textView.Text = "Since this application requires network connection, Please check your network connection.";
            textView.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.WrapContent, Android.Views.ViewGroup.LayoutParams.WrapContent);

            if (IsOnline())
            {
                Java.Lang.Runnable run = new Java.Lang.Runnable(() =>
                {
                    layout.RemoveView(sfBusyIndicator);
                    layout.AddView(mainGrid);

                });
                handler.PostDelayed(run, 100);
            }
            else
            {
                Java.Lang.Runnable run = new Java.Lang.Runnable(() =>
                {
                    layout.RemoveView(sfBusyIndicator);
                    layout.AddView(textView);

                });
                handler.PostDelayed(run, 100);
            }


            return layout;
        }

        private void Layout_LayoutChange1(object sender, View.LayoutChangeEventArgs e)
        {
            var layout = sender as LinearLayout;
            if (childGrid != null && childGrid.ChildCount > 0 &&
                previousWidth == layout.Width && previousHeight == layout.Height)
                return;
            if (layout != null)
            {
                InitializeChildGrid();
                if (layout.Height > 0)
                {
                    double row = layout.Height / 512;
                    if (Math.Ceiling(row) <= 0)
                        row = 1;
                    else
                        row = Math.Ceiling(row);
                    rowCount = (int)row + 1;
                    previousHeight = layout.Height;
                }
                if (layout.Width > 0)
                {
                    double column = layout.Width / 512;
                    if (Math.Ceiling(column) <= 0)
                        column = 1;
                    else
                        column = Math.Ceiling(column);
                    columnCount = (int)column + 1;
                    previousWidth = layout.Width;
                }
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        ImageView image = new ImageView(sampleContext);
                        image.SetImageResource(Resource.Drawable.grid);
                        image.SetMinimumHeight((int)(512 * density));
                        image.SetMinimumWidth((int)(512 * density));
                        image.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                            ViewGroup.LayoutParams.MatchParent);
                        image.LayoutParameters.Height = (int)(512 * density);
                        image.LayoutParameters.Width = (int)(512 * density);
                        image.SetPadding(0, 0, 0, 0);
                        image.SetX(i * (512 * density));
                        image.SetY(j * (512 * density));
                        childGrid.AddView(image);
                    }
                }
                childGrid.SetClipChildren(false);
            }
        }

        public bool IsOnline()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)sampleContext.GetSystemService(Context.ConnectivityService);
            NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            var isConnected = networkInfo == null ? false : networkInfo.IsConnected;
            return isConnected;
        }

        void AddGridView()
        {
            InitializeChildGrid();
            mainGrid = new FrameLayout(sampleContext);
            mainGrid.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
               ViewGroup.LayoutParams.MatchParent);
            mainGrid.AddView(childGrid);
            maps = new SfMaps(sampleContext);
            maps.ZoomLevel = 4;
            maps.MinZoom = 4;
            maps.MaxZoom = 10;
            maps.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);
            layer = new ImageryLayer();

            layer.GeoCoordinates = new PointF(27.1751f, 78.0421f);

            PopulationMarker marker1 = new PopulationMarker(sampleContext);
            marker1.Latitude = 20.6843f;
            marker1.Longitude = -88.5678f;
            layer.Markers.Add(marker1);

            PopulationMarker marker2 = new PopulationMarker(sampleContext);
            marker2.Latitude = -13.1631f;
            marker2.Longitude = -72.5450f;
            layer.Markers.Add(marker2);

            PopulationMarker marker3 = new PopulationMarker(sampleContext);
            marker3.Latitude = -22.9519f;
            marker3.Longitude = -43.2106f;
            layer.Markers.Add(marker3);

            PopulationMarker marker4 = new PopulationMarker(sampleContext);
            marker4.Latitude = 41.8902;
            marker4.Longitude = 12.4922;
            layer.Markers.Add(marker4);

            PopulationMarker marker5 = new PopulationMarker(sampleContext);
            marker5.Latitude = 30.3285;
            marker5.Longitude = 35.4444;
            layer.Markers.Add(marker5);

            PopulationMarker marker6 = new PopulationMarker(sampleContext);
            marker6.Latitude = 27.1751;
            marker6.Longitude = 78.0421;
            layer.Markers.Add(marker6);

            PopulationMarker marker7 = new PopulationMarker(sampleContext);
            marker7.Latitude = 40.4319;
            marker7.Longitude = 116.5704;
            layer.Markers.Add(marker7);

            maps.Adapter = new MarkerAdapter(sampleContext);

            maps.Layers.Add(layer);
            mainGrid.AddView(maps);
            mainGrid.SetClipChildren(false);

            List<int> arrayList = new List<int>();
            arrayList.Add(Resource.Drawable.Mexico);
            arrayList.Add(Resource.Drawable.Peru);
            arrayList.Add(Resource.Drawable.Christ);
            arrayList.Add(Resource.Drawable.Colosseum);
            arrayList.Add(Resource.Drawable.Petra);
            arrayList.Add(Resource.Drawable.TajMahal);
            arrayList.Add(Resource.Drawable.China_wall);

            List<string> descriptionList = new List<string>();
            descriptionList.Add("Mayan ruins on Mexico's Yucatan Peninsula. It was one of the largest Maya cities, thriving from around A.D. 600 to 1200.");
            descriptionList.Add("An inca citadel built in the mid-1400s. It was not widely known until the early 20th century.");
            descriptionList.Add("An enormous statue of Jesus Christ with open arms. A symbol of Christianity across the world, the statue has also become a cultural icon of both Rio de Janeiro and Brazil.");
            descriptionList.Add("Built between A.D. 70 and 80. It is one of the most popular touristattractions in Europe.");
            descriptionList.Add("It is a historic and archaeological city in southern Jordan. Petra lies around Jabal Al-Madbah in a basin surrounded by mountains which form the eastern flank of the Arabah valley that runs from the Dead Sea to the Gulf of Aqaba.");
            descriptionList.Add("It is an ivory-white marble mausoleum on the southern bank of the river Yamuna in the Indian city of Agra.");
            descriptionList.Add("The Great Wall of China is a series of fortifications that were built across the historical northern borders of ancient Chinese states and Imperial China as protection against various nomadic groups from the Eurasian Steppe.");

            List<string> headerList = new List<string>();
            headerList.Add("Chichen Itza, Mexico");
            headerList.Add("Machu Picchu, Peru");
            headerList.Add("Chirst the Redeemer, Brazil");
            headerList.Add("Colosseum, Rome");
            headerList.Add("Petra, Jordan");
            headerList.Add("Taj Mahal, India");
            headerList.Add("Great wall of China, China");

            DisplayMetrics displayMetrics = sampleContext.Resources.DisplayMetrics;
            float screenWidth = displayMetrics.WidthPixels;
            float screenHeight = displayMetrics.HeightPixels;
            var density = displayMetrics.Density;

            LinearLayout layout = new LinearLayout(sampleContext);
            layout.Orientation = Orientation.Horizontal;
            layout.SetPadding(0, 0, 0, 10);
            layout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            layout.SetVerticalGravity(GravityFlags.Bottom);

            var itemWidth = screenWidth * 0.7;

            SfCarousel carousel = new SfCarousel(sampleContext);
            carousel.RotationAngle = 0;
            carousel.ItemWidth = (int)itemWidth;
            carousel.ItemHeight = (int)(110 * sampleContext.Resources.DisplayMetrics.Density);
            carousel.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, carousel.ItemHeight);
            carousel.SelectedIndex = 5;
            carousel.SelectedItemOffset = (int)(carousel.ItemWidth / 2) - (int)(carouselGap * density);
            
            List<SfCarouselItem> dataSource = new List<SfCarouselItem>();

            for (int i = 0; i <= 6; i++)
            {
                LinearLayout linearLayout = new LinearLayout(sampleContext);
                linearLayout.SetBackgroundColor(Color.White);
                linearLayout.Orientation = Orientation.Horizontal;
                linearLayout.SetBackgroundResource((Resource.Drawable.carousel_corner_radius));
                linearLayout.LayoutParameters = new Android.Views.ViewGroup.LayoutParams((int)itemWidth, (int)carousel.ItemHeight);

                var width = (int)(0.6f * itemWidth);

                LinearLayout layout1 = new LinearLayout(sampleContext);
                layout1.Orientation = Orientation.Vertical;
                layout1.LayoutParameters = new Android.Views.ViewGroup.LayoutParams((int)width, (int)carousel.ItemHeight);
                layout1.SetPadding(15, 15, 15, 15);

                TextView textView = new TextView(sampleContext);
                textView.Text = headerList[i];

                textView.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
                textView.TextAlignment = TextAlignment.TextStart;
                textView.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(width - 30, ViewGroup.LayoutParams.WrapContent);
                layout1.AddView(textView);

                textView = new TextView(sampleContext);
                textView.Text = descriptionList[i];
                textView.SetMaxLines(3);
                textView.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
                textView.TextAlignment = TextAlignment.TextStart;
                textView.SetPadding(0, 10, 0, 0);
                textView.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(width - 30, ViewGroup.LayoutParams.WrapContent);
                layout1.AddView(textView);
                linearLayout.AddView(layout1);

                SfCarouselItem sfCarouselItem = new SfCarouselItem(sampleContext);

                width = (int)(0.4f * itemWidth);

                LinearLayout layout2 = new LinearLayout(sampleContext);
                layout2.SetPadding(10, 15, 15, 15);

                layout2.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(width, carousel.ItemHeight);
                ImageView imageView = new ImageView(sampleContext);
                imageView.SetBackgroundResource((Resource.Drawable.carousel_corner_radius));
                
                imageView.SetImageResource(arrayList[i]);
                imageView.SetScaleType(ImageView.ScaleType.FitXy);
                imageView.ClipToOutline = true;

                layout2.AddView(imageView);

                linearLayout.AddView(layout2);
                sfCarouselItem.ContentView = linearLayout;
                dataSource.Add(sfCarouselItem);
            }

            carousel.DataSource = dataSource;
            carousel.SelectionChanged += Carousel_SelectionChanged;
            layout.AddView(carousel);
            mainGrid.AddView(layout);

            LinearLayout linear = new LinearLayout(sampleContext);
            linear.Orientation = Orientation.Horizontal;
            linear.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.MatchParent);
            linear.SetHorizontalGravity(GravityFlags.End);
            linear.SetVerticalGravity(GravityFlags.Bottom);
            TextView textView1 = new TextView(sampleContext);
            textView1.Text = "©";
            textView1.SetBackgroundColor(Color.White);
            textView1.SetTextColor(Color.Black);
            textView1.SetPadding(2, 2, 2, 2);
            linear.AddView(textView1);
            TextView textView2 = new TextView(sampleContext);
            textView2.Text = "OpenStreetMap contributors.";
            textView2.SetTextColor(Color.DeepSkyBlue);
            textView2.SetPadding(0, 2, 3, 2);
            textView2.SetBackgroundColor(Color.White);
            textView2.Clickable = true;
            textView2.Click += TextView2_Click;
            linear.AddView(textView2);
            mainGrid.AddView(linear);
        }

        private void Carousel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = e.SfCarousel.SelectedIndex;
            if (index == 0)
            {
                layer.GeoCoordinates = new PointF(20.6843f, -88.5678f);
            }
            else if (index == 1)
            {
                layer.GeoCoordinates = new PointF(-13.1631f, -72.5450f);
            }
            else if (index == 2)
            {
                layer.GeoCoordinates = new PointF(-22.9519f, -43.2106f);
            }
            else if (index == 3)
            {
                layer.GeoCoordinates = new PointF(41.8902f, 12.4922f);
            }
            else if (index == 4)
            {
                layer.GeoCoordinates = new PointF(30.3285f, 35.4444f);
            }
            else if (index == 5)
            {
                layer.GeoCoordinates = new PointF(27.1751f, 78.0421f);
            }
            else if (index == 6)
            {
                layer.GeoCoordinates = new PointF(40.4319f, 116.5704f);
            }
        }

        private void TextView2_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://www.openstreetmap.org/copyright");
            var intent = new Intent(Intent.ActionView, uri);
            sampleContext.StartActivity(intent);
        }

        void InitializeChildGrid()
        {
            if (childGrid == null)
            {
                childGrid = new FrameLayout(sampleContext);
                childGrid.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                   ViewGroup.LayoutParams.MatchParent);
                childGrid.SetClipChildren(false);
            }
        }
    }
}