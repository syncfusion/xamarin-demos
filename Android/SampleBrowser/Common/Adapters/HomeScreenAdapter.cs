#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	public class HomeScreenAdapter : BaseAdapter<SampleBase>
	{
		List<SampleBase> items;
		Activity context;
		public HomeScreenAdapter(Activity context, List<SampleBase> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
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
				view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Title;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Description;
			int resourceid = context.Resources.GetIdentifier("drawable/" + item.ImageId, null, context.PackageName);
			if (resourceid == 0)
				resourceid = context.Resources.GetIdentifier("drawable/rangenavigator", null, context.PackageName);
			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(resourceid);
			TextView textView = (TextView)view.FindViewById(Resource.Id.tagText);
			if (!item.Type.Equals(""))
			{
				textView.Visibility = ViewStates.Visible;
				if (item.Type.ToLower().Equals("new"))
				{
					textView.Text = "New";
					textView.SetBackgroundResource(Resource.Drawable.newtagbackground);

				}
				else if (item.Type.ToLower().Equals("updated"))
				{
					textView.Text = "Updated";
					textView.SetBackgroundResource(Resource.Drawable.updatetagbackground);
				}
				else if (item.Type.ToLower().Equals("preview"))
				{
					textView.Text = "Preview";
					textView.SetBackgroundResource(Resource.Drawable.previewtagbackground);
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