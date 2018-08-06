#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	[Activity(Theme = "@style/PropertyApp", MainLauncher = false,ScreenOrientation = ScreenOrientation.Portrait)]
	public class NewSampleActivityPage : Activity
	{
		public NewSampleActivityPage()
		{
		}

		internal SampleBase SelectedGroup;
		internal SamplePage currentSamplePage;
		bool isselected = true;
		internal RelativeLayout SettingsButton;
		int SelectedIndex = 0;
		SampleViewActivity sampleViewActivity;
		List<SampleBase> Samples;
		protected override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			ActionBar.SetDisplayHomeAsUpEnabled(true);
			ActionBar.SetDisplayShowCustomEnabled(true);
			ActionBar.SetIcon(new ColorDrawable(Color.Transparent));
			ActionBar.SetDisplayShowTitleEnabled(false);
			LayoutInflater mInflater = LayoutInflater.From(this);
			View mCustomView = mInflater.Inflate(Resource.Layout.CustomActionBar, null);
			RelativeLayout imageButton = (RelativeLayout)mCustomView.FindViewById(Resource.Id.imageButton);
			View propertyWindow = mInflater.Inflate(Resource.Layout.Propertywindow, null);
			View mainView = mInflater.Inflate(Resource.Layout.layout, null);
			SettingsButton = imageButton;
			SetContentView(mainView);
			PopupWindow popup = new PopupWindow(propertyWindow, FrameLayout.LayoutParams.MatchParent,
			                                    FrameLayout.LayoutParams.MatchParent);
			imageButton.Click += delegate
			{
				popup.ContentView = propertyWindow;
				View propview = currentSamplePage.GetPropertyWindowLayout(this);
				LinearLayout linear = (LinearLayout)propertyWindow.FindViewById(Resource.Id.container);
				linear.RemoveAllViews();
				linear.AddView(propview);
				if (isselected)
				{
					popup.ShowAsDropDown(imageButton, 0, 280);
					isselected = false;
				}


				ImageView iconclose = (ImageView)propertyWindow.FindViewById(Resource.Id.close);
				Button discard = (Button)propertyWindow.FindViewById(Resource.Id.discard);
				Button apply = (Button)propertyWindow.FindViewById(Resource.Id.apply);

				iconclose.Click += delegate
				{
					popup.Dismiss();
					isselected = true;
				};

				discard.Click += delegate
				{
					popup.Dismiss();
					isselected = true;
				};


				apply.Click += delegate
				{
					currentSamplePage.OnApplyChanges(currentSamplePage.SampleView);
					popup.Dismiss();
					isselected = true;
				};
			};


			if (MainActivity.isFeatureSamples)
			{
				SelectedIndex = Int32.Parse(MainActivity.SelectedIntent.GetSerializableExtra("sample").ToString());
				Samples = MainActivity.FeatureSamples;
			}
			else
			{
				SelectedIndex = FeaturesFragment.CurrentIndex;
				Samples = FeaturesFragment.Samples;
			}

			ActionBar.CustomView = mCustomView;


			TextView textView = (TextView)FindViewById(Resource.Id.title_text);
			textView.Text = Samples[SelectedIndex].Title;
			RelativeLayout textParent = (RelativeLayout)FindViewById(Resource.Id.textParent);
			textParent.Click += (object sender, EventArgs e) =>
			{

				OnBackButtonPressed();

			};
			this.ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
			FrameLayout frameLayout = (FrameLayout)mainView.FindViewById(Resource.Id.fragment_content);
			sampleViewActivity = new SampleViewActivity(Samples, frameLayout, this, SelectedIndex);
			sampleViewActivity.BaseTextView = textView;

			base.OnCreate(savedInstanceState);
		}

		public override void Finish()
		{
			base.Finish();
		}

		public void OnBackButtonPressed()
		{
            if(currentSamplePage!=null)
            {
                currentSamplePage.Destroy();
                currentSamplePage = null;
            }
			Finish();
			base.OnBackPressed();
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					OnBackButtonPressed();
					break;

			}
			return base.OnOptionsItemSelected(item);
		}
	}
}

