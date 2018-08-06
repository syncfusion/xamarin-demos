#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	[Activity(Theme = "@style/PropertyApp", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
	public class AllControlsSamplePage : Activity
	{
		public AllControlsSamplePage()
		{
		}

		internal SampleBase SelectedGroup;
		bool isselected = true;
		SampleViewActivity sampleViewActivity;
		internal SamplePage currentSamplePage;
		internal RelativeLayout SettingsButton;

		protected override void OnCreate(Bundle savedInstanceState)
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
			popup.Focusable = true;
			popup.DismissEvent += Popup_DismissEvent;
			imageButton.Click += delegate
			{
				popup.ContentView = propertyWindow;
				if (currentSamplePage.PropertyView == null)
				{
					currentSamplePage.PropertyView = currentSamplePage.GetPropertyWindowLayout(this);
				}
				LinearLayout linear = (LinearLayout)propertyWindow.FindViewById(Resource.Id.container);
				linear.RemoveAllViews();
				linear.AddView(currentSamplePage.PropertyView);
				if (isselected)
				{
					popup.ShowAsDropDown(imageButton, 0, 280);
					popup.Focusable = true;
					popup.Update();

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

			ActionBar.CustomView = mCustomView;
			SelectedGroup = (Group)MainActivity.SelectedIntent.GetSerializableExtra("sample");

			TextView textView = (TextView)FindViewById(Resource.Id.title_text);
			textView.Text = SelectedGroup.Title;
			RelativeLayout textParent = (RelativeLayout)FindViewById(Resource.Id.textParent);
			textParent.Click += (object sender, EventArgs e) =>
			{
				OnBackButtonPressed();
			};

			if ((SelectedGroup as Group).Features.Count > 0)
			{
				this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
				AddTab("Types", new TypesFragment((SelectedGroup as Group).samples, this,false));

				AddTab("Features", new TypesFragment((SelectedGroup as Group).Features, this, true));
			}
			else
			{
				this.ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
				FrameLayout frameLayout = (FrameLayout)mainView.FindViewById(Resource.Id.fragment_content);
				sampleViewActivity = new SampleViewActivity((SelectedGroup as Group).samples, frameLayout, this, 0);
				if ((SelectedGroup as Group).samples.Count > 0)
				{
					textView.Text = (SelectedGroup as Group).samples[0].Title;
				}
				sampleViewActivity.BaseTextView = textView;
			}

			if (savedInstanceState != null && ActionBar.TabCount > 0)
				this.ActionBar.SelectTab(this.ActionBar.GetTabAt(savedInstanceState.GetInt("tab")));
			base.OnCreate(savedInstanceState);
		}

		private void Popup_DismissEvent(object sender, EventArgs e)
		{
			isselected = true;
		}

		public override void OnBackPressed()
		{
			Finish();
			OnBackButtonPressed();
			base.OnBackPressed();
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);
			base.OnSaveInstanceState(outState);
		}

		void AddTab(string tabText, Fragment view)
		{
			var tab = this.ActionBar.NewTab();
			tab.SetText(tabText);

			tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
			{
				if (tab.Text == "Features")
				{

				}

				var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragment_content);
				if (fragment != null)
					e.FragmentTransaction.Remove(fragment);
				e.FragmentTransaction.Add(Resource.Id.fragment_content, view);
			};

			tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
			{
				e.FragmentTransaction.Remove(view);
			};

			this.ActionBar.AddTab(tab);
		}

		public override void Finish()
		{
			if (currentSamplePage != null)
			{
				currentSamplePage.Destroy();
				currentSamplePage = null;
			}
			base.Finish();
		}

		public void OnBackButtonPressed()
		{
			Finish();           
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