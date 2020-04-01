#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	public class SampleViewActivity
	{
        #region fields

        private Activity activity;

        private FrameLayout sampleView;

        private List<SampleModel> samples;

        private SampleModel selectedSample;

        private RecyclerViewAdapter adapter;

        #endregion

        #region ctor

        public SampleViewActivity(List<SampleModel> sampleCollection, FrameLayout mainView, Activity act, int index)
		{
			activity = act;
			samples = sampleCollection;
            if (samples.Count > 0)
            {
                selectedSample = samples[index];
            }

			View view = LayoutInflater.From(mainView.Context).Inflate(Resource.Layout.SamplePageLayout, null);
			mainView.AddView(view);
			OnViewCreated(view);
		}

        #endregion

        #region properties

        internal TextView BaseTextView { get; set; }

        #endregion

        #region methods

        public void OnViewCreated(View view)
        {
            sampleView = (FrameLayout)view.FindViewById(Resource.Id.SampleView);
            var layoutManager = new LinearLayoutManager(activity, LinearLayoutManager.Horizontal, false);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.horizontal_RecyclerView);
            recyclerView.SetBackgroundResource(Resource.Layout.listviewborder);
            recyclerView.SetLayoutManager(layoutManager);

            if (samples.Count == 1)
            {
                recyclerView.Visibility = ViewStates.Gone;
            }
            else
            {
                adapter = new RecyclerViewAdapter(samples);
                adapter.ItemClick += Adapter_ItemClick;
                recyclerView.SetAdapter(adapter);
            }

            Refresh(selectedSample);
        }

        private void Adapter_ItemClick(object sender, ListViewSelectionChangedEventArgs e)
        {
            TextView selectedItem = e.SelectedItem, prevSelectedItem = e.PreviousSelectedItem;
            if (selectedItem.Text != prevSelectedItem?.Text)
            {
                selectedSample = samples[e.SelectedIndex];
                Refresh(selectedSample);
                selectedItem.SetTextColor(Color.ParseColor("#0277F5"));
                prevSelectedItem?.SetTextColor(Color.Black);
            }
        }

        private void Refresh(SampleModel selectedSample)
		{
			SamplePage samplePage;
            if (BaseTextView != null)
            {
                BaseTextView.Text = selectedSample.Title;
            }

			bool isClassExists = Type.GetType("SampleBrowser." + selectedSample.Name) != null;
			if (isClassExists)
			{
				var handle = Activator.CreateInstance(null, "SampleBrowser." + selectedSample.Name);
				samplePage = (SamplePage)handle.Unwrap();

				sampleView.RemoveAllViews();
				sampleView.AddView(samplePage.GetSampleContent(activity));
                var allControlsSamplePage = activity as AllControlsSamplePage;
                if (allControlsSamplePage != null)
                {
                    if (allControlsSamplePage.CurrentSamplePage != null)
                    {
                        allControlsSamplePage.CurrentSamplePage.Destroy();
                    }

                    allControlsSamplePage.CurrentSamplePage = samplePage;

                    allControlsSamplePage.SettingsButton.Visibility = samplePage.GetPropertyWindowLayout(activity) != null
                        ? ViewStates.Visible : ViewStates.Invisible;
				}
			}
		}

        #endregion
    }
}