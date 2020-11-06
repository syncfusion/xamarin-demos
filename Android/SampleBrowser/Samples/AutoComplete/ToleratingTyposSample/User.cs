#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using System.Linq;

namespace SampleBrowser
{
	public class User
	{
		public string count = "0";
		public string Text { get; set; }
		public string Image { get; set; }
		public string Count
		{
			get
			{
				return "About " + count + " results";
			}
			set
			{
				count = value;
			}
		}

		public override string ToString()
		{
			return Text + " " + Count;
		}
	}

	public class MyCustomListAdapter : BaseAdapter<User>
	{
		List<User> users;
		ImageManager imageManager;
		public MyCustomListAdapter(List<User> users)
		{
			this.users = users;
			imageManager = new ImageManager();
		}

		public override User this[int position]
		{
			get
			{
				return users[position];
			}
		}

		public override int Count
		{
			get
			{
				return users.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;

			if (view == null)
			{
				view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.userRow, parent, false);

				var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
				var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
				name.TextSize = 14;
				var department = view.FindViewById<TextView>(Resource.Id.departmentTextView);
				view.Tag = new ViewHolder() { Image = photo, Text = name, Count = department };
			}

			var holder = (ViewHolder)view.Tag;

			holder.Image.SetImageDrawable(imageManager.Get(parent.Context, users[position].Image));
			holder.Text.Text = users[position].Text;
			holder.Count.Text = users[position].Count;

			return view;
		}
	}

	public class ImageManager
	{
		Dictionary<string, Drawable> cache = new Dictionary<string, Drawable>();

		public Drawable Get(Context context, string url)
		{
			if (!cache.ContainsKey(url))
			{
				var drawable = Drawable.CreateFromStream(context.Assets.Open(url), null);

				cache.Add(url, drawable);
			}

			return cache[url];
		}
	}

	public class UserData
	{
		public List<User> Users { get; private set; }

		public UserData()
		{
			var temp = new List<User>();

			AddUser(temp, "General", "all.png", "0");
			AddUser(temp, "Maps", "Maps.png", "0");
			AddUser(temp, "Images", "Picture.png", "0");
			AddUser(temp, "News", "Newspaper.png", "0");
			AddUser(temp, "Video", "Media.png", "0");
			AddUser(temp, "Music", "Music.png", "0");
			AddUser(temp, "Books", "Book.png", "0");
			AddUser(temp, "Flight", "Aeroplane.png", "0");
			AddUser(temp, "Quick Search", "Spaceship.png", "0");

			Users = temp.ToList();
		}

		void AddUser(List<User> users, string name, string image, string count)
		{
			users.Add(new User()
			{
				Text = name,
				Count = count,
				Image = image,
			});

			//users.Add(new User()
			//{
			//    Text = "dVirendra Thakur",
			//    Count = "Xamarin Android & Xamarin Forms Development",
			//    Image = "Image4.png",
			//});
		}

	}

	public class ViewHolder : Java.Lang.Object
	{
		public ImageView Image { get; set; }
		public TextView Text { get; set; }
		public TextView Count { get; set; }
	}
}
