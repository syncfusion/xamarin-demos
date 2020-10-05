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
using System.ComponentModel;
using Java.Lang;
using Android.Graphics;
using System.Collections.ObjectModel;
using Syncfusion.Android.PopupLayout;
using System.IO;
using System.Reflection;
using Android.Graphics.Drawables;
using Android.Content.Res;

namespace SampleBrowser
{
    [Activity(Label = "DetailsView")]
    public class DetailsView : SamplePage
    {
        LinearLayout linearLayout;
        ListView listView;
        SfPopupLayout initialPopup;
        SfPopupLayout detailsPopup;
        ContatsViewModel viewModel;
        float density;
        Context context;
        TextView Label1;

        public override View GetSampleContent(Context context)
        {
            this.context = context;
            density = context.Resources.DisplayMetrics.Density;
            viewModel = new ContatsViewModel();

            linearLayout = new LinearLayout(context);
            linearLayout.ViewAttachedToWindow += SampleLoaded;
            linearLayout.ViewDetachedFromWindow += SampleExited;
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;

            listView = new ListView(context);
            listView.SetPadding((int)(16 * density), (int)(10 * density), (int)(16 * density), 0);
            listView.DividerHeight = 16;
            listView.Divider.Alpha = 0;
            listView.SetBackgroundColor(Color.ParseColor("#F4F4F4"));
            listView.ItemClick += ListView_ItemClick;
            listView.Adapter = new CustomPopupAdapter(viewModel, context);

            Label1 = new TextView(context);
            Label1.Gravity = GravityFlags.CenterVertical;
            Label1.Alpha = 221;
            Label1.SetTextColor(Color.Gray);
            Label1.SetBackgroundColor(Color.ParseColor("#F4F4F4"));
            Label1.TextSize = 20;
            Label1.Text = "Today";
            Label1.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
            Label1.SetPadding((int)(16 * density),0,0,0);

            linearLayout.AddView(Label1, LinearLayout.LayoutParams.MatchParent, (int)(50 * density));
            linearLayout.AddView(listView);

            return linearLayout;
        }

        public override void Destroy()
        {
            base.Destroy();
            linearLayout.ViewAttachedToWindow -= SampleLoaded;
            linearLayout.ViewDetachedFromWindow -= SampleExited;
            listView.ItemClick -= ListView_ItemClick;
        }

        private void SampleExited(object sender, View.ViewDetachedFromWindowEventArgs e)
        {
            initialPopup.Dispose();
            initialPopup = null;
            if (detailsPopup != null)
            {
                detailsPopup.Dispose();
                detailsPopup = null;
            }
        }

        private void SampleLoaded(object sender, View.ViewAttachedToWindowEventArgs e)
        {
            DisplayInitialPopup();
        }

        private void DisplayInitialPopup()
        {
            initialPopup = new SfPopupLayout(context);
            initialPopup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            initialPopup.PopupView.ShowFooter = true;
            initialPopup.PopupView.ShowCloseButton = false;
            initialPopup.PopupView.HeaderTitle = "Notification !";
            initialPopup.PopupView.AcceptButtonText = "OK";
            initialPopup.PopupView.PopupStyle.HeaderTextSize = 16;
            initialPopup.StaysOpen = true;
            TextView messageView = new TextView(context);
            messageView.Text = "Click on the contact tile to view the options";
            messageView.SetTextColor(Color.Black);
            messageView.SetBackgroundColor(Color.White);
            messageView.TextSize = 14;
            initialPopup.PopupView.ContentView = messageView;
            initialPopup.PopupView.ContentView.SetPadding((int)(10 * density), (int)(10 * density), (int)(10 * density), (int)(10 * density));
            initialPopup.PopupView.PopupStyle.CornerRadius = 3;
            initialPopup.PopupView.HeightRequest = 180;
            initialPopup.Show();
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            CreateDetailsPopup(e.View);
            if ((50 * density) + e.View.Bottom + (130 * density) >= listView.Bottom)
                detailsPopup.ShowRelativeToView(e.View, RelativePosition.AlignTop, 0, 0);
            else
                detailsPopup.ShowRelativeToView(e.View, RelativePosition.AlignBottom, 0, 0);
        }

