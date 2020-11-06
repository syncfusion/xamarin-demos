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
using Syncfusion.SfPullToRefresh;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Java.Lang;
using Android.Graphics;

namespace SampleBrowser
{
    public class CustomBaseAdapter : BaseAdapter
    {
        Activity context;
        ObservableCollection<Mail> items;
        private Random random;

        public CustomBaseAdapter(Activity activity, ObservableCollection<Mail> inboxItems)
        {
            context = activity;
            items = inboxItems;
            random = new Random();
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ListViewTemplate, null);
            }

            var image = view.FindViewById<CircleViewOfTemplate>(Resource.Id.imageView);
            var senderLabel = view.FindViewById<TextView>(Resource.Id.sender);
            var subjectLabel = view.FindViewById<TextView>(Resource.Id.subject);
            var detailLabel = view.FindViewById<TextView>(Resource.Id.details);
            var date = view.FindViewById<TextView>(Resource.Id.date);

            senderLabel.TextSize = 18;
            subjectLabel.TextSize = 14;
            detailLabel.TextSize = 12;
            date.TextSize = 12;

            senderLabel.Text = items[position].Sender;
            subjectLabel.Text = items[position].Subject;
            detailLabel.Text = items[position].Details;

            image.Text = senderLabel.Text[0].ToString();
            image.backgroundColor = items[position].BackgroundColor;
            image.Invalidate();
            return view;
        }
    }
}