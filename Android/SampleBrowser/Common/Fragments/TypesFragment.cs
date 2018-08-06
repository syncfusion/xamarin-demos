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
using Android.OS;
namespace SampleBrowser
{
	public class TypesFragment : Fragment
	{
		 SampleBase CurrentSample;
		HorizontalListView ScrollView;
		FrameLayout sampleView;
		Activity currentActivity;
		ListViewAdapter adapter;
		internal SamplePage currentSamplePage;
		bool createView = false, isFeaturedSamples;
		Toast toastNotification;
		List<SampleBase> typesSamples, featuredSamples;

		public TypesFragment(List<SampleBase> samples, Activity activity, bool isFeaturesFragment)
		{
			if (isFeaturesFragment)
			{
				isFeaturedSamples = true;
				featuredSamples = samples;
				if (featuredSamples.Count > 0)
					CurrentSample = featuredSamples[0];            
			}
			else
			{
				isFeaturedSamples = false;
				typesSamples = samples;
				if (typesSamples.Count > 0)
					CurrentSample = typesSamples[0];            
			}
		
			currentActivity = activity;
			toastNotification = new Toast(activity);
			createView = true;
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			if (createView)
			{
				ScrollView = (HorizontalListView)view.FindViewById(Resource.Id.List1);
				ScrollView.SetBackgroundResource(Resource.Layout.listviewborder);
				sampleView = (FrameLayout)view.FindViewById(Resource.Id.SampleView);
				adapter = new ListViewAdapter(currentActivity, isFeaturedSamples ? featuredSamples : typesSamples, 0);
				ScrollView.Adapter = adapter;
				ScrollView.ItemClick += OnListItemClick;
				if (CurrentSample != null)
					RefreshSample(CurrentSample);
			}
			base.OnViewCreated(view, savedInstanceState);
		}

		void RefreshSample(SampleBase selectedSample)
		{
			SamplePage sample;

			bool isClassExists = Type.GetType("SampleBrowser." + selectedSample.Name) != null;

			if (isClassExists)
			{
				var handle = Activator.CreateInstance(null, "SampleBrowser." + selectedSample.Name);
				sample = (SamplePage)handle.Unwrap();
				sampleView.RemoveAllViews();

				if ((currentActivity as AllControlsSamplePage).currentSamplePage != null)
					(currentActivity as AllControlsSamplePage).currentSamplePage.Destroy();

				(currentActivity as AllControlsSamplePage).currentSamplePage = sample;
				currentSamplePage = sample;
				sampleView.AddView(sample.GetSampleContent(this.View.Context));

				if (currentSamplePage.GetPropertyWindowLayout(currentActivity) != null)
					(currentActivity as AllControlsSamplePage).SettingsButton.Visibility = ViewStates.Visible;
				else
					(currentActivity as AllControlsSamplePage).SettingsButton.Visibility = ViewStates.Invisible;

				if (!selectedSample.Type.Equals(""))
				{
					string toatText = "";
					if (selectedSample.Type.ToLower().Equals("new"))
						toatText = "New";
					else if (selectedSample.Type.ToLower().Equals("updated"))
						toatText = "Updated";
					else if (selectedSample.Type.ToLower().Equals("preview"))
						toatText = "Preview";

					if (toastNotification != null)
						toastNotification.Cancel();

					toastNotification = Toast.MakeText(currentActivity, toatText, ToastLength.Short);
					toastNotification.Show();

				}
			}
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.TypesLayout, null);
		}

		protected void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var sample = isFeaturedSamples ? featuredSamples[e.Position] : typesSamples[e.Position];
			if (!CurrentSample.Name.Equals(sample.Name))
			{
				CurrentSample = sample;
				RefreshSample(CurrentSample);
				if (adapter.SelectedView != null)
					adapter.SelectedView.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Black);

				adapter.SelectedText = sample.Title;
				adapter.SelectedView = e.View;
				adapter.SelectedView.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Blue);
			}
		}
	}
}