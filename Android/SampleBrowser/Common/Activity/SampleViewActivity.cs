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
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{

	public class SampleViewActivity
	{
		internal SampleBase CurrentSample;
		internal TextView BaseTextView;
		HorizontalListView ScrollView;
		FrameLayout sampleView;
		Activity activity;
		int CurrentIndex;
		internal SamplePage currentSamplePage;

		public SampleViewActivity(List<SampleBase> sample, FrameLayout mainiew, Activity act, int index)
		{
			activity = act;
			Samples = sample;
			CurrentIndex = index;
			if (Samples.Count > 0)
				CurrentSample = Samples[index];
			View view = LayoutInflater.From(mainiew.Context).Inflate(Resource.Layout.SamplePageLayout, null);
			mainiew.AddView(view);
			toastNotification = new Toast(act);
			OnViewCreated(view);
		}

		List<SampleBase> Samples;
		ListViewAdapter adapter;
		Toast toastNotification;
		public void OnViewCreated(View view)
		{
			ScrollView = (HorizontalListView)view.FindViewById(Resource.Id.List1);
			sampleView = (FrameLayout)view.FindViewById(Resource.Id.SampleView);

			if (Samples.Count == 1)
			{
				ScrollView.Visibility = ViewStates.Gone;
				ViewGroup.MarginLayoutParams param = (ViewGroup.MarginLayoutParams)sampleView.LayoutParameters;
			}
			else
			{
				adapter = new ListViewAdapter(activity, Samples, CurrentIndex);
				ScrollView.Adapter = adapter;
				ScrollView.ItemClick += OnListItemClick;
			}

			RefreshSample(CurrentSample);
		}

		void RefreshSample(SampleBase selectedSample)
		{
			SamplePage sample;
			if (BaseTextView != null)
			{
				BaseTextView.Text = selectedSample.Title;
			}
			bool isClassExists = Type.GetType("SampleBrowser." + selectedSample.Name) != null;
			if (isClassExists)
			{
				var handle = Activator.CreateInstance(null, "SampleBrowser." + selectedSample.Name);
				sample = (SamplePage)handle.Unwrap();

				currentSamplePage = sample;

				sampleView.RemoveAllViews();
				sampleView.AddView(sample.GetSampleContent(activity));
				if (activity is AllControlsSamplePage)
				{
					if ((activity as AllControlsSamplePage).currentSamplePage != null)
					{
						(activity as AllControlsSamplePage).currentSamplePage.Destroy();
					}
					(activity as AllControlsSamplePage).currentSamplePage = sample;
					if (currentSamplePage.GetPropertyWindowLayout(activity) != null)
					{
						(activity as AllControlsSamplePage).SettingsButton.Visibility = ViewStates.Visible;
					}
					else
					{
						(activity as AllControlsSamplePage).SettingsButton.Visibility = ViewStates.Invisible;
					}
				}
				else if (activity is NewSampleActivityPage)
				{
					if ((activity as NewSampleActivityPage).currentSamplePage != null)
					{
						(activity as NewSampleActivityPage).currentSamplePage.Destroy();
					}
					(activity as NewSampleActivityPage).currentSamplePage = sample;
					if (currentSamplePage.GetPropertyWindowLayout(activity) != null)
					{
						(activity as NewSampleActivityPage).SettingsButton.Visibility = ViewStates.Visible;
					}
					else
					{
						(activity as NewSampleActivityPage).SettingsButton.Visibility = ViewStates.Invisible;
					}
				}

				if (!selectedSample.Type.Equals(""))
				{
					string toatText = "";
					if (selectedSample.Type.ToLower().Equals("new"))
						toatText = "New";
					else if (selectedSample.Type.ToLower().Equals("updated"))
						toatText = "Updated";
					else if (selectedSample.Type.ToLower().Equals("preview"))
						toatText = "Preview";

					if (toastNotification != null && toastNotification.Handle != IntPtr.Zero)
						toastNotification.Cancel();

					toastNotification = Toast.MakeText(activity, toatText, ToastLength.Short);
					toastNotification.Show();
				}
			}
			else
			{
				toastNotification = Toast.MakeText(activity, "No such class exists", ToastLength.Short);
				toastNotification.Show();
			}
		}

		protected void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var sample = Samples[e.Position];
			if (!CurrentSample.Name.Equals(sample.Name))
			{
				CurrentSample = sample;
				RefreshSample(CurrentSample);
				if (adapter.SelectedView != null)
				{
					adapter.SelectedView.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Black);
				}
				adapter.SelectedText = sample.Title;
				adapter.SelectedView = e.View;
				adapter.SelectedView.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Blue);
			}
		}
	}
}