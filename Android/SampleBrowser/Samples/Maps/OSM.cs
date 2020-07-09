#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        public OSM()
        {

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
            maps.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);
            ImageryLayer layer = new ImageryLayer();
            maps.Layers.Add(layer);
            mainGrid.AddView(maps);
            mainGrid.SetClipChildren(false);
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