        private void CreateDetailsPopup(View view)
        {
            detailsPopup = new SfPopupLayout(context);
            detailsPopup.PopupView.WidthRequest = (int)(view.Width / Resources.System.DisplayMetrics.Density);
            detailsPopup.PopupView.HeightRequest = 130;
            detailsPopup.PopupView.ShowHeader = false;
            detailsPopup.PopupView.PopupStyle.BorderColor = Color.White;
            detailsPopup.PopupView.PopupStyle.BorderThickness = 5;
            detailsPopup.PopupView.ShowFooter = false;
            detailsPopup.StaysOpen = false;
            detailsPopup.PopupView.PopupStyle.CornerRadius = 5;
            detailsPopup.PopupView.AnimationMode = AnimationMode.None;
            detailsPopup.PopupView.ContentView = GetCustomPopupView(this.context, view);
        }

        private View GetCustomPopupView(Context context, View view)
        {
            LinearLayout mainLinearLayout;
            LinearLayout linearLayout1;
            LinearLayout linearLayout2;
            LinearLayout linearLayout3;
            ImageView imageView1;
            ImageView imageView2;
            ImageView imageView3;
            TextView label1;
            TextView label2;
            TextView label3;

            imageView1 = new ImageView(context);
            imageView1.Alpha = 137;
            
            imageView1.SetImageResource(Resource.Drawable.Popup_SendMessage);

            label1 = new TextView(context);
            label1.Click += Label1_Click;
            label1.Alpha = 0.87f;
            label1.Gravity = GravityFlags.Top;
            label1.SetTextColor(Color.Black);
            label1.TextSize = 16;
            label1.Text = "Send a message";

            linearLayout1 = new LinearLayout(context);
            linearLayout1.Orientation = Android.Widget.Orientation.Horizontal;
            linearLayout1.AddView(imageView1, (int)(60 * density), (int)(20 * density));
            linearLayout1.AddView(label1, LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

            imageView2 = new ImageView(context);
            imageView2.Alpha = 0.6f;
            imageView2.SetImageResource(Resource.Drawable.Popup_BlockContact);

            label2 = new TextView(context);
            label2.Alpha = 137;
            label2.Click += Label2_Click;
            label2.Gravity = GravityFlags.Top;
            label2.SetTextColor(Color.Black);
            label2.TextSize = 16;
            label2.Alpha = 0.87f;
            label2.Text = "Block/report spam";

            linearLayout2 = new LinearLayout(context);
            linearLayout2.Orientation = Android.Widget.Orientation.Horizontal;
            linearLayout2.AddView(imageView2, (int)(60 * density), (int)(20 * density));
            linearLayout2.AddView(label2, LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

            imageView3 = new ImageView(context);
            imageView3.Alpha = 0.6f;
            imageView3.SetImageResource(Resource.Drawable.Popup_ContactInfo);

            label3 = new TextView(context);
            label2.Alpha = 0.87f;
            label3.Gravity = GravityFlags.Top;
            label3.SetTextColor(Color.Black);
            label3.TextSize = 16;
            label3.Click += Label3_Click;
            label3.Text = "Call details";

            linearLayout3 = new LinearLayout(context);
            linearLayout3.Orientation = Android.Widget.Orientation.Horizontal;
            linearLayout3.AddView(imageView3, (int)(60 * density), (int)(20 * density));
            linearLayout3.AddView(label3, LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

            mainLinearLayout = new LinearLayout(context);
            mainLinearLayout.SetPadding((int)(10 * density), (int)(10 * density), (int)(10 * density), (int)(10 * density));
            mainLinearLayout.Orientation = Android.Widget.Orientation.Vertical;
            mainLinearLayout.SetBackgroundColor(Color.ParseColor("#FFFFFF"));
            mainLinearLayout.AddView(linearLayout1, LinearLayout.LayoutParams.MatchParent, (int)(40 * density));
            mainLinearLayout.AddView(linearLayout2, LinearLayout.LayoutParams.MatchParent, (int)(40 * density));
            mainLinearLayout.AddView(linearLayout3, LinearLayout.LayoutParams.MatchParent, (int)(40 * density));
            return mainLinearLayout;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(context, "Contact Blocked", ToastLength.Short);
            toast.Show();
            Handler handler = new Handler();
            handler.PostDelayed(new Runnable(toast.Cancel), 500);
            handler = null;
            toast = null;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(context, "Message Sent", ToastLength.Short);
            toast.Show();
            Handler handler = new Handler();
            handler.PostDelayed(new Runnable(toast.Cancel), 500);
            handler = null;
            toast = null;
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(context, "No outgoing call history", ToastLength.Short);
            toast.Show();
            Handler handler = new Handler();
            handler.PostDelayed(new Runnable(toast.Cancel), 500);
            handler = null;
            toast = null;
        }

    }

    public class CustomPopupAdapter : BaseAdapter
    {
        ContatsViewModel viewModel;
        Context context;

        public CustomPopupAdapter(ContatsViewModel viewmodel, Context contxt) : base()
        {
            this.viewModel = viewmodel;
            this.context = contxt;
        }

        public override int Count
        {
            get
            {
                return viewModel.ContactsList.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView != null)
                return convertView;
            else
            {
                var view = new CustomView(this.context);
                view.SetValue(viewModel.ContactsList[position]);
                return view;
            }
        }
    }

    public class CustomView : GridLayout
    {
        ImageView image1;
        ImageView image2;
        TextView Label1;
        TextView Label2;
        GridLayout DetailsLayout;
        internal static TextView currentLabel;

        public CustomView(Context context) : base(context)
        {
            this.SetPadding(25, 25, 25, 25);
            this.SetBackgroundColor(Color.ParseColor("#FFFFFF"));
            this.ColumnCount = 3;
            this.RowCount = 1;

            image1 = new ImageView(context);
            image1.SetPadding(0, 10, 0, 10);

            image2 = new ImageView(context);
            image2.SetPadding(0, (int)(15 * Resources.DisplayMetrics.Density), 0, (int)(15 * Resources.DisplayMetrics.Density));

            Label1 = new TextView(context);
            Label1.Gravity = GravityFlags.Start;
            Label1.Alpha = 221;          
            Label1.SetTextColor(Color.Black);
            Label1.TextSize = 20;

            Label2 = new TextView(context);
            Label2.Gravity = GravityFlags.Start;
            Label2.Alpha = 137;
            Label2.TextSize = 16;
            Label2.SetTextColor(Color.Gray);

            DetailsLayout = new GridLayout(context);
            DetailsLayout.RowCount = 4;
            DetailsLayout.ColumnCount = 1;
            DetailsLayout.AddView(Label1);
            DetailsLayout.AddView(Label2);
            DetailsLayout.SetPadding((int)(20 * this.Resources.DisplayMetrics.Density), (int)(5 * this.Resources.DisplayMetrics.Density), 0, 0);

            if(MainActivity.IsTablet)
                this.AddView(image1, (int)(70 * this.Resources.DisplayMetrics.Density), (int)(70 * this.Resources.DisplayMetrics.Density));
            else
            this.AddView(image1, (int)(50 * this.Resources.DisplayMetrics.Density), (int)(50 * this.Resources.DisplayMetrics.Density));
            this.AddView(DetailsLayout, Resources.DisplayMetrics.WidthPixels - (int)(120 * Resources.DisplayMetrics.Density) - 70, ViewGroup.LayoutParams.MatchParent);
            this.AddView(image2, (int)(50 * this.Resources.DisplayMetrics.Density), (int)(50 * this.Resources.DisplayMetrics.Density));
        }

        internal void SetValue(object obj)
        {
            List<int> list = new List<int>();
            Random r = new Random();
            list.Add(Resource.Drawable.PopupImage1);
            list.Add(Resource.Drawable.PopupImage2);
            list.Add(Resource.Drawable.PopupImage3);
            list.Add(Resource.Drawable.PopupImage4);
            list.Add(Resource.Drawable.PopupImage5);
            list.Add(Resource.Drawable.PopupImage6);
            list.Add(Resource.Drawable.PopupImage7);
            list.Add(Resource.Drawable.PopupImage8);
            list.Add(Resource.Drawable.PopupImage9);
            list.Add(Resource.Drawable.PopupImage10);
            var contacts = obj as Contacts;
            Label1.Text = contacts.ContactName;
            currentLabel = Label1;
            Label2.Text = contacts.ContactNumber.ToString();
            image1.SetImageResource(list[r.Next(10)]);
            image2.SetImageResource(Resource.Drawable.Popup_CallerImage);
            image2.Alpha = 0.54f;
        }

    }

}