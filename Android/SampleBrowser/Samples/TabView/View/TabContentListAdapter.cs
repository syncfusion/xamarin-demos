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
using System.Linq;
using System.Text;
using Java.Util;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace SampleBrowser
{
    internal class TabContentListAdapter : BaseAdapter<TabData>
    {
        private IEnumerable<TabData> list;
        public TabContentListAdapter(IEnumerable<TabData> _list)
        {
            list = _list;
        }
        public override TabData this[int position] { get { return list.ToList<TabData>()[position]; } }

        public override int Count { get { return list.ToList<TabData>().Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        int currentApiVersion = (int)Build.VERSION.SdkInt;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var context = parent.Context;
            var item = list.ToList<TabData>()[position];

            var mainLayout = new GridLayout(context);
            var nameLabel = new TextView(context);
            nameLabel.TextSize = 20;
            nameLabel.SetLines(2);
            nameLabel.LayoutParameters = new ViewGroup.LayoutParams(((context.Resources.DisplayMetrics.WidthPixels / 2 - 85) / 3) * 2, 170);
            nameLabel.Text = item.Name;

            if (IsTabletDevice(context))
            {
                nameLabel.TextSize = 30;
                nameLabel.SetLines(1);
                nameLabel.LayoutParameters = new ViewGroup.LayoutParams(360, 120);
            }

            var imageView = new ImageView(context);
            var imageID = Application.Context.Resources.GetIdentifier(item.ImagePath.Replace(".jpeg", "").Replace(".jpg", ""), "drawable", Application.Context.PackageName);
            imageView.SetImageResource(imageID);
            imageView.SetPadding(10, 40, 20, 20);
            imageView.LayoutParameters = new ViewGroup.LayoutParams(640, 540);
            imageView.SetScaleType(ImageView.ScaleType.FitXy);

            if (IsTabletDevice(context))
            {
                imageView.LayoutParameters = new ViewGroup.LayoutParams(500, 500);
            }


            var priceLabel = new TextView(context);

            priceLabel.LayoutParameters = new ViewGroup.LayoutParams(170, 90);
            priceLabel.SetTextColor(Color.Rgb(128, 207, 53));
            priceLabel.TextSize = 15;
            priceLabel.Text = "$" + item.Price;

            if (IsTabletDevice(context))
            {
                priceLabel.LayoutParameters = new ViewGroup.LayoutParams(150, 120);
                priceLabel.TextSize = 20;

            }

            var description = new TextView(context);
            description.LayoutParameters = new ViewGroup.LayoutParams(context.Resources.DisplayMetrics.WidthPixels / 2 - 130, 300);
            if (!IsTabletDevice(context))
                description.SetPadding(0, -8, 10, 0);
            description.SetTextColor(Color.Rgb(134, 134, 134));
            description.TextSize = 10;
            if (!IsTabletDevice(context))
                description.SetLines(10);
            description.Text = item.Description;
            if (IsTabletDevice(context))
            {
                description.SetLines(10);
                description.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 300);
                description.SetPadding(0, 0, 10, 0);
                description.TextSize = 15;

            }

            var offerLabel = new TextView(context);
            offerLabel.SetTextColor(Color.Rgb(128, 207, 53));
            offerLabel.TextSize = 15;
            offerLabel.Text = item.Offer + "% Offer";
            offerLabel.LayoutParameters = new ViewGroup.LayoutParams(200, 90);
            if (IsTabletDevice(context))
            {
                offerLabel.TextSize = 20;
                offerLabel.LayoutParameters = new ViewGroup.LayoutParams(250, 120);

            }

            var ratingLabel = new TextView(context);
            ratingLabel.SetBackgroundColor(Color.Rgb(77, 146, 223));
            ratingLabel.Text = "*" + item.Rating;
            ratingLabel.TextSize = 13;
            ratingLabel.TextAlignment = TextAlignment.TextEnd;
            ratingLabel.Gravity = GravityFlags.Right;
            ratingLabel.SetTextColor(Color.White);
            if (IsTabletDevice(context))
            {
                ratingLabel.TextSize = 20;
                ratingLabel.Gravity = GravityFlags.Center;
                ratingLabel.LayoutParameters = new ViewGroup.LayoutParams(60, 50);

            }

            var detailsLayout = new GridLayout(context);
            detailsLayout.ColumnCount = 2;
            detailsLayout.LayoutParameters = new ViewGroup.LayoutParams(context.Resources.DisplayMetrics.WidthPixels / 2 - 100, 90);
            detailsLayout.SetPadding(0, 10, 10, 10);
            detailsLayout.AddView(priceLabel);
            detailsLayout.AddView(offerLabel);
            detailsLayout.SetBackgroundColor(Color.White);
            if (IsTabletDevice(context))
            {
                detailsLayout.LayoutParameters = new ViewGroup.LayoutParams(context.Resources.DisplayMetrics.WidthPixels / 2 - 100, 100);
            }

            var headerGrid = new GridLayout(context);
            headerGrid.LayoutParameters = new ViewGroup.LayoutParams(context.Resources.DisplayMetrics.WidthPixels / 2 - 100, 170);
            headerGrid.SetPadding(0, 10, 10, 10);
            headerGrid.ColumnCount = 2;
            headerGrid.RowCount = 1;
            headerGrid.AddView(nameLabel);
            headerGrid.AddView(ratingLabel);
            if (IsTabletDevice(context))
            {
                headerGrid.LayoutParameters = new ViewGroup.LayoutParams(800, 100);
            }

            var subGrid = new GridLayout(context);
            subGrid.LayoutParameters = new ViewGroup.LayoutParams(context.Resources.DisplayMetrics.WidthPixels / 2 - 100, 600);
            subGrid.SetPadding(10, 0, 10, 0);
            subGrid.ColumnCount = 1;
            subGrid.RowCount = 3;

            if (IsTabletDevice(context))
            {
                subGrid.LayoutParameters = new ViewGroup.LayoutParams(500, 500);
                subGrid.SetPadding(10, 30, 10, 0);
            }

            subGrid.AddView(headerGrid);
            subGrid.AddView(detailsLayout);
            subGrid.AddView(description);
            if (currentApiVersion <= 19)
            {
                mainLayout.LayoutParameters = new AbsListView.LayoutParams(context.Resources.DisplayMetrics.WidthPixels, 600);
            }
            else
            {
                mainLayout.LayoutParameters = new ViewGroup.LayoutParams(context.Resources.DisplayMetrics.WidthPixels, 600);
            }
            if (IsTabletDevice(context))
            {
                mainLayout.LayoutParameters = new ViewGroup.LayoutParams(context.Resources.DisplayMetrics.WidthPixels, 500);
            }
            mainLayout.SetPadding(20, 20, 20, 0);
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 1;
            mainLayout.AddView(imageView);
            mainLayout.AddView(subGrid);
            mainLayout.SetBackgroundColor(Color.White);
            return mainLayout;

        }
        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = Java.Lang.Math.Sqrt(Java.Lang.Math.Pow(screenWidth, 2) + Java.Lang.Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }

    }
}
