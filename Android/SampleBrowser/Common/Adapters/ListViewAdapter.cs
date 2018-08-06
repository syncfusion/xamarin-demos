#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class ListViewAdapter : BaseAdapter<SampleBase>
    {
        List<SampleBase> items;
        Activity context;
        int CurrentIndex;
        internal View SelectedView;

        public ListViewAdapter(Activity context, List<SampleBase> items, int index)
            : base()
        {
            this.context = context;
            this.items = items;
            CurrentIndex = index;
        }

        internal string SelectedText = "";

        public override long GetItemId(int position)
        {
            return position;
        }

        public override SampleBase this[int position]
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

			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.ScrollTextView, null);
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Title;

			if (CurrentIndex == position && SelectedView == null)
			{
				SelectedView = view;
				SelectedText = item.Title;
				SelectedView.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Blue);
			}
            else if (SelectedText == item.Title)
                view.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Blue);
            else
                view.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Black);

            TextView textView = (TextView)view.FindViewById(Resource.Id.tagText);
            if (!item.Type.Equals(""))
            {
                textView.Visibility = ViewStates.Visible;

                if (item.Type.ToLower().Equals("new"))
                {
                    textView.Text = "N";
                    textView.SetBackgroundResource(Resource.Drawable.newtagcircle);                   
                }
                else if (item.Type.ToLower().Equals("updated"))
                {
                    textView.Text = "U";
                    textView.SetBackgroundResource(Resource.Drawable.updatetagcircle);
                }
                else if (item.Type.ToLower().Equals("preview"))
                {
                    textView.Text = "P";
                    textView.SetBackgroundResource(Resource.Drawable.previewtagcircle);
                }
            }
            else
            {
                textView.Visibility = ViewStates.Invisible;
            }

            return view;
        }
    }
}