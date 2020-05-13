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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.PopupLayout;
using Android.Graphics;
using Android.Content.Res;
using System.Threading.Tasks;
using static Android.Views.View;
using Android.Util;

namespace SampleBrowser
{
    public class MovieAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        FrameLayout mainView;
        int count = 0;
        public MovieAdapter(Activity context, List<TableItem> items,FrameLayout view)
            : base()
        {
            this.context = context;
            this.items = items;
            this.mainView = view;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            view = context.LayoutInflater.Inflate(Resource.Layout.CustomListView, null);
            count++;
            return CreateMovieTile(view as LinearLayout, item);
        }

        private LinearLayout CreateMovieTile (LinearLayout view,TableItem item)
        {
            var density = Resources.System.DisplayMetrics.Density;

            ImageView img = new ImageView(context);
            img.SetPadding(16,16,12 ,16);
            img.SetImageResource(item.ImageResourceId);
            if (MainActivity.IsTablet)
                view.AddView(img, (int)(125 * density), (int)(142 * density));
            else
                view.AddView(img, (int)(103 * density), (int)(117 * density));

            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Android.Widget.Orientation.Vertical;

            TextView t1 = new TextView(context);
            t1.Text = item.Heading;
            t1.SetTextColor(Color.ParseColor("#000000"));
            t1.SetTextSize(ComplexUnitType.Dip, 16);
            if (MainActivity.IsTablet)
                t1.SetPadding((int)(12 * density), (int)(12 * density), 0, (int)(8 * density));
            else
                t1.SetPadding((int)(12 * density), 0, 0, (int)(8 * density));

            TextView t2 = new TextView(context);
            t2.SetTextColor(Color.Argb(54,00,00,00));
            t2.Text = item.SubHeading;
            t2.SetTextSize(ComplexUnitType.Dip, 12);
            t2.SetPadding((int)(12 * density), 0, 0, (int)(10 * density));


            LinearLayout certificateLayout = new LinearLayout(context);
            certificateLayout.Orientation = Android.Widget.Orientation.Horizontal;
            certificateLayout.SetPadding(0, 20, 0, 0);

            TextView t3 = new TextView(context);
            t3.Text = "2D";
            t3.SetX((int)(12 * density));
            t3.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            t3.SetTextColor(Color.Argb(54, 00, 00, 00));
            t3.SetTextSize(ComplexUnitType.Dip, 10);
            t3.SetBackgroundResource(Resource.Layout.BorderLayout);

            TextView t4 = new TextView(context);
            t4.Text = "3D";
            t4.SetTextColor(Color.Argb(54, 00, 00, 00));
            t4.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            t4.SetX((int)(22 * density));
            t4.SetTextSize(ComplexUnitType.Dip, 10);
            t4.SetBackgroundResource(Resource.Layout.BorderLayout);

            if (item.Heading == "AA-Team" || item.Heading == "Configuring 2" || item.Heading == "Inside Us 2" || item.Heading == "Clash Of The Titans")
            {
                TextView t5 = new TextView(context);     
                t5.Text = "UA";                          
                t5.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
                t5.SetTextColor(Color.Argb(54, 00, 00, 00));
                t5.SetX((int)(32 * density));
                t5.SetTextSize(ComplexUnitType.Dip, 10);
                t5.SetBackgroundResource(Resource.Layout.BorderLayout);

                certificateLayout.AddView(t3, (int)(30 * density), (int)(20 * density));
                certificateLayout.AddView(t4, (int)(30 * density), (int)(20 * density));
                certificateLayout.AddView(t5, (int)(30 * density), (int)(20 * density));
            }
            else
            {
                certificateLayout.AddView(t3, (int)(30 * density), (int)(20 * density));
                certificateLayout.AddView(t4, (int)(30 * density), (int)(20 * density));
            }
            linear.AddView(t1);
            linear.AddView(t2);
            linear.AddView(certificateLayout);

            if (MainActivity.IsTablet)
                view.AddView(linear, (int)(Resources.System.DisplayMetrics.WidthPixels - (195 * density)), ViewGroup.LayoutParams.MatchParent);
            else
                view.AddView(linear, (int)(Resources.System.DisplayMetrics.WidthPixels - (183 * density)), ViewGroup.LayoutParams.MatchParent);

            Button bookButton = new Button(context);
            bookButton.SetTextColor(Color.White);
            bookButton.SetTextSize(ComplexUnitType.Dip, 14);
            bookButton.Gravity = GravityFlags.Center;
            bookButton.SetY((int)(43 *density));
            if (MainActivity.IsTablet)
                bookButton.SetPadding(0, 0, (int)(12 * density), 0);
            else
                bookButton.SetPadding((int)(12 * density), 0, (int)(12 * density), 0);
            bookButton.SetText("Book", TextView.BufferType.Normal);
            bookButton.SetBackgroundColor(Color.ParseColor("#007CEE"));
            bookButton.Click += BookButton_Click;
            if (MainActivity.IsTablet)
                view.AddView(bookButton, (int)(65 * density), (int)(30 * density));
            else
                view.AddView(bookButton, (int)(60 * density), (int)(30 * density));
            return view;
        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            var child = this.mainView.GetChildAt(0);
            this.mainView.RemoveAllViews();
            if (child.Id == 1)
            {
                this.mainView.AddView(PopupCustomizations.secondPage, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            }
            var backbutton = ((((context as AllControlsSamplePage).SettingsButton.Parent as RelativeLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as RelativeLayout).GetChildAt(0);
            backbutton.Click += backbutton_Click;
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            if (this.mainView != null && this.mainView.ChildCount > 0)
            {
                var child = this.mainView.GetChildAt(0);
                if (child != null && child.Id == 2)
                {
                    this.mainView.RemoveView(child);
                    if (PopupCustomizations.movieList.Parent == null)
                    {
                        this.mainView.AddView(PopupCustomizations.movieList);
                    }
                }
            }
        }
    }

    public class TableItem
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public int ImageResourceId { get; set; }
        public string Timing1 { get; set; }
        public string Timing2 { get; set; }
    }
}